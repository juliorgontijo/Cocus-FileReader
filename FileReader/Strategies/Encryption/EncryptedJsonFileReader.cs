using FileReader.Strategies.FileReader;
using System.Text.Json;

namespace FileReader.Strategies.Encryption
{
    public class EncryptedJsonFileReader : IFileReaderStrategy
    {
        private readonly IDecryptionStrategy _decryptionStrategy;

        public EncryptedJsonFileReader(IDecryptionStrategy decryptionStrategy)
        {
            _decryptionStrategy = decryptionStrategy;
        }

        public void Read(string filePath)
        {
            try
            {
                string encryptedContent = File.ReadAllText(filePath);
                string decryptedContent = _decryptionStrategy.Decrypt(encryptedContent);

                Console.WriteLine("--- Decrypted JSON File Contents ---");
                Console.WriteLine(decryptedContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to read encrypted JSON file: {ex.Message}");
            }
        }
    }
}
