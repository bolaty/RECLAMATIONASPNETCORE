using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
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
        private string _RQ_DATESAISIEREQUETE = "01/01/1900";
        private string _CU_CODECOMPTEUTULISATEURAGENTENCHARGE = "0";
        private string _RQ_DATETRANSFERTREQUETE = "01/01/1900";
        private string _RQ_CODEREQUETERELANCEE = "0";
        private string _RQ_SIGNATURE = "";
        private string _RQ_SIGNATURE1 = "";
        private string _RS_CODESTATUTRECEVABILITE = "";
        private string _RQ_OBJETREQUETE = "";
        private string _SR_CODESERVICE = "";
        private string _RQ_DELAITRAITEMENTREQUETE = "";
        private string _RQ_OBSERVATIONDELAITRAITEMENTREQUETE = "";
        private string _RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = "";
        private string _RQ_DUREETRAITEMENTREQUETE = "";
        private string _RQ_DATEDEBUTTRAITEMENTREQUETE = "01/01/1900";
        private string _RQ_DATEFINTRAITEMENTREQUETE = "01/01/1900";
        private string _AC_CODEACTIONCORRECTIVE = "";
        private string _NS_CODENIVEAUSATISFACTION = "";
        private string _RQ_DATECLOTUREREQUETE = "01/01/1900";
        private string _NR_CODENATUREREQUETE = "";
        private string _TR_LIBELLETYEREQUETE = "";

        private string _CU_NUMEROUTILISATEUR = "";
        private string _CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = "";
        private string _CU_NOMUTILISATEUR = "";
        private string _CU_CONTACT = "";
        private string _CU_EMAIL = "";
        private string _RQ_AFFICHERINFOCLIENT = "";
        private string _NR_LIBELLENATUREREQUETE = "";
        private string _RE_CODEETAPE = "";
        private string _RE_LIBELLEETAPE = "";
        private string _AT_INDEXETAPE = "";
        private string _AT_DATECLOTUREETAPE = "01/01/1900";
        private string _AT_DATEDEBUTTRAITEMENTETAPE = "01/01/1900";
        private string _AT_DATEFINTRAITEMENTETAPE = "01/01/1900";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;
        private string _RT_CODETYPERELANCE = "";
        private string _PP_CODEPARAMETRE = "";
        private string _PP_VALEUR = "";

        private string _AG_CODEAGENCE = "";

        private string _RQ_NOMRAPPORT = "";
        private string _RQ_LIENRAPPORT = "";
        private string _TR_LIBELLETYEREQUETE_TRANSLATE = "";
        private string _RE_LIBELLEETAPE_TRANSLATE = "";

        private string _CT_DATEOUVERTURECONTENTIEUX = "01/01/1900";//13/04/2024
        private string _CT_DATECLOTURECONTENTIEUX = "01/01/1900";//13/04/2024


        private string _NOMBREREQUETES = "0";
        private string _NOMBREREQUETESENCOURS = "0";
        private string _NOMBREREQUETESATTRIBUEES = "0";
        private string _NOMBREREQUETEDEJATRAITER = "0";
        private string _NOMBREREQUETESTRAITEESDANSDELAIS = "0";
        private string _NOMBREREQUETESTRAITEESHORSDELAIS = "0";

        private string _CU_CODECOMPTEUTULISATEURASSOCIER = "";
        private string _NOMBREREQUETESTOTAL = "0";

        private List<clsReqrequete> _clsDocumentAssociesALaRequetes = null;
        private List<clsReqrequete> _clsDocumentAssociesAuContentieux = null;
        private string _FICHIERSJOINT = "";
        private string _CT_CODEREQUETECONTENTIEUX = "";


        #endregion

        #region ACCESSEURS

        public List<clsReqrequete> clsDocumentAssociesALaRequetes
        {
            get { return _clsDocumentAssociesALaRequetes; }
            set { _clsDocumentAssociesALaRequetes = value; }
        }

        public List<clsReqrequete> clsDocumentAssociesAuContentieux
        {
            get { return _clsDocumentAssociesAuContentieux; }
            set { _clsDocumentAssociesAuContentieux = value; }
        }

        public string CU_CODECOMPTEUTULISATEURASSOCIER
        {
            get { return _CU_CODECOMPTEUTULISATEURASSOCIER; }
            set { _CU_CODECOMPTEUTULISATEURASSOCIER = value; }
        }

        public string NOMBREREQUETES
        {
            get { return _NOMBREREQUETES; }
            set { _NOMBREREQUETES = value; }
        }

        public string NOMBREREQUETESENCOURS
        {
            get { return _NOMBREREQUETESENCOURS; }
            set { _NOMBREREQUETESENCOURS = value; }
        }

        public string NOMBREREQUETESATTRIBUEES
        {
            get { return _NOMBREREQUETESATTRIBUEES; }
            set { _NOMBREREQUETESATTRIBUEES = value; }
        }

        public string NOMBREREQUETEDEJATRAITER
        {
            get { return _NOMBREREQUETEDEJATRAITER; }
            set { _NOMBREREQUETEDEJATRAITER = value; }
        }


        public string NOMBREREQUETESTRAITEESDANSDELAIS
        {
            get { return _NOMBREREQUETESTRAITEESDANSDELAIS; }
            set { _NOMBREREQUETESTRAITEESDANSDELAIS = value; }
        }

        public string NOMBREREQUETESTRAITEESHORSDELAIS
        {
            get { return _NOMBREREQUETESTRAITEESHORSDELAIS; }
            set { _NOMBREREQUETESTRAITEESHORSDELAIS = value; }
        }

        public string NR_CODENATUREREQUETE
        {
            get { return _NR_CODENATUREREQUETE; }
            set { _NR_CODENATUREREQUETE = value; }
        }
        public string NR_LIBELLENATUREREQUETE
        {
            get { return _NR_LIBELLENATUREREQUETE; }
            set { _NR_LIBELLENATUREREQUETE = value; }
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

        public string RQ_CODEREQUETE
        {
            get { return _RQ_CODEREQUETE; }
            set { _RQ_CODEREQUETE = value; }
        }

        public string TR_LIBELLETYEREQUETE
        {
            get { return _TR_LIBELLETYEREQUETE; }
            set { _TR_LIBELLETYEREQUETE = value; }
        }

        public string TR_LIBELLETYEREQUETE_TRANSLATE
        {
            get { return _TR_LIBELLETYEREQUETE_TRANSLATE; }
            set { _TR_LIBELLETYEREQUETE_TRANSLATE = value; }
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

        public string RQ_DATESAISIEREQUETE
        {
            get { return _RQ_DATESAISIEREQUETE; }
            set { _RQ_DATESAISIEREQUETE = value; }
        }

        public string CU_CODECOMPTEUTULISATEURAGENTENCHARGE
        {
            get { return _CU_CODECOMPTEUTULISATEURAGENTENCHARGE; }
            set { _CU_CODECOMPTEUTULISATEURAGENTENCHARGE = value; }
        }

        public string RQ_DATETRANSFERTREQUETE
        {
            get { return _RQ_DATETRANSFERTREQUETE; }
            set { _RQ_DATETRANSFERTREQUETE = value; }
        }

        public string RQ_CODEREQUETERELANCEE
        {
            get { return _RQ_CODEREQUETERELANCEE; }
            set { _RQ_CODEREQUETERELANCEE = value; }
        }

        public string RQ_SIGNATURE
        {
            get { return _RQ_SIGNATURE; }
            set { _RQ_SIGNATURE = value; }
        }

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
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

        public string RQ_DATEDEBUTTRAITEMENTREQUETE
        {
            get { return _RQ_DATEDEBUTTRAITEMENTREQUETE; }
            set { _RQ_DATEDEBUTTRAITEMENTREQUETE = value; }
        }

        public string RQ_DATEFINTRAITEMENTREQUETE
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
        public string RE_CODEETAPE
        {
            get { return _RE_CODEETAPE; }
            set { _RE_CODEETAPE = value; }
        }

        public string RE_LIBELLEETAPE
        {
            get { return _RE_LIBELLEETAPE; }
            set { _RE_LIBELLEETAPE = value; }
        }

        public string RE_LIBELLEETAPE_TRANSLATE
        {
            get { return _RE_LIBELLEETAPE_TRANSLATE; }
            set { _RE_LIBELLEETAPE_TRANSLATE = value; }
        }

        public string RQ_DATECLOTUREREQUETE
        {
            get { return _RQ_DATECLOTUREREQUETE; }
            set { _RQ_DATECLOTUREREQUETE = value; }
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
        public string RQ_AFFICHERINFOCLIENT
        {
            get { return _RQ_AFFICHERINFOCLIENT; }
            set { _RQ_AFFICHERINFOCLIENT = value; }
        }

        public string RQ_NOMRAPPORT
        {
            get { return _RQ_NOMRAPPORT; }
            set { _RQ_NOMRAPPORT = value; }
        }

        public string RQ_LIENRAPPORT
        {
            get { return _RQ_LIENRAPPORT; }
            set { _RQ_LIENRAPPORT = value; }
        }

        public string CT_DATEOUVERTURECONTENTIEUX
        {
            get { return _CT_DATEOUVERTURECONTENTIEUX; }
            set { _CT_DATEOUVERTURECONTENTIEUX = value; }
        }
        public string CT_DATECLOTURECONTENTIEUX
        {
            get { return _CT_DATECLOTURECONTENTIEUX; }
            set { _CT_DATECLOTURECONTENTIEUX = value; }
        }

        public string AT_INDEXETAPE
        {
            get { return _AT_INDEXETAPE; }
            set { _AT_INDEXETAPE = value; }
        }
        public string AT_DATECLOTUREETAPE
        {
            get { return _AT_DATECLOTUREETAPE; }
            set { _AT_DATECLOTUREETAPE = value; }
        }

        public string AT_DATEDEBUTTRAITEMENTETAPE
        {
            get { return _AT_DATEDEBUTTRAITEMENTETAPE; }
            set { _AT_DATEDEBUTTRAITEMENTETAPE = value; }
        }
        public string AT_DATEFINTRAITEMENTETAPE
        {
            get { return _AT_DATEFINTRAITEMENTETAPE; }
            set { _AT_DATEFINTRAITEMENTETAPE = value; }
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
        public string RT_CODETYPERELANCE
        {
            get { return _RT_CODETYPERELANCE; }
            set { _RT_CODETYPERELANCE = value; }
        }

        public string NOMBREREQUETESTOTAL
        {
            get { return _NOMBREREQUETESTOTAL; }
            set { _NOMBREREQUETESTOTAL = value; }
        }

        public string FICHIERSJOINT
        {
            get { return _FICHIERSJOINT; }
            set { _FICHIERSJOINT = value; }
        }
        public string CT_CODEREQUETECONTENTIEUX
        {
            get { return _CT_CODEREQUETECONTENTIEUX; }
            set { _CT_CODEREQUETECONTENTIEUX = value; }
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
            this.RQ_DATECLOTUREREQUETE = clsReqrequete.RQ_DATECLOTUREREQUETE;
            this.RQ_SIGNATURE1 = RQ_SIGNATURE1;
            this.NR_CODENATUREREQUETE = NR_CODENATUREREQUETE;
            this.TR_LIBELLETYEREQUETE = TR_LIBELLETYEREQUETE;
            this.CU_NUMEROUTILISATEUR = CU_NUMEROUTILISATEUR;
            this.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = CU_ADRESSEGEOGRAPHIQUEUTILISATEUR;
            this.CU_NOMUTILISATEUR = CU_NOMUTILISATEUR;
            this.CU_CONTACT = CU_CONTACT;
            this.CU_EMAIL = CU_EMAIL;
            this.RQ_AFFICHERINFOCLIENT = RQ_AFFICHERINFOCLIENT;
            this.NR_LIBELLENATUREREQUETE = NR_LIBELLENATUREREQUETE;
            this.RE_CODEETAPE = RE_CODEETAPE;
            this.RE_LIBELLEETAPE = RE_LIBELLEETAPE;
            this.AT_INDEXETAPE = AT_INDEXETAPE;
            this.AT_DATECLOTUREETAPE = AT_DATECLOTUREETAPE;
            this.AT_DATEDEBUTTRAITEMENTETAPE = AT_DATEDEBUTTRAITEMENTETAPE;
            this.AT_DATEFINTRAITEMENTETAPE = AT_DATEFINTRAITEMENTETAPE;
            this.RT_CODETYPERELANCE = clsReqrequete.RT_CODETYPERELANCE;

            this.PP_CODEPARAMETRE = clsReqrequete.PP_CODEPARAMETRE;
            this.PP_VALEUR = clsReqrequete.PP_VALEUR;

            this.AG_CODEAGENCE = clsReqrequete.AG_CODEAGENCE;

            this.RQ_NOMRAPPORT = clsReqrequete.RQ_NOMRAPPORT;
            this.RQ_LIENRAPPORT = clsReqrequete.RQ_LIENRAPPORT;
            this.TR_LIBELLETYEREQUETE_TRANSLATE = clsReqrequete.TR_LIBELLETYEREQUETE_TRANSLATE;
            this.RE_LIBELLEETAPE_TRANSLATE = clsReqrequete.RE_LIBELLEETAPE_TRANSLATE;

            this.CT_DATEOUVERTURECONTENTIEUX = clsReqrequete.CT_DATEOUVERTURECONTENTIEUX;
            this.CT_DATECLOTURECONTENTIEUX = clsReqrequete.CT_DATECLOTURECONTENTIEUX;

            this.NOMBREREQUETES = clsReqrequete.NOMBREREQUETES;
            this.NOMBREREQUETESENCOURS = clsReqrequete.NOMBREREQUETESENCOURS;
            this.NOMBREREQUETESATTRIBUEES = clsReqrequete.NOMBREREQUETESATTRIBUEES;
            this.NOMBREREQUETEDEJATRAITER = clsReqrequete.NOMBREREQUETEDEJATRAITER;
            this.NOMBREREQUETESTRAITEESDANSDELAIS = clsReqrequete.NOMBREREQUETESTRAITEESDANSDELAIS;
            this.NOMBREREQUETESTRAITEESHORSDELAIS = clsReqrequete.NOMBREREQUETESTRAITEESHORSDELAIS;

            this.CU_CODECOMPTEUTULISATEURASSOCIER = clsReqrequete.CU_CODECOMPTEUTULISATEURASSOCIER;
            this.NOMBREREQUETESTOTAL = clsReqrequete.NOMBREREQUETESTOTAL;

            this.clsResultat = clsReqrequete.clsResultat;
            this.clsObjetEnvoi = clsReqrequete.clsObjetEnvoi;

            this.clsDocumentAssociesALaRequetes = clsReqrequete.clsDocumentAssociesALaRequetes;
            this.clsDocumentAssociesAuContentieux = clsReqrequete.clsDocumentAssociesAuContentieux;
            this.FICHIERSJOINT = clsReqrequete.FICHIERSJOINT;
            this.CT_CODEREQUETECONTENTIEUX = clsReqrequete.CT_CODEREQUETECONTENTIEUX;
        }

        #endregion

    }
}
