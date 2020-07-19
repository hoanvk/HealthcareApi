using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaBenefits
    {
        public HeaBenefits()
        {
            HeaOptionalBenefits = new HashSet<HeaOptionalBenefits>();
            HeaPlanDetails = new HashSet<HeaPlanDetails>();
            HeaPrices = new HashSet<HeaPrices>();
        }

        public int Id { get; set; }
        public string BenefitName { get; set; }
        public string Flag { get; set; }
        public string BenefitCode { get; set; }
        public int? ProductId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public HeaProducts Product { get; set; }
        public ICollection<HeaOptionalBenefits> HeaOptionalBenefits { get; set; }
        public ICollection<HeaPlanDetails> HeaPlanDetails { get; set; }
        public ICollection<HeaPrices> HeaPrices { get; set; }
    }
}
