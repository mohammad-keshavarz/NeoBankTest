using Domain.Helper;
using Domain.Models;
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

		if (result != request.ExpectedResult)
		{
			await context.ServiceCallLogs.AddAsync(new ServiceCallLog
			{
				ServiceCallUrl = request.Uri,
				ScenarioId = request.ScenarioId,
				PBIId = request.PBIId,
				TestCaseId = request.TestCaseId,
				RequestBody = result.ResponseBody,
				ServiceCallDate = DateTime.Now,
				CreationUserId = 1,
				ExpectedResult = JsonConvert.SerializeObject(request),
				ExpectedStatus = request.ExpectedStatus ?? 0,
				ResponseBody = result.ResponseBody,
				ServiceCallStatus = result.ResponseStatus
			});
			await context.SaveChangesAsync();
		}

		return result;
	}
}

