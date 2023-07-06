namespace MagicVilla.API.Models.DTO;

public class VilaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Detalhes { get; set; }
    public double Tarifa { get; set; }
    public int MetrosQuadrados { get; set; }
    public int Ocupacao { get; set; }
    public string UrlDaImagem { get; set; }
    public string Comodidade { get; set; }
}