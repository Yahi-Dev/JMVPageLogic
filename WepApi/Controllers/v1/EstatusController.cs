using Asp.Versioning;
using JMVPageLogic.Core.Application.Dtos.Estatus;
using JMVPageLogic.Core.Application.Dtos.Usuarios;
using JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services;
using JMVPageLogic.Core.Application.Services.Domain_Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EstatusController : BaseApiController
    {
        private readonly IEstatusService _estatusService;

        public EstatusController(IEstatusService estatusService)
        {
            _estatusService = estatusService;
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
                var estatus = await _estatusService.GetAllAsync();
                if (estatus == null || estatus.Count == 0)
                {
                    return NoContent();
                }
                return Ok(estatus);
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
                var estatus = await _estatusService.GetByIdAsync(id);
                if (estatus == null)
                {
                    return NoContent();
                }
                return Ok(estatus);
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
        public async Task<IActionResult> Post(SaveEstatusDto estatusDto)
        {
            try
            {
                if (estatusDto == null)
                {
                    return BadRequest("Estatus data is null.");
                }
                var createdEstatus = await _estatusService.AddAsync(estatusDto);
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
        public async Task<IActionResult> Put(int id, SaveEstatusDto estatusDto)
        {
            try
            {
                if (estatusDto == null || id != estatusDto.Id)
                {
                    return BadRequest("Estatus data is invalid.");
                }
                var existingEstatus = await _estatusService.GetByIdAsync(id);
                if (existingEstatus == null)
                {
                    return NotFound($"Estatus with ID {id} not found.");
                }
                await _estatusService.UpdateAsync(estatusDto, id);
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
                var existingEstatus = await _estatusService.GetByIdAsync(id);
                if (existingEstatus == null)
                {
                    return NotFound($"Estatus with ID {id} not found.");
                }
                await _estatusService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
