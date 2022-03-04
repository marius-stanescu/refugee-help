using System;

namespace BlazorApp.Api.Domain
{
    public abstract class OfferBase
    {
        protected OfferBase()
        {
            Id = Guid.NewGuid();
            CreatedOnUtc = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }

        public ContactPerson ContactPerson { get; set; }

        public int AdultCapacity { get; set; }

        public int ChildrenCapacity { get; set; }

        public bool IsActive { get; private set; } = true;

        public string DeactivationReason { get; private set; }

        public DateTime CreatedOnUtc { get; private set; }

        public DateTime? DeactivatedOnUtc { get; private set; }

        public void Deactivate(string reason)
        {
            IsActive = false;
            DeactivationReason = reason;
            DeactivatedOnUtc = DateTime.UtcNow;
        }
    }
}
