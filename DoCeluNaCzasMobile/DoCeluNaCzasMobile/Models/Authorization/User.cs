﻿using Newtonsoft.Json;

namespace DoCeluNaCzasMobile.Models.Authorization
{
    public class User
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("issued")]
        public string Issued { get; set; }
        [JsonProperty("expires")]
        public string Expires { get; set; }
    }
}
