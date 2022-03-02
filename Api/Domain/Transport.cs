using System;

namespace BlazorApp.Api.Domain
{
    public class Transport
    {
        public Transport()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public ContactPerson ContactPerson { get; set; }

        public string StartingPoint { get; set; }

        public Address Destination { get; set; }

        public int AdultSeats { get; set; }

        public int ChildSeats { get; set; }

        public DateTime? ExpiresOn { get; set; }
    }
}
