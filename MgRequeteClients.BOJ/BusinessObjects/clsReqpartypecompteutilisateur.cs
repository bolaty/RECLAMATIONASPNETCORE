using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqpartypecompteutilisateur
    {
        #region VARIABLES LOCALES

        private string _TU_CODETYPEUTILISATEUR = "";
        private string _TU_LIBELLETYPEUTILISATEUR = "";
        private string _TU_ACTIF = "";

        #endregion

        #region ACCESSEURS

        public string TU_CODETYPEUTILISATEUR
        {
            get { return _TU_CODETYPEUTILISATEUR; }
            set { _TU_CODETYPEUTILISATEUR = value; }
        }

        public string TU_LIBELLETYPEUTILISATEUR
        {
            get { return _TU_LIBELLETYPEUTILISATEUR; }
            set { _TU_LIBELLETYPEUTILISATEUR = value; }
        }

        public string TU_ACTIF
        {
            get { return _TU_ACTIF; }
            set { _TU_ACTIF = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsReqpartypecompteutilisateur() { }
        public clsReqpartypecompteutilisateur(string TU_CODETYPEUTILISATEUR, string TU_LIBELLETYPEUTILISATEUR, string TU_ACTIF)
        {
            this.TU_CODETYPEUTILISATEUR = TU_CODETYPEUTILISATEUR;
            this.TU_LIBELLETYPEUTILISATEUR = TU_LIBELLETYPEUTILISATEUR;
            this.TU_ACTIF = TU_ACTIF;
        }
        public clsReqpartypecompteutilisateur(clsReqpartypecompteutilisateur clsReqpartypecompteutilisateur)
        {
            this.TU_CODETYPEUTILISATEUR = clsReqpartypecompteutilisateur.TU_CODETYPEUTILISATEUR;
            this.TU_LIBELLETYPEUTILISATEUR = clsReqpartypecompteutilisateur.TU_LIBELLETYPEUTILISATEUR;
            this.TU_ACTIF = clsReqpartypecompteutilisateur.TU_ACTIF;
        }

        #endregion
    }
}
