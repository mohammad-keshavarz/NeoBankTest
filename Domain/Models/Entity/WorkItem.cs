using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Domain.Models.Azure;

[Table(nameof(WorkItem))]

public class WorkItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string WorkItemId { get; set; }
    
    public string? AreaPath { get; set; }

    public string? TeamProject { get; set; }

    public string? IterationPath { get; set; }

    public int WorkItemTypeId { get; set; }

    public WorkItemState StateId { get; set; }


    public DateTime? WorkItemCreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? Title { get; set; }

}

