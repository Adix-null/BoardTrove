﻿using System.ComponentModel.DataAnnotations;

namespace BoardTroveAPI.Models
{
    public class UserDTO
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
