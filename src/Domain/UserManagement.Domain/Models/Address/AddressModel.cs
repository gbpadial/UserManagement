using System.Text.Json.Serialization;

namespace UserManagement.Domain.Models.Address;

public record AddressModel
{
    [JsonPropertyName("Cep")]
    public string ZipCode { get; set; } = string.Empty;

    [JsonPropertyName("Logradouro")]
    public string Street { get; set; } = string.Empty;

    [JsonPropertyName("Bairro")]
    public string District { get; set; } = string.Empty;

    [JsonPropertyName("Localidade")]
    public string City { get; set; } = string.Empty;

    [JsonPropertyName("Uf")]
    public string State { get; set; } = string.Empty;

    [JsonPropertyName("Ibge")]
    public string Code { get; set; } = string.Empty;
}
