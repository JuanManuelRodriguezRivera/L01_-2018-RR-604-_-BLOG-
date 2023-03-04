using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01__2018_RR_604___BLOG_.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace L01__2018_RR_604___BLOG_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class blogController : ControllerBase
    {
        private readonly blogContext _blogContext;

        public blogController(blogContext blogContext)
        {
            _blogContext = blogContext;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Usuario> ListadoUsuario = (from e in _blogContext.Usuario select e).Tolist();
            if (ListadoUsuario.Count()==0)
            {
                return NotFound();
            }
            return Ok(ListadoUsuario);
        }
        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByDescription(string filtro)
        {
            Usuario? usuarios = (from e in _blogContext.Usuario where e.NombreUsuario.Contains(filtro) select e).FirstOrDefault();
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }


        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByNombre(string filtro)
        {
            Usuario? usuarios = (from e in _blogContext.Usuario where e.Nombre.Contains(filtro) select e).FirstOrDefault();
            if(usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByApellido(string filtro)
        {
            Usuario? usuarios = (from e in _blogContext.Usuario where e.Apellido.Contains(filtro) select e).FirstOrDefault();
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByRol(string filtro)
        {
            Usuario? usuarios = (from e in _blogContext.Usuario where e.RolId= ((filtro)) select e).FirstOrDefault();
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<publicaciones> ListadoPublicaciones = (from e in _blogContext.Publicaciones select e).Tolist();
            if (ListadoPublicaciones.Count() == 0)
            {
                return NotFound();
            }
            return Ok(ListadoPublicaciones);
        }

        [HttpGet]
        [Route("GetById/{publicaciones}")]
        public IActionResult Get(int usuarioId)
        {
            Usuario? usuarios = (from e in _blogContext.Publicaciones
                          where e.UsuarioId = usuarioId
                                 select e).FirstOrDefault();
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }


        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<comentarios> ListadoComentario = (from e in _blogContext.Comentarios select e).Tolist();
            if (ListadoComentario.Count() == 0)
            {
                return NotFound();
            }
            return Ok(ListadoComentario);
        }

        [HttpGet]
        [Route("GetById/{comentarios}")]
        public IActionResult Get(string publicacionId)
        {
            comentarios? comentarios = (from e in _blogContext.comentarios
                          where e.PublicacionId = publicacionId
                          select e).FirstOrDefault();
            if (comentarios == null)
            {
                return NotFound();
            }
            return Ok(comentarios);
        }
    }
}
