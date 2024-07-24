using MediSoft.Models;
using Microsoft.EntityFrameworkCore;

namespace MediSoft.DAL;

public class Context : DbContext
{
	public Context(DbContextOptions<Context> options)
		: base(options) { }

	public DbSet<Citas> Citas { get; set; }
	public DbSet<Disponibilidades> Disponibilidades { get; set; }
	public DbSet<Doctores> Doctores { get; set; }
	public DbSet<Noticias> Noticias { get; set; }
	public DbSet<Pacientes> Pacientes { get; set; }
	public DbSet<Usuarios> Usuarios { get; set; }

	public DbSet<DetalleDoctores> DetalleDoctores { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
        // Crear usuario por defecto
        modelBuilder.Entity<Usuarios>().HasData(
			new Usuarios
			{
				UsuarioId = 1,
				Nombre = "Administrador",
				Apellido = "Del Sistema",
				Cedula = "12345678900",
				Usuario = "administrador",
				Contrasena = "Admin12345@@",
				Telefono = "8096680075",
				CorreoElectronico = "administrador-sistema@gmail.com",
				Direccion = "Ninguna",
				Rol = "Administrador"

			});
	}
} 
