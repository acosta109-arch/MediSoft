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
				NombreCompleto = "Administrador del sistema",
				Cedula = "12345678900",
				Usuario = "administrador",
				Contrasena = "Admin12345@@",
				Telefono = "8096680075",
				CorreoElectronico = "administrador-sistema@gmail.com",
				Direccion = "Ninguna",
				Rol = "Administrador"

			});

        base.OnModelCreating(modelBuilder);
        // Crear usuario por defecto
        modelBuilder.Entity<Usuarios>().HasData(
            new Usuarios
            {
                UsuarioId = 2,
                NombreCompleto = "Jairo Camilo Acosta",
                Cedula = "98765432100",
                Usuario = "jairo_camilo",
                Contrasena = "Jairo12345@@",
                Telefono = "8094275715",
                CorreoElectronico = "camiloacostajairo5@gmail.com",
                Direccion = "Tenares",
                Rol = "Paciente"

            });

        base.OnModelCreating(modelBuilder);
        // Crear usuario por defecto
        modelBuilder.Entity<Usuarios>().HasData(
            new Usuarios
            {
                UsuarioId = 3,
                NombreCompleto = "Erick Francisco Peña De Jesus",
                Cedula = "11111111111",
                Usuario = "erick_pena",
                Contrasena = "Erick12345@@",
                Telefono = "8292964961",
                CorreoElectronico = "erickfran99@gmail.com",
                Direccion = "Villa Tapia",
                Rol = "Paciente"

            });
    } 
}  
 