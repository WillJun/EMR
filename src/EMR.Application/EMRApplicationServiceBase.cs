// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="EMRApplicationServiceBase.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Volo.Abp.Application.Services;

/// <summary>
/// The Application namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Application
{
    /// <summary>
    /// Class ServiceBase.
    /// Implements the <see cref="Volo.Abp.Application.Services.ApplicationService" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Application.Services.ApplicationService" />
    /// <remarks>Will Wu</remarks>
    public abstract class ServiceBase : ApplicationService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase" /> class.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        protected ServiceBase()
        {

        }
    }
}
