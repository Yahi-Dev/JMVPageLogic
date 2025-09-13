using Asp.Versioning;
using JMVPageLogic.Core.Application.Dtos.Biblioteca;
using JMVPageLogic.Core.Application.Dtos.Estatus;
using JMVPageLogic.Core.Application.Dtos.Usuarios;
using JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services;
using JMVPageLogic.Core.Application.Services.Domain_Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BibliotecaController : BaseApiController
    {
        private readonly IBibliotecaService _bibliotecaService;

        public BibliotecaController(IBibliotecaService biliotecaService)
        {
            _bibliotecaService = biliotecaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var document = await _bibliotecaService.GetAllAsync();
                if (document == null || document.Count == 0)
                {
                    return NoContent();
                }
                return Ok(document);
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
                var document = await _bibliotecaService.GetByIdAsync(id);
                if (document == null)
                {
                    return NoContent();
                }
                return Ok(document);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(SaveBibliotecaDto bibliotecaDto)
        {
            try
            {
                if (bibliotecaDto == null)
                {
                    return BadRequest("Biblioteca data is null.");
                }
                var createdBiblioteca = await _bibliotecaService.AddAsync(bibliotecaDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SaveBibliotecaDto bibliotecaDto)
        {
            try
            {
                if (bibliotecaDto == null || id != bibliotecaDto.Id)
                {
                    return BadRequest("Biblioteca data is invalid.");
                }
                var existingDocument = await _bibliotecaService.GetByIdAsync(id);
                if (existingDocument == null)
                {
                    return NotFound($"Document with ID {id} not found.");
                }
                await _bibliotecaService.UpdateAsync(bibliotecaDto, id);
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
                var existingDocument = await _bibliotecaService.GetByIdAsync(id);
                if (existingDocument == null)
                {
                    return NotFound($"Document with ID {id} not found.");
                }
                await _bibliotecaService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
