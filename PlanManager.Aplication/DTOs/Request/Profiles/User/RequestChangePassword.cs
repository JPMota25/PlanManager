namespace PlanManager.Aplication.DTOs.Request.Profiles;

public class RequestChangePassword
{
    public string Password { get; set; }
    public string NewPassword { get; set; }

    public RequestChangePassword(string password, string newPassword)
    {
        Password = password;
        NewPassword = newPassword;
    }
}