using Microsoft.EntityFrameworkCore;
using UCSC.ASE.EbillService.EbillApplicationServices;
using UCSC.ASE.ReservationService.DatabaseModules;
using UCSC.ASE.ReservationService.ReservationApplicationService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IReservationApplicationService, ReservationApplicationService>();
builder.Services.AddScoped<IEbillApplicationService, EbillApplicationService>();

// Add db connection.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.MapGet("/", () => "Reservation Service Up And Running....");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
