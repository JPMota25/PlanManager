namespace PlanManager.Aplication.DTOs.Response.PlanManager.PlanPermission;

public class ResponsePlanPermissionCreated
{
    public string Name { get; set; }
    public string Code { get; set; }

    public ResponsePlanPermissionCreated(string name, string code)
    {
        Name = name;
        Code = code;
    }
}