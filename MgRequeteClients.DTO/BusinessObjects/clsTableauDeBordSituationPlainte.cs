using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsTableauDeBordSituationPlainte
    {
        #region VARIABLES LOCALES


        private string _LIBELLERUBRIQUE = "";
        private string _TOTALPLAINTERECUES = "0";
        private string _TOTALPLAINTETRAITES = "0";
        private string _AVISCLIENTFAVORABLE = "0";
        private string _AVISCLIENTNONFAVORABLE = "0";
        private string _TAUXSATISFACTION = "0";

        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        #endregion

        #region ACCESSEURS

        public string LIBELLERUBRIQUE
        {
            get { return _LIBELLERUBRIQUE; }
            set { _LIBELLERUBRIQUE = value; }
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

        public clsTableauDeBordSituationPlainte() { }

        public clsTableauDeBordSituationPlainte(clsTableauDeBordSituationPlainte clsTableauDeBordSituationPlainte)
        {
            this.TOTALPLAINTERECUES = clsTableauDeBordSituationPlainte.TOTALPLAINTERECUES;
            this.LIBELLERUBRIQUE = clsTableauDeBordSituationPlainte.LIBELLERUBRIQUE;

            this.TOTALPLAINTETRAITES = clsTableauDeBordSituationPlainte.TOTALPLAINTETRAITES;
            this.AVISCLIENTFAVORABLE = clsTableauDeBordSituationPlainte.AVISCLIENTFAVORABLE;
            this.AVISCLIENTNONFAVORABLE = clsTableauDeBordSituationPlainte.AVISCLIENTNONFAVORABLE;
            this.TAUXSATISFACTION = clsTableauDeBordSituationPlainte.TAUXSATISFACTION;


            this.clsResultat = clsTableauDeBordSituationPlainte.clsResultat;
            this.clsObjetEnvoi = clsTableauDeBordSituationPlainte.clsObjetEnvoi;
        }

        #endregion

    }
}
