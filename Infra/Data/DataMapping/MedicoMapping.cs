using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.DataMapping
{
    public class MedicoMapping : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medico");
            builder.Property(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(255).HasColumnType("varchar(255)");
            builder.Property(x => x.Cpf).HasMaxLength(14).HasColumnType("varchar(14)");
            builder.Property(x => x.Crm).HasMaxLength(10).HasColumnType("varchar(10)");
            builder.Property(x => x.Especialidades).HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
        }
    }
}
