using FileReader.Strategies.FileReader;
using FileReader.Strategies.Security;

namespace FileReader.Strategies.Encryption
{
    public class EncryptedTextFileReader : IFileReaderStrategy
    {
        private readonly IDecryptionStrategy _decryptionStrategy;
        private readonly ISecurityStrategy _securityStrategy;
        private readonly string _role;

        public EncryptedTextFileReader(IDecryptionStrategy decryptionStrategy, ISecurityStrategy securityStrategy, string role)
        {
            _decryptionStrategy = decryptionStrategy;
            _securityStrategy = securityStrategy;
            _role = role;
        }

        public void Read(string filePath)
        {
            if (!_securityStrategy.CanAccess(filePath, _role))
            {
                Console.WriteLine("Access denied.");
                return;
            }

            string encryptedContent = File.ReadAllText(filePath);
            string decryptedContent = _decryptionStrategy.Decrypt(encryptedContent);
            Console.WriteLine("--- Decrypted Text File Contents ---");
            Console.WriteLine(decryptedContent);
        }
    }
}
