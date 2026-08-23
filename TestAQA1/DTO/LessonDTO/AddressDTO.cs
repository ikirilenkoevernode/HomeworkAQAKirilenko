namespace TestAQA3.DTO {
    using System.Text.Json.Serialization;
    public record AdressDTO
    (


       [property: JsonPropertyName("country")]
    string Country,
       [property: JsonPropertyName("city")]
   string City,
       [property: JsonPropertyName("street")]
   string Street,
       [property: JsonPropertyName("zip")]
   string Zip
        );

}