using Domain.Helper;
using Domain.Service;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<NeoBankContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddHttpClient();
builder.Services.AddScoped<IHttpProvider, HttpProvider>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped(typeof(IRequestService<>), typeof(RequestService <>));

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
