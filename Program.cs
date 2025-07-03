using System;
using Cosmos.System;

namespace MRX_OS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var kernel = new Kernel();
            kernel.Run();
        }
    }
}