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
    public ActionResult<IEnumerable<VilaDTO>> ObterVilas()
    {
        return Ok(_context.Vilas.ToList());
    }

    [HttpGet("{id:int}", Name = "ObterVila")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VilaDTO> ObterVila(int id)
    {
        if (id <= 0) { return BadRequest("Id inválido"); }

        var vila = _context.Vilas.FirstOrDefault(v => v.Id == id);

        if (vila == null) return NotFound();

        return Ok(vila);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<VilaDTO> AdicionarVila([FromBody] VilaDTO vilaDTO)
    {
        if (vilaDTO == null) return BadRequest("Vila inválida");

        if (vilaDTO.Id > 0) return StatusCode(StatusCodes.Status500InternalServerError);

        if (_context.Vilas.Any(v => v.Nome.ToUpper().Trim() == vilaDTO.Nome.ToUpper().Trim()))
        {
            ModelState.AddModelError("Nome", "Vila já cadastrada");
            return BadRequest(ModelState);
        }

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

        _context.Vilas.Add(model);
        _context.SaveChanges();

        return CreatedAtRoute("ObterVila", new { id = vilaDTO.Id }, vilaDTO);
    }

    [HttpPut("{id:int}", Name = "AtualizarVila")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult AtualizarVila(int id, [FromBody] VilaDTO vilaDTO)
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
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:int}", Name = "RemoverVila")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult RemoverVila(int id)
    {
        if (id <= 0) return BadRequest("Id inválido");

        var vila = _context.Vilas.FirstOrDefault(v => v.Id == id);

        if (vila == null) return NotFound();

        _context.Vilas.Remove(vila);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id:int}", Name = "AtualizarParcialmenteVila")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult AtualizarParcialmenteVila(int id, [FromBody] JsonPatchDocument<VilaDTO> patchDTO)
    {
        if (patchDTO == null || id <= 0) return BadRequest("Vila inválida");

        var vila = _context.Vilas.AsNoTracking().FirstOrDefault(v => v.Id == id);

        VilaDTO vilaDTO = new()
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
        _context.SaveChanges();

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return NoContent();
    }
}