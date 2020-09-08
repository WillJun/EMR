// ***********************************************************************
// Assembly         : EMR.Domain
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-05-2020
// ***********************************************************************
// <copyright file="AppSettings.cs" company="EMR.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.Extensions.Configuration;

/// <summary>
/// The Configurations namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Domain.Configurations
{
    /// <summary>
    /// Class AppSettings.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class AppSettings
    {
        /// <summary>
        /// 配置文件的根节点
        /// </summary>
        private static readonly IConfigurationRoot _config;

        /// <summary>
        /// ApiVersion
        /// </summary>
        /// <value>The API version.</value>
        /// <remarks>Will Wu</remarks>
        public static string ApiVersion => _config["ApiVersion"];

        /// <summary>
        /// WebHost
        /// </summary>
        /// <value>The web host.</value>
        /// <remarks>Will Wu</remarks>
        public static string WebHost => _config["WebHost"];

        /// <summary>
        /// APIHost
        /// </summary>
        /// <value>The API host.</value>
        /// <remarks>Will Wu</remarks>
        public static string APIHost => _config["APIHost"];

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>Will Wu</remarks>
        static AppSettings()
        {
            // 加载appsettings.json，并构建IConfigurationRoot
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json", true, true);
            _config = builder.Build();
        }

        /// <summary>
        /// EnableDb
        /// </summary>
        /// <value>The enable database.</value>
        /// <remarks>Will Wu</remarks>
        public static string EnableDb => _config["ConnectionStrings:Enable"];

        /// <summary>
        /// ConnectionStrings
        /// </summary>
        /// <value>The connection strings.</value>
        /// <remarks>Will Wu</remarks>
        public static string ConnectionStrings => _config.GetConnectionString(EnableDb);

        /// <summary>
        /// 监听端口
        /// </summary>
        /// <value>The listen port.</value>
        /// <remarks>Will Wu</remarks>
        public static string ListenPort => _config["listenPort"];

        /// <summary>
        /// Caching
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class Caching
        {
            /// <summary>
            /// RedisConnectionString
            /// </summary>
            /// <value>The redis connection string.</value>
            /// <remarks>Will Wu</remarks>
            public static string RedisConnectionString => _config["Caching:RedisConnectionString"];

            /// <summary>
            /// 是否开启
            /// </summary>
            /// <value><c>true</c> if this instance is open; otherwise, <c>false</c>.</value>
            /// <remarks>Will Wu</remarks>
            public static bool IsOpen => Convert.ToBoolean(_config["Caching:IsOpen"]);
        }

        /// <summary>
        /// GitHub
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class GitHub
        {
            /// <summary>
            /// Gets the user identifier.
            /// </summary>
            /// <value>The user identifier.</value>
            /// <remarks>Will Wu</remarks>
            public static int UserId => Convert.ToInt32(_config["Github:UserId"]);

            /// <summary>
            /// Gets the client identifier.
            /// </summary>
            /// <value>The client identifier.</value>
            /// <remarks>Will Wu</remarks>
            public static string Client_ID => _config["Github:ClientID"];

            /// <summary>
            /// Gets the client secret.
            /// </summary>
            /// <value>The client secret.</value>
            /// <remarks>Will Wu</remarks>
            public static string Client_Secret => _config["Github:ClientSecret"];

            /// <summary>
            /// Gets the redirect URI.
            /// </summary>
            /// <value>The redirect URI.</value>
            /// <remarks>Will Wu</remarks>
            public static string Redirect_Uri => _config["Github:RedirectUri"];

            /// <summary>
            /// Gets the name of the application.
            /// </summary>
            /// <value>The name of the application.</value>
            /// <remarks>Will Wu</remarks>
            public static string ApplicationName => _config["Github:ApplicationName"];
        }

        /// <summary>
        /// JWT
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class JWT
        {
            /// <summary>
            /// Gets the domain.
            /// </summary>
            /// <value>The domain.</value>
            /// <remarks>Will Wu</remarks>
            public static string Domain => _config["JWT:Domain"];

            /// <summary>
            /// Gets the security key.
            /// </summary>
            /// <value>The security key.</value>
            /// <remarks>Will Wu</remarks>
            public static string SecurityKey => _config["JWT:SecurityKey"];

            /// <summary>
            /// Gets the expires.
            /// </summary>
            /// <value>The expires.</value>
            /// <remarks>Will Wu</remarks>
            public static int Expires => Convert.ToInt32(_config["JWT:Expires"]);
        }

        /// <summary>
        /// Hangfire
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class Hangfire
        {
            /// <summary>
            /// Gets the login.
            /// </summary>
            /// <value>The login.</value>
            /// <remarks>Will Wu</remarks>
            public static string Login => _config["Hangfire:Login"];

            /// <summary>
            /// Gets the password.
            /// </summary>
            /// <value>The password.</value>
            /// <remarks>Will Wu</remarks>
            public static string Password => _config["Hangfire:Password"];
        }

        /// <summary>
        /// MTA
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class MTA
        {
            /// <summary>
            /// Gets the application identifier.
            /// </summary>
            /// <value>The application identifier.</value>
            /// <remarks>Will Wu</remarks>
            public static string App_Id => _config["MTA:App_Id"];

            /// <summary>
            /// Gets the secret key.
            /// </summary>
            /// <value>The secret key.</value>
            /// <remarks>Will Wu</remarks>
            public static string SECRET_KEY => _config["MTA:SECRET_KEY"];
        }

        /// <summary>
        /// 个性签名配置
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class Signature
        {
            /// <summary>
            /// Gets the path.
            /// </summary>
            /// <value>The path.</value>
            /// <remarks>Will Wu</remarks>
            public static string Path => _config["Signature:Path"];

            /// <summary>
            /// Gets the urls.
            /// </summary>
            /// <value>The urls.</value>
            /// <remarks>Will Wu</remarks>
            public static IDictionary<string, string> Urls
            {
                get
                {
                    var dic = new Dictionary<string, string>();

                    var urls = _config.GetSection("Signature:Urls");
                    foreach (IConfigurationSection section in urls.GetChildren())
                    {
                        var url = section["Url"];
                        var parameter = section["Parameter"];

                        dic.Add(url, parameter);
                    }
                    return dic;
                }
            }
        }

        /// <summary>
        /// 百度AI 语音合成
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class BaiduAI
        {
            /// <summary>
            /// Gets the API key.
            /// </summary>
            /// <value>The API key.</value>
            /// <remarks>Will Wu</remarks>
            public static string APIKey => _config["BaiduAI:APIKey"];

            /// <summary>
            /// Gets the secret key.
            /// </summary>
            /// <value>The secret key.</value>
            /// <remarks>Will Wu</remarks>
            public static string SecretKey => _config["BaiduAI:SecretKey"];
        }

        /// <summary>
        /// 腾讯云API
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class TencentCloud
        {
            /// <summary>
            /// Gets the secret identifier.
            /// </summary>
            /// <value>The secret identifier.</value>
            /// <remarks>Will Wu</remarks>
            public static string SecretId => _config["TencentCloud:SecretId"];

            /// <summary>
            /// Gets the secret key.
            /// </summary>
            /// <value>The secret key.</value>
            /// <remarks>Will Wu</remarks>
            public static string SecretKey => _config["TencentCloud:SecretKey"];

            /// <summary>
            /// Class Captcha.
            /// </summary>
            /// <remarks>Will Wu</remarks>
            public static class Captcha
            {
                /// <summary>
                /// Gets the API key.
                /// </summary>
                /// <value>The API key.</value>
                /// <remarks>Will Wu</remarks>
                public static string APIKey => _config["TencentCloud:Captcha:AppId"];

                /// <summary>
                /// Gets the secret key.
                /// </summary>
                /// <value>The secret key.</value>
                /// <remarks>Will Wu</remarks>
                public static string SecretKey => _config["TencentCloud:Captcha:AppSecret"];
            }
        }

        /// <summary>
        /// RemoveBg
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class RemoveBg
        {
            /// <summary>
            /// Gets the secret.
            /// </summary>
            /// <value>The secret.</value>
            /// <remarks>Will Wu</remarks>
            public static string Secret => _config["RemoveBg:Secret"];

            /// <summary>
            /// Gets the URL.
            /// </summary>
            /// <value>The URL.</value>
            /// <remarks>Will Wu</remarks>
            public static string URL => _config["RemoveBg:URL"];
        }

        /// <summary>
        /// FM Api
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class FMApi
        {
            /// <summary>
            /// Gets the channels.
            /// </summary>
            /// <value>The channels.</value>
            /// <remarks>Will Wu</remarks>
            public static string Channels => _config["FMApi:Channels"];

            /// <summary>
            /// Gets the song.
            /// </summary>
            /// <value>The song.</value>
            /// <remarks>Will Wu</remarks>
            public static string Song => _config["FMApi:Song"];

            /// <summary>
            /// Gets the lyric.
            /// </summary>
            /// <value>The lyric.</value>
            /// <remarks>Will Wu</remarks>
            public static string Lyric => _config["FMApi:Lyric"];
        }

        /// <summary>
        /// Email配置
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class Email
        {
            /// <summary>
            /// Host
            /// </summary>
            /// <value>The host.</value>
            /// <remarks>Will Wu</remarks>
            public static string Host => _config["Email:Host"];

            /// <summary>
            /// Port
            /// </summary>
            /// <value>The port.</value>
            /// <remarks>Will Wu</remarks>
            public static int Port => Convert.ToInt32(_config["Email:Port"]);

            /// <summary>
            /// UseSsl
            /// </summary>
            /// <value><c>true</c> if [use SSL]; otherwise, <c>false</c>.</value>
            /// <remarks>Will Wu</remarks>
            public static bool UseSsl => Convert.ToBoolean(_config["Email:UseSsl"]);

            /// <summary>
            /// From
            /// </summary>
            /// <remarks>Will Wu</remarks>
            public static class From
            {
                /// <summary>
                /// Username
                /// </summary>
                /// <value>The username.</value>
                /// <remarks>Will Wu</remarks>
                public static string Username => _config["Email:From:Username"];

                /// <summary>
                /// Password
                /// </summary>
                /// <value>The password.</value>
                /// <remarks>Will Wu</remarks>
                public static string Password => _config["Email:From:Password"];

                /// <summary>
                /// Name
                /// </summary>
                /// <value>The name.</value>
                /// <remarks>Will Wu</remarks>
                public static string Name => _config["Email:From:Name"];

                /// <summary>
                /// Address
                /// </summary>
                /// <value>The address.</value>
                /// <remarks>Will Wu</remarks>
                public static string Address => _config["Email:From:Address"];
            }

            /// <summary>
            /// To
            /// </summary>
            /// <value>To.</value>
            /// <remarks>Will Wu</remarks>
            public static IDictionary<string, string> To
            {
                get
                {
                    var dic = new Dictionary<string, string>();

                    var emails = _config.GetSection("Email:To");
                    foreach (IConfigurationSection section in emails.GetChildren())
                    {
                        var name = section["Name"];
                        var address = section["Address"];

                        dic.Add(name, address);
                    }
                    return dic;
                }
            }
        }
    }
}