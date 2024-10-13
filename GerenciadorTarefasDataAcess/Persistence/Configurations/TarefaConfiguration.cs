using GerenciadorTarefas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorTarefas.Infrastructure.Configurations
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefas");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Titulo)
                .IsRequired() 
                .HasMaxLength(100); 

            builder.Property(t => t.Descricao)
                .HasMaxLength(500); 

            builder.Property(t => t.Status)
                .IsRequired()
                .HasConversion(
                    status => status.ToString(), 
                    status => (Tarefa.StatusTarefa)Enum.Parse(typeof(Tarefa.StatusTarefa), status)
                )
                .HasMaxLength(20); 


            builder.HasOne(t => t.Usuario)
                .WithMany(u => u.Tarefas) 
                .HasForeignKey(t => t.UsuarioID) 
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
