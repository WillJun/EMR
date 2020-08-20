//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding
// FileName : PersonalExpenditure
//
// Created by : Will.Wu at 2020/8/19 10:44:31
//
//
//========================================================================
using System;

using Volo.Abp.Domain.Entities;

namespace EMR.Domain.TeamBuilding
{
    public class PersonalExpenditure : Entity<Guid>
    {
        public PersonalExpenditure()
        {
        }

        public PersonalExpenditure(Guid id) : base(id)
        {
        }

        public Guid ExpenditureTeamId { get; set; }
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