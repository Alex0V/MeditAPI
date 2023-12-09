using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BLL.Models
{
    public class FormMeditModel
    {
        public string meditationName { get; set; } = null!;

        public string meditationDescription { get; set; } = null!;

        public IFormFile image { get; set; } = null!;
    }
}
