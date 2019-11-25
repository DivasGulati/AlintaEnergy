using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlintaEnergy.Application.Dto
{
    public class CustomerDto
    {
        //[JsonIgnore]
        public int? Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
