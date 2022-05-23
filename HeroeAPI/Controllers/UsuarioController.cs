using HeroeAPI.Modelos;
using HeroeAPI.Repositorio;
using HeroeAPI.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace HeroeAPI.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        internal MongoDbRepositorio _respositorio = new MongoDbRepositorio();
        private IMongoCollection<Usuario> Collection;
        private readonly IUsuarioCollection _db;

        public UsuarioController(IUsuarioCollection db )
        {
            this._db = db;
            Collection = _respositorio.db.GetCollection<Usuario>("Usuarios");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _db.GetAllUsuarios());
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] Usuario usuario)
        {


            if (ModelState.IsValid)
            {
                var usuarioBd = Collection.AsQueryable().Where(x => x.usuario == usuario.usuario).ToList();

                if (usuarioBd.Count != 0)
                {
                    return NotFound("Usuario duplicado");
                }


                await _db.InsertUsuario(usuario);

                var usuarioInsertado = Collection.AsQueryable().Where(x => x.usuario == usuario.usuario).ToList();

                return Ok(usuarioInsertado[0]);
            }


            return BadRequest();    
           
        }

    }
}
