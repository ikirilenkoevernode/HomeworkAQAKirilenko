namespace TestHomework15.DTO
{
    using System.Text.Json.Serialization;
    public record UserInfo(
        [property: JsonPropertyName("id")]
    int Id,

        [property: JsonPropertyName("username")]
    string Username,

        [property: JsonPropertyName("profile")]
    Profile Profile,

        [property: JsonPropertyName("roles")]
    List<string> Roles
    );

}