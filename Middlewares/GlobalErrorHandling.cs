using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CaribeMediaApi.Middlewares
{
    public class GlobalErrorHandling
    {
        private readonly RequestDelegate _next;
        private ILogger _logger;

        public GlobalErrorHandling(
            RequestDelegate next, ILogger<GlobalErrorHandling> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var content = JsonConvert.SerializeObject(new {
                    errors = new string[] { 
                        "there was an internal server error, please contact system administrator"
                     }
                });
            
                await context.Response.WriteAsync(content);
            }
        }
    }
}