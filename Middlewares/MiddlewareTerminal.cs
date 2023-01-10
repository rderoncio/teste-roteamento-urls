using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace ExemploRoteamentoURLs.Middlewares
{
    public class MiddlewareTerminal
    {
        private readonly RequestDelegate _next;

        public MiddlewareTerminal(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync(" Middleware Terminal ");
        }
    }
}