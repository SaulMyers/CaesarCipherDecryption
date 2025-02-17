using Decrypter;

namespace DecrypterTestProject
{
    public class Tests
    {
        CaesarCipher cc;

        [SetUp]
        public void Setup()
        {
            cc = new CaesarCipher(5,3);
        }

        [Test]
        public void EmptyInput()
        {
            Assert.Throws<ArgumentNullException>(() => cc.Decrypt(string.Empty));
        }

        [Test]
        public void InvalidChar()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => cc.Decrypt("1 2"));
        }

        [Test]
        public void InputTooLong()
        {
            Assert.Throws<Exception>(() => cc.Decrypt("aaaaaa"));
        }

        [Test]
        public void TestCharSetWrap()
        {
            string plaintext = cc.Decrypt("abc");
            Assert.That(plaintext.Equals("xyz"));
        }

    }
}