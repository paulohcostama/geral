using RadConvenioAPI.Domain.DTOs;

namespace RadConvenioAPI.Application.Interfaces
{
    /// <summary>Serviço responsável por criptografar e descriptografar textos no padrão Delphi (RAD).</summary>
    public interface ICriptografiaService
    {
        /// <summary>Criptografa um texto claro para uma string hexadecimal.</summary>
        /// <param name="aDto">DTO contendo o texto claro.</param>
        /// <returns>Resultado com o hexadecimal criptografado.</returns>
        CriptografiaResultadoDto Criptografar(CriptografiaDto aDto);

        /// <summary>Descriptografa uma string hexadecimal para o texto claro original.</summary>
        /// <param name="aDto">DTO contendo o hexadecimal criptografado.</param>
        /// <returns>Resultado com o texto claro.</returns>
        CriptografiaResultadoDto Descriptografar(CriptografiaDto aDto);
    }
}
