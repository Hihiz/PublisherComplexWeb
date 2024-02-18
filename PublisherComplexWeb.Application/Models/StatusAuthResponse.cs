﻿using PublisherComplexWeb.Application.Interfaces;

namespace PublisherComplexWeb.Application.Models
{
    public class StatusAuthResponse : IBaseStatus
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}

