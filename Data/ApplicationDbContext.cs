using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicVilla.Models;
using MagicVillaNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Villa> Villas {get; set;}
        public DbSet<NumeroVilla> NumeroVillas {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id=1,
                    Nombre="Villa Fernanda",
                    Detalle="Tiene las tremendas Tetas",
                    ImagenUrl="",
                    Ocupantes=5,
                    MetrosCuadrados=50,
                    Tarifa=200,
                    Amenidad="",
                    FechaCreacion=DateTime.Now,
                    FechaActualizacion=DateTime.Now
                },
                new Villa()
                {
                    Id=2,
                    Nombre="Villa Maira",
                    Detalle="Tiene una Cintura y un Culo",
                    ImagenUrl="",
                    Ocupantes=7,
                    MetrosCuadrados=70,
                    Tarifa=300,
                    Amenidad="",
                    FechaCreacion=DateTime.Now,
                    FechaActualizacion=DateTime.Now
                },
                new Villa()
                {
                    Id=3,
                    Nombre="Villa Fernanda y Maira",
                    Detalle="No se a cual de las 2 me Culiaria Primero",
                    ImagenUrl="",
                    Ocupantes=7,
                    MetrosCuadrados=100,
                    Tarifa=500,
                    Amenidad="",
                    FechaCreacion=DateTime.Now,
                    FechaActualizacion=DateTime.Now
                },
                new Villa()
                {
                    Id=3000,
                    Nombre="Villa Danilo y Fernanda",
                    Detalle="Culiando a la Fernanda todo el Dia",
                    ImagenUrl="",
                    Ocupantes=7,
                    MetrosCuadrados=100,
                    Tarifa=500,
                    Amenidad="",
                    FechaCreacion=DateTime.Now,
                    FechaActualizacion=DateTime.Now
                }
            );
        }
    }
}