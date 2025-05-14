using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqmodecollecte
    {
        #region VARIABLES LOCALES

        private string _MC_CODEMODECOLLETE = "";
        private string _MC_LIBELLEMODECOLLETE = "";
        private string _MC_STATUT = "";
        private string _MC_LIBELLEMODECOLLETE_TRANSLATE = "";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;
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

        public string MC_LIBELLEMODECOLLETE_TRANSLATE
        {
            get { return _MC_LIBELLEMODECOLLETE_TRANSLATE; }
            set { _MC_LIBELLEMODECOLLETE_TRANSLATE = value; }
        }

        public string MC_STATUT
        {
            get { return _MC_STATUT; }
            set { _MC_STATUT = value; }
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
            this.MC_LIBELLEMODECOLLETE_TRANSLATE = clsReqmodecollecte.MC_LIBELLEMODECOLLETE_TRANSLATE;
            this.clsResultat = clsReqmodecollecte.clsResultat;
            this.clsObjetEnvoi = clsReqmodecollecte.clsObjetEnvoi;
        }

        #endregion

    }
}
