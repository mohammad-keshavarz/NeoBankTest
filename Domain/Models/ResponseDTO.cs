using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class ResponseDTO
	{
		public int ResponseStatus { get; set; }
		public string ResponseHeader{ get; set; }
		public dynamic ResponseBody{ get; set; }

		public HttpWebResponse httpWebResponse { get; set; }
	}
}
