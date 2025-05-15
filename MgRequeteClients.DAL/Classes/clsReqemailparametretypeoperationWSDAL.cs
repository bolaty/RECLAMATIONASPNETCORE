using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.Tools.Classes;
using MgRequeteClients.DAL.Interfaces;
using MgRequeteClients.BOJ.BusinessObjects;
using Microsoft.Data.SqlClient;

namespace MgRequeteClients.DAL.Classes
{
    public class clsReqemailparametretypeoperationWSDAL : ITableDAL<clsReqemailparametretypeoperation>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(PW_CODEWEBTYPEOPERATION) AS PW_CODEWEBTYPEOPERATION  FROM dbo.FT_REQEMAILPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(PW_CODEWEBTYPEOPERATION) AS PW_CODEWEBTYPEOPERATION  FROM dbo.FT_REQEMAILPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(PW_CODEWEBTYPEOPERATION) AS PW_CODEWEBTYPEOPERATION  FROM dbo.FT_REQEMAILPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsReqemailparametretypeoperation comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsReqemailparametretypeoperation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT PW_LIBELLE  , PW_ACTIF  FROM dbo.FT_REQEMAILPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsReqemailparametretypeoperation clsReqemailparametretypeoperation = new clsReqemailparametretypeoperation();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsReqemailparametretypeoperation.PW_LIBELLE = clsDonnee.vogDataReader["PW_LIBELLE"].ToString();
                    clsReqemailparametretypeoperation.PW_ACTIF = clsDonnee.vogDataReader["PW_ACTIF"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsReqemailparametretypeoperation;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqemailparametretypeoperation>clsReqemailparametretypeoperation</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsReqemailparametretypeoperation clsReqemailparametretypeoperation)
        {
            //Préparation des paramètres
            SqlParameter vppParamPW_CODEWEBTYPEOPERATION = new SqlParameter("@PW_CODEWEBTYPEOPERATION", SqlDbType.VarChar, 4);
            vppParamPW_CODEWEBTYPEOPERATION.Value = clsReqemailparametretypeoperation.PW_CODEWEBTYPEOPERATION;
            SqlParameter vppParamPW_LIBELLE = new SqlParameter("@PW_LIBELLE", SqlDbType.VarChar, 150);
            vppParamPW_LIBELLE.Value = clsReqemailparametretypeoperation.PW_LIBELLE;
            SqlParameter vppParamPW_ACTIF = new SqlParameter("@PW_ACTIF", SqlDbType.VarChar, 1);
            vppParamPW_ACTIF.Value = clsReqemailparametretypeoperation.PW_ACTIF;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQEMAILPARAMETRETYPEOPERATION  @PW_CODEWEBTYPEOPERATION, @PW_LIBELLE, @PW_ACTIF, @CODECRYPTAGE, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamPW_CODEWEBTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamPW_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamPW_ACTIF);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqemailparametretypeoperation>clsReqemailparametretypeoperation</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsReqemailparametretypeoperation clsReqemailparametretypeoperation, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamPW_CODEWEBTYPEOPERATION = new SqlParameter("@PW_CODEWEBTYPEOPERATION", SqlDbType.VarChar, 4);
            vppParamPW_CODEWEBTYPEOPERATION.Value = clsReqemailparametretypeoperation.PW_CODEWEBTYPEOPERATION;
            SqlParameter vppParamPW_LIBELLE = new SqlParameter("@PW_LIBELLE", SqlDbType.VarChar, 150);
            vppParamPW_LIBELLE.Value = clsReqemailparametretypeoperation.PW_LIBELLE;
            SqlParameter vppParamPW_ACTIF = new SqlParameter("@PW_ACTIF", SqlDbType.VarChar, 1);
            vppParamPW_ACTIF.Value = clsReqemailparametretypeoperation.PW_ACTIF;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQEMAILPARAMETRETYPEOPERATION  @PW_CODEWEBTYPEOPERATION, @PW_LIBELLE, @PW_ACTIF, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamPW_CODEWEBTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamPW_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamPW_ACTIF);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQEMAILPARAMETRETYPEOPERATION  @PW_CODEWEBTYPEOPERATION, '' , '' , @CODECRYPTAGE, 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsReqemailparametretypeoperation </returns>
        ///<author>Home Technology</author>
        public List<clsReqemailparametretypeoperation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  PW_CODEWEBTYPEOPERATION, PW_LIBELLE, PW_ACTIF FROM dbo.FT_REQEMAILPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsReqemailparametretypeoperation> clsReqemailparametretypeoperations = new List<clsReqemailparametretypeoperation>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsReqemailparametretypeoperation clsReqemailparametretypeoperation = new clsReqemailparametretypeoperation();
                    clsReqemailparametretypeoperation.PW_CODEWEBTYPEOPERATION = clsDonnee.vogDataReader["PW_CODEWEBTYPEOPERATION"].ToString();
                    clsReqemailparametretypeoperation.PW_LIBELLE = clsDonnee.vogDataReader["PW_LIBELLE"].ToString();
                    clsReqemailparametretypeoperation.PW_ACTIF = clsDonnee.vogDataReader["PW_ACTIF"].ToString();
                    clsReqemailparametretypeoperations.Add(clsReqemailparametretypeoperation);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsReqemailparametretypeoperations;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsReqemailparametretypeoperation </returns>
        ///<author>Home Technology</author>
        public List<clsReqemailparametretypeoperation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsReqemailparametretypeoperation> clsReqemailparametretypeoperations = new List<clsReqemailparametretypeoperation>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  PW_CODEWEBTYPEOPERATION, PW_LIBELLE, PW_ACTIF FROM dbo.FT_REQEMAILPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsReqemailparametretypeoperation clsReqemailparametretypeoperation = new clsReqemailparametretypeoperation();
                    clsReqemailparametretypeoperation.PW_CODEWEBTYPEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["PW_CODEWEBTYPEOPERATION"].ToString();
                    clsReqemailparametretypeoperation.PW_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PW_LIBELLE"].ToString();
                    clsReqemailparametretypeoperation.PW_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["PW_ACTIF"].ToString();
                    clsReqemailparametretypeoperations.Add(clsReqemailparametretypeoperation);
                }
                Dataset.Dispose();
            }
            return clsReqemailparametretypeoperations;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_REQEMAILPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT PW_CODEWEBTYPEOPERATION , PW_LIBELLE FROM dbo.FT_REQEMAILPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PW_CODEWEBTYPEOPERATION)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
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
                    this.vapCritere = "WHERE PW_CODEWEBTYPEOPERATION=@PW_CODEWEBTYPEOPERATION";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@PW_CODEWEBTYPEOPERATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
            }
        }
    }
}
