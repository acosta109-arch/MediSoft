using System.ComponentModel.DataAnnotations;

namespace MediSoft.Models;

public class DetalleDoctores
{
    [Key]
    public int DetalleDoctoresId { get; set; }

    [Required(ErrorMessage = "El campo especialidad es obligatorio.")]
    public string Especialidad { get; set; }

}
 