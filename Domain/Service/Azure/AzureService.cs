using Domain.Helper;
using Domain.Models.Azure;
using Domain.Models.DTO.Azure;
using Domain.Models.Enum;
using Domain.Models.Repository;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Domain.Service.Azure
{
    public interface IAzureService<T, U>
    {
        Task<dynamic> GetWorkItem(List<int> workItems);
    }

    public class AzureService<T, U> : IAzureService<T, U>
    {
        private readonly IGenericRepository<WorkItem> workItemRepository;
        private readonly IAzureRequestService<T, U> azureRequestService;
        private readonly IUnitOfWork unitOfWork;

        public AzureService(IAzureRequestService<T, U> azureRequestService, IGenericRepository<WorkItem> workItemRepository, IUnitOfWork unitOfWork)
        {
            this.azureRequestService = azureRequestService;
            this.workItemRepository = workItemRepository;
            this.unitOfWork = unitOfWork;
        }

        private string RemoveSpace(string body)
        {
            return Regex.Replace(body, @"\s+", "");
        }

        public async Task<dynamic> GetWorkItem(List<int> workItems)
        {
            try
            {
                var dbWorkItems = await workItemRepository.Search(i => workItems.Contains(i.WorkItemId));
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
                        Enum.TryParse(RemoveSpace(responseBody.fields.SystemWorkItemType), true, out resultWorkItemTypeId);
                        fetchedWorkItem.WorkItemTypeId = resultWorkItemTypeId;

                        WorkItemState resultWorkItemState = WorkItemState.newWorkItem;
                        Enum.TryParse(RemoveSpace(responseBody.fields.SystemState), true, out resultWorkItemState);
                        fetchedWorkItem.StateId = resultWorkItemState;

                        //await context.WorkItems.AddAsync(fetchedWorkItem);
                        await workItemRepository.Add(fetchedWorkItem);
                        unitOfWork.Commit();
                        //await context.SaveChangesAsync();
                        fetchedWorkItems.Add(fetchedWorkItem);

                    }
                }
                
                return await workItemRepository.Search(i => workItems.Contains(i.WorkItemId));
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
