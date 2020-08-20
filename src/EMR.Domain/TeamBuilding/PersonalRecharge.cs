//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding
// FileName : PersonalRecharge
//
// Created by : Will.Wu at 2020/8/19 10:55:57
//
//
//========================================================================

using System;
using Volo.Abp.Domain.Entities;

namespace EMR.Domain.TeamBuilding
{
    public class PersonalRecharge : Entity<Guid>
    {
        public PersonalRecharge()
        {
        }

        public PersonalRecharge(Guid id) : base(id)
        {
        }

        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNumber { get; set; }

        public Guid SourceId { get; set; }
        public Guid UserId { get; set; }
        public double Amount { get; set; }

        public string Comment { get; set; }
        public DateTime CreateTime { get; set; }
    }
}