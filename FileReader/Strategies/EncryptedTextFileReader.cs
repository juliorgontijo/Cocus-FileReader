namespace FileReader.Strategies
{
    public class EncryptedTextFileReader : IFileReaderStrategy
    {
        private readonly IDecryptionStrategy _decryptionStrategy;

        public EncryptedTextFileReader(IDecryptionStrategy decryptionStrategy)
        {
            _decryptionStrategy = decryptionStrategy;
        }

        public void Read(string filePath)
        {
            string encryptedContent = File.ReadAllText(filePath);
            string decryptedContent = _decryptionStrategy.Decrypt(encryptedContent);
            Console.WriteLine("--- Decrypted Text File Contents ---");
            Console.WriteLine(decryptedContent);
        }
    }
}
