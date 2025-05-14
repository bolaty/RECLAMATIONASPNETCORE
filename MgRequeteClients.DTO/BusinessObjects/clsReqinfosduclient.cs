using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqinfosduclient
    {
        #region VARIABLES LOCALES

        private string _AG_CODEAGENCE = "";
        private string _TU_CODETYPEUTILISATEUR = "";
        private string _CU_NUMEROUTILISATEUR = "";
        private string _CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = "";
        private string _CU_NOMUTILISATEUR = "";
        private string _CU_CONTACT = "";
        private string _CU_EMAIL = "";
        private string _CU_DATECREATION = "01/01/1900";
        private string _CU_DATECLOTURE = "01/01/1900";
        private string _PI_CODEPIECE = "";
        private string _CU_NUMEROPIECE = "";
        private string _CU_DATEPIECE = "01/01/1900";

        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        private string _CU_NOMUTILISATEURASSOCIER = "";
        private string _CU_CONTACTUTILISATEURASSOCIER = "";
        private string _CU_EMAILUTILISATEURASSOCIER = "";
        #endregion

        #region ACCESSEURS
        public string CU_NOMUTILISATEURASSOCIER
        {
            get { return _CU_NOMUTILISATEURASSOCIER; }
            set { _CU_NOMUTILISATEURASSOCIER = value; }
        }
        public string CU_CONTACTUTILISATEURASSOCIER
        {
            get { return _CU_CONTACTUTILISATEURASSOCIER; }
            set { _CU_CONTACTUTILISATEURASSOCIER = value; }
        }
        public string CU_EMAILUTILISATEURASSOCIER
        {
            get { return _CU_EMAILUTILISATEURASSOCIER; }
            set { _CU_EMAILUTILISATEURASSOCIER = value; }
        }
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
        public string TU_CODETYPEUTILISATEUR
        {
            get { return _TU_CODETYPEUTILISATEUR; }
            set { _TU_CODETYPEUTILISATEUR = value; }
        }
        public string CU_NUMEROUTILISATEUR
        {
            get { return _CU_NUMEROUTILISATEUR; }
            set { _CU_NUMEROUTILISATEUR = value; }
        }
        public string CU_ADRESSEGEOGRAPHIQUEUTILISATEUR
        {
            get { return _CU_ADRESSEGEOGRAPHIQUEUTILISATEUR; }
            set { _CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = value; }
        }
        public string CU_NOMUTILISATEUR
        {
            get { return _CU_NOMUTILISATEUR; }
            set { _CU_NOMUTILISATEUR = value; }
        }
        public string CU_CONTACT
        {
            get { return _CU_CONTACT; }
            set { _CU_CONTACT = value; }
        }
        public string CU_EMAIL
        {
            get { return _CU_EMAIL; }
            set { _CU_EMAIL = value; }
        }
        public string CU_DATECREATION
        {
            get { return _CU_DATECREATION; }
            set { _CU_DATECREATION = value; }
        }
        public string CU_DATECLOTURE
        {
            get { return _CU_DATECLOTURE; }
            set { _CU_DATECLOTURE = value; }
        }
        public string PI_CODEPIECE
        {
            get { return _PI_CODEPIECE; }
            set { _PI_CODEPIECE = value; }
        }
        public string CU_NUMEROPIECE
        {
            get { return _CU_NUMEROPIECE; }
            set { _CU_NUMEROPIECE = value; }
        }
        public string CU_DATEPIECE
        {
            get { return _CU_DATEPIECE; }
            set { _CU_DATEPIECE = value; }
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

        public clsReqinfosduclient() { }

        public clsReqinfosduclient(clsReqinfosduclient clsReqinfosduclient)
        {
            this.AG_CODEAGENCE = clsReqinfosduclient.AG_CODEAGENCE;
            this.TU_CODETYPEUTILISATEUR = clsReqinfosduclient.TU_CODETYPEUTILISATEUR;
            this.CU_NUMEROUTILISATEUR = clsReqinfosduclient.CU_NUMEROUTILISATEUR;
            this.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = clsReqinfosduclient.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR;
            this.CU_NOMUTILISATEUR = clsReqinfosduclient.CU_NOMUTILISATEUR;
            this.CU_CONTACT = clsReqinfosduclient.CU_CONTACT;
            this.CU_EMAIL = clsReqinfosduclient.CU_EMAIL;
            this.CU_DATECREATION = clsReqinfosduclient.CU_DATECREATION;
            this.CU_DATECLOTURE = clsReqinfosduclient.CU_DATECLOTURE;
            this.PI_CODEPIECE = clsReqinfosduclient.PI_CODEPIECE;
            this.CU_NUMEROPIECE = clsReqinfosduclient.CU_NUMEROPIECE;
            this.CU_DATEPIECE = clsReqinfosduclient.CU_DATEPIECE;
            this.CU_NOMUTILISATEURASSOCIER = clsReqinfosduclient.CU_NOMUTILISATEURASSOCIER;
            this.CU_CONTACTUTILISATEURASSOCIER = clsReqinfosduclient.CU_CONTACTUTILISATEURASSOCIER;
            this.CU_EMAILUTILISATEURASSOCIER = clsReqinfosduclient.CU_EMAILUTILISATEURASSOCIER;
            this.clsResultat = clsReqinfosduclient.clsResultat;
            this.clsObjetEnvoi = clsReqinfosduclient.clsObjetEnvoi;
        }

        #endregion

    }
}
