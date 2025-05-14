using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqmicclient
    {
        #region VARIABLES LOCALES

        private string _CL_IDCLIENT = "";
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _CL_CODECLIENT = "";
        private string _CL_CODECLIENTZENITH = "";
        private string _AG_CODEAGENCE = "";
        private string _PV_CODEPOINTVENTE = "";
        private DateTime _CL_DATESAISIE = DateTime.Parse("01/01/1900");
        private string _CL_REGISTRECOMMERCE = "";
        private string _CL_NUMEROCOMPTECONTRIBUABLE = "";
        private string _TYPEOPERATION = "";

        #endregion

        #region ACCESSEURS

        public string CL_IDCLIENT
        {
            get { return _CL_IDCLIENT; }
            set { _CL_IDCLIENT = value; }
        }
        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
        }
        public string CL_CODECLIENT
        {
            get { return _CL_CODECLIENT; }
            set { _CL_CODECLIENT = value; }
        }

        public string CL_CODECLIENTZENITH
        {
            get { return _CL_CODECLIENTZENITH; }
            set { _CL_CODECLIENTZENITH = value; }
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

        public DateTime CL_DATESAISIE
        {
            get { return _CL_DATESAISIE; }
            set { _CL_DATESAISIE = value; }
        }

        public string CL_REGISTRECOMMERCE
        {
            get { return _CL_REGISTRECOMMERCE; }
            set { _CL_REGISTRECOMMERCE = value; }
        }

        public string CL_NUMEROCOMPTECONTRIBUABLE
        {
            get { return _CL_NUMEROCOMPTECONTRIBUABLE; }
            set { _CL_NUMEROCOMPTECONTRIBUABLE = value; }
        }
        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsReqmicclient() { }

        public clsReqmicclient(clsReqmicclient clsReqmicclient)
        {
            this.CL_IDCLIENT = clsReqmicclient.CL_IDCLIENT;
            this.CU_CODECOMPTEUTULISATEUR = clsReqmicclient.CU_CODECOMPTEUTULISATEUR;
            this.CL_CODECLIENT = clsReqmicclient.CL_CODECLIENT;
            this.CL_CODECLIENTZENITH = clsReqmicclient.CL_CODECLIENTZENITH;
            this.AG_CODEAGENCE = clsReqmicclient.AG_CODEAGENCE;
            this.PV_CODEPOINTVENTE = clsReqmicclient.PV_CODEPOINTVENTE;
            this.CL_DATESAISIE = clsReqmicclient.CL_DATESAISIE;
            this.CL_REGISTRECOMMERCE = clsReqmicclient.CL_REGISTRECOMMERCE;
            this.CL_NUMEROCOMPTECONTRIBUABLE = clsReqmicclient.CL_NUMEROCOMPTECONTRIBUABLE;
            this.TYPEOPERATION = clsReqmicclient.TYPEOPERATION;
        }

        #endregion
    }
}
