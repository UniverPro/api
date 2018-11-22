﻿using Newtonsoft.Json;

namespace Uni.WebApi.Models.Responses
{
    [JsonObject]
    public class UniversityResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }
    }
}