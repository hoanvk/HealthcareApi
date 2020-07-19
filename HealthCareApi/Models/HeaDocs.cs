using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaDocs
    {
        public int Id { get; set; }
        public string PolicyNo { get; set; }
        public byte? DocType { get; set; }
        public string FileType { get; set; }
        public byte[] FileContent { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int? PolicyHeaderId { get; set; }
        public string FileName { get; set; }

        public HeaPolicyHeader PolicyHeader { get; set; }
    }
}
