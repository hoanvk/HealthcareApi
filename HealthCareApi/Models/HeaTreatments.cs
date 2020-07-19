using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaTreatments
    {
        public int Id { get; set; }
        public int? PolicyRiskId { get; set; }
        public string Disease { get; set; }
        public string Examination { get; set; }
        public string Treatment { get; set; }

        public HeaInsuredPersons PolicyRisk { get; set; }
    }
}
