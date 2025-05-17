using FileReader.Strategies.FileReader;
using FileReader.Strategies.Security;
using System.Text;

public class TextFileReader : IFileReaderStrategy
{
    private readonly ISecurityStrategy _securityStrategy;
    private readonly string _role;
    public TextFileReader(ISecurityStrategy securityStrategy, string role)
    {
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

        string contents = File.ReadAllText(filePath, Encoding.UTF8);
        Console.WriteLine("\n--- Text File Contents ---");
        Console.WriteLine(contents);
    }
}
