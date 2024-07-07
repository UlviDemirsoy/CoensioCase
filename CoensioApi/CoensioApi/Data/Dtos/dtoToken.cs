using System.Text.Json.Serialization;

namespace CoensioApi.Data.Dtos
{
    public class dtoToken
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
    }
}
