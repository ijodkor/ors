using Microsoft.EntityFrameworkCore;
using ORS.Apps;
using ORS.apps.MobileOperators;
using ORS.Apps.Regions;
using ORS.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DI services
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<RegionService>();
builder.Services.AddScoped<OperatorService>();

// Cors
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.SetIsOriginAllowed(AllowedCors)));

// Register controllers
builder.Services.AddControllers();

// Enable Swagger annatations
builder.Services.AddSwaggerGen(options => { options.EnableAnnotations(); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ORS V1");
        // Set Swagger UI at the app's root
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseCors();

// Mapping
app.MapGet("/ping", new App().Ping)
    .WithName("Tizim haqida")
    .WithOpenApi()
    .WithTags("Author");

// Use controller
app.MapControllers();
app.Run();
return;

bool AllowedCors(string origin) {
    return new Uri(origin).Host == "localhost"
           || new Uri(origin).Host == "127.0.0.1"
           || new Uri(origin).Host.StartsWith("192.168.1.")
           || origin.EndsWith(".uz");
}