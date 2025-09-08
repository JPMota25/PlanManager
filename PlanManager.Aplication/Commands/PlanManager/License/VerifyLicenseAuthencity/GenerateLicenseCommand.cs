using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Domain.Commands;
using PlanManager.Domain.DTOs.Response.PlanManager.License;

namespace PlanManager.Aplication.Commands.PlanManager.License.VerifyLicenseAuthencity
{
    public class GenerateLicenseCommand : Notifiable<Notification>, ICommand, IRequest<ResultDto<LicenseAuthencityResult>>
    {
        public void Validate()
        {
            var contract = new Contract<Notification>().Requires();
            AddNotifications(contract);
        }

        public GenerateLicenseCommand(string customerIdentification, string signIdentification)
        {
            SignIdentification = signIdentification;
            CustomerIdentification = customerIdentification;
        }

        public string CustomerIdentification { get; private set; }
        public string SignIdentification { get; private set; }
    }
}
