using System.Text.Json;

namespace FileReader.Strategies.FileReader
{
    public class JsonFileReader : IFileReaderStrategy
    {
        public void Read(string filePath)
        {
            try
            {
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
