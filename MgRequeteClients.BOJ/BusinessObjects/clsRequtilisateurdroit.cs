using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsRequtilisateurdroit
    {
        #region VARIABLES LOCALES

        private string _DP_CODEDROITCOMPTEUTULISATEUR = "";
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _TYPEOPERATION = "";

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

        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsRequtilisateurdroit() { }

        public clsRequtilisateurdroit(clsRequtilisateurdroit clsRequtilisateurdroit)
        {
            this.DP_CODEDROITCOMPTEUTULISATEUR = clsRequtilisateurdroit.DP_CODEDROITCOMPTEUTULISATEUR;
            this.CU_CODECOMPTEUTULISATEUR = clsRequtilisateurdroit.CU_CODECOMPTEUTULISATEUR;
            this.TYPEOPERATION = clsRequtilisateurdroit.TYPEOPERATION;
        }

        #endregion
    }
}
