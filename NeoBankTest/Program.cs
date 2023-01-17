using Domain.Helper;
using Domain.Models;
using Domain.Models.Repository;
using Domain.Models.Authenticate;
using Domain.Service;
using Domain.Service.Azure;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<NeoBankContext>(options =>
{
	options.UseSqlServer(connectionString);
}, ServiceLifetime.Transient);

builder.Services.AddHttpClient();
builder.Services.AddScoped<NeoBankContext>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddTransient<IHttpProvider, HttpProvider>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient(typeof(IRequestService<,>), typeof(RequestService<,>));
builder.Services.AddTransient(typeof(IAzureRequestService<,>), typeof(AzureRequestService<,>));
builder.Services.AddTransient(typeof(IAzureService<,>), typeof(AzureService<,>));

builder.Services.AddHangfire(configuration => configuration
	.UseSimpleAssemblyNameTypeSerializer()
	.UseRecommendedSerializerSettings()
	.UseSqlServerStorage(builder.Configuration.GetConnectionString("AppDb")));

// Add the processing server as IHostedService
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHangfireDashboard();
app.MapHangfireDashboard();

//RecurringJob.AddOrUpdate<IBankService>(x => x.GetDepositBalance(), "*/2 * * * *");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
