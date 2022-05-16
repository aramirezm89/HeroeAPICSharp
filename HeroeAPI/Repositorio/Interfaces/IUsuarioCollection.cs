using HeroeAPI.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroeAPI.Repositorio.Interfaces
{
    public interface IUsuarioCollection
    {
        Task InsertUsuario(Usuario heroe);
        Task UpdateUsuario(Usuario heroe);
        Task DeleteUsuario(string id);

        Task<List<Usuario>> GetAllUsuarios();

        Task<Usuario> GetUsuarioById(string id);
    }
}
