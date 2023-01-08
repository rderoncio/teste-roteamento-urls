using Newtonsoft.Json;

public sealed class JsonCepModel
{
    [JsonProperty("cep")]
    public string CEP { get; set; }

    [JsonProperty("logradouro")]
    public string Logradouro { get; set; }

    [JsonProperty("complemento")]
    public string Complemento { get; set; }

    [JsonProperty("bairro")]
    public string Bairro { get; set; }
    
    [JsonProperty("localidade")]
    public string Municipio { get; set; }

    [JsonProperty("uf")]
    public string Uf { get; set; }

    [JsonProperty("ddd")]
    public string Ddd { get; set; }

    [JsonProperty("ibge")]
    public string Ibge { get; set; }
}