using AutoMapper;
using PlanManager.Aplication.Commands.Profiles.User.ChangePassword;
using PlanManager.Aplication.Commands.Profiles.User.CreateUser;
using PlanManager.Aplication.Commands.Profiles.User.Login;
using PlanManager.Aplication.Commands.Profiles.User.LoginReport;
using PlanManager.Aplication.Commands.Profiles.User.ValidateToken;
using PlanManager.Aplication.DTOs.Request.Profiles;
using PlanManager.Aplication.DTOs.Request.Profiles.Person;
using PlanManager.Aplication.DTOs.Request.Profiles.User;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Mappings.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RequestLogin, LoginCommand>().ForMember(x => x.Username, y => y.MapFrom(x => x.Username))
            .ForMember(x => x.Password, y => y.MapFrom(x => x.Password));

        CreateMap<RequestCreatePerson, Person>().ConvertUsing(x => new Person(x.FirstName, x.LastName, x.Email, x.Document, x.Type, x.CountryCode, x.DDD,
            x.NumberWithDigit, x.Neighboorhood, x.HouseNumber, x.HasHouseNumber, x.Complement, x.Street, x.City, x.State, x.Country, x.Zipcode));

        CreateMap<RequestCreateUser, CreateUserCommand>().ForMember(x => x.Person, y => y.MapFrom(x => x.Person))
            .ForMember(x => x.Username, y => y.MapFrom(x => x.Username)).ForMember(x => x.Password, y => y.MapFrom(x => x.Password));

        CreateMap<RequestChangePassword, ChangePasswordCommand>().ForMember(x => x.NewPassword, y => y.MapFrom(x => x.NewPassword))
            .ForMember(x => x.Password, y => y.MapFrom(x => x.Password));

        CreateMap<RequestLoginReport, LoginReportCommand>().ForMember(x => x.Email, y => y.MapFrom(x => x.Email))
            .ForMember(x => x.Document, y => y.MapFrom(x => x.Document)).ForMember(x => x.FinalTime, y => y.MapFrom(x => x.FinalTime))
            .ForMember(x => x.InitialTime, y => y.MapFrom(x => x.InitialTime)).ForMember(x => x.Skip, y => y.MapFrom(x => x.Skip))
            .ForMember(x => x.Take, y => y.MapFrom(x => x.Take));

        CreateMap<RequestTokenValidation, ValidateTokenCommand>().ForMember(x => x.Token, y => y.MapFrom(x => x.Token));
    }
}