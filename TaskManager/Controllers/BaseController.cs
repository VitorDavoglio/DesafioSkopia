using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;
using TaskManager.Utils;

namespace TaskManager.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IMediator _mediatr;
        public BaseController(IMediator mediatr)
        {
            _mediatr = mediatr;
            JsonConvert.DefaultSettings = (() =>
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new StringEnumConverter());
                return settings;
            });
        }
        public async Task<IActionResult> GenerateApiResponseAsync<TDataObject>(Func<Task<TDataObject>> func)
        {
            return await GenerateResponseAsync(func, HttpStatusCode.OK);
        }
        private async Task<IActionResult> GenerateResponseAsync<T>(Func<Task<T>> func, HttpStatusCode responseCode)
        {
            try
            {
                T data = await func();
                IActionResult result;

                if (data != null)
                {
                    return StatusCode((int)responseCode, new ApiNotification<T>()
                    {
                        Success = (int)responseCode < 300,
                        Data = data,
                        Notifications = null
                    });
                }
                else
                {
                    return StatusCode((int)responseCode, new ApiNotification<T>()
                    {
                        Success = (int)responseCode < 300,
                        Data = default(T?),
                        Notifications = null
                    });
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
      
    }
}
