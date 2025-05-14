using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsTableauDeBordTauxSatisfaction
    {
        #region VARIABLES LOCALES


        private string _LIBELLERUBRIQUE = "";
        private string _TOTALPLAINTERECUES = "0";
        private string _TOTALPLAINTETRAITES = "0";
        private string _AVISCLIENTFAVORABLE = "0";
        private string _AVISCLIENTNONFAVORABLE = "0";
        private string _TAUXSATISFACTION = "0";

        private string _TR_LIBELLETYEREQUETE = "";
        private string _TR_CODETYEREQUETE = "";
        private string _NOMBRE = "0";
        private string _NR_CODENATUREREQUETE = "";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        #endregion

        #region ACCESSEURS
        public string LIBELLERUBRIQUE
        {
            get { return _LIBELLERUBRIQUE; }
            set { _LIBELLERUBRIQUE = value; }
        }


        public string TR_LIBELLETYEREQUETE
        {
            get { return _TR_LIBELLETYEREQUETE; }
            set { _TR_LIBELLETYEREQUETE = value; }
        }

        public string NR_CODENATUREREQUETE
        {
            get { return _NR_CODENATUREREQUETE; }
            set { _NR_CODENATUREREQUETE = value; }
        }


        public string NOMBRE
        {
            get { return _NOMBRE; }
            set { _NOMBRE = value; }
        }

        public string TR_CODETYEREQUETE
        {
            get { return _TR_CODETYEREQUETE; }
            set { _TR_CODETYEREQUETE = value; }
        }
        public string TOTALPLAINTERECUES
        {
            get { return _TOTALPLAINTERECUES; }
            set { _TOTALPLAINTERECUES = value; }
        }

        public string TOTALPLAINTETRAITES
        {
            get { return _TOTALPLAINTETRAITES; }
            set { _TOTALPLAINTETRAITES = value; }
        }

        public string AVISCLIENTFAVORABLE
        {
            get { return _AVISCLIENTFAVORABLE; }
            set { _AVISCLIENTFAVORABLE = value; }
        }
        public string AVISCLIENTNONFAVORABLE
        {
            get { return _AVISCLIENTNONFAVORABLE; }
            set { _AVISCLIENTNONFAVORABLE = value; }
        }

        public string TAUXSATISFACTION
        {
            get { return _TAUXSATISFACTION; }
            set { _TAUXSATISFACTION = value; }
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

        public clsTableauDeBordTauxSatisfaction() { }

        public clsTableauDeBordTauxSatisfaction(clsTableauDeBordTauxSatisfaction clsTableauDeBordTauxSatisfaction)
        {
            this.TOTALPLAINTERECUES = clsTableauDeBordTauxSatisfaction.TOTALPLAINTERECUES;
            this.LIBELLERUBRIQUE = clsTableauDeBordTauxSatisfaction.LIBELLERUBRIQUE;

            this.TOTALPLAINTETRAITES = clsTableauDeBordTauxSatisfaction.TOTALPLAINTETRAITES;
            this.AVISCLIENTFAVORABLE = clsTableauDeBordTauxSatisfaction.AVISCLIENTFAVORABLE;
            this.AVISCLIENTNONFAVORABLE = clsTableauDeBordTauxSatisfaction.AVISCLIENTNONFAVORABLE;
            this.TAUXSATISFACTION = clsTableauDeBordTauxSatisfaction.TAUXSATISFACTION;

            this.LIBELLERUBRIQUE = clsTableauDeBordTauxSatisfaction.LIBELLERUBRIQUE;
            this.NOMBRE = clsTableauDeBordTauxSatisfaction.NOMBRE;
            this.TR_LIBELLETYEREQUETE = clsTableauDeBordTauxSatisfaction.TR_LIBELLETYEREQUETE;
            this.NR_CODENATUREREQUETE = clsTableauDeBordTauxSatisfaction.NR_CODENATUREREQUETE;

            this.clsResultat = clsTableauDeBordTauxSatisfaction.clsResultat;
            this.clsObjetEnvoi = clsTableauDeBordTauxSatisfaction.clsObjetEnvoi;
        }

        #endregion

    }
}
