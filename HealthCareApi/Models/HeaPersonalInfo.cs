using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaPersonalInfo
    {
        public int Id { get; set; }
        public int? ClientInfoId { get; set; }
        public string Salutation { get; set; }
        public string Married { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string Position { get; set; }

        public HeaClients ClientInfo { get; set; }
    }
}
