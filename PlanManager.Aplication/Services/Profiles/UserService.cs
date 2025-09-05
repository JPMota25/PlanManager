using PlanManager.Aplication.Commands.Profiles.User.Login;
using PlanManager.Aplication.Commands.Profiles.User.LoginReport;
using PlanManager.Aplication.DTOs.Request.Profiles;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.DTOs;
using PlanManager.Domain.DTOs.Response;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;

namespace PlanManager.Aplication.Services.Profiles;

public class UserService : IUserService {
	private readonly IUserRepository _userRepository;
	private readonly IPasswordHashService _passwordHashService;

	public UserService(IUserRepository userRepository, IPasswordHashService passwordHashService) {
		_userRepository = userRepository;
		_passwordHashService = passwordHashService;
	}

	public async Task AddUser(User user) {
		await _userRepository.AddAsync(user);
	}

	public async Task<User?> AuthenticateAndReturnUser(string username, string password) {
		var userDb = await _userRepository.GetUser(username);
		if (userDb == null)
			return null;

		return !_passwordHashService.VerifyPassword(password, userDb.Password, userDb) ? null : userDb;
	}

	public async Task<IList<LoginReportDto>> GenerateLoginReport(LoginReportCommand loginReportCommand) {
		return await _userRepository.LoginReport(loginReportCommand.Email, loginReportCommand.Document, loginReportCommand.InitialTime,
			loginReportCommand.FinalTime, loginReportCommand.Skip, loginReportCommand.Take);
	}

    public async Task<IList<string>> PermissionsInUser(string idUser)
    {
        throw new NotImplementedException();
    }
}