using HelloSunshineSMSSYNRN_API.Data;
using HelloSunshineSMSSYNRN_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// ─── 1. Add Swagger Services Here ───
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register our custom Architecture
builder.Services.AddScoped<OracleRepository>();
builder.Services.AddScoped<ISmsSyncService, SmsSyncService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();