using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqsmsparametretypeoperation
    {
        #region VARIABLES LOCALES

        private string _TE_CODESMSTYPEOPERATION = "";
        private string _TS_CODETYPESCHEMACOMPTABLE = "";
        private string _TE_LIBELLE = "";
        private string _TE_NATUREOPERATION = "";
        private string _TE_ACTIF = "";

        #endregion

        #region ACCESSEURS

        public string TE_CODESMSTYPEOPERATION
        {
            get { return _TE_CODESMSTYPEOPERATION; }
            set { _TE_CODESMSTYPEOPERATION = value; }
        }

        public string TS_CODETYPESCHEMACOMPTABLE
        {
            get { return _TS_CODETYPESCHEMACOMPTABLE; }
            set { _TS_CODETYPESCHEMACOMPTABLE = value; }
        }

        public string TE_LIBELLE
        {
            get { return _TE_LIBELLE; }
            set { _TE_LIBELLE = value; }
        }

        public string TE_NATUREOPERATION
        {
            get { return _TE_NATUREOPERATION; }
            set { _TE_NATUREOPERATION = value; }
        }

        public string TE_ACTIF
        {
            get { return _TE_ACTIF; }
            set { _TE_ACTIF = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsReqsmsparametretypeoperation() { }
        public clsReqsmsparametretypeoperation(string TE_CODESMSTYPEOPERATION, string TS_CODETYPESCHEMACOMPTABLE, string TE_LIBELLE, string TE_NATUREOPERATION, string TE_ACTIF)
        {
            this.TE_CODESMSTYPEOPERATION = TE_CODESMSTYPEOPERATION;
            this.TS_CODETYPESCHEMACOMPTABLE = TS_CODETYPESCHEMACOMPTABLE;
            this.TE_LIBELLE = TE_LIBELLE;
            this.TE_NATUREOPERATION = TE_NATUREOPERATION;
            this.TE_ACTIF = TE_ACTIF;
        }
        public clsReqsmsparametretypeoperation(clsReqsmsparametretypeoperation clsReqsmsparametretypeoperation)
        {
            this.TE_CODESMSTYPEOPERATION = clsReqsmsparametretypeoperation.TE_CODESMSTYPEOPERATION;
            this.TS_CODETYPESCHEMACOMPTABLE = clsReqsmsparametretypeoperation.TS_CODETYPESCHEMACOMPTABLE;
            this.TE_LIBELLE = clsReqsmsparametretypeoperation.TE_LIBELLE;
            this.TE_NATUREOPERATION = clsReqsmsparametretypeoperation.TE_NATUREOPERATION;
            this.TE_ACTIF = clsReqsmsparametretypeoperation.TE_ACTIF;
        }

        #endregion
    }
}
