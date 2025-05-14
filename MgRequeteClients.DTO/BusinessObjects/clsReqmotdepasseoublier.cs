using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqmotdepasseoublier
    {
        #region VARIABLES LOCALES

        private string _AG_CODEAGENCE = "";
        private string _MO_DATE = "01/01/1900";
        private string _MO_NUMEROSEQUENCE = "0";
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _MO_CONTACT = "";
        private string _MO_HEURE = "01/01/1900";
        private string _MO_CODEVALIDATION = "";
        private string _MO_DATEVALIDATION = "01/01/1900";


        private string _TU_CODETYPEUTILISATEUR = "";
        private string _CU_MOTDEPASSE = "";

        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        #endregion

        #region ACCESSEURS

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public string MO_DATE
        {
            get { return _MO_DATE; }
            set { _MO_DATE = value; }
        }

        public string MO_NUMEROSEQUENCE
        {
            get { return _MO_NUMEROSEQUENCE; }
            set { _MO_NUMEROSEQUENCE = value; }
        }

        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
        }

        public string MO_CONTACT
        {
            get { return _MO_CONTACT; }
            set { _MO_CONTACT = value; }
        }

        public string MO_HEURE
        {
            get { return _MO_HEURE; }
            set { _MO_HEURE = value; }
        }

        public string MO_CODEVALIDATION
        {
            get { return _MO_CODEVALIDATION; }
            set { _MO_CODEVALIDATION = value; }
        }


        public string TU_CODETYPEUTILISATEUR
        {
            get { return _TU_CODETYPEUTILISATEUR; }
            set { _TU_CODETYPEUTILISATEUR = value; }
        }
        public string CU_MOTDEPASSE
        {
            get { return _CU_MOTDEPASSE; }
            set { _CU_MOTDEPASSE = value; }
        }

        public string MO_DATEVALIDATION
        {
            get { return _MO_DATEVALIDATION; }
            set { _MO_DATEVALIDATION = value; }
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

        public clsReqmotdepasseoublier() { }

        public clsReqmotdepasseoublier(clsReqmotdepasseoublier clsReqmotdepasseoublier)
        {
            this.AG_CODEAGENCE = clsReqmotdepasseoublier.AG_CODEAGENCE;
            this.MO_DATE = clsReqmotdepasseoublier.MO_DATE;
            this.MO_NUMEROSEQUENCE = clsReqmotdepasseoublier.MO_NUMEROSEQUENCE;
            this.CU_CODECOMPTEUTULISATEUR = clsReqmotdepasseoublier.CU_CODECOMPTEUTULISATEUR;
            this.MO_CONTACT = clsReqmotdepasseoublier.MO_CONTACT;
            this.MO_HEURE = clsReqmotdepasseoublier.MO_HEURE;
            this.MO_CODEVALIDATION = clsReqmotdepasseoublier.MO_CODEVALIDATION;
            this.MO_DATEVALIDATION = clsReqmotdepasseoublier.MO_DATEVALIDATION;
            this.TU_CODETYPEUTILISATEUR = clsReqmotdepasseoublier.TU_CODETYPEUTILISATEUR;
            this.CU_MOTDEPASSE = clsReqmotdepasseoublier.CU_MOTDEPASSE;

            this.clsResultat = clsReqmotdepasseoublier.clsResultat;
            this.clsObjetEnvoi = clsReqmotdepasseoublier.clsObjetEnvoi;
        }

        #endregion

    }
}
