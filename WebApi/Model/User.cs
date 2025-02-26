﻿namespace WebApi.Model
{
    public class User
    {
        public int Id { get; set; } // Unique identifier for each user
        public string Username { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Skillsets { get; set; }
        public string Hobby { get; set; }
    }
}
