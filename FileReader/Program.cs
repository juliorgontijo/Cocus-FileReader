namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the full path of the file to read (.txt or .xml):");
            string filePath = Console.ReadLine();

            var context = new FileReaderContext();
            context.ReadFile(filePath);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
