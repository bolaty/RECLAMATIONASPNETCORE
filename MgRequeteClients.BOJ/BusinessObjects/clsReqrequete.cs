using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqrequete
    {
        #region VARIABLES LOCALES

        private string _RQ_CODEREQUETE = "";
        private string _TR_CODETYEREQUETE = "";
        private string _RQ_NUMEROREQUETE = "";
        private string _RQ_NUMERORECOMPTE = "";
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _RQ_LOCALISATIONCLIENT = "";
        private string _RQ_DESCRIPTIONREQUETE = "";
        private string _MC_CODEMODECOLLETE = "";
        private DateTime _RQ_DATESAISIEREQUETE = DateTime.Parse("01/01/1900");
        private string _CU_CODECOMPTEUTULISATEURAGENTENCHARGE = "0";
        private DateTime _RQ_DATETRANSFERTREQUETE = DateTime.Parse("01/01/1900");
        private string _RQ_CODEREQUETERELANCEE = "0";
        private Byte[] _RQ_SIGNATURE = null;
        private string _RQ_SIGNATURE1 = "";
        private string _RS_CODESTATUTRECEVABILITE = "";
        private string _RQ_OBJETREQUETE = "";
        private string _SR_CODESERVICE = "";
        private string _RQ_DELAITRAITEMENTREQUETE = "";
        private string _RQ_OBSERVATIONDELAITRAITEMENTREQUETE = "";
        private string _RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = "";
        private string _RQ_DUREETRAITEMENTREQUETE = "";
        private DateTime _RQ_DATEDEBUTTRAITEMENTREQUETE = DateTime.Parse("01/01/1900");
        private DateTime _RQ_DATEFINTRAITEMENTREQUETE = DateTime.Parse("01/01/1900");
        private string _AC_CODEACTIONCORRECTIVE = "";
        private string _NS_CODENIVEAUSATISFACTION = "";
        private string _RQ_AFFICHERINFOCLIENT = "N";
        private string _RT_CODETYPERELANCE = "";
        private DateTime _RQ_DATECLOTUREREQUETE = DateTime.Parse("01/01/1900");
        private string _TYPEOPERATION = "";
        private string _PP_CODEPARAMETRE = "";
        private string _PP_VALEUR = "";

        private string _RQ_NOMRAPPORT = "";

        private string _CU_CODECOMPTEUTULISATEURASSOCIER = "";

        #endregion

        #region ACCESSEURS


        public string CU_CODECOMPTEUTULISATEURASSOCIER
        {
            get { return _CU_CODECOMPTEUTULISATEURASSOCIER; }
            set { _CU_CODECOMPTEUTULISATEURASSOCIER = value; }
        }

        public string RQ_CODEREQUETE
        {
            get { return _RQ_CODEREQUETE; }
            set { _RQ_CODEREQUETE = value; }
        }

        public string RQ_NOMRAPPORT
        {
            get { return _RQ_NOMRAPPORT; }
            set { _RQ_NOMRAPPORT = value; }
        }

        public string PP_VALEUR
        {
            get { return _PP_VALEUR; }
            set { _PP_VALEUR = value; }
        }

        public string PP_CODEPARAMETRE
        {
            get { return _PP_CODEPARAMETRE; }
            set { _PP_CODEPARAMETRE = value; }
        }

        public string TR_CODETYEREQUETE
        {
            get { return _TR_CODETYEREQUETE; }
            set { _TR_CODETYEREQUETE = value; }
        }

        public string RQ_NUMEROREQUETE
        {
            get { return _RQ_NUMEROREQUETE; }
            set { _RQ_NUMEROREQUETE = value; }
        }

        public string RQ_NUMERORECOMPTE
        {
            get { return _RQ_NUMERORECOMPTE; }
            set { _RQ_NUMERORECOMPTE = value; }
        }

        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
        }

        public string RQ_LOCALISATIONCLIENT
        {
            get { return _RQ_LOCALISATIONCLIENT; }
            set { _RQ_LOCALISATIONCLIENT = value; }
        }

        public string RQ_DESCRIPTIONREQUETE
        {
            get { return _RQ_DESCRIPTIONREQUETE; }
            set { _RQ_DESCRIPTIONREQUETE = value; }
        }

        public string MC_CODEMODECOLLETE
        {
            get { return _MC_CODEMODECOLLETE; }
            set { _MC_CODEMODECOLLETE = value; }
        }

        public DateTime RQ_DATESAISIEREQUETE
        {
            get { return _RQ_DATESAISIEREQUETE; }
            set { _RQ_DATESAISIEREQUETE = value; }
        }

        public string CU_CODECOMPTEUTULISATEURAGENTENCHARGE
        {
            get { return _CU_CODECOMPTEUTULISATEURAGENTENCHARGE; }
            set { _CU_CODECOMPTEUTULISATEURAGENTENCHARGE = value; }
        }

        public DateTime RQ_DATETRANSFERTREQUETE
        {
            get { return _RQ_DATETRANSFERTREQUETE; }
            set { _RQ_DATETRANSFERTREQUETE = value; }
        }

        public string RQ_CODEREQUETERELANCEE
        {
            get { return _RQ_CODEREQUETERELANCEE; }
            set { _RQ_CODEREQUETERELANCEE = value; }
        }

        public Byte[] RQ_SIGNATURE
        {
            get { return _RQ_SIGNATURE; }
            set { _RQ_SIGNATURE = value; }
        }
        public string RQ_SIGNATURE1
        {
            get { return _RQ_SIGNATURE1; }
            set { _RQ_SIGNATURE1 = value; }
        }
        public string RS_CODESTATUTRECEVABILITE
        {
            get { return _RS_CODESTATUTRECEVABILITE; }
            set { _RS_CODESTATUTRECEVABILITE = value; }
        }

        public string RQ_OBJETREQUETE
        {
            get { return _RQ_OBJETREQUETE; }
            set { _RQ_OBJETREQUETE = value; }
        }

        public string SR_CODESERVICE
        {
            get { return _SR_CODESERVICE; }
            set { _SR_CODESERVICE = value; }
        }

        public string RQ_DELAITRAITEMENTREQUETE
        {
            get { return _RQ_DELAITRAITEMENTREQUETE; }
            set { _RQ_DELAITRAITEMENTREQUETE = value; }
        }

        public string RQ_OBSERVATIONDELAITRAITEMENTREQUETE
        {
            get { return _RQ_OBSERVATIONDELAITRAITEMENTREQUETE; }
            set { _RQ_OBSERVATIONDELAITRAITEMENTREQUETE = value; }
        }

        public string RQ_OBSERVATIONAGENTTRAITEMENTREQUETE
        {
            get { return _RQ_OBSERVATIONAGENTTRAITEMENTREQUETE; }
            set { _RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = value; }
        }

        public string RQ_DUREETRAITEMENTREQUETE
        {
            get { return _RQ_DUREETRAITEMENTREQUETE; }
            set { _RQ_DUREETRAITEMENTREQUETE = value; }
        }

        public DateTime RQ_DATEDEBUTTRAITEMENTREQUETE
        {
            get { return _RQ_DATEDEBUTTRAITEMENTREQUETE; }
            set { _RQ_DATEDEBUTTRAITEMENTREQUETE = value; }
        }

        public DateTime RQ_DATEFINTRAITEMENTREQUETE
        {
            get { return _RQ_DATEFINTRAITEMENTREQUETE; }
            set { _RQ_DATEFINTRAITEMENTREQUETE = value; }
        }

        public string AC_CODEACTIONCORRECTIVE
        {
            get { return _AC_CODEACTIONCORRECTIVE; }
            set { _AC_CODEACTIONCORRECTIVE = value; }
        }

        public string NS_CODENIVEAUSATISFACTION
        {
            get { return _NS_CODENIVEAUSATISFACTION; }
            set { _NS_CODENIVEAUSATISFACTION = value; }
        }

        public string RQ_AFFICHERINFOCLIENT
        {
            get { return _RQ_AFFICHERINFOCLIENT; }
            set { _RQ_AFFICHERINFOCLIENT = value; }
        }
        public string RT_CODETYPERELANCE
        {
            get { return _RT_CODETYPERELANCE; }
            set { _RT_CODETYPERELANCE = value; }
        }
        public DateTime RQ_DATECLOTUREREQUETE
        {
            get { return _RQ_DATECLOTUREREQUETE; }
            set { _RQ_DATECLOTUREREQUETE = value; }
        }

        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsReqrequete() { }

        public clsReqrequete(clsReqrequete clsReqrequete)
        {
            this.RQ_CODEREQUETE = clsReqrequete.RQ_CODEREQUETE;
            this.TR_CODETYEREQUETE = clsReqrequete.TR_CODETYEREQUETE;
            this.RQ_NUMEROREQUETE = clsReqrequete.RQ_NUMEROREQUETE;
            this.RQ_NUMERORECOMPTE = clsReqrequete.RQ_NUMERORECOMPTE;
            this.CU_CODECOMPTEUTULISATEUR = clsReqrequete.CU_CODECOMPTEUTULISATEUR;
            this.RQ_LOCALISATIONCLIENT = clsReqrequete.RQ_LOCALISATIONCLIENT;
            this.RQ_DESCRIPTIONREQUETE = clsReqrequete.RQ_DESCRIPTIONREQUETE;
            this.MC_CODEMODECOLLETE = clsReqrequete.MC_CODEMODECOLLETE;
            this.RQ_DATESAISIEREQUETE = clsReqrequete.RQ_DATESAISIEREQUETE;
            this.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = clsReqrequete.CU_CODECOMPTEUTULISATEURAGENTENCHARGE;
            this.RQ_DATETRANSFERTREQUETE = clsReqrequete.RQ_DATETRANSFERTREQUETE;
            this.RQ_CODEREQUETERELANCEE = clsReqrequete.RQ_CODEREQUETERELANCEE;
            this.RQ_SIGNATURE = clsReqrequete.RQ_SIGNATURE;
            this.RS_CODESTATUTRECEVABILITE = clsReqrequete.RS_CODESTATUTRECEVABILITE;
            this.RQ_OBJETREQUETE = clsReqrequete.RQ_OBJETREQUETE;
            this.SR_CODESERVICE = clsReqrequete.SR_CODESERVICE;
            this.RQ_DELAITRAITEMENTREQUETE = clsReqrequete.RQ_DELAITRAITEMENTREQUETE;
            this.RQ_OBSERVATIONDELAITRAITEMENTREQUETE = clsReqrequete.RQ_OBSERVATIONDELAITRAITEMENTREQUETE;
            this.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = clsReqrequete.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE;
            this.RQ_DUREETRAITEMENTREQUETE = clsReqrequete.RQ_DUREETRAITEMENTREQUETE;
            this.RQ_DATEDEBUTTRAITEMENTREQUETE = clsReqrequete.RQ_DATEDEBUTTRAITEMENTREQUETE;
            this.RQ_DATEFINTRAITEMENTREQUETE = clsReqrequete.RQ_DATEFINTRAITEMENTREQUETE;
            this.AC_CODEACTIONCORRECTIVE = clsReqrequete.AC_CODEACTIONCORRECTIVE;
            this.NS_CODENIVEAUSATISFACTION = clsReqrequete.NS_CODENIVEAUSATISFACTION;
            this.RQ_AFFICHERINFOCLIENT = clsReqrequete.RQ_AFFICHERINFOCLIENT;
            this.RT_CODETYPERELANCE = clsReqrequete.RT_CODETYPERELANCE;

            this.RQ_DATECLOTUREREQUETE = clsReqrequete.RQ_DATECLOTUREREQUETE;
            this.RQ_SIGNATURE1 = clsReqrequete.RQ_SIGNATURE1;
            this.TYPEOPERATION = clsReqrequete.TYPEOPERATION;

            this.PP_CODEPARAMETRE = clsReqrequete.PP_CODEPARAMETRE;
            this.PP_VALEUR = clsReqrequete.PP_VALEUR;

            this.RQ_NOMRAPPORT = clsReqrequete.RQ_NOMRAPPORT;

            this.CU_CODECOMPTEUTULISATEURASSOCIER = clsReqrequete.CU_CODECOMPTEUTULISATEURASSOCIER;

        }

        #endregion

    }
}
