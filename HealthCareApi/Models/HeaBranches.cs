using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaBranches
    {
        public HeaBranches()
        {
            HeaPolicyHeader = new HashSet<HeaPolicyHeader>();
            HeaUsers = new HashSet<HeaUsers>();
            InverseBranch = new HashSet<HeaBranches>();
        }

        public int Id { get; set; }
        public int? BranchId { get; set; }
        public int? PartnerId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public HeaBranches Branch { get; set; }
        public ICollection<HeaPolicyHeader> HeaPolicyHeader { get; set; }
        public ICollection<HeaUsers> HeaUsers { get; set; }
        public ICollection<HeaBranches> InverseBranch { get; set; }
    }
}
