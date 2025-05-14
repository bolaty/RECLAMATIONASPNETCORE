using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsRequtilisateurdroitparametre
    {
        #region VARIABLES LOCALES

        private string _DP_CODEDROITCOMPTEUTULISATEUR = "";
        private string _DP_LIBELLEDROITCOMPTEUTULISATEUR = "";
        private string _DP_STATUT = "";
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _DP_OBJET = "";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;
        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";
        private string _SL_CODEMESSAGE = "";

        #endregion

        #region ACCESSEURS
        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
        }
        public string DP_CODEDROITCOMPTEUTULISATEUR
        {
            get { return _DP_CODEDROITCOMPTEUTULISATEUR; }
            set { _DP_CODEDROITCOMPTEUTULISATEUR = value; }
        }

        public string DP_LIBELLEDROITCOMPTEUTULISATEUR
        {
            get { return _DP_LIBELLEDROITCOMPTEUTULISATEUR; }
            set { _DP_LIBELLEDROITCOMPTEUTULISATEUR = value; }
        }

        public string DP_OBJET
        {
            get { return _DP_OBJET; }
            set { _DP_OBJET = value; }
        }
        public string DP_STATUT
        {
            get { return _DP_STATUT; }
            set { _DP_STATUT = value; }
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
        public string SL_RESULTAT
        {
            get { return _SL_RESULTAT; }
            set { _SL_RESULTAT = value; }
        }

        public string SL_MESSAGE
        {
            get { return _SL_MESSAGE; }
            set { _SL_MESSAGE = value; }
        }
        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsRequtilisateurdroitparametre() { }

        public clsRequtilisateurdroitparametre(clsRequtilisateurdroitparametre clsRequtilisateurdroitparametre)
        {
            this.DP_CODEDROITCOMPTEUTULISATEUR = clsRequtilisateurdroitparametre.DP_CODEDROITCOMPTEUTULISATEUR;
            this.DP_LIBELLEDROITCOMPTEUTULISATEUR = clsRequtilisateurdroitparametre.DP_LIBELLEDROITCOMPTEUTULISATEUR;
            this.DP_STATUT = clsRequtilisateurdroitparametre.DP_STATUT;
            this.CU_CODECOMPTEUTULISATEUR = clsRequtilisateurdroitparametre.CU_CODECOMPTEUTULISATEUR;
            this.DP_OBJET = clsRequtilisateurdroitparametre.DP_OBJET;

            this.SL_RESULTAT = clsRequtilisateurdroitparametre.SL_RESULTAT;
            this.SL_MESSAGE = clsRequtilisateurdroitparametre.SL_MESSAGE;
            this.SL_CODEMESSAGE = clsRequtilisateurdroitparametre.SL_CODEMESSAGE;

            this.clsResultat = clsRequtilisateurdroitparametre.clsResultat;
            this.clsObjetEnvoi = clsRequtilisateurdroitparametre.clsObjetEnvoi;
        }

        #endregion

    }
}
