namespace TestHomework15.DTO
{
    using System.Text.Json.Serialization;
    public record AddressDTO(
    [property: JsonPropertyName("street")]
        string Street,
    [property: JsonPropertyName("city")]
        string City,

    [property: JsonPropertyName("geo")]
        Geo Geo
    );

}