namespace TestHomework15.DTO
{
    using System.Text.Json.Serialization;
    public record Profile(
        [property: JsonPropertyName("fullName")]
    string FullName,

        [property: JsonPropertyName("age")]
    int Age,

        [property: JsonPropertyName("address")]
    AddressDTO Address,

        [property: JsonPropertyName("tags")]
    List<string> Tags
    );


}