using System.ComponentModel.DataAnnotations;

namespace MediSoft.Models;

public class Noticias
{
	[Key]
	public int NoticiaId { get; set; }

	[Required(ErrorMessage = "El campo descripción es obligatorio.")]
	public string Descripcion { get; set; }

	[Required(ErrorMessage = "El campo fecha es obligatorio.")]
    public DateTime Fecha { get; set; }
}
 