using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader.Strategies
{
    public interface IDecryptionStrategy
    {
        string Decrypt(string encryptedText);
    }

}
