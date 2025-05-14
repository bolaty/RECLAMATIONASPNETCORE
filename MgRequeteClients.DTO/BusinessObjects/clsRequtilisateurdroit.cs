using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsRequtilisateurdroit
    {
        #region VARIABLES LOCALES

        private string _DP_CODEDROITCOMPTEUTULISATEUR = "";
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _DP_LIBELLEDROITCOMPTEUTULISATEUR = "";
        private string _DP_COCHER = "";
        private string _TYPEOPERATION = "";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        #endregion

        #region ACCESSEURS

        public string DP_CODEDROITCOMPTEUTULISATEUR
        {
            get { return _DP_CODEDROITCOMPTEUTULISATEUR; }
            set { _DP_CODEDROITCOMPTEUTULISATEUR = value; }
        }

        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
        }

        public string DP_LIBELLEDROITCOMPTEUTULISATEUR
        {
            get { return _DP_LIBELLEDROITCOMPTEUTULISATEUR; }
            set { _DP_LIBELLEDROITCOMPTEUTULISATEUR = value; }
        }
        public string DP_COCHER
        {
            get { return _DP_COCHER; }
            set { _DP_COCHER = value; }
        }

        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
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

        public clsRequtilisateurdroit() { }

        public clsRequtilisateurdroit(clsRequtilisateurdroit clsRequtilisateurdroit)
        {
            this.DP_CODEDROITCOMPTEUTULISATEUR = clsRequtilisateurdroit.DP_CODEDROITCOMPTEUTULISATEUR;
            this.CU_CODECOMPTEUTULISATEUR = clsRequtilisateurdroit.CU_CODECOMPTEUTULISATEUR;
            this.DP_LIBELLEDROITCOMPTEUTULISATEUR = clsRequtilisateurdroit.DP_LIBELLEDROITCOMPTEUTULISATEUR;
            this.DP_COCHER = clsRequtilisateurdroit.DP_COCHER;
            this.TYPEOPERATION = clsRequtilisateurdroit.TYPEOPERATION;

            this.clsResultat = clsRequtilisateurdroit.clsResultat;
            this.clsObjetEnvoi = clsRequtilisateurdroit.clsObjetEnvoi;
        }

        #endregion
    }
}
