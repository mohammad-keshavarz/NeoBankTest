using Azure;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Web;

namespace Domain.Helper;

public class HttpProvider : IHttpProvider
{
	private readonly IHttpClientFactory httpClientFactory;
	private readonly ILogger<HttpProvider> logger;
	private readonly NeoBankContext context;
	public const string HttpClientIgnoreSsl = "HttpClientIgnoreSsl";

	public HttpProvider(IHttpClientFactory httpClientFactory, ILogger<HttpProvider> logger, NeoBankContext context)
	{
		this.httpClientFactory = httpClientFactory;
		this.logger = logger;
		this.context = context;
	}

	public async Task<ResponseDTO?> PostAsync<TBody>(HttpProviderRequest<TBody> request)
	{
		try
		{
			var client = httpClientFactory.CreateClient(HttpClientIgnoreSsl);

			client.BaseAddress = new Uri(request?.BaseAddress);
			if (request.HeaderParameters?.Any() == true)
			{
				for (var i = 0; i < request.HeaderParameters.Count; i++)
				{
					client.DefaultRequestHeaders.Add(request.HeaderParameters[i].Key, request.HeaderParameters[i].Value);
				}
			}

			HttpResponseMessage response;
			var serviceCallDate = DateTime.Now;
			if (typeof(TBody) == typeof(List<KeyValuePair<string, string>>))
			{
				using var req = new HttpRequestMessage(HttpMethod.Post, request.Uri) { Content = new FormUrlEncodedContent(request.Body as List<KeyValuePair<string, string>>) };
				response = await client.SendAsync(req);
			}
			else
			{
				response = typeof(TBody) == typeof(StringContent)
					? await client.PostAsync(request.Uri, request.Body as StringContent)
					: await client.PostAsJsonAsync(request.Uri, request.Body);
			}

			return new ResponseDTO
			{
				ResponseBody = await response.Content.ReadAsStringAsync(),
				ResponseStatus = (int)response.StatusCode,
				ResponseHeader = JsonSerializer.Serialize(response.Headers),
			};
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "PostAsync");
			return new ResponseDTO
			{
				ResponseBody = ex.Message,
				ResponseStatus = 500,
			};
		}
	}

	public async Task<ResponseDTO> GetAsync<TBody>(HttpProviderRequest<TBody> request)
	{
		try
		{
			var client = httpClientFactory.CreateClient(HttpClientIgnoreSsl);
			client.BaseAddress = new Uri(request?.BaseAddress);
			if (request.HeaderParameters?.Any() == true)
			{
				for (int i = 0; i < request.HeaderParameters.Count; i++)
				{
					client.DefaultRequestHeaders.Add(request.HeaderParameters[i].Key, request.HeaderParameters[i].Value);
				}
			}

			if (request.Body != null)
			{
				var properties = request.Body.GetType().GetProperties();
				var lst = properties.Select(x => x.Name + "=" + HttpUtility.UrlEncode(x.GetValue(request.Body, null)?.ToString())).ToArray();
				string queryParams = string.Join("&", lst);

				request.Uri += "?" + queryParams;
			}

			var response = await client.GetAsync(new Uri(request.Uri));

			//return await response.Content.ReadAsAsync<TResponse>();
			return new ResponseDTO
			{
				ResponseBody = await response.Content.ReadAsStringAsync(),
				ResponseStatus = (int)response.StatusCode,
				ResponseHeader = JsonSerializer.Serialize(response.Headers),
			};
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "GetAsync");

			throw;
		}
	}
}
