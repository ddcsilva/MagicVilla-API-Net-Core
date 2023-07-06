using MagicVilla.API.Models.DTO;

namespace MagicVilla.API.Data;

public static class MagicVillaStore {
    public static List<VilaDTO> listaVilas = new() {
        new VilaDTO { Id = 1, Nome = "Vista da Piscina" },
        new VilaDTO { Id = 2, Nome = "Vista do Lago" },
        new VilaDTO { Id = 3, Nome = "Vista do Mar" }
    };
}