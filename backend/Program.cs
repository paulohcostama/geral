using RadConvenioAPI.Application.Interfaces;
using RadConvenioAPI.Application.Services;

var builder = WebApplication.CreateBuilder(args);

const string DevCorsPolicy = "RadDevCors";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICriptografiaService, CriptografiaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(DevCorsPolicy, policy =>
        policy.WithOrigins(
                "http://localhost:5173",
                "http://127.0.0.1:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(DevCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.MapGet("/health", () => Results.Ok(new { status = "ok", service = "RadConvenioAPI" }));

app.Run();
