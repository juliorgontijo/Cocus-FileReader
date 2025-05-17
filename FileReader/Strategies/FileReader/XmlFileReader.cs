using FileReader.Strategies.FileReader;
using FileReader.Strategies.Security;
using System;
using System.Xml.Linq;

public class XmlFileReader : IFileReaderStrategy
{
    private readonly ISecurityStrategy _securityStrategy;
    private readonly string _role;

    public XmlFileReader(ISecurityStrategy securityStrategy, string role)
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

        var doc = XDocument.Load(filePath);
        Console.WriteLine("--- XML File Contents ---");
        Console.WriteLine(doc.ToString());
    }
}
