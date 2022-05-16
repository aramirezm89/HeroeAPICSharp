using HeroeAPI.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroeAPI.Repositorio
{
  public interface IHeroeCollection
  {
    Task InsertHeroe(Heroe heroe);
    Task UpdateHeroe(Heroe heroe);
    Task DeleteHeroe(string id);

    Task<List<Heroe>> GetAllHeroes();

    Task<Heroe> GetHeroeById(string id);

  }
}
