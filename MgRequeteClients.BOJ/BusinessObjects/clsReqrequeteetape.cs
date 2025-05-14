using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqrequeteetape
    {
        #region VARIABLES LOCALES

        private string _AT_INDEXETAPE = "";
        private string _AG_CODEAGENCE = "";
        private string _RQ_CODEREQUETE = "";
        private string _CU_CODECOMPTEUTULISATEURAGENTENCHARGE = "";
        private string _RE_CODEETAPE = "";
        private int _AT_NUMEROORDRE = 0;
        private string _AT_DESCRIPTION = "";
        private DateTime _RQ_DATESAISIE = DateTime.Parse("01/01/1900");
        private DateTime _AT_DATEDEBUTTRAITEMENTETAPE = DateTime.Parse("01/01/1900");
        private DateTime _AT_DATEFINTRAITEMENTETAPE = DateTime.Parse("01/01/1900");
        private DateTime _AT_DATECLOTUREETAPE = DateTime.Parse("01/01/1900");
        private string _NS_CODENIVEAUSATISFACTION = "";
        private string _AT_OBSERVATION = "";
        private string _AT_NOMRAPPORT = "";

        private string _TYPEOPERATION = "";
        private string _AT_ACTIF = "";

        #endregion

        #region ACCESSEURS

        public string AT_INDEXETAPE
        {
            get { return _AT_INDEXETAPE; }
            set { _AT_INDEXETAPE = value; }
        }

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public string RQ_CODEREQUETE
        {
            get { return _RQ_CODEREQUETE; }
            set { _RQ_CODEREQUETE = value; }
        }

        public string CU_CODECOMPTEUTULISATEURAGENTENCHARGE
        {
            get { return _CU_CODECOMPTEUTULISATEURAGENTENCHARGE; }
            set { _CU_CODECOMPTEUTULISATEURAGENTENCHARGE = value; }
        }

        public string RE_CODEETAPE
        {
            get { return _RE_CODEETAPE; }
            set { _RE_CODEETAPE = value; }
        }

        public int AT_NUMEROORDRE
        {
            get { return _AT_NUMEROORDRE; }
            set { _AT_NUMEROORDRE = value; }
        }

        public string AT_DESCRIPTION
        {
            get { return _AT_DESCRIPTION; }
            set { _AT_DESCRIPTION = value; }
        }

        public DateTime RQ_DATESAISIE
        {
            get { return _RQ_DATESAISIE; }
            set { _RQ_DATESAISIE = value; }
        }

        public DateTime AT_DATEDEBUTTRAITEMENTETAPE
        {
            get { return _AT_DATEDEBUTTRAITEMENTETAPE; }
            set { _AT_DATEDEBUTTRAITEMENTETAPE = value; }
        }

        public DateTime AT_DATEFINTRAITEMENTETAPE
        {
            get { return _AT_DATEFINTRAITEMENTETAPE; }
            set { _AT_DATEFINTRAITEMENTETAPE = value; }
        }

        public DateTime AT_DATECLOTUREETAPE
        {
            get { return _AT_DATECLOTUREETAPE; }
            set { _AT_DATECLOTUREETAPE = value; }
        }

        public string NS_CODENIVEAUSATISFACTION
        {
            get { return _NS_CODENIVEAUSATISFACTION; }
            set { _NS_CODENIVEAUSATISFACTION = value; }
        }


        public string AT_OBSERVATION
        {
            get { return _AT_OBSERVATION; }
            set { _AT_OBSERVATION = value; }
        }

        public string AT_NOMRAPPORT
        {
            get { return _AT_NOMRAPPORT; }
            set { _AT_NOMRAPPORT = value; }
        }

        public string AT_ACTIF
        {
            get { return _AT_ACTIF; }
            set { _AT_ACTIF = value; }
        }

        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsReqrequeteetape() { }

        public clsReqrequeteetape(clsReqrequeteetape clsReqrequeteetape)
        {
            this.AT_INDEXETAPE = clsReqrequeteetape.AT_INDEXETAPE;
            this.AG_CODEAGENCE = clsReqrequeteetape.AG_CODEAGENCE;
            this.RQ_CODEREQUETE = clsReqrequeteetape.RQ_CODEREQUETE;
            this.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = clsReqrequeteetape.CU_CODECOMPTEUTULISATEURAGENTENCHARGE;
            this.RE_CODEETAPE = clsReqrequeteetape.RE_CODEETAPE;
            this.AT_NUMEROORDRE = clsReqrequeteetape.AT_NUMEROORDRE;
            this.AT_DESCRIPTION = clsReqrequeteetape.AT_DESCRIPTION;
            this.RQ_DATESAISIE = clsReqrequeteetape.RQ_DATESAISIE;
            this.AT_DATEDEBUTTRAITEMENTETAPE = clsReqrequeteetape.AT_DATEDEBUTTRAITEMENTETAPE;
            this.AT_DATEFINTRAITEMENTETAPE = clsReqrequeteetape.AT_DATEFINTRAITEMENTETAPE;
            this.AT_DATECLOTUREETAPE = clsReqrequeteetape.AT_DATECLOTUREETAPE;
            this.NS_CODENIVEAUSATISFACTION = clsReqrequeteetape.NS_CODENIVEAUSATISFACTION;

            this.AT_OBSERVATION = clsReqrequeteetape.AT_OBSERVATION;
            this.AT_NOMRAPPORT = clsReqrequeteetape.AT_NOMRAPPORT;
            this.TYPEOPERATION = clsReqrequeteetape.TYPEOPERATION;

            this.AT_ACTIF = clsReqrequeteetape.AT_ACTIF;
        }

        #endregion

    }
}
