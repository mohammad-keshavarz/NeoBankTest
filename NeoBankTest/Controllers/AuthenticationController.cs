using Domain.Helper;
using Domain.Models;
using Domain.Models.Azure;
using Domain.Models.TestDTO;
using Domain.Service;
using Domain.Service.Azure;
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
        private readonly IAzureService<dynamic, dynamic> _AzureService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IUserService userService, IRequestService<dynamic, dynamic> requestService, IAzureService<dynamic,dynamic> azureService)
        {
            _logger = logger;
            _userService = userService;
            _RequestService = requestService;
            _AzureService = azureService;

        }


        [HttpGet(Name = "automation/api/authentication/login")]
        public async Task<IActionResult> loginAutomate()
        {
            var testCases = LoginTestCases.LoginTestList;
            var testPlanResult = new TestPlanResultDTO();
            var testCaseIds = testCases.Select(i =>i.TestCaseId).ToList();
            var workItemIds= testCaseIds.Concat(testCases.Select(i =>i.PBIId)).ToList();
            List<WorkItem> workItems = await _AzureService.GetWorkItem(workItemIds);
            foreach (var testCase in testCases)
            {
                WorkItem workItem = workItems.Find(i => i.WorkItemId == testCase.TestCaseId);
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
                TestResultDTO res = await _RequestService.SendRequest(request);
                res.TestCaseTitle = workItem.Title;
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