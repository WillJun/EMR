using System.Linq;
using EMR.EntityFrameworkCore;
using EMR.HttpApi.Hosting.Filters;
using EMR.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace EMR.HttpApi.Hosting
{
    [DependsOn(
typeof(AbpAspNetCoreMvcModule),
typeof(AbpAutofacModule), typeof(EMRSwaggerModule), typeof(EMRHttpApiModule),
       typeof(EMRFrameworkCoreModule)
)]
    public class EMRHttpApiHostingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<MvcOptions>(options =>
            {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

                // 移除 AbpExceptionFilter
                options.Filters.Remove(filterMetadata);
                // 添加自己实现的 EMRExceptionFilter
                options.Filters.Add(typeof(EMRExceptionFilter));
            });

            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            // 认证授权
            context.Services.AddAuthorization();

            // Http请求
            context.Services.AddHttpClient();
            //base.ConfigureServices(context);

            context.Services.AddRouting(options =>
            {
                // 设置URL为小写
                //options.LowercaseUrls = true;
                // 在生成的URL后面添加斜杠
                options.AppendTrailingSlash = true;
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }

            // 路由
            app.UseRouting();
            //严格传输安全头
            app.UseHsts();
            // 跨域
            app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            //HTTP请求转HTTPS。
            app.UseHttpsRedirection();
            // 身份验证
            app.UseAuthentication();

            // 认证授权
            app.UseAuthorization();

            // 异常处理中间件
            //app.UseMiddleware<ExceptionHandlerMiddleware>();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}