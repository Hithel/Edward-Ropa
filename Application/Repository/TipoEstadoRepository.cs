

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class TipoEstadoRepository : GenericRepository<TipoEstado>, ITipoEstado
{
    private readonly ApiContext _context;

    public TipoEstadoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<TipoEstado>> GetAllAsync()
    {
        return await _context.TipoEstados
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoEstado> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.TipoEstados as IQueryable<TipoEstado>;

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

    public override async Task<TipoEstado> GetByIdAsync(int id)
    {
        return await _context.TipoEstados
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}