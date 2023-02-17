using CityInfo.API;
using CityInfo.API.DbContexts;
using CityInfo.API.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Serilog;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// configure Serilog
//Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
//                                      .WriteTo.Console()
//                                      .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day)
//                                      .CreateLogger();
// tell asp core to use serilog , substituing build-in logger
//builder.Host.UseSerilog();

builder.Services.AddControllers(opt =>
{
    opt.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
  .AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

#if DEBUG
builder.Services.AddTransient<IMailService,LocalMailService>();
#else
builder.Services.AddTransient<IMailService,CloudMailService>();
#endif

builder.Services.AddSingleton<CitiesDataStore>();
builder.Services.AddDbContext<CityInfoContext>(
    dbContextOptions => dbContextOptions.UseSqlite(
        builder.Configuration["ConnectionStrings:CityInfoDBConnectionString"]
    )
);

builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// routing decision is made
app.UseRouting();

app.UseAuthorization();

// endpoint is executed
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.MapControllers();

app.Run();

// endpoint is executed
//app.UseEndpoints()

// routing decision is made
// app.UseRouting()

// met6, app.MapControllers() does both