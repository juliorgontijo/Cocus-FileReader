using FileReader.Strategies.Security;

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

            Console.WriteLine("Is this file encrypted? (y/n):");
            string encryptedInput = Console.ReadLine();

            Console.WriteLine("Enter your role (admin/user):");
            string role = Console.ReadLine()?.Trim().ToLower() ?? "user";
            bool isEncrypted = encryptedInput!.Trim().ToLower() == "y";

            var securityStrategy = new SimpleRoleBasedSecurityStrategy();
            var context = new FileReaderContext(securityStrategy);
            context.ReadFile(filePath, isEncrypted, role);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
