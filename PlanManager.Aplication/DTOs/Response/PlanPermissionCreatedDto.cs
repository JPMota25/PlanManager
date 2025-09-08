namespace PlanManager.Aplication.DTOs.Response;

public class PlanPermissionCreatedDto
{
    public string Name { get; set; }
    public string Code { get; set; }

    public PlanPermissionCreatedDto(string name, string code)
    {
        Name = name;
        Code = code;
    }
}