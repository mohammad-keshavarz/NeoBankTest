using System.Text.Json.Serialization;

namespace Domain.Models.Azure
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Avatar
    {
        [JsonPropertyName("href")]
        public string href { get; set; }
    }

    public class Fields
    {
        [JsonPropertyName("System.AreaPath")]
        public string SystemAreaPath { get; set; }

        [JsonPropertyName("System.TeamProject")]
        public string SystemTeamProject { get; set; }

        [JsonPropertyName("System.IterationPath")]
        public string SystemIterationPath { get; set; }

        [JsonPropertyName("System.WorkItemType")]
        public string SystemWorkItemType { get; set; }

        [JsonPropertyName("System.State")]
        public string SystemState { get; set; }

        [JsonPropertyName("System.Reason")]
        public string SystemReason { get; set; }

        [JsonPropertyName("System.CreatedDate")]
        public DateTime SystemCreatedDate { get; set; }

        [JsonPropertyName("System.CreatedBy")]
        public SystemCreatedBy SystemCreatedBy { get; set; }

        [JsonPropertyName("System.ChangedDate")]
        public DateTime SystemChangedDate { get; set; }

        [JsonPropertyName("System.ChangedBy")]
        public SystemChangedBy SystemChangedBy { get; set; }

        [JsonPropertyName("System.CommentCount")]
        public int SystemCommentCount { get; set; }

        [JsonPropertyName("System.Title")]
        public string SystemTitle { get; set; }

        [JsonPropertyName("System.BoardColumn")]
        public string SystemBoardColumn { get; set; }

        [JsonPropertyName("System.BoardColumnDone")]
        public bool SystemBoardColumnDone { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Scheduling.StoryPoints")]
        public double MicrosoftVSTSSchedulingStoryPoints { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Common.StateChangeDate")]
        public DateTime MicrosoftVSTSCommonStateChangeDate { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Common.ActivatedDate")]
        public DateTime MicrosoftVSTSCommonActivatedDate { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Common.ActivatedBy")]
        public MicrosoftVSTSCommonActivatedBy MicrosoftVSTSCommonActivatedBy { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Common.ClosedDate")]
        public DateTime MicrosoftVSTSCommonClosedDate { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Common.ClosedBy")]
        public MicrosoftVSTSCommonClosedBy MicrosoftVSTSCommonClosedBy { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Common.Priority")]
        public int MicrosoftVSTSCommonPriority { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Common.ValueArea")]
        public string MicrosoftVSTSCommonValueArea { get; set; }

        [JsonPropertyName("Microsoft.VSTS.Common.BacklogPriority")]
        public double MicrosoftVSTSCommonBacklogPriority { get; set; }

        [JsonPropertyName("WEF_B682D08F66AA48AC9E9A28DFB3A19878_Kanban.Column")]
        public string WEF_B682D08F66AA48AC9E9A28DFB3A19878_KanbanColumn { get; set; }

        [JsonPropertyName("WEF_B682D08F66AA48AC9E9A28DFB3A19878_Kanban.Column.Done")]
        public bool WEF_B682D08F66AA48AC9E9A28DFB3A19878_KanbanColumnDone { get; set; }

        [JsonPropertyName("System.Description")]
        public string SystemDescription { get; set; }

        [JsonPropertyName("Custom.UIPrototype")]
        public string CustomUIPrototype { get; set; }

        [JsonPropertyName("Custom.Viewes")]
        public string CustomViewes { get; set; }

        [JsonPropertyName("Custom.Services")]
        public string CustomServices { get; set; }

        [JsonPropertyName("href")]
        public string href { get; set; }
    }

    public class Html
    {
        [JsonPropertyName("href")]
        public string href { get; set; }
    }

    public class Links
    {
        [JsonPropertyName("avatar")]
        public Avatar avatar { get; set; }

        [JsonPropertyName("self")]
        public Self self { get; set; }

        [JsonPropertyName("workItemUpdates")]
        public WorkItemUpdates workItemUpdates { get; set; }

        [JsonPropertyName("workItemRevisions")]
        public WorkItemRevisions workItemRevisions { get; set; }

        [JsonPropertyName("workItemComments")]
        public WorkItemComments workItemComments { get; set; }

        [JsonPropertyName("html")]
        public Html html { get; set; }

        [JsonPropertyName("workItemType")]
        public WorkItemType workItemType { get; set; }

        [JsonPropertyName("fields")]
        public Fields fields { get; set; }
    }

    public class MicrosoftVSTSCommonActivatedBy
    {
        [JsonPropertyName("displayName")]
        public string displayName { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }

        [JsonPropertyName("_links")]
        public Links _links { get; set; }

        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("uniqueName")]
        public string uniqueName { get; set; }

        [JsonPropertyName("imageUrl")]
        public string imageUrl { get; set; }

        [JsonPropertyName("descriptor")]
        public string descriptor { get; set; }
    }

    public class MicrosoftVSTSCommonClosedBy
    {
        [JsonPropertyName("displayName")]
        public string displayName { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }

        [JsonPropertyName("_links")]
        public Links _links { get; set; }

        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("uniqueName")]
        public string uniqueName { get; set; }

        [JsonPropertyName("imageUrl")]
        public string imageUrl { get; set; }

        [JsonPropertyName("descriptor")]
        public string descriptor { get; set; }
    }

    public class WorkItemDTO
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("rev")]
        public int rev { get; set; }

        [JsonPropertyName("fields")]
        public Fields fields { get; set; }

        [JsonPropertyName("_links")]
        public Links _links { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }
    }

    public class Self
    {
        [JsonPropertyName("href")]
        public string href { get; set; }
    }

    public class SystemChangedBy
    {
        [JsonPropertyName("displayName")]
        public string displayName { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }

        [JsonPropertyName("_links")]
        public Links _links { get; set; }

        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("uniqueName")]
        public string uniqueName { get; set; }

        [JsonPropertyName("imageUrl")]
        public string imageUrl { get; set; }

        [JsonPropertyName("descriptor")]
        public string descriptor { get; set; }
    }

    public class SystemCreatedBy
    {
        [JsonPropertyName("displayName")]
        public string displayName { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }

        [JsonPropertyName("_links")]
        public Links _links { get; set; }

        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("uniqueName")]
        public string uniqueName { get; set; }

        [JsonPropertyName("imageUrl")]
        public string imageUrl { get; set; }

        [JsonPropertyName("descriptor")]
        public string descriptor { get; set; }
    }

    public class WorkItemComments
    {
        [JsonPropertyName("href")]
        public string href { get; set; }
    }

    public class WorkItemRevisions
    {
        [JsonPropertyName("href")]
        public string href { get; set; }
    }

    public class WorkItemType
    {
        [JsonPropertyName("href")]
        public string href { get; set; }
    }

    public class WorkItemUpdates
    {
        [JsonPropertyName("href")]
        public string href { get; set; }
    }


}
