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
            ScenarioId = 0,
            TestCaseId = 14116,
            Uri = "authentication/login",

            ExpectedStatus = 200,
            ServiceType = RequestType.Post,
            Body = new
            {
                nationalCode = "0013013203",
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
            TestCaseId = 14119,
            ScenarioId = 0,
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
                action = "Panel1",
                succeeded = true,
                errors = "null"
            },
            
        },

        new RequestDTO<dynamic, dynamic>
        {
            TestCaseId = 1,
            ScenarioId = 1111,
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
