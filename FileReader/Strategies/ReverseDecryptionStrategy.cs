using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader.Strategies
{
    public class ReverseDecryptionStrategy : IDecryptionStrategy
    {
        public string Decrypt(string encryptedText)
        {
            char[] chars = encryptedText.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
