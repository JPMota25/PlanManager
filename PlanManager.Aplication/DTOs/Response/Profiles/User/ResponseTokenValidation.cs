using System;
using System.Collections.Generic;
using System.Text;

namespace PlanManager.Aplication.DTOs.Response.Profiles.User
{
    public class ResponseTokenValidation
    {
        public bool IsValid { get; set; }
        public DateTime ValidatedAt { get; set; }

        public ResponseTokenValidation(bool isValid, DateTime validatedAt)
        {
            IsValid = isValid;
            ValidatedAt = validatedAt;
        }
    }
}
