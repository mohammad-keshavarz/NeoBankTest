using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoBankTest.Helper;
using NeoBankTest.Models;
using NeoBankTest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoBankTest.Service.Tests
{
	[TestClass()]
	public class UserServiceTests
	{

		[SetUp]
		public void Setup()
		{
			_httpProvider = new Mock<IHttpProvider>();
			_userService = new UserService(_httpProvider);
		}


		[TestMethod()]
		public void LoginTest()
		{
			var request = new PasargadRequestDto();
			var requestBody = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("nationalCode","0063429764"),
				new KeyValuePair<string, string>("captcha", ""),
			};

			var response = _userService.Login(request, requestBody);

			Assert.IsTrue(response);
		}
    }
}