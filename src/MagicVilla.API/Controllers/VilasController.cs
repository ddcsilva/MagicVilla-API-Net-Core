using AutoMapper;
using MagicVilla.API.Models;
using MagicVilla.API.Models.DTO;
using MagicVilla.API.Repository.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VilasController : ControllerBase
{
    private readonly IVilaRepository _vilaRepository;
    private readonly IMapper _mapper;

    public VilasController(IVilaRepository vilaRepository, IMapper mapper)
    {
        _vilaRepository = vilaRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<VilaDTO>>> ObterVilas()
    {
        IEnumerable<Vila> vilas = await _vilaRepository.ObterTodosAsync();
        return Ok(_mapper.Map<IEnumerable<VilaDTO>>(vilas));
    }

    [HttpGet("{id:int}", Name = "ObterVila")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VilaDTO>> ObterVila(int id)
    {
        if (id <= 0) { return BadRequest("Id inválido"); }

        var vila = await _vilaRepository.ObterAsync(v => v.Id == id);

        if (vila == null) return NotFound();

        return Ok(_mapper.Map<VilaDTO>(vila));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<VilaDTO>> AdicionarVila([FromBody] CriacaoVilaDTO criacaoDTO)
    {
        if (criacaoDTO == null) return BadRequest("Vila inválida");

        if (await _vilaRepository.ObterAsync(v => v.Nome.ToUpper() == criacaoDTO.Nome.ToUpper()) != null)
        {
            ModelState.AddModelError("Nome", "Vila já cadastrada");
            return BadRequest(ModelState);
        }

        Vila model = _mapper.Map<Vila>(criacaoDTO);

        await _vilaRepository.CriarAsync(model);

        return CreatedAtRoute(nameof(ObterVila), new { id = model.Id }, _mapper.Map<VilaDTO>(model));
    }

    [HttpPut("{id:int}", Name = "AtualizarVila")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AtualizarVila(int id, [FromBody] AtualizacaoVilaDTO atualizacaoDTO)
    {
        if (atualizacaoDTO == null || id != atualizacaoDTO.Id) return BadRequest("Vila inválida");

        if (atualizacaoDTO.Id <= 0) return BadRequest("Id inválido");

        Vila model = _mapper.Map<Vila>(atualizacaoDTO);

        await _vilaRepository.AtualizarAsync(model);

        return NoContent();
    }

    [HttpDelete("{id:int}", Name = "RemoverVila")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoverVila(int id)
    {
        if (id <= 0) return BadRequest("Id inválido");

        var vila = await _vilaRepository.ObterAsync(v => v.Id == id);

        if (vila == null) return NotFound();

        await _vilaRepository.ExcluirAsync(vila);

        return NoContent();
    }

    [HttpPatch("{id:int}", Name = "AtualizarParcialmenteVila")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AtualizarParcialmenteVila(int id, [FromBody] JsonPatchDocument<AtualizacaoVilaDTO> patchDTO)
    {
        if (patchDTO == null || id <= 0) return BadRequest("Vila inválida");

        var vila = await _vilaRepository.ObterAsync(v => v.Id == id, rastrear: false);

        AtualizacaoVilaDTO vilaDTO = _mapper.Map<AtualizacaoVilaDTO>(vila);

        if (vila == null) return NotFound();

        patchDTO.ApplyTo(vilaDTO, ModelState);

        Vila model = _mapper.Map<Vila>(vilaDTO);

        await _vilaRepository.AtualizarAsync(model);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return NoContent();
    }
}