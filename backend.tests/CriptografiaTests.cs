using RadConvenioAPI.Utils;
using Xunit;

namespace RadConvenioAPI.Tests
{
    public class CriptografiaTests
    {
        [Theory]
        [InlineData("RADINFO 2026")]
        [InlineData("Convenio RAD")]
        [InlineData("a")]
        [InlineData("Acentuação e símbolos !@#$%")]
        public void CriptografarEDescriptografar_DeveRetornarTextoOriginal(string aTexto)
        {
            string hex = Criptografia.TextToCriptoHex(aTexto);
            string recuperado = Criptografia.CriptoHexToText(hex);

            Assert.Equal(aTexto, recuperado);
        }

        [Fact]
        public void TextToCriptoHex_DeveGerarSomenteCaracteresHexadecimais()
        {
            string hex = Criptografia.TextToCriptoHex("RADINFO 2026");

            Assert.Matches("^[0-9A-F]+$", hex);
            Assert.Equal(0, hex.Length % 2);
        }

        [Fact]
        public void CriptoHexToText_ComHexIncompleto_DeveLancarArgumentException()
        {
            Assert.Throws<System.ArgumentException>(() => Criptografia.CriptoHexToText("ABC"));
        }
    }
}
