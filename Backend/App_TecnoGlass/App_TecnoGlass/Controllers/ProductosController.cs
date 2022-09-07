using App_TecnoGlass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_TecnoGlass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ProductosController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listarProductos = await _context.Productos.ToListAsync();
                return Ok(listarProductos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Productos Producto)
        {
            _context.Add(Producto);
            await _context.SaveChangesAsync();
            return Ok(Producto);
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Productos Producto)
        {
            try
            {
                if (id != Producto.id)
                {
                    return NotFound();
                }
                _context.Update(Producto);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El producto se actualizo" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Producto = await _context.Productos.FindAsync(id);

                if (Producto == null)
                {
                    return NotFound();
                }
                _context.Productos.Remove(Producto);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Producto eliminado" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
