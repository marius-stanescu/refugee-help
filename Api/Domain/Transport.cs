using System;

namespace BlazorApp.Api.Domain
{
    public class Transport : OfferBase
    {
        public string StartingPoint { get; set; }

        public Address Destination { get; set; }

        public DateTime? ExpiresOn { get; set; }
    }
}
