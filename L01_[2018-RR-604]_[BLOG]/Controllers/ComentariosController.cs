
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Mvc;
using L01__2018_RR_604___BLOG_.Models;
using Microsoft.EntityFrameworkCore;

namespace L01__2018_RR_604___BLOG_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class comentariosController : ControllerBase
    {
        private readonly blogContext _blogContexto;

        public comentariosController(blogContext blogContexto)
        {
            _blogContexto = blogContexto;
        }

        [HttpPost]
        [Route("Crear")]

        public IActionResult GuardarComentarios([FromBody] comentarios comentarios)
        {
            try
            {
                _blogContexto.comentarios.Add(comentarios);
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
            List<comentarios> listadoComentarios = (from e in _blogContexto.comentarios select e).ToList();
            if (listadoComentarios.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoComentarios);
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarComentarios(int id, [FromBody] comentarios comentariosModificar)
        {
            comentarios? comentariosActual = (from e in _blogContexto.comentarios where e.cometarioId == id select e).FirstOrDefault();
            if (comentariosActual == null)
            {
                return NotFound();
            }
            comentariosActual.cometarioId = comentariosModificar.cometarioId;
            comentariosActual.publicacionId = comentariosModificar.publicacionId;
            comentariosActual.comentario = comentariosModificar.comentario;
            comentariosActual.usuarioId= comentariosModificar.usuarioId;

            _blogContexto.Entry(comentariosActual).State = EntityState.Modified;
            _blogContexto.SaveChanges();
            return Ok(comentariosModificar);
        }

        [HttpDelete]
        [Route("Eliminar")]

        public IActionResult EliminarComentarios(int id)
        {
            comentarios? comentarios = (from e in _blogContexto.comentarios where e.cometarioId == id select e).FirstOrDefault();
            if (comentarios == null)
            {
                return NotFound();
            }
            _blogContexto.comentarios.Attach(comentarios);
            _blogContexto.comentarios.Remove(comentarios);
            _blogContexto.SaveChanges();
            return Ok(comentarios);
        }

        [HttpGet]
        [Route("Buscar por publicacionId")]
        public IActionResult Get(int id)
        {
            comentarios? comentarios = (from e in _blogContexto.comentarios where e.publicacionId == id select e).FirstOrDefault();
            if (comentarios == null)
            {
                return NotFound();
            }
            return Ok(comentarios);
        }
    }
}
