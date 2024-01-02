using MagicVilla.Data;
using MagicVilla.Repositorio.IRepositorio;
using MagicVillaNetCore.Models;

namespace MagicVilla.Repositorio
{
    public class VillaRepositorio : Repositorio<Villa>, IVillaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public VillaRepositorio(ApplicationDbContext db):base(db)
        {
            this._db=db;   
        }
        public async Task<Villa> ActualizarVilla(Villa entidad)
        {
            entidad.FechaActualizacion=DateTime.Now;
            _db.Villas.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}