using System;
using System.Collections.Generic;

namespace BlazorApp.Shared
{
    public class AddOfferRequest
    {
        public AddOfferRequest()
        {
            Transport = new TransportOfferModel();
            Housing = new HousingOfferModel();
        }


        public string Name { get; set; }

        public string Phone { get; set; }

        public TransportOfferModel Transport { get; set; }

        public HousingOfferModel Housing { get; set; }

        public class TransportOfferModel
        {
            public bool IsOffered { get; set; }

            public IEnumerable<string> Cities { get; set; } = new HashSet<string>() { };

            public int AdultCapacity { get; set; }

            public int CarSeatCapacity { get; set; }

            public DateTime? ExpiryDate { get; set; } = DateTime.Today;

            public TimeSpan? ExpiryTime { get; set; } = new TimeSpan(12, 00, 00);
        }

        public class HousingOfferModel
        {
            public bool IsOffered { get; set; }

            public string City { get; set; }

            public int AdultCapacity { get; set; }

            public int ChildrenCapacity { get; set; }

            public bool AllowsPets { get; set; }

            public HousingPeriod Period { get; set; }
        }
    }
}
