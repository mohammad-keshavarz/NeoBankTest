using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DTO.Azure
{
    public class AzureRequestDTO<T>
    {
        public int? WorkItemId { get; set; }
        public string? Uri{ get; set; }
        public string? Organization{ get; set; }
        public string? ProjectId{ get; set; }
        public string? AccessToken{ get; set; }
        public RequestType ServiceType { get; set; }
        public IReadOnlyList<(string Key, string Value)>? HeaderParameters { get; set; }
        public T? Body { get; set; }

    }
}
