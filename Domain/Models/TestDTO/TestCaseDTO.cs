using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.Authenticate;

namespace Domain.Models.TestDTO
{
    public class TestCaseDTO<T, U>
    {
        public int? ScenarioId { get; set; }
        public int? PBIId { get; set; }
        public int? TestCaseId { get; set; }
        public string Uri { get; set; }
        public U ExpectedResult { get; set; }
        public int? ExpectedStatus { get; set; }
        public T? Body { get; set; }

        public int? ServiceType { get; set; }
    }
}
