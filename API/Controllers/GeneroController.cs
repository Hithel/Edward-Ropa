
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

    public class GeneroController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public GeneroController(IUserService userService, IUnitOfWork unitofwork, IMapper mapper)
    {
        _userService = userService;
        this.unitofwork = unitofwork;
        this.mapper = mapper;

    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GeneroDto>>> Get()
    {
        var entidad = await unitofwork.Genero.GetAllAsync();
        return mapper.Map<List<GeneroDto>>(entidad);
    }


    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<GeneroDto>>> GetPaginacion([FromQuery] Params usuarioParams)
    {
        var entidad = await unitofwork.Genero.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
        var listEntidad = mapper.Map<List<GeneroDto>>(entidad.registros);
        return new Pager<GeneroDto>(listEntidad, entidad.totalRegistros, usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GeneroDto>> Get(int id)
    {
        var entidad = await unitofwork.Genero.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<GeneroDto>(entidad);
    }

    [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Genero>> Post(GeneroDto entidadDto)
        {
            var entidad = this.mapper.Map<Genero>(entidadDto);
            this.unitofwork.Genero.Add(entidad);
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
    public async Task<ActionResult<GeneroDto>> Put(int id, [FromBody] GeneroDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Genero>(entidadDto);
        unitofwork.Genero.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitofwork.Genero.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitofwork.Genero.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}


