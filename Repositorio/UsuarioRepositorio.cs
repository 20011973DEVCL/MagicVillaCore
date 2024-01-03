using MagicVilla.Data;
using MagicVilla.Models;
using MagicVilla.Repositorio.IRepositorio;

namespace MagicVilla.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepositorio(ApplicationDbContext db):base(db)
        {
           this._db = db; 
        }
        public async Task<Usuario> Actualizar(Usuario entidad)
        {
            entidad.FechaActualizacion=DateTime.Now;
            _db.Usuarios.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}