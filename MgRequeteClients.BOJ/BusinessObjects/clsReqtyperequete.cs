using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqtyperequete
    {
        #region VARIABLES LOCALES

        private string _TR_CODETYEREQUETE = "";
        private string _NR_CODENATUREREQUETE = "";
        private string _TR_LIBELLETYEREQUETE = "";
        private string _TR_STATUT = "";

        #endregion

        #region ACCESSEURS

        public string TR_CODETYEREQUETE
        {
            get { return _TR_CODETYEREQUETE; }
            set { _TR_CODETYEREQUETE = value; }
        }

        public string NR_CODENATUREREQUETE
        {
            get { return _NR_CODENATUREREQUETE; }
            set { _NR_CODENATUREREQUETE = value; }
        }

        public string TR_LIBELLETYEREQUETE
        {
            get { return _TR_LIBELLETYEREQUETE; }
            set { _TR_LIBELLETYEREQUETE = value; }
        }

        public string TR_STATUT
        {
            get { return _TR_STATUT; }
            set { _TR_STATUT = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsReqtyperequete() { }
        public clsReqtyperequete(string TR_CODETYEREQUETE, string NR_CODENATUREREQUETE, string TR_LIBELLETYEREQUETE, string TR_STATUT)
        {
            this.TR_CODETYEREQUETE = TR_CODETYEREQUETE;
            this.NR_CODENATUREREQUETE = NR_CODENATUREREQUETE;
            this.TR_LIBELLETYEREQUETE = TR_LIBELLETYEREQUETE;
            this.TR_STATUT = TR_STATUT;
        }
        public clsReqtyperequete(clsReqtyperequete clsReqtyperequete)
        {
            this.TR_CODETYEREQUETE = clsReqtyperequete.TR_CODETYEREQUETE;
            this.NR_CODENATUREREQUETE = clsReqtyperequete.NR_CODENATUREREQUETE;
            this.TR_LIBELLETYEREQUETE = clsReqtyperequete.TR_LIBELLETYEREQUETE;
            this.TR_STATUT = clsReqtyperequete.TR_STATUT;
        }

        #endregion

    }
}
