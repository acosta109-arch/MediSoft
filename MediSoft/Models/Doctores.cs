using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediSoft.Models;

public class Doctores
{
	[Key]
	public int DoctorId { get; set; }

	[Required(ErrorMessage = "El campo Nombre es obligatorio")]
	[RegularExpression(@"^[A-ZÁÉÍÓÚÑ][a-zA-ZÁÉÍÓÚÑ ]*$", ErrorMessage = "El nombre debe comenzar con una letra mayúscula y solo puede contener letras y espacios.")]
	public string Nombre { get; set; }

	[Required(ErrorMessage = "El campo Apellido es obligatorio")]
	[RegularExpression(@"^[A-ZÁÉÍÓÚÑ][a-zA-ZÁÉÍÓÚÑ ]*$", ErrorMessage = "El apellido debe comenzar con una letra mayúscula y solo puede contener letras y espacios.")]
	public string Apellido { get; set; }

	[Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
	public string Telefono { get; set; }

	[Required(ErrorMessage = "El campo Email es obligatorio.")]
	[EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
	public string Email { get; set; }

    public ICollection<DetalleDoctores> DetalleDoctores { get; set; } = new List<DetalleDoctores>();
}
 