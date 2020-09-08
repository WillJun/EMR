// ***********************************************************************
// Assembly         : EMR.Domain.Shared
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-02-2020
// ***********************************************************************
// <copyright file="EMRConsts.cs" company="EMR.Domain.Shared">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The Shared namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Domain.Shared
{
    /// <summary>
    /// Class EMRConsts.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class EMRConsts
    { /// <summary>
      /// 数据库表前缀 </summary>
        public const string DbTablePrefix = "emr_";

        /// <summary>
        /// 分组
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class Grouping
        {
            /// <summary>
            /// 初始化接口组
            /// </summary>
            public const string GroupName_v1 = "v1";

            /// <summary>
            /// 前台接口组
            /// </summary>
            public const string GroupName_v2 = "v2";

            /// <summary>
            /// 后台接口组
            /// </summary>
            public const string GroupName_v3 = "v3";

            /// <summary>
            /// JWT授权接口组
            /// </summary>
            public const string GroupName_v4 = "v4";
        }

        /// <summary>
        /// 缓存过期时间策略
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class CacheStrategy
        {
            /// <summary>
            /// 一天过期24小时
            /// </summary>

            public const int ONE_DAY = 1440;

            /// <summary>
            /// 12小时过期
            /// </summary>

            public const int HALF_DAY = 720;

            /// <summary>
            /// 8小时过期
            /// </summary>

            public const int EIGHT_HOURS = 480;

            /// <summary>
            /// 5小时过期
            /// </summary>

            public const int FIVE_HOURS = 300;

            /// <summary>
            /// 3小时过期
            /// </summary>

            public const int THREE_HOURS = 180;

            /// <summary>
            /// 2小时过期
            /// </summary>

            public const int TWO_HOURS = 120;

            /// <summary>
            /// 1小时过期
            /// </summary>

            public const int ONE_HOURS = 60;

            /// <summary>
            /// 半小时过期
            /// </summary>

            public const int HALF_HOURS = 30;

            /// <summary>
            /// 5分钟过期
            /// </summary>
            public const int FIVE_MINUTES = 5;

            /// <summary>
            /// 1分钟过期
            /// </summary>
            public const int ONE_MINUTE = 1;

            /// <summary>
            /// 永不过期
            /// </summary>

            public const int NEVER = -1;
        }

        /// <summary>
        /// 响应文本
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public static class ResponseText
        {
            /// <summary>
            /// 新增成功
            /// </summary>
            public const string INSERT_SUCCESS = "新增成功";

            /// <summary>
            /// 3ic
            /// </summary>
            public const string WOW_TIMES_LIMIT = "点赞次数每人限3次";

            /// <summary>
            /// 更新成功
            /// </summary>
            public const string UPDATE_SUCCESS = "更新成功";

            /// <summary>
            /// 删除成功
            /// </summary>
            public const string DELETE_SUCCESS = "删除成功";

            /// <summary>
            /// 什么不存在
            /// </summary>
            public const string WHAT_NOT_EXIST = "{0}:{1} 不存在";

            /// <summary>
            /// 数据为空
            /// </summary>
            public const string DATA_IS_NONE = "数据为空";

            /// <summary>
            /// 余额不足
            /// </summary>
            public const string BALANCE_IS_NONE = "余额不足";

            /// <summary>
            /// 不许本店消费
            /// </summary>
            public const string DONOT_COST_IN_OWNER_SHOP = "不许本店消费";

            /// <summary>
            /// IP地址格式错误
            /// </summary>
            public const string IP_IS_WRONG = "IP地址格式错误";

            /// <summary>
            /// 图片错误
            /// </summary>
            public const string IMG_IS_WRONG = "图片错误";

            /// <summary>
            /// 密码错误
            /// </summary>
            public const string PASSWORD_WRONG = "密码错误";

            /// <summary>
            /// 参数错误
            /// </summary>
            public const string PARAMETER_ERROR = "参数错误";

            /// <summary>
            /// 没有权限
            /// </summary>
            public const string RIGHT_LIMIT = "没有权限";

            /// <summary>
            /// 用户错误
            /// </summary>
            public const string USER_ERROR = "用户错误";
        }
    }
}