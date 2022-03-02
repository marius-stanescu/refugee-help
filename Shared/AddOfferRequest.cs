using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class AddOfferRequest
    {
        public AddOfferRequest()
        {
            Transport = new TransportOfferModel();
            Shelter = new ShelterOfferModel();
        }

        public string Name { get; set; }

        public string Phone { get; set; }

        public TransportOfferModel Transport { get; set; }

        public ShelterOfferModel Shelter { get; set; }

        public class TransportOfferModel
        {
            public TransportOfferModel()
            {
                Destination = new AddressModel();
            }

            public bool IsOffered { get; set; }

            public string StartingPoint { get; set; }

            public AddressModel Destination { get; set; }

            public int AdultSeats { get; set; }

            public int ChildSeats { get; set; }

            public DateTime? ExpiryDate { get; set; }

            public TimeSpan? ExpiryTime { get; set; }
        }

        public class ShelterOfferModel
        {
            public ShelterOfferModel()
            {
                Address = new AddressModel();
            }

            public bool IsOffered { get; set; }

            public AddressModel Address { get; set; }

            public int AdultCapacity { get; set; }

            public int ChildrenCapacity { get; set; }

            public bool AllowsPets { get; set; }

            public TimePeriod Period { get; set; }
        }

        public class AddressModel
        {
            public AddressModel()
            {
                Region = new RegionModel();
                City = new CityModel();
            }

            public RegionModel Region { get; set; }

            public CityModel City { get; set; }
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
                .When(x => !x.Shelter.IsOffered)
                .WithMessage("Oferta trebuie să includă transport, cazare sau ambele!");

            RuleFor(x => x.Transport.StartingPoint)
                .NotEmpty()
                .When(x => x.Transport.IsOffered)
                .WithMessage("Locul de plecare este necesar!");

            RuleFor(x => x.Transport.Destination.Region)
                .NotEmpty()
                .When(x => x.Transport.IsOffered)
                .WithMessage("Destinația este necesară!");

            RuleFor(x => x.Transport.Destination.City)
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

            RuleFor(x => x.Shelter.IsOffered)
                .Must(isOffered => isOffered)
                .When(x => !x.Transport.IsOffered)
                .WithMessage("Oferta trebuie să includă transport, cazare sau ambele!");

            RuleFor(x => x.Shelter.Address.Region)
                .NotEmpty()
                .When(x => x.Shelter.IsOffered)
                .WithMessage("Județul este necesar!");

            RuleFor(x => x.Shelter.Address.City)
                .NotEmpty()
                .When(x => x.Shelter.IsOffered)
                .WithMessage("Orașul este necesar!");

            RuleFor(x => x.Shelter.Period)
                .IsInEnum()
                .When(x => x.Shelter.IsOffered)
                .WithMessage("Perioada este necesară!");

            RuleFor(x => x.Shelter.AdultCapacity)
                .InclusiveBetween(0, 1000)
                .When(x => x.Shelter.IsOffered)
                .WithMessage("Nr. de adulți este necesar!");

            RuleFor(x => x.Shelter.AdultCapacity)
                .GreaterThan(0)
                .When(x => x.Shelter.IsOffered && x.Shelter.ChildrenCapacity == 0)
                .WithMessage("Nr. de adulți este necesar!");

            RuleFor(x => x.Shelter.ChildrenCapacity)
                .InclusiveBetween(0, 1000)
                .When(x => x.Shelter.IsOffered)
                .WithMessage("Nr. de copii este necesar!");

            RuleFor(x => x.Shelter.ChildrenCapacity)
                .GreaterThan(0)
                .When(x => x.Shelter.IsOffered && x.Shelter.AdultCapacity == 0)
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
