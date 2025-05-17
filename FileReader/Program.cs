namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the full path of the file to read:");
            string filePath = Console.ReadLine();

            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("No input provided.");
                return;
            }

            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            if (string.IsNullOrEmpty(extension))
            {
                Console.WriteLine("Invalid file path. Please provide a valid file with an extension.");
                return;
            }

            string encryptedInput = "n";
            if (extension == ".txt")
            {
                Console.WriteLine("Is this file encrypted? (y/n):");
                encryptedInput = Console.ReadLine();
            }

            bool isEncrypted = encryptedInput!.Trim().ToLower() == "y";

            var context = new FileReaderContext();
            context.ReadFile(filePath, isEncrypted);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
