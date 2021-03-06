﻿using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaPlans
    {
        public HeaPlans()
        {
            HeaInsuredPersons = new HashSet<HeaInsuredPersons>();
            HeaPlanDetails = new HashSet<HeaPlanDetails>();
            HeaPrices = new HashSet<HeaPrices>();
        }

        public int Id { get; set; }
        public string PlanCode { get; set; }
        public string PlanName { get; set; }
        public int? ProductId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public HeaProducts Product { get; set; }
        public ICollection<HeaInsuredPersons> HeaInsuredPersons { get; set; }
        public ICollection<HeaPlanDetails> HeaPlanDetails { get; set; }
        public ICollection<HeaPrices> HeaPrices { get; set; }
    }
}
