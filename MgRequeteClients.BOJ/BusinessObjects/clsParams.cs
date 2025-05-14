using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsParams
    {
        #region VARIABLES LOCALES

        private string _CodeAgence = "";
        private string _CO_CODECOMPTE = "";
        private string _PV_CODEPOINTVENTE = "";
        private string _CodeOperateur = "";
        private string _LibelleMouchard = "";
        private string _LibelleEcran = "";
        private string _SL_VALEURRETOURS = "";
        private string _SL_CODEMESSAGE = "";
        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";

        private string _SL_RESULTATAPI = "";
        private string _SL_MESSAGEAPI = "";

        private string _TYPEOPERATION = "";
        private string _LO_LOGICIEL = "";
        private string _SMSTEXT = "";
        private string _INDICATIF = "";
        private string _RECIPIENTPHONE = "";
        private string _SM_DATEPIECE = "";
        private string _SM_NUMSEQUENCE = "";
        private string _SM_RAISONNONENVOISMS = "";
        private string _OB_NOMOBJET = "";
        private string _LG_CODELANGUE = "";
        private string _EJ_IDEPARGNANTJOURNALIER = "";
        private string _MB_IDTIERS = "";
        private string _CL_IDCLIENT = "";
        private string _TE_CODESMSTYPEOPERATION = "";
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private DateTime _SM_DATEEMISSIONSMS = DateTime.Parse("01/01/1900");
        private string _MC_NUMPIECE;
        private string _MC_NUMSEQUENCE = "0";
        private string _SM_STATUT = "N";
        private string _SM_TYPEOPERATION = "0";
        private string _SL_LIBELLE1 = "";
        private string _SL_LIBELLE2 = "";

        #endregion

        #region ACCESSEURS

        public string CodeAgence
        {
            get { return _CodeAgence; }
            set { _CodeAgence = value; }
        }
        public string CO_CODECOMPTE
        {
            get { return _CO_CODECOMPTE; }
            set { _CO_CODECOMPTE = value; }
        }
        public string PV_CODEPOINTVENTE
        {
            get { return _PV_CODEPOINTVENTE; }
            set { _PV_CODEPOINTVENTE = value; }
        }

        public string CodeOperateur
        {
            get { return _CodeOperateur; }
            set { _CodeOperateur = value; }
        }

        public string LibelleMouchard
        {
            get { return _LibelleMouchard; }
            set { _LibelleMouchard = value; }
        }

        public string LibelleEcran
        {
            get { return _LibelleEcran; }
            set { _LibelleEcran = value; }
        }

        public string SL_VALEURRETOURS
        {
            get { return _SL_VALEURRETOURS; }
            set { _SL_VALEURRETOURS = value; }
        }

        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
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

        public string SL_RESULTATAPI
        {
            get { return _SL_RESULTATAPI; }
            set { _SL_RESULTATAPI = value; }
        }

        public string SL_MESSAGEAPI
        {
            get { return _SL_MESSAGEAPI; }
            set { _SL_MESSAGEAPI = value; }
        }

        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }

        public string LO_LOGICIEL
        {
            get { return _LO_LOGICIEL; }
            set { _LO_LOGICIEL = value; }
        }


        public string SMSTEXT
        {
            get { return _SMSTEXT; }
            set { _SMSTEXT = value; }
        }

        public string INDICATIF
        {
            get { return _INDICATIF; }
            set { _INDICATIF = value; }
        }

        public string RECIPIENTPHONE
        {
            get { return _RECIPIENTPHONE; }
            set { _RECIPIENTPHONE = value; }
        }

        public string SM_DATEPIECE
        {
            get { return _SM_DATEPIECE; }
            set { _SM_DATEPIECE = value; }
        }
        public string SM_NUMSEQUENCE
        {
            get { return _SM_NUMSEQUENCE; }
            set { _SM_NUMSEQUENCE = value; }
        }
        public string SM_RAISONNONENVOISMS
        {
            get { return _SM_RAISONNONENVOISMS; }
            set { _SM_RAISONNONENVOISMS = value; }
        }


        public string OB_NOMOBJET
        {
            get { return _OB_NOMOBJET; }
            set { _OB_NOMOBJET = value; }
        }


        public string LG_CODELANGUE
        {
            get { return _LG_CODELANGUE; }
            set { _LG_CODELANGUE = value; }
        }

        public string EJ_IDEPARGNANTJOURNALIER
        {
            get { return _EJ_IDEPARGNANTJOURNALIER; }
            set { _EJ_IDEPARGNANTJOURNALIER = value; }
        }

        public string MB_IDTIERS
        {
            get { return _MB_IDTIERS; }
            set { _MB_IDTIERS = value; }
        }

        public string CL_IDCLIENT
        {
            get { return _CL_IDCLIENT; }
            set { _CL_IDCLIENT = value; }
        }

        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
        }

        public string TE_CODESMSTYPEOPERATION
        {
            get { return _TE_CODESMSTYPEOPERATION; }
            set { _TE_CODESMSTYPEOPERATION = value; }
        }

        public DateTime SM_DATEEMISSIONSMS
        {
            get { return _SM_DATEEMISSIONSMS; }
            set { _SM_DATEEMISSIONSMS = value; }
        }

        public string MC_NUMPIECE
        {
            get { return _MC_NUMPIECE; }
            set { _MC_NUMPIECE = value; }
        }

        public string SM_STATUT
        {
            get { return _SM_STATUT; }
            set { _SM_STATUT = value; }
        }

        public string SM_TYPEOPERATION
        {
            get { return _SM_TYPEOPERATION; }
            set { _SM_TYPEOPERATION = value; }
        }

        public string MC_NUMSEQUENCE
        {
            get { return _MC_NUMSEQUENCE; }
            set { _MC_NUMSEQUENCE = value; }
        }

        public string SL_LIBELLE1
        {
            get { return _SL_LIBELLE1; }
            set { _SL_LIBELLE1 = value; }
        }
        public string SL_LIBELLE2
        {
            get { return _SL_LIBELLE2; }
            set { _SL_LIBELLE2 = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsParams() { }

        public clsParams(clsParams clsParams)
        {
            this.CodeAgence = clsParams.CodeAgence;
            this.CO_CODECOMPTE = clsParams.CO_CODECOMPTE;
            this.OB_NOMOBJET = clsParams.OB_NOMOBJET;
            this.PV_CODEPOINTVENTE = clsParams.PV_CODEPOINTVENTE;
            this.CodeOperateur = clsParams.CodeOperateur;
            this.LibelleMouchard = clsParams.LibelleMouchard;
            this.LibelleEcran = clsParams.LibelleEcran;
            this.SL_VALEURRETOURS = clsParams.SL_VALEURRETOURS;
            this.SL_CODEMESSAGE = clsParams.SL_CODEMESSAGE;
            this.SL_RESULTAT = clsParams.SL_RESULTAT;
            this.SL_MESSAGE = clsParams.SL_MESSAGE;

            this.SL_RESULTATAPI = clsParams.SL_RESULTATAPI;
            this.SL_MESSAGEAPI = clsParams.SL_MESSAGEAPI;

            this.LG_CODELANGUE = clsParams.LG_CODELANGUE;
            this.SMSTEXT = clsParams.SMSTEXT;
            this.INDICATIF = clsParams.INDICATIF;
            this.RECIPIENTPHONE = clsParams.RECIPIENTPHONE;
            this.SM_DATEPIECE = clsParams.SM_DATEPIECE;
            this.SM_NUMSEQUENCE = clsParams.SM_NUMSEQUENCE;
            this.SM_RAISONNONENVOISMS = clsParams.SM_RAISONNONENVOISMS;
            this.LO_LOGICIEL = clsParams.LO_LOGICIEL;
            this.TYPEOPERATION = clsParams.TYPEOPERATION;
            this.EJ_IDEPARGNANTJOURNALIER = clsParams.EJ_IDEPARGNANTJOURNALIER;
            this.MB_IDTIERS = clsParams.MB_IDTIERS;
            this.CL_IDCLIENT = clsParams.CL_IDCLIENT;
            this.TE_CODESMSTYPEOPERATION = clsParams.TE_CODESMSTYPEOPERATION;
            this.CU_CODECOMPTEUTULISATEUR = clsParams.CU_CODECOMPTEUTULISATEUR;

            this.SM_DATEEMISSIONSMS = clsParams.SM_DATEEMISSIONSMS;
            this.MC_NUMPIECE = clsParams.MC_NUMPIECE;
            this.MC_NUMSEQUENCE = clsParams.MC_NUMSEQUENCE;
            this.SM_STATUT = clsParams.SM_STATUT;
            this.SM_TYPEOPERATION = clsParams.SM_TYPEOPERATION;
            this.SL_LIBELLE1 = clsParams.SL_LIBELLE1;
            this.SL_LIBELLE2 = clsParams.SL_LIBELLE2;

        }

        #endregion
    }
}
