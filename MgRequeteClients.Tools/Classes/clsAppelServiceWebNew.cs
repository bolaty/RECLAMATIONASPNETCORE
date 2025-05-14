using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using log4net;

namespace MgRequeteClients.Tools.Classes
{
    public class clsAppelServiceWebNew
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly HttpClient httpClient = new HttpClient();

        public static IList<K> excecuteServiceWeb<K, T>(K data, T Objet, string method, string url)
        {
            List<K> objList = new List<K>();

            try
            {
                // Création du contenu JSON
                string jsonConsultation = JsonConvert.SerializeObject(new { Objet });
                var content = new StringContent(jsonConsultation, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                // Envoi synchrone selon la méthode
                if (method.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    response = httpClient.PostAsync(url, content).GetAwaiter().GetResult();
                }
                else if (method.Equals("PUT", StringComparison.OrdinalIgnoreCase))
                {
                    response = httpClient.PutAsync(url, content).GetAwaiter().GetResult();
                }
                else if (method.Equals("GET", StringComparison.OrdinalIgnoreCase))
                {
                    response = httpClient.GetAsync(url).GetAwaiter().GetResult();
                }
                else
                {
                    throw new NotSupportedException($"Méthode HTTP non supportée : {method}");
                }

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    objList = JsonConvert.DeserializeObject<List<K>>(result);
                }
                else
                {
                    Log.Error($"Erreur HTTP : {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException e)
            {
                Log.Error("Erreur de requête HTTP : ", e);
                return null;
            }
            catch (Exception ex)
            {
                Log.Error("Erreur générale : ", ex);
                return null;
            }

            return objList;
        }

        public static bool IsValidateIP(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress)) return false;

            if (ipAddress.Contains("http://"))
                ipAddress = ipAddress.Replace("http://", "");
            if (ipAddress.Contains("https://"))
                ipAddress = ipAddress.Replace("https://", "");

            string[] adresse = ipAddress.Split(':');
            if (adresse.Length != 2) return false;

            string host = adresse[0];
            if (!int.TryParse(adresse[1].Replace("/", ""), out int port)) return false;

            return PingHost(host, port);
        }

        public static bool PingHost(string host, int port)
        {
            try
            {
                using var client = new TcpClient();
                var result = client.BeginConnect(host, port, null, null);
                bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2));
                return success && client.Connected;
            }
            catch
            {
                return false;
            }
        }

    }
}
