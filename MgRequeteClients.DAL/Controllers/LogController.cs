using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MgRequeteClients.Tools.Classes;

namespace MgRequeteClients.DAL.Controllers
{
    internal class LogController
    {
        // GET: Log
        public void EcrireDansFichierLog(string vlpOrigine, string vlpMessage)
        {
            string path = clsDeclaration.PATHLOGGER;
            //try { path = Server.MapPath("~/Loggers/"); } catch { }

            Logger loggerHT;
            //--Envoi de sms Appel url notification
            loggerHT = new Logger();
            loggerHT.Log(path, vlpOrigine, vlpMessage);
        }
    }
}
