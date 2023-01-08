using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;


namespace ExemploRoteamentoURLs.Middlewares
{
    public class MiddlewareConsultaPopulacao
    {
        private readonly RequestDelegate _next;

        public MiddlewareConsultaPopulacao(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string[] segmentos = context.Request.Path.ToString().Split("/", System.StringSplitOptions.RemoveEmptyEntries);

            if (segmentos.Length == 2 && segmentos[0] == "pop")
            {
                string localidade = HttpUtility.UrlDecode(segmentos[1]);
                int populacaoRandom = (new Random()).Next(9999, 999999);
                context.Response.ContentType = "text/plain; charset=utf-8";

                StringBuilder html = new StringBuilder();
                html.Append($"<h3>População de {localidade.ToUpper()}</h3>");
                html.Append($"<p>População de {populacaoRandom:N0} habitantes</p>");
                await context.Response.WriteAsync(html.ToString());
            }
            else if (_next != null)
            {
                await _next(context);
            }
        }
    }
}