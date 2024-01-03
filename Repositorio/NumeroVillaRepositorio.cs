using MagicVilla.Data;
using MagicVilla.Models;
using MagicVilla.Repositorio.IRepositorio;
using MagicVillaNetCore.Models;

namespace MagicVilla.Repositorio
{
    public class NumeroVillaRepositorio : Repositorio<NumeroVilla>, INumeroVillaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public NumeroVillaRepositorio(ApplicationDbContext db):base(db)
        {
            this._db=db;   
        }
        public async Task<NumeroVilla> Actualizar(NumeroVilla entidad)
        {
            entidad.FechaActualizacion=DateTime.Now;
            _db.NumeroVillas.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}