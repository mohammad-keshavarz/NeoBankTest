using Domain.Models;
using Domain.Models.Authenticate;

namespace Domain.Helper;

public class HttpProviderRequest<T>
{
	public string BaseAddress { get; set; }
	public int? ScenarioId { get; set; }
	public int? PBIId { get; set; }
	public int? TestCaseId { get; set; }

	public string Uri { get; set; } = string.Empty;
	public RequestType ServiceType { get; set; }

	public IReadOnlyList<(string Key, string Value)> HeaderParameters { get; set; }

	public T? Body { get; set; }

	//public U? ExpectedResult { get; set; }

	//public int? ExpectedStatus { get; set; }

/*	public static implicit operator HttpProviderRequest<T, U>(HttpProviderRequest<LoginRequestDTO> v)
	{
		throw new NotImplementedException();
	}*/
}