using Asp.Versioning;
using JMVPageLogic.Core.Application.Dtos.Actividades;
using JMVPageLogic.Core.Application.Dtos.Estatus;
using JMVPageLogic.Core.Application.Dtos.Usuarios;
using JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services;
using JMVPageLogic.Core.Application.Services.Domain_Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ActividadesController : BaseApiController
    {
        private readonly IActividadesService _actividadesService;

        public ActividadesController(IActividadesService actividadesService)
        {
            _actividadesService = actividadesService;
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
                var actividades = await _actividadesService.GetAllAsync();
                if (actividades == null || actividades.Count == 0)
                {
                    return NoContent();
                }
                return Ok(actividades);
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
                var actividades = await _actividadesService.GetByIdAsync(id);
                if (actividades == null)
                {
                    return NoContent();
                }
                return Ok(actividades);
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
        public async Task<IActionResult> Post(SaveActividadesDto actividadDto)
        {
            try
            {
                if (actividadDto == null)
                {
                    return BadRequest("Actividad data is null.");
                }
                var createdActividad = await _actividadesService.AddAsync(actividadDto);
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
        public async Task<IActionResult> Put(int id, SaveActividadesDto actividadDto)
        {
            try
            {
                if (actividadDto == null || id != actividadDto.Id)
                {
                    return BadRequest("Actividad data is invalid.");
                }
                var existingActividad = await _actividadesService.GetByIdAsync(id);
                if (existingActividad == null)
                {
                    return NotFound($"Actividad with ID {id} not found.");
                }
                await _actividadesService.UpdateAsync(actividadDto, id);
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
                var existingActividad = await _actividadesService.GetByIdAsync(id);
                if (existingActividad == null)
                {
                    return NotFound($"Actividad with ID {id} not found.");
                }
                await _actividadesService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
