using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaOptionalBenefits
    {
        public int? PolicyRiskId { get; set; }
        public int? BenefitId { get; set; }
        public string BenefitCode { get; set; }
        public string OptionalFlag { get; set; }
        public int Id { get; set; }
        public long? Si { get; set; }
        public long? PreAmt { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public HeaBenefits Benefit { get; set; }
        public HeaInsuredPersons PolicyRisk { get; set; }
    }
}
