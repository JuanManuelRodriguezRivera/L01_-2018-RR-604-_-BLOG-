using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01__2018_RR_604___BLOG_.Models;
using Microsoft.EntityFrameworkCore;

namespace L01__2018_RR_604___BLOG_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuarioController : ControllerBase
    {
        private readonly blogContext  _blogContexto;

            public usuarioController(blogContext blogContexto)
        {
            _blogContexto = blogContexto;
        }

        [HttpPost]
        [Route("Crear")]

        public IActionResult GuardarUsuarios([FromBody] usuarios usuarios)
        {
            try
            {
                _blogContexto.usuarios.Add(usuarios);
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
            List<usuarios> listadoUsuario = (from e in _blogContexto.usuarios select e).ToList();
            if (listadoUsuario.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoUsuario);
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarUsuarios(int id, [FromBody] usuarios usuarioModificar)
        {
            usuarios? usuarioActual = (from e in _blogContexto.usuarios where e.usurioId == id select e).FirstOrDefault();
            if (usuarioActual == null)
            {
                return NotFound();
            }
            usuarioActual.usurioId = usuarioModificar.usurioId;
            usuarioActual.rolId = usuarioModificar.rolId;
            usuarioActual.nombreUsuario = usuarioModificar.nombreUsuario;
            usuarioActual.clave = usuarioModificar.clave;
            usuarioActual.nombre = usuarioModificar.nombre;
            usuarioActual.apellido = usuarioModificar.clave;

            _blogContexto.Entry(usuarioActual).State = EntityState.Modified;
            _blogContexto.SaveChanges();
            return Ok(usuarioModificar);
        }

        [HttpDelete]
        [Route("Eliminar")]

        public IActionResult EliminarUsuario(int id)
        {
            usuarios? usuarios =(from e in _blogContexto.usuarios where e.usurioId == id select e).FirstOrDefault();
            if (usuarios == null)
            {
                return NotFound();
            }
            _blogContexto.usuarios.Attach(usuarios);
            _blogContexto.usuarios.Remove(usuarios);
            _blogContexto.SaveChanges();
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("Buscar por nombre")]
        public IActionResult FindByNombre(string filtro)
        {
            usuarios? usuarios =(from e in _blogContexto.usuarios where e.nombre.Contains(filtro) select e).FirstOrDefault();
            if(usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("Buscar por apellido")]
        public IActionResult FindByApellido(string filtro)
        {
            usuarios? usuarios = (from e in _blogContexto.usuarios where e.apellido.Contains(filtro) select e).FirstOrDefault();
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("Buscar por rolId")]
        public IActionResult Get(int id)
        {
            usuarios? usuarios = (from e in _blogContexto.usuarios where e.rolId == id select e).FirstOrDefault();
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }
    }
}
