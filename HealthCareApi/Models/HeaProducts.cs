using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaProducts
    {
        public HeaProducts()
        {
            HeaBenefits = new HashSet<HeaBenefits>();
            HeaPlans = new HashSet<HeaPlans>();
        }

        public int Id { get; set; }
        public string ProdName { get; set; }
        public string ProdCode { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<HeaBenefits> HeaBenefits { get; set; }
        public ICollection<HeaPlans> HeaPlans { get; set; }
    }
}
