// ***********************************************************************
// Assembly         : EMR.Swagger
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="SwaggerDocumentFilter.cs" company="EMR.Swagger">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

/// <summary>
/// The Filters namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Swagger.Filters
{
    /// <summary>
    /// 对应Controller的API文档描述信息
    /// Implements the <see cref="Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter" />
    /// </summary>
    /// <seealso cref="Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter" />
    /// <remarks>Will Wu</remarks>
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// Applies the specified swagger document.
        /// </summary>
        /// <param name="swaggerDoc">The swagger document.</param>
        /// <param name="context">The context.</param>
        /// <remarks>Will Wu</remarks>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var tags = new List<OpenApiTag>
            {
                new OpenApiTag {
                    Name = "TeamBuildingInit",
                    Description = "初始化接口",
                    ExternalDocs = new OpenApiExternalDocs { Description = "包含：初始化Team/User/Charge" }
                },
                new OpenApiTag {
                    Name = "TeamBuilding",
                    Description = "TeamBuilding接口",
                    ExternalDocs = new OpenApiExternalDocs { Description = "包含：团队，人员，账单，充值，点赞，流水" }
                },
            };

            #region 实现添加自定义描述时过滤不属于同一个分组的API

            var groupName = context.ApiDescriptions.FirstOrDefault().GroupName;

            var apis = context.ApiDescriptions.GetType().GetField("_source", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(context.ApiDescriptions) as IEnumerable<ApiDescription>;

            var controllers = apis.Where(x => x.GroupName != groupName).Select(x => ((ControllerActionDescriptor)x.ActionDescriptor).ControllerName).Distinct();

            swaggerDoc.Tags = tags.Where(x => !controllers.Contains(x.Name)).OrderBy(x => x.Name).ToList();

            #endregion 实现添加自定义描述时过滤不属于同一个分组的API

            // 按照Name升序排序
            swaggerDoc.Tags = tags.OrderBy(x => x.Name).ToList();
        }
    }
}