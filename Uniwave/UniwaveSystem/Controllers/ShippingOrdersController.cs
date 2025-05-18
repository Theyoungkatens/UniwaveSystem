using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniwaveSystem.Data;
using UniwaveSystem.DTOs;
using UniwaveSystem.Models;

namespace UniwaveSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippingOrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShippingOrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _context.ShippingOrders
                .Include(o => o.LogisticRoute)
                .ToListAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _context.ShippingOrders
                .Include(o => o.LogisticRoute)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(ShippingOrderDto dto)
        {
            var route = await _context.LogisticRoutes.FindAsync(dto.LogisticRouteId);
            if (route == null) return BadRequest("Invalid route ID");

            var order = new ShippingOrder
            {
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                CargoType = dto.CargoType,
                PickupAddress = dto.PickupAddress,
                DeliveryAddress = dto.DeliveryAddress,
                WeightKg = dto.WeightKg,
                LogisticRouteId = dto.LogisticRouteId
            };

            _context.ShippingOrders.Add(order);
            await _context.SaveChangesAsync();
            return Ok(order);
        }
    }
}
