using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareApi.Dtos
{
    public class ApiUser
    {
        public string publicKey { get; set; }
        public string secret { get; set; }
        public IList<ApiClaim> claims { get; set; }
    }
}
