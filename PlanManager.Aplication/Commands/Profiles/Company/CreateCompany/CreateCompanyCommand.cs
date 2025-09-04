using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response.Company;
using PlanManager.Domain.Commands;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Commands.Profiles.Company.CreateCompany
{
    public class CreateCompanyCommand : Notifiable<Notification>, ICommand , IRequest<ResultDto<CompanyCreatedDto>>
    {
        public void Validate()
        {
            var contract = new Contract<Notification>().Requires();
            AddNotifications(contract);
        }

        public CreateCompanyCommand(Person person)
        {
            Person = person;
            Validate();
        }

        public Person Person { get; private set; }
    }
}
