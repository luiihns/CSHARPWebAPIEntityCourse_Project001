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

        [HttpGet]
        public ActionResult<IEnumerable<Contacto>> Get()
        {
            return Ok(listContacto);
        }

        [HttpGet("{id}")]
        public ActionResult<Contacto> Get(int id)
        {
            Contacto objContacto = listContacto.Find(x => x.Id == id);
            if (objContacto == null)
            {
                return NotFound(new { Message = "El contacto no ha sido encontrado." });
            }
            return Ok(objContacto);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Contacto>> Post(Contacto objContacto)
        {
            listContacto.Add(objContacto);
            return Ok(listContacto);
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Contacto>> Put(int id, Contacto objContacto)
        {
            Contacto tmpContacto = listContacto.Find(x => x.Id == id);
            if (tmpContacto == null)
            {
                return NotFound(new { Message = "El contacto no ha sido encontrado." });
            }
            tmpContacto.Nombre = objContacto.Nombre;
            tmpContacto.Apellido = objContacto.Apellido;
            tmpContacto.Apodo = objContacto.Apodo;
            tmpContacto.Ubicacion = objContacto.Ubicacion;

            return Ok(listContacto);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Contacto>> Delete(int id)
        {
            Contacto tmpContacto = listContacto.Find(x => x.Id == id);
            if (tmpContacto == null)
            {
                return NotFound(new { Message = "El contacto no ha sido encontrado." });
            }
            listContacto.Remove(tmpContacto);

            return Ok(listContacto);
        }
    }
}
