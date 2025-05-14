using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MgRequeteClients.API.Models;
using MgRequeteClients.Tools.Classes;

namespace MgRequeteClients.API.Controllers
{
    public class LogController : ControllerBase
    {

        // GET: Log
        public void EcrireDansFichierLog(string vlpOrigine, string vlpMessage)
        {
            string path = MgRequeteClients.Tools.Classes.clsDeclaration.PATHLOGGER;
            //try { path = Server.MapPath("~/Loggers/"); } catch { }

            Logger loggerHT;
            //--Envoi de sms Appel url notification
            loggerHT = new Logger();
            loggerHT.Log(path, vlpOrigine, vlpMessage);
        }

        public void EcrireDansFichierLogNew(string vlpOrigine, string vlpMessage)
        {
            string path = MgRequeteClients.Tools.Classes.clsDeclaration.PATHLOGGER;
            //try { path = Server.MapPath("~/Loggers/"); } catch { }

            Logger loggerHT;
            //--Envoi de sms Appel url notification
            loggerHT = new Logger();
            loggerHT.LogVR(path, vlpOrigine, vlpMessage);
        }
    }
}
