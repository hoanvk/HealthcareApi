using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaPlanDetails
    {
        public int Id { get; set; }
        public int? PlanId { get; set; }
        public int? BenefitId { get; set; }
        public string Title { get; set; }
        public long? Si { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public HeaBenefits Benefit { get; set; }
        public HeaPlans Plan { get; set; }
    }
}
