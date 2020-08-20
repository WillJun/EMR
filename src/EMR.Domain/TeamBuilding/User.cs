//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding
// FileName : User
//
// Created by : Will.Wu at 2020/8/19 10:32:27
//
//
//========================================================================
using System;

using Volo.Abp.Domain.Entities;

namespace EMR.Domain.TeamBuilding
{
    public class User : Entity<Guid>
    {
        public User()
        {
        }

        public User(Guid id) : base(id)
        {
        }

        public string Account { get; set; }
        public string UserName { get; set; }
        public string UserEnName { get; set; }

        public string Email { get; set; }
        public string Dept { get; set; }

        public Guid TeamId { get; set; }

        public bool IsLeader { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// 是否超支
        /// </summary>

        public bool IsOverspend { get; set; }
    }
}