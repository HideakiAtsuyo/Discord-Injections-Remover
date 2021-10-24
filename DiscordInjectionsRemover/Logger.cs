using Crayon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordInjectionsRemover
{
    public static class Logger
    {
        public static void Info(string x)
        {
            Console.WriteLine($"{Output.Yellow("[")}{Output.Blue("INFO")}{Output.Yellow("]")}: {x}");
        }
        public static void Warn(string x)
        {
            Console.WriteLine($"{Output.Yellow("[")}{Output.Red("WARN")}{Output.Yellow("]")}: {x}");
        }
    }
}
