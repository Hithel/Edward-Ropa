

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class TallaRepository : GenericRepository<Talla>, ITalla
{
    private readonly ApiContext _context;

    public TallaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Talla>> GetAllAsync()
    {
        return await _context.Tallas
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Talla> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Tallas as IQueryable<Talla>;

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

    public override async Task<Talla> GetByIdAsync(int id)
    {
        return await _context.Tallas
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}