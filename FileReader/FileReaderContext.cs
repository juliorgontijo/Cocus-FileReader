using FileReader.Strategies;

namespace FileReader
{

    public class FileReaderContext
    {
        private readonly Dictionary<string, Func<bool, IFileReaderStrategy>> _strategyFactories;

        public FileReaderContext()
        {
            _strategyFactories = new Dictionary<string, Func<bool, IFileReaderStrategy>>
        {
            {
                ".txt", isEncrypted =>
                {
                    if (isEncrypted)
                        return new EncryptedTextFileReader(new ReverseDecryptionStrategy());
                    else
                        return new TextFileReader();
                }
            },
            { ".xml", _ => new XmlFileReader() }
        };
        }

        public void ReadFile(string filePath, bool isEncrypted = false)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("The specified file does not exist.");
                return;
            }

            string extension = Path.GetExtension(filePath).ToLowerInvariant();

            if (_strategyFactories.TryGetValue(extension, out var strategyFactory))
            {
                var strategy = strategyFactory(isEncrypted);
                strategy.Read(filePath);
            }
            else
            {
                Console.WriteLine($"Unsupported file type: {extension}");
            }
        }
    }
}
