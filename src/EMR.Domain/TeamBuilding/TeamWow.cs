//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding
// FileName : TeamWow
//
// Created by : Will.Wu at 2020/8/19 15:28:17
//
//
//========================================================================
using System;
using Volo.Abp.Domain.Entities;

namespace EMR.Domain.TeamBuilding
{
    public class TeamWow : Entity<Guid>
    {
        public Guid TeamId { get; set; }

        public Guid UserId { get; set; }

        public bool IsWow { get; set; }
    }
}