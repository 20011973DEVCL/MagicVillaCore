using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}