using MagicVilla.API.Models;

namespace MagicVilla.API.Repository.Interfaces;

public interface IVilaRepository : IRepository<Vila>
{
    Task<Vila> AtualizarAsync(Vila entity);
}