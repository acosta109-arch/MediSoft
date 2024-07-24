using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediSoft.Models;

public class Citas
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    [RegularExpression(@"^[A-ZÁÉÍÓÚÑ][a-zA-ZÁÉÍÓÚÑ ]*$", ErrorMessage = "El nombre debe comenzar con una letra mayúscula y solo puede contener letras y espacios.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El campo Apellido es obligatorio")]
    [RegularExpression(@"^[A-ZÁÉÍÓÚÑ][a-zA-ZÁÉÍÓÚÑ ]*$", ErrorMessage = "El apellido debe comenzar con una letra mayúscula y solo puede contener letras y espacios.")]
    public string Apellido { get; set; }

    [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "La cédula debe tener exactamente 11 dígitos.")]
    public string? Cedula { get; set; }

    [Required(ErrorMessage = "El campo numero de seguro medico es obligatorio.")]
    public string NumeroSeguro { get; set; }

    [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
    public string Telefono { get; set; }

    [ForeignKey("DoctorId")]
    [Required(ErrorMessage = "Campo doctor es obligatorio.")]
    public int DoctorId { get; set; }
    public Doctores Doctor { get; set; }

    [Required(ErrorMessage = "Campo fecha es obligatorio.")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Campo causa es obligatorio.")]
    public string Causa { get; set; } 
}
 