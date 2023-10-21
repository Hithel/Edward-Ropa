

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class InventarioTallaRepository : GenericRepository<InventatioTalla>, IInventarioTalla
{
    private readonly ApiContext _context;

    public InventarioTallaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<InventatioTalla>> GetAllAsync()
    {
        return await _context.InventatioTallas
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<InventatioTalla> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.InventatioTallas as IQueryable<InventatioTalla>;

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

    public override async Task<InventatioTalla> GetByIdAsync(int id)
    {
        return await _context.InventatioTallas
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}