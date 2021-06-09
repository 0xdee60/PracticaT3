using ALIAGA_PRACTICA_T3.WEB.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALIAGA_PRACTICA_T3.WEB.Models.Maps
{
    public class HistoriaMap : IEntityTypeConfiguration<Historia>
    {
        public void Configure(EntityTypeBuilder<Historia> builder)
        {
            builder.ToTable("Historia");
            builder.HasKey(o=>o.idHistoria);

            builder.HasOne(o => o.usuario).WithMany(o => o.historias).HasForeignKey(o => o.idUsuario);
            builder.HasOne(o => o.mascota).WithMany().HasForeignKey(o=>o.idMascota);
        }
    }
}
