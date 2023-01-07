using Domain.Helper;
using Domain.Models;
using Domain.Models.Authenticate;
using Domain.Service;
using Domain.Service.TestCase;
using Domain.Service.TestCase.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace NeoBankTest.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class AuthenticationController : ControllerBase
	{
		private readonly ILogger<AuthenticationController> _logger;
		private readonly IUserService _userService;
		private readonly IRequestService<LoginRequestDTO, LoginResponseDTO> _RequestService;
		public AuthenticationController(ILogger<AuthenticationController> logger, IUserService userService, IRequestService<LoginRequestDTO, LoginResponseDTO> requestService)
		{
			_logger = logger;
			_userService = userService;
			_RequestService = requestService;
		}

		[HttpPost(Name = "login")]
		public async Task<IActionResult> login(LoginRequestDTO body)
		{
			var request = new RequestDTO<LoginRequestDTO,>
			{
				BaseAddress = Constant.URL,
				Body = body,
				ScenarioId = 1,
				PBIId = 14011,
				TestCaseId = 16782,
				Uri = "authentication/login",
				ServiceType = RequestType.Post,
				ExpectedResult = null,
				ExpectedStatus = 200,

			};

			var res = await _RequestService.SendRequest(request);
			return Ok(res);
		}

		[HttpGet(Name = "login/automate")]
		public async Task<IActionResult> loginAutomate()
		{
			var testCases = LoginTestCases.LoginTestList;

			foreach (var testCase in testCases)
			{
				var request = new RequestDTO<dynamic,dynamic>
				{
					BaseAddress = Constant.URL ?? Constant.URL,
					Body = testCase.Body,
					ScenarioId = testCase.ScenarioId,
					PBIId = testCase.PBIId,
					TestCaseId = testCase.TestCaseId,
					Uri = testCase.Uri,
					ServiceType = testCase.ServiceType,
					ExpectedResult = testCase.ExpectedResult,
					ExpectedStatus = testCase.ExpectedStatus,

				};
				var res = await _RequestService.SendRequest(request);
			}
			return Ok();

		}

	}
}