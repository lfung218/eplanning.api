using System;
using System.Collections.Generic;

namespace eplanning.api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BDay { get; set; }
        public List<Event> EventNames { get; set; }
    }
}