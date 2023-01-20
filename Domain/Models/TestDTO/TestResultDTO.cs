using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.TestDTO
{
    public class TestResultDTO
    {
        public int? TestCaseID { get; set; }
        public string? TestCaseTitle { get; set; }
        public int? PBIId { get; set; }
        public string? PBITitle { get; set; }
        public int? ScenarioId { get; set; }
        public bool IsSuccess { get; set; }
        public long TestDbId { get; set; }
        public TimeOnly Time { get; set; }
        public List<UnexpectedResultDTO>? WrongResults { get; set; }

    }
}
