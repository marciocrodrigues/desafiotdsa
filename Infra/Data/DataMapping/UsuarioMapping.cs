using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.DataMapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.Property(x => x.Id);
            builder.Property(x => x.Codigo).HasMaxLength(6).HasColumnType("char(6)");
            builder.Property(x => x.Nome).HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Senha).HasMaxLength(10).HasColumnType("varchar(10)");
        }
    }
}
