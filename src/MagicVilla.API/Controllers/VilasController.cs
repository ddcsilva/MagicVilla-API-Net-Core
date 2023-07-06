using MagicVilla.API.Data;
using MagicVilla.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VilasController : ControllerBase
{
    [HttpGet]
    public IEnumerable<VilaDTO> ObterVilas()
    {
        return MagicVillaStore.listaVilas;
    }

    [HttpGet("{id}")]
    public VilaDTO ObterVila(int id)
    {
        return MagicVillaStore.listaVilas.FirstOrDefault(v => v.Id == id);
    }
}