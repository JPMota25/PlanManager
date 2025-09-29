using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;
using PlanManager.Aplication.DTOs.Response.Profiles.User;

namespace PlanManager.Aplication.Commands.Profiles.User.ValidateToken
{
    public class ValidateTokenCommand : Notifiable<Notification> ,ICommand, IRequest<ResultDto<ResponseTokenValidation>>
    {
        public void Validate()
        {
            var contract = new Contract<Notification>().Requires();
            AddNotifications(contract);
        }

        public ValidateTokenCommand(string token)
        {
            Token = token;
            Validate();
        }

        public string Token { get; private set; }
    }
}
