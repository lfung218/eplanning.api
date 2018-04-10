using System;

namespace eplanning.api.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User Creator { get; set; }
        public string Location { get; set; }
        public string EventType { get; set; }
        public DateTime EventDate { get; set; }
        public int NumOfGuest { get; set; }
    }
}
