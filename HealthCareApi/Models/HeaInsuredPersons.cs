using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaInsuredPersons
    {
        public HeaInsuredPersons()
        {
            HeaAnswers = new HashSet<HeaAnswers>();
            HeaOptionalBenefits = new HashSet<HeaOptionalBenefits>();
            HeaTreatments = new HashSet<HeaTreatments>();
        }

        public int Id { get; set; }
        public int? ClientInfoId { get; set; }
        public string RelativeType { get; set; }
        public int? PolicyHeaderId { get; set; }
        public int? PlanId { get; set; }
        public short? Age { get; set; }
        public long? Si { get; set; }
        public long? PreAmt { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Gender { get; set; }
        public long? OptPreAmt { get; set; }

        public HeaClients ClientInfo { get; set; }
        public HeaPlans Plan { get; set; }
        public HeaPolicyHeader PolicyHeader { get; set; }
        public ICollection<HeaAnswers> HeaAnswers { get; set; }
        public ICollection<HeaOptionalBenefits> HeaOptionalBenefits { get; set; }
        public ICollection<HeaTreatments> HeaTreatments { get; set; }
    }
}
