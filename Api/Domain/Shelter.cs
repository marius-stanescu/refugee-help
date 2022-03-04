using System;
using BlazorApp.Shared;

namespace BlazorApp.Api.Domain
{
    public class Shelter : OfferBase
    {
        public Address Address { get; set; }

        public bool AllowsPets { get; set; }

        public TimePeriod Period { get; set; }

        public int MaxPeriodInDays { get; set; }
    }
}
