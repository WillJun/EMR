//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding
// FileName : TeamDiscount
//
// Created by : Will.Wu at 2020/8/19 10:28:59
//
//
//========================================================================

using System;

using Volo.Abp.Domain.Entities;

namespace EMR.Domain.TeamBuilding
{
    public class TeamDiscount : Entity<Guid>
    {
        public TeamDiscount()
        {
        }

        public TeamDiscount(Guid id) : base(id)
        {
        }

        public Guid TeamId { get; set; }
        public bool IsDisable { get; set; }

        public double FullAmount { get; set; }

        public string Operation { get; set; }

        public double Discount { get; set; }
        public string Discription { get; set; }
    }
}