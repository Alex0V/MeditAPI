using Medit.BLL.DTO.Requests.CompletedSession;
using Medit.BLL.Interfaces.Services;
using Medit.BLL.Services;
using Medit.DAL.Context;
using Medit.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static MeditAPI.Controllers.CompletedSessionController;

namespace MeditAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompletedSessionController : ControllerBase
    {
        private readonly MeditDBContext _context;
        private readonly ICompletedSessionService completedSessionService;

        public CompletedSessionController(MeditDBContext context, ICompletedSessionService completedSessionService)
        {
            _context = context;
            this.completedSessionService = completedSessionService;
        }

        [Authorize]
        [HttpGet("users/{userName}/period/{period}")]
        public async Task<IActionResult> GetRecordsByTimeInterval(string userName, string period)
        {
            var completedSessions = await this.completedSessionService.GetRecordsByTimeInterval(userName, period);
            if (completedSessions == null)
            {
                return NotFound();
            }
            return Ok(completedSessions);
        }


        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddCompletedSession([FromBody] AddCompletedSessionRequest addcompletedSessionRequest)
        {
            await this.completedSessionService.Insert(addcompletedSessionRequest);

            return Ok();
        }
    }
}
