using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaSettings
    {
        public int Id { get; set; }
        public string ItemKey { get; set; }
        public string ItemValue { get; set; }
        public string ItemTable { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
