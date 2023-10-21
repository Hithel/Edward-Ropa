using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        
        private readonly ApiContext _context;
        private CargoRepository _cargo;
        private ClienteRepository _cliente;
        private ColorRepository _color;
        private DepartamentoRepository _departamento;
        private DetalleOrdenRepository _detalleOrden;
        private DetalleVentaRepository _detalleVenta;
        private EmpleadoRepository _empleado;
        private EmpresaRepository _empresa;
        private EstadoRepository _estado;
        private FormaPagoRepository _formaPago;
        private GeneroRepository _genero;
        private InsumoRepository _insumo;
        private InsumoPrendaRepository _insumoPrenda;
        private InventarioRepository _inventario;
        private InventarioTallaRepository _inventarioTalla;
        private MunicipioRepository _municipio;
        private OrdenRepository _orden;
        private PaisRepository _pais;
        private PrendaRepository _prenda;
        private ProveedorRepository _proveedor;
        private TallaRepository _talla;
        private TipoEstadoRepository _tipoEstado;
        private TipoPersonaRepository _tipoPersona;
        private TipoProteccionRepository _tipoProteccion;
        private VentaRepository _venta;

        private UserRepository _users;
        private RolRepository _roles; 

    public UnitOfWork (ApiContext context)
        {
            _context = context;
        }

        // Controll de nulos para los repositorios

        public ICargo Cargos
        {
            get
            {
                if (_cargo == null)
                {
                    _cargo = new CargoRepository(_context);
                }
                return _cargo;
            }
        }

        public ICliente Cliente
        {
            get
            {
                if (_cliente == null)
                {
                    _cliente = new ClienteRepository(_context);
                }
                return _cliente;
            }
        }

        public IColor Color
        {
            get
            {
                if (_color == null)
                {
                    _color = new ColorRepository(_context);
                }
                return _color;
            }
        }


        public IDepartamento Departamento
        {
            get
            {
                if (_departamento == null)
                {
                    _departamento = new DepartamentoRepository(_context);
                }
                return _departamento;
            }
        }

        public IDetalleOrden DetalleOrden
        {
            get
            {
                if (_detalleOrden == null)
                {
                    _detalleOrden = new DetalleOrdenRepository(_context);
                }
                return _detalleOrden;
            }
        }

        public IDetalleVenta DetalleVenta
        {
            get
            {
                if (_detalleVenta == null)
                {
                    _detalleVenta = new DetalleVentaRepository(_context);
                }
                return _detalleVenta;
            }
        }

        public IEmpleado Empleado
        {
            get
            {
                if (_empleado == null)
                {
                    _empleado = new EmpleadoRepository(_context);
                }
                return _empleado;
            }
        }

        public IEmpresa Empresa
        {
            get
            {
                if (_empresa == null)
                {
                    _empresa = new EmpresaRepository(_context);
                }
                return _empresa;
            }
        }

        public IEstado Estado
        {
            get
            {
                if (_estado == null)
                {
                    _estado = new EstadoRepository(_context);
                }
                return _estado;
            }
        }

        public IFormaPago FormaPago
        {
            get
            {
                if (_formaPago == null)
                {
                    _formaPago = new FormaPagoRepository(_context);
                }
                return _formaPago;
            }
        }

        public IGenero Genero
        {
            get
            {
                if (_genero == null)
                {
                    _genero = new GeneroRepository(_context);
                }
                return _genero;
            }
        }

        public IInsumo Insumo
        {
            get
            {
                if (_insumo == null)
                {
                    _insumo = new InsumoRepository(_context);
                }
                return _insumo;
            }
        }

        public IInsumoPrenda InsumoPrenda
        {
            get
            {
                if (_insumoPrenda == null)
                {
                    _insumoPrenda = new InsumoPrendaRepository(_context);
                }
                return _insumoPrenda;
            }
        }

        public IInventario Inventario
        {
            get
            {
                if (_inventario == null)
                {
                    _inventario = new InventarioRepository(_context);
                }
                return _inventario;
            }
        }

        public IInventarioTalla InventarioTalla
        {
            get
            {
                if (_inventarioTalla == null)
                {
                    _inventarioTalla = new InventarioTallaRepository(_context);
                }
                return _inventarioTalla;
            }
        }

        public IMunicipio Municipio
        {
            get
            {
                if (_municipio == null)
                {
                    _municipio = new MunicipioRepository(_context);
                }
                return _municipio;
            }
        }

        public IOrden Orden
        {
            get
            {
                if (_orden == null)
                {
                    _orden = new OrdenRepository(_context);
                }
                return _orden;
            }
        }

        public IPais Pais
        {
            get
            {
                if (_pais == null)
                {
                    _pais = new PaisRepository(_context);
                }
                return _pais;
            }
        }

        public IPrenda Prenda
        {
            get
            {
                if (_prenda == null)
                {
                    _prenda = new PrendaRepository(_context);
                }
                return _prenda;
            }
        }

        public IProveedor Proveedor
        {
            get
            {
                if (_proveedor == null)
                {
                    _proveedor = new ProveedorRepository(_context);
                }
                return _proveedor;
            }
        }

        public ITalla Talla
        {
            get
            {
                if (_talla == null)
                {
                    _talla = new TallaRepository(_context);
                }
                return _talla;
            }
        }

        public ITipoEstado TipoEstado
        {
            get
            {
                if (_tipoEstado == null)
                {
                    _tipoEstado = new TipoEstadoRepository(_context);
                }
                return _tipoEstado;
            }
        }

        public ITipoPersona TipoPersona
        {
            get
            {
                if (_tipoPersona == null)
                {
                    _tipoPersona = new TipoPersonaRepository(_context);
                }
                return _tipoPersona;
            }
        }

        public ITipoProteccion TipoProteccion
        {
            get
            {
                if (_tipoProteccion == null)
                {
                    _tipoProteccion = new TipoProteccionRepository(_context);
                }
                return _tipoProteccion;
            }
        }

        public IVenta Venta
        {
            get
            {
                if (_venta == null)
                {
                    _venta = new VentaRepository(_context);
                }
                return _venta;
            }
        }

        public IUser Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }

        public IRol Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }





    }
}
