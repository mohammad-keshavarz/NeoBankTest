using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Models;


[Table(nameof(ServiceCallLog))]
public class ServiceCallLog
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public long Id { get; set; }

	[StringLength(500)]
	public string? ServiceCallUrl { get; set; }
	public int? ScenarioId { get; set; }
	public int? PBIId { get; set; }
	public int? TestCaseId { get; set; }

	public DateTime ServiceCallDate { get; set; }

	public string? RequestBody { get; set; }

	public int? ServiceCallStatus { get; set; }

	public string? ResponseBody { get; set; }

	public bool isSuccess { get; set; }

	public string? ExpectedResult { get; set; }
	
	public int ExpectedStatus { get; set; }
	public string? WronResult { get; set; }

	[StringLength(25)]
	public string? ErrorCode { get; set; }

	[StringLength(150)]
	public string? ErrorType { get; set; }

	public DateTime CreationDate { get; set; }

	public int CreationUserId { get; set; }

	public void Configure(EntityTypeBuilder<ServiceCallLog> builder)
	{

	}
}