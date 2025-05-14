using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqemailparametretypeoperation
    {
        #region VARIABLES LOCALES

        private string _PW_CODEWEBTYPEOPERATION = "";
        private string _PW_LIBELLE = "";
        private string _PW_ACTIF = "";

        #endregion

        #region ACCESSEURS

        public string PW_CODEWEBTYPEOPERATION
        {
            get { return _PW_CODEWEBTYPEOPERATION; }
            set { _PW_CODEWEBTYPEOPERATION = value; }
        }

        public string PW_LIBELLE
        {
            get { return _PW_LIBELLE; }
            set { _PW_LIBELLE = value; }
        }

        public string PW_ACTIF
        {
            get { return _PW_ACTIF; }
            set { _PW_ACTIF = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsReqemailparametretypeoperation() { }
        public clsReqemailparametretypeoperation(string PW_CODEWEBTYPEOPERATION, string PW_LIBELLE, string PW_ACTIF)
        {
            this.PW_CODEWEBTYPEOPERATION = PW_CODEWEBTYPEOPERATION;
            this.PW_LIBELLE = PW_LIBELLE;
            this.PW_ACTIF = PW_ACTIF;
        }
        public clsReqemailparametretypeoperation(clsReqemailparametretypeoperation clsReqemailparametretypeoperation)
        {
            this.PW_CODEWEBTYPEOPERATION = clsReqemailparametretypeoperation.PW_CODEWEBTYPEOPERATION;
            this.PW_LIBELLE = clsReqemailparametretypeoperation.PW_LIBELLE;
            this.PW_ACTIF = clsReqemailparametretypeoperation.PW_ACTIF;
        }

        #endregion

    }
}
