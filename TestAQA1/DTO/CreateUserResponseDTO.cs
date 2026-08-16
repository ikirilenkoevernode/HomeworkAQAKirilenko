using System.Text.Json.Serialization;

namespace TestAQA1
{
    public class CreateUserRequestDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public string Job { get; set; }
    }
}