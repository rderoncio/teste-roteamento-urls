using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace ExemploRoteamentoURLs.Endpoint
{
    public static class EndpointConsultaPopulacao
    {
        public static async Task Endpoint(HttpContext context)
        {
            string localidade = HttpUtility.UrlDecode(context.Request.RouteValues["local"] as string);

            int populacaoRandom = (new Random()).Next(9999, 999999);
            context.Response.ContentType = "text/html; charset=utf-8";

            StringBuilder html = new StringBuilder();
            html.Append($"<h3>População de {localidade.ToUpper()}</h3>");
            html.Append($"<p>População de {populacaoRandom:N0} habitantes</p>");
            await context.Response.WriteAsync(html.ToString());

        }
    }
}