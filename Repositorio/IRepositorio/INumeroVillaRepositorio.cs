using MagicVilla.Models;
using MagicVillaNetCore.Models;

namespace MagicVilla.Repositorio.IRepositorio
{
    public interface INumeroVillaRepositorio : IRepositorio<NumeroVilla>
    {
        Task<NumeroVilla> Actualizar(NumeroVilla entidad);
    }
}