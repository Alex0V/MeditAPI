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
    public class MeditationController : ControllerBase
    {
        private readonly MeditDBContext _context;
        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration;
        private readonly IRecommendationService _recommendationService;
        public MeditationController(MeditDBContext context, IStorageService storageService, IConfiguration configuration, IRecommendationService recommendationService)
        {
            this._context = context;
            this._storageService = storageService;
            this._configuration = configuration;
            this._recommendationService = recommendationService;
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllMeditation()
        {
            var result = await _context.Meditations.ToListAsync();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("getbyid/{id:int}")]
        public async Task<IActionResult> GetMeditation([FromRoute] int id)
        {
            var result = await _context.Meditations.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Authorize]
        [HttpGet("recomend/{id:int}")]
        public async Task<IActionResult> GetRecomendation([FromRoute] int id)
        {
            var result = await _context.Meditations.FirstOrDefaultAsync(x => x.Id == id);
            var recomendMeditations = await this._recommendationService.GetRecomendationByNameAsync(result.Name);
            if (result == null)
            {
                return NotFound();
            }
            var filteredMeditations = await this._context.Meditations.Where(m => recomendMeditations.Contains(m.Name)).ToListAsync();
            return Ok(filteredMeditations);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteMeditation([FromRoute] int id)
        {
            // обєкт медитації та її сеанси
            var medit_result = await _context.Meditations.FindAsync(id);
            var sesion_result = await _context.Sessions.Where(x => x.MeditationId == id).ToListAsync();

            var cred = new AwsCredentials()
            {
                AwsKey = _configuration["AwsConfiguration:AwsAccessKey"],
                AwsSecretKey = _configuration["AwsConfiguration:AwsSecretKey"]
            };
            foreach (var session in sesion_result)
            {
                await _storageService.DeleteFileAsync(session.AudioKey, cred);
            }
            await _storageService.DeleteFileAsync(medit_result.FotoKey, cred);
            _context.Meditations.Remove(medit_result);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public async Task<IActionResult> AddSessionGroup([FromForm]FormMeditModel formMeditModel)
        {
            // зберігаємо файл в aws S3
            var cred = new AwsCredentials()
            {
                AwsKey = _configuration["AwsConfiguration:AwsAccessKey"],
                AwsSecretKey = _configuration["AwsConfiguration:AwsSecretKey"]
            };
            var result = await _storageService.UploadFileAsync(formMeditModel.image, cred);

            if(result.StatusCode != 200)
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

            // додаємо медитацію в базу даних
            var medit = new Meditation
            {
                Name = formMeditModel.Name,
                Description = formMeditModel.Description,
                Duration = formMeditModel.Duration,
                FotoKey = result.FileName,
                CreationDate = DateTime.Now,
                S3UrlFoto = fileUrl
            };
            await _context.Meditations.AddAsync(medit);
            await _context.SaveChangesAsync();
            return Ok(medit.Id);
        }
    }
}
