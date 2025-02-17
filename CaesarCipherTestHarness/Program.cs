using Decrypter;
using System.Configuration;

//get caesar cipher config, set defaults if config missing or invalid
int maxLength = int.TryParse(ConfigurationManager.AppSettings["maxCaesarCipherInputLength"], out maxLength) ? maxLength : 100;
int cipherOffset = int.TryParse(ConfigurationManager.AppSettings["caesarCipherOffset"], out cipherOffset) ? cipherOffset : 3;

Console.WriteLine(string.Format("Input an encrypted string (a-z only, less than {0} chars) and press enter. Input 'exit' to exit.", maxLength));

CaesarCipher caesarCipher = new CaesarCipher(maxLength, cipherOffset);

string input = string.Empty;

while (input != "exit")
{
    input = Console.ReadLine();

    try
    {
        Console.WriteLine(caesarCipher.Decrypt(input));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}