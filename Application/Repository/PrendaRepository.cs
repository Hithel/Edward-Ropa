

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class PrendaRepository : GenericRepository<Prenda>, IPrenda
{
    private readonly ApiContext _context;

    public PrendaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Prenda>> GetAllAsync()
    {
        return await _context.Prendas
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Prenda> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Prendas as IQueryable<Prenda>;

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

    public override async Task<Prenda> GetByIdAsync(int id)
    {
        return await _context.Prendas
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}