namespace TestHomework15.DTO
{
    using System.Text.Json.Serialization;
    public record RootDTO(
        [property: JsonPropertyName("data")]
    List<User> Data
    );
}