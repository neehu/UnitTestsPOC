﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mock
{
    class FakeFileReader : IFileReader
    {
        public string ReadAllText(string path)
        {
            return "";
        }
    }
}
