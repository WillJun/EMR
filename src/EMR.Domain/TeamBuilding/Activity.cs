//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding
// FileName : Activity
//
// Created by : Will.Wu at 2020/9/8 16:09:12
//
//
//========================================================================

using System;

using Volo.Abp.Domain.Entities;

namespace EMR.Domain.TeamBuilding
{
    public class Activity : Entity<Guid>
    {
        public Activity()
        {
        }

        public Activity(Guid id) : base(id)
        {
        }

        public string ActivityName { get; set; }
        public DateTime? Start_Time { get; set; }

        public DateTime? Finish_Time { get; set; }
    }
}