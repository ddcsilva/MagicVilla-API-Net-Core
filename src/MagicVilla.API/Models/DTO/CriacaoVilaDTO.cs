using System.ComponentModel.DataAnnotations;

namespace MagicVilla.API.Models.DTO;

public class CriacaoVilaDTO
{    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    public string Nome { get; set; }

    public string Detalhes { get; set; }

    [Required]
    public double Tarifa { get; set; }

    [Required]
    public int MetrosQuadrados { get; set; }

    [Required]
    public int Ocupacao { get; set; }

    [Required]
    public string UrlDaImagem { get; set; }
    
    public string Comodidade { get; set; }
}