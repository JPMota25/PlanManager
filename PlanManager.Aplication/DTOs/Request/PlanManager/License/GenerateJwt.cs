using System;
using System.Collections.Generic;
using System.Text;

namespace PlanManager.Aplication.DTOs.Request.PlanManager.License
{
    public class GenerateJwt
    {
        public string CustomerIdentification { get; set; }
        public string SignIdentification { get; set; }
    }
}
