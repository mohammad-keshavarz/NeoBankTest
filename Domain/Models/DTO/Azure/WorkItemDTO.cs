using Newtonsoft.Json;

namespace Domain.Models.Azure
{
    internal class WorkItemDTO
    {

        public long Id { get; set; }

        [JsonProperty("id")]
        public string WorkItemId { get; set; }

        [JsonProperty("System.AreaPath")]
        public string? AreaPath { get; set; }

        [JsonProperty("System.TeamProject")]
        public string? TeamProject { get; set; }

        [JsonProperty("System.IterationPath")]
        public string? IterationPath { get; set; }

        [JsonProperty("System.WorkItemType")]
        public int WorkItemTypeId { get; set; }

        [JsonProperty("System.State")]
        public int StateId { get; set; }


        [JsonProperty("System.CreatedDate")]
        public DateTime? WorkItemCreatedDate { get; set; }

        [JsonProperty("System.CreatedBy.uniqueName")]
        public string? CreatedBy { get; set; }

        [JsonProperty("System.Title")]
        public string? Title { get; set; }



    }
}
