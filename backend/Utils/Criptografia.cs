using System;
using System.Linq;
using System.Text;

namespace RadConvenioAPI.Utils
{
    // A classe agora é estática, o que significa que não pode ser instanciada.
    // Todos os seus membros (métodos e propriedades) também devem ser estáticos.
    public static class Criptografia
    {
        private static readonly string FixedKey = "@#$%"; // A chave padrão do componente Delphi

        private static string Invert(string sText)
        {
            if (string.IsNullOrEmpty(sText))
            {
                return sText;
            }
            char[] charArray = sText.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static string DecToHex(byte number)
        {
            return number.ToString("X2");
        }

        private static byte HexToDec(string number)
        {
            return Convert.ToByte(number, 16);
        }

        public static string TextToCriptoBin(string sText)
        {
            sText = Invert(sText);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < sText.Length; i++)
            {
                int sPos = i + 1; // Posição no Delphi é base 1

                // Ajusta o índice para replicar o comportamento do Delphi
                char keyChar = FixedKey[sPos % FixedKey.Length];

                byte bKey = (byte)((int)keyChar + sPos);

                char encryptedChar = (char)(sText[i] ^ bKey);
                result.Append(encryptedChar);
            }
            return result.ToString();
        }

        public static string CriptoBinToText(string sText)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < sText.Length; i++)
            {
                int sPos = i + 1; // Posição no Delphi é base 1

                // Ajusta o índice para replicar o comportamento do Delphi
                char keyChar = FixedKey[sPos % FixedKey.Length];

                byte bKey = (byte)((int)keyChar + sPos);

                char decryptedChar = (char)(sText[i] ^ bKey);
                result.Append(decryptedChar);
            }
            return Invert(result.ToString());
        }

        public static string TextToCriptoHex(string sText)
        {
            sText = TextToCriptoBin(sText);
            StringBuilder result = new StringBuilder();

            foreach (char c in sText)
            {
                result.Append(DecToHex((byte)c));
            }
            return result.ToString();
        }

        public static string CriptoHexToText(string sText)
        {
            StringBuilder binResult = new StringBuilder();

            for (int i = 0; i < sText.Length; i += 2)
            {
                if (i + 2 > sText.Length)
                {
                    throw new ArgumentException("A string hexadecimal está incompleta.", nameof(sText));
                }
                string hexPair = sText.Substring(i, 2);
                binResult.Append((char)HexToDec(hexPair));
            }
            return CriptoBinToText(binResult.ToString());
        }
    }
}
