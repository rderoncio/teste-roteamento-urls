using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;

namespace ExemploRoteamentoURLs.Endpoint
{
    public static class EndpointRota
    {
        public static async Task Endpoint(HttpContext context)
        {
            LinkGenerator linkGenerator = context.RequestServices.GetService<LinkGenerator>();
            string linkCep = linkGenerator.GetPathByRouteValues(context, "consultacep", new { cep = context.Request.RouteValues["cep"]});
            string linkPop = linkGenerator.GetPathByRouteValues(context, "consultapop", new { local = context.Request.RouteValues["local"]});

            StringBuilder html = new StringBuilder();
            html.Append("<p>Requisição foi Roteada</p>");
            html.Append($"<p><a href='{linkCep}'>Consulta CEP</a></p>");
            html.Append($"<p><a href='{linkPop}'>Consulta População</a></p>");

            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync(html.ToString());
        }
    }
}
