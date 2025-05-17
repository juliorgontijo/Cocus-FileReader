using FileReader.Strategies.Security;
using System.Text.Json;

namespace FileReader.Strategies.FileReader
{
    public class JsonFileReader : IFileReaderStrategy
    {
        private readonly ISecurityStrategy _securityStrategy;
        private readonly string _role;

        public JsonFileReader(ISecurityStrategy securityStrategy, string role)
        {
            _securityStrategy = securityStrategy;
            _role = role;
        }

        public void Read(string filePath)
        {
            try
            {
                if (!_securityStrategy.CanAccess(filePath, _role))
                {
                    Console.WriteLine("Access denied.");
                    return;
                }

                string jsonContent = File.ReadAllText(filePath);

                var jsonElement = JsonSerializer.Deserialize<JsonElement>(jsonContent);

                Console.WriteLine("--- JSON File Contents ---");
                Console.WriteLine(JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions
                {
                    WriteIndented = true
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to read JSON file: {ex.Message}");
            }
        }
    }

}
