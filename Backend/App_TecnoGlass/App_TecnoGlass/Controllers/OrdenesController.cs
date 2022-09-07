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
    public class OrdenesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public OrdenesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<OrdenesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listarOrdenes = await _context.Ordenes.ToListAsync();
                return Ok(listarOrdenes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<OrdenesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //  return "value";
        //}

        // POST api/<OrdenesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ordenes Orden)
        {
            _context.Add(Orden);
            await _context.SaveChangesAsync();
            return Ok(Orden);
        }

        // PUT api/<OrdenesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Ordenes Orden)
        {
            try
            {
                if (id != Orden.id)
                {
                    return NotFound();
                }
                _context.Update(Orden);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La orden se actualizo" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<OrdenesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var orden = await _context.Ordenes.FindAsync(id);

                if (orden == null)
                {
                    return NotFound();
                }
                _context.Ordenes.Remove(orden);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Orden eliminada" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
