using Microsoft.EntityFrameworkCore;

namespace WebApiAutores;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigurationServices(IServiceCollection services)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<ApplicatinDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("defaultConnection")));

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();
        app.UseEndpoints(endpoint =>
        {
            endpoint.MapControllers();
        });

    }


}