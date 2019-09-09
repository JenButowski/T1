using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectManager
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessCollection processCollection = new ProcessCollection();
            processCollection.ListInfo();
            processCollection.KillProcessByName("Discord");
            Console.ReadLine();
        }
    }
}
