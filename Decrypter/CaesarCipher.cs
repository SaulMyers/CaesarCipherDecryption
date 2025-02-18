using System.Text.RegularExpressions;

namespace Decrypter
{
    public class CaesarCipher
    {
        private int maxLength;
        private int cipherOffset;
        private char[] charSet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        /// <summary>
        /// Caesar Cipher constructor
        /// </summary>
        /// <param name="iMaxLength"></param>
        /// <param name="iCipherOffset"></param>
        public CaesarCipher(int iMaxLength, int iCipherOffset)
        {
            maxLength = iMaxLength;
            cipherOffset = iCipherOffset;
        }

        /// <summary>
        /// Accepts a string encrypted with a Caesar Cipher, decrypts it, and returns the result.
        /// </summary>
        /// <param name="ciphertext">Must be non-null, [a-z]</param>
        /// <returns>plaintext</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="Exception">Input length was greater than maximum allowed</exception>
        public string Decrypt(string cipherText)
        {
            #region Validation

            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("ciphertext cannot be null or empty");
            else if (!Regex.IsMatch(cipherText, @"^[a-z]+$"))
                throw new ArgumentOutOfRangeException("only [a-z] allowed");
            else if (cipherText.Length > maxLength)
                throw new Exception(string.Format("ciphertext length [{0}] is greater than the maximum allowed [{1}]", cipherText.Length, maxLength));
                //TODO make custom exception for this

            #endregion

            char[] plainText = new char[cipherText.Length];

            //for each character in the input
            for (int i = 0; i < cipherText.Length; i++)
            {
                //find the encrypted char's current position in the charset
                int currentPosition = Array.IndexOf(charSet, cipherText[i]);

                //wrap around to the end of the char set if shifting left will take us < 0 position
                if (currentPosition < cipherOffset)
                    currentPosition = charSet.Length + currentPosition;

                //shift the encrypted char back by the cipher offset and add it to the result
                plainText[i] = charSet[currentPosition - cipherOffset];
            }

            return new string(plainText);
        }
    }
}
