using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaPrices
    {
        public int Id { get; set; }
        public short? FromAge { get; set; }
        public short? ToAge { get; set; }
        public string Title { get; set; }
        public long? Price { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int? PlanId { get; set; }
        public int? BenefitId { get; set; }

        public HeaBenefits Benefit { get; set; }
        public HeaPlans Plan { get; set; }
    }
}
