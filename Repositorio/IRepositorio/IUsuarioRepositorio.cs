using MagicVilla.Models;

namespace MagicVilla.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
         Task<Usuario> Actualizar(Usuario entidad);
    }
}