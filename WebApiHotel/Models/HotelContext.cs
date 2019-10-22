using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiHotel.Models
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }
        public virtual DbSet<DetalleReservacion> DetalleReservacion { get; set; }
        public virtual DbSet<EstadoFactura> EstadoFactura { get; set; }
        public virtual DbSet<EstadoHabitacion> EstadoHabitacion { get; set; }
        public virtual DbSet<EstadoReservacion> EstadoReservacion { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<ListadoTipoDescripcion> ListadoTipoDescripcion { get; set; }
        public virtual DbSet<Ocupacion> Ocupacion { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Reservacion> Reservacion { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Saludo> Saludo { get; set; }
        public virtual DbSet<TarjetaCliente> TarjetaCliente { get; set; }
        public virtual DbSet<TipoDescripcion> TipoDescripcion { get; set; }
        public virtual DbSet<TipoHabitacion> TipoHabitacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=bdHotel;User ID=sa;Password=admin123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleFactura)
                    .HasName("PK__DetalleF__DFF38252E5A609DC");

                entity.Property(e => e.IdDetalleFactura).HasColumnName("idDetalleFactura");

                entity.Property(e => e.DescripcionDetFactura)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdFactura).HasColumnName("idFactura");

                entity.Property(e => e.PrecioTotalDetalleFact).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecioUnidadDetFactura).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.DetalleFactura)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetFactruta_idFactura");
            });

            modelBuilder.Entity<DetalleReservacion>(entity =>
            {
                entity.HasKey(e => e.IdDetalleReservacion)
                    .HasName("PK__DetalleR__B802C4B5FC8DCE66");

                entity.Property(e => e.IdDetalleReservacion).HasColumnName("idDetalleReservacion");

                entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");

                entity.Property(e => e.IdReservacion).HasColumnName("idReservacion");

                entity.HasOne(d => d.IdReservacionNavigation)
                    .WithMany(p => p.DetalleReservacion)
                    .HasForeignKey(d => d.IdReservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetReserv_idReservacion");
            });

            modelBuilder.Entity<EstadoFactura>(entity =>
            {
                entity.HasKey(e => e.IdEstadoFactura)
                    .HasName("PK__EstadoFa__B11DF04F9E8B4FB1");

                entity.Property(e => e.IdEstadoFactura)
                    .HasColumnName("idEstadoFactura")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DescripcionEstadoFact)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoHabitacion>(entity =>
            {
                entity.HasKey(e => e.IdEstadoHabitacion)
                    .HasName("PK__EstadoHa__70B58445B9AEDB94");

                entity.Property(e => e.IdEstadoHabitacion)
                    .HasColumnName("idEstadoHabitacion")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DescripcionEstadoHab)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoReservacion>(entity =>
            {
                entity.HasKey(e => e.IdEstadoReservacion)
                    .HasName("PK__EstadoRe__F374EC724F912BA1");

                entity.Property(e => e.IdEstadoReservacion)
                    .HasColumnName("idEstadoReservacion")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NombreEstadoReservacion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Factura__3CD5687EC106B814");

                entity.Property(e => e.IdFactura).HasColumnName("idFactura");

                entity.Property(e => e.IdEstadoFactura).HasColumnName("idEstadoFactura");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.MontoFactura).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SerieFactura)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPagoFactura)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoFacturaNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdEstadoFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_idEstadoFactura");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_idPersona");
            });

            modelBuilder.Entity<Habitacion>(entity =>
            {
                entity.HasKey(e => e.IdHabitacion)
                    .HasName("PK__Habitaci__D9D53BE266BAD365");

                entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");

                entity.Property(e => e.DescripcionHabitacion)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.IdEstadoHabitacion).HasColumnName("idEstadoHabitacion");

                entity.Property(e => e.IdTipoHabitacion).HasColumnName("idTipoHabitacion");

                entity.Property(e => e.PrecioHabitacion).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UbicacionHabitacion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoHabitacionNavigation)
                    .WithMany(p => p.Habitacion)
                    .HasForeignKey(d => d.IdEstadoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Habitacion_idEstadoHabitacion");

                entity.HasOne(d => d.IdTipoHabitacionNavigation)
                    .WithMany(p => p.Habitacion)
                    .HasForeignKey(d => d.IdTipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Habitacion_idTipoHabitacion");
            });

            modelBuilder.Entity<ListadoTipoDescripcion>(entity =>
            {
                entity.HasKey(e => e.IdListadoTipoDescrip)
                    .HasName("PK__ListadoT__A4591C78A5C34820");

                entity.Property(e => e.IdListadoTipoDescrip).HasColumnName("idListadoTipoDescrip");

                entity.Property(e => e.IdTipoDescripcion).HasColumnName("idTipoDescripcion");

                entity.Property(e => e.IdTipoHabitacion).HasColumnName("idTipoHabitacion");

                entity.HasOne(d => d.IdTipoDescripcionNavigation)
                    .WithMany(p => p.ListadoTipoDescripcion)
                    .HasForeignKey(d => d.IdTipoDescripcion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LstTipoDesc_idTipoDescripcion");

                entity.HasOne(d => d.IdTipoHabitacionNavigation)
                    .WithMany(p => p.ListadoTipoDescripcion)
                    .HasForeignKey(d => d.IdTipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LstTipoDesc_idTipoHabitacion");
            });

            modelBuilder.Entity<Ocupacion>(entity =>
            {
                entity.HasKey(e => e.IdOcupacion)
                    .HasName("PK__Ocupacio__BE5FA2046E5E75B7");

                entity.Property(e => e.IdOcupacion).HasColumnName("idOcupacion");

                entity.Property(e => e.FechaEntradaOcupacion).HasColumnType("date");

                entity.Property(e => e.FechaSalidaOcupacion).HasColumnType("date");

                entity.Property(e => e.IdEstadoReservacion).HasColumnName("idEstadoReservacion");

                entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");

                entity.HasOne(d => d.IdEstadoReservacionNavigation)
                    .WithMany(p => p.Ocupacion)
                    .HasForeignKey(d => d.IdEstadoReservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocupacion_idEstadoReservacion");

                entity.HasOne(d => d.IdHabitacionNavigation)
                    .WithMany(p => p.Ocupacion)
                    .HasForeignKey(d => d.IdHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocupacion_idHabitacion");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Persona__A478814176DCC16F");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.ApellidoPersona)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionPersona)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdSaludo).HasColumnName("idSaludo");

                entity.Property(e => e.Nitpersona)
                    .IsRequired()
                    .HasColumnName("NITPersona")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePersona)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroPersona)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSaludoNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.IdSaludo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_idSaludo");
            });

            modelBuilder.Entity<Reservacion>(entity =>
            {
                entity.HasKey(e => e.IdReservacion)
                    .HasName("PK__Reservac__C813D8ADA8B661B6");

                entity.Property(e => e.IdReservacion).HasColumnName("idReservacion");

                entity.Property(e => e.DiaIngresoReservacion).HasColumnType("date");

                entity.Property(e => e.DiaSalidaReservacion).HasColumnType("date");

                entity.Property(e => e.IdEstadoReservacion).HasColumnName("idEstadoReservacion");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.HasOne(d => d.IdEstadoReservacionNavigation)
                    .WithMany(p => p.Reservacion)
                    .HasForeignKey(d => d.IdEstadoReservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservacion_idEstadoReserv");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Reservacion)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservacion_idPersona");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__3C872F76F8FCAF3B");

                entity.Property(e => e.IdRol)
                    .HasColumnName("idRol")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Saludo>(entity =>
            {
                entity.HasKey(e => e.IdSaludo)
                    .HasName("PK__Saludo__BE9EBF04113A6AA3");

                entity.Property(e => e.IdSaludo)
                    .HasColumnName("idSaludo")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NombreSaludo)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TarjetaCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__TarjetaC__885457EEFFD8091F");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Ccv).HasColumnName("CCV");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.NombreTarjeta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTarjeta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.TarjetaCliente)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TarjetaCliente_idPersona");
            });

            modelBuilder.Entity<TipoDescripcion>(entity =>
            {
                entity.HasKey(e => e.IdTipoDescripcion)
                    .HasName("PK__TipoDesc__C396E8F8414856F7");

                entity.Property(e => e.IdTipoDescripcion)
                    .HasColumnName("idTipoDescripcion")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NombreTipoDescripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoHabitacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabitacion)
                    .HasName("PK__TipoHabi__64CD3F69B27F71E4");

                entity.Property(e => e.IdTipoHabitacion)
                    .HasColumnName("idTipoHabitacion")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NombreTipoHabitacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6C99DC36C");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.ContraseniaUsuario)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_idPersona");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_idRol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
