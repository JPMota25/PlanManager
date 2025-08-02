using PlanManager.Aplication.Commands.Profiles.User.Login;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Interfaces.Profiles;

public interface IUserService {
	Task AddUser(User user);
	Task<User?> AuthenticateAndReturnUser(string username, string password);
}