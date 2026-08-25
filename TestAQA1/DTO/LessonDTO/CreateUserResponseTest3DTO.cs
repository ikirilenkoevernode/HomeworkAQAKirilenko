using System.Text.Json.Serialization;

namespace TestAQA1
{
    public class CreateUserResponseTest3DTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("job")]
        public string Job { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }
    }
}