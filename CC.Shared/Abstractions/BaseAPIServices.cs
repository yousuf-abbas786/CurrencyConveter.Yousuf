﻿
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CC.Shared.Abstractions
{
    public abstract class BaseAPIServices
    {
        private readonly ILogger _logger;
        private readonly IFlurlClient _flurlClient;

        public BaseAPIServices(ILogger<BaseAPIServices> logger, IFlurlClientCache clients, string baseUrlName)
        {
            _logger = logger;
            _flurlClient = clients.Get(baseUrlName);
        }

        protected async Task<T> GetRequestData<T>(string url, Dictionary<string, string>? queryString = null)
        {
            if (string.IsNullOrEmpty(url))
                throw new Exception("URL for request is null");

            if (queryString != null)
            {
                url += "?";
                foreach (var key in queryString.Where(a => !string.IsNullOrEmpty(a.Value)))
                {
                    url += key.Key + "=" + key.Value + "&";
                }
            }
            url = url.TrimEnd('&');

            _logger.LogInformation($"GetRequestData - URL: {url}");

            var response = await GetRequestWithRetries<T>(url, 3);

            if (response == null)
                throw new Exception($"GetRequestData Error: Check requested API: {url}, Response: {JsonConvert.SerializeObject(response)}");

            return response;
        }

        protected async Task<T> PostRequestData<T>(string url, object data)
        {
            if (string.IsNullOrEmpty(url))
                throw new Exception("URL for request is null");

            var response = await _flurlClient.Request(url).PostJsonAsync(data);
            if (response == null)
                throw new Exception($"PostRequestData Error: Check requested API: {url}, Body: {JsonConvert.SerializeObject(data)}, Response: {response?.ResponseMessage}");

            return await response.GetJsonAsync<T>();
        }

        protected async Task<T> GetRequestWithRetries<T>(string url, int maxRetries)
        {
            T response = default(T);
            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    response = await _flurlClient.Request(url).GetJsonAsync<T>();
                    return response;
                }
                catch (FlurlHttpException ex)
                {
                    _logger.LogError($"Error returned from {ex.Call.Request.Url}, Error: {ex.Message}");
                }
                await Task.Delay(1000);
            }

            return response;
        }

        protected async Task<T> RequestWithoutRetries<T>(string url)
        {
            return await _flurlClient.Request(url).GetJsonAsync<T>();
        }
    }
}
