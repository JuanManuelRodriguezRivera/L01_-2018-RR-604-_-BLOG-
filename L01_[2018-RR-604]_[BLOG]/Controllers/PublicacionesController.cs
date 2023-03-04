using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01__2018_RR_604___BLOG_.Models;
using Microsoft.EntityFrameworkCore;

namespace L01__2018_RR_604___BLOG_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class publicacionesController : ControllerBase
    {
        private readonly blogContext _blogContexto;

        public publicacionesController(blogContext blogContexto)
        {
            _blogContexto = blogContexto;
        }

        [HttpPost]
        [Route("Crear")]

        public IActionResult GuardarPublicaciones([FromBody] publicaciones publicaciones)
        {
            try
            {
                _blogContexto.publicaciones.Add(publicaciones);
                _blogContexto.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Leer")]
        public IActionResult Get()
        {
            List<publicaciones> listadoPublicaciones = (from e in _blogContexto.publicaciones select e).ToList();
            if (listadoPublicaciones.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoPublicaciones);
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarPublicaciones(int id, [FromBody] publicaciones publicacionesModificar)
        {
            publicaciones? publicacionesActual = (from e in _blogContexto.publicaciones where e.publicacionId == id select e).FirstOrDefault();
            if (publicacionesActual == null)
            {
                return NotFound();
            }
            publicacionesActual.publicacionId = publicacionesModificar.publicacionId;
            publicacionesActual.titulo = publicacionesModificar.titulo;
            publicacionesActual.descripcion = publicacionesModificar.descripcion;
            publicacionesActual.usuarioId = publicacionesModificar.usuarioId;

            _blogContexto.Entry(publicacionesActual).State = EntityState.Modified;
            _blogContexto.SaveChanges();
            return Ok(publicacionesModificar);
        }

        [HttpDelete]
        [Route("Eliminar")]

        public IActionResult EliminarPublicaciones(int id)
        {
            publicaciones? publicaciones = (from e in _blogContexto.publicaciones where e.publicacionId == id select e).FirstOrDefault();
            if (publicaciones == null)
            {
                return NotFound();
            }
            _blogContexto.publicaciones.Attach(publicaciones);
            _blogContexto.publicaciones.Remove(publicaciones);
            _blogContexto.SaveChanges();
            return Ok(publicaciones);
        }

        [HttpGet]
        [Route("Buscar por usuarioId")]
        public IActionResult Get(int id)
        {
            publicaciones? publicaciones = (from e in _blogContexto.publicaciones where e.usuarioId == id select e).FirstOrDefault();
            if (publicaciones == null)
            {
                return NotFound();
            }
            return Ok(publicaciones);
        }
    }
}
