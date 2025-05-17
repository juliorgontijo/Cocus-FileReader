using FileReader.Strategies.Encryption;
using FileReader.Strategies.FileReader;
using FileReader.Strategies.Security;

namespace FileReader
{
    public class FileReaderContext
    {
        private readonly Dictionary<string, Func<bool, string, IFileReaderStrategy>> _strategyFactories;
        private readonly ISecurityStrategy _securityStrategy;

        public FileReaderContext(ISecurityStrategy securityStrategy)
        {
            _securityStrategy = securityStrategy;

            _strategyFactories = new Dictionary<string, Func<bool, string, IFileReaderStrategy>>
        {
            {
                ".txt", (isEncrypted, role) =>
                {
                    return isEncrypted
                        ? new EncryptedTextFileReader(new ReverseDecryptionStrategy(), _securityStrategy, role)
                        : new TextFileReader(_securityStrategy, role);
                }
            },
            {
                ".xml", (isEncrypted, role) =>
                {
                    return isEncrypted
                        ? new EncryptedXmlFileReader(new ReverseDecryptionStrategy(), _securityStrategy, role)
                        : new XmlFileReader(_securityStrategy, role);
                }
            },
            { 
                ".json", (isEncrypted, role) => new JsonFileReader() 
            }
        };
        }

        public void ReadFile(string filePath, bool isEncrypted = false, string role = "user")
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("The specified file does not exist.");
                return;
            }

            string extension = Path.GetExtension(filePath).ToLowerInvariant();

            if (_strategyFactories.TryGetValue(extension, out var strategyFactory))
            {
                var strategy = strategyFactory(isEncrypted, role);
                strategy.Read(filePath);
            }
            else
            {
                Console.WriteLine($"Unsupported file type: {extension}");
            }
        }
    }
}
