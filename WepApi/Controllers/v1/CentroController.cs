using Asp.Versioning;
using JMVPageLogic.Core.Application.Dtos.Centro;
using JMVPageLogic.Core.Application.Dtos.Estatus;
using JMVPageLogic.Core.Application.Dtos.Usuarios;
using JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services;
using JMVPageLogic.Core.Application.Services.Domain_Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CentroController : BaseApiController
    {
        private readonly ICentroService _centroService;

        public CentroController(ICentroService centroService)
        {
            _centroService = centroService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var estatus = await _centroService.GetAllAsync();
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var estatus = await _centroService.GetByIdAsync(id);
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

        [HttpPost]
        public async Task<IActionResult> Post(SaveCentroDto centroDto)
        {
            try
            {
                if (centroDto == null)
                {
                    return BadRequest("Estatus data is null.");
                }
                var createdEstatus = await _centroService.AddAsync(centroDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SaveCentroDto centroDto)
        {
            try
            {
                if (centroDto == null || id != centroDto.Id)
                {
                    return BadRequest("Estatus data is invalid.");
                }
                var existingCentro = await _centroService.GetByIdAsync(id);
                if (existingCentro == null)
                {
                    return NotFound($"Estatus with ID {id} not found.");
                }
                await _centroService.UpdateAsync(centroDto, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingCentro = await _centroService.GetByIdAsync(id);
                if (existingCentro == null)
                {
                    return NotFound($"Estatus with ID {id} not found.");
                }
                await _centroService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
