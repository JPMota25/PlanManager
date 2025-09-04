using System;
using System.Collections.Generic;
using System.Text;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.DTOs.Request.Profiles.Company
{
    public class CreateCompanyDto
    {
        public CreatePersonDto Person { get; set; }
    }
}
