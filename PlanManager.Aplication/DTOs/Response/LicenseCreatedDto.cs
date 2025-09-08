namespace PlanManager.Aplication.DTOs.Response;

public class LicenseCreatedDto
{
    public string Id { get; set; }
    public string IdSign { get; set; }
    public decimal Value { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }

    public LicenseCreatedDto(string id, string idSign, decimal value, string type, string status)
    {
        Id = id;
        IdSign = idSign;
        Value = value;
        Type = type;
        Status = status;
    }
}