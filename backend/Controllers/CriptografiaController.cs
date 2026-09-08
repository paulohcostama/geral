using Microsoft.AspNetCore.Mvc;
using RadConvenioAPI.Application.Interfaces;
using RadConvenioAPI.Domain.DTOs;

namespace RadConvenioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CriptografiaController : ControllerBase
    {
        private readonly ICriptografiaService _service;

        public CriptografiaController(ICriptografiaService service)
            => _service = service;

        /// <summary>Criptografa um texto claro, retornando o hexadecimal.</summary>
        [HttpPost("criptografar")]
        public IActionResult Criptografar([FromBody] CriptografiaDto aDto)
            => Ok(_service.Criptografar(aDto));

        /// <summary>Descriptografa uma string hexadecimal, retornando o texto claro.</summary>
        [HttpPost("descriptografar")]
        public IActionResult Descriptografar([FromBody] CriptografiaDto aDto)
        {
            try
            {
                return Ok(_service.Descriptografar(aDto));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (FormatException)
            {
                return BadRequest(new { erro = "A string informada não é um hexadecimal válido." });
            }
        }
    }
}
