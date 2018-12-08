﻿using Newtonsoft.Json;

namespace Uni.WebApi.Models.Responses
{
    [JsonObject]
    public class UserResponseModel
    {
        public int Id { get; set; }
        
        public string Login { get; set; }

        public int PersonId { get; set; }
    }
}