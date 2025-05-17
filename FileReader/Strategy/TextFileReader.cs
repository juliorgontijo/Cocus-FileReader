using FileReader.Strategy;
using System.Text;

public class TextFileReader : IFileReaderStrategy
{
    public void Read(string filePath)
    {
        string contents = File.ReadAllText(filePath, Encoding.UTF8);
        Console.WriteLine("\n--- Text File Contents ---");
        Console.WriteLine(contents);
    }
}
