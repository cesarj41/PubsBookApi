using System;
using System.Collections.Generic;

namespace CaribeMediaApi.Entities
{
    public class Publishers
    {
        public Publishers()
        {
            Employee = new HashSet<Employee>();
            Titles = new HashSet<Titles>();
        }

        public string PubId { get; set; }
        public string PubName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public PubInfo PubInfo { get; set; }
        public ICollection<Employee> Employee { get; set; }
        public ICollection<Titles> Titles { get; set; }
    }
}
