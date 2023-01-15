using Domain.Models;
using Domain.Models.Azure;
using Microsoft.EntityFrameworkCore;

namespace Domain.Helper;

public class NeoBankContext : DbContext
{
	public NeoBankContext(DbContextOptions<NeoBankContext> options)
		: base(options) { }


	// DataSets
	public DbSet<ServiceCallLog> ServiceCallLogs { get; set; }
	public DbSet<WorkItem> WorkItems{ get; set; }
}
