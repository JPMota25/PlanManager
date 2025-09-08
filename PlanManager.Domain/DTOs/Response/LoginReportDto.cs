namespace PlanManager.Domain.DTOs.Response;

public class LoginReportDto
{
    public string Username { get; set; }
    public string Name { get; set; }
    public DateTime LoggedAt { get; set; }
}

public class ListLoginReportDto
{
    public IList<LoginReportDto> Report { get; set; }

    public ListLoginReportDto(IList<LoginReportDto> report)
    {
        Report = report;
    }
}