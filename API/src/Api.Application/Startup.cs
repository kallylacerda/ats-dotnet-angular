using System;
using Api.CrossCutting.DependencyInjection;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Application
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
      ConfigureService.ConfigureDependenciesService(services);
      ConfigureRepository.ConfigureDependenciesRepository(services);

      var config = new MapperConfiguration(cfg =>
      {
        cfg.AddProfile(new DtoToModelProfile());
        cfg.AddProfile(new EntityToDtoProfile());
        cfg.AddProfile(new ModelToEntityProfile());
      });

      IMapper mapper = config.CreateMapper();

      services.AddSingleton(mapper);

      services.AddCors();

      services.AddControllers();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "API ATS - AspNetCore 3.1",
          Description = "Arquitetura DDD",
          Contact = new OpenApiContact
          {
            Name = "Kallyl Lacerda",
            Email = "kallyl.lacerda@outlook.com",
            Url = new Uri("https://www.linkedin.com/in/kallyl-lacerda/")
          }
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

      app.UseSwagger();

      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API ATS - AspNetCore 3.1");
        c.RoutePrefix = string.Empty;
      });

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      if (Environment.GetEnvironmentVariable("APPLY_MIGRATIONS").ToLower() == "TRUE".ToLower())
      {
        using (var service = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                                                    .CreateScope())
        {
          using (var context = service.ServiceProvider.GetService<MyContext>())
          {
            context.Database.Migrate();
          }
        }
      }
    }
  }
}
