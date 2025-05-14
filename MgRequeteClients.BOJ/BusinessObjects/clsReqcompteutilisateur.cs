using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqcompteutilisateur
    {
        #region VARIABLES LOCALES

        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _AG_CODEAGENCE = "";
        private string _TU_CODETYPEUTILISATEUR = "";
        private string _CU_NUMEROUTILISATEUR = "";
        private string _CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = "";
        private string _CU_NOMUTILISATEUR = "";
        private string _CU_CONTACT = "";
        private string _CU_EMAIL = "";
        private string _CU_LOGIN = "";
        private string _CU_MOTDEPASSE = "";
        private DateTime _CU_DATECREATION = DateTime.Parse("01/01/1900");
        private DateTime _CU_DATECLOTURE = DateTime.Parse("01/01/1900");
        private string _CU_TOKEN = "";
        private string _PI_CODEPIECE = "";
        private string _CU_NUMEROPIECE = "";
        private DateTime _CU_DATEPIECE = DateTime.Parse("01/01/1900");
        private string _CU_NOMBRECONNECTION = "";
        private string _CU_CLESESSION = "";
        private string _TYPEOPERATION = "";
        #endregion

        #region ACCESSEURS

        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
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

        public string CU_LOGIN
        {
            get { return _CU_LOGIN; }
            set { _CU_LOGIN = value; }
        }

        public string CU_MOTDEPASSE
        {
            get { return _CU_MOTDEPASSE; }
            set { _CU_MOTDEPASSE = value; }
        }

        public DateTime CU_DATECREATION
        {
            get { return _CU_DATECREATION; }
            set { _CU_DATECREATION = value; }
        }

        public DateTime CU_DATECLOTURE
        {
            get { return _CU_DATECLOTURE; }
            set { _CU_DATECLOTURE = value; }
        }

        public string CU_TOKEN
        {
            get { return _CU_TOKEN; }
            set { _CU_TOKEN = value; }
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

        public DateTime CU_DATEPIECE
        {
            get { return _CU_DATEPIECE; }
            set { _CU_DATEPIECE = value; }
        }

        public string CU_NOMBRECONNECTION
        {
            get { return _CU_NOMBRECONNECTION; }
            set { _CU_NOMBRECONNECTION = value; }
        }

        public string CU_CLESESSION
        {
            get { return _CU_CLESESSION; }
            set { _CU_CLESESSION = value; }
        }


        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsReqcompteutilisateur() { }

        public clsReqcompteutilisateur(clsReqcompteutilisateur clsReqcompteutilisateur)
        {
            this.CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;
            this.AG_CODEAGENCE = clsReqcompteutilisateur.AG_CODEAGENCE;
            this.TU_CODETYPEUTILISATEUR = clsReqcompteutilisateur.TU_CODETYPEUTILISATEUR;
            this.CU_NUMEROUTILISATEUR = clsReqcompteutilisateur.CU_NUMEROUTILISATEUR;
            this.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = clsReqcompteutilisateur.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR;
            this.CU_NOMUTILISATEUR = clsReqcompteutilisateur.CU_NOMUTILISATEUR;
            this.CU_CONTACT = clsReqcompteutilisateur.CU_CONTACT;
            this.CU_EMAIL = clsReqcompteutilisateur.CU_EMAIL;
            this.CU_LOGIN = clsReqcompteutilisateur.CU_LOGIN;
            this.CU_MOTDEPASSE = clsReqcompteutilisateur.CU_MOTDEPASSE;
            this.CU_DATECREATION = clsReqcompteutilisateur.CU_DATECREATION;
            this.CU_DATECLOTURE = clsReqcompteutilisateur.CU_DATECLOTURE;
            this.CU_TOKEN = clsReqcompteutilisateur.CU_TOKEN;
            this.PI_CODEPIECE = clsReqcompteutilisateur.PI_CODEPIECE;
            this.CU_NUMEROPIECE = clsReqcompteutilisateur.CU_NUMEROPIECE;
            this.CU_DATEPIECE = clsReqcompteutilisateur.CU_DATEPIECE;
            this.CU_NOMBRECONNECTION = clsReqcompteutilisateur.CU_NOMBRECONNECTION;
            this.CU_CLESESSION = clsReqcompteutilisateur.CU_CLESESSION;
            this.TYPEOPERATION = clsReqcompteutilisateur.TYPEOPERATION;
        }

        #endregion
    }
}
