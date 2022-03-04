using System;

namespace BlazorApp.Shared
{
    public class DeactivateOfferRequest
    {
        public DeactivateOfferRequest(Guid offerId, string reason)
        {
            OfferId = offerId;
            Reason = reason;
        }

        public Guid OfferId { get; set; }

        public string Reason { get; set; }
    }
}
