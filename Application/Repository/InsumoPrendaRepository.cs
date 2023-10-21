

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class InsumoPrendaRepository : GenericRepository<InsumoPrenda>, IInsumoPrenda
{
    private readonly ApiContext _context;

    public InsumoPrendaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<InsumoPrenda>> GetAllAsync()
    {
        return await _context.InsumoPrendas
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<InsumoPrenda> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.InsumoPrendas as IQueryable<InsumoPrenda>;

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

    public override async Task<InsumoPrenda> GetByIdAsync(int id)
    {
        return await _context.InsumoPrendas
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}