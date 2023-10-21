
using API.Dtos;
using API.Helpers.Paginacion;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")] 
[Authorize]

    public class PrendaController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PrendaController(IUserService userService, IUnitOfWork unitofwork, IMapper mapper)
    {
        _userService = userService;
        this.unitofwork = unitofwork;
        this.mapper = mapper;

    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PrendaDto>>> Get()
    {
        var entidad = await unitofwork.Prenda.GetAllAsync();
        return mapper.Map<List<PrendaDto>>(entidad);
    }

    [HttpGet("Consulta3B")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Object>>> GetPrendasProteccion()
    {
        var entidad = await unitofwork.Prenda.GetPrendasProteccion();
        return mapper.Map<List<Object>>(entidad);
    }


    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PrendaDto>>> GetPaginacion([FromQuery] Params usuarioParams)
    {
        var entidad = await unitofwork.Prenda.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
        var listEntidad = mapper.Map<List<PrendaDto>>(entidad.registros);
        return new Pager<PrendaDto>(listEntidad, entidad.totalRegistros, usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PrendaDto>> Get(int id)
    {
        var entidad = await unitofwork.Prenda.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<PrendaDto>(entidad);
    }

    [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Prenda>> Post(PrendaDto entidadDto)
        {
            var entidad = this.mapper.Map<Prenda>(entidadDto);
            this.unitofwork.Prenda.Add(entidad);
            await unitofwork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            entidadDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = entidadDto.Id}, entidadDto);
        }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PrendaDto>> Put(int id, [FromBody] PrendaDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Prenda>(entidadDto);
        unitofwork.Prenda.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitofwork.Prenda.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitofwork.Prenda.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}


