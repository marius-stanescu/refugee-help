using System;

namespace BlazorApp.Api.Domain
{
    public class Transport : OfferBase
    {
        public int BorderId { get; set; }

        public Border Border { get; set; }

        public Address Destination { get; set; }

        public DateTime? ExpiresOn { get; set; }
    }
}
