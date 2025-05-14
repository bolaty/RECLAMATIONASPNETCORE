using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.BOJ.BusinessObjects;
using MgRequeteClients.DAL.Classes;
using MgRequeteClients.Tools.Classes;

namespace MgRequeteClients.BLL.Classes
{
    public class clsEditionWSBLL
    {
        private clsEditionWSDAL clsEditionWSDAL = new clsEditionWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();


        string bvlErreurMiseAjour;


        public DataSet pvgInsertIntoDatasetZone(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetZone(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetAgence(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetAgence(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetExercice(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetExercice(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetPeriodicite(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetPeriodicite(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetPeriode(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetPeriode(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgPeriodicite(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgPeriodicite(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgPeriodiciteDateDebutFin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgPeriodiciteDateDebutFin(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetSociete(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetSociete(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetTESTSOCIETE(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetTESTSOCIETE(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetTESTZONE(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetTESTZONE(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetTestAgence(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetTestAgence(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgEnteteDesEtats(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgEnteteDesEtats(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgChargerDansDataSetPourComboAgenceEdition(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgChargerDansDataSetPourComboAgenceEdition(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetDroitUtilisateur(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsEditionWSDAL.pvgInsertIntoDatasetDroitUtilisateurlist(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
    }
}
