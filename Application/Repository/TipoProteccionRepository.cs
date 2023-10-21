

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class TipoProteccionRepository : GenericRepository<TipoProteccion>, ITipoProteccion
{
    private readonly ApiContext _context;

    public TipoProteccionRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<TipoProteccion>> GetAllAsync()
    {
        return await _context.TipoProtecciones
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoProteccion> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.TipoProtecciones as IQueryable<TipoProteccion>;

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

    public override async Task<TipoProteccion> GetByIdAsync(int id)
    {
        return await _context.TipoProtecciones
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}