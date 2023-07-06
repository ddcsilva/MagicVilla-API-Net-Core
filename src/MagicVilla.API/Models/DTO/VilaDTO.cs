using System.ComponentModel.DataAnnotations;

namespace MagicVilla.API.Models.DTO;

public class VilaDTO
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    public string Nome { get; set; }
    public string Detalhes { get; set; }

    [Required]
    public double Tarifa { get; set; }
    public int MetrosQuadrados { get; set; }
    public int Ocupacao { get; set; }
    public string UrlDaImagem { get; set; }
    public string Comodidade { get; set; }
}