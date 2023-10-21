
using API.Dtos;
using API.Helpers.Paginacion;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
    public class FormaPagoController: ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public FormaPagoController(IUserService userService, IUnitOfWork unitofwork, IMapper mapper)
    {
        _userService = userService;
        this.unitofwork = unitofwork;
        this.mapper = mapper;

    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<FormaPagoDto>>> Get()
    {
        var entidad = await unitofwork.FormaPago.GetAllAsync();
        return mapper.Map<List<FormaPagoDto>>(entidad);
    }


    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<FormaPagoDto>>> GetPaginacion([FromQuery] Params usuarioParams)
    {
        var entidad = await unitofwork.FormaPago.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
        var listEntidad = mapper.Map<List<FormaPagoDto>>(entidad.registros);
        return new Pager<FormaPagoDto>(listEntidad, entidad.totalRegistros, usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FormaPagoDto>> Get(int id)
    {
        var entidad = await unitofwork.FormaPago.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<FormaPagoDto>(entidad);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FormaPagoDto>> Put(int id, [FromBody] FormaPagoDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<FormaPago>(entidadDto);
        unitofwork.FormaPago.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitofwork.FormaPago.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitofwork.FormaPago.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}


