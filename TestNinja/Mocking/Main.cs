using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public static class Main
    {
        public static void mainMethod()
        {
            var vs = new VideoService();
            vs.ReadVideoTitle();
        }
    }
}
