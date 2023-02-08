using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Titulo Obrigatioro")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Genero Obrigatioro")]
    [MaxLength(50, ErrorMessage = "Tem que ser menos que 50")]
    public string Genero { get; set; }

    [Required]
    [Range(70,600, ErrorMessage = "Duração de 70 a 600")]
    public int Duracao { get; set; }
   
}
