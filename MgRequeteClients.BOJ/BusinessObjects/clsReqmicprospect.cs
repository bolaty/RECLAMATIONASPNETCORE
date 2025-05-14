using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqmicprospect
    {
        #region VARIABLES LOCALES

        private string _PR_IDPROSPECT = "";
        private string _AG_CODEAGENCE = "";
        private string _PV_CODEPOINTVENTE = "";
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private DateTime _PR_DATESAISIE = DateTime.Parse("01/01/1900");
        private string _PR_REGISTRECOMMERCE = "";
        private string _PR_NUMEROCOMPTECONTRIBUABLE = "";
        private string _TYPEOPERATION = "";

        #endregion

        #region ACCESSEURS

        public string PR_IDPROSPECT
        {
            get { return _PR_IDPROSPECT; }
            set { _PR_IDPROSPECT = value; }
        }

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public string PV_CODEPOINTVENTE
        {
            get { return _PV_CODEPOINTVENTE; }
            set { _PV_CODEPOINTVENTE = value; }
        }

        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
        }

        public DateTime PR_DATESAISIE
        {
            get { return _PR_DATESAISIE; }
            set { _PR_DATESAISIE = value; }
        }

        public string PR_REGISTRECOMMERCE
        {
            get { return _PR_REGISTRECOMMERCE; }
            set { _PR_REGISTRECOMMERCE = value; }
        }

        public string PR_NUMEROCOMPTECONTRIBUABLE
        {
            get { return _PR_NUMEROCOMPTECONTRIBUABLE; }
            set { _PR_NUMEROCOMPTECONTRIBUABLE = value; }
        }

        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }
        #endregion

        #region INSTANCIATEURS

        public clsReqmicprospect() { }

        public clsReqmicprospect(clsReqmicprospect clsReqmicprospect)
        {
            this.PR_IDPROSPECT = clsReqmicprospect.PR_IDPROSPECT;
            this.AG_CODEAGENCE = clsReqmicprospect.AG_CODEAGENCE;
            this.PV_CODEPOINTVENTE = clsReqmicprospect.PV_CODEPOINTVENTE;
            this.CU_CODECOMPTEUTULISATEUR = clsReqmicprospect.CU_CODECOMPTEUTULISATEUR;
            this.PR_DATESAISIE = clsReqmicprospect.PR_DATESAISIE;
            this.PR_REGISTRECOMMERCE = clsReqmicprospect.PR_REGISTRECOMMERCE;
            this.PR_NUMEROCOMPTECONTRIBUABLE = clsReqmicprospect.PR_NUMEROCOMPTECONTRIBUABLE;
            this.TYPEOPERATION = clsReqmicprospect.TYPEOPERATION;
        }

        #endregion

    }
}
