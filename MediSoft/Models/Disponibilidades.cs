using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MediSoft.Models;

public class Disponibilidades
{
    [Key]
    public int DisponibilidadId { get; set; }

    [ForeignKey("DoctorId")]
    [Required(ErrorMessage = "Campo doctor es obligatorio.")]
    public int DoctorId { get; set; }
    public Doctores Doctor { get; set; }

    public string DiasDisponibilidad { get; set; }

    [Required(ErrorMessage = "Campo hora de inicio es obligatorio.")]
    public string HoraInicio { get; set; }

    [Required(ErrorMessage = "Campo hora de fin es obligatorio.")]
    public string HoraFin { get; set; }

    [Required(ErrorMessage = "Campo consultorio es obligatorio.")]
    public string Consultorio { get; set; }
} 
