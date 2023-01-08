using Microsoft.AspNetCore.Builder;
using ExemploRoteamentoURLs.Middlewares;

public static class MetodosExtensao
{
    public static IApplicationBuilder UseConsultaPopulacao(this IApplicationBuilder app)
    {
        app.UseMiddleware<MiddlewareConsultaPopulacao>();
        return app;
    }

    public static IApplicationBuilder UseMiddlewareTerminal(this IApplicationBuilder app)
    {
        app.UseMiddleware<MiddlewareTerminal>();
        return app;
    }

    public static IApplicationBuilder UseConsultaCep(this IApplicationBuilder app)
    {
        app.UseMiddleware<MiddlewareConsultaCep>();
        return app;
    }

}