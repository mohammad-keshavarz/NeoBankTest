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
			Uri = "autentication/login",

			ExpectedStatus = 200,
			Body = new {
				NationalCode= "0013013203",
				Password = "Elh@m121169"
			},
			ExpectedResult = new {
				Token=""
			},
			ServiceType = RequestType.Post
		},
	};






	/*public TestCaseDTO<LoginRequestDTO, LoginResponseDTO> testCaseLogin(TestCaseDTO<LoginRequestDTO, LoginResponseDTO> test)
	{

		LoginRequestDTO body = new LoginRequestDTO()
		{
			NationalCode = "0013013203",
			Password = "Elh@m121169"
		};
		LoginResponseDTO response = new LoginResponseDTO()
		{

		};


		RequestDTO<LoginRequestDTO, ResponseDTO> requestDTO = new()
		{
			TestCaseId = 123,
			ScenarioId = 7897,
			PBIId = 12,
			Uri = "autentication/login",
			ExpectedResult = { 
				ResponseHeader  
			},
			ExpectedStatus = 200,
			Body = body,
			ServiceType = RequestType.Post
		};


		test.TestCaseId = 123;
		test.ScenarioId = 7897;
		test.PBIId = 12;
		test.Uri = "autentication/login";
		test.ExpectedResult = response;
		test.ExpectedStatus = 200;
		test.Body = body;
		test.ServiceType = 200;


		return test;
	}*/
}
