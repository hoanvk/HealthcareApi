using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaUsers
    {
        public int Id { get; set; }
        public int? BranchId { get; set; }
        public string FullName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public HeaBranches Branch { get; set; }
    }
}
