
using System;
using System.Collections.Generic;
using System.Text;

using EmbedIO;
using EmbedIO.WebApi;


namespace websum {

    class Program {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args) {
            var url = "http://localhost:9696/";
            if (args.Length > 0)
                url = args[0];

            // Our web server is disposable.
            using (var server = CreateWebServer(url)) {
                // Once we've registered our modules and configured them, we call the RunAsync() method.
                server.RunAsync();

                var browser = new System.Diagnostics.Process() {
                    StartInfo = new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true }
                };
                browser.Start();
                // Wait for any key to be pressed before disposing of our web server.
                // In a service, we'd manage the lifecycle of our web server using
                // something like a BackgroundWorker or a ManualResetEvent.
                Console.ReadKey(true);
            }
        }

        // Create and configure our web server.
        private static WebServer CreateWebServer(string url) {


            //      TODO




            var server = new WebServer(o => o
                .WithUrlPrefix(url)
                .WithMode(HttpListenerMode.EmbedIO));
            // First, we will configure our web server by adding Modules.
            /*
            .WithLocalSessionManager()
            .WithWebApi("/api", m => m
                .WithController<PeopleController>())
            .WithModule(new WebSocketChatModule("/chat"))
            .WithModule(new WebSocketTerminalModule("/terminal"))
            .WithStaticFolder("/", HtmlRootPath, true, m => m
                .WithContentCaching(UseFileCache)) // Add static files after other modules to avoid conflicts
            .WithModule(new ActionModule("/", HttpVerbs.Any, ctx => ctx.SendDataAsync(new { Message = "Error" })));
            */

            // Listen for state changes.
            //server.StateChanged += (s, e) => $"WebServer New State - {e.NewState}".Info();
            server.StateChanged += (s, e) => Console.WriteLine($"WebServer New State - {e.NewState}");

            return server;
        }
    }
}