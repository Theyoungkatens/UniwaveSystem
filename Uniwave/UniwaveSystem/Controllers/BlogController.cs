using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniwaveSystem.Data;
using UniwaveSystem.DTOs;
using UniwaveSystem.Models;

namespace UniwaveSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await _context.Blogs.OrderByDescending(b => b.CreatedDate).ToListAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(BlogDto dto)
        {
            var blog = new Blog
            {
                Title = dto.Title,
                Content = dto.Content,
                Tags = dto.Tags,
                Image = dto.Image,
                Category = dto.Category,
                CreatedDate = DateTime.UtcNow
            };

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return Ok(blog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, BlogDto dto)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return NotFound();

            blog.Title = dto.Title;
            blog.Content = dto.Content;
            blog.Tags = dto.Tags;
            blog.Image = dto.Image;
            blog.Category = dto.Category;

            await _context.SaveChangesAsync();
            return Ok(blog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return NotFound();

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
