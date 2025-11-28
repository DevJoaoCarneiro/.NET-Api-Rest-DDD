using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.Response
{
    public class UserResponseDTO
    {
        [JsonPropertyName("message")]
        public string message { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string status { get; set; } = string.Empty;

        public UserData? data { get; set; } = new UserData();
    }

    public class UserData
    {
        [JsonPropertyName("name")]
        public string name { get; set; } = string.Empty;
        [JsonPropertyName("email")]
        public string email { get; set; } = string.Empty;
    }
}
