using Intent.RoslynWeaver.Attributes;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


[assembly: DefaultIntentManaged(Mode.Fully)] // Overwrite this file on each Software Factory run.
[assembly: IntentTemplate("MyModule.Templates.ProgramTemplate", Version = "1.0")]

namespace Test.App.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
