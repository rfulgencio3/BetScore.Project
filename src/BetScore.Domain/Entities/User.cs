using System;
using System.Collections.Generic;
using System.Text;

namespace BetScore.Domain.Entities
{
    public class User : Base
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
