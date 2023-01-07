using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Authenticate
{
	public class LoginResponseDTO : ResponseDTO
	{
		public string Token{ get; set; }
	}
}