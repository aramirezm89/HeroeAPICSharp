using HeroeAPI.Modelos;
using HeroeAPI.Modelos.DTO;
using HeroeAPI.Repositorio;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Linq;

namespace HeroeAPI.Controllers
{
    [Route("api/heroe")]
    [ApiController]
    public class HeroeController : ControllerBase
    {
        internal MongoDbRepositorio _respositorio = new MongoDbRepositorio();
        private IMongoCollection<Heroe> Collection;
        private readonly IHeroeCollection _db;
        public HeroeController(IHeroeCollection db)
        {
            this._db = db;
            Collection = _respositorio.db.GetCollection<Heroe>("Heroe");
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


        [HttpGet("filtro")]
        public ActionResult GetHeroeFiltro([FromQuery]FiltrarBusquedaDTO filtrar)
        {

          
                var filtro = Collection.AsQueryable().Where(x => x.superhero.ToLower().Contains(filtrar.Nombre.ToLower())).Take(5).ToList();

                return Ok(filtro);

        
        }



        [HttpPost]
        public async Task<IActionResult> CreateHeroe([FromBody] Heroe heroe)
        {


            if (heroe == null)
            {
                return BadRequest();
            }

            heroe.superhero = heroe.superhero.ToLower().Trim();
            heroe.alter_ego = heroe.alter_ego.ToLower().Trim();
            heroe.characters = heroe.characters.ToLower().Trim();
            heroe.first_appearance = heroe.first_appearance.ToLower().Trim();
            heroe.publisher = heroe.publisher.ToLower().Trim();

            var heroeBd =  Collection.AsQueryable().Where(x => x.superhero.ToLower() == heroe.superhero).ToList();

            if (heroeBd.Count != 0)
            {
                return NoContent(); 
            }


            await _db.InsertHeroe(heroe);

            var heroeInsertado = Collection.AsQueryable().Where(x => x.superhero.ToLower() == heroe.superhero).ToList();

           return Ok(heroeInsertado[0]);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroe(string id)
        {
            await _db.DeleteHeroe(id);

            return NoContent();
        }
    }
}
