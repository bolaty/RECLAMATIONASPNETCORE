using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.BOJ.BusinessObjects;
using MgRequeteClients.DAL.Interfaces;
using MgRequeteClients.Tools.Classes;
using Microsoft.Data.SqlClient;

namespace MgRequeteClients.DAL.Classes
{
    public class clsOperateurWSDAL : ITableDAL<clsOperateur>
    {

        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };
        clsPlancomptableWSDAL clsPlancomptableWSDAL = new clsPlancomptableWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(OP_CODEOPERATEUR) AS OP_CODEOPERATEUR  FROM dbo.FT_OPERATEUR(@CODECRYPTAGE)   " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(OP_CODEOPERATEUR) AS OP_CODEOPERATEUR  FROM dbo.FT_OPERATEUR(@CODECRYPTAGE)   " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(OP_CODEOPERATEUR) AS OP_CODEOPERATEUR  FROM dbo.OPERATEUR   " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsOperateur comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsOperateur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , PO_CODEPROFIL  ,SR_CODESERVICE,PV_CODEPOINTVENTE, PL_CODENUMCOMPTE  ,PL_CODENUMCOMPTECOFFRE,PL_CODENUMCOMPTESORTIEPROVISOIRE,PL_LIBELLECOFFRE,PL_LIBELLESORTIEPROVISOIRE, OP_NOMPRENOM  , OP_LOGIN  , OP_MOTPASSE  , OP_ACTIF  , OP_TELEPHONE  , OP_EMAIL  , OP_JOURNEEOUVERTE  ,  OP_GESTIONNAIRE  ,OP_AGENTCREDIT,OP_CAISSIER,OP_IMPRESSIONAUTOMATIQUE,OP_IMPRESSIONAUTOMATIQUETONTINE,OP_AGENTBUDGET,OP_DATESAISIE,OP_CREATIONJOURNEE,OP_FERMERTUREJOURNEE,OP_CREATIONPROFIL,OP_CREATIONOPERATEUR,OP_EXTOURNEOPERATION, OP_FERMERTURECAISSE,OP_REOUVERTURECAISSE,OP_AGENTDECOLLECTEETDECREDIT  FROM dbo.FT_OPERATEUR(@CODECRYPTAGE)   " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsOperateur clsOperateur = new clsOperateur();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsOperateur.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsOperateur.PO_CODEPROFIL = clsDonnee.vogDataReader["PO_CODEPROFIL"].ToString();
                    clsOperateur.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
                    clsOperateur.PV_CODEPOINTVENTE = clsDonnee.vogDataReader["PV_CODEPOINTVENTE"].ToString();


                    clsOperateur.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsOperateur.PL_CODENUMCOMPTECOFFRE = clsDonnee.vogDataReader["PL_CODENUMCOMPTECOFFRE"].ToString();
                    clsOperateur.PL_CODENUMCOMPTESORTIEPROVISOIRE = clsDonnee.vogDataReader["PL_CODENUMCOMPTESORTIEPROVISOIRE"].ToString();

                    clsOperateur.PL_LIBELLECOFFRE = clsDonnee.vogDataReader["PL_LIBELLECOFFRE"].ToString();
                    clsOperateur.PL_LIBELLESORTIEPROVISOIRE = clsDonnee.vogDataReader["PL_LIBELLESORTIEPROVISOIRE"].ToString();


                    clsOperateur.OP_NOMPRENOM = clsDonnee.vogDataReader["OP_NOMPRENOM"].ToString();
                    clsOperateur.OP_LOGIN = clsDonnee.vogDataReader["OP_LOGIN"].ToString();
                    clsOperateur.OP_MOTPASSE = clsDonnee.vogDataReader["OP_MOTPASSE"].ToString();
                    clsOperateur.OP_ACTIF = clsDonnee.vogDataReader["OP_ACTIF"].ToString();
                    clsOperateur.OP_TELEPHONE = clsDonnee.vogDataReader["OP_TELEPHONE"].ToString();
                    clsOperateur.OP_EMAIL = clsDonnee.vogDataReader["OP_EMAIL"].ToString();
                    clsOperateur.OP_JOURNEEOUVERTE = clsDonnee.vogDataReader["OP_JOURNEEOUVERTE"].ToString();
                    clsOperateur.OP_AGENTCREDIT = clsDonnee.vogDataReader["OP_AGENTCREDIT"].ToString();
                    clsOperateur.OP_GESTIONNAIRE = clsDonnee.vogDataReader["OP_GESTIONNAIRE"].ToString();
                    clsOperateur.OP_CAISSIER = clsDonnee.vogDataReader["OP_CAISSIER"].ToString();
                    clsOperateur.OP_IMPRESSIONAUTOMATIQUE = clsDonnee.vogDataReader["OP_IMPRESSIONAUTOMATIQUE"].ToString();
                    clsOperateur.OP_IMPRESSIONAUTOMATIQUETONTINE = clsDonnee.vogDataReader["OP_IMPRESSIONAUTOMATIQUETONTINE"].ToString();
                    clsOperateur.OP_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["OP_DATESAISIE"].ToString());
                    clsOperateur.OP_AGENTBUDGET = clsDonnee.vogDataReader["OP_AGENTBUDGET"].ToString();


                    clsOperateur.OP_CREATIONJOURNEE = clsDonnee.vogDataReader["OP_CREATIONJOURNEE"].ToString();
                    clsOperateur.OP_FERMERTUREJOURNEE = clsDonnee.vogDataReader["OP_FERMERTUREJOURNEE"].ToString();
                    clsOperateur.OP_CREATIONPROFIL = clsDonnee.vogDataReader["OP_CREATIONPROFIL"].ToString();
                    clsOperateur.OP_CREATIONOPERATEUR = clsDonnee.vogDataReader["OP_CREATIONOPERATEUR"].ToString();
                    clsOperateur.OP_EXTOURNEOPERATION = clsDonnee.vogDataReader["OP_EXTOURNEOPERATION"].ToString();

                    clsOperateur.OP_FERMERTURECAISSE = clsDonnee.vogDataReader["OP_FERMERTURECAISSE"].ToString();
                    clsOperateur.OP_REOUVERTURECAISSE = clsDonnee.vogDataReader["OP_REOUVERTURECAISSE"].ToString();
                    clsOperateur.OP_AGENTDECOLLECTEETDECREDIT = clsDonnee.vogDataReader["OP_AGENTDECOLLECTEETDECREDIT"].ToString();


                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsOperateur;
        }
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsOperateur </returns>
        ///<author>Home Technology</author>
        public List<clsOperateur> pvgSelectCompte(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT * FROM TEMPCOMPTEUTULISATEURRESULTAT" + vppCritere[0];
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsOperateur> clsOperateurs = new List<clsOperateur>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsOperateur clsOperateur = new clsOperateur();
                    clsOperateur.OP_LOGIN = clsDonnee.vogDataReader["OP_LOGIN"].ToString();
                    clsOperateur.OP_MOTPASSE = clsDonnee.vogDataReader["OP_MOTPASSE"].ToString();
                    clsOperateur.AG_EMAIL = clsDonnee.vogDataReader["AG_EMAIL"].ToString();
                    clsOperateur.AG_EMAILMOTDEPASSE = clsDonnee.vogDataReader["AG_EMAILMOTDEPASSE"].ToString();
                    clsOperateurs.Add(clsOperateur);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsOperateurs;
        }
        public void pvgInsert(clsDonnee clsDonnee, clsOperateur clsOperateur)
        {
            //Préparation des paramètres 
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.BigInt);
            vppParamOP_CODEOPERATEUR.Value = clsOperateur.OP_CODEOPERATEUR;

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.Int);
            vppParamAG_CODEAGENCE.Value = clsOperateur.AG_CODEAGENCE;

            SqlParameter vppParamPO_CODEPROFIL = new SqlParameter("@PO_CODEPROFIL", SqlDbType.VarChar, 2);
            vppParamPO_CODEPROFIL.Value = clsOperateur.PO_CODEPROFIL;

            SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
            vppParamSR_CODESERVICE.Value = clsOperateur.SR_CODESERVICE;


            SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 25);
            vppParamPV_CODEPOINTVENTE.Value = clsOperateur.PV_CODEPOINTVENTE;
            if (clsOperateur.PV_CODEPOINTVENTE == "") vppParamPV_CODEPOINTVENTE.Value = DBNull.Value;


            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            clsOperateur.PL_CODENUMCOMPTE = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTE).PL_CODENUMCOMPTE;
            vppParamPL_CODENUMCOMPTE.Value = clsOperateur.PL_CODENUMCOMPTE;
            if (clsOperateur.PL_CODENUMCOMPTE == "") vppParamPL_CODENUMCOMPTE.Value = DBNull.Value;


            SqlParameter vppParamPL_CODENUMCOMPTECOFFRE = new SqlParameter("@PL_CODENUMCOMPTECOFFRE", SqlDbType.VarChar, 25);
            clsOperateur.PL_CODENUMCOMPTECOFFRE = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTECOFFRE).PL_CODENUMCOMPTE;
            vppParamPL_CODENUMCOMPTECOFFRE.Value = clsOperateur.PL_CODENUMCOMPTECOFFRE;
            if (clsOperateur.PL_CODENUMCOMPTECOFFRE == "") vppParamPL_CODENUMCOMPTECOFFRE.Value = DBNull.Value;

            SqlParameter vppParamPL_CODENUMCOMPTESORTIEPROVISOIRE = new SqlParameter("@PL_CODENUMCOMPTESORTIEPROVISOIRE", SqlDbType.VarChar, 25);
            clsOperateur.PL_CODENUMCOMPTESORTIEPROVISOIRE = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTESORTIEPROVISOIRE).PL_CODENUMCOMPTE;
            vppParamPL_CODENUMCOMPTESORTIEPROVISOIRE.Value = clsOperateur.PL_CODENUMCOMPTESORTIEPROVISOIRE;
            if (clsOperateur.PL_CODENUMCOMPTESORTIEPROVISOIRE == "") vppParamPL_CODENUMCOMPTESORTIEPROVISOIRE.Value = DBNull.Value;

            SqlParameter vppParamPL_CODENUMCOMPTEBANQUEMOBILE = new SqlParameter("@PL_CODENUMCOMPTEBANQUEMOBILE", SqlDbType.VarChar, 25);
            clsOperateur.PL_CODENUMCOMPTEBANQUEMOBILE = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTECOMPTEBANQUEMOBILE).PL_CODENUMCOMPTE;
            vppParamPL_CODENUMCOMPTEBANQUEMOBILE.Value = clsOperateur.PL_CODENUMCOMPTEBANQUEMOBILE;
            if (clsOperateur.PL_CODENUMCOMPTEBANQUEMOBILE == "") vppParamPL_CODENUMCOMPTEBANQUEMOBILE.Value = DBNull.Value;


            SqlParameter vppParamOP_NOMPRENOM = new SqlParameter("@OP_NOMPRENOM", SqlDbType.VarChar, 1000);
            vppParamOP_NOMPRENOM.Value = clsOperateur.OP_NOMPRENOM;

            SqlParameter vppParamOP_LOGIN = new SqlParameter("@OP_LOGIN", SqlDbType.VarChar, 1000);
            vppParamOP_LOGIN.Value = clsOperateur.OP_LOGIN;

            SqlParameter vppParamOP_MOTPASSE = new SqlParameter("@OP_MOTPASSE", SqlDbType.VarChar, 1000);
            vppParamOP_MOTPASSE.Value = clsOperateur.OP_MOTPASSE;

            SqlParameter vppParamOP_ACTIF = new SqlParameter("@OP_ACTIF", SqlDbType.VarChar, 1);
            vppParamOP_ACTIF.Value = clsOperateur.OP_ACTIF;

            SqlParameter vppParamOP_TELEPHONE = new SqlParameter("@OP_TELEPHONE", SqlDbType.VarChar, 1000);
            vppParamOP_TELEPHONE.Value = clsOperateur.OP_TELEPHONE;

            SqlParameter vppParamOP_EMAIL = new SqlParameter("@OP_EMAIL", SqlDbType.VarChar, 1000);
            vppParamOP_EMAIL.Value = clsOperateur.OP_EMAIL;

            SqlParameter vppParamOP_JOURNEEOUVERTE = new SqlParameter("@OP_JOURNEEOUVERTE", SqlDbType.VarChar, 1);
            vppParamOP_JOURNEEOUVERTE.Value = clsOperateur.OP_JOURNEEOUVERTE;

            SqlParameter vppParamOP_GESTIONNAIRE = new SqlParameter("@OP_GESTIONNAIRE", SqlDbType.VarChar, 1);
            vppParamOP_GESTIONNAIRE.Value = clsOperateur.OP_GESTIONNAIRE;

            SqlParameter vppParamOP_AGENTCREDIT = new SqlParameter("@OP_AGENTCREDIT", SqlDbType.VarChar, 1);
            vppParamOP_AGENTCREDIT.Value = clsOperateur.OP_AGENTCREDIT;

            SqlParameter vppParamOP_CAISSIER = new SqlParameter("@OP_CAISSIER", SqlDbType.VarChar, 1);
            vppParamOP_CAISSIER.Value = clsOperateur.OP_CAISSIER;

            SqlParameter vppParamOP_IMPRESSIONAUTOMATIQUE = new SqlParameter("@OP_IMPRESSIONAUTOMATIQUE", SqlDbType.VarChar, 1);
            vppParamOP_IMPRESSIONAUTOMATIQUE.Value = clsOperateur.OP_IMPRESSIONAUTOMATIQUE;


            SqlParameter vppParamOP_IMPRESSIONAUTOMATIQUETONTINE = new SqlParameter("@OP_IMPRESSIONAUTOMATIQUETONTINE", SqlDbType.VarChar, 1);
            vppParamOP_IMPRESSIONAUTOMATIQUETONTINE.Value = clsOperateur.OP_IMPRESSIONAUTOMATIQUETONTINE;

            SqlParameter vppParamOP_CREATIONJOURNEE = new SqlParameter("@OP_CREATIONJOURNEE", SqlDbType.VarChar, 1);
            vppParamOP_CREATIONJOURNEE.Value = clsOperateur.OP_CREATIONJOURNEE;

            SqlParameter vppParamOP_FERMERTUREJOURNEE = new SqlParameter("@OP_FERMERTUREJOURNEE", SqlDbType.VarChar, 1);
            vppParamOP_FERMERTUREJOURNEE.Value = clsOperateur.OP_FERMERTUREJOURNEE;

            SqlParameter vppParamOP_CREATIONPROFIL = new SqlParameter("@OP_CREATIONPROFIL", SqlDbType.VarChar, 1);
            vppParamOP_CREATIONPROFIL.Value = clsOperateur.OP_CREATIONPROFIL;

            SqlParameter vppParamOP_CREATIONOPERATEUR = new SqlParameter("@OP_CREATIONOPERATEUR", SqlDbType.VarChar, 1);
            vppParamOP_CREATIONOPERATEUR.Value = clsOperateur.OP_CREATIONOPERATEUR;


            SqlParameter vppParamOP_CLIENTVISA = new SqlParameter("@OP_CLIENTVISA", SqlDbType.VarChar, 1);
            vppParamOP_CLIENTVISA.Value = clsOperateur.OP_CLIENTVISA;
            SqlParameter vppParamOP_VALIDATIONOD = new SqlParameter("@OP_VALIDATIONOD", SqlDbType.VarChar, 1);
            vppParamOP_VALIDATIONOD.Value = clsOperateur.OP_VALIDATIONOD;


            SqlParameter vppParamOP_EXTOURNEOPERATION = new SqlParameter("@OP_EXTOURNEOPERATION", SqlDbType.VarChar, 1);
            vppParamOP_EXTOURNEOPERATION.Value = clsOperateur.OP_EXTOURNEOPERATION;


            SqlParameter vppParamOP_FERMERTURECAISSE = new SqlParameter("@OP_FERMERTURECAISSE", SqlDbType.VarChar, 1);
            vppParamOP_FERMERTURECAISSE.Value = clsOperateur.OP_FERMERTURECAISSE;

            SqlParameter vppParamOP_REOUVERTURECAISSE = new SqlParameter("@OP_REOUVERTURECAISSE", SqlDbType.VarChar, 1);
            vppParamOP_REOUVERTURECAISSE.Value = clsOperateur.OP_REOUVERTURECAISSE;



            SqlParameter vppParamOP_MODIFICATIONCOMPTEWEB = new SqlParameter("@OP_MODIFICATIONCOMPTEWEB", SqlDbType.VarChar, 1);
            vppParamOP_MODIFICATIONCOMPTEWEB.Value = clsOperateur.OP_MODIFICATIONCOMPTEWEB;

            SqlParameter vppParamOP_MODIFICATIONCOMPTESMS = new SqlParameter("@OP_MODIFICATIONCOMPTESMS", SqlDbType.VarChar, 1);
            vppParamOP_MODIFICATIONCOMPTESMS.Value = clsOperateur.OP_MODIFICATIONCOMPTESMS;

            SqlParameter vppParamOP_MODIFICATIONCOMPTEMOBILE = new SqlParameter("@OP_MODIFICATIONCOMPTEMOBILE", SqlDbType.VarChar, 1);
            vppParamOP_MODIFICATIONCOMPTEMOBILE.Value = clsOperateur.OP_MODIFICATIONCOMPTEMOBILE;

            SqlParameter vppParamOP_CREATIONCOMPTEMOBILE = new SqlParameter("@OP_CREATIONCOMPTEMOBILE", SqlDbType.VarChar, 1);
            vppParamOP_CREATIONCOMPTEMOBILE.Value = clsOperateur.OP_CREATIONCOMPTEMOBILE;

            SqlParameter vppParamOP_BLOCAGECOMPTE = new SqlParameter("@OP_BLOCAGECOMPTE", SqlDbType.VarChar, 1);
            vppParamOP_BLOCAGECOMPTE.Value = clsOperateur.OP_BLOCAGECOMPTE;

            SqlParameter vppParamOP_DEBLOCAGECOMPTE = new SqlParameter("@OP_DEBLOCAGECOMPTE", SqlDbType.VarChar, 1);
            vppParamOP_DEBLOCAGECOMPTE.Value = clsOperateur.OP_DEBLOCAGECOMPTE;


            SqlParameter vppParamOP_MODIFICATIONTELEPHONECLIENT = new SqlParameter("@OP_MODIFICATIONTELEPHONECLIENT", SqlDbType.VarChar, 1);
            vppParamOP_MODIFICATIONTELEPHONECLIENT.Value = clsOperateur.OP_MODIFICATIONTELEPHONECLIENT;

            SqlParameter vppParamOP_AGENTBUDGET = new SqlParameter("@OP_AGENTBUDGET", SqlDbType.VarChar, 1);
            vppParamOP_AGENTBUDGET.Value = clsOperateur.OP_AGENTBUDGET;


            SqlParameter vppParamOP_GESTIONNAIRECOMPTEMOBILE = new SqlParameter("@OP_GESTIONNAIRECOMPTEMOBILE", SqlDbType.VarChar, 1);
            vppParamOP_GESTIONNAIRECOMPTEMOBILE.Value = clsOperateur.OP_GESTIONNAIRECOMPTEMOBILE;

            SqlParameter vppParamOP_AGENTCREDITMOBILE = new SqlParameter("@OP_AGENTCREDITMOBILE", SqlDbType.VarChar, 1);
            vppParamOP_AGENTCREDITMOBILE.Value = clsOperateur.OP_AGENTCREDITMOBILE;

            SqlParameter vppParamOP_AGENTDECOLLECTEETDECREDIT = new SqlParameter("@OP_AGENTDECOLLECTEETDECREDIT", SqlDbType.VarChar, 1);
            vppParamOP_AGENTDECOLLECTEETDECREDIT.Value = clsOperateur.OP_AGENTDECOLLECTEETDECREDIT;

            SqlParameter vppParamOP_MODIFICATIONPHOTOETSIGNATURECLIENT = new SqlParameter("@OP_MODIFICATIONPHOTOETSIGNATURECLIENT", SqlDbType.VarChar, 1);
            vppParamOP_MODIFICATIONPHOTOETSIGNATURECLIENT.Value = clsOperateur.OP_MODIFICATIONPHOTOETSIGNATURECLIENT;

            SqlParameter vppParamOP_MONTANTMAXIMUMAUTORISEPARRETRAIT = new SqlParameter("@OP_MONTANTMAXIMUMAUTORISEPARRETRAIT", SqlDbType.Money);
            vppParamOP_MONTANTMAXIMUMAUTORISEPARRETRAIT.Value = clsOperateur.OP_MONTANTMAXIMUMAUTORISEPARRETRAIT;


            SqlParameter vppParamOP_MONTANTTOTALENCAISSEAUTORISE = new SqlParameter("@OP_MONTANTTOTALENCAISSEAUTORISE", SqlDbType.Money);
            vppParamOP_MONTANTTOTALENCAISSEAUTORISE.Value = clsOperateur.OP_MONTANTTOTALENCAISSEAUTORISE;


            SqlParameter vppParamOP_DATESAISIE = new SqlParameter("@OP_DATESAISIE", SqlDbType.DateTime);
            vppParamOP_DATESAISIE.Value = clsOperateur.OP_DATESAISIE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamCM_IDCOMMERCIAL = new SqlParameter("@CM_IDCOMMERCIAL", SqlDbType.VarChar, 25);
            vppParamCM_IDCOMMERCIAL.Value = clsOperateur.CM_IDCOMMERCIAL;
            if (clsOperateur.CM_IDCOMMERCIAL == "") vppParamCM_IDCOMMERCIAL.Value = DBNull.Value;


            SqlParameter vppParamLO_CODELOGICIEL = new SqlParameter("@LO_CODELOGICIEL", SqlDbType.VarChar, 25);
            vppParamLO_CODELOGICIEL.Value = clsOperateur.LO_CODELOGICIEL;

            SqlParameter vppParamOP_TRANSFERTCREDITPARMOBILEMONEY = new SqlParameter("@OP_TRANSFERTCREDITPARMOBILEMONEY", SqlDbType.VarChar, 1);
            vppParamOP_TRANSFERTCREDITPARMOBILEMONEY.Value = clsOperateur.OP_TRANSFERTCREDITPARMOBILEMONEY;

            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  @OP_CODEOPERATEUR, @AG_CODEAGENCE, @PO_CODEPROFIL,@SR_CODESERVICE,@PV_CODEPOINTVENTE, @PL_CODENUMCOMPTE, @PL_CODENUMCOMPTECOFFRE, @PL_CODENUMCOMPTESORTIEPROVISOIRE,@PL_CODENUMCOMPTEBANQUEMOBILE, @OP_NOMPRENOM, @OP_LOGIN, @OP_MOTPASSE, @OP_ACTIF, @OP_TELEPHONE, @OP_EMAIL, @OP_JOURNEEOUVERTE, @OP_DATESAISIE, @OP_GESTIONNAIRE, @OP_AGENTCREDIT,@OP_CAISSIER,@OP_AGENTBUDGET,@OP_IMPRESSIONAUTOMATIQUE,@OP_IMPRESSIONAUTOMATIQUETONTINE,@OP_CREATIONJOURNEE,@OP_FERMERTUREJOURNEE,@OP_CREATIONPROFIL,@OP_CREATIONOPERATEUR,@OP_EXTOURNEOPERATION,@OP_FERMERTURECAISSE,@OP_REOUVERTURECAISSE,@OP_MONTANTMAXIMUMAUTORISEPARRETRAIT,@OP_MONTANTTOTALENCAISSEAUTORISE,@OP_MODIFICATIONCOMPTEWEB,@OP_MODIFICATIONCOMPTESMS,@OP_MODIFICATIONCOMPTEMOBILE,@OP_CREATIONCOMPTEMOBILE,@OP_BLOCAGECOMPTE,@OP_DEBLOCAGECOMPTE,@OP_GESTIONNAIRECOMPTEMOBILE,@OP_AGENTCREDITMOBILE,@OP_MODIFICATIONTELEPHONECLIENT,@OP_AGENTDECOLLECTEETDECREDIT,@CODECRYPTAGE, 0,@CM_IDCOMMERCIAL ,@OP_MODIFICATIONPHOTOETSIGNATURECLIENT,@LO_CODELOGICIEL,@OP_TRANSFERTCREDITPARMOBILEMONEY,@OP_CLIENTVISA,@OP_VALIDATIONOD";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFIL);
            vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
            vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);


            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTECOFFRE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTESORTIEPROVISOIRE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTEBANQUEMOBILE);


            vppSqlCmd.Parameters.Add(vppParamOP_NOMPRENOM);
            vppSqlCmd.Parameters.Add(vppParamOP_LOGIN);
            vppSqlCmd.Parameters.Add(vppParamOP_MOTPASSE);
            vppSqlCmd.Parameters.Add(vppParamOP_ACTIF);
            vppSqlCmd.Parameters.Add(vppParamOP_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamOP_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamOP_JOURNEEOUVERTE);
            vppSqlCmd.Parameters.Add(vppParamOP_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_GESTIONNAIRE);
            vppSqlCmd.Parameters.Add(vppParamOP_AGENTCREDIT);
            vppSqlCmd.Parameters.Add(vppParamOP_CAISSIER);
            vppSqlCmd.Parameters.Add(vppParamOP_AGENTBUDGET);
            vppSqlCmd.Parameters.Add(vppParamOP_IMPRESSIONAUTOMATIQUE);
            vppSqlCmd.Parameters.Add(vppParamOP_IMPRESSIONAUTOMATIQUETONTINE);

            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONJOURNEE);
            vppSqlCmd.Parameters.Add(vppParamOP_FERMERTUREJOURNEE);
            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONPROFIL);
            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONOPERATEUR);

            vppSqlCmd.Parameters.Add(vppParamOP_CLIENTVISA);
            vppSqlCmd.Parameters.Add(vppParamOP_VALIDATIONOD);

            vppSqlCmd.Parameters.Add(vppParamOP_EXTOURNEOPERATION);


            vppSqlCmd.Parameters.Add(vppParamOP_FERMERTURECAISSE);
            vppSqlCmd.Parameters.Add(vppParamOP_REOUVERTURECAISSE);

            vppSqlCmd.Parameters.Add(vppParamOP_MONTANTMAXIMUMAUTORISEPARRETRAIT);
            vppSqlCmd.Parameters.Add(vppParamOP_MONTANTTOTALENCAISSEAUTORISE);


            vppSqlCmd.Parameters.Add(vppParamOP_MODIFICATIONCOMPTEWEB);
            vppSqlCmd.Parameters.Add(vppParamOP_MODIFICATIONCOMPTESMS);
            vppSqlCmd.Parameters.Add(vppParamOP_MODIFICATIONCOMPTEMOBILE);
            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONCOMPTEMOBILE);
            vppSqlCmd.Parameters.Add(vppParamOP_BLOCAGECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamOP_DEBLOCAGECOMPTE);



            vppSqlCmd.Parameters.Add(vppParamOP_GESTIONNAIRECOMPTEMOBILE);
            vppSqlCmd.Parameters.Add(vppParamOP_AGENTCREDITMOBILE);


            vppSqlCmd.Parameters.Add(vppParamOP_MODIFICATIONTELEPHONECLIENT);
            vppSqlCmd.Parameters.Add(vppParamOP_AGENTDECOLLECTEETDECREDIT);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamCM_IDCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamOP_MODIFICATIONPHOTOETSIGNATURECLIENT);
            vppSqlCmd.Parameters.Add(vppParamLO_CODELOGICIEL);
            vppSqlCmd.Parameters.Add(vppParamOP_TRANSFERTCREDITPARMOBILEMONEY);

            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }

        public void pvgUpdate(clsDonnee clsDonnee, clsOperateur clsOperateur, params string[] vppCritere)
        {
            //Préparation des paramètres 
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.BigInt);
            vppParamOP_CODEOPERATEUR.Value = clsOperateur.OP_CODEOPERATEUR;

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.Int);
            vppParamAG_CODEAGENCE.Value = clsOperateur.AG_CODEAGENCE;

            SqlParameter vppParamPO_CODEPROFIL = new SqlParameter("@PO_CODEPROFIL", SqlDbType.VarChar, 2);
            vppParamPO_CODEPROFIL.Value = clsOperateur.PO_CODEPROFIL;


            SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
            vppParamSR_CODESERVICE.Value = clsOperateur.SR_CODESERVICE;


            SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 25);
            vppParamPV_CODEPOINTVENTE.Value = clsOperateur.PV_CODEPOINTVENTE;
            if (clsOperateur.PV_CODEPOINTVENTE == "") vppParamPV_CODEPOINTVENTE.Value = DBNull.Value;


            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            clsOperateur.PL_CODENUMCOMPTE = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTE).PL_CODENUMCOMPTE;
            vppParamPL_CODENUMCOMPTE.Value = clsOperateur.PL_CODENUMCOMPTE;
            if (clsOperateur.PL_CODENUMCOMPTE == "") vppParamPL_CODENUMCOMPTE.Value = DBNull.Value;

            SqlParameter vppParamPL_CODENUMCOMPTECOFFRE = new SqlParameter("@PL_CODENUMCOMPTECOFFRE", SqlDbType.VarChar, 25);
            clsOperateur.PL_CODENUMCOMPTECOFFRE = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTECOFFRE).PL_CODENUMCOMPTE;
            vppParamPL_CODENUMCOMPTECOFFRE.Value = clsOperateur.PL_CODENUMCOMPTECOFFRE;
            if (clsOperateur.PL_CODENUMCOMPTECOFFRE == "") vppParamPL_CODENUMCOMPTECOFFRE.Value = DBNull.Value;

            SqlParameter vppParamPL_CODENUMCOMPTESORTIEPROVISOIRE = new SqlParameter("@PL_CODENUMCOMPTESORTIEPROVISOIRE", SqlDbType.VarChar, 25);
            clsOperateur.PL_CODENUMCOMPTESORTIEPROVISOIRE = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTESORTIEPROVISOIRE).PL_CODENUMCOMPTE;
            vppParamPL_CODENUMCOMPTESORTIEPROVISOIRE.Value = clsOperateur.PL_CODENUMCOMPTESORTIEPROVISOIRE;
            if (clsOperateur.PL_CODENUMCOMPTESORTIEPROVISOIRE == "") vppParamPL_CODENUMCOMPTESORTIEPROVISOIRE.Value = DBNull.Value;

            SqlParameter vppParamPL_CODENUMCOMPTEBANQUEMOBILE = new SqlParameter("@PL_CODENUMCOMPTEBANQUEMOBILE", SqlDbType.VarChar, 25);
            clsOperateur.PL_CODENUMCOMPTEBANQUEMOBILE = clsPlancomptableWSDAL.pvgTableLabel(clsDonnee, clsOperateur.SO_CODESOCIETE, clsOperateur.PL_NUMCOMPTECOMPTEBANQUEMOBILE).PL_CODENUMCOMPTE;
            vppParamPL_CODENUMCOMPTEBANQUEMOBILE.Value = clsOperateur.PL_CODENUMCOMPTEBANQUEMOBILE;
            if (clsOperateur.PL_CODENUMCOMPTEBANQUEMOBILE == "") vppParamPL_CODENUMCOMPTEBANQUEMOBILE.Value = DBNull.Value;


            SqlParameter vppParamOP_NOMPRENOM = new SqlParameter("@OP_NOMPRENOM", SqlDbType.VarChar, 1000);
            vppParamOP_NOMPRENOM.Value = clsOperateur.OP_NOMPRENOM;

            SqlParameter vppParamOP_LOGIN = new SqlParameter("@OP_LOGIN", SqlDbType.VarChar, 1000);
            vppParamOP_LOGIN.Value = clsOperateur.OP_LOGIN;

            SqlParameter vppParamOP_MOTPASSE = new SqlParameter("@OP_MOTPASSE", SqlDbType.VarChar, 1000);
            vppParamOP_MOTPASSE.Value = clsOperateur.OP_MOTPASSE;

            SqlParameter vppParamOP_ACTIF = new SqlParameter("@OP_ACTIF", SqlDbType.VarChar, 1);
            vppParamOP_ACTIF.Value = clsOperateur.OP_ACTIF;

            SqlParameter vppParamOP_TELEPHONE = new SqlParameter("@OP_TELEPHONE", SqlDbType.VarChar, 1000);
            vppParamOP_TELEPHONE.Value = clsOperateur.OP_TELEPHONE;

            SqlParameter vppParamOP_EMAIL = new SqlParameter("@OP_EMAIL", SqlDbType.VarChar, 1000);
            vppParamOP_EMAIL.Value = clsOperateur.OP_EMAIL;

            SqlParameter vppParamOP_JOURNEEOUVERTE = new SqlParameter("@OP_JOURNEEOUVERTE", SqlDbType.VarChar, 1);
            vppParamOP_JOURNEEOUVERTE.Value = clsOperateur.OP_JOURNEEOUVERTE;

            SqlParameter vppParamOP_GESTIONNAIRE = new SqlParameter("@OP_GESTIONNAIRE", SqlDbType.VarChar, 1);
            vppParamOP_GESTIONNAIRE.Value = clsOperateur.OP_GESTIONNAIRE;

            SqlParameter vppParamOP_AGENTCREDIT = new SqlParameter("@OP_AGENTCREDIT", SqlDbType.VarChar, 1);
            vppParamOP_AGENTCREDIT.Value = clsOperateur.OP_AGENTCREDIT;

            SqlParameter vppParamOP_CAISSIER = new SqlParameter("@OP_CAISSIER", SqlDbType.VarChar, 1);
            vppParamOP_CAISSIER.Value = clsOperateur.OP_CAISSIER;

            SqlParameter vppParamOP_AGENTBUDGET = new SqlParameter("@OP_AGENTBUDGET", SqlDbType.VarChar, 1);
            vppParamOP_AGENTBUDGET.Value = clsOperateur.OP_AGENTBUDGET;

            SqlParameter vppParamOP_IMPRESSIONAUTOMATIQUE = new SqlParameter("@OP_IMPRESSIONAUTOMATIQUE", SqlDbType.VarChar, 1);
            vppParamOP_IMPRESSIONAUTOMATIQUE.Value = clsOperateur.OP_IMPRESSIONAUTOMATIQUE;


            SqlParameter vppParamOP_IMPRESSIONAUTOMATIQUETONTINE = new SqlParameter("@OP_IMPRESSIONAUTOMATIQUETONTINE", SqlDbType.VarChar, 1);
            vppParamOP_IMPRESSIONAUTOMATIQUETONTINE.Value = clsOperateur.OP_IMPRESSIONAUTOMATIQUETONTINE;

            SqlParameter vppParamOP_CREATIONJOURNEE = new SqlParameter("@OP_CREATIONJOURNEE", SqlDbType.VarChar, 1);
            vppParamOP_CREATIONJOURNEE.Value = clsOperateur.OP_CREATIONJOURNEE;

            SqlParameter vppParamOP_FERMERTUREJOURNEE = new SqlParameter("@OP_FERMERTUREJOURNEE", SqlDbType.VarChar, 1);
            vppParamOP_FERMERTUREJOURNEE.Value = clsOperateur.OP_FERMERTUREJOURNEE;

            SqlParameter vppParamOP_CREATIONPROFIL = new SqlParameter("@OP_CREATIONPROFIL", SqlDbType.VarChar, 1);
            vppParamOP_CREATIONPROFIL.Value = clsOperateur.OP_CREATIONPROFIL;

            SqlParameter vppParamOP_CREATIONOPERATEUR = new SqlParameter("@OP_CREATIONOPERATEUR", SqlDbType.VarChar, 1);
            vppParamOP_CREATIONOPERATEUR.Value = clsOperateur.OP_CREATIONOPERATEUR;


            SqlParameter vppParamOP_CLIENTVISA = new SqlParameter("@OP_CLIENTVISA", SqlDbType.VarChar, 1);
            vppParamOP_CLIENTVISA.Value = clsOperateur.OP_CLIENTVISA;
            SqlParameter vppParamOP_VALIDATIONOD = new SqlParameter("@OP_VALIDATIONOD", SqlDbType.VarChar, 1);
            vppParamOP_VALIDATIONOD.Value = clsOperateur.OP_VALIDATIONOD;


            SqlParameter vppParamOP_EXTOURNEOPERATION = new SqlParameter("@OP_EXTOURNEOPERATION", SqlDbType.VarChar, 1);
            vppParamOP_EXTOURNEOPERATION.Value = clsOperateur.OP_EXTOURNEOPERATION;


            SqlParameter vppParamOP_FERMERTURECAISSE = new SqlParameter("@OP_FERMERTURECAISSE", SqlDbType.VarChar, 1);
            vppParamOP_FERMERTURECAISSE.Value = clsOperateur.OP_FERMERTURECAISSE;

            SqlParameter vppParamOP_REOUVERTURECAISSE = new SqlParameter("@OP_REOUVERTURECAISSE", SqlDbType.VarChar, 1);
            vppParamOP_REOUVERTURECAISSE.Value = clsOperateur.OP_REOUVERTURECAISSE;



            SqlParameter vppParamOP_MODIFICATIONCOMPTEWEB = new SqlParameter("@OP_MODIFICATIONCOMPTEWEB", SqlDbType.VarChar, 1);
            vppParamOP_MODIFICATIONCOMPTEWEB.Value = clsOperateur.OP_MODIFICATIONCOMPTEWEB;

            SqlParameter vppParamOP_MODIFICATIONCOMPTESMS = new SqlParameter("@OP_MODIFICATIONCOMPTESMS", SqlDbType.VarChar, 1);
            vppParamOP_MODIFICATIONCOMPTESMS.Value = clsOperateur.OP_MODIFICATIONCOMPTESMS;

            SqlParameter vppParamOP_MODIFICATIONCOMPTEMOBILE = new SqlParameter("@OP_MODIFICATIONCOMPTEMOBILE", SqlDbType.VarChar, 1);
            vppParamOP_MODIFICATIONCOMPTEMOBILE.Value = clsOperateur.OP_MODIFICATIONCOMPTEMOBILE;

            SqlParameter vppParamOP_CREATIONCOMPTEMOBILE = new SqlParameter("@OP_CREATIONCOMPTEMOBILE", SqlDbType.VarChar, 1);
            vppParamOP_CREATIONCOMPTEMOBILE.Value = clsOperateur.OP_CREATIONCOMPTEMOBILE;

            SqlParameter vppParamOP_BLOCAGECOMPTE = new SqlParameter("@OP_BLOCAGECOMPTE", SqlDbType.VarChar, 1);
            vppParamOP_BLOCAGECOMPTE.Value = clsOperateur.OP_BLOCAGECOMPTE;

            SqlParameter vppParamOP_DEBLOCAGECOMPTE = new SqlParameter("@OP_DEBLOCAGECOMPTE", SqlDbType.VarChar, 1);
            vppParamOP_DEBLOCAGECOMPTE.Value = clsOperateur.OP_DEBLOCAGECOMPTE;


            SqlParameter vppParamOP_MODIFICATIONTELEPHONECLIENT = new SqlParameter("@OP_MODIFICATIONTELEPHONECLIENT", SqlDbType.VarChar, 1);
            vppParamOP_MODIFICATIONTELEPHONECLIENT.Value = clsOperateur.OP_MODIFICATIONTELEPHONECLIENT;


            SqlParameter vppParamOP_GESTIONNAIRECOMPTEMOBILE = new SqlParameter("@OP_GESTIONNAIRECOMPTEMOBILE", SqlDbType.VarChar, 1);
            vppParamOP_GESTIONNAIRECOMPTEMOBILE.Value = clsOperateur.OP_GESTIONNAIRECOMPTEMOBILE;

            SqlParameter vppParamOP_AGENTCREDITMOBILE = new SqlParameter("@OP_AGENTCREDITMOBILE", SqlDbType.VarChar, 1);
            vppParamOP_AGENTCREDITMOBILE.Value = clsOperateur.OP_AGENTCREDITMOBILE;

            SqlParameter vppParamOP_AGENTDECOLLECTEETDECREDIT = new SqlParameter("@OP_AGENTDECOLLECTEETDECREDIT", SqlDbType.VarChar, 1);
            vppParamOP_AGENTDECOLLECTEETDECREDIT.Value = clsOperateur.OP_AGENTDECOLLECTEETDECREDIT;

            SqlParameter vppParamOP_MONTANTMAXIMUMAUTORISEPARRETRAIT = new SqlParameter("@OP_MONTANTMAXIMUMAUTORISEPARRETRAIT", SqlDbType.Money);
            vppParamOP_MONTANTMAXIMUMAUTORISEPARRETRAIT.Value = clsOperateur.OP_MONTANTMAXIMUMAUTORISEPARRETRAIT;

            SqlParameter vppParamOP_MONTANTTOTALENCAISSEAUTORISE = new SqlParameter("@OP_MONTANTTOTALENCAISSEAUTORISE", SqlDbType.Money);
            vppParamOP_MONTANTTOTALENCAISSEAUTORISE.Value = clsOperateur.OP_MONTANTTOTALENCAISSEAUTORISE;

            SqlParameter vppParamOP_DATESAISIE = new SqlParameter("@OP_DATESAISIE", SqlDbType.DateTime);
            vppParamOP_DATESAISIE.Value = clsOperateur.OP_DATESAISIE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;


            SqlParameter vppParamCM_IDCOMMERCIAL = new SqlParameter("@CM_IDCOMMERCIAL", SqlDbType.VarChar, 25);
            vppParamCM_IDCOMMERCIAL.Value = clsOperateur.CM_IDCOMMERCIAL;
            if (clsOperateur.CM_IDCOMMERCIAL == "") vppParamCM_IDCOMMERCIAL.Value = DBNull.Value;


            SqlParameter vppParamOP_MODIFICATIONPHOTOETSIGNATURECLIENT = new SqlParameter("@OP_MODIFICATIONPHOTOETSIGNATURECLIENT", SqlDbType.VarChar, 1);
            vppParamOP_MODIFICATIONPHOTOETSIGNATURECLIENT.Value = clsOperateur.OP_MODIFICATIONPHOTOETSIGNATURECLIENT;

            SqlParameter vppParamLO_CODELOGICIEL = new SqlParameter("@LO_CODELOGICIEL", SqlDbType.VarChar, 25);
            vppParamLO_CODELOGICIEL.Value = clsOperateur.LO_CODELOGICIEL;

            SqlParameter vppParamOP_TRANSFERTCREDITPARMOBILEMONEY = new SqlParameter("@OP_TRANSFERTCREDITPARMOBILEMONEY", SqlDbType.VarChar, 1);
            vppParamOP_TRANSFERTCREDITPARMOBILEMONEY.Value = clsOperateur.OP_TRANSFERTCREDITPARMOBILEMONEY;

            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  @OP_CODEOPERATEUR, @AG_CODEAGENCE, @PO_CODEPROFIL,@SR_CODESERVICE,@PV_CODEPOINTVENTE, @PL_CODENUMCOMPTE,@PL_CODENUMCOMPTECOFFRE, @PL_CODENUMCOMPTESORTIEPROVISOIRE,@PL_CODENUMCOMPTEBANQUEMOBILE,  @OP_NOMPRENOM, @OP_LOGIN, @OP_MOTPASSE, @OP_ACTIF, @OP_TELEPHONE, @OP_EMAIL, @OP_JOURNEEOUVERTE, @OP_DATESAISIE, @OP_GESTIONNAIRE,@OP_AGENTCREDIT,@OP_CAISSIER,@OP_AGENTBUDGET,@OP_IMPRESSIONAUTOMATIQUE,@OP_IMPRESSIONAUTOMATIQUETONTINE,@OP_CREATIONJOURNEE,@OP_FERMERTUREJOURNEE,@OP_CREATIONPROFIL,@OP_CREATIONOPERATEUR,@OP_EXTOURNEOPERATION,@OP_FERMERTURECAISSE,@OP_REOUVERTURECAISSE,@OP_MONTANTMAXIMUMAUTORISEPARRETRAIT,@OP_MONTANTTOTALENCAISSEAUTORISE,@OP_MODIFICATIONCOMPTEWEB,@OP_MODIFICATIONCOMPTESMS,@OP_MODIFICATIONCOMPTEMOBILE,@OP_CREATIONCOMPTEMOBILE,@OP_BLOCAGECOMPTE,@OP_DEBLOCAGECOMPTE,@OP_GESTIONNAIRECOMPTEMOBILE,@OP_AGENTCREDITMOBILE,@OP_MODIFICATIONTELEPHONECLIENT,@OP_AGENTDECOLLECTEETDECREDIT,@CODECRYPTAGE, 1,@CM_IDCOMMERCIAL,@OP_MODIFICATIONPHOTOETSIGNATURECLIENT,@LO_CODELOGICIEL,@OP_TRANSFERTCREDITPARMOBILEMONEY,@OP_CLIENTVISA,@OP_VALIDATIONOD ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamPO_CODEPROFIL);
            vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
            vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);


            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTECOFFRE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTESORTIEPROVISOIRE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTEBANQUEMOBILE);

            vppSqlCmd.Parameters.Add(vppParamOP_NOMPRENOM);
            vppSqlCmd.Parameters.Add(vppParamOP_LOGIN);
            vppSqlCmd.Parameters.Add(vppParamOP_MOTPASSE);
            vppSqlCmd.Parameters.Add(vppParamOP_ACTIF);
            vppSqlCmd.Parameters.Add(vppParamOP_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamOP_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamOP_JOURNEEOUVERTE);
            vppSqlCmd.Parameters.Add(vppParamOP_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamOP_GESTIONNAIRE);
            vppSqlCmd.Parameters.Add(vppParamOP_AGENTCREDIT);
            vppSqlCmd.Parameters.Add(vppParamOP_CAISSIER);
            vppSqlCmd.Parameters.Add(vppParamOP_AGENTBUDGET);
            vppSqlCmd.Parameters.Add(vppParamOP_IMPRESSIONAUTOMATIQUE);
            vppSqlCmd.Parameters.Add(vppParamOP_IMPRESSIONAUTOMATIQUETONTINE);

            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONJOURNEE);
            vppSqlCmd.Parameters.Add(vppParamOP_FERMERTUREJOURNEE);
            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONPROFIL);
            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONOPERATEUR);

            vppSqlCmd.Parameters.Add(vppParamOP_CLIENTVISA);
            vppSqlCmd.Parameters.Add(vppParamOP_VALIDATIONOD);

            vppSqlCmd.Parameters.Add(vppParamOP_EXTOURNEOPERATION);


            vppSqlCmd.Parameters.Add(vppParamOP_FERMERTURECAISSE);
            vppSqlCmd.Parameters.Add(vppParamOP_REOUVERTURECAISSE);

            vppSqlCmd.Parameters.Add(vppParamOP_MONTANTMAXIMUMAUTORISEPARRETRAIT);
            vppSqlCmd.Parameters.Add(vppParamOP_MONTANTTOTALENCAISSEAUTORISE);


            vppSqlCmd.Parameters.Add(vppParamOP_MODIFICATIONCOMPTEWEB);
            vppSqlCmd.Parameters.Add(vppParamOP_MODIFICATIONCOMPTESMS);
            vppSqlCmd.Parameters.Add(vppParamOP_MODIFICATIONCOMPTEMOBILE);
            vppSqlCmd.Parameters.Add(vppParamOP_CREATIONCOMPTEMOBILE);
            vppSqlCmd.Parameters.Add(vppParamOP_BLOCAGECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamOP_DEBLOCAGECOMPTE);



            vppSqlCmd.Parameters.Add(vppParamOP_GESTIONNAIRECOMPTEMOBILE);
            vppSqlCmd.Parameters.Add(vppParamOP_AGENTCREDITMOBILE);

            vppSqlCmd.Parameters.Add(vppParamOP_MODIFICATIONTELEPHONECLIENT);
            vppSqlCmd.Parameters.Add(vppParamOP_AGENTDECOLLECTEETDECREDIT);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamCM_IDCOMMERCIAL);
            vppSqlCmd.Parameters.Add(vppParamOP_MODIFICATIONPHOTOETSIGNATURECLIENT);
            vppSqlCmd.Parameters.Add(vppParamLO_CODELOGICIEL);
            vppSqlCmd.Parameters.Add(vppParamOP_TRANSFERTCREDITPARMOBILEMONEY);
            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }

        public void pvgUpdateDesactiverOperateur(clsDonnee clsDonnee, clsOperateur clsOperateur, params string[] vppCritere)
        {
            //Préparation des paramètres 
            SqlParameter vppParamOP_ACTIF = new SqlParameter("@OP_ACTIF", SqlDbType.VarChar, 1);
            vppParamOP_ACTIF.Value = clsOperateur.OP_ACTIF;

            SqlParameter vppParamOP_LOGIN = new SqlParameter("@OP_LOGIN", SqlDbType.VarChar, 1000);
            vppParamOP_LOGIN.Value = clsOperateur.OP_LOGIN;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  '', '' , '' ,'', '' ,'', '' ,'' , '' ,'' , @OP_LOGIN , '' , @OP_ACTIF , '' , '' ,'', '' , '' ,'' ,'' ,'' ,'','','','','' ,'','','','','','','','','','','','','','','','', @CODECRYPTAGE, 3,'' ,'','','', '', '' ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamOP_ACTIF);
            vppSqlCmd.Parameters.Add(vppParamOP_LOGIN);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:OP_CODEOPERATEUR,SE_CODESERVICE)</summary>
        ///<param name="vppCritere">BusinessObject</param>
        ///<param name="vppCritere1">critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvgUpdateOP_MOTPASSE(clsDonnee clsDonnee, clsOperateur clsOperateur, params string[] vppCritere)
        {
            //Préparation des paramètres 

            SqlParameter vppParamOP_LOGIN = new SqlParameter("@OP_LOGIN", SqlDbType.VarChar, 1000);
            vppParamOP_LOGIN.Value = clsOperateur.OP_LOGIN;

            SqlParameter vppParamOP_MOTPASSE = new SqlParameter("@OP_MOTPASSE", SqlDbType.VarChar, 1000);
            vppParamOP_MOTPASSE.Value = clsOperateur.OP_MOTPASSE;

            SqlParameter vppParamOP_TELEPHONE = new SqlParameter("@OP_TELEPHONE", SqlDbType.VarChar, 1000);
            vppParamOP_TELEPHONE.Value = clsOperateur.OP_TELEPHONE;

            //SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            //vppParamOP_CODEOPERATEUR.Value = clsOperateur.OP_CODEOPERATEUR;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  '', '' , '' ,'', '','' , '' , '' ,'' , '' ,@OP_LOGIN , @OP_MOTPASSE , '' , @OP_TELEPHONE , '' , '','' , '' ,'' , '' ,'' ,'','','','','' ,'','','','','','','','','','','','','','','','', @CODECRYPTAGE, 9,'','','','','','' ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamOP_LOGIN);
            vppSqlCmd.Parameters.Add(vppParamOP_MOTPASSE);
            vppSqlCmd.Parameters.Add(vppParamOP_TELEPHONE);
            // vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:OP_CODEOPERATEUR,SE_CODESERVICE)</summary>
        ///<param name="vppCritere">BusinessObject</param>
        ///<param name="vppCritere1">critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvgUpdateOP_MOTPASSEPremiereConnexion(clsDonnee clsDonnee, clsOperateur clsOperateur, params string[] vppCritere)
        {
            //Préparation des paramètres 
            SqlParameter vppParamOP_MOTPASSE = new SqlParameter("@OP_MOTPASSE", SqlDbType.VarChar, 1000);
            vppParamOP_MOTPASSE.Value = clsOperateur.OP_MOTPASSE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsOperateur.OP_CODEOPERATEUR;

            SqlParameter vppParamOP_DATESAISIE = new SqlParameter("@OP_DATESAISIE", SqlDbType.DateTime);
            vppParamOP_DATESAISIE.Value = clsOperateur.OP_DATESAISIE;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  @OP_CODEOPERATEUR, '' , '' ,'', '','' , '' , '' ,'' , '' ,'' , @OP_MOTPASSE , '' , '' , '' , '',@OP_DATESAISIE , '' ,'' , '' ,'' ,'','','','','' ,'','','','','','','','','','','','','','','','', @CODECRYPTAGE, 7,'' ,'','','','','' ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamOP_MOTPASSE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamOP_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:OP_CODEOPERATEUR,SE_CODESERVICE)</summary>
        ///<param name="vppCritere">BusinessObject</param>
        ///<param name="vppCritere1">critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvgUpdateOP_MOTPASSEObligatoire(clsDonnee clsDonnee, clsOperateur clsOperateur, params string[] vppCritere)
        {
            //Préparation des paramètres 
            SqlParameter vppParamOP_MOTPASSE = new SqlParameter("@OP_MOTPASSE", SqlDbType.VarChar, 1000);
            vppParamOP_MOTPASSE.Value = clsOperateur.OP_MOTPASSE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsOperateur.OP_CODEOPERATEUR;

            SqlParameter vppParamOP_DATESAISIE = new SqlParameter("@OP_DATESAISIE", SqlDbType.DateTime);
            vppParamOP_DATESAISIE.Value = clsOperateur.OP_DATESAISIE;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  @OP_CODEOPERATEUR, '' , '' ,'', '','' , '' , '' ,'' , '' ,'' , @OP_MOTPASSE , '' , '' , '' , '',@OP_DATESAISIE , '' ,'' , '' ,'' ,'','','','','' ,'','','','','','','','','','','','','','','','', @CODECRYPTAGE, 8,'','' ,'','','','' ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamOP_MOTPASSE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamOP_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:OP_CODEOPERATEUR,SE_CODESERVICE)</summary>
        ///<param name="vppCritere">BusinessObject</param>
        ///<param name="vppCritere1">critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvgUpdateOP_JOURNEEOUVERTE(clsDonnee clsDonnee, clsOperateur clsOperateur, params string[] vppCritere)
        {
            //Préparation des paramètres 
            SqlParameter vppParamOP_JOURNEEOUVERTE = new SqlParameter("@OP_JOURNEEOUVERTE", SqlDbType.VarChar, 1);
            vppParamOP_JOURNEEOUVERTE.Value = clsOperateur.OP_JOURNEEOUVERTE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsOperateur.OP_CODEOPERATEUR;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  @OP_CODEOPERATEUR,'' , '' ,'','' ,'', '' , '' ,'' , '' , '' , '' , '' ,'' , '' , @OP_JOURNEEOUVERTE , '' ,'', '' , '' ,'' ,'','','','','' ,'','','','','','','','','','','','','','','','', @CODECRYPTAGE, 6,'','','','','','' ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamOP_JOURNEEOUVERTE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }

        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //Préparation des paramètres 
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.BigInt);
            vppParamOP_CODEOPERATEUR.Value = vppCritere[0];

            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  @OP_CODEOPERATEUR, '' ,'' ,'', '','' , '' , '' , '' ,'' , '' ,'' , '' , '' , '' , '' ,'', '' , '','' ,'', '','' ,'','','' ,'','','','','','','','','','','','','','','','','',2 ,'','','','','','' ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }

        public void pvgDelete1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //Préparation des paramètres 
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.Int);
            vppParamAG_CODEAGENCE.Value = vppCritere[0];

            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_OPERATEUR  '', @AG_CODEAGENCE ,'' ,'', '' ,'', '' , '' , '' ,'' , '' , '' , '' , '' , '' , '' , '' ,'', '', '' ,'', '','' ,'','','' ,'','','','','','','','','','','','','','','','','',4,'','','','','','' ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTETontineMobile, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsTontineweb </returns>
        ///<author>Home Technology</author>
        public void pvgTransfertPortefeuilleClient(clsDonnee clsDonnee, clsOperateur clsOperateur, params string[] vppCritere)
        {
            //Préparation des paramètres 
            SqlParameter vppParamLG_CODELANGUE = new SqlParameter("@LG_CODELANGUE", SqlDbType.VarChar, 25);
            vppParamLG_CODELANGUE.Value = clsOperateur.LG_CODELANGUE;

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsOperateur.AG_CODEAGENCE;

            SqlParameter vppParamOP_CODEOPERATEURINITIAL = new SqlParameter("@OP_CODEOPERATEURINITIAL", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEURINITIAL.Value = clsOperateur.OP_CODEOPERATEURINITIAL;

            SqlParameter vppParamOP_CODEOPERATEURFINAL = new SqlParameter("@OP_CODEOPERATEURFINAL", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEURFINAL.Value = clsOperateur.OP_CODEOPERATEURFINAL;

            SqlParameter vppParamCL_IDCLIENT = new SqlParameter("@CL_IDCLIENT", SqlDbType.VarChar, 25);
            vppParamCL_IDCLIENT.Value = clsOperateur.CL_IDCLIENT;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande 
            this.vapRequete = "EXEC [dbo].[PS_TRANSFERTPORTEFEUILLECLIENT] @LG_CODELANGUE ,@AG_CODEAGENCE, @OP_CODEOPERATEURINITIAL, @OP_CODEOPERATEURFINAL, @CL_IDCLIENT,@CODECRYPTAGE";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamLG_CODELANGUE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURINITIAL);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURFINAL);
            vppSqlCmd.Parameters.Add(vppParamCL_IDCLIENT);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);


            //vapNomParametre = new string[] { "@LG_CODELANGUE", "@AG_CODEAGENCE", "@OP_CODEOPERATEURINITIAL", "@OP_CODEOPERATEURFINAL", "@CL_IDCLIENT","@CODECRYPTAGE" };
            //vapValeurParametre = new object[] { clsOperateur.LG_CODELANGUE, clsOperateur.AG_CODEAGENCE, clsOperateur.OP_CODEOPERATEURINITIAL, clsOperateur.OP_CODEOPERATEURFINAL, clsOperateur.CL_IDCLIENT, clsDonnee.vogCleCryptage};

            //this.vapRequete = "EXEC [dbo].[PS_TRANSFERTPORTEFEUILLECLIENT] @LG_CODELANGUE ,@AG_CODEAGENCE, @OP_CODEOPERATEURINITIAL, @OP_CODEOPERATEURFINAL, @CL_IDCLIENT,@CODECRYPTAGE";// +this.vapCritere;
            //this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            //return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public void pvgOperateurUpdateStatutConnection(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@OP_CONNECTE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
            this.vapRequete = "EXEC PS_OPERATEURUPDATESTATUTCONNECTE @AG_CODEAGENCE,@OP_CODEOPERATEUR,@OP_CONNECTE, @CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        public void pvgReinitialisationCompteOperateur(clsDonnee clsDonnee, clsOperateur clsOperateur)
        {
            //Préparation des paramètres 
            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 50);
            vppParamOP_CODEOPERATEUR.Value = clsOperateur.OP_CODEOPERATEUR;

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.Int);
            vppParamAG_CODEAGENCE.Value = clsOperateur.AG_CODEAGENCE;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;



            //Préparation de la commande 
            this.vapRequete = "EXECUTE PC_REINITIALISATIONCOMPTEOPERATEUR  @OP_CODEOPERATEUR, @AG_CODEAGENCE,@CODECRYPTAGE, 0";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande 
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);


            //Ouverture de la connection et exécution de la commande 
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsOperateur </returns>
        ///<author>Home Technology</author>
        public List<clsOperateur> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  ,OP_GESTIONNAIRE, PO_CODEPROFIL  ,SR_CODESERVICE, PL_CODENUMCOMPTE  , OP_NOMPRENOM  , OP_LOGIN  , OP_MOTPASSE  , OP_ACTIF  , OP_TELEPHONE  , OP_EMAIL  , OP_JOURNEEOUVERTE  ,OP_AGENTCREDIT,OP_CAISSIER, OP_DATESAISIE  FROM dbo.FT_OPERATEUR(@CODECRYPTAGE)   " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsOperateur> clsOperateurs = new List<clsOperateur>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsOperateur clsOperateur = new clsOperateur();
                    clsOperateur.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                    clsOperateur.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsOperateur.PO_CODEPROFIL = clsDonnee.vogDataReader["PO_CODEPROFIL"].ToString();
                    clsOperateur.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
                    clsOperateur.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsOperateur.OP_NOMPRENOM = clsDonnee.vogDataReader["OP_NOMPRENOM"].ToString();
                    clsOperateur.OP_LOGIN = clsDonnee.vogDataReader["OP_LOGIN"].ToString();
                    clsOperateur.OP_MOTPASSE = clsDonnee.vogDataReader["OP_MOTPASSE"].ToString();
                    clsOperateur.OP_ACTIF = clsDonnee.vogDataReader["OP_ACTIF"].ToString();
                    clsOperateur.OP_TELEPHONE = clsDonnee.vogDataReader["OP_TELEPHONE"].ToString();
                    clsOperateur.OP_EMAIL = clsDonnee.vogDataReader["OP_EMAIL"].ToString();
                    clsOperateur.OP_JOURNEEOUVERTE = clsDonnee.vogDataReader["OP_JOURNEEOUVERTE"].ToString();
                    clsOperateur.OP_GESTIONNAIRE = clsDonnee.vogDataReader["OP_GESTIONNAIRE"].ToString();
                    clsOperateur.OP_AGENTCREDIT = clsDonnee.vogDataReader["OP_AGENTCREDIT"].ToString();
                    clsOperateur.OP_CAISSIER = clsDonnee.vogDataReader["OP_CAISSIER"].ToString();
                    clsOperateur.OP_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["OP_DATESAISIE"].ToString());
                    clsOperateurs.Add(clsOperateur);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsOperateurs;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsOperateur </returns>
        ///<author>Home Technology</author>
        public List<clsOperateur> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsOperateur> clsOperateurs = new List<clsOperateur>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , PO_CODEPROFIL  ,SR_CODESERVICE, PL_CODENUMCOMPTE  , OP_NOMPRENOM  , OP_LOGIN  , OP_MOTPASSE  , OP_ACTIF  , OP_TELEPHONE  , OP_EMAIL  , OP_JOURNEEOUVERTE  ,OP_CAISSIER, OP_DATESAISIE  FROM dbo.FT_OPERATEUR(@CODECRYPTAGE)   " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsOperateur clsOperateur = new clsOperateur();
                    clsOperateur.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
                    clsOperateur.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsOperateur.PO_CODEPROFIL = Dataset.Tables["TABLE"].Rows[Idx]["PO_CODEPROFIL"].ToString();
                    clsOperateur.SR_CODESERVICE = Dataset.Tables["TABLE"].Rows[Idx]["SR_CODESERVICE"].ToString();
                    clsOperateur.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
                    clsOperateur.OP_NOMPRENOM = Dataset.Tables["TABLE"].Rows[Idx]["OP_NOMPRENOM"].ToString();
                    clsOperateur.OP_LOGIN = Dataset.Tables["TABLE"].Rows[Idx]["OP_LOGIN"].ToString();
                    clsOperateur.OP_MOTPASSE = Dataset.Tables["TABLE"].Rows[Idx]["OP_MOTPASSE"].ToString();
                    clsOperateur.OP_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["OP_ACTIF"].ToString();
                    clsOperateur.OP_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["OP_TELEPHONE"].ToString();
                    clsOperateur.OP_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["OP_EMAIL"].ToString();
                    clsOperateur.OP_JOURNEEOUVERTE = Dataset.Tables["TABLE"].Rows[Idx]["OP_JOURNEEOUVERTE"].ToString();
                    clsOperateur.OP_AGENTCREDIT = Dataset.Tables["TABLE"].Rows[Idx]["OP_AGENTCREDIT"].ToString();
                    clsOperateur.OP_GESTIONNAIRE = Dataset.Tables["TABLE"].Rows[Idx]["OP_GESTIONNAIRE"].ToString();
                    clsOperateur.OP_CAISSIER = Dataset.Tables["TABLE"].Rows[Idx]["OP_CAISSIER"].ToString();
                    clsOperateur.OP_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["OP_DATESAISIE"].ToString());
                    clsOperateurs.Add(clsOperateur);
                }
                Dataset.Dispose();
            }
            return clsOperateurs;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_OPERATEUR(@CODECRYPTAGE)   " + this.vapCritere + "  AND OP_AFFICHER='O' AND NOT (OP_LOGIN like '%ADMIN%')";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetSelonPointService(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereSelonPointService(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_OPERATEUR(@CODECRYPTAGE)   " + this.vapCritere + "  AND OP_AFFICHER='O' AND NOT (OP_LOGIN like '%ADMIN%')";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgListeFingerprintWhiteLister(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereSelonWl(clsDonnee, vppCritere);

            this.vapRequete = " SELECT CASE WHEN EXISTS(SELECT 1 FROM WHITELISTETENTATIVEDECONNEXION " + this.vapCritere + ") THEN 1 ELSE 0 END AS resultat";

            //this.vapRequete = "SELECT * FROM dbo.WHITELISTETENTATIVEDECONNEXION " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgListeFingerprintWhiteLister2(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereSelonWl(clsDonnee, vppCritere);

            //this.vapRequete = " SELECT CASE WHEN EXISTS(SELECT 1 FROM WHITELISTETENTATIVEDECONNEXION " + this.vapCritere + ") THEN 1 ELSE 0 END AS resultat";

            this.vapRequete = "SELECT * FROM dbo.WHITELISTETENTATIVEDECONNEXION ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgVerificationConnexionOperateur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpVerificationConnexionOperateur(clsDonnee, vppCritere);
            this.vapRequete = "SELECT OP_CONNECTE FROM dbo.OPERATEUR " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetLOGIN(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_OPERATEUR(@CODECRYPTAGE)   " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public void pvgWhiteListeNavigateur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //Préparation des paramètres

            SqlParameter vppParamFINGERPRINTNAV = new SqlParameter("@FINGERPRINTNAV", SqlDbType.VarChar, 100);
            vppParamFINGERPRINTNAV.Value = vppCritere[0];

            SqlParameter vppParamJT_DATEJOURNEETRAVAIL = new SqlParameter("@JT_DATEJOURNEETRAVAIL", SqlDbType.DateTime);
            vppParamJT_DATEJOURNEETRAVAIL.Value = vppCritere[1];

            SqlParameter vppParamHEUREACTION = new SqlParameter("@HEUREACTION", SqlDbType.DateTime);
            vppParamHEUREACTION.Value = vppCritere[2];


            //Préparation de la commande
            this.vapRequete = "INSERT INTO WHITELISTETENTATIVEDECONNEXION " +
            " (WL_IDNAVIGATEUR,JT_DATEJOURNEETRAVAIL,HEUREACTION)" +
            " VALUES(@FINGERPRINTNAV,@JT_DATEJOURNEETRAVAIL,@HEUREACTION)";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamFINGERPRINTNAV);
            vppSqlCmd.Parameters.Add(vppParamJT_DATEJOURNEETRAVAIL);
            vppSqlCmd.Parameters.Add(vppParamHEUREACTION);

            //Ouverture de la connection et exécution de la commande
            vppSqlCmd.ExecuteNonQuery();
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public void pvgDeleteWhiteListeNavigateur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereSelonWl(clsDonnee, vppCritere);
            this.vapRequete = "DELETE FROM WHITELISTETENTATIVEDECONNEXION " + this.vapCritere;
            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT OP_CODEOPERATEUR,OP_NOMPRENOM FROM dbo.FT_OPERATEUR(@CODECRYPTAGE) " + this.vapCritere + "  AND OP_ACTIF='O' ORDER BY OP_NOMPRENOM";
            //this.vapRequete = "SELECT OP_CODEOPERATEUR,OP_NOMPRENOM FROM dbo.FT_OPERATEUR(@CODECRYPTAGE) " + this.vapCritere + "  AND OP_ACTIF='O' AND NOT (OP_LOGIN like '%ADMIN%' OR OP_LOGIN like'%BILAN%') ORDER BY OP_NOMPRENOM";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboOP_GESTIONNAIRE(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  OP_GESTIONNAIRE=@OP_GESTIONNAIRE ";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_GESTIONNAIRE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], 'O' };
            //
            this.vapRequete = "SELECT OP_CODEOPERATEUR AS OP_GESTIONNAIRE,OP_NOMPRENOM FROM dbo.FT_OPERATEUR(@CODECRYPTAGE) " + this.vapCritere + "  AND OP_ACTIF='O' AND NOT (OP_LOGIN like '%ADMIN%' OR OP_LOGIN like'%BILAN%') ORDER BY OP_NOMPRENOM";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboOP_AGENTCOLLECTEETCREDIT(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  OP_AGENTDECOLLECTEETDECREDIT=@OP_AGENTDECOLLECTEETDECREDIT ";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_AGENTDECOLLECTEETDECREDIT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], 'O' };
            //
            this.vapRequete = "SELECT OP_CODEOPERATEUR AS OP_AGENTDECOLLECTEETDECREDIT , OP_NOMPRENOM FROM dbo.FT_OPERATEUR(@CODECRYPTAGE) " + this.vapCritere + "  AND OP_ACTIF='O' AND NOT (OP_LOGIN like '%ADMIN%' OR OP_LOGIN like'%BILAN%') ORDER BY OP_NOMPRENOM";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboOP_AGENTCREDIT(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_AGENTCREDIT=@OP_AGENTCREDIT ";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_AGENTCREDIT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], 'O' };
            //
            this.vapRequete = "SELECT OP_CODEOPERATEUR AS OP_AGENTCREDIT,OP_NOMPRENOM FROM dbo.FT_OPERATEUR(@CODECRYPTAGE) " + this.vapCritere + "  AND OP_ACTIF='O' AND NOT (OP_LOGIN like '%ADMIN%' OR OP_LOGIN like'%BILAN%') ORDER BY OP_NOMPRENOM";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboOP_CAISSIER(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CAISSIER=@OP_CAISSIER AND OP_JOURNEEOUVERTE=@OP_JOURNEEOUVERTE ";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CAISSIER", "@OP_JOURNEEOUVERTE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], 'O', vppCritere[1], };
            //
            this.vapRequete = "SELECT OP_CODEOPERATEUR,OP_NOMPRENOM,PL_CODENUMCOMPTE,OP_LOGIN,OP_MOTPASSE,PO_CODEPROFIL,OP_TELEPHONE,OP_EMAIL,OP_ACTIF,OP_JOURNEEOUVERTE,OP_GESTIONNAIRE,OP_AGENTCREDIT,OP_CAISSIER FROM dbo.FT_OPERATEUR(@CODECRYPTAGE) " + this.vapCritere + "  AND OP_ACTIF='O' AND NOT (OP_LOGIN like '%ADMIN%' OR OP_LOGIN like'%BILAN%') ORDER BY OP_NOMPRENOM";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboOP_CAISSIERPassationFond(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CAISSIER=@OP_CAISSIER AND OP_JOURNEEOUVERTE=@OP_JOURNEEOUVERTE  AND OP_CODEOPERATEUR<>@OP_CODEOPERATEUR";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CAISSIER", "@OP_JOURNEEOUVERTE", "@OP_CODEOPERATEUR" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], 'O', vppCritere[1], vppCritere[2] };
            //
            this.vapRequete = "SELECT OP_CODEOPERATEUR,OP_NOMPRENOM,PL_CODENUMCOMPTE,OP_LOGIN FROM dbo.FT_OPERATEUR(@CODECRYPTAGE) " + this.vapCritere +
             "  AND OP_ACTIF='O' AND NOT (OP_LOGIN like '%ADMIN%' OR OP_LOGIN like'%BILAN%') ORDER BY OP_NOMPRENOM";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }




        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboStat(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CAISSIER=@OP_CAISSIER";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CAISSIER" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], 'O' };
            //
            this.vapRequete = "SELECT OP_CODEOPERATEUR,OP_NOMPRENOM,PL_CODENUMCOMPTE,OP_LOGIN FROM dbo.FT_OPERATEUR(@CODECRYPTAGE) " + this.vapCritere +
             "  AND OP_ACTIF='O' AND NOT (OP_LOGIN like '%ADMIN%' OR OP_LOGIN like'%BILAN%') ORDER BY OP_NOMPRENOM";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEWEB, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public DataSet pvgLogin(clsDonnee clsDonnee, string LG_CODELANGUE, string SL_LOGIN, string SL_MOTPASSE, string TYPEOPERATEUR)
        {
            DataSet Dataset = new DataSet();
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@LG_CODELANGUE", "@SL_LOGIN", "@SL_MOTPASSE", "@TYPEOPERATEUR", "@TYPEOPERATION" };
            //vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, LG_CODELANGUE, SL_LOGIN, SL_MOTPASSE, TYPEOPERATEUR, "02" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, LG_CODELANGUE, SL_LOGIN, SL_MOTPASSE, TYPEOPERATEUR, "03" };
            this.vapRequete = "EXEC PS_WEBUSERLOGIN @LG_CODELANGUE,@SL_LOGIN,@SL_MOTPASSE,@TYPEOPERATEUR,@TYPEOPERATION ,@CODECRYPTAGE,''";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandTimeout = 0;
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT OP_CODEOPERATEUR,OP_NOMPRENOM FROM dbo.FT_OPERATEUR(@CODECRYPTAGE)";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetOperateurPointdevente(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT *  FROM dbo.[FC_OPERATEURPOINTVENTEWEB](@AG_CODEAGENCE,@OP_CODEOPERATEUR,@CODECRYPTAGE) ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo2(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT OP_CODEOPERATEUR,OP_NOMPRENOM FROM dbo.FT_OPERATEUR(@CODECRYPTAGE) " + this.vapCritere + "  AND OP_ACTIF='O' ORDER BY OP_NOMPRENOM";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboDroitCorrectionBilletage(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
            this.vapRequete = "SELECT OP_CODEOPERATEUR,OP_NOMPRENOM,PL_CODENUMCOMPTE FROM dbo.FT_OPERATEUR(@CODECRYPTAGE)  WHERE OP_CODEOPERATEUR IN(SELECT OP_CODEOPERATEUR1 FROM OPERATEURDROITCORRETIONBILLETAGEWEB WHERE OP_CODEOPERATEUR=@OP_CODEOPERATEUR)   AND OP_ACTIF='O' ORDER BY OP_NOMPRENOM";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboDroitBrouillardUtilisateur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
            this.vapRequete = "SELECT OP_CODEOPERATEUR,OP_NOMPRENOM,PL_CODENUMCOMPTE FROM dbo.FT_OPERATEUR(@CODECRYPTAGE)  WHERE OP_CODEOPERATEUR IN(SELECT OP_CODEOPERATEUR1 FROM OPERATEURDROITBROUILLARDCAISSE WHERE OP_CODEOPERATEUR=@OP_CODEOPERATEUR)   AND OP_ACTIF='O' ORDER BY OP_NOMPRENOM";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : OP_CODEOPERATEUR  ,  ) </summary> 
        ///<param name=clsDonnee>Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboPointdeVente(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PV_CODEPOINTVENTE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0].Replace("''", "'"), vppCritere[1].Replace("''", "'") };
            this.vapRequete = "EXEC PS_MICPOINTVENTEOPERATEURCHARGEMENTCOMBO @AG_CODEAGENCE,@PV_CODEPOINTVENTE, @CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public string pvgGetSoldeCompteOperateur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT  [dbo].[FC_SOLDECOMPTEGRANDLIVREPRECEDENT](@CodeAgence,@CodeCompte,@DateDebut)  ";
            vapNomParametre = new string[] { "@CodeAgence", "@CodeCompte", "@DateDebut" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR,AG_CODEAGENCE,PO_CODEPROFIL,PL_CODENUMCOMPTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE  AG_CODEAGENCE=@AG_CODEAGENCE  AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = " WHERE   AG_CODEAGENCE=@AG_CODEAGENCE AND  OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND PO_CODEPROFIL=@PO_CODEPROFIL ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@PO_CODEPROFIL" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = " WHERE   AG_CODEAGENCE=@AG_CODEAGENCE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR ANDPO_CODEPROFIL=@PO_CODEPROFIL AND  PL_CODENUMCOMPTE=@PL_CODENUMCOMPTE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@PO_CODEPROFIL", "@PL_CODENUMCOMPTE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
            }
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR,AG_CODEAGENCE,PO_CODEPROFIL,PL_CODENUMCOMPTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE  AG_CODEAGENCE=@AG_CODEAGENCE  AND OP_LOGIN=@OP_LOGIN";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_LOGIN" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR,AG_CODEAGENCE,PO_CODEPROFIL,PL_CODENUMCOMPTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpVerificationConnexionOperateur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 2:
                    this.vapCritere = " WHERE  AG_CODEAGENCE=@AG_CODEAGENCE  AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR,AG_CODEAGENCE,PO_CODEPROFIL,PL_CODENUMCOMPTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereSelonPointService(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE  AG_CODEAGENCE=@AG_CODEAGENCE  AND PV_CODEPOINTVENTE=@PV_CODEPOINTVENTE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PV_CODEPOINTVENTE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
            }
        }



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR,AG_CODEAGENCE,PO_CODEPROFIL,PL_CODENUMCOMPTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereSelonWl(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = " WHERE WL_IDNAVIGATEUR=@WL_IDNAVIGATEUR ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@WL_IDNAVIGATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;

            }
        }





    }
}
