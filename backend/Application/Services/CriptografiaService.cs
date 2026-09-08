using RadConvenioAPI.Application.Interfaces;
using RadConvenioAPI.Domain.DTOs;
using RadConvenioAPI.Utils;

namespace RadConvenioAPI.Application.Services
{
    /// <summary>Implementação do serviço de criptografia baseada no componente Delphi legado.</summary>
    public class CriptografiaService : ICriptografiaService
    {
        /// <inheritdoc />
        public CriptografiaResultadoDto Criptografar(CriptografiaDto aDto)
            => new CriptografiaResultadoDto
            {
                Original = aDto.Texto,
                Resultado = Criptografia.TextToCriptoHex(aDto.Texto)
            };

        /// <inheritdoc />
        public CriptografiaResultadoDto Descriptografar(CriptografiaDto aDto)
            => new CriptografiaResultadoDto
            {
                Original = aDto.Texto,
                Resultado = Criptografia.CriptoHexToText(aDto.Texto)
            };
    }
}
