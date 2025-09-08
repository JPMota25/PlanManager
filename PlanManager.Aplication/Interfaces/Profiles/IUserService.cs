using PlanManager.Aplication.Commands.Profiles.User.LoginReport;
using PlanManager.Domain.DTOs.Response;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Interfaces.Profiles;

public interface IUserService
{
    Task AddUser(User user);
    Task<User?> AuthenticateAndReturnUser(string username, string password);
    Task<IList<LoginReportDto>> GenerateLoginReport(LoginReportCommand loginReportCommand);
    Task<IList<string>> PermissionsInUser(string idUser);
}