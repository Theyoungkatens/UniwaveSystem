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
        public async Task<IActionResult> GetOrderById(string id)
        {
            var order = await _context.ShippingOrders
                .Include(o => o.LogisticRoute)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();
            return Ok(order);
        }

        private async Task<string> GenerateShippingOrderId()
        {
            var now = DateTime.UtcNow; // hoặc dùng DateTime.Now nếu không dùng UTC
            var yy = now.ToString("yy");
            var MM = now.ToString("MM");

            string prefix = $"UNI{yy}{MM}";

            // Đếm số đơn trong tháng hiện tại
            int count = await _context.ShippingOrders
                .CountAsync(o => o.Id.StartsWith(prefix));

            int nextNumber = count + 1;
            string id = $"{prefix}{nextNumber.ToString("D3")}"; // Pad thành 3 chữ số

            return id;
        }
        private decimal CalculateShippingPrice(LogisticRoute route, double weightKg)
        {
            decimal price = route.BasePricePerKg;

            if (weightKg > 1)
            {
                double extraWeight = weightKg - 1;
                int extraUnits = (int)Math.Ceiling(extraWeight * 10); // Số đơn vị 0.1kg
                price += route.ExtraPricePer0_1Kg * extraUnits;
            }

            return price;
        }


        [HttpPost]
        public async Task<IActionResult> CreateShippingOrder([FromBody] ShippingOrderCreateDto dto)
        {
            var route = await _context.LogisticRoutes.FindAsync(dto.LogisticRouteId);
            if (route == null) return BadRequest("Invalid route");

            var newId = await GenerateShippingOrderId();

            decimal price = CalculateShippingPrice(route, dto.WeightKg);

            var order = new ShippingOrder
            {
                Id = newId,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                CargoType = dto.CargoType,
                PickupAddress = dto.PickupAddress,
                DeliveryAddress = dto.DeliveryAddress,
                WeightKg = dto.WeightKg,
                LogisticRouteId = dto.LogisticRouteId,
                TotalPrice = price
            };

            _context.ShippingOrders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }


    }
}
