using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.TestDTO
{
    public class TestPlanResultDTO
    {
        public int? PassedCount { get; set; } = 0;
        public int? FailedCount { get; set; }= 0;
        public List<TestResultDTO>? PassedTestCases { get; set; } = new List<TestResultDTO>();
        public List<TestResultDTO>? FailedTestCases { get; set; }= new List<TestResultDTO>();
    }
}
