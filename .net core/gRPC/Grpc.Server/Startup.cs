using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Grpc.Message;

namespace Grpc.Server
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
            services.AddSingleton<PersonaService.PersonaServiceBase, PersonaServer>();
            services.AddSingleton<SkillService.SkillServiceBase, SkillServer>();
            var server = services.BuildServiceProvider();
            services.AddSingleton(
                 new GrpcServer("0.0.0.0", 50051,
                  PersonaService.BindService(server.GetRequiredService<PersonaService.PersonaServiceBase>()),
                  SkillService.BindService(server.GetRequiredService<SkillService.SkillServiceBase>())
                 ));

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 全局错误处理

            //app.Run(async (context) =>
            //{
            //    //await context.Response.WriteAsync("Server start");
            //});
        }
    }
}
