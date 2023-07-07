using System.Linq.Expressions;
using MagicVilla.API.Data;
using MagicVilla.API.Models;
using MagicVilla.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.API.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly MagicVillaContext _context;
    internal DbSet<T> dbSet;

    public Repository(MagicVillaContext context)
    {
        _context = context;
        dbSet = _context.Set<T>();
    }

    public async Task<List<T>> ObterTodosAsync(Expression<Func<T, bool>> filtro = null)
    {
        IQueryable<T> query = dbSet;


        if (filtro != null)
        {
            query = query.Where(filtro);
        }

        return await query.ToListAsync();
    }

    public async Task<T> ObterAsync(Expression<Func<T, bool>> filtro = null, bool rastrear = true)
    {
        IQueryable<T> query = dbSet;

        if (!rastrear)
        {
            query = query.AsNoTracking();
        }

        if (filtro != null)
        {
            query = query.Where(filtro);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task CriarAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        await SalvarAsync();
    }

    public async Task ExcluirAsync(T entity)
    {
        dbSet.Remove(entity);
        await SalvarAsync();        
    }

    public async Task SalvarAsync()
    {
        await _context.SaveChangesAsync();
    }
}