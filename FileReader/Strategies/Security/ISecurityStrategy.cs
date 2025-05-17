﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader.Strategies.Security
{
    public interface ISecurityStrategy
    {
        bool CanAccess(string filePath, string role);
    }
}
