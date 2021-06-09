using ALIAGA_PRACTICA_T3.WEB.Models.Entidades;
using ALIAGA_PRACTICA_T3.WEB.Models.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALIAGA_PRACTICA_T3.WEB.Models
{
    public class T3Context:DbContext
    {
        public T3Context()
        {
        }

        public T3Context(DbContextOptions<T3Context> options)
        : base(options)
        {

        }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new MascotaMap());
            modelBuilder.ApplyConfiguration(new HistoriaMap());

        }
    }
}
