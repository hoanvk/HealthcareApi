using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaCorporateInfo
    {
        public int Id { get; set; }
        public int? ClientInfoId { get; set; }
        public string TaxNum { get; set; }
        public string CountryOrigin { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public HeaClients ClientInfo { get; set; }
    }
}
