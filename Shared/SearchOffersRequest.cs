using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class SearchOffersRequest
    {
        public SearchOffersRequest()
        {
            Shelter = new ShelterModel();
            Address = new AddressModel();
        }

        public int NumberOfAdults { get; set; }

        public int NumberOfChildren { get; set; }

        public string StartingPoint { get; set; }

        public ShelterModel Shelter { get; set; }

        public AddressModel Address { get; set; }

        public class ShelterModel
        {
            public ShelterModel()
            {
                Period = TimePeriod.OneToThreeDays;
            }

            public bool IsNeeded { get; set; }

            public TimePeriod Period { get; set; }

            public bool AllowsPets { get; set; }
        }
    }

    public class SearchOffersRequestValidator : AbstractValidator<SearchOffersRequest>
    {
        public SearchOffersRequestValidator()
        {
            RuleFor(x => x.NumberOfAdults)
                .InclusiveBetween(0, 200)
                .WithMessage("Nr. de adulți este necesar!")
                .GreaterThan(0)
                .When(x => x.NumberOfChildren == 0)
                .WithMessage("Nr. de adulți sau copii este necesar!");

            RuleFor(x => x.NumberOfChildren)
                .InclusiveBetween(0, 200)
                .WithMessage("Nr. de copii este necesar!")
                .GreaterThan(0)
                .When(x => x.NumberOfAdults == 0)
                .WithMessage("Nr. de adulți sau copii este necesar!");

            RuleFor(x => x.StartingPoint)
                .NotEmpty()
                .WithMessage("Locul de plecare este necesar!");

            RuleFor(x => x.Shelter.Period)
                .IsInEnum()
                .When(x => x.Shelter.IsNeeded)
                .WithMessage("Perioada este necesară!");
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var validationContext = ValidationContext<SearchOffersRequest>
                .CreateWithOptions((SearchOffersRequest)model, x => x.IncludeProperties(propertyName));
            var result = await ValidateAsync(validationContext);
            if (result.IsValid)
            {
                return Array.Empty<string>();
            }

            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
