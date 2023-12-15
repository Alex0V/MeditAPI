using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace Medit.BLL.Interfaces.Services
{
    public interface IRecommendationService
    {
        Task<List<string>> GetRecomendationByNameAsync(string meditName);
    }
}
