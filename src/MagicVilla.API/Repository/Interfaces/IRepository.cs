using System.Linq.Expressions;

namespace MagicVilla.API.Repository.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> ObterTodosAsync(Expression<Func<T, bool>> filtro = null);
    Task<T> ObterAsync(Expression<Func<T, bool>> filtro = null, bool rastrear = true);
    Task CriarAsync(T entity);
    Task ExcluirAsync(T entity);
    Task SalvarAsync();
}