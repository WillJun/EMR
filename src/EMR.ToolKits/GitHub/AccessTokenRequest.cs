//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.ToolKits.GitHub
// FileName : AccessTokenRequest
//
// Created by : Will.Wu at 2020/8/5 11:48:07
//
//
//========================================================================

using EMR.Domain.Configurations;

namespace EMR.ToolKits.GitHub
{
    public class AccessTokenRequest
    {
        /// <summary>
        /// Client ID
        /// </summary>
        public string Client_ID = GitHubConfig.Client_ID;

        /// <summary>
        /// Client Secret
        /// </summary>
        public string Client_Secret = GitHubConfig.Client_Secret;

        /// <summary>
        /// 调用API_Authorize获取到的Code值
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Authorization callback URL
        /// </summary>
        public string Redirect_Uri = GitHubConfig.Redirect_Uri;

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }
    }
}