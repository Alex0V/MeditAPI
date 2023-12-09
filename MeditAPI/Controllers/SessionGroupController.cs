using Medit.BLL.Models;
using Medit.DAL.Context;
using Medit.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeditAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionGroupController : ControllerBase
    {
        private readonly MeditDBContext _context;
        public SessionGroupController(MeditDBContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllSessionGroup()
        {
            var result = await _context.SessionGroups.ToListAsync();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSessionGroup([FromForm]FormMeditModel formMeditModel)
        {
            return Ok(new
            {
                Message = "Моделька дійшла до сервера"
            });
        }
    }
}
