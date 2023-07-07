using MagicVilla.API.Data;
using MagicVilla.API.Models;
using MagicVilla.API.Repository.Interfaces;

namespace MagicVilla.API.Repository;

public class VilaRepository : Repository<Vila>, IVilaRepository
{
    private readonly MagicVillaContext _context;

    public VilaRepository(MagicVillaContext context) : base(context)
    {
        _context = context;
    }


    public async Task<Vila> AtualizarAsync(Vila entity)
    {
        entity.DataAtualizacao = DateTime.Now;
        _context.Vilas.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}