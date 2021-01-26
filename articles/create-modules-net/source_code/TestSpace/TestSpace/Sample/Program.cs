using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.VisualStudio.Projects.ConsoleApp.Program", Version = "1.0")]

namespace Sample
{
    public class Program
    {
        [IntentManaged(Mode.Ignore)]
        public static void Main(string[] args)
        {
            Console.WriteLine("Application Started...");
            Console.ReadLine();
        }
    }
}