using Medit.BLL.Interfaces.Services;
using Medit.BLL.Models;
using Medit.DAL.Context;
using Medit.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using WebAPI.Models;

namespace MeditAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly MeditDBContext _context;
        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration;


        public SessionController(MeditDBContext context, IStorageService storageService, IConfiguration configuration)
        {
            this._context = context;
            this._storageService = storageService;
            this._configuration = configuration;
        }

        [Authorize]
        [HttpGet("group/{meditationId:int}")]
        public async Task<IActionResult> GetAllSession([FromRoute] int meditationId)
        {
            var result = await _context.Sessions.Where(x => x.MeditationId == meditationId).ToListAsync();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add/{meditationId:int}")]
        public async Task<IActionResult> AddSession([FromRoute] int meditationId,[FromForm] FormSessionModel formSessionModel)
        {
            // зберігаємо файл в aws S3
            var cred = new AwsCredentials()
            {
                AwsKey = _configuration["AwsConfiguration:AwsAccessKey"],
                AwsSecretKey = _configuration["AwsConfiguration:AwsSecretKey"]
            };
            var result = await _storageService.UploadFileAsync(formSessionModel.image, cred);

            if (result.StatusCode != 200)
            {
                switch (result.StatusCode)
                {
                    case (int)HttpStatusCode.NotFound:
                        return NotFound(result.Message); // Повертає 404 Not Found разом із повідомленням
                    case (int)HttpStatusCode.BadRequest:
                        return BadRequest(result.Message);
                    case (int)HttpStatusCode.InternalServerError:
                        return StatusCode(500, result.Message); // Повертає 500 Internal Server Error разом із повідомленням
                    default:
                        return StatusCode(result.StatusCode, result.Message); // Якщо невідомий статус, повертаємо 500 Internal Server Error разом із повідомленням
                }
            }

            // отримуємо url файлу
            //var fileUrl = await _storageService.GetPrivateImageUrlAsync(result.FileName, cred);
            var fileUrl = $"https://medi-coursework.s3.eu-west-2.amazonaws.com/{result.FileName}";

            // додаємо сеанс в базу даних
            var session = new Session
            {
                SessionName = formSessionModel.Name,
                MeditationId = meditationId,
                AudioKey = result.FileName,
                S3UrlAudio = fileUrl
            };
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
            return Ok(meditationId);
        }
    }
}
