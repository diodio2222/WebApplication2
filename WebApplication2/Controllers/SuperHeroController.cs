using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication2.Data;
using WebApplication2.Entitties;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SuperHeroController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("/insert")]
        public async Task <IActionResult> insert(Superman Hero) {
            if (Hero != null) {
                _dataContext.Supermans.Add(Hero);
                await _dataContext.SaveChangesAsync();
            }
            var heros = await _dataContext.Supermans.ToListAsync();
            return Ok(heros);
            
        }
        [HttpGet]
        [Route("/select")]
        public string aaafa()
        {
            return "dsfdsfds2";
        }
    }
}
 