namespace RadConvenioAPI.Domain.DTOs
{
    /// <summary>Payload de entrada para operações de criptografia.</summary>
    public class CriptografiaDto
    {
        /// <summary>Texto a ser criptografado ou string hexadecimal a ser descriptografada.</summary>
        public string Texto { get; set; } = string.Empty;
    }

    /// <summary>Resultado de uma operação de criptografia.</summary>
    public class CriptografiaResultadoDto
    {
        /// <summary>Texto original informado na requisição.</summary>
        public string Original { get; set; } = string.Empty;

        /// <summary>Resultado da operação (hexadecimal criptografado ou texto claro).</summary>
        public string Resultado { get; set; } = string.Empty;
    }
}
