//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding
// FileName : TeamExpend
//
// Created by : Will.Wu at 2020/8/29 13:28:04
//
//
//========================================================================
using System;

using Volo.Abp.Domain.Entities;

namespace EMR.Domain.TeamBuilding
{
    public class TeamExpend : Entity<Guid>
    {
        public TeamExpend()
        {
        }

        public TeamExpend(Guid id) : base(id)
        {
        }

        public Guid TeamId { get; set; }
        public Guid UserId { get; set; }
        public double Expend { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNumber { get; set; }

        public string Comment { get; set; }
        public DateTime CreateTime { get; set; }
    }
}