using MagicVilla.API.Data;
using MagicVilla.API.Models;
using MagicVilla.API.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VilasController : ControllerBase
{
    private readonly MagicVillaContext _context;

    public VilasController(MagicVillaContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<VilaDTO>>> ObterVilas()
    {
        return Ok(await _context.Vilas.ToListAsync());
    }

    [HttpGet("{id:int}", Name = "ObterVila")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VilaDTO>> ObterVila(int id)
    {
        if (id <= 0) { return BadRequest("Id inválido"); }

        var vila = await _context.Vilas.FirstOrDefaultAsync(v => v.Id == id);

        if (vila == null) return NotFound();

        return Ok(vila);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<VilaDTO>> AdicionarVila([FromBody] CriacaoVilaDTO vilaDTO)
    {
        if (vilaDTO == null) return BadRequest("Vila inválida");

        if (await _context.Vilas.AnyAsync(v => v.Nome.ToUpper().Trim() == vilaDTO.Nome.ToUpper().Trim()))
        {
            ModelState.AddModelError("Nome", "Vila já cadastrada");
            return BadRequest(ModelState);
        }

        Vila model = new Vila()
        {
            Nome = vilaDTO.Nome,
            Detalhes = vilaDTO.Detalhes,
            Tarifa = vilaDTO.Tarifa,
            MetrosQuadrados = vilaDTO.MetrosQuadrados,
            Ocupacao = vilaDTO.Ocupacao,
            UrlDaImagem = vilaDTO.UrlDaImagem,
            Comodidade = vilaDTO.Comodidade,
        };

        await _context.Vilas.AddAsync(model);
        await _context.SaveChangesAsync();

        return CreatedAtRoute("ObterVila", new { id = model.Id }, vilaDTO);
    }

    [HttpPut("{id:int}", Name = "AtualizarVila")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AtualizarVila(int id, [FromBody] AtualizacaoVilaDTO vilaDTO)
    {
        if (vilaDTO == null || id != vilaDTO.Id) return BadRequest("Vila inválida");

        if (vilaDTO.Id <= 0) return BadRequest("Id inválido");

        Vila model = new Vila()
        {
            Id = vilaDTO.Id,
            Nome = vilaDTO.Nome,
            Detalhes = vilaDTO.Detalhes,
            Tarifa = vilaDTO.Tarifa,
            MetrosQuadrados = vilaDTO.MetrosQuadrados,
            Ocupacao = vilaDTO.Ocupacao,
            UrlDaImagem = vilaDTO.UrlDaImagem,
            Comodidade = vilaDTO.Comodidade,
        };

        _context.Vilas.Update(model);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}", Name = "RemoverVila")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoverVila(int id)
    {
        if (id <= 0) return BadRequest("Id inválido");

        var vila = await _context.Vilas.FirstOrDefaultAsync(v => v.Id == id);

        if (vila == null) return NotFound();

        _context.Vilas.Remove(vila);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch("{id:int}", Name = "AtualizarParcialmenteVila")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AtualizarParcialmenteVila(int id, [FromBody] JsonPatchDocument<AtualizacaoVilaDTO> patchDTO)
    {
        if (patchDTO == null || id <= 0) return BadRequest("Vila inválida");

        var vila = await _context.Vilas.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);

        AtualizacaoVilaDTO vilaDTO = new()
        {
            Id = vila.Id,
            Nome = vila.Nome,
            Detalhes = vila.Detalhes,
            Tarifa = vila.Tarifa,
            MetrosQuadrados = vila.MetrosQuadrados,
            Ocupacao = vila.Ocupacao,
            UrlDaImagem = vila.UrlDaImagem,
            Comodidade = vila.Comodidade,
        };

        if (vila == null) return NotFound();

        patchDTO.ApplyTo(vilaDTO, ModelState);

        Vila model = new Vila()
        {
            Id = vilaDTO.Id,
            Nome = vilaDTO.Nome,
            Detalhes = vilaDTO.Detalhes,
            Tarifa = vilaDTO.Tarifa,
            MetrosQuadrados = vilaDTO.MetrosQuadrados,
            Ocupacao = vilaDTO.Ocupacao,
            UrlDaImagem = vilaDTO.UrlDaImagem,
            Comodidade = vilaDTO.Comodidade,
        };

        _context.Vilas.Update(model);
        await _context.SaveChangesAsync();

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return NoContent();
    }
}