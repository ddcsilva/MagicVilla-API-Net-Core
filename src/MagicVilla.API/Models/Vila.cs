using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla.API.Models;

public class Vila
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Detalhes { get; set; }
    public double Tarifa { get; set; }
    public int MetrosQuadrados { get; set; }
    public int Ocupacao { get; set; }
    public string UrlDaImagem { get; set; }
    public string Comodidade { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
}