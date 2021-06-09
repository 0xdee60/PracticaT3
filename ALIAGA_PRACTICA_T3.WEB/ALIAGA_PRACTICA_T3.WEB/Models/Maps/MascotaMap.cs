using ALIAGA_PRACTICA_T3.WEB.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALIAGA_PRACTICA_T3.WEB.Models.Maps
{
    public class MascotaMap : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable("Mascota");
            builder.HasKey(o=>o.idMascota);

            builder.HasOne(o => o.usuario).WithMany(o => o.mascotas).HasForeignKey(o=>o.idUsuario);
        }
    }
}
