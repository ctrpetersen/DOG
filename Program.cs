using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOG
{
    internal class Program
    {
        private static void Main(string[] args) => DOG.Instance.StartAsync().GetAwaiter().GetResult();
    }
}
