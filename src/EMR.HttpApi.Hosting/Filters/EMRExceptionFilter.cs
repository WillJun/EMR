using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EMR.HttpApi.Hosting.Filters
{
    public class EMRExceptionFilter : IExceptionFilter
    {
        private readonly ILog _log;

        public EMRExceptionFilter()
        {
            _log = LogManager.GetLogger(typeof(EMRExceptionFilter));
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"> </param>
        /// <returns> </returns>
        public void OnException(ExceptionContext context)
        {
            // 错误日志记录
            _log.Error($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}