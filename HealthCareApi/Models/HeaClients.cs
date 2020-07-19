using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaClients
    {
        public HeaClients()
        {
            HeaCorporateInfo = new HashSet<HeaCorporateInfo>();
            HeaInsuredPersons = new HashSet<HeaInsuredPersons>();
            HeaPersonalInfo = new HashSet<HeaPersonalInfo>();
            HeaPolicyHeader = new HashSet<HeaPolicyHeader>();
        }

        public int Id { get; set; }
        public string ClientName { get; set; }
        public string IdentityNo { get; set; }
        public string IdentityType { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string OffPhone { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string Contact { get; set; }
        public string ClientType { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<HeaCorporateInfo> HeaCorporateInfo { get; set; }
        public ICollection<HeaInsuredPersons> HeaInsuredPersons { get; set; }
        public ICollection<HeaPersonalInfo> HeaPersonalInfo { get; set; }
        public ICollection<HeaPolicyHeader> HeaPolicyHeader { get; set; }
    }
}
