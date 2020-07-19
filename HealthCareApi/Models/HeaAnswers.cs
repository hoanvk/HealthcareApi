using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaAnswers
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public string Answer { get; set; }
        public int? PolicyRiskId { get; set; }

        public HeaInsuredPersons PolicyRisk { get; set; }
        public HeaQuestions Question { get; set; }
    }
}
