// ***********************************************************************
// Assembly         : EMR.Domain.Shared
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="EMRDbConsts.cs" company="EMR.Domain.Shared">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The Shared namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Domain.Shared
{
    /// <summary>
    /// Class EMRDbConsts.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class EMRDbConsts
    {
        /// <summary>
        /// Class DbTableName.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class DbTableName
        {
            /// <summary>
            /// The personal expenditure
            /// </summary>
            public const string PersonalExpenditure = "PersonalExpenditures";

            /// <summary>
            /// The personal recharge
            /// </summary>
            public const string PersonalRecharge = "PersonalRecharges";

            /// <summary>
            /// The sales quota
            /// </summary>
            public const string SalesQuota = "SalesQuotas";

            /// <summary>
            /// The team
            /// </summary>
            public const string Team = "Teams";
            /// <summary>
            /// The team wow
            /// </summary>
            public const string TeamWow = "TeamWows";
            /// <summary>
            /// The team discount
            /// </summary>
            public const string TeamDiscount = "TeamDiscount";
            /// <summary>
            /// The team expend
            /// </summary>
            public const string TeamExpend = "TeamExpend";

            /// <summary>
            /// The user
            /// </summary>
            public const string User = "Users";

            /// <summary>
            /// The activity
            /// </summary>
            public const string Activity = "Activities";
        }
    }
}