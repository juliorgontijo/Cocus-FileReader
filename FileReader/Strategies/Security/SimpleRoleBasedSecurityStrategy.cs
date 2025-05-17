namespace FileReader.Strategies.Security
{
    using System;

    public class SimpleRoleBasedSecurityStrategy : ISecurityStrategy
    {
        public bool CanAccess(string filePath, string role)
        {
            if (role == "admin")
                return true;

            // Simulate restricted access for other roles
            if (filePath.Contains("restricted", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Access denied: role '{role}' cannot access '{filePath}'");
                return false;
            }

            return true;
        }
    }

}
