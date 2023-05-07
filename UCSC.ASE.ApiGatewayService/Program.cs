using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//services cors
builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
});

builder.Configuration.AddJsonFile("GatewayRoutes.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

//app cors
app.UseCors("CORSPolicy");

app.UseAuthorization();

app.MapGet("/", () => "Api gateway up and running....");
app.MapControllers();
await app.UseOcelot();

app.Run();
