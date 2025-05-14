using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqcompteutilisateur
    {
        #region VARIABLES LOCALES
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _AG_CODEAGENCE = "";
        private string _AG_RAISONSOCIAL = "";
        private string _TU_CODETYPEUTILISATEUR = "";
        private string _CU_NUMEROUTILISATEUR = "";
        private string _CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = "";
        private string _CU_NOMUTILISATEUR = "";
        private string _CU_CONTACT = "";
        private string _CU_EMAIL = "";
        private string _CU_LOGIN = "";
        private string _CU_MOTDEPASSE = "";
        private string _CU_DATECREATION = "01/01/1900";
        private string _CU_DATECLOTURE = "01/01/1900";
        private string _CU_TOKEN = "";
        private string _PI_CODEPIECE = "";
        private string _CU_NUMEROPIECE = "";
        private string _CU_DATEPIECE = "01/01/1900";
        private string _CU_NOMBRECONNECTION = "";
        private string _CU_CLESESSION = "";

        private string _JT_DATEJOURNEETRAVAIL = "01/01/1900";
        private string _EX_DATEDEBUTPREMIEREXERCIE = "01/01/1900";
        private string _EX_DATEDEBUT = "01/01/1900";
        private string _EX_DATEFIN = "01/01/1900";
        private string _EX_DATEDEBUTBILAN = "01/01/1900";
        private string _EX_EXERCICE = "";
        private string _EX_ETATEXERCICE = "";

        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";
        private string _SL_CODEMESSAGE = "";

        private clsReqoperateur _clsReqoperateur;
        private clsReqmicclient _clsReqmicclient;
        private clsReqtontineepargnantjournalier _clsReqtontineepargnantjournalier;
        private clsReqmicprospect _clsReqmicprospect;

        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

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

        public string AG_RAISONSOCIAL
        {
            get { return _AG_RAISONSOCIAL; }
            set { _AG_RAISONSOCIAL = value; }
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

        public string CU_DATEPIECE
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



        public clsReqoperateur clsReqoperateur
        {
            get { return _clsReqoperateur; }
            set { _clsReqoperateur = value; }
        }

        public clsReqmicclient clsReqmicclient
        {
            get { return _clsReqmicclient; }
            set { _clsReqmicclient = value; }
        }
        public clsReqtontineepargnantjournalier clsReqtontineepargnantjournalier
        {
            get { return _clsReqtontineepargnantjournalier; }
            set { _clsReqtontineepargnantjournalier = value; }
        }

        public clsReqmicprospect clsReqmicprospect
        {
            get { return _clsReqmicprospect; }
            set { _clsReqmicprospect = value; }
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


        public string JT_DATEJOURNEETRAVAIL
        {
            get { return _JT_DATEJOURNEETRAVAIL; }
            set { _JT_DATEJOURNEETRAVAIL = value; }
        }
        public string EX_DATEDEBUTPREMIEREXERCIE
        {
            get { return _EX_DATEDEBUTPREMIEREXERCIE; }
            set { _EX_DATEDEBUTPREMIEREXERCIE = value; }
        }
        public string EX_EXERCICE
        {
            get { return _EX_EXERCICE; }
            set { _EX_EXERCICE = value; }
        }
        public string EX_DATEDEBUT
        {
            get { return _EX_DATEDEBUT; }
            set { _EX_DATEDEBUT = value; }
        }
        public string EX_DATEFIN
        {
            get { return _EX_DATEFIN; }
            set { _EX_DATEFIN = value; }
        }
        public string EX_ETATEXERCICE
        {
            get { return _EX_ETATEXERCICE; }
            set { _EX_ETATEXERCICE = value; }
        }
        public string EX_DATEDEBUTBILAN
        {
            get { return _EX_DATEDEBUTBILAN; }
            set { _EX_DATEDEBUTBILAN = value; }
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

        public clsReqcompteutilisateur() { }

        public clsReqcompteutilisateur(clsReqcompteutilisateur clsReqcompteutilisateur)
        {
            this.CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;
            this.AG_CODEAGENCE = clsReqcompteutilisateur.AG_CODEAGENCE;
            this.AG_RAISONSOCIAL = clsReqcompteutilisateur.AG_RAISONSOCIAL;
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

            this.clsReqoperateur = clsReqcompteutilisateur.clsReqoperateur;
            this.clsReqmicclient = clsReqcompteutilisateur.clsReqmicclient;
            this.clsReqtontineepargnantjournalier = clsReqcompteutilisateur.clsReqtontineepargnantjournalier;
            this.clsReqmicprospect = clsReqcompteutilisateur.clsReqmicprospect;

            this.clsResultat = clsReqcompteutilisateur.clsResultat;
            this.clsObjetEnvoi = clsReqcompteutilisateur.clsObjetEnvoi;

            this.JT_DATEJOURNEETRAVAIL = clsReqcompteutilisateur.JT_DATEJOURNEETRAVAIL;
            this.EX_DATEDEBUTPREMIEREXERCIE = clsReqcompteutilisateur.EX_DATEDEBUTPREMIEREXERCIE;
            this.EX_EXERCICE = clsReqcompteutilisateur.EX_EXERCICE;
            this.EX_DATEDEBUT = clsReqcompteutilisateur.EX_DATEDEBUT;
            this.EX_DATEFIN = clsReqcompteutilisateur.EX_DATEFIN;
            this.EX_ETATEXERCICE = clsReqcompteutilisateur.EX_ETATEXERCICE;
            this.EX_DATEDEBUTBILAN = clsReqcompteutilisateur.EX_DATEDEBUTBILAN;

            this.SL_CODEMESSAGE = clsReqcompteutilisateur.SL_CODEMESSAGE;
            this.SL_MESSAGE = clsReqcompteutilisateur.SL_MESSAGE;
            this.SL_RESULTAT = clsReqcompteutilisateur.SL_RESULTAT;
        }

        #endregion

    }
}
