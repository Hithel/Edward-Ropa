

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class InsumoRepository : GenericRepository<Insumo>, IInsumo
{
    private readonly ApiContext _context;

    public InsumoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Insumo>> GetAllAsync()
    {
        return await _context.Insumos
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Insumo> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Insumos as IQueryable<Insumo>;

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

    public override async Task<Insumo> GetByIdAsync(int id)
    {
        return await _context.Insumos
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}