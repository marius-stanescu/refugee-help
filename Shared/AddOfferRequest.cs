using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

            public string StartingPoint { get; set; }

            public string Destination { get; set; }

            public int AdultSeats { get; set; }

            public int ChildSeats { get; set; }

            public DateTime? ExpiryDate { get; set; }

            public TimeSpan? ExpiryTime { get; set; }
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

    public class AddOfferRequestValidator : AbstractValidator<AddOfferRequest>
    {
        public AddOfferRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Numele este necesar!");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Telefonul este necesar!")
                .Length(10, 30)
                .WithMessage("Telefonul este necesar!");

            RuleFor(x => x.Transport.IsOffered)
                .Must(isOffered => isOffered)
                .When(x => !x.Housing.IsOffered)
                .WithMessage("Oferta trebuie să includă transport sau cazare sau ambele!");

            RuleFor(x => x.Transport.StartingPoint)
                .NotEmpty()
                .When(x => x.Transport.IsOffered)
                .WithMessage("Locul de plecare este necesar!");

            RuleFor(x => x.Transport.Destination)
                .NotEmpty()
                .When(x => x.Transport.IsOffered)
                .WithMessage("Destinația este necesară!");

            RuleFor(x => x.Transport.AdultSeats)
                .InclusiveBetween(0, 200)
                .When(x => x.Transport.IsOffered)
                .WithMessage("Nr. de locuri pentru adulți este necesar!");

            RuleFor(x => x.Transport.AdultSeats)
                .GreaterThan(0)
                .When(x => x.Transport.IsOffered && x.Transport.ChildSeats == 0)
                .WithMessage("Nr. de locuri pentru adulți este necesar!");

            RuleFor(x => x.Transport.ChildSeats)
                .InclusiveBetween(0, 200)
                .When(x => x.Transport.IsOffered)
                .WithMessage("Nr. de scaune pentru copii este necesar!");

            RuleFor(x => x.Transport.ChildSeats)
                .GreaterThan(0)
                .When(x => x.Transport.IsOffered && x.Transport.AdultSeats == 0)
                .WithMessage("Nr. de scaune pentru copii este necesar!");

            RuleFor(x => x.Housing.IsOffered)
                .Must(isOffered => isOffered)
                .When(x => !x.Transport.IsOffered)
                .WithMessage("Oferta trebuie să includă transport sau cazare sau ambele!");

            RuleFor(x => x.Housing.City)
                .NotEmpty()
                .When(x => x.Housing.IsOffered)
                .WithMessage("Orașul este necesar!");

            RuleFor(x => x.Housing.Period)
                .IsInEnum()
                .When(x => x.Housing.IsOffered)
                .WithMessage("Perioada este necesară!");

            RuleFor(x => x.Housing.AdultCapacity)
                .InclusiveBetween(0, 1000)
                .When(x => x.Housing.IsOffered)
                .WithMessage("Nr. de adulți este necesar!");

            RuleFor(x => x.Housing.AdultCapacity)
                .GreaterThan(0)
                .When(x => x.Housing.IsOffered && x.Housing.ChildrenCapacity == 0)
                .WithMessage("Nr. de adulți este necesar!");

            RuleFor(x => x.Housing.ChildrenCapacity)
                .InclusiveBetween(0, 1000)
                .When(x => x.Housing.IsOffered)
                .WithMessage("Nr. de copii este necesar!");

            RuleFor(x => x.Housing.ChildrenCapacity)
                .GreaterThan(0)
                .When(x => x.Housing.IsOffered && x.Housing.AdultCapacity == 0)
                .WithMessage("Nr. de copii este necesar!");
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<AddOfferRequest>.CreateWithOptions((AddOfferRequest)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
            {
                return Array.Empty<string>();
            }

            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
