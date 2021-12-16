using System;

namespace BetScore.Application.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}