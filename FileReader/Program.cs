using System;
using System.IO;

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the full path of the text file to read:");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                try
                {
                    string contents = File.ReadAllText(filePath);
                    Console.WriteLine("\n--- File Contents ---");
                    Console.WriteLine(contents);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading the file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("The specified file does not exist.");
            }
        }
    }
}
