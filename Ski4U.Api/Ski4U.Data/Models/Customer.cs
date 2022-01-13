using System;
using System.Collections.Generic;

namespace Ski4U.Data.Models
{
    public class Customer : IEntityWithId
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Number { get; set; }

        public string Address { get; set; }

        public IList<Order> Orders { get; set; } = new List<Order>();

        public IList<Comment> Comments { get; set; } = new List<Comment>();
    }
}
