using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqtontineepargnantjournalier
    {
        #region VARIABLES LOCALES

        private string _EJ_IDEPARGNANTJOURNALIER = "";
        private string _EJ_CODEEPARGNANTJOURNALIERZENITH = "";
        private string _AG_CODEAGENCE = "";
        private string _PV_CODEPOINTVENTE = "";
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _EJ_DATESAISIE = "01/01/1900";

        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        #endregion

        #region ACCESSEURS

        public string EJ_IDEPARGNANTJOURNALIER
        {
            get { return _EJ_IDEPARGNANTJOURNALIER; }
            set { _EJ_IDEPARGNANTJOURNALIER = value; }
        }

        public string EJ_CODEEPARGNANTJOURNALIERZENITH
        {
            get { return _EJ_CODEEPARGNANTJOURNALIERZENITH; }
            set { _EJ_CODEEPARGNANTJOURNALIERZENITH = value; }
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

        public string EJ_DATESAISIE
        {
            get { return _EJ_DATESAISIE; }
            set { _EJ_DATESAISIE = value; }
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

        public clsReqtontineepargnantjournalier() { }

        public clsReqtontineepargnantjournalier(clsReqtontineepargnantjournalier clsReqtontineepargnantjournalier)
        {
            this.EJ_IDEPARGNANTJOURNALIER = clsReqtontineepargnantjournalier.EJ_IDEPARGNANTJOURNALIER;
            this.EJ_CODEEPARGNANTJOURNALIERZENITH = clsReqtontineepargnantjournalier.EJ_CODEEPARGNANTJOURNALIERZENITH;
            this.AG_CODEAGENCE = clsReqtontineepargnantjournalier.AG_CODEAGENCE;
            this.PV_CODEPOINTVENTE = clsReqtontineepargnantjournalier.PV_CODEPOINTVENTE;
            this.CU_CODECOMPTEUTULISATEUR = clsReqtontineepargnantjournalier.CU_CODECOMPTEUTULISATEUR;
            this.EJ_DATESAISIE = clsReqtontineepargnantjournalier.EJ_DATESAISIE;

            this.clsResultat = clsReqtontineepargnantjournalier.clsResultat;
            this.clsObjetEnvoi = clsReqtontineepargnantjournalier.clsObjetEnvoi;
        }

        #endregion
    }
}
