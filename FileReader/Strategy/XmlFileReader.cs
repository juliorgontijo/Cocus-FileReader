using FileReader.Strategy;
using System;
using System.Xml.Linq;

public class XmlFileReader : IFileReaderStrategy
{
    public void Read(string filePath)
    {
        XDocument doc = XDocument.Load(filePath);
        Console.WriteLine("\n--- XML File Contents (Formatted) ---");
        Console.WriteLine(doc.ToString());
    }
}
