namespace PlanManager.Aplication.DTOs.Response;

public class UserCreatedDto {
	public string Id { get; set; }
	public string Username { get; set; }

	public UserCreatedDto(string id, string username) {
		Id = id;
		Username = username;
	}
}