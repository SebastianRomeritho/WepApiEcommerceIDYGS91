using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WepApiEcommerceIDYGS91.Data;
using WepApiEcommerceIDYGS91.Models;

namespace WepApiEcommerceIDYGS91.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ProductController(ApplicationDBContext context)
        {
            _context = context;

        }
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            List<Product> list = new List<Product>();
            try
            {
                list = await _context.Products.Include(c => c.oCategory).OrderByDescending(c => c.IdProduct).ToListAsync();

                return StatusCode(StatusCodes.Status200OK, list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, list);
            }
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] Product request)
        {
            try
            {
                await _context.Products.AddAsync(request);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

           
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Product request)
        {
            try
            {
                _context.Products.Update(request);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Product user = _context.Products.Find(id);
                _context.Products.Remove(user);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
