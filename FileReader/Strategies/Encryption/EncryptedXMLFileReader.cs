using FileReader.Strategies.FileReader;
using FileReader.Strategies.Security;
using System.Xml.Linq;

namespace FileReader.Strategies.Encryption
{
    public class EncryptedXmlFileReader : IFileReaderStrategy
    {
        private readonly IDecryptionStrategy _decryptionStrategy;
        private readonly ISecurityStrategy _securityStrategy;
        private readonly string _role;

        public EncryptedXmlFileReader(IDecryptionStrategy decryptionStrategy, ISecurityStrategy securityStrategy, string role)
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

            try
            {
                Console.WriteLine("--- Decrypted XML File Contents ---");
                Console.WriteLine(decryptedContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to parse decrypted XML content:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
