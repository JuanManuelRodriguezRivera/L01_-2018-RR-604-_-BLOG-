using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01__2018_RR_604___BLOG_.Models;
using Microsoft.EntityFrameworkCore;

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
            List<blog> ListadoBlog = (from e in _blogContext.blog select e).ToList();

            if (ListadoBlog.Count() == 0)
            {
                return NotFound();
            }
            return Ok(ListadoBlog);
        }

        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByNombre(string filtro)
        {
            Usuario? usuario = (from e in _blogContext.blog where e.nombreUsuario.Contains(filtro) select e).FirstOrDefault();
            if(usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByApellido(string filtro)
        {
            usuario? usuarios = (from e in _blogContext.blog where e.apellido.Contains(filtro) select e).FirstOrDefault();
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(Usuarios);
        }

        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByRol(string filtro)
        {
            usuario? usuarios = (from e in _blogContext.blog where e.rol.Contains(filtro) select e).FirstOrDefault();
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("GetById/{usuario}")]
        public IActionResult Get(int usuarioId)
        {
            usuario? usuarios = (from e in _blogContext.blog
                          where e.usuarioId = usuarioId
                          select e).FirstOrDefault();
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }


        [HttpGet]
        [Route("GetById/{publicacion}")]
        public IActionResult Get(int publicacionId)
        {
            publicaciones? publicacione = (from e in _blogContext.blog
                          where e.publicacionId = publicacionId
                          select e).FirstOrDefault();
            if (publicacione == null)
            {
                return NotFound();
            }
            return Ok(publicacione);
        }
    }
}
