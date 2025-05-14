using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using log4net;

namespace MgRequeteClients.Tools.Classes
{
    public static class clsAppelServiceWeb
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<IEnumerable<TResponse>> ExecuteWebServiceAsync<TRequest, TResponse>(
            TRequest request,
            string method,
            string url,
            string authToken = null,
            TimeSpan? timeout = null)
        {
            try
            {
                if (!await IsNetworkAvailableAsync())
                    return null;

                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrEmpty(authToken))
                {
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
                }

                _httpClient.Timeout = timeout ?? TimeSpan.FromSeconds(30);

                var requestMessage = new HttpRequestMessage(
                    new HttpMethod(method),
                    url);

                if (request != null)
                {
                    var jsonContent = JsonSerializer.Serialize(request);
                    requestMessage.Content = new StringContent(
                        jsonContent,
                        Encoding.UTF8,
                        "application/json");
                }

                var response = await _httpClient.SendAsync(requestMessage);

                response.EnsureSuccessStatusCode();

                await using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<TResponse>>(responseStream);
            }
            catch (HttpRequestException ex)
            {
                // Utiliser ILogger au lieu de log4net
                Console.Error.WriteLine($"HTTP Request Error: {ex.Message}");
                throw new WebServiceException("Web service call failed", ex);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"General Error: {ex.Message}");
                throw;
            }
        }

        public static async Task<bool> IsNetworkAvailableAsync()
        {
            try
            {
                // Solution cross-platform
                using var ping = new Ping();
                var result = await ping.SendPingAsync("8.8.8.8", 3000); // Google DNS
                return result.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }

    }

    public class WebServiceException : Exception
    {
        public WebServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}