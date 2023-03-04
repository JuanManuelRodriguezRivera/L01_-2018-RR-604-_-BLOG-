using L01__2018_RR_604___BLOG_.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01__2018_RR_604___BLOG_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<comentarios> Listadocomentario = (from e in _blogContext.comentarios select e).Tolist();
            if (Listadocomentario.Count() == 0)
            {
                return NotFound();
            }
            return Ok(Listadocomentario);
        }
    }
}
