//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Swagger
// FileName : WQHBlogSwaggerExtensions
//
// Created by : Will.Wu at 2020/7/29 15:52:20
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.IO;

using EMR.Domain.Configurations;
using EMR.Swagger.Filters;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerUI;

using static EMR.Domain.Shared.EMRConsts;

namespace EMR.Swagger
{
    public static class EMRSwaggerExtensions
    {
        /// <summary>
        /// 当前API版本，从appsettings.json获取
        /// </summary>
        private static readonly string version = $"v{AppSettings.ApiVersion}";

        /// <summary>
        /// Swagger描述信息
        /// </summary>
        private static readonly string description = @"<b>Blog</b><code>Powered by .NET Core 3.1 on Windows 10 Pro</code>";

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                //options.SwaggerDoc("v1", new OpenApiInfo
                //{
                //    Version = "1.0.0",
                //    Title = "接口",
                //    Description = "接口描述"
                //});
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerDoc(x.UrlPrefix, x.OpenApiInfo);
                });
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "EMR.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "EMR.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "EMR.Application.Contracts.xml"));

                //#region 小绿锁，JWT身份认证配置

                //var security = new OpenApiSecurityScheme
                //{
                //    Description = "JWT模式授权，请输入 Bearer {Token} 进行身份验证",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey
                //};
                //options.AddSecurityDefinition("oauth2", security);
                //options.AddSecurityRequirement(new OpenApiSecurityRequirement { { security, new List<string>() } });
                //options.OperationFilter<AddResponseHeadersFilter>();
                //options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //options.OperationFilter<SecurityRequirementsOperationFilter>();

                //#endregion 小绿锁，JWT身份认证配置

                options.DocumentFilter<SwaggerDocumentFilter>();
            });
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(options =>
            {
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerEndpoint($"/swagger/{x.UrlPrefix}/swagger.json", x.Name);
                });
                // 模型的默认扩展深度，设置为 -1 完全隐藏模型
                options.DefaultModelsExpandDepth(-1);
                // API文档仅展开标记
                options.DocExpansion(DocExpansion.List);
                // API前缀设置为空
                options.RoutePrefix = string.Empty;
                // API页面Title
                options.DocumentTitle = "接口文档 - WQH";
                //options.SwaggerEndpoint($"/swagger/v1/swagger.json", "默认接口");
            });
        }

        /// <summary>
        /// Swagger分组信息，将进行遍历使用
        /// </summary>
        private static readonly List<SwaggerApiInfo> ApiInfos = new List<SwaggerApiInfo>()
        {
             new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_v1,
                Name = "博客前台接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "WQH - 博客前台接口",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_v2,
                Name = "博客后台接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "WQH - 博客后台接口",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_v3,
                Name = "通用公共接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "WQH - 通用公共接口",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_v4,
                Name = "JWT授权接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "WQH - JWT授权接口",
                    Description = description
                }
            }
        };

        internal class SwaggerApiInfo
        {
            /// <summary>
            /// URL前缀
            /// </summary>
            public string UrlPrefix { get; set; }

            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// <see cref="Microsoft.OpenApi.Models.OpenApiInfo" />
            /// </summary>
            public OpenApiInfo OpenApiInfo { get; set; }
        }
    }
}