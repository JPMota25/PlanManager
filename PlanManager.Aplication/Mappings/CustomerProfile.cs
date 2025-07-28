using AutoMapper;
using PlanManager.Aplication.Commands.CreateCustomer;
using PlanManager.Aplication.DTOs.Request;
using PlanManager.Aplication.DTOs.Request.ValueObjects;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Mappings;

public class CustomerProfile : Profile {
	public CustomerProfile() {
		CreateMap<FullNameDto, FullName>().ConvertUsing(x => new FullName(x.FirstName, x.LastName));

		CreateMap<EmailDto, Email>().ConvertUsing(x => new Email(x.EmailAddress));

		CreateMap<DocumentDto, Document>().ConvertUsing(x => new Document(x.Identification, x.Type));

		CreateMap<PhoneDto, Phone>().ConvertUsing(x => new Phone(x.CountryCode, x.DDD, x.NumberWithDigit));

		CreateMap<AddressDto, Address>().ConvertUsing(x =>
			new Address(x.Neighboorhood, x.HouseNumber, x.HasHouseNumber, x.Complement, x.Street, x.City, x.State, x.Country, x.Zipcode));

		CreateMap<CreateCustomerDto, CreateCustomerCommand>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
			.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.Document))
			.ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone)).ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
	}
}