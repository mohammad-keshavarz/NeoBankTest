using Domain.Helper;
using Domain.Models;
using Domain.Models.TestDTO;
using Dynamitey;
using Newtonsoft.Json;

namespace Domain.Service;


public interface IRequestService<TBody, UExpectedResponse>
{
    Task<ResponseDTO> SendRequest(RequestDTO<TBody, UExpectedResponse> request);
}


public class RequestService<TBody, UExpectedResponse> : IRequestService<TBody, UExpectedResponse>
{
    private readonly IHttpProvider httpProvider;
    private readonly NeoBankContext context;

    public RequestService(IHttpProvider httpProvider, NeoBankContext context)
    {
        this.httpProvider = httpProvider;
        this.context = context;
    }

    public async Task<ResponseDTO> SendRequest(RequestDTO<TBody, UExpectedResponse> request)
    {
        HttpProviderRequest<TBody> httpRequest = new HttpProviderRequest<TBody>
        {
            BaseAddress = request.BaseAddress ?? Constant.URL,
            ScenarioId = request.ScenarioId,
            PBIId = request.PBIId,
            TestCaseId = request.TestCaseId,
            Uri = request.Uri,
            ServiceType = request.ServiceType,
            HeaderParameters = request.HeaderParameters,
            Body = request.Body
        };


        ResponseDTO result = null;
        switch (request.ServiceType)
        {
            case Models.RequestType.Post:
                result = await httpProvider.PostAsync(httpRequest);
                break;
            case Models.RequestType.Get:
                break;
            case Models.RequestType.Patch:
                break;
            case Models.RequestType.Delete:
                break;
            case Models.RequestType.Update:
                break;
            case Models.RequestType.Put:
                break;
        }
        var responseBody = "";
        var wrongResults = "";
        var isSuccess = true;
        var unexpectedResultList = new List<UnexpectedResultDTO>();
        if (result != null)
        {
            responseBody = result.ResponseBody.ToString();
            unexpectedResultList = compareObjects(request.ExpectedResult, responseBody);



            if (unexpectedResultList.Count > 0 || result.ResponseStatus != request.ExpectedStatus)
            {
/*                foreach (string unexpectedResult in unexpectedResultList)
                {
                    wrongResults += unexpectedResult;
                }*/
                if (result.ResponseStatus != request.ExpectedStatus)
                {
                    unexpectedResultList.Add(
                        new UnexpectedResultDTO { Property = "RequestStatus",
                         ActualValue= request.ExpectedStatus.ToString() ,
                         ExpectedValue= result.ResponseStatus.ToString() ,
                        }
                        );;
                     //wrongResults += " { \"prop\" : \"" + "requestStatus" + "\", \"expectedValue\" : \"" + request.ExpectedStatus + "\", \"actualValue\" : \"" + result.ResponseStatus + "\" },";

                }
                isSuccess = false;
            }
        }
        else
        {
            wrongResults = "no response";
            isSuccess = false;

        }
        {
            await context.ServiceCallLogs.AddAsync(new ServiceCallLog
            {
                ServiceCallUrl = request.Uri,
                ScenarioId = request.ScenarioId,
                PBIId = request.PBIId,
                TestCaseId = request.TestCaseId,
                RequestBody = JsonConvert.SerializeObject(request.Body),
                ServiceCallDate = DateTime.Now,
                CreationUserId = 1,
                ExpectedResult = JsonConvert.SerializeObject(request.ExpectedResult),
                ExpectedStatus = request.ExpectedStatus ?? 0,
                //ResponseBody = result.ResponseBody,
                ServiceCallStatus = result.ResponseStatus,
                WronResult = JsonConvert.SerializeObject(unexpectedResultList),
                isSuccess = isSuccess,
                CreationDate= DateTime.Now,
            });
            await context.SaveChangesAsync();
        }


        return result;
    }

    List<UnexpectedResultDTO?> compareObjects(object expectedResponse, string response)
    {
        dynamic d = JsonConvert.DeserializeObject<dynamic>(response);

        IEnumerable<string> list1 = Dynamic.GetMemberNames(expectedResponse);
        var expectedList = list1.OrderBy(m => m);
        if (response == null || response == "")
        {
            var responseList = new List<string?>();
        }
        else
        {
            IEnumerable<string> list2 = Dynamic.GetMemberNames(d);
            var responseLIst = list2.OrderBy(m => m);

        }

        var unexpectedResultList = new List<UnexpectedResultDTO?>();
        foreach (var expected in expectedList)
        {
            var expectedProperty = JsonConvert.SerializeObject(expectedResponse.GetType().GetProperty(expected).GetValue(expectedResponse)).ToLower().Replace("\"", " ").Replace(" ", "");
            var targetProperty = "";
            if (response != "")
            {
                targetProperty = JsonConvert.SerializeObject(d[expected.ToString()]).ToLower().Replace("\"", " ").Replace(" ", "");
            }

            if (targetProperty != expectedProperty)
            {
                unexpectedResultList.Add(new UnexpectedResultDTO
                {
                    Property = expected,
                    ActualValue= targetProperty,
                    ExpectedValue= expectedProperty
                });

            }

        }
        return unexpectedResultList;

    }
}

