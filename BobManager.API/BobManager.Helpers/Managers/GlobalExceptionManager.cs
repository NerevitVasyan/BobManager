using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using BobManager.Dto.DtoResults;
using Microsoft.AspNetCore.Http;

namespace BobManager.Helpers.Managers
{
    public class ErrorFilter
    {
        /// <summary>
        /// if LogLevel none error not logging
        /// </summary>
        public LogLevel Logging { get; private set; }
        public bool ShowClient { get; private set; }
        
        public ErrorFilter(LogLevel logLevel = LogLevel.None, bool showClient = false)
        {
            Logging = logLevel;
            ShowClient = showClient;
        }
    }

    public class GlobalExceptionManager
    {
        private ConcurrentDictionary<Type, ErrorFilter> filters = new ConcurrentDictionary<Type, ErrorFilter>();
        public ILogger Logger { get; set; } = null;

        private ErrorFilter baseErrorFilter;
        private string baseText;
  
        public bool DebugMode { get; set; }

        public GlobalExceptionManager(ErrorFilter baseErrorFilter, string baseText)
        {
            this.baseErrorFilter = baseErrorFilter ?? throw new ArgumentNullException("baseErrorFilter");
            this.baseText = baseText ?? throw new ArgumentNullException("baseText");
        }
        public bool AddFilter(Type typeOfExceptions, ErrorFilter baseErrorFilter)
        {
            if (typeOfExceptions == null)
                throw new ArgumentNullException("typeOfExceptions");
            if (baseErrorFilter == null)
                throw new ArgumentNullException("baseErrorFilter");

            return filters.TryAdd(typeOfExceptions, baseErrorFilter);
        }

        public bool AddRangeErrors(Dictionary<Type, ErrorFilter> filters)
        {
            if (filters == null)
                throw new ArgumentNullException("filters");

            foreach (var item in filters)
                AddFilter(item.Key, item.Value);
            return true;
        }

        public ResultDto CreateResultDto(HttpContext context, Exception ex, ErrorFilter fl) {
            ResultDto result = null;

            if (fl.Logging != LogLevel.None && Logger != null)
                Logger.Log(fl.Logging, $"[{DateTime.Now.ToString()}][{context.Connection.RemoteIpAddress.MapToIPv4()}]: " + ex.Message);

            if (fl.ShowClient || DebugMode)
                result = new SingleResultDto<Exception> { Data = ex, Message = ex.Message };
            else
                result = new ResultDto() { Message = baseText };
            result.IsSuccessful = false;
            return result;
        }

        public ResultDto MapExceptionToResultDto(HttpContext context, Exception ex)
        {
            foreach (var item in filters)
                if (item.Key == ex.GetType())
                    return CreateResultDto(context, ex, item.Value);

            return CreateResultDto(context, ex, baseErrorFilter);
        }
    }
}
