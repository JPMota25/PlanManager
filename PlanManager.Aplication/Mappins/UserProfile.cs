using AutoMapper;
using PlanManager.Aplication.Commands.Profiles.User.ChangePassword;
using PlanManager.Aplication.Commands.Profiles.User.CreateUser;
using PlanManager.Aplication.Commands.Profiles.User.Login;
using PlanManager.Aplication.DTOs.Request.Profiles;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Mappins;

public class UserProfile : Profile {
	public UserProfile() {
		CreateMap<LoginDto, LoginCommand>().ForMember(x => x.Username, y => y.MapFrom(x => x.Username))
			.ForMember(x => x.Password, y => y.MapFrom(x => x.Password));

		CreateMap<CreatePersonDto, Person>().ConvertUsing(x => new Person(x.FirstName, x.LastName, x.Email, x.Document, x.Type, x.CountryCode, x.DDD,
			x.NumberWithDigit, x.Neighboorhood, x.HouseNumber, x.HasHouseNumber, x.Complement, x.Street, x.City, x.State, x.Country, x.Zipcode));

		CreateMap<CreateUserDto, CreateUserCommand>().ForMember(x => x.Person, y => y.MapFrom(x => x.Person))
			.ForMember(x => x.Username, y => y.MapFrom(x => x.Username)).ForMember(x => x.Password, y => y.MapFrom(x => x.Password));

		CreateMap<ChangePasswordDto, ChangePasswordCommand>().ForMember(x => x.NewPassword, y => y.MapFrom(x => x.NewPassword))
			.ForMember(x => x.Password, y => y.MapFrom(x => x.Password));
	}
}