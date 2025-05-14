using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqmodecollecte
    {
        #region VARIABLES LOCALES

        private string _MC_CODEMODECOLLETE = "";
        private string _MC_LIBELLEMODECOLLETE = "";
        private string _MC_STATUT = "";

        #endregion

        #region ACCESSEURS

        public string MC_CODEMODECOLLETE
        {
            get { return _MC_CODEMODECOLLETE; }
            set { _MC_CODEMODECOLLETE = value; }
        }

        public string MC_LIBELLEMODECOLLETE
        {
            get { return _MC_LIBELLEMODECOLLETE; }
            set { _MC_LIBELLEMODECOLLETE = value; }
        }

        public string MC_STATUT
        {
            get { return _MC_STATUT; }
            set { _MC_STATUT = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsReqmodecollecte() { }
        public clsReqmodecollecte(string MC_CODEMODECOLLETE, string MC_LIBELLEMODECOLLETE, string MC_STATUT)
        {
            this.MC_CODEMODECOLLETE = MC_CODEMODECOLLETE;
            this.MC_LIBELLEMODECOLLETE = MC_LIBELLEMODECOLLETE;
            this.MC_STATUT = MC_STATUT;
        }
        public clsReqmodecollecte(clsReqmodecollecte clsReqmodecollecte)
        {
            this.MC_CODEMODECOLLETE = clsReqmodecollecte.MC_CODEMODECOLLETE;
            this.MC_LIBELLEMODECOLLETE = clsReqmodecollecte.MC_LIBELLEMODECOLLETE;
            this.MC_STATUT = clsReqmodecollecte.MC_STATUT;
        }

        #endregion

    }
}
