using System.ComponentModel.DataAnnotations;

namespace Domain.Helper;

public enum TransactionStatus
{
	None,
	[Display(Name = "موفقیت آمیز")]
	Success = 1,

	[Display(Name = "ناموفق")]
	Failed = 2,

	[Display(Name = "ناشناخته")]
	Unknown = 3,
}