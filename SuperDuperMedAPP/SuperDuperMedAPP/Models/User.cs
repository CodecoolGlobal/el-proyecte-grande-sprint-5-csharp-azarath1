using System;

namespace SuperDuperMedAPP.Models
{
    public abstract class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string Username { get; set; }

        public string HashPassword { get; set; }
        public string Role { get; set; }

    }
}
