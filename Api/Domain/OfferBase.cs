using System;

namespace BlazorApp.Api.Domain
{
    public abstract class OfferBase
    {
        protected OfferBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public ContactPerson ContactPerson { get; set; }

        public int AdultCapacity { get; set; }

        public int ChildrenCapacity { get; set; }

        public bool IsActive { get; set; } = true;

        public string DeactivationReason { get; set; }
    }
}
