using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.BOJ.BusinessObjects;
using MgRequeteClients.DAL.Interfaces;
using MgRequeteClients.Tools.Classes;

namespace MgRequeteClients.DAL.Classes
{
    public class clsReqactioncorrectiveWSDAL : ITableDAL<clsReqactioncorrective>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AC_CODEACTIONCORRECTIVE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(AC_CODEACTIONCORRECTIVE) AS AC_CODEACTIONCORRECTIVE  FROM dbo.FT_REQACTIONCORRECTIVE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AC_CODEACTIONCORRECTIVE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(AC_CODEACTIONCORRECTIVE) AS AC_CODEACTIONCORRECTIVE  FROM dbo.FT_REQACTIONCORRECTIVE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AC_CODEACTIONCORRECTIVE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(AC_CODEACTIONCORRECTIVE) AS AC_CODEACTIONCORRECTIVE  FROM dbo.FT_REQACTIONCORRECTIVE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AC_CODEACTIONCORRECTIVE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsReqactioncorrective comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsReqactioncorrective pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AC_LIBELLEACTIONCORRECTIVE  FROM dbo.FT_REQACTIONCORRECTIVE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsReqactioncorrective clsReqactioncorrective = new clsReqactioncorrective();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsReqactioncorrective.AC_LIBELLEACTIONCORRECTIVE = clsDonnee.vogDataReader["AC_LIBELLEACTIONCORRECTIVE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsReqactioncorrective;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqactioncorrective>clsReqactioncorrective</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsReqactioncorrective clsReqactioncorrective)
        {
            //Préparation des paramètres
            SqlParameter vppParamAC_CODEACTIONCORRECTIVE = new SqlParameter("@AC_CODEACTIONCORRECTIVE", SqlDbType.VarChar, 2);
            vppParamAC_CODEACTIONCORRECTIVE.Value = clsReqactioncorrective.AC_CODEACTIONCORRECTIVE;
            SqlParameter vppParamAC_LIBELLEACTIONCORRECTIVE = new SqlParameter("@AC_LIBELLEACTIONCORRECTIVE", SqlDbType.VarChar, 150);
            vppParamAC_LIBELLEACTIONCORRECTIVE.Value = clsReqactioncorrective.AC_LIBELLEACTIONCORRECTIVE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQACTIONCORRECTIVE  @AC_CODEACTIONCORRECTIVE, @AC_LIBELLEACTIONCORRECTIVE, @CODECRYPTAGE, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIONCORRECTIVE);
            vppSqlCmd.Parameters.Add(vppParamAC_LIBELLEACTIONCORRECTIVE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AC_CODEACTIONCORRECTIVE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqactioncorrective>clsReqactioncorrective</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsReqactioncorrective clsReqactioncorrective, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamAC_CODEACTIONCORRECTIVE = new SqlParameter("@AC_CODEACTIONCORRECTIVE", SqlDbType.VarChar, 2);
            vppParamAC_CODEACTIONCORRECTIVE.Value = clsReqactioncorrective.AC_CODEACTIONCORRECTIVE;
            SqlParameter vppParamAC_LIBELLEACTIONCORRECTIVE = new SqlParameter("@AC_LIBELLEACTIONCORRECTIVE", SqlDbType.VarChar, 150);
            vppParamAC_LIBELLEACTIONCORRECTIVE.Value = clsReqactioncorrective.AC_LIBELLEACTIONCORRECTIVE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQACTIONCORRECTIVE  @AC_CODEACTIONCORRECTIVE, @AC_LIBELLEACTIONCORRECTIVE, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIONCORRECTIVE);
            vppSqlCmd.Parameters.Add(vppParamAC_LIBELLEACTIONCORRECTIVE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AC_CODEACTIONCORRECTIVE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQACTIONCORRECTIVE  @AC_CODEACTIONCORRECTIVE, '' , @CODECRYPTAGE, 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AC_CODEACTIONCORRECTIVE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsReqactioncorrective </returns>
        ///<author>Home Technology</author>
        public List<clsReqactioncorrective> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AC_CODEACTIONCORRECTIVE, AC_LIBELLEACTIONCORRECTIVE FROM dbo.FT_REQACTIONCORRECTIVE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsReqactioncorrective> clsReqactioncorrectives = new List<clsReqactioncorrective>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsReqactioncorrective clsReqactioncorrective = new clsReqactioncorrective();
                    clsReqactioncorrective.AC_CODEACTIONCORRECTIVE = clsDonnee.vogDataReader["AC_CODEACTIONCORRECTIVE"].ToString();
                    clsReqactioncorrective.AC_LIBELLEACTIONCORRECTIVE = clsDonnee.vogDataReader["AC_LIBELLEACTIONCORRECTIVE"].ToString();
                    clsReqactioncorrectives.Add(clsReqactioncorrective);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsReqactioncorrectives;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AC_CODEACTIONCORRECTIVE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsReqactioncorrective </returns>
        ///<author>Home Technology</author>
        public List<clsReqactioncorrective> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsReqactioncorrective> clsReqactioncorrectives = new List<clsReqactioncorrective>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AC_CODEACTIONCORRECTIVE, AC_LIBELLEACTIONCORRECTIVE FROM dbo.FT_REQACTIONCORRECTIVE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsReqactioncorrective clsReqactioncorrective = new clsReqactioncorrective();
                    clsReqactioncorrective.AC_CODEACTIONCORRECTIVE = Dataset.Tables["TABLE"].Rows[Idx]["AC_CODEACTIONCORRECTIVE"].ToString();
                    clsReqactioncorrective.AC_LIBELLEACTIONCORRECTIVE = Dataset.Tables["TABLE"].Rows[Idx]["AC_LIBELLEACTIONCORRECTIVE"].ToString();
                    clsReqactioncorrectives.Add(clsReqactioncorrective);
                }
                Dataset.Dispose();
            }
            return clsReqactioncorrectives;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AC_CODEACTIONCORRECTIVE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_REQACTIONCORRECTIVE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AC_CODEACTIONCORRECTIVE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AC_CODEACTIONCORRECTIVE , AC_LIBELLEACTIONCORRECTIVE FROM dbo.FT_REQACTIONCORRECTIVE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AC_CODEACTIONCORRECTIVE)</summary>
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
                    this.vapCritere = "WHERE AC_CODEACTIONCORRECTIVE=@AC_CODEACTIONCORRECTIVE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AC_CODEACTIONCORRECTIVE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
            }
        }

    }
}
