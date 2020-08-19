﻿//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.ToolKits.GitHub
// FileName : UserResponse
//
// Created by : Will.Wu at 2020/8/5 12:33:15
//
//
//========================================================================

namespace EMR.ToolKits.GitHub
{
    public class UserResponse
    {
        public string Login { get; set; }

        public int Id { get; set; }

        public string Avatar_url { get; set; }

        public string Html_url { get; set; }

        public string Repos_url { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Blog { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }

        public string Bio { get; set; }

        public int Public_repos { get; set; }
    }
}