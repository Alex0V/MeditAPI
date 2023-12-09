using Medit.BLL.Interfaces.Services;
using Medit.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("group/{SessionGroupId:int}")]
        public async Task<IActionResult> GetAllSession(int SessionGroupId)
        {
            var result = await _context.Sessions.Where(x => x.SessionGroupId == SessionGroupId).ToListAsync();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
