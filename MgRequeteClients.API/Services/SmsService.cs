using Microsoft.Extensions.Options;
using MgRequeteClients.API.Configuration;


namespace MgRequeteClients.API.Services
{
    public class SmsService
    {
        private readonly string _smsApi;

        public SmsService(IOptions<ApiEndpointsOptions> options)
        {
            _smsApi = options.Value.SmsApi;
        }

        public void EnvoyerSms(string message)
        {
            // Exemple d'envoi fictif (à remplacer par un appel HTTP si nécessaire)
            Console.WriteLine($"[SMS envoyé] Contenu : '{message}' via {_smsApi}");
        }

        public string GetApiUrl()
        {
            return _smsApi;
        }
    }
}
