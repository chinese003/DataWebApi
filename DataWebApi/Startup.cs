using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataWebApi.Utility;
using EFCore.Oracle.MES;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DataWebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                options =>
                {
                    options.Filters.Add<ValidateModelAttribute>();
                    options.Filters.Add<ApiResultFilterAttribute>();
                    options.Filters.Add<CustomExceptionAttribute>();
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ////连接数据库
            ////1 配置连接字符串
            //var connStr = _configuration.GetConnectionString("OracleConnection");
            ////2 添加DbContext
            //services.AddDbContext<OracleDbContext>(
            //    options =>
            //    {
            //        options.EnableSensitiveDataLogging(true);//敏感数据记录
            //        options.UseSqlServer(connStr);
            //    }, ServiceLifetime.Transient);

            // 配置 CORS 授权策略
            services.AddCors(option =>
            {
                //添加一个名为 AllowAny 的策略
                option.AddPolicy("AllowAny", builder =>
                {
                    //配置跨域项
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                    builder.AllowCredentials();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // 允许跨域请求访问
            app.UseCors();

            app.UseMvc();
        }
    }
}
