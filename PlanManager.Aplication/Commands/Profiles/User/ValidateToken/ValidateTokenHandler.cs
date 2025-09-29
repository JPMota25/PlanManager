using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response.Profiles.User;
using PlanManager.Aplication.Interfaces.Utils;

namespace PlanManager.Aplication.Commands.Profiles.User.ValidateToken
{
    public class ValidateTokenHandler : Notifiable<Notification>, IRequestHandler<ValidateTokenCommand, ResultDto<ResponseTokenValidation>>
    {
        private readonly ITokenService _tokenService;

        public ValidateTokenHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public async Task<ResultDto<ResponseTokenValidation>> Handle(ValidateTokenCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid)
                return ResultDto<ResponseTokenValidation>.Fail(new Notification("Token.Validation", "Token request error."));

            var validToken = _tokenService.ValidateToken(request.Token);
            if(!validToken)
                return ResultDto<ResponseTokenValidation>.Fail(new Notification("Token.Invalid", "Invalid Token Login Again."));

            return ResultDto<ResponseTokenValidation>.Ok(new ResponseTokenValidation(validToken, DateTime.Now));
        }
    }
}
