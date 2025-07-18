using PlanManager.Aplication.Commands;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Interfaces.Profiles;

public interface IUserService {
	Task<IList<User>> HandleListUser();
	Task<User> HandleCreateUser(CreateUserCommand model);
	Task<bool> HandleAuthenticateUser(LoginCommand model);
	Task<User?> HandleGetUserByUsername(string username);
	Task<User?> HandleGetUserById(Id id);

	Task HandleChangePassword(ChangePasswordByUsernameCommand model);
}