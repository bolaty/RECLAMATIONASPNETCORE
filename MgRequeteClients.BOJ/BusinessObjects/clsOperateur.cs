using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsOperateur
    {
        private string _OP_CODEOPERATEUR = "";

        private string _AG_CODEAGENCE = "";
        private string _SO_CODESOCIETE = "";
        private string _PO_CODEPROFIL = "";
        private string _SR_CODESERVICE = "";
        private string _PV_CODEPOINTVENTE = "";
        private string _PL_CODENUMCOMPTE = "";
        private string _PL_CODENUMCOMPTECOFFRE = "";
        private string _PL_CODENUMCOMPTESORTIEPROVISOIRE = "";
        private string _PL_NUMCOMPTE = "";
        private string _PL_NUMCOMPTECOFFRE = "";
        private string _PL_NUMCOMPTESORTIEPROVISOIRE = "";


        private string _PL_LIBELLE = "";
        private string _PL_LIBELLECOFFRE = "";
        private string _PL_LIBELLESORTIEPROVISOIRE = "";

        private string _PL_NUMCOMPTECOMPTEBANQUEMOBILE = "";
        private string _PL_CODENUMCOMPTEBANQUEMOBILE = "";


        private string _OP_NOMPRENOM = "";
        private string _OP_LOGIN = "";
        private string _OP_MOTPASSE = "";
        private string _OP_ACTIF = "O";
        private string _OP_TELEPHONE = "";
        private string _OP_EMAIL = "";
        private string _OP_JOURNEEOUVERTE = "O";
        private string _OP_AGENTCREDIT = "N";
        private string _OP_GESTIONNAIRE = "N";
        private string _OP_CAISSIER = "N";
        private string _OP_AGENTBUDGET = "N";
        private string _OP_IMPRESSIONAUTOMATIQUE = "";
        private string _OP_IMPRESSIONAUTOMATIQUETONTINE = "";



        private string _OP_CREATIONJOURNEE = "N";
        private string _OP_FERMERTUREJOURNEE = "N";
        private string _OP_CREATIONPROFIL = "N";
        private string _OP_CREATIONOPERATEUR = "O";

        private string _OP_CLIENTVISA = "N";
        private string _OP_VALIDATIONOD = "N";

        private string _OP_EXTOURNEOPERATION = "N";


        private string _OP_FERMERTURECAISSE = "N";
        private string _OP_REOUVERTURECAISSE = "N";

        private string _OP_MODIFICATIONCOMPTEWEB = "N";
        private string _OP_MODIFICATIONCOMPTESMS = "N";
        private string _OP_MODIFICATIONCOMPTEMOBILE = "N";
        private string _OP_CREATIONCOMPTEMOBILE = "N";
        private string _OP_BLOCAGECOMPTE = "N";
        private string _OP_DEBLOCAGECOMPTE = "N";
        private string _OP_MODIFICATIONTELEPHONECLIENT = "";

        private DateTime _OP_DATESAISIE = DateTime.Parse("01/01/1900");
        private DateTime _OP_DATEPREMIERECONNEXION = DateTime.Parse("01/01/1900");
        private double _OP_MONTANTMAXIMUMAUTORISEPARRETRAIT = 0;
        private double _OP_MONTANTTOTALENCAISSEAUTORISE = 0;

        private string _OP_GESTIONNAIRECOMPTEMOBILE = "";
        private string _OP_AGENTCREDITMOBILE = "";
        private string _OP_AGENTDECOLLECTEETDECREDIT = "";
        private string _CM_IDCOMMERCIAL = "";

        private string _OP_CODEOPERATEURSAISIE = "";
        private string _OP_CODEOPERATEURINITIAL = "";
        private string _OP_CODEOPERATEURFINAL = "";
        private string _TYPEOPERATION = "";
        private string _LG_CODELANGUE = "";
        private string _CL_IDCLIENT = "";
        private string _OP_CONNECTE = "N";
        private string _OP_MODIFICATIONPHOTOETSIGNATURECLIENT = "";
        private string _LO_CODELOGICIEL = "";
        private string _OP_TRANSFERTCREDITPARMOBILEMONEY = "N";
        private string _AG_EMAILMOTDEPASSE = "";
        private string _AG_EMAIL = "";
        private string _LIEN_APPCLIENT = "";

        public string LIEN_APPCLIENT
        {
            get { return _LIEN_APPCLIENT; }
            set { _LIEN_APPCLIENT = value; }
        }


        public string AG_EMAIL
        {
            get { return _AG_EMAIL; }
            set { _AG_EMAIL = value; }
        }

        public string AG_EMAILMOTDEPASSE
        {
            get { return _AG_EMAILMOTDEPASSE; }
            set { _AG_EMAILMOTDEPASSE = value; }
        }
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
        public string SO_CODESOCIETE
        {
            get { return _SO_CODESOCIETE; }
            set { _SO_CODESOCIETE = value; }
        }

        public string PO_CODEPROFIL
        {
            get { return _PO_CODEPROFIL; }
            set { _PO_CODEPROFIL = value; }
        }

        public string SR_CODESERVICE
        {
            get { return _SR_CODESERVICE; }
            set { _SR_CODESERVICE = value; }
        }

        public string PV_CODEPOINTVENTE
        {
            get { return _PV_CODEPOINTVENTE; }
            set { _PV_CODEPOINTVENTE = value; }
        }

        public string PL_CODENUMCOMPTE
        {
            get { return _PL_CODENUMCOMPTE; }
            set { _PL_CODENUMCOMPTE = value; }
        }

        public string PL_CODENUMCOMPTECOFFRE
        {
            get { return _PL_CODENUMCOMPTECOFFRE; }
            set { _PL_CODENUMCOMPTECOFFRE = value; }
        }
        public string PL_CODENUMCOMPTESORTIEPROVISOIRE
        {
            get { return _PL_CODENUMCOMPTESORTIEPROVISOIRE; }
            set { _PL_CODENUMCOMPTESORTIEPROVISOIRE = value; }
        }
        public string PL_NUMCOMPTE
        {
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
        }
        public string PL_NUMCOMPTECOFFRE
        {
            get { return _PL_NUMCOMPTECOFFRE; }
            set { _PL_NUMCOMPTECOFFRE = value; }
        }
        public string PL_NUMCOMPTESORTIEPROVISOIRE
        {
            get { return _PL_NUMCOMPTESORTIEPROVISOIRE; }
            set { _PL_NUMCOMPTESORTIEPROVISOIRE = value; }
        }
        public string PL_LIBELLE
        {
            get { return _PL_LIBELLE; }
            set { _PL_LIBELLE = value; }
        }
        public string PL_LIBELLECOFFRE
        {
            get { return _PL_LIBELLECOFFRE; }
            set { _PL_LIBELLECOFFRE = value; }
        }
        public string PL_LIBELLESORTIEPROVISOIRE
        {
            get { return _PL_LIBELLESORTIEPROVISOIRE; }
            set { _PL_LIBELLESORTIEPROVISOIRE = value; }
        }

        public string PL_NUMCOMPTECOMPTEBANQUEMOBILE
        {
            get { return _PL_NUMCOMPTECOMPTEBANQUEMOBILE; }
            set { _PL_NUMCOMPTECOMPTEBANQUEMOBILE = value; }
        }
        public string PL_CODENUMCOMPTEBANQUEMOBILE
        {
            get { return _PL_CODENUMCOMPTEBANQUEMOBILE; }
            set { _PL_CODENUMCOMPTEBANQUEMOBILE = value; }
        }





        public string OP_NOMPRENOM
        {
            get { return _OP_NOMPRENOM; }
            set { _OP_NOMPRENOM = value; }
        }
        public string OP_LOGIN
        {
            get { return _OP_LOGIN; }
            set { _OP_LOGIN = value; }
        }
        public string OP_MOTPASSE
        {
            get { return _OP_MOTPASSE; }
            set { _OP_MOTPASSE = value; }
        }
        public string OP_ACTIF
        {
            get { return _OP_ACTIF; }
            set { _OP_ACTIF = value; }
        }
        public string OP_TELEPHONE
        {
            get { return _OP_TELEPHONE; }
            set { _OP_TELEPHONE = value; }
        }
        public string OP_EMAIL
        {
            get { return _OP_EMAIL; }
            set { _OP_EMAIL = value; }
        }
        public string OP_JOURNEEOUVERTE
        {
            get { return _OP_JOURNEEOUVERTE; }
            set { _OP_JOURNEEOUVERTE = value; }
        }
        public string OP_AGENTCREDIT
        {
            get { return _OP_AGENTCREDIT; }
            set { _OP_AGENTCREDIT = value; }
        }
        public string OP_GESTIONNAIRE
        {
            get { return _OP_GESTIONNAIRE; }
            set { _OP_GESTIONNAIRE = value; }
        }
        public string OP_CAISSIER
        {
            get { return _OP_CAISSIER; }
            set { _OP_CAISSIER = value; }
        }
        public string OP_IMPRESSIONAUTOMATIQUE
        {
            get { return _OP_IMPRESSIONAUTOMATIQUE; }
            set { _OP_IMPRESSIONAUTOMATIQUE = value; }
        }

        public string OP_IMPRESSIONAUTOMATIQUETONTINE
        {
            get { return _OP_IMPRESSIONAUTOMATIQUETONTINE; }
            set { _OP_IMPRESSIONAUTOMATIQUETONTINE = value; }
        }

        public string OP_AGENTBUDGET
        {
            get { return _OP_AGENTBUDGET; }
            set { _OP_AGENTBUDGET = value; }
        }

        public DateTime OP_DATESAISIE
        {
            get { return _OP_DATESAISIE; }
            set { _OP_DATESAISIE = value; }
        }

        public string OP_CREATIONJOURNEE
        {
            get { return _OP_CREATIONJOURNEE; }
            set { _OP_CREATIONJOURNEE = value; }
        }
        public string OP_FERMERTUREJOURNEE
        {
            get { return _OP_FERMERTUREJOURNEE; }
            set { _OP_FERMERTUREJOURNEE = value; }
        }
        public string OP_CREATIONPROFIL
        {
            get { return _OP_CREATIONPROFIL; }
            set { _OP_CREATIONPROFIL = value; }
        }

        public string OP_CREATIONOPERATEUR
        {
            get { return _OP_CREATIONOPERATEUR; }
            set { _OP_CREATIONOPERATEUR = value; }
        }


        public string OP_CLIENTVISA
        {
            get { return _OP_CLIENTVISA; }
            set { _OP_CLIENTVISA = value; }
        }
        public string OP_VALIDATIONOD
        {
            get { return _OP_VALIDATIONOD; }
            set { _OP_VALIDATIONOD = value; }
        }


        public string OP_EXTOURNEOPERATION
        {
            get { return _OP_EXTOURNEOPERATION; }
            set { _OP_EXTOURNEOPERATION = value; }
        }



        public string OP_FERMERTURECAISSE
        {
            get { return _OP_FERMERTURECAISSE; }
            set { _OP_FERMERTURECAISSE = value; }
        }

        public string OP_REOUVERTURECAISSE
        {
            get { return _OP_REOUVERTURECAISSE; }
            set { _OP_REOUVERTURECAISSE = value; }
        }



        public string OP_MODIFICATIONCOMPTEWEB
        {
            get { return _OP_MODIFICATIONCOMPTEWEB; }
            set { _OP_MODIFICATIONCOMPTEWEB = value; }
        }

        public string OP_MODIFICATIONCOMPTESMS
        {
            get { return _OP_MODIFICATIONCOMPTESMS; }
            set { _OP_MODIFICATIONCOMPTESMS = value; }
        }

        public string OP_MODIFICATIONCOMPTEMOBILE
        {
            get { return _OP_MODIFICATIONCOMPTEMOBILE; }
            set { _OP_MODIFICATIONCOMPTEMOBILE = value; }
        }

        public string OP_CREATIONCOMPTEMOBILE
        {
            get { return _OP_CREATIONCOMPTEMOBILE; }
            set { _OP_CREATIONCOMPTEMOBILE = value; }
        }

        public string OP_BLOCAGECOMPTE
        {
            get { return _OP_BLOCAGECOMPTE; }
            set { _OP_BLOCAGECOMPTE = value; }
        }

        public string OP_DEBLOCAGECOMPTE
        {
            get { return _OP_DEBLOCAGECOMPTE; }
            set { _OP_DEBLOCAGECOMPTE = value; }
        }

        public string OP_MODIFICATIONTELEPHONECLIENT
        {
            get { return _OP_MODIFICATIONTELEPHONECLIENT; }
            set { _OP_MODIFICATIONTELEPHONECLIENT = value; }
        }
        public double OP_MONTANTMAXIMUMAUTORISEPARRETRAIT
        {
            get { return _OP_MONTANTMAXIMUMAUTORISEPARRETRAIT; }
            set { _OP_MONTANTMAXIMUMAUTORISEPARRETRAIT = value; }
        }

        public double OP_MONTANTTOTALENCAISSEAUTORISE
        {
            get { return _OP_MONTANTTOTALENCAISSEAUTORISE; }
            set { _OP_MONTANTTOTALENCAISSEAUTORISE = value; }
        }
        public string OP_GESTIONNAIRECOMPTEMOBILE
        {
            get { return _OP_GESTIONNAIRECOMPTEMOBILE; }
            set { _OP_GESTIONNAIRECOMPTEMOBILE = value; }
        }

        public string OP_AGENTCREDITMOBILE
        {
            get { return _OP_AGENTCREDITMOBILE; }
            set { _OP_AGENTCREDITMOBILE = value; }
        }
        public DateTime OP_DATEPREMIERECONNEXION
        {
            get { return _OP_DATEPREMIERECONNEXION; }
            set { _OP_DATEPREMIERECONNEXION = value; }
        }
        public string OP_AGENTDECOLLECTEETDECREDIT
        {
            get { return _OP_AGENTDECOLLECTEETDECREDIT; }
            set { _OP_AGENTDECOLLECTEETDECREDIT = value; }
        }

        public string CM_IDCOMMERCIAL
        {
            get { return _CM_IDCOMMERCIAL; }
            set { _CM_IDCOMMERCIAL = value; }
        }

        public string LO_CODELOGICIEL
        {
            get { return _LO_CODELOGICIEL; }
            set { _LO_CODELOGICIEL = value; }
        }
        public string OP_TRANSFERTCREDITPARMOBILEMONEY
        {
            get { return _OP_TRANSFERTCREDITPARMOBILEMONEY; }
            set { _OP_TRANSFERTCREDITPARMOBILEMONEY = value; }
        }




        public string OP_CODEOPERATEURSAISIE
        {
            get { return _OP_CODEOPERATEURSAISIE; }
            set { _OP_CODEOPERATEURSAISIE = value; }
        }
        public string OP_CODEOPERATEURINITIAL
        {
            get { return _OP_CODEOPERATEURINITIAL; }
            set { _OP_CODEOPERATEURINITIAL = value; }
        }

        public string OP_CODEOPERATEURFINAL
        {
            get { return _OP_CODEOPERATEURFINAL; }
            set { _OP_CODEOPERATEURFINAL = value; }
        }

        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }
        public string LG_CODELANGUE
        {
            get { return _LG_CODELANGUE; }
            set { _LG_CODELANGUE = value; }
        }

        public string CL_IDCLIENT
        {
            get { return _CL_IDCLIENT; }
            set { _CL_IDCLIENT = value; }
        }
        public string OP_CONNECTE
        {
            get { return _OP_CONNECTE; }
            set { _OP_CONNECTE = value; }
        }
        public string OP_MODIFICATIONPHOTOETSIGNATURECLIENT
        {
            get { return _OP_MODIFICATIONPHOTOETSIGNATURECLIENT; }
            set { _OP_MODIFICATIONPHOTOETSIGNATURECLIENT = value; }
        }
        public clsOperateur() { }


        public clsOperateur(clsOperateur clsOperateur)
        {
            OP_CODEOPERATEUR = clsOperateur.OP_CODEOPERATEUR;
            AG_CODEAGENCE = clsOperateur.AG_CODEAGENCE;
            SO_CODESOCIETE = clsOperateur.SO_CODESOCIETE;
            PO_CODEPROFIL = clsOperateur.PO_CODEPROFIL;
            SR_CODESERVICE = clsOperateur.SR_CODESERVICE;
            PV_CODEPOINTVENTE = clsOperateur.PV_CODEPOINTVENTE;

            PL_CODENUMCOMPTE = clsOperateur.PL_CODENUMCOMPTE;
            PL_CODENUMCOMPTECOFFRE = clsOperateur.PL_CODENUMCOMPTECOFFRE;
            PL_CODENUMCOMPTESORTIEPROVISOIRE = clsOperateur.PL_CODENUMCOMPTESORTIEPROVISOIRE;

            PL_NUMCOMPTE = clsOperateur.PL_NUMCOMPTE;
            PL_NUMCOMPTECOFFRE = clsOperateur.PL_NUMCOMPTECOFFRE;
            PL_NUMCOMPTESORTIEPROVISOIRE = clsOperateur.PL_NUMCOMPTESORTIEPROVISOIRE;
            PL_LIBELLE = clsOperateur.PL_LIBELLE;
            PL_LIBELLECOFFRE = clsOperateur.PL_LIBELLECOFFRE;
            PL_LIBELLESORTIEPROVISOIRE = clsOperateur.PL_LIBELLESORTIEPROVISOIRE;

            PL_NUMCOMPTECOMPTEBANQUEMOBILE = clsOperateur.PL_NUMCOMPTECOMPTEBANQUEMOBILE;
            PL_CODENUMCOMPTEBANQUEMOBILE = clsOperateur.PL_CODENUMCOMPTEBANQUEMOBILE;


            OP_CREATIONJOURNEE = clsOperateur.OP_CREATIONJOURNEE;
            OP_FERMERTUREJOURNEE = clsOperateur.OP_FERMERTUREJOURNEE;
            OP_CREATIONPROFIL = clsOperateur.OP_CREATIONPROFIL;
            OP_CREATIONOPERATEUR = clsOperateur.OP_CREATIONOPERATEUR;

            OP_CLIENTVISA = clsOperateur.OP_CLIENTVISA;
            OP_VALIDATIONOD = clsOperateur.OP_VALIDATIONOD;

            OP_EXTOURNEOPERATION = clsOperateur.OP_EXTOURNEOPERATION;

            OP_FERMERTURECAISSE = clsOperateur.OP_FERMERTURECAISSE;
            OP_REOUVERTURECAISSE = clsOperateur.OP_REOUVERTURECAISSE;



            OP_NOMPRENOM = clsOperateur.OP_NOMPRENOM;
            OP_LOGIN = clsOperateur.OP_LOGIN;
            OP_MOTPASSE = clsOperateur.OP_MOTPASSE;
            OP_ACTIF = clsOperateur.OP_ACTIF;
            OP_TELEPHONE = clsOperateur.OP_TELEPHONE;
            OP_EMAIL = clsOperateur.OP_EMAIL;
            OP_JOURNEEOUVERTE = clsOperateur.OP_JOURNEEOUVERTE;
            OP_AGENTCREDIT = clsOperateur.OP_AGENTCREDIT;
            OP_GESTIONNAIRE = clsOperateur.OP_GESTIONNAIRE;
            OP_CAISSIER = clsOperateur.OP_CAISSIER;
            OP_IMPRESSIONAUTOMATIQUE = clsOperateur.OP_IMPRESSIONAUTOMATIQUE;
            OP_IMPRESSIONAUTOMATIQUETONTINE = clsOperateur.OP_IMPRESSIONAUTOMATIQUETONTINE;

            OP_DATESAISIE = clsOperateur.OP_DATESAISIE;
            OP_MONTANTMAXIMUMAUTORISEPARRETRAIT = clsOperateur.OP_MONTANTMAXIMUMAUTORISEPARRETRAIT;
            OP_MONTANTTOTALENCAISSEAUTORISE = clsOperateur.OP_MONTANTTOTALENCAISSEAUTORISE;
            OP_AGENTBUDGET = clsOperateur.OP_AGENTBUDGET;

            OP_MODIFICATIONCOMPTEWEB = clsOperateur.OP_MODIFICATIONCOMPTEWEB;
            OP_MODIFICATIONCOMPTESMS = clsOperateur.OP_MODIFICATIONCOMPTESMS;
            OP_MODIFICATIONCOMPTEMOBILE = clsOperateur.OP_MODIFICATIONCOMPTEMOBILE;
            OP_CREATIONCOMPTEMOBILE = clsOperateur.OP_CREATIONCOMPTEMOBILE;
            OP_BLOCAGECOMPTE = clsOperateur.OP_BLOCAGECOMPTE;
            OP_DEBLOCAGECOMPTE = clsOperateur.OP_DEBLOCAGECOMPTE;
            OP_MODIFICATIONTELEPHONECLIENT = clsOperateur.OP_MODIFICATIONTELEPHONECLIENT;


            OP_GESTIONNAIRECOMPTEMOBILE = clsOperateur.OP_GESTIONNAIRECOMPTEMOBILE;
            OP_AGENTCREDITMOBILE = clsOperateur.OP_AGENTCREDITMOBILE;
            OP_DATEPREMIERECONNEXION = clsOperateur.OP_DATEPREMIERECONNEXION;
            OP_AGENTDECOLLECTEETDECREDIT = clsOperateur.OP_AGENTDECOLLECTEETDECREDIT;
            CM_IDCOMMERCIAL = clsOperateur.CM_IDCOMMERCIAL;




            OP_CODEOPERATEURSAISIE = clsOperateur.OP_CODEOPERATEURSAISIE;
            OP_CODEOPERATEURINITIAL = clsOperateur.OP_CODEOPERATEURINITIAL;
            OP_CODEOPERATEURFINAL = clsOperateur.OP_CODEOPERATEURFINAL;
            TYPEOPERATION = clsOperateur.TYPEOPERATION;
            LG_CODELANGUE = clsOperateur.LG_CODELANGUE;
            CL_IDCLIENT = clsOperateur.CL_IDCLIENT;
            OP_CONNECTE = clsOperateur.OP_CONNECTE;
            OP_MODIFICATIONPHOTOETSIGNATURECLIENT = clsOperateur.OP_MODIFICATIONPHOTOETSIGNATURECLIENT;
            LO_CODELOGICIEL = clsOperateur.LO_CODELOGICIEL;
            LIEN_APPCLIENT = clsOperateur.LIEN_APPCLIENT;
            AG_EMAIL = clsOperateur.AG_EMAIL;
            AG_EMAILMOTDEPASSE = clsOperateur.AG_EMAILMOTDEPASSE;

            OP_TRANSFERTCREDITPARMOBILEMONEY = clsOperateur.OP_TRANSFERTCREDITPARMOBILEMONEY;
        }
    }
}
