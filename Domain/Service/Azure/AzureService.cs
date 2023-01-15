using Domain.Helper;
using Domain.Models.Azure;
using Domain.Models.DTO.Azure;
using Domain.Models.Enum;
using System.Text.Json;

namespace Domain.Service.Azure
{
    public interface IAzureService<T, U>
    {
        Task<dynamic> GetWorkItem(List<int> workItems);
    }

    public class AzureService<T, U> : IAzureService<T, U>
    {

        private readonly IHttpProvider httpProvider;
        private readonly NeoBankContext context;
        private readonly IAzureRequestService<T, U> azureRequestService;

        public AzureService(IHttpProvider httpProvider, NeoBankContext context, IAzureRequestService<T, U> azureRequestService)
        {
            this.httpProvider = httpProvider;
            this.context = context;
            this.azureRequestService = azureRequestService;
        }
        public async Task<dynamic> GetWorkItem(List<int> workItems)
        {
            try
            {
                var dbWorkItems = context.WorkItems.Where(i => workItems.Contains(i.WorkItemId));
                var dbWorkItemIds = new List<int>();
                foreach (var dbWorkItem in dbWorkItems)
                {
                    dbWorkItemIds.Add(dbWorkItem.WorkItemId);
                };
                var fetchedWorkItems = new List<WorkItem>();
                var newWorkItems = workItems.Except(dbWorkItemIds);
                foreach (var newWorkItem in newWorkItems)
                {
                    var request = new AzureRequestDTO<dynamic>()
                    {
                        AccessToken = Constant.AzureAccessToken,
                        Uri = Constant.AzureOrganization + "/" + Constant.AzureProject + "/_apis/wit/workitems/" + newWorkItem,
                        ServiceType = Models.RequestType.Get,

                    };
                    var response = await azureRequestService.Request(request);
                    if (response.ResponseStatus == 200 && response.ResponseBody != null)
                    {
                        WorkItemDTO responseBody = JsonSerializer.Deserialize<WorkItemDTO>(response.ResponseBody);
                        var fetchedWorkItem = new WorkItem()
                        {
                            WorkItemId = responseBody.id,
                            AreaPath = responseBody.fields.SystemAreaPath,
                            TeamProject = responseBody.fields.SystemTeamProject,
                            IterationPath = responseBody.fields.SystemIterationPath,
                            WorkItemCreatedDate = responseBody.fields.SystemCreatedDate,
                            CreatedBy = responseBody.fields.SystemCreatedBy.uniqueName,
                            Title = responseBody.fields.SystemTitle,
                        };
                        WorkItemTypes resultWorkItemTypeId = WorkItemTypes.Bug;
                        Enum.TryParse(responseBody.fields.SystemWorkItemType, true, out resultWorkItemTypeId);
                        fetchedWorkItem.WorkItemTypeId = resultWorkItemTypeId;

                        WorkItemState resultWorkItemState = WorkItemState.newWorkItem;
                        Enum.TryParse(responseBody.fields.SystemState, true, out resultWorkItemState);
                        fetchedWorkItem.StateId = resultWorkItemState;

                        await context.WorkItems.AddAsync(fetchedWorkItem);
                        await context.SaveChangesAsync();
                        fetchedWorkItems.Add(fetchedWorkItem);

                    }
                }
                //if (dbWorkItems == null) { return null; }
                return fetchedWorkItems;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
