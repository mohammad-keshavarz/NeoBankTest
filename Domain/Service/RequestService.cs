using Domain.Helper;
using Domain.Models;

namespace Domain.Service;


public interface IRequestService<T>
{
	Task<ResponseDTO> SendRequest(HttpProviderRequest<T> request);
}


public class RequestService<TBody> : IRequestService<TBody>
{
	private readonly IHttpProvider httpProvider;
	private readonly NeoBankContext context;

	public RequestService(IHttpProvider httpProvider, NeoBankContext context)
	{
		this.httpProvider = httpProvider;
		this.context = context;
	}


	public async Task<ResponseDTO> SendRequest(HttpProviderRequest<TBody> request)
	{
		request.BaseAddress = request.BaseAddress ?? Constant.URL;
		request.ScenarioId = request.ScenarioId;
		request.PBIId = request.PBIId;
		request.TestCaseId = request.TestCaseId;
		request.Uri = request.Uri;
		request.ServiceType = request.ServiceType;
		request.HeaderParameters = request.HeaderParameters;
		request.Body = request.Body;
		request.ExpectedResult = request.ExpectedResult;
		request.ExpectedStatus = request.ExpectedStatus;


		ResponseDTO result = null;
		switch (request.ServiceType)
		{
			case Models.RequestType.Post:
				result = await httpProvider.PostAsync(request);
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

		await context.ServiceCallLogs.AddAsync(new ServiceCallLog
		{
			ServiceCallUrl = request.Uri,
			ScenarioId = request.ScenarioId,
			PBIId = request.PBIId,
			TestCaseId = request.TestCaseId,
			RequestBody = result.ResponseBody,
			ServiceCallDate = DateTime.Now,
			CreationUserId = 1,
			ExpectedResult = request.ExpectedResult,
			ExpectedStatus = request.ExpectedStatus,
			ResponseBody= result.ResponseBody,
			ServiceCallStatus=result.ResponseStatus
		});
		await context.SaveChangesAsync();



		return await Task.FromResult(result);
	}
}