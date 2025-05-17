using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader.Strategies.FileReader
{
    public interface IFileReaderStrategy
    {
        public void Read(string filePath);
    }
}
