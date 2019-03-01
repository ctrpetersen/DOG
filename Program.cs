using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOG
{
    public class Program
    {
        private static void Main(string[] args) => D_O_G.Instance.StartAsync().GetAwaiter().GetResult();
    }
}
