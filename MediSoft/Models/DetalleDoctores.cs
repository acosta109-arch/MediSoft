using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediSoft.Models;

public class DetalleDoctores
{
    [Key]
    public int DetalleId { get; set; }

    [Required(ErrorMessage = "El campo especialidad es obligatorio.")]
    public string DiasDisponibilidad { get; set; }

    [ForeignKey("DoctorId")]
    [Required(ErrorMessage = "Campo doctor es obligatorio.")]
    public int DoctorId { get; set; }

}
 