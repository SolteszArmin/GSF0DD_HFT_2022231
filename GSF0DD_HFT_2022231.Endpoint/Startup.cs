
using GSF0DD_HFT_2022231.Logic.Classes;
using GSF0DD_HFT_2022231.Logic.Interface;
using GSF0DD_HFT_2022231.Models;
using GSF0DD_HFT_2022231.Repository.Data;
using GSF0DD_HFT_2022231.Repository.Interface;
using GSF0DD_HFT_2022231.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSF0DD_HFT_2022231.Endpoint
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<GameListDbContext>();

            services.AddTransient<IRepository<Publisher>, PublisherRepository>();
            services.AddTransient<IRepository<Genre>, GenreRepository>();
            services.AddTransient<IRepository<Game>, GameRepository>();

            services.AddTransient<ILogic<Publisher>, PublisherLogic>();
            services.AddTransient<ILogic<Genre>, GenreLogic>();
            services.AddTransient<IGameLogic<Game>, GameLogic>();

            services.AddControllers();

            services.AddSwaggerGen(t =>
            {
                t.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "GSF0DD_HFT_2022231.Endpoint",
                    Version = "v1",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(t => t.SwaggerEndpoint("/swagger/v1/swagger.json", "GSF0DD_HFT_2022231.Endpoint v1"));
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
