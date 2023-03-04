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
            blog? blog = (from e in _blogContext.blog where e.nombre.Contains(filtro) select e).FirstOrDefault();
            if(blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByApellido(string filtro)
        {
            blog? blog = (from e in _blogContext.blog where e.apellido.Contains(filtro) select e).FirstOrDefault();
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByRol(string filtro)
        {
            blog? blog = (from e in _blogContext.blog where e.rol.Contains(filtro) select e).FirstOrDefault();
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpGet]
        [Route("GetById/{usuario}")]
        public IActionResult Get(int usuarioId)
        {
            blog? blog = (from e in _blogContext.blog
                          where e.usuarioId = usuarioId
                          select e).FirstOrDefault();
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }


        [HttpGet]
        [Route("GetById/{publicacion}")]
        public IActionResult Get(int publicacionId)
        {
            blog? blog = (from e in _blogContext.blog
                          where e.publicacionId = publicacionId
                          select e).FirstOrDefault();
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }
    }
}
