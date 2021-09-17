using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.hroads.webApi_.Domains;

#nullable disable

namespace senai.hroads.webApi_.Contexts
{
    public partial class HroadsContext : DbContext
    {
        public HroadsContext()
        {
        }

        public HroadsContext(DbContextOptions<HroadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<ClasseHabilidade> ClasseHabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<TipoHabilidade> TipoHabilidades { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public object Classe { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-OAGJCNA\\SQLEXPRESSS; initial catalog=SENAI_HROADS_TARDE; user Id=SA; pwd=SENAI@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__classe__60FFF80165874F47");

                entity.ToTable("classe");

                entity.HasIndex(e => e.NomeClasse, "UQ__classe__F1ED81023D1BA596")
                    .IsUnique();

                entity.Property(e => e.IdClasse)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idClasse");

                entity.Property(e => e.NomeClasse)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nomeClasse");
            });

            modelBuilder.Entity<ClasseHabilidade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("classeHabilidade");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__classeHab__idCla__52593CB8");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__classeHab__idHab__5165187F");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__habilida__655F75282D68BC97");

                entity.ToTable("habilidade");

                entity.HasIndex(e => e.NomeHabilidade, "UQ__habilida__08EF5E0C5B4D4E25")
                    .IsUnique();

                entity.Property(e => e.IdHabilidade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idHabilidade");

                entity.Property(e => e.IdTipoHabilidade).HasColumnName("idTipoHabilidade");

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeHabilidade");

                entity.HasOne(d => d.IdTipoHabilidadeNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoHabilidade)
                    .HasConstraintName("FK__habilidad__idTip__4F7CD00D");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__personag__E175C72EB4F581C9");

                entity.ToTable("personagem");

                entity.HasIndex(e => e.NomePersonagem, "UQ__personag__2075C7B809C288B6")
                    .IsUnique();

                entity.Property(e => e.IdPersonagem)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idPersonagem");

                entity.Property(e => e.CapacidadeMana).HasColumnName("capacidadeMana");

                entity.Property(e => e.CapacidadeVida).HasColumnName("capacidadeVida");

                entity.Property(e => e.DataAtualizacao)
                    .HasColumnType("date")
                    .HasColumnName("dataAtualizacao");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("date")
                    .HasColumnName("dataCriacao");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.NomePersonagem)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("nomePersonagem");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__personage__idCla__47DBAE45");
            });

            modelBuilder.Entity<TipoHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabilidade)
                    .HasName("PK__tipoHabi__B197B832DCBADF37");

                entity.ToTable("tipoHabilidade");

                entity.HasIndex(e => e.NomeTipoHabilidade, "UQ__tipoHabi__3E8F59B12E9E8A7F")
                    .IsUnique();

                entity.Property(e => e.IdTipoHabilidade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoHabilidade");

                entity.Property(e => e.NomeTipoHabilidade)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoHabilidade");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF1D801679");

                entity.ToTable("tipoUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.nomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A68B7747EA");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Senha)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__59FA5E80");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
