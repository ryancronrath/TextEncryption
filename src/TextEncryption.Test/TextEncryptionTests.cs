namespace TextEncryption.Test
{
    public class Tests
    {
        private OneTimePad _otp;

        [SetUp]
        public void Setup()
        {
            _otp = new OneTimePad();
        }

        [Test]
        public void EncryptText_WithShortKey_Fails()
        {
            // Arrange

            // Act

            // Assert
            Assert.That(() => _otp.Encrypt("Test", ""), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void EncryptText_NullKey_Fails()
        {
            // Arrange

            // Act

            // Assert
            Assert.That(() => _otp.Encrypt("Test", null), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void EncryptText_NullText_Fails()
        {
            // Arrange

            // Act

            // Assert
            Assert.That(() => _otp.Encrypt(null, "Test"), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void EncryptText_WithValidValues_Succeeds()
        {
            // Arrange
            string key = "This is my test";

            // Act
            string encryptedText = _otp.Encrypt("Test", key);

            // Assert
            Assert.IsTrue(encryptedText == ";lAL");
        }

        [Test]
        public void EncryptText_WithNewline_ReplacesNewlineWithSpace()
        {
            // Arrange
            string key = "This is my test";

            // Act
            string encryptedText = _otp.Encrypt("Test\n", key);
            string decryptedText = _otp.Decrypt(encryptedText, key);

            // Assert
            Assert.IsTrue(decryptedText == "Test ");
        }

        [Test]
        public void EncryptText_WithTab_ReplacesTabWithSpace()
        {
            // Arrange
            string key = "This is my test";

            // Act
            string encryptedText = _otp.Encrypt("Test\t", key);
            string decryptedText = _otp.Decrypt(encryptedText, key);

            // Assert
            Assert.IsTrue(decryptedText == "Test ");
        }

        [Test]
        public void EncryptText_WithReturn_ReplacesReturnWithSpace()
        {
            // Arrange
            string key = "This is my test";

            // Act
            string encryptedText = _otp.Encrypt("Test\r", key);
            string decryptedText = _otp.Decrypt(encryptedText, key);

            // Assert
            Assert.IsTrue(decryptedText == "Test ");
        }

        [Test]
        public void DecryptText_WithValidValues_Succeeds()
        {
            // Arrange
            string key = "This is my test";

            // Act
            string decryptedText = _otp.Decrypt(";lAL", key);

            // Assert
            Assert.IsTrue(decryptedText == "Test");
        }

        [Test]
        public void GenerateKey_WithInvalidLength_Fails()
        {
            // Arrange

            // Act

            // Assert
            Assert.That(() => _otp.GenerateKey(-1), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void GenerateKey_WithZeroLength_Fails()
        {
            // Arrange

            // Act

            // Assert
            Assert.That(() => _otp.GenerateKey(0), Throws.TypeOf<ArgumentException>());
        }
    }
}