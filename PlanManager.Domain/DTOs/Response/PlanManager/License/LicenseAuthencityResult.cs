using PlanManager.Domain.Entities.PlanManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanManager.Domain.DTOs.Response.PlanManager.License
{
    public class LicenseAuthencityResult
    {
        public DateTime DateTimeValidated { get; set; }
        public string Jwt { get; set; }

        public LicenseAuthencityResult(DateTime dateTimeValidated, string jwt)
        {
            DateTimeValidated = dateTimeValidated;
            Jwt = jwt;
        }
    }
}
