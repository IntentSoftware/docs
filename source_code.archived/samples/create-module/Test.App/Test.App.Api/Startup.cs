using Intent.RoslynWeaver.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


[assembly: DefaultIntentManaged(Mode.Fully)] // Overwrite this file on each Software Factory run.
[assembly: IntentTemplate("MyModule.Templates.StartupTemplate", Version = "1.0")]

namespace Test.App.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // [IntentManaged(Mode.Ignore)] // Uncomment to take over configuring services
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // [IntentManaged(Mode.Ignore)] // Uncomment to take over configuring the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}