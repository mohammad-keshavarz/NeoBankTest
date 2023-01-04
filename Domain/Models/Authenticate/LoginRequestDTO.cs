using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Authenticate
{
	public class LoginRequestDTO
	{
		public string NationalCode { get; set; }
		public string Password { get; set; }
	}
}
