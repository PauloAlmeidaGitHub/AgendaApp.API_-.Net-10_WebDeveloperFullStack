using AgendaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Infra.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TAREFAS");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("ID");

            builder.Property(t => t.Nome).HasColumnName("NOME").HasMaxLength(150).IsRequired();

            builder.Property(t => t.Data).HasColumnName("DATA").IsRequired();

            builder.Property(t => t.Hora).HasColumnName("HORA").IsRequired();

            builder.Property(t => t.Descricao).HasColumnName("DESCRICAO").HasMaxLength(255).IsRequired();

            builder.Property(t => t.Prioridade).IsRequired();
        }
    }
}
