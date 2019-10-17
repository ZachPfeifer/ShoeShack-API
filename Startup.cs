using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BrandShack.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using ShoeShack.Repositories;
using ShoeShack.Services;

namespace ShoeShack
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      //Connection to DB
      services.AddScoped<IDbConnection>(x => CreateDbConnection());

      //Register Transient Services
      services.AddTransient<ShoesService>();
      services.AddTransient<ShoesRepository>();
      services.AddTransient<BrandsService>();
      services.AddTransient<BrandsRepository>();
      services.AddTransient<OrdersService>();
      services.AddTransient<OrdersRepository>();

    }

    private IDbConnection CreateDbConnection()
    {
      string connectionString = Configuration.GetSection("db").GetValue<string>("gearhost");
      return new MySqlConnection(connectionString);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
