using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqnaturerequete
    {
        #region VARIABLES LOCALES

        private string _NR_CODENATUREREQUETE = "";
        private string _NR_LIBELLENATUREREQUETE = "";
        private string _NR_STATUT = "";

        #endregion

        #region ACCESSEURS

        public string NR_CODENATUREREQUETE
        {
            get { return _NR_CODENATUREREQUETE; }
            set { _NR_CODENATUREREQUETE = value; }
        }

        public string NR_LIBELLENATUREREQUETE
        {
            get { return _NR_LIBELLENATUREREQUETE; }
            set { _NR_LIBELLENATUREREQUETE = value; }
        }

        public string NR_STATUT
        {
            get { return _NR_STATUT; }
            set { _NR_STATUT = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsReqnaturerequete() { }
        public clsReqnaturerequete(string NR_CODENATUREREQUETE, string NR_LIBELLENATUREREQUETE, string NR_STATUT)
        {
            this.NR_CODENATUREREQUETE = NR_CODENATUREREQUETE;
            this.NR_LIBELLENATUREREQUETE = NR_LIBELLENATUREREQUETE;
            this.NR_STATUT = NR_STATUT;
        }
        public clsReqnaturerequete(clsReqnaturerequete clsReqnaturerequete)
        {
            this.NR_CODENATUREREQUETE = clsReqnaturerequete.NR_CODENATUREREQUETE;
            this.NR_LIBELLENATUREREQUETE = clsReqnaturerequete.NR_LIBELLENATUREREQUETE;
            this.NR_STATUT = clsReqnaturerequete.NR_STATUT;
        }

        #endregion

    }
}
