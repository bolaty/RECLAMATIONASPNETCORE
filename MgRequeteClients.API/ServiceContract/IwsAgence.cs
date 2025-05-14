using MgRequeteClients.BOJ.BusinessObjects;

namespace MgRequeteClients.API.ServiceContract
{
    public interface IwsAgence
    {
        string AjouterAgence(MgRequeteClients.DTO.BusinessObjects.clsAgence agence);
    }
}
