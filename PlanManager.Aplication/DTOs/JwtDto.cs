namespace PlanManager.Aplication.DTOs;

public class JwtDto
{
    public string JwtKey { get; set; }

    public JwtDto(string jwtKey)
    {
        JwtKey = jwtKey;
    }
}