
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class OrdenRepository : GenericRepository<Orden>, IOrden
{
    private readonly ApiContext _context;

    public OrdenRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Orden>> GetAllAsync()
    {
        return await _context.Ordenes
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Orden> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Ordenes as IQueryable<Orden>;

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

    public override async Task<Orden> GetByIdAsync(int id)
    {
        return await _context.Ordenes
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Object>> GetPrendasProduccion(int numero)
    {
        var result = await (
            from o in _context.Ordenes
            join e in _context.Estado on o.IdEstadoFk equals e.Id
            join p in _context.Prendas on o.Id equals p.IdEstadoFk
            where o.Id == numero
            where e.Descripcion == "Produccion"
            select new 
            {
                prenda = p.Nombre,
                Estado = e.Descripcion
            }

        ).ToListAsync();

        return result;
    }
}