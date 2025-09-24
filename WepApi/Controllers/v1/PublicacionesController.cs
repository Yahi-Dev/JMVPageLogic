using Asp.Versioning;
using JMVPageLogic.Core.Application.Dtos.Actividades;
using JMVPageLogic.Core.Application.Dtos.Estatus;
using JMVPageLogic.Core.Application.Dtos.Publicaciones;
using JMVPageLogic.Core.Application.Dtos.Usuarios;
using JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services;
using JMVPageLogic.Core.Application.Services.Domain_Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PublicacionesController : BaseApiController
    {
        private readonly IPublicacionesService _publicacionesService;

        public PublicacionesController(IPublicacionesService publicacionesService)
        {
            _publicacionesService = publicacionesService;
        }

        
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Usuario")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var publicaciones = await _publicacionesService.GetAllAsync();
                if (publicaciones == null || publicaciones.Count == 0)
                {
                    return NoContent();
                }
                return Ok(publicaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

     
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Usuario")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var publicaciones = await _publicacionesService.GetByIdAsync(id);
                if (publicaciones == null)
                {
                    return NoContent();
                }
                return Ok(publicaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

     
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(SavePublicacionesDto publicacionDto)
        {
            try
            {
                if (publicacionDto == null)
                {
                    return BadRequest("Publicacion data is null.");
                }
                var createdPublicacion = await _publicacionesService.AddAsync(publicacionDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SavePublicacionesDto publicacionDto)
        {
            try
            {
                if (publicacionDto == null || id != publicacionDto.Id)
                {
                    return BadRequest("Publicacion data is invalid.");
                }
                var existingPublicacion = await _publicacionesService.GetByIdAsync(id);
                if (existingPublicacion == null)
                {
                    return NotFound($"Publicacion with ID {id} not found.");
                }
                await _publicacionesService.UpdateAsync(publicacionDto, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingPublicacion = await _publicacionesService.GetByIdAsync(id);
                if (existingPublicacion == null)
                {
                    return NotFound($"Publicacion with ID {id} not found.");
                }
                await _publicacionesService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
