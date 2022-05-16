using HeroeAPI.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HeroeAPI.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioCollection _db;

        public UsuarioController(IUsuarioCollection db )
        {
            this._db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            return Ok(await _db.GetAllUsuarios());
        }

    }
}
