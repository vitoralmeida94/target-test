using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TargetTest.Core.Entities;

namespace TargetTest.Infrastructe.Persistence
{
    public partial class TargetDbContext : DbContext
    {
        public TargetDbContext()
        {
        }

        public TargetDbContext(DbContextOptions<TargetDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Plano> Planos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-U6UMEV7\\SQLEXPRESS;Database=TargetInvestimentoDb;User Id=sa;Password=123456;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF")
                    .IsFixedLength(true);

                entity.Property(e => e.DataCriacao).HasColumnType("date");

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Renda).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Plano)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.PlanoId)
                    .HasConstraintName("FK_Cliente_Plano");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.ToTable("Endereco");

                entity.Property(e => e.ClientId).ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CEP")
                    .IsFixedLength(true);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("UF")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Client)
                    .WithOne(p => p.Endereco)
                    .HasForeignKey<Endereco>(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_Cliente");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plano>(entity =>
            {
                entity.ToTable("Plano");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(5, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
