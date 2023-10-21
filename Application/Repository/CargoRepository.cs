

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class CargoRepository : GenericRepository<Cargo>, ICargo
{
    private readonly ApiContext _context;

    public CargoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Cargo>> GetAllAsync()
    {
        return await _context.Cargos
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Cargo> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Cargos as IQueryable<Cargo>;

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

    public override async Task<Cargo> GetByIdAsync(int id)
    {
        return await _context.Cargos
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}