using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaPolicyHeader
    {
        public HeaPolicyHeader()
        {
            HeaDocs = new HashSet<HeaDocs>();
            HeaInsuredPersons = new HashSet<HeaInsuredPersons>();
            HeaTrans = new HashSet<HeaTrans>();
        }

        public int Id { get; set; }
        public int? ClientInfoId { get; set; }
        public int? AgentId { get; set; }
        public int? StaffId { get; set; }
        public int? BranchId { get; set; }
        public string PolicyNo { get; set; }
        public DateTime? InceptionDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public long? Totalpre { get; set; }
        public long? Discount { get; set; }
        public long? Netpre { get; set; }
        public long? TotalSi { get; set; }
        public DateTime? TranDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public byte? LastStatus { get; set; }
        public int? PolicyHeaderId { get; set; }

        public HeaAgents Agent { get; set; }
        public HeaBranches Branch { get; set; }
        public HeaClients ClientInfo { get; set; }
        public ICollection<HeaDocs> HeaDocs { get; set; }
        public ICollection<HeaInsuredPersons> HeaInsuredPersons { get; set; }
        public ICollection<HeaTrans> HeaTrans { get; set; }
    }
}
