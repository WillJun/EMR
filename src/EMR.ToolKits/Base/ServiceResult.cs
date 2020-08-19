//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.ToolKits.Base
// FileName : ServiceResult
//
// Created by : Will.Wu at 2020/8/5 8:35:52
//
//
//========================================================================
using System;
using EMR.ToolKits.Base.Enum;

namespace EMR.ToolKits.Base
{
    /// <summary>
    /// 服务层响应实体
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public ServiceResultCode Code { get; set; }

        /// <summary>
        /// 响应信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 成功
        /// </summary>
        public bool Success => Code == ServiceResultCode.Succeed;

        /// <summary>
        /// 时间戳(毫秒)
        /// </summary>
        public long Timestamp { get; } = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="message"> </param>
        /// <param name="data"> </param>
        /// <returns> </returns>
        public void IsSuccess(string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Succeed;
        }

        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="message"> </param>
        /// <param name="data"> </param>
        /// <returns> </returns>
        public void IsFailed(string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Failed;
        }

        /// <summary> 响应失败 </summary> <param name="exexception></param> <param name="data"></param> <returns></returns>
        public void IsFailed(Exception exception)
        {
            Message = exception.InnerException?.StackTrace;
            Code = ServiceResultCode.Failed;
        }
    }
}