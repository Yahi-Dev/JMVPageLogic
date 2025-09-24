using Asp.Versioning;
using JMVPageLogic.Core.Application.Dtos.Comunidad;
using JMVPageLogic.Core.Application.Dtos.Estatus;
using JMVPageLogic.Core.Application.Dtos.Usuarios;
using JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services;
using JMVPageLogic.Core.Application.Services.Domain_Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ComunidadController : BaseApiController
    {
        private readonly IComunidadService _comunidadService;

        public ComunidadController(IComunidadService comunidadService)
        {
            _comunidadService = comunidadService;
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
                var comunidad = await _comunidadService.GetAllAsync();
                if (comunidad == null || comunidad.Count == 0)
                {
                    return NoContent();
                }
                return Ok(comunidad);
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
                var comunidad = await _comunidadService.GetByIdAsync(id);
                if (comunidad == null)
                {
                    return NoContent();
                }
                return Ok(comunidad);
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
        public async Task<IActionResult> Post(SaveComunidadDto comunidadDto)
        {
            try
            {
                if (comunidadDto == null)
                {
                    return BadRequest("Comunidad data is null.");
                }
                var createdComunidad = await _comunidadService.AddAsync(comunidadDto);
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
        public async Task<IActionResult> Put(int id, SaveComunidadDto comunidadDto)
        {
            try
            {
                if (comunidadDto == null || id != comunidadDto.Id)
                {
                    return BadRequest("Comunidad data is invalid.");
                }
                var existingComunidad = await _comunidadService.GetByIdAsync(id);
                if (existingComunidad == null)
                {
                    return NotFound($"Comunidad with ID {id} not found.");
                }
                await _comunidadService.UpdateAsync(comunidadDto, id);
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
                var existingComunidad = await _comunidadService.GetByIdAsync(id);
                if (existingComunidad == null)
                {
                    return NotFound($"comunidad with ID {id} not found.");
                }
                await _comunidadService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
