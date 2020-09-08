// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="EMRDbContext.cs" company="EMR.EntityFrameworkCore">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using EMR.Domain.TeamBuilding;

using Microsoft.EntityFrameworkCore;

using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

/// <summary>
/// The EntityFrameworkCore namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.EntityFrameworkCore
{
    /// <summary>
    /// Class EMRDbContext.
    /// Implements the <see cref="Volo.Abp.EntityFrameworkCore.AbpDbContext{EMR.EntityFrameworkCore.EMRDbContext}" />
    /// </summary>
    /// <seealso cref="Volo.Abp.EntityFrameworkCore.AbpDbContext{EMR.EntityFrameworkCore.EMRDbContext}" />
    /// <remarks>Will Wu</remarks>
    [ConnectionStringName("MySql")]
    public class EMRDbContext : AbpDbContext<EMRDbContext>
    {
        /// <summary>
        /// Gets or sets the personal expenditures.
        /// </summary>
        /// <value>The personal expenditures.</value>
        /// <remarks>Will Wu</remarks>
        public DbSet<PersonalExpenditure> PersonalExpenditures { get; set; }

        /// <summary>
        /// Gets or sets the personal recharges.
        /// </summary>
        /// <value>The personal recharges.</value>
        /// <remarks>Will Wu</remarks>
        public DbSet<PersonalRecharge> PersonalRecharges { get; set; }

        /// <summary>
        /// Gets or sets the sales quotas.
        /// </summary>
        /// <value>The sales quotas.</value>
        /// <remarks>Will Wu</remarks>
        public DbSet<SalesQuota> SalesQuotas { get; set; }

        /// <summary>
        /// Gets or sets the teams.
        /// </summary>
        /// <value>The teams.</value>
        /// <remarks>Will Wu</remarks>
        public DbSet<Team> Teams { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        /// <remarks>Will Wu</remarks>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the team wows.
        /// </summary>
        /// <value>The team wows.</value>
        /// <remarks>Will Wu</remarks>
        public DbSet<TeamWow> TeamWows { get; set; }

        /// <summary>
        /// Gets or sets the team discounts.
        /// </summary>
        /// <value>The team discounts.</value>
        /// <remarks>Will Wu</remarks>
        public DbSet<TeamDiscount> TeamDiscounts { get; set; }
        /// <summary>
        /// Gets or sets the team expends.
        /// </summary>
        /// <value>The team expends.</value>
        /// <remarks>Will Wu</remarks>
        public DbSet<TeamExpend> TeamExpends { get; set; }

        /// <summary>
        /// Gets or sets the activities.
        /// </summary>
        /// <value>The activities.</value>
        /// <remarks>Will Wu</remarks>
        public DbSet<Activity> Activities { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EMRDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <remarks>Will Wu</remarks>
        public EMRDbContext(DbContextOptions<EMRDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        /// <remarks>Will Wu</remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configure();
        }
    }
}