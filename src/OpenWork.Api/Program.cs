using OpenWork.Api.Configurations;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureDataAccess(true);
builder.ConfigureAuth();

builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddService();
builder.Services.ConfigureSwaggerAuthorize();

WebApplication app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
	_ = app.UseSwagger();
	_ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }