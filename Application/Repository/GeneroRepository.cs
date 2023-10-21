

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class GeneroRepository : GenericRepository<Genero>, IGenero
{
    private readonly ApiContext _context;

    public GeneroRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Genero>> GetAllAsync()
    {
        return await _context.Generos
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Genero> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Generos as IQueryable<Genero>;

        if (!string.IsNullOrEmpty(search.ToString()))
        {
            query = query.Where(p => p.Id.Equals(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    public override async Task<Genero> GetByIdAsync(int id)
    {
        return await _context.Generos
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}