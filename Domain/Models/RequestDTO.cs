using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class RequestDTO<T, U>
	{
		public string? BaseAddress { get; set; }
		public int? ScenarioId { get; set; }
		public int? PBIId { get; set; }
		public int? TestCaseId { get; set; }

		public string Uri { get; set; } = string.Empty;
		public RequestType ServiceType { get; set; }

		public IReadOnlyList<(string Key, string Value)> HeaderParameters { get; set; }

		public T? Body { get; set; }

		public U? ExpectedResult { get; set; }

		public int? ExpectedStatus { get; set; }
	}
}
