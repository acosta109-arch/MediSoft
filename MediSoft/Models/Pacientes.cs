using System.ComponentModel.DataAnnotations;

namespace MediSoft.Models;

public class Pacientes
{
	[Key]
	public int PacienteId { get; set; }

	[Required(ErrorMessage = "El campo Nombre es obligatorio.")]
	[RegularExpression(@"^[A-ZÁÉÍÓÚÑ][a-zA-ZÁÉÍÓÚÑ ]*$", ErrorMessage = "El nombre debe comenzar con una letra mayúscula y solo puede contener letras y espacios.")]
	public string Nombre { get; set; }

	[Required(ErrorMessage = "El campo Apellido es obligatorio")]
	[RegularExpression(@"^[A-ZÁÉÍÓÚÑ][a-zA-ZÁÉÍÓÚÑ ]*$", ErrorMessage = "El apellido debe comenzar con una letra mayúscula y solo puede contener letras y espacios.")]
	public string Apellido { get; set; }

	[Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio.")]
	public DateTime FechaNacimiento { get; set; }

    [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "La cédula debe tener exactamente 11 dígitos.")]
    public string? Cedula { get; set; }

    [Required(ErrorMessage = "El campo numero de seguro medico es obligatorio.")]
	public string NumeroSeguro { get; set; }

	[Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
	public string Telefono { get; set; }

	[Required(ErrorMessage = "El campo de Fecha de registro es obligatorio.")]
	public DateTime FechaRegistro { get; set; }
}
