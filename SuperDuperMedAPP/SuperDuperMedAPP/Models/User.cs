using System;

namespace SuperDuperMedAPP.Models
{
    public abstract class User
    {
        // ReSharper disable once InconsistentNaming
        public int ID { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string Username { get; set; } = null!;

        public string HashPassword { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
