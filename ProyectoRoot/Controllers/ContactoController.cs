using Microsoft.AspNetCore.Mvc;
using ProyectoRoot.Controllers.Models;
using System.Collections.Generic;

namespace ProyectoRoot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private List<Contacto> listContacto = new List<Contacto> {
        new Contacto { Id=1,Nombre="Luis",Apellido="Navarrete",Apodo="Luii",Ubicacion="Chile" },new Contacto { Id=2,Nombre="Ana",Apellido="Sánchez",Apodo="Ani",Ubicacion="Santiago" } };

        // GET: api/<ContactoController>
        [HttpGet]
        public IEnumerable<Contacto> Get()
        {
            return listContacto;
        }

        // GET api/<ContactoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContactoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
