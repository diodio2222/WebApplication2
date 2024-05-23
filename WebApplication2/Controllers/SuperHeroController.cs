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

        // C 建立資料
        [HttpPost]
        [Route("/insert")]
        public async Task <IActionResult> insert(Superman Hero) {
            if (Hero != null) {
                _dataContext.Supermans.Add(Hero);
                await _dataContext.SaveChangesAsync();
            }
            return Ok(await _dataContext.Supermans.ToListAsync());
            
        }
        // R 查詢資料
        [HttpGet]
        [Route("/select/{id}")]
        public async Task<IActionResult> FindOne(string id)
        { 
            var hero = await _dataContext.Supermans.FindAsync(id);
            if (hero == null)
            {
                return NotFound("查無此筆資料");
            }
            return Ok(hero);
        }

        //U 更新資料
        [HttpPut]
        [Route("/Update")]
        public async Task<IActionResult> Update(Superman UpdateHero)
        {
            var hero = await _dataContext.Supermans.FindAsync(UpdateHero.Id);
            if (hero == null)
            {
                return NotFound("查無此筆資料");
            }
            hero = UpdateHero;
            _dataContext.Supermans.Update(hero);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Supermans.ToListAsync());

        }

        //D 更新資料
        [HttpDelete]
        [Route("/Delete")]
        public async Task<IActionResult> Delete(Superman DeleteHero)
        {
            var hero = await _dataContext.Supermans.FindAsync(DeleteHero.Id);
            if (hero == null)
            {
                return NotFound("查無此筆資料");
            }
            _dataContext.Supermans.Remove(DeleteHero);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Supermans.ToListAsync());

        }
    }
}
 