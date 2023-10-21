

namespace Domain.Interfaces;
    public interface  IUnitOfWork
    {
        ICargo Cargos { get;  }
        ICliente Cliente { get;  }
        IColor Color { get;  }
        IDepartamento Departamento { get;  }
        IDetalleOrden DetalleOrden { get;  } 
        IDetalleVenta DetalleVenta { get;  }
        IEmpleado Empleado { get;  }
        IEmpresa Empresa { get;  }
        IEstado Estado { get;  }
        IFormaPago FormaPago { get;  }
        IGenero Genero { get;  }
        IInsumo Insumo { get;  }
        IInsumoPrenda InsumoPrenda { get; }
        IInventario Inventario { get;  }
        IInventarioTalla InventarioTalla { get;  }
        IMunicipio Municipio { get;  }
        IOrden Orden { get;  }
        IPais Pais { get;  }
        IPrenda Prenda { get;  }
        IProveedor Proveedor { get;  }
        ITalla Talla { get;  }
        ITipoEstado TipoEstado { get;  }
        ITipoPersona TipoPersona { get; }
        ITipoProteccion TipoProteccion { get;  }
        IVenta Venta { get;  }
        IRol Roles { get; }
        IUser Users { get; }
        Task<int> SaveAsync();
    }
