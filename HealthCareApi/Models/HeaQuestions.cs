using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaQuestions
    {
        public HeaQuestions()
        {
            HeaAnswers = new HashSet<HeaAnswers>();
        }

        public int Id { get; set; }
        public string Question { get; set; }
        public byte? TheOrder { get; set; }

        public ICollection<HeaAnswers> HeaAnswers { get; set; }
    }
}
