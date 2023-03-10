using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoRoot.Controllers.Models;
using ProyectoRoot.Data;

namespace ProyectoRoot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactosController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: api/Contactos
        /// Obtiene todos los registros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContacto()
        {
            return await _context.Contacto.Where(x => x.IsDeleted==false).ToListAsync();
        }

        /// <summary>
        /// GET: api/Contactos/5
        /// Obtiene 1 registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> GetContacto(int id)
        {
            var contacto = await _context.Contacto.FindAsync(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return contacto;
        }

        /// <summary>
        /// PUT: api/Contactos/5
        /// Actualiza 1 registro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contacto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContacto(int id, Contacto contacto)
        {
            var dbContacto = await _context.Contacto.FindAsync(id);
            if (dbContacto == null)
                return NotFound();

            dbContacto.Nombre = contacto.Nombre;
            dbContacto.Apellido= contacto.Apellido;
            dbContacto.Apodo = contacto.Apodo;
            dbContacto.Ubicacion = contacto.Ubicacion;

            await _context.SaveChangesAsync();

            return Ok(dbContacto);
        }

        /// <summary>
        /// POST: api/Contactos
        /// Crea un registro y retorna el recién creado
        /// </summary>
        /// <param name="contacto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Contacto>> PostContacto(Contacto contacto)
        {
            _context.Contacto.Add(contacto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContacto", new { id = contacto.Id }, contacto);
        }
                
        /// <summary>
        /// DELETE: api/Contactos/5
        /// Borra 1 registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContacto(int id)
        {
            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
                        
            _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactoExists(int id)
        {
            return _context.Contacto.Any(e => e.Id == id);
        }
    }
}
