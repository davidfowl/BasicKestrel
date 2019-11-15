using System.Net;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BasicKestrel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder.UseKestrel(options =>
                    {
                        // Listen on 8080 (ipv4 and ipv6)
                        options.ListenLocalhost(8080);

                        // Listen on 8085 (ipv4 and ipv6)
                        options.ListenLocalhost(8085, listenOptions =>
                        {
                            // Write logic that runs before the TLS handshake
                            listenOptions.UseTlsFilter();

                            // Do HTTPS
                            listenOptions.UseHttps();
                        });
                    })
                    .UseStartup<Startup>();
                })
                .Build();

            host.Run();
        }
    }
}
