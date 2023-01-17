using Domain.Models.Entity;
using Domain.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Azure;

[Table(nameof(WorkItem))]

public class WorkItem : EntityClass
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public int WorkItemId { get; set; }

    public string? AreaPath { get; set; }

    public string? TeamProject { get; set; }

    public string? IterationPath { get; set; }

    public WorkItemTypes WorkItemTypeId { get; set; }

    public WorkItemState StateId { get; set; }

    public DateTime? WorkItemCreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? Title { get; set; }

}

