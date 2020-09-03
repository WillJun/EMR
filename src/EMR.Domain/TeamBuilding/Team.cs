//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding
// FileName : Team
//
// Created by : Will.Wu at 2020/8/19 10:28:59
//
//
//========================================================================
using System;

using Volo.Abp.Domain.Entities;

namespace EMR.Domain.TeamBuilding
{
    public class Team : Entity<Guid>
    {
        public Team()
        {
        }

        public Team(Guid id) : base(id)
        {
        }

        public string TeamName { get; set; }

        public string TeamLeader { get; set; }

        public bool IsOrganiser { get; set; }

        public string Logo { get; set; }

        public DateTime CreateTime { get; set; }
    }
}