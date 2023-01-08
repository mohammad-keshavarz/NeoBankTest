using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.TestDTO
{
    public class UnexpectedResultDTO
    {
        public string Property { get; set; }
        public string ExpectedValue { get; set; }
        public string ActualValue { get; set; }
    }
}
