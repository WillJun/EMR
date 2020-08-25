//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding
// FileName : SalesQuotaWithUserDto
//
// Created by : Will.Wu at 2020/8/25 14:36:26
//
//
//========================================================================

namespace EMR.Application.Contracts.TeamBuilding
{
    public class SalesQuotaWithUserDto : SalesQuotaDto
    {
        public string UserName { get; set; }
        public string UserAccount { get; set; }
    }
}