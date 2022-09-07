using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using App_TecnoGlass.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_TecnoGlass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public EstadoController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<EstadoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listarEstados = await _context.Estados.ToListAsync();
                return Ok(listarEstados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EstadoController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
          //  return "value";
        //}

        // POST api/<EstadoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Estados Estado)
        {
            _context.Add(Estado);
            await _context.SaveChangesAsync();
            return Ok(Estado);
        }

        // PUT api/<EstadoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Estados Estado)
        {
            try
            {
                if (id != Estado.id)
                {
                    return NotFound();
                }
                _context.Update(Estado);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La orden se actualizo" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EstadoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var estado = await _context.Estados.FindAsync(id);

                if (estado == null)
                {
                    return NotFound();
                }
                _context.Estados.Remove(estado);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Estado eliminado" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
