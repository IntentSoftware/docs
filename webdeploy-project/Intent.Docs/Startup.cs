using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Intent.Docs;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Intent.Docs
{
    public class Startup
    {
        [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Called by OWIN")]
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                // NOTE: If you are planning on removing this redirect with the intention of having a document
                // at the `/docs/` path, there is an unresolved problem when viewing it. If one visits
                // `https://intentarchitect.com/docs/`, then everything works fine, if one visits
                // `https://intentarchitect.com/docs`, then all the relative paths on the published page stop
                // working as the browser no longer sees the page as being in a folder for things like the CSS
                // and image URLs.

                // I tried using url rewrite in the web.config as per
                // https://blog.elmah.io/web-config-redirects-with-rewrite-rules-https-www-and-more/, but that
                // particular example didn't seem to work.

                // I then tried using OWIN middleware here, but even when debugging off an Azure hosted
                // instance of the website, there was no discernible difference that I could see in
                // context.Request between `/docs` and `/docs/`. Maybe newer version of ASP and/or .NETs can
                // manage better.
                if (context.Request.Path.Value == "/")
                {
                    context.Response.Redirect("/docs/articles/getting-started/welcome/welcome.html");
                }
                else
                {
                    await next();
                }
            });

            var root = AppDomain.CurrentDomain.BaseDirectory;
            var wwwroot = Path.Combine(root);

            var fileServerOptions = new FileServerOptions
            {
                EnableDefaultFiles = true,
                EnableDirectoryBrowsing = false,
                RequestPath = new PathString(string.Empty),
                FileSystem = new PhysicalFileSystem(wwwroot),
                StaticFileOptions = { ServeUnknownFileTypes = true }
            };

            app.UseFileServer(fileServerOptions);
        }
    }
}