using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsRequtilisateurdroitparametre
    {
        #region VARIABLES LOCALES

        private string _DP_CODEDROITCOMPTEUTULISATEUR = "";
        private string _DP_LIBELLEDROITCOMPTEUTULISATEUR = "";
        private string _DP_STATUT = "";
        private string _DP_OBJET = "";
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _TYPEOPERATION = "";
        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }

        #endregion

        #region ACCESSEURS
        public string DP_OBJET
        {
            get { return _DP_OBJET; }
            set { _DP_OBJET = value; }
        }
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

        public string DP_STATUT
        {
            get { return _DP_STATUT; }
            set { _DP_STATUT = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsRequtilisateurdroitparametre() { }

        public clsRequtilisateurdroitparametre(clsRequtilisateurdroitparametre clsRequtilisateurdroitparametre)
        {
            this.DP_CODEDROITCOMPTEUTULISATEUR = clsRequtilisateurdroitparametre.DP_CODEDROITCOMPTEUTULISATEUR;
            this.DP_LIBELLEDROITCOMPTEUTULISATEUR = clsRequtilisateurdroitparametre.DP_LIBELLEDROITCOMPTEUTULISATEUR;
            this.DP_STATUT = clsRequtilisateurdroitparametre.DP_STATUT;
            this.DP_OBJET = clsRequtilisateurdroitparametre.DP_OBJET;
            this.CU_CODECOMPTEUTULISATEUR = clsRequtilisateurdroitparametre.CU_CODECOMPTEUTULISATEUR;
            this.TYPEOPERATION = clsRequtilisateurdroitparametre.TYPEOPERATION;
        }

        #endregion

    }
}
