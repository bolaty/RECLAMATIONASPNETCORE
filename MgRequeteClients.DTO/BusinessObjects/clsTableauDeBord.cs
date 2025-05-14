using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsTableauDeBord
    {
        #region VARIABLES LOCALES
        List<clsTableauDeBordTauxSatisfaction> _clsTableauDeBordTauxSatisfactions = null;
        List<clsTableauDeBordSituationPlainte> _clsTableauDeBordSituationPlaintes = null;
        List<clsTableauDeBordAutre> _clsTableauDeBordDelaiTraiPlaintes = null;
        List<clsTableauDeBordAutre> _clsTableauDeBordNatPlainteRecurs = null;
        List<clsTableauDeBordAutre> _clsTableauDeBordNbrePlainterefs = null;
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        #endregion

        #region ACCESSEURS



        public List<clsTableauDeBordTauxSatisfaction> clsTableauDeBordTauxSatisfactions
        {
            get { return _clsTableauDeBordTauxSatisfactions; }
            set { _clsTableauDeBordTauxSatisfactions = value; }
        }
        public List<clsTableauDeBordSituationPlainte> clsTableauDeBordSituationPlaintes
        {
            get { return _clsTableauDeBordSituationPlaintes; }
            set { _clsTableauDeBordSituationPlaintes = value; }
        }
        public List<clsTableauDeBordAutre> clsTableauDeBordDelaiTraiPlaintes
        {
            get { return _clsTableauDeBordDelaiTraiPlaintes; }
            set { _clsTableauDeBordDelaiTraiPlaintes = value; }
        }
        public List<clsTableauDeBordAutre> clsTableauDeBordNatPlainteRecurs
        {
            get { return _clsTableauDeBordNatPlainteRecurs; }
            set { _clsTableauDeBordNatPlainteRecurs = value; }
        }
        public List<clsTableauDeBordAutre> clsTableauDeBordNbrePlainterefs
        {
            get { return _clsTableauDeBordNbrePlainterefs; }
            set { _clsTableauDeBordNbrePlainterefs = value; }
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

        public clsTableauDeBord() { }

        public clsTableauDeBord(clsTableauDeBord clsTableauDeBord)
        {
            this.clsTableauDeBordTauxSatisfactions = clsTableauDeBord.clsTableauDeBordTauxSatisfactions;
            this.clsTableauDeBordSituationPlaintes = clsTableauDeBord.clsTableauDeBordSituationPlaintes;
            this.clsTableauDeBordDelaiTraiPlaintes = clsTableauDeBord.clsTableauDeBordDelaiTraiPlaintes;
            this.clsTableauDeBordNatPlainteRecurs = clsTableauDeBord.clsTableauDeBordNatPlainteRecurs;
            this.clsTableauDeBordNbrePlainterefs = clsTableauDeBord.clsTableauDeBordNbrePlainterefs;
            this.clsResultat = clsTableauDeBord.clsResultat;
            this.clsObjetEnvoi = clsTableauDeBord.clsObjetEnvoi;
        }

        #endregion

    }
}
