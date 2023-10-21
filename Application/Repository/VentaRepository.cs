

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class VentaRepository : GenericRepository<Venta>, IVenta
{
    private readonly ApiContext _context;

    public VentaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Venta>> GetAllAsync()
    {
        return await _context.Ventas
            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Venta> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
    {
        var query = _context.Ventas as IQueryable<Venta>;

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

    public override async Task<Venta> GetByIdAsync(int id)
    {
        return await _context.Ventas
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Object>> GetVentasEmpleado(int id)
    {
        var result = await (
            from v in _context.Ventas
            join e in _context.Empleados on v.IdEmpleadoFK equals e.Id
            where e.Id == id
            select new 
            {
                Id = v.Id,
                fecha = v.Fecha,
                FormaPago = v.FormaPago
            }
        ).ToListAsync();

        return result;
    }
}