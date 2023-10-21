

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class ColorRepository : GenericRepository<Color>, IColor
{
    private readonly ApiContext _context;

    public ColorRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Color>> GetAllAsync()
    {
        return await _context.Color
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Color> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Color as IQueryable<Color>;

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

    public override async Task<Color> GetByIdAsync(int id)
    {
        return await _context.Color
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}