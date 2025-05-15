using System;
using System.Collections.Generic;
//using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.Tools.Classes;
using MgRequeteClients.BOJ.BusinessObjects;
using Microsoft.Data.SqlClient;

namespace MgRequeteClients.DAL.Classes
{
    public class clsEditionWSDAL
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete </summary>
		///<param name="clsDonnee"> Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgInsertIntoDatasetAgence(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT * FROM VUE_ETATAGENCEWEB ";
            ////AG_CODEAGENCE,AG_RAISONSOCIAL,AGENCE.AG_AGENCECODE,SO_CODESOCIETE,VL_CODEVILLE,AG_BOITEPOSTAL,AG_TELEPHONE,AGENCE.AG_FAX,AG_EMAIL,AG_ACTIF,Expr1,VL_LIBELLE,VL_DESCRIPTION,ZN_CODEZONE,ZN_NOMZONE,ZN_DESCRIPTION

            switch (vppCritere.Length)
            {

                case 1:
                    this.vapRequete += "WHERE  EX_EXERCICE=@EX_EXERCICE";
                    vapNomParametre = new string[] { "@EX_EXERCICE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;

                case 2:
                    this.vapRequete += " WHERE  EX_EXERCICE=@EX_EXERCICE AND SO_CODESOCIETE=@SO_CODESOCIETE";
                    vapNomParametre = new string[] { "@EX_EXERCICE", "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapRequete += " WHERE  EX_EXERCICE=@EX_EXERCICE AND SO_CODESOCIETE=@SO_CODESOCIETE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR";
                    vapNomParametre = new string[] { "@EX_EXERCICE", "@SO_CODESOCIETE", "@OP_CODEOPERATEUR" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapRequete += " WHERE EX_EXERCICE=@EX_EXERCICE AND SO_CODESOCIETE = @SO_CODESOCIETE  AND ZN_CODEZONE LIKE '%'+@ZN_CODEZONE+'%' ";
                    vapNomParametre = new string[] { "@EX_EXERCICE", "@SO_CODESOCIETE", "@OP_CODEOPERATEUR", "@ZN_CODEZONE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
                case 5:
                    this.vapRequete += " WHERE EX_EXERCICE=@EX_EXERCICE AND SO_CODESOCIETE = @SO_CODESOCIETE AND OP_CODEOPERATEUR=@OP_CODEOPERATEUR AND ZN_CODEZONE LIKE '%'+@ZN_CODEZONE+'%' AND AG_AGENCECODE LIKE '%'+@AG_AGENCECODE+'%' ";
                    vapNomParametre = new string[] { "@EX_EXERCICE", "@SO_CODESOCIETE", "@OP_CODEOPERATEUR", "@ZN_CODEZONE", "@AG_AGENCECODE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;

                default:
                    break;
            }
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetZone(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT ZN_CODEZONE,ZN_NOMZONE,SO_CODESOCIETE,ZN_DESCRIPTION FROM ZONE ";

            switch (vppCritere.Length)
            {
                case 0:
                    this.vapRequete += "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapRequete += " WHERE  ZN_CODEZONE=@ZN_CODEZONE";
                    vapNomParametre = new string[] { "@ZN_CODEZONE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;

                default:
                    break;
            }
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

        }

        public DataSet pvgInsertIntoDatasetExercice(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT DISTINCT EX_EXERCICE FROM EXERCICE ORDER BY EX_EXERCICE DESC";

            switch (vppCritere.Length)
            {

                case 0:
                    this.vapRequete += "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapRequete += " WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;

                case 2:
                    this.vapRequete += " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EX_EXERCICE=@EX_EXERCICE ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EX_EXERCICE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;

                default:
                    break;
            }
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetPeriodicite(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT * FROM PERIODICITE ";

            switch (vppCritere.Length)
            {
                case 0:
                    this.vapRequete += " WHERE PE_ACTIF='O'AND PE_PRODUCTIONETATFINANCIER='O' ";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;

                case 1:
                    this.vapRequete += " WHERE  PE_CODEPERIODICITE=@PE_CODEPERIODICITE AND PE_ACTIF='O' AND PE_PRODUCTIONETATFINANCIER='O' ";
                    vapNomParametre = new string[] { "@PE_CODEPERIODICITE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;

                default:
                    break;
            }
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetPeriode(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT * FROM PERIODE ";

            switch (vppCritere.Length)
            {

                case 0:
                    this.vapRequete += "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapRequete += " WHERE PE_CODEPERIODICITE = @PE_CODEPERIODICITE ";
                    vapNomParametre = new string[] { "@PE_CODEPERIODICITE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;

                case 2:
                    this.vapRequete += " WHERE PE_CODEPERIODICITE=@PE_CODEPERIODICITE AND PP_CODEPERIODE=@PP_CODEPERIODE ";
                    vapNomParametre = new string[] { "@PE_CODEPERIODICITE", "@PP_CODEPERIODE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;

                default:
                    break;
            }
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgPeriodicite(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@PE_CODEPERIODICITE" };
            vapValeurParametre = new object[] { vppCritere[0] };
            this.vapRequete = " select * from FC_PERIODICITE (@PE_CODEPERIODICITE)";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgPeriodiciteDateDebutFin(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@EX_EXERCICE", "@MO_CODEMOIS", "@PE_CODEPERIODICITE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
            this.vapRequete = " select * from FC_PERIODICITEDATEDEBUTFIN (@EX_EXERCICE,@MO_CODEMOIS,@PE_CODEPERIODICITE)";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgInsertIntoDatasetSociete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT * FROM SOCIETE ";

            switch (vppCritere.Length)
            {
                case 0:
                    this.vapRequete += "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapRequete += " WHERE  SO_CODESOCIETE=@SO_CODESOCIETE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;

                default:
                    break;
            }
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

        }

        public DataSet pvgInsertIntoDatasetTESTSOCIETE(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT * FROM TESTSOCIETE ";

            switch (vppCritere.Length)
            {
                case 0:
                    this.vapRequete += "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapRequete += " WHERE  SO_CODESOCIETE=@SO_CODESOCIETE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;

                default:
                    break;
            }
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

        }

        public DataSet pvgInsertIntoDatasetTESTZONE(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT * FROM TESTZONE ";

            switch (vppCritere.Length)
            {
                case 0:
                    this.vapRequete += "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapRequete += " WHERE  SO_CODESOCIETE=@SO_CODESOCIETE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;

                default:
                    break;
            }
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

        }



        public DataSet pvgInsertIntoDatasetTestAgence(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT * FROM VUE_TESTZONEVILLEAGENCE ";

            switch (vppCritere.Length)
            {

                case 0:
                    this.vapRequete += "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;

                case 1:
                    this.vapRequete += " WHERE  SO_CODESOCIETE=@SO_CODESOCIETE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapRequete += " WHERE  SO_CODESOCIETE = @SO_CODESOCIETE AND ZN_CODEZONE LIKE '%'+@ZN_CODEZONE+'%' ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@ZN_CODEZONE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapRequete += " WHERE  SO_CODESOCIETE = @SO_CODESOCIETE AND ZN_CODEZONE LIKE '%'+@ZN_CODEZONE+'%' AND AG_AGENCECODE LIKE '%'+@AG_AGENCECODE+'%' ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@ZN_CODEZONE", "@AG_AGENCECODE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

                default:
                    break;
            }
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

        }

        public DataSet pvgEnteteDesEtats(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@PP_CODEPARAMETRE" };
            vapValeurParametre = new object[] { vppCritere[0] };
            this.vapRequete = " SELECT PP_CODEPARAMETRE,SO_CODESOCIETE,PP_LIBELLE,PP_MONTANT,PP_VALEUR,PP_MONTANTMAXI from PARAMETRE WHERE substring( PP_CODEPARAMETRE,1,3)=@PP_CODEPARAMETRE ORDER BY PP_MONTANTMAXI";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }




        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CO_CODECOMPTE, PU_CODEPROCURATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMiccompteprocuration>clsMiccompteprocuration</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsParametre clsParametre, params string[] vppCritere)
        {
            //Préparation des paramètres

            SqlParameter vppParamPP_VALEUR = new SqlParameter("@PP_VALEUR", SqlDbType.VarChar, 25);
            vppParamPP_VALEUR.Value = clsParametre.PP_VALEUR;

            //Préparation de la commande
            pvpChoixCritere(vppCritere);
            this.vapRequete = "UPDATE PARAMETRE SET " +
                           "PP_VALEUR = @PP_VALEUR " + vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);



            vppSqlCmd.Parameters.Add(vppParamPP_VALEUR);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        public void pvgSuppressionTableTemporaire(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@OP_CODEOPERATEUREDITION", "@PREFIXE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
            this.vapRequete = "EXEC PS_ETATSUPPRIMERTABLETEMPORAIRE @OP_CODEOPERATEUREDITION,@PREFIXE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandTimeout = 0;
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }



        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, EN_CODEENTREPOT ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboAgenceEdition(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@EX_EXERCICE", "@SO_CODESOCIETE", "@ZN_CODEZONE", "@AG_CODEAGENCE", "@OP_CODEOPERATEUR" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
            this.vapRequete = "EXEC PS_COMBOAGENCE @EX_EXERCICE,@SO_CODESOCIETE,@ZN_CODEZONE,@AG_CODEAGENCE,@OP_CODEOPERATEUR,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgInsertIntoDatasetDroitUtilisateurlist(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapRequete = "SELECT  DP_CODEDROITCOMPTEUTULISATEUR, DP_LIBELLEDROITCOMPTEUTULISATEUR, DP_STATUT FROM dbo.FT_REQUTILISATEURDROITPARAMETRE(@CODECRYPTAGE) ";

            switch (vppCritere.Length)
            {

                case 0:
                    this.vapRequete += "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                default:
                    break;
            }
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, CO_CODECOMPTE, PU_CODEPROCURATION)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECOMPTE=@CO_CODECOMPTE AND CL_IDCLIENT IS NULL";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@CO_CODECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECOMPTE=@CO_CODECOMPTE AND PU_CODEPROCURATION =@PU_CODEPROCURATION";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@CO_CODECOMPTE", "@PU_CODEPROCURATION" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECOMPTE=@CO_CODECOMPTE AND CL_IDCLIENT IS NOT NULL";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@CO_CODECOMPTE", "@PU_CODEPROCURATION" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 5:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CO_CODECOMPTE=@CO_CODECOMPTE AND CL_IDCLIENT=@CL_IDCLIENT";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@CO_CODECOMPTE", "@CL_IDCLIENT" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }

    }
}
