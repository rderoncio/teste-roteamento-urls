using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ExemploRoteamentoURLs.Middlewares
{
    public class MiddlewareConsultaCep
    {
        private readonly RequestDelegate _next;

        public MiddlewareConsultaCep(RequestDelegate next)
        {
            _next = next;
        }

        public MiddlewareConsultaCep()
        {
        }

        public async Task Invoke(HttpContext context)
        {
            string cep = context.Request.RouteValues["cep"] as string;
            JsonCepModel jsonCepObjeto = await ConsultaCep(cep);

            context.Response.ContentType = "text/html; charset=utf-8";

            StringBuilder html = new StringBuilder();
            html.Append($"<h3>Dados para o CEP {jsonCepObjeto.CEP} </h3>");
            html.Append($"<p>Logradouro: {jsonCepObjeto.Logradouro}</p>");
            html.Append($"<p>Bairro: {jsonCepObjeto.Bairro}</p>");
            html.Append($"<p>Município: {jsonCepObjeto.Municipio}</p>");
            html.Append($"<p>UF: {jsonCepObjeto.Uf}</p>");

            await context.Response.WriteAsync(html.ToString());

            if (_next != null)
            {
                await _next(context);
            }
        }

        private async Task<JsonCepModel> ConsultaCep(string cep)
        {
            cep = cep.Replace("-", "").Replace(" ", "");
            string url = $"http://viacep.com.br/ws/{cep}/json";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Middleware Consulta CEP");
            var response = await client.GetAsync(url);

            string dadosCEP = await response.Content.ReadAsStringAsync();
            dadosCEP = dadosCEP.Replace("?(", "").Replace(")", "").Trim();

            return JsonConvert.DeserializeObject<JsonCepModel>(dadosCEP);
        }
    }
}
