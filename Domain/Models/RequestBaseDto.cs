namespace Domain.Models;

public class RequestBaseDto
{
	public long CompanyId { get; set; }

	public string SwiftCode { get; set; }

	public Guid? TraceNumber { get; set; }

	public string DepositData { get; set; }

}
