using System.ComponentModel.DataAnnotations;

namespace MediSoft.Models;

public class Usuarios
{
	[Key]
	public int UsuarioId { get; set; }

	[Required(ErrorMessage = "El campo Nombre es obligatorio.")]
	[RegularExpression(@"^[A-ZÁÉÍÓÚÑ][a-zA-ZÁÉÍÓÚÑ ]*$", ErrorMessage = "El nombre debe comenzar con una letra mayúscula y solo puede contener letras y espacios.")]
	public string? Nombre { get; set; }

	[Required(ErrorMessage = "El campo Apellido es obligatorio.")]
	[RegularExpression(@"^[A-ZÁÉÍÓÚÑ][a-zA-ZÁÉÍÓÚÑ ]*$", ErrorMessage = "El apellido debe comenzar con una letra mayúscula y solo puede contener letras y espacios.")]
	public string? Apellido { get; set; }

	[Required(ErrorMessage = "El campo Cédula es obligatorio.")]
	[RegularExpression(@"^\d{11}$", ErrorMessage = "La cédula debe tener exactamente 11 dígitos.")]
	public string? Cedula { get; set; }

	[Required(ErrorMessage = "El campo Usuario es obligatorio")]
	public string? Usuario { get; set; }

	[Required(ErrorMessage = "El campo Contraseña es obligatorio")]
	[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "La contraseña debe tener al menos 8 caracteres, incluyendo al menos una letra mayúscula, una letra minúscula, un número y un símbolo.")]
	public string? Contrasena { get; set; }

	[Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
	public string? Telefono { get; set; }

	[Required(ErrorMessage = "El campo Correo Electrónico es obligatorio.")]
	[EmailAddress(ErrorMessage = "Introduzca un Correo Electrónico válido.")]
	public string? CorreoElectronico { get; set; }

	[Required(ErrorMessage = "El campo Dirección es obligatorio.")]
	public string? Direccion { get; set; }

	[Required(ErrorMessage = "El campo Rol es obligatorio.")]
	public string? Rol { get; set; }

}
