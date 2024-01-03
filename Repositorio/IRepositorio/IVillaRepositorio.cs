using MagicVillaNetCore.Models;

namespace MagicVilla.Repositorio.IRepositorio
{
    public interface IVillaRepositorio : IRepositorio<Villa>
    {
        Task<Villa> Actualizar(Villa entidad);
    }
}