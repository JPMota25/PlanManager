using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Domain.Commands;

namespace PlanManager.Aplication.Commands.Profiles.User.LoginReport;

public class LoginReportCommand : Notifiable<Notification>, ICommand, IRequest<ResultDto<LoginReportDto>> {
	public void Validate() {
		throw new NotImplementedException();
	}

	public LoginReportCommand(string? email, string? document, string? username, DateTime initialTime, DateTime finalTime, int skip, int take) {
		Email = email;
		Document = document;
		Username = username;
		InitialTime = initialTime;
		FinalTime = finalTime;
		Skip = skip;
		Take = take;
		Validate();
	}

	public string? Email { get; private set; }
	public string? Document { get; private set; }
	public string? Username { get;  private set; }
	public DateTime InitialTime { get;private set; }
	public DateTime? FinalTime { get;private set; }
	public int Skip { get;private set; }
	public int Take { get;private set; }
}