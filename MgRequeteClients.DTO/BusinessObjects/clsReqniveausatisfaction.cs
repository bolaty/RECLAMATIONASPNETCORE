using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqniveausatisfaction
    {
        #region VARIABLES LOCALES

        private string _NS_CODENIVEAUSATISFACTION = "";
        private string _NS_LIBELLENIVEAUSATISFACTION = "";
        private string _NS_LIBELLENIVEAUSATISFACTION_TRANSLATE = "";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;
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

        public string NS_LIBELLENIVEAUSATISFACTION_TRANSLATE
        {
            get { return _NS_LIBELLENIVEAUSATISFACTION_TRANSLATE; }
            set { _NS_LIBELLENIVEAUSATISFACTION_TRANSLATE = value; }
        }

        public clsResultat clsResultat
        {
            get { return _clsResultat; }
            set { _clsResultat = value; }
        }
        public clsObjetEnvoi clsObjetEnvoi
        {
            get { return _clsObjetEnvoi; }
            set { _clsObjetEnvoi = value; }
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
            this.NS_LIBELLENIVEAUSATISFACTION_TRANSLATE = clsReqniveausatisfaction.NS_LIBELLENIVEAUSATISFACTION_TRANSLATE;
            this.clsResultat = clsReqniveausatisfaction.clsResultat;
            this.clsObjetEnvoi = clsReqniveausatisfaction.clsObjetEnvoi;
        }
        #endregion

    }


}
