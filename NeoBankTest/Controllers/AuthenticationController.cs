using Domain.Helper;
using Domain.Models;
using Domain.Models.Authenticate;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace NeoBankTest.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class AuthenticationController : ControllerBase
	{
		private readonly ILogger<AuthenticationController> _logger;
		private readonly IUserService _userService;
		private readonly IRequestService<LoginRequestDTO> _RequestService;
		public AuthenticationController(ILogger<AuthenticationController> logger, IUserService userService, IRequestService<LoginRequestDTO> requestService)
		{
			_logger = logger;
			_userService = userService;
			_RequestService = requestService;
		}

		[HttpPost(Name = "login")]
		public async Task<IActionResult> login(LoginRequestDTO body)
		{
			var request = new HttpProviderRequest<LoginRequestDTO>
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

	}
}