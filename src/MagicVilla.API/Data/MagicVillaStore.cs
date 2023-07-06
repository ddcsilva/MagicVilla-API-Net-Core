using MagicVilla.API.Models.DTO;

namespace MagicVilla.API.Data;

public static class MagicVillaStore {
    public static List<VilaDTO> listaVilas = new() {
        new VilaDTO { Id = 1, Nome = "Vista da Piscina", Ocupacao = 2, tamanhoMetroQuadrado = 100 },
        new VilaDTO { Id = 2, Nome = "Vista do Lago", Ocupacao = 4, tamanhoMetroQuadrado = 200 },
        new VilaDTO { Id = 3, Nome = "Vista do Mar", Ocupacao = 6, tamanhoMetroQuadrado = 300 },
    };
}