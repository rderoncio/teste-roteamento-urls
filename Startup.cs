using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ExemploRoteamentoURLs.Endpoint;
using Microsoft.AspNetCore.Routing;

namespace ExemploRoteamentoURLs
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoint =>
            {
                //http://localhost:port/rota
                endpoint.Map("rota", EndpointRota.Endpoint);

                //http://localhost:port/populacao/{local=default}
                endpoint.Map("populacao/{local=São%20Paulo-SP}", EndpointConsultaPopulacao.Endpoint).WithMetadata(new RouteNameMetadata("consultapop"));

                //http://localhost:port/cep/{cep?}
                endpoint.Map("cep/{cep?}", EndpointConsultaCep.Endpoint).WithMetadata(new RouteNameMetadata("consultacep"));
            });

            //http://localhost:port
            app.UseMiddlewareTerminal();
        }
    }
}
