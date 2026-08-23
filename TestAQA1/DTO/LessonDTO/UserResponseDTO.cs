using System;
using System.Text.Json.Serialization;
namespace TestAQA1
{
    public class UserResponseDTO
    {
        [JsonPropertyName("data")]
        public UserDataDTO Data { get; set; }
    }
}