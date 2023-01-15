using Domain.Helper;
using Domain.Models;
using Domain.Models.DTO.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Azure
{
    public interface IAzureRequestService<TBody, UExpectedResponse>
    {
        Task<ResponseDTO> Request(AzureRequestDTO<dynamic> request);
    }
    public class AzureRequestService<TRequest,UResponse>: IAzureRequestService<TRequest,UResponse>
    {
        private readonly IHttpProvider httpProvider;
        private readonly NeoBankContext context;

        public AzureRequestService(IHttpProvider httpProvider, NeoBankContext context)
        {
            this.httpProvider = httpProvider;
            this.context = context;
        }
        public async Task<ResponseDTO> Request(AzureRequestDTO<dynamic> request )
        {
            HttpProviderRequest<TRequest> azureRequest = new HttpProviderRequest<TRequest> { 
                BaseAddress = Constant.AzureURL,
                Uri = Constant.AzureURL + request.Uri,
                ServiceType = request.ServiceType,
                HeaderParameters = new List<(string Key, string Value)>() { 
                ("Authorization","Basic "+ Constant.AzureAccessToken)
                } ,
                Body = request.Body
            };
            ResponseDTO response = null;
                       switch (azureRequest.ServiceType)
            {
                case Models.RequestType.Post:
                    response = await httpProvider.PostAsync(azureRequest);
                    break;
                case Models.RequestType.Get:
                    response = await httpProvider.GetAsync(azureRequest);
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

            return response;
        }   
    }
}
