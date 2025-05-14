using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqrequeteetape
    {
        #region VARIABLES LOCALES

        private string _AT_INDEXETAPE = "";
        private string _AG_CODEAGENCE = "";
        private string _RQ_CODEREQUETE = "";
        private string _CU_CODECOMPTEUTULISATEURAGENTENCHARGE = "";
        private string _RE_CODEETAPE = "";
        private string _AT_NUMEROORDRE = "0";
        private string _AT_DESCRIPTION = "";
        private string _RQ_DATESAISIE = "01/01/1900";
        private string _AT_DATEDEBUTTRAITEMENTETAPE = "01/01/1900";
        private string _AT_DATEFINTRAITEMENTETAPE = "01/01/1900";
        private string _AT_DATECLOTUREETAPE = "01/01/1900";
        private string _NS_CODENIVEAUSATISFACTION = "";

        private string _AT_OBSERVATION = "";
        private string _AT_NOMRAPPORT = "";
        private string _RQ_OBSERVATIONANNULATIONCLOTUREDEFINITIVE = "";
        private string _RQ_OBSERVATIONCLOTUREDEFINITIVE = "";
        private string _AT_ACTIF = "";

        private string _CU_NOMUTILISATEUR = "";
        private string _CU_CONTACT = "";
        private string _CU_EMAIL = "";

        private List<clsDocEtapesDetail> _clsDocEtapesDetails = null;

        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        #endregion

        #region ACCESSEURS


        public List<clsDocEtapesDetail> clsDocEtapesDetails
        {
            get { return _clsDocEtapesDetails; }
            set { _clsDocEtapesDetails = value; }
        }

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

        public string AT_NUMEROORDRE
        {
            get { return _AT_NUMEROORDRE; }
            set { _AT_NUMEROORDRE = value; }
        }

        public string AT_DESCRIPTION
        {
            get { return _AT_DESCRIPTION; }
            set { _AT_DESCRIPTION = value; }
        }

        public string RQ_DATESAISIE
        {
            get { return _RQ_DATESAISIE; }
            set { _RQ_DATESAISIE = value; }
        }

        public string AT_DATEDEBUTTRAITEMENTETAPE
        {
            get { return _AT_DATEDEBUTTRAITEMENTETAPE; }
            set { _AT_DATEDEBUTTRAITEMENTETAPE = value; }
        }

        public string AT_DATEFINTRAITEMENTETAPE
        {
            get { return _AT_DATEFINTRAITEMENTETAPE; }
            set { _AT_DATEFINTRAITEMENTETAPE = value; }
        }

        public string AT_DATECLOTUREETAPE
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

        public string RQ_OBSERVATIONCLOTUREDEFINITIVE
        {
            get { return _RQ_OBSERVATIONCLOTUREDEFINITIVE; }
            set { _RQ_OBSERVATIONCLOTUREDEFINITIVE = value; }
        }

        public string RQ_OBSERVATIONANNULATIONCLOTUREDEFINITIVE
        {
            get { return _RQ_OBSERVATIONANNULATIONCLOTUREDEFINITIVE; }
            set { _RQ_OBSERVATIONANNULATIONCLOTUREDEFINITIVE = value; }
        }
        public string CU_NOMUTILISATEUR
        {
            get { return _CU_NOMUTILISATEUR; }
            set { _CU_NOMUTILISATEUR = value; }
        }

        public string CU_CONTACT
        {
            get { return _CU_CONTACT; }
            set { _CU_CONTACT = value; }
        }

        public string CU_EMAIL
        {
            get { return _CU_EMAIL; }
            set { _CU_EMAIL = value; }
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
            this.RQ_OBSERVATIONCLOTUREDEFINITIVE = clsReqrequeteetape.RQ_OBSERVATIONCLOTUREDEFINITIVE;
            this.RQ_OBSERVATIONANNULATIONCLOTUREDEFINITIVE = clsReqrequeteetape.RQ_OBSERVATIONANNULATIONCLOTUREDEFINITIVE;
            this.AT_ACTIF = clsReqrequeteetape.AT_ACTIF;

            this.CU_NOMUTILISATEUR = clsReqrequeteetape.CU_NOMUTILISATEUR;
            this.CU_CONTACT = clsReqrequeteetape.CU_CONTACT;
            this.CU_EMAIL = clsReqrequeteetape.CU_EMAIL;

            this.clsDocEtapesDetails = clsReqrequeteetape.clsDocEtapesDetails;

            this.clsResultat = clsReqrequeteetape.clsResultat;
            this.clsObjetEnvoi = clsReqrequeteetape.clsObjetEnvoi;
        }

        #endregion

    }
}
