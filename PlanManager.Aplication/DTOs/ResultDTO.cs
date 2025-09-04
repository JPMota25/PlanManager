using Flunt.Notifications;

namespace PlanManager.Aplication.DTOs;

public class ResultDto<T> where T : class {
	public static ResultDto<T> Ok(T data) {
		return new ResultDto<T>("true", data);
	}

	public static ResultDto<T> Fail(IReadOnlyCollection<Notification> notifications) {
		return new ResultDto<T>("false", notifications);
	}

	public static ResultDto<T> Fail(Notification notification) {
		return new ResultDto<T>("false", notification);
	}

	public string Success { get; private set; }
	public IList<T> Data { get; private set; } = [];
	public IReadOnlyCollection<Notification> Errors { get; private set; } = [];


	public ResultDto(string success, T data) {
		Success = success;
		Data.Add(data);
	}

	public ResultDto(string success, IReadOnlyCollection<Notification> errors) {
		Success = success;
		Errors = errors;
	}

	public ResultDto(string success, Notification notification) {
		Success = success;
		Errors = [notification];
	}
}