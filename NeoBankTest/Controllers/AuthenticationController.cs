using Domain.Helper;
using Domain.Models;
using Domain.Models.TestDTO;
using Domain.Service;
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
        private readonly IRequestService<dynamic, dynamic> _RequestService;
        public AuthenticationController(ILogger<AuthenticationController> logger, IUserService userService, IRequestService<dynamic, dynamic> requestService)
        {
            _logger = logger;
            _userService = userService;
            _RequestService = requestService;
        }


        [HttpGet(Name = "automation/api/authentication/login")]
        public async Task<IActionResult> loginAutomate()
        {
            var testCases = LoginTestCases.LoginTestList;
            var testPlanResult = new TestPlanResultDTO();
            foreach (var testCase in testCases)
            {
                var request = new RequestDTO<dynamic, dynamic>
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
                if (res.IsSuccess == true)
                {
                    testPlanResult.PassedTestCases!.Add(res);
                }
                else {
                    testPlanResult.FailedTestCases!.Add(res);
                }
            }
            testPlanResult.PassedCount = testPlanResult.PassedTestCases.Count();
            testPlanResult.FailedCount = testPlanResult.FailedTestCases.Count();
        
            return Ok(testPlanResult);

        }
        /*[HttpGet(Name = "automation/api/register/re")]
		public async Task<IActionResult> registerAutomate()
		{
			var testCases = LoginTestCases.LoginTestList;


			return Ok();

		}*/

    }
}