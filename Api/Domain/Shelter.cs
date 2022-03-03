using System;
using BlazorApp.Shared;

namespace BlazorApp.Api.Domain
{
    public class Shelter
    {
        public Shelter()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public ContactPerson ContactPerson { get; set; }

        public Address Address { get; set; }

        public int AdultCapacity { get; set; }

        public int ChildrenCapacity { get; set; }

        public bool AllowsPets { get; set; }

        public TimePeriod Period { get; set; }

        public int MaxPeriodInDays { get; set; }
    }
}
