using System;
using System.Collections.Generic;
using System.Text;

namespace AlintaEnergy.Infrastructure.Model
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
