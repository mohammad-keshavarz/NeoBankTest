using Domain.Models;

namespace Domain.Service.TestCase.Authentication;

public static class LoginTestCases
{
	/*		 public async TestCaseDTO<LoginRequestDTO, LoginResponseDTO> loginTestCases() {
TestCaseDTO<LoginRequestDTO, LoginResponseDTO>[] loginTestCaseList;
loginTestCaseList[0]= new TestCaseDTO<>
}*/

	public static List<RequestDTO<dynamic, dynamic>> LoginTestList { get; } = new()
	{
		new RequestDTO<dynamic, dynamic>
		{
			PBIId = 14007,
			ScenarioId =14117,
			TestCaseId = 14021,
			Uri = "authentication/login",

			ExpectedStatus = 200,
			ServiceType = RequestType.Post,
			Body = new
			{
				nationalCode = "001301320",
				password = "Elh@m121169"
			},
			ExpectedResult = new
			{
				data = "null",
				message = "null",
				action = "Panel",
				succeeded = true,
				errors = "null"
			},

		},

		new RequestDTO<dynamic, dynamic>
		{
			TestCaseId = 14022,
			ScenarioId = 14117,
			PBIId = 14007,
			Uri = "authentication/login",

			ExpectedStatus = 200,
			ServiceType = RequestType.Post,
			Body = new
			{
				nationalCode = "0013013203",
				password = "Elh@m1211693"
			},
			ExpectedResult = new
			{
				data = "null",
				message = "null",
				action = "Panel",
				succeeded = true,
				errors = "null"
			},

		},




		 new RequestDTO<dynamic, dynamic>
		{
			TestCaseId = 14023,
			ScenarioId = 14117,
			PBIId = 14007,
			Uri = "authentication/login",

			ExpectedStatus = 200,
			ServiceType = RequestType.Post,
			Body = new
			{
				nationalCode = "00130132033",
				password = "Elh@m1211693"
			},
			ExpectedResult = new
			{
				data = "null",
				message = "null",
				action = "Panel",
				succeeded = true,
				errors = "null"
			},

		},




		  new RequestDTO<dynamic, dynamic>
		{
			TestCaseId = 14024,
			ScenarioId = 14117,
			PBIId = 14007,
			Uri = "authentication/login",

			ExpectedStatus = 200,
			ServiceType = RequestType.Post,
			Body = new
			{
				nationalCode = "0013013203A",
				password = "Elh@m1211693"
			},
			ExpectedResult = new
			{
				data = "null",
				message = "null",
				action = "Panel",
				succeeded = true,
				errors = "null"
			},

		},






		   new RequestDTO<dynamic, dynamic>
		{
			TestCaseId = 14026,
			ScenarioId = 14117,
			PBIId = 14007,
			Uri = "authentication/login",

			ExpectedStatus = 200,
			ServiceType = RequestType.Post,
			Body = new
			{
				nationalCode = "001301320?3",
				password = "Elh@m1211693"
			},
			ExpectedResult = new
			{
				data = "null",
				message = "null",
				action = "Panel",
				succeeded = true,
				errors = "null"
			},

		},

			  new RequestDTO<dynamic, dynamic>
		{
			TestCaseId = 14027,
			ScenarioId = 14117,
			PBIId = 14007,
			Uri = "authentication/login",

			ExpectedStatus = 200,
			ServiceType = RequestType.Post,
			Body = new
			{
				nationalCode = "001301320 3",
				password = "Elh@m1211693"
			},
			ExpectedResult = new
			{
				data = "null",
				message = "null",
				action = "Panel",
				succeeded = true,
				errors = "null"
			},

		},


					new RequestDTO<dynamic, dynamic>
		{
			TestCaseId = 14318,
			ScenarioId = 14117,
			PBIId = 14007,
			Uri = "authentication/login",

			ExpectedStatus = 200,
			ServiceType = RequestType.Post,
			Body = new
			{
				nationalCode = "001301320 3",
				password = "Elh@m12   11693"
			},
			ExpectedResult = new
			{
				data = "null",
				message = "null",
				action = "Panel",
				succeeded = true,
				errors = "null"
			},

		},





		new RequestDTO<dynamic, dynamic>
		{
			TestCaseId = 14069,
			ScenarioId = 14117,
			PBIId = 14007,
			Uri = "authentication/login",

			ExpectedStatus = 400,
			Body = new
			{
				nationalCode = "1234567890",
				password = "Elh@m1211693"
			},
			ServiceType = RequestType.Post,
			ExpectedResult = new
			{
				data = "null",
				message = "null",
				action = "null",
				succeeded = false,
				errors = new[]
				{
					new {
						message = "مقدار وارد شده برای فیلد کد ملی معتبر نمی باشد",
						code = "null",
						reference = "NationalCode",
						info = "null",
						value = "null"
					},
				},
			},

		}
	};






}
