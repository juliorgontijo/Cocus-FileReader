using FileReader.Strategy;

namespace FileReader
{

    public class FileReaderContext
    {
        private readonly Dictionary<string, IFileReaderStrategy> _strategies;

        public FileReaderContext()
        {
            _strategies = new Dictionary<string, IFileReaderStrategy>
        {
            { ".txt", new TextFileReader() },
            { ".xml", new XmlFileReader() }
        };
        }

        public void ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("The specified file does not exist.");
                return;
            }

            string extension = Path.GetExtension(filePath).ToLowerInvariant();

            if (_strategies.TryGetValue(extension, out IFileReaderStrategy strategy))
            {
                strategy.Read(filePath);
            }
            else
            {
                Console.WriteLine($"Unsupported file type: {extension}");
            }
        }
    }

}
