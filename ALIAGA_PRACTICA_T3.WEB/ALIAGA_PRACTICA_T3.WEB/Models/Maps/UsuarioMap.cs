using ALIAGA_PRACTICA_T3.WEB.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALIAGA_PRACTICA_T3.WEB.Models.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(o=>o.idUsuario);

            builder.HasMany(o => o.mascotas).WithOne(o => o.usuario).HasForeignKey(o=>o.idMascota);
            builder.HasMany(o => o.historias).WithOne(o => o.usuario).HasForeignKey(o => o.idHistoria);

        }
    }
}
