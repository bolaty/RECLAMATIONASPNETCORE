using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqniveausatisfaction
    {
        #region VARIABLES LOCALES

        private string _NS_CODENIVEAUSATISFACTION = "";
        private string _NS_LIBELLENIVEAUSATISFACTION = "";

        #endregion

        #region ACCESSEURS

        public string NS_CODENIVEAUSATISFACTION
        {
            get { return _NS_CODENIVEAUSATISFACTION; }
            set { _NS_CODENIVEAUSATISFACTION = value; }
        }

        public string NS_LIBELLENIVEAUSATISFACTION
        {
            get { return _NS_LIBELLENIVEAUSATISFACTION; }
            set { _NS_LIBELLENIVEAUSATISFACTION = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsReqniveausatisfaction() { }
        public clsReqniveausatisfaction(string NS_CODENIVEAUSATISFACTION, string NS_LIBELLENIVEAUSATISFACTION)
        {
            this.NS_CODENIVEAUSATISFACTION = NS_CODENIVEAUSATISFACTION;
            this.NS_LIBELLENIVEAUSATISFACTION = NS_LIBELLENIVEAUSATISFACTION;
        }
        public clsReqniveausatisfaction(clsReqniveausatisfaction clsReqniveausatisfaction)
        {
            this.NS_CODENIVEAUSATISFACTION = clsReqniveausatisfaction.NS_CODENIVEAUSATISFACTION;
            this.NS_LIBELLENIVEAUSATISFACTION = clsReqniveausatisfaction.NS_LIBELLENIVEAUSATISFACTION;
        }

        #endregion

    }
}
