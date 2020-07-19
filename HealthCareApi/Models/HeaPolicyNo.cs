using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaPolicyNo
    {
        public int PolicyNo { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
