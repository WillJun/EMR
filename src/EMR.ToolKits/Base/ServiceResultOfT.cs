//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.ToolKits.Base
// FileName : ServiceResultOfT
//
// Created by : Will.Wu at 2020/8/5 8:36:35
//
//
//========================================================================
using EMR.ToolKits.Base.Enum;

namespace EMR.ToolKits.Base
{
    /// <summary>
    /// 服务层响应实体(泛型)
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public class ServiceResult<T> : ServiceResult where T : class
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="result"> </param>
        /// <param name="message"> </param>
        public void IsSuccess(T result = null, string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Succeed;
            Result = result;
        }
    }
}