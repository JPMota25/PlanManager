using Flunt.Notifications;
using MediatR;
using PlanManager.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;
using PlanManager.Aplication.DTOs;
using PlanManager.Domain.DTOs.Response.PlanManager.License;

namespace PlanManager.Aplication.Commands.PlanManager.License.VerifyLicenseAuthencity
{
    public class GenerateLicenseCommand : Notifiable<Notification> ,ICommand, IRequest<ResultDto<LicenseAuthencityResult>>
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
