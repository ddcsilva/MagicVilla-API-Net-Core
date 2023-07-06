using MagicVilla.API.Data;
using MagicVilla.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VilasController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<VilaDTO>> ObterVilas()
    {
        return Ok(MagicVillaStore.listaVilas);
    }

    [HttpGet("{id:int}", Name = "ObterVila")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VilaDTO> ObterVila(int id)
    {
        if (id <= 0) return BadRequest("Id inválido");

        var vila = MagicVillaStore.listaVilas.FirstOrDefault(v => v.Id == id);

        if (vila == null) return NotFound();

        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<VilaDTO> AdicionarVila([FromBody] VilaDTO vilaDTO)
    {
        if (vilaDTO == null) return BadRequest("Vila inválida");

        if (vilaDTO.Id > 0) return StatusCode(StatusCodes.Status500InternalServerError);

        if (MagicVillaStore.listaVilas.Any(v => v.Nome == vilaDTO.Nome)) 
        {
            ModelState.AddModelError("Nome", "Vila já cadastrada");
            return BadRequest(ModelState);
        }

        vilaDTO.Id = MagicVillaStore.listaVilas.Max(v => v.Id) + 1;
        MagicVillaStore.listaVilas.Add(vilaDTO);

        return CreatedAtRoute("ObterVila", new { id = vilaDTO.Id }, vilaDTO);
    }
}