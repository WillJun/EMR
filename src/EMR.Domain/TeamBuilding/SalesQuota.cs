//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding
// FileName : SalesQuotas
//
// Created by : Will.Wu at 2020/8/19 10:41:14
//
//
//========================================================================
using System;

using Volo.Abp.Domain.Entities;

namespace EMR.Domain.TeamBuilding
{
    public class SalesQuota : Entity<Guid>
    {
        public SalesQuota()
        {
        }

        public SalesQuota(Guid id) : base(id)
        {
        }

        /// <summary>
        /// 流水号
        /// </summary>

        public string SerialNumber { get; set; }
        public Guid TeamId { get; set; }
        public Guid Operator { get; set; }
        public double Income { get; set; }
        public string Comment { get; set; }
        public DateTime CreateTime { get; set; }
    }
}