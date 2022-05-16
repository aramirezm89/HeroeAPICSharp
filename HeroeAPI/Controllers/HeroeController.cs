using HeroeAPI.Modelos;
using HeroeAPI.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HeroeAPI.Controllers
{
    [Route("api/heroe")]
    [ApiController]
    public class HeroeController : ControllerBase
    {
        private readonly IHeroeCollection _db;
        public HeroeController(IHeroeCollection db)
        {
            this._db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            return Ok(await _db.GetAllHeroes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeroe(string id)
        {
            return Ok(await _db.GetHeroeById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateHeroe([FromBody] Heroe heroe)
        {
            if (heroe == null)
            {
                return BadRequest();
            }

            if (heroe.superhero == string.Empty)
            {
                ModelState.AddModelError("Nombre", "falta nombre del heroe");

            }

            await _db.InsertHeroe(heroe);

            return Created("created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHeroe([FromBody] Heroe heroe, string id)
        {
            if (heroe == null)
            {
                return BadRequest();
            }

            if (heroe.superhero == string.Empty)
            {
                ModelState.AddModelError("SuperHero", "falta nombre del SuperHeroe");

            }

            heroe.Id = new MongoDB.Bson.ObjectId(id).ToString();

            await _db.UpdateHeroe(heroe);

            return Created("created", true);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHeroe(string id)
        {
            await _db.DeleteHeroe(id);

            return NoContent();
        }
    }
}
