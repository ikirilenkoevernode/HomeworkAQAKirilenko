namespace TestHomework15.DTO
{
    using System.Text.Json.Serialization;
    public record Geo(
        [property: JsonPropertyName("lat")]
    double Lat,

        [property: JsonPropertyName("lng")]
    double Lng
    );


}