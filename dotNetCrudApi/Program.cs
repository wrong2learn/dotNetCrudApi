using dotNetCrudApi.StartupConfig;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

app.ConfigureSwagger();
app.UseAuthorization();
app.MapControllers();

app.Run();
