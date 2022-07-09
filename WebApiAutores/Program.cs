using WebApiAutores;

var builder = WebApplication.CreateBuilder(args);

var starup = new Startup(builder.Configuration);
starup.ConfigurationServices(builder.Services);
var app = builder.Build();
starup.Configure(app, app.Environment);
app.Run();
