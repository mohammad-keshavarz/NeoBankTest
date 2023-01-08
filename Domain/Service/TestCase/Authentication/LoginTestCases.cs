using Azure;
using Domain.Models;
using Domain.Models.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.TestCase.Authentication;

public static class LoginTestCases
{
	/*		 public async TestCaseDTO<LoginRequestDTO, LoginResponseDTO> loginTestCases() {
TestCaseDTO<LoginRequestDTO, LoginResponseDTO>[] loginTestCaseList;
loginTestCaseList[0]= new TestCaseDTO<>
}*/

	public static List<RequestDTO<dynamic, dynamic>> LoginTestList { get; } = new()
	{
		new RequestDTO<dynamic, dynamic> {
			TestCaseId = 123,
			ScenarioId = 7897,
			PBIId = 12,
			Uri = "authentication/login",

			ExpectedStatus = 200,
			Body = new {
				nationalCode= "0013013203",
				password = "Elh@m121169"
			},
			ExpectedResult = new
			{
                data = "null",
				message= "null",
				action= "Panel",
				succeeded= true,
				errors= "null"
			},
			ServiceType = RequestType.Post
		},

		new RequestDTO<dynamic, dynamic> {
			TestCaseId = 14119,
			ScenarioId = 0,
			PBIId = 14007,
			Uri = "authentication/login",

			ExpectedStatus = 200,
			Body = new {
				nationalCode= "0013013203",
				password = "Elh@m1211693"
			},
			ExpectedResult = new
			{
				data = "null",
				message= "null",
				action= "Panel",
				succeeded= true,
				errors= "null"
			},
			ServiceType = RequestType.Post
		},

		new RequestDTO<dynamic, dynamic> {
			TestCaseId = 14021,
			ScenarioId = 14117,
			PBIId = 14007,
			Uri = "authentication/login",

			ExpectedStatus = 200,
			Body = new {
				nationalCode= "001301320",
				password = "Elh@m1211693"
			},
			ExpectedResult = new
			{
				data = "null",
				message= "null",
				action= "Panel",
				succeeded= true,
				errors= "null"
			},
			ServiceType = RequestType.Post
		},



	};






}
