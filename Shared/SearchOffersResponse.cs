using System;
using System.Collections.Generic;

namespace BlazorApp.Shared
{
    public class SearchOffersResult
    {
        public SearchOffersResult()
        {
            ShelterResults = new List<ShelterResult>();
            TransportResults = new List<TransportResult>();
        }

        public bool SearchedForShelter { get; set; }

        public ICollection<ShelterResult> ShelterResults { get; set; }

        public ICollection<TransportResult> TransportResults { get; set; }

        public class ShelterResult : BaseOfferResult
        {
            public int AdultCapacity { get; set; }

            public int ChildrenCapacity { get; set; }

            public TimePeriod Period { get; set; }

            public AddressModel Address { get; set; }
        }

        public class TransportResult : BaseOfferResult
        {
            public int AdultSeats { get; set; }

            public int ChildSeats { get; set; }

            public AddressModel Destination { get; set; }

            public DateTime? LeavesAt { get; set; }
        }

        public abstract class BaseOfferResult
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public string Phone { get; set; }

            public bool DisplayPhone { get; set; }

            public bool IsActive { get; set; }
        }
    }
}
