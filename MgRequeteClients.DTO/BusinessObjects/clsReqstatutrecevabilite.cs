using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqstatutrecevabilite
    {
        #region VARIABLES LOCALES

        private string _RS_CODESTATUTRECEVABILITE = "";
        private string _RS_LIBELLESTATUTRECEVABILITE = "";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;
        #endregion

        #region ACCESSEURS

        public string RS_CODESTATUTRECEVABILITE
        {
            get { return _RS_CODESTATUTRECEVABILITE; }
            set { _RS_CODESTATUTRECEVABILITE = value; }
        }

        public string RS_LIBELLESTATUTRECEVABILITE
        {
            get { return _RS_LIBELLESTATUTRECEVABILITE; }
            set { _RS_LIBELLESTATUTRECEVABILITE = value; }
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

        public clsReqstatutrecevabilite() { }
        public clsReqstatutrecevabilite(string RS_CODESTATUTRECEVABILITE, string RS_LIBELLESTATUTRECEVABILITE)
        {
            this.RS_CODESTATUTRECEVABILITE = RS_CODESTATUTRECEVABILITE;
            this.RS_LIBELLESTATUTRECEVABILITE = RS_LIBELLESTATUTRECEVABILITE;

        }
        public clsReqstatutrecevabilite(clsReqstatutrecevabilite clsReqstatutrecevabilite)
        {
            this.RS_CODESTATUTRECEVABILITE = clsReqstatutrecevabilite.RS_CODESTATUTRECEVABILITE;
            this.RS_LIBELLESTATUTRECEVABILITE = clsReqstatutrecevabilite.RS_LIBELLESTATUTRECEVABILITE;
            this.clsResultat = clsReqstatutrecevabilite.clsResultat;
            this.clsObjetEnvoi = clsReqstatutrecevabilite.clsObjetEnvoi;
        }

        #endregion

    }
}
