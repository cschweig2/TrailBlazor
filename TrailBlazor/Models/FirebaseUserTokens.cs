using Newtonsoft.Json;

namespace TrailBlazor.Models
{
    class FirebaseUserTokens
    {
        [JsonProperty("Access_Token")]
        public string AccessToken { get; set; }
        [JsonProperty("Expires_In")]
        public string ExpiresIn { get; set; }
        [JsonProperty("Token_Type")]
        public string TokenType { get; set; }
        [JsonProperty("Refresh_Token")]
        public string RefreshToken { get; set; }
        [JsonProperty("Id_Token")]
        public string IdToken { get; set; }
    }
}
