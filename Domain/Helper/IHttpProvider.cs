using Domain.Models;
using System.Net;

namespace Domain.Helper;

public interface IHttpProvider
{
	Task<ResponseDTO?> PostAsync<TBody>(HttpProviderRequest<TBody> request);

	Task<ResponseDTO> GetAsync<TBody>(HttpProviderRequest<TBody> request);
}