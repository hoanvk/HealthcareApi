using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaTrans
    {
        public decimal Id { get; set; }
        public string ReqTranNo { get; set; }
        public string ResTranNo { get; set; }
        public DateTime? TranDate { get; set; }
        public byte? Status { get; set; }
        public int? PolicyHeaderId { get; set; }

        public HeaPolicyHeader PolicyHeader { get; set; }
    }
}
