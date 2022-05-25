using HeroeAPI.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroeAPI.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        Task InsertEntity(T heroe);
        Task UpdateEntity(T heroe);
        Task DeleteEntity(string id);

        Task<List<T>> GetAll();

        Task<T> GetEntityById(string id);

    }
}
