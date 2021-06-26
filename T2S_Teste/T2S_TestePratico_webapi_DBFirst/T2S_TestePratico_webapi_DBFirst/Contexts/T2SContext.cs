using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using T2S_TestePratico_webapi_DBFirst.Domains;

#nullable disable

namespace T2S_TestePratico_webapi_DBFirst.Contexts
{
    public partial class T2SContext : DbContext
    {
        public T2SContext()
        {
        }

        public T2SContext(DbContextOptions<T2SContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Conteiner> Conteiners { get; set; }
        public virtual DbSet<Movimentacao> Movimentacaos { get; set; }
        public virtual DbSet<TipoMovimentacao> TipoMovimentacaos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-CH4GPL6M\\SQLEXPRESS; initial catalog=Exportacaoconteiner; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PK__Cliente__9B8553FCC439D4C5");

                entity.ToTable("Cliente");

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.Property(e => e.Email)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Conteiner>(entity =>
            {
                entity.HasKey(e => e.Idconteiner)
                    .HasName("PK__Conteine__8105E8D19939BEE6");

                entity.ToTable("Conteiner");

                entity.Property(e => e.Idconteiner).HasColumnName("IDConteiner");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroConteiner)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.StatusConteiner)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Conteiners)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Conteiner__IdCli__4AB81AF0");
            });

            modelBuilder.Entity<Movimentacao>(entity =>
            {
                entity.HasKey(e => e.Idmovimentacao)
                    .HasName("PK__Moviment__1A0F4EFF867B9B3C");

                entity.ToTable("Movimentacao");

                entity.Property(e => e.Idmovimentacao).HasColumnName("IDMovimentacao");

                entity.Property(e => e.DataHoraFim).HasColumnType("datetime");

                entity.Property(e => e.DataHoraInicio).HasColumnType("datetime");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Movimentacaos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Movimenta__IdCli__3D5E1FD2");

                entity.HasOne(d => d.IdTipoMovimentacaoNavigation)
                    .WithMany(p => p.Movimentacaos)
                    .HasForeignKey(d => d.IdTipoMovimentacao)
                    .HasConstraintName("FK__Movimenta__IdTip__3E52440B");
            });

            modelBuilder.Entity<TipoMovimentacao>(entity =>
            {
                entity.HasKey(e => e.IdtipoMovimentacao)
                    .HasName("PK__TipoMovi__A5099F762BFBF657");

                entity.ToTable("TipoMovimentacao");

                entity.Property(e => e.IdtipoMovimentacao).HasColumnName("IDTipoMovimentacao");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
