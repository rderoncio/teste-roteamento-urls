using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            //app.UseConsultaPopulacao();
            //app.UseConsultaCep();
            
            app.UseRouting();
            app.UseEndpoints(endpoint => 
            {
                endpoint.MapGet("Rota", async context => 
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.WriteAsync("Requisição foi Roteada");
                });

                endpoint.MapGet("populacao/{local}", EndpointConsultaPopulacao.Endpoint).WithMetadata(new RouteNameMetadata("consultapop"));
                endpoint.MapGet("cep/{cep}", EndpointConsultaCep.Endpoint);
            });

            app.UseMiddlewareTerminal();
        }
    }
}
