using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniwaveSystem.Data;
using UniwaveSystem.Models;
using UniwaveSystem.DTOs;

namespace UniwaveSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogisticRoutesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LogisticRoutesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoutes()
        {
            var routes = await _context.LogisticRoutes.ToListAsync();
            return Ok(routes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRouteById(int id)
        {
            var route = await _context.LogisticRoutes.FindAsync(id);
            if (route == null) return NotFound();
            return Ok(route);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoute(LogisticRouteDto dto)
        {
            var route = new LogisticRoute
            {
                FromLocation = dto.FromLocation,
                ToLocation = dto.ToLocation,
                BasePricePerKg = dto.BasePricePerKg,
                ExtraPricePer0_1Kg = dto.ExtraPricePer0_1Kg
            };

            _context.LogisticRoutes.Add(route);
            await _context.SaveChangesAsync();
            return Ok(route);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoute(int id, LogisticRouteDto dto)
        {
            var route = await _context.LogisticRoutes.FindAsync(id);
            if (route == null) return NotFound();

            route.FromLocation = dto.FromLocation;
            route.ToLocation = dto.ToLocation;
            route.BasePricePerKg = dto.BasePricePerKg;
            route.ExtraPricePer0_1Kg = dto.ExtraPricePer0_1Kg;

            await _context.SaveChangesAsync();
            return Ok(route);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var route = await _context.LogisticRoutes.FindAsync(id);
            if (route == null) return NotFound();

            _context.LogisticRoutes.Remove(route);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
