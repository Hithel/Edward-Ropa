

using Domain.Entities;

namespace Domain.Interfaces;
    public interface IVenta : IGenericRepo<Venta>
    {
        Task<IEnumerable<Object>> GetVentasEmpleado(int id);
    }