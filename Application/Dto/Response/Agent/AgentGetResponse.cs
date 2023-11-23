﻿namespace Dto.Response.Agent
{
    public class AgentGetResponse
    {
        public long id { get; set; }
        public string name { get; set; } = string.Empty;
        public string adress { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string postalCode { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
    }
}
