using PlanManager.Aplication.Commands;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Services.Profiles;

public class UserService : IUserService {
	private readonly IUserRepository _userRepository;
	private readonly IPasswordHashService _passwordHashService;
	private readonly IPersonService _personService;
	private readonly ILogActivityService _logActivityService;

	public UserService(IUserRepository userRepository, IPasswordHashService passwordHashService, IPersonService personService,
		ILogActivityService logActivityService) {
		_logActivityService = logActivityService;
		_userRepository = userRepository;
		_personService = personService;
		_passwordHashService = passwordHashService;
	}

	public Task<IList<User>> HandleListUser() {
		throw new NotImplementedException();
	}

	public Task<User> HandleCreateUser(CreateUserCommand model) {
		throw new NotImplementedException();
	}

	public Task<bool> HandleAuthenticateUser(LoginCommand model) {
		throw new NotImplementedException();
	}

	public Task<User?> HandleGetUserByUsername(string username) {
		throw new NotImplementedException();
	}

	public Task<User?> HandleGetUserById(Id id) {
		throw new NotImplementedException();
	}

	public Task HandleChangePassword(ChangePasswordByUsernameCommand model) {
		throw new NotImplementedException();
	}
}