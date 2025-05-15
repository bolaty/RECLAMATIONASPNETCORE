using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.BOJ.BusinessObjects;
using MgRequeteClients.Tools.Classes;
using MgRequeteClients.DAL.Interfaces;
using Microsoft.Data.SqlClient;

namespace MgRequeteClients.DAL.Classes
{
    public class clsSmsoutWSDAL : ITableDAL<clsSmsout>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_SMSOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_SMSOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_SMSOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsSmsout comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsSmsout pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MC_DATEPIECE  , MC_NUMPIECE  , MC_NUMSEQUENCE  , TE_CODESMSTYPEOPERATION  , CO_CODECOMPTE  , SM_MESSAGE  , SM_TELEPHONE  , SM_STATUT  , SM_DATEEMISSIONSMS  , SM_DATESAISIE  FROM dbo.FT_SMSOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsSmsout clsSmsout = new clsSmsout();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsSmsout.MC_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["MC_DATEPIECE"].ToString());
                    clsSmsout.MC_NUMPIECE = clsDonnee.vogDataReader["MC_NUMPIECE"].ToString();
                    clsSmsout.MC_NUMSEQUENCE = clsDonnee.vogDataReader["MC_NUMSEQUENCE"].ToString();
                    clsSmsout.TE_CODESMSTYPEOPERATION = clsDonnee.vogDataReader["TE_CODESMSTYPEOPERATION"].ToString();
                    clsSmsout.CO_CODECOMPTE = clsDonnee.vogDataReader["CO_CODECOMPTE"].ToString();
                    clsSmsout.SM_MESSAGE = clsDonnee.vogDataReader["SM_MESSAGE"].ToString();
                    clsSmsout.SM_TELEPHONE = clsDonnee.vogDataReader["SM_TELEPHONE"].ToString();
                    clsSmsout.SM_STATUT = clsDonnee.vogDataReader["SM_STATUT"].ToString();
                    clsSmsout.SM_DATEEMISSIONSMS = DateTime.Parse(clsDonnee.vogDataReader["SM_DATEEMISSIONSMS"].ToString());
                    clsSmsout.SM_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["SM_DATESAISIE"].ToString());
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsSmsout;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsSmsout>clsSmsout</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsSmsout clsSmsout)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsSmsout.AG_CODEAGENCE;
            SqlParameter vppParamSM_DATEPIECE = new SqlParameter("@SM_DATEPIECE", SqlDbType.DateTime);
            vppParamSM_DATEPIECE.Value = clsSmsout.SM_DATEPIECE;
            SqlParameter vppParamSM_NUMSEQUENCE = new SqlParameter("@SM_NUMSEQUENCE", SqlDbType.VarChar, 25);
            vppParamSM_NUMSEQUENCE.Value = clsSmsout.SM_NUMSEQUENCE;
            SqlParameter vppParamMC_DATEPIECE = new SqlParameter("@MC_DATEPIECE", SqlDbType.DateTime);
            vppParamMC_DATEPIECE.Value = clsSmsout.MC_DATEPIECE;
            if (clsSmsout.MC_DATEPIECE.Year < 1900) vppParamMC_DATEPIECE.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamMC_NUMPIECE = new SqlParameter("@MC_NUMPIECE", SqlDbType.VarChar, 25);
            vppParamMC_NUMPIECE.Value = clsSmsout.MC_NUMPIECE;
            if (clsSmsout.MC_NUMPIECE == "") vppParamMC_NUMPIECE.Value = DBNull.Value;
            SqlParameter vppParamMC_NUMSEQUENCE = new SqlParameter("@MC_NUMSEQUENCE", SqlDbType.VarChar, 25);
            vppParamMC_NUMSEQUENCE.Value = clsSmsout.MC_NUMSEQUENCE;
            if (clsSmsout.MC_NUMSEQUENCE == "") vppParamMC_NUMSEQUENCE.Value = DBNull.Value;
            SqlParameter vppParamTE_CODESMSTYPEOPERATION = new SqlParameter("@TE_CODESMSTYPEOPERATION", SqlDbType.VarChar, 4);
            vppParamTE_CODESMSTYPEOPERATION.Value = clsSmsout.TE_CODESMSTYPEOPERATION;
            SqlParameter vppParamCO_CODECOMPTE = new SqlParameter("@CO_CODECOMPTE", SqlDbType.VarChar, 50);
            vppParamCO_CODECOMPTE.Value = clsSmsout.CO_CODECOMPTE;
            SqlParameter vppParamSM_MESSAGE = new SqlParameter("@SM_MESSAGE", SqlDbType.VarChar, 1000);
            vppParamSM_MESSAGE.Value = clsSmsout.SM_MESSAGE;
            SqlParameter vppParamSM_TELEPHONE = new SqlParameter("@SM_TELEPHONE", SqlDbType.VarChar, 1000);
            vppParamSM_TELEPHONE.Value = clsSmsout.SM_TELEPHONE;
            SqlParameter vppParamSM_STATUT = new SqlParameter("@SM_STATUT", SqlDbType.VarChar, 1);
            vppParamSM_STATUT.Value = clsSmsout.SM_STATUT;
            SqlParameter vppParamSM_DATEEMISSIONSMS = new SqlParameter("@SM_DATEEMISSIONSMS", SqlDbType.DateTime);
            vppParamSM_DATEEMISSIONSMS.Value = clsSmsout.SM_DATEEMISSIONSMS;
            SqlParameter vppParamSM_DATESAISIE = new SqlParameter("@SM_DATESAISIE", SqlDbType.DateTime);
            vppParamSM_DATESAISIE.Value = clsSmsout.SM_DATESAISIE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_SMSOUT  @AG_CODEAGENCE, @SM_DATEPIECE, @SM_NUMSEQUENCE, @MC_DATEPIECE, @MC_NUMPIECE, @MC_NUMSEQUENCE, @TE_CODESMSTYPEOPERATION, @CO_CODECOMPTE, @SM_MESSAGE, @SM_TELEPHONE, @SM_STATUT, @SM_DATEEMISSIONSMS, @SM_DATESAISIE, @CODECRYPTAGE, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamSM_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamSM_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamMC_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMC_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMC_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamTE_CODESMSTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamCO_CODECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamSM_MESSAGE);
            vppSqlCmd.Parameters.Add(vppParamSM_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamSM_STATUT);
            vppSqlCmd.Parameters.Add(vppParamSM_DATEEMISSIONSMS);
            vppSqlCmd.Parameters.Add(vppParamSM_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsSmsout>clsSmsout</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsSmsout clsSmsout, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsSmsout.AG_CODEAGENCE;
            SqlParameter vppParamSM_DATEPIECE = new SqlParameter("@SM_DATEPIECE", SqlDbType.DateTime);
            vppParamSM_DATEPIECE.Value = clsSmsout.SM_DATEPIECE;
            SqlParameter vppParamSM_NUMSEQUENCE = new SqlParameter("@SM_NUMSEQUENCE", SqlDbType.VarChar, 25);
            vppParamSM_NUMSEQUENCE.Value = clsSmsout.SM_NUMSEQUENCE;
            SqlParameter vppParamMC_DATEPIECE = new SqlParameter("@MC_DATEPIECE", SqlDbType.DateTime);
            vppParamMC_DATEPIECE.Value = clsSmsout.MC_DATEPIECE;
            if (clsSmsout.MC_DATEPIECE.Year < 1900) vppParamMC_DATEPIECE.Value = DateTime.Parse("01/01/1900");
            SqlParameter vppParamMC_NUMPIECE = new SqlParameter("@MC_NUMPIECE", SqlDbType.VarChar, 25);
            vppParamMC_NUMPIECE.Value = clsSmsout.MC_NUMPIECE;
            if (clsSmsout.MC_NUMPIECE == "") vppParamMC_NUMPIECE.Value = DBNull.Value;
            SqlParameter vppParamMC_NUMSEQUENCE = new SqlParameter("@MC_NUMSEQUENCE", SqlDbType.VarChar, 25);
            vppParamMC_NUMSEQUENCE.Value = clsSmsout.MC_NUMSEQUENCE;
            if (clsSmsout.MC_NUMSEQUENCE == "") vppParamMC_NUMSEQUENCE.Value = DBNull.Value;
            SqlParameter vppParamTE_CODESMSTYPEOPERATION = new SqlParameter("@TE_CODESMSTYPEOPERATION", SqlDbType.VarChar, 4);
            vppParamTE_CODESMSTYPEOPERATION.Value = clsSmsout.TE_CODESMSTYPEOPERATION;
            SqlParameter vppParamCO_CODECOMPTE = new SqlParameter("@CO_CODECOMPTE", SqlDbType.VarChar, 50);
            vppParamCO_CODECOMPTE.Value = clsSmsout.CO_CODECOMPTE;
            SqlParameter vppParamSM_MESSAGE = new SqlParameter("@SM_MESSAGE", SqlDbType.VarChar, 1000);
            vppParamSM_MESSAGE.Value = clsSmsout.SM_MESSAGE;
            SqlParameter vppParamSM_TELEPHONE = new SqlParameter("@SM_TELEPHONE", SqlDbType.VarChar, 1000);
            vppParamSM_TELEPHONE.Value = clsSmsout.SM_TELEPHONE;
            SqlParameter vppParamSM_STATUT = new SqlParameter("@SM_STATUT", SqlDbType.VarChar, 1);
            vppParamSM_STATUT.Value = clsSmsout.SM_STATUT;
            SqlParameter vppParamSM_DATEEMISSIONSMS = new SqlParameter("@SM_DATEEMISSIONSMS", SqlDbType.DateTime);
            vppParamSM_DATEEMISSIONSMS.Value = clsSmsout.SM_DATEEMISSIONSMS;
            SqlParameter vppParamSM_DATESAISIE = new SqlParameter("@SM_DATESAISIE", SqlDbType.DateTime);
            vppParamSM_DATESAISIE.Value = clsSmsout.SM_DATESAISIE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_SMSOUT  @AG_CODEAGENCE, @SM_DATEPIECE, @SM_NUMSEQUENCE, @MC_DATEPIECE, @MC_NUMPIECE, @MC_NUMSEQUENCE, @TE_CODESMSTYPEOPERATION, @CO_CODECOMPTE, @SM_MESSAGE, @SM_TELEPHONE, @SM_STATUT, @SM_DATEEMISSIONSMS, @SM_DATESAISIE, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamSM_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamSM_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamMC_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamMC_NUMPIECE);
            vppSqlCmd.Parameters.Add(vppParamMC_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamTE_CODESMSTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamCO_CODECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamSM_MESSAGE);
            vppSqlCmd.Parameters.Add(vppParamSM_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamSM_STATUT);
            vppSqlCmd.Parameters.Add(vppParamSM_DATEEMISSIONSMS);
            vppSqlCmd.Parameters.Add(vppParamSM_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_SMSOUT  @AG_CODEAGENCE, @SM_DATEPIECE, @SM_NUMSEQUENCE, '' , '' , '' , @TE_CODESMSTYPEOPERATION, @CO_CODECOMPTE, '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsSmsout </returns>
        ///<author>Home Technology</author>
        public List<clsSmsout> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE, SM_MESSAGE, SM_TELEPHONE, SM_STATUT, SM_DATEEMISSIONSMS, SM_DATESAISIE FROM dbo.FT_SMSOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsSmsout> clsSmsouts = new List<clsSmsout>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsSmsout clsSmsout = new clsSmsout();
                    clsSmsout.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsSmsout.SM_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["SM_DATEPIECE"].ToString());
                    clsSmsout.SM_NUMSEQUENCE = clsDonnee.vogDataReader["SM_NUMSEQUENCE"].ToString();
                    clsSmsout.MC_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["MC_DATEPIECE"].ToString());
                    clsSmsout.MC_NUMPIECE = clsDonnee.vogDataReader["MC_NUMPIECE"].ToString();
                    clsSmsout.MC_NUMSEQUENCE = clsDonnee.vogDataReader["MC_NUMSEQUENCE"].ToString();
                    clsSmsout.TE_CODESMSTYPEOPERATION = clsDonnee.vogDataReader["TE_CODESMSTYPEOPERATION"].ToString();
                    clsSmsout.CO_CODECOMPTE = clsDonnee.vogDataReader["CO_CODECOMPTE"].ToString();
                    clsSmsout.SM_MESSAGE = clsDonnee.vogDataReader["SM_MESSAGE"].ToString();
                    clsSmsout.SM_TELEPHONE = clsDonnee.vogDataReader["SM_TELEPHONE"].ToString();
                    clsSmsout.SM_STATUT = clsDonnee.vogDataReader["SM_STATUT"].ToString();
                    clsSmsout.SM_DATEEMISSIONSMS = DateTime.Parse(clsDonnee.vogDataReader["SM_DATEEMISSIONSMS"].ToString());
                    clsSmsout.SM_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["SM_DATESAISIE"].ToString());
                    clsSmsouts.Add(clsSmsout);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsSmsouts;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsSmsout </returns>
        ///<author>Home Technology</author>
        public List<clsSmsout> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsSmsout> clsSmsouts = new List<clsSmsout>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE, SM_MESSAGE, SM_TELEPHONE, SM_STATUT, SM_DATEEMISSIONSMS, SM_DATESAISIE FROM dbo.FT_SMSOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsSmsout clsSmsout = new clsSmsout();
                    clsSmsout.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsSmsout.SM_DATEPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SM_DATEPIECE"].ToString());
                    clsSmsout.SM_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["SM_NUMSEQUENCE"].ToString();
                    clsSmsout.MC_DATEPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MC_DATEPIECE"].ToString());
                    clsSmsout.MC_NUMPIECE = Dataset.Tables["TABLE"].Rows[Idx]["MC_NUMPIECE"].ToString();
                    clsSmsout.MC_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["MC_NUMSEQUENCE"].ToString();
                    clsSmsout.TE_CODESMSTYPEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["TE_CODESMSTYPEOPERATION"].ToString();
                    clsSmsout.CO_CODECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECOMPTE"].ToString();
                    clsSmsout.SM_MESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["SM_MESSAGE"].ToString();
                    clsSmsout.SM_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["SM_TELEPHONE"].ToString();
                    clsSmsout.SM_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["SM_STATUT"].ToString();
                    clsSmsout.SM_DATEEMISSIONSMS = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SM_DATEEMISSIONSMS"].ToString());
                    clsSmsout.SM_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SM_DATESAISIE"].ToString());
                    clsSmsouts.Add(clsSmsout);
                }
                Dataset.Dispose();
            }
            return clsSmsouts;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_SMSOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetAPI(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@DATEDEBUT", "@DATEFIN", "@TW_MATRICULEELEVE", "@TW_NOMELEVE", "@TW_PRENOMSELEVE", "@TYPEOPERATION", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC [dbo].[PS_MOBILELISTEINSCRIPTIONATRAITER1] @AG_CODEAGENCE,@DATEDEBUT,@DATEFIN,@TW_MATRICULEELEVE,@TW_NOMELEVE,@TW_PRENOMSELEVE,@TYPEOPERATION,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetAPI2(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@DATEDEBUT", "@DATEFIN", "@TYPEOPERATION", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC [dbo].[PS_MOBILELISTEINSCRIPTIONATRAITER2] @AG_CODEAGENCE,@DATEDEBUT,@DATEFIN,@TYPEOPERATION,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }




        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PO_CODEPROCEDUREAUTOMATIQUE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet PvgUpdateStatutInscription(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@TW_CODEETABLISSEMENT", "@TW_CODESESSIONANNEE", "@TW_MATRICULEELEVE", "@TW_DATECONSTAT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
            this.vapRequete = "EXEC PS_TRANSFERTMgRequeteClientsUPDATESTATUTINSCRIPTION  @TW_CODEETABLISSEMENT , @TW_CODESESSIONANNEE,@TW_MATRICULEELEVE,@TW_DATECONSTAT,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetListeSMS(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@SM_STATUT", "@TO_CODETYPETRANSFERT", "@TW_DATEDEBUT", "@TW_DATEFIN", "@TW_TELEPHONEEMETTEUR", "@TW_COMPTEEMETTEUR", "@TW_NOMEMETTEUR", "@TW_PRENNOMEMETTEUR", "@TW_NOMDESTINATAIRE", "@TW_PRENNOMDESTINATAIRE", "@TW_TELEPHONEDESTINATAIRE", "@TW_MONTANTOPERATION1", "@TW_MONTANTOPERATION2", "@ST_CODESTATUTLISTE", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9], vppCritere[10], vppCritere[11], vppCritere[12], vppCritere[13], vppCritere[14], vppCritere[15] };
            this.vapRequete = "EXEC PS_MOBILELISTESMS @AG_CODEAGENCE,@SM_STATUT,@TO_CODETYPETRANSFERT,@TW_DATEDEBUT,@TW_DATEFIN,@TW_TELEPHONEEMETTEUR,@TW_COMPTEEMETTEUR,@TW_NOMEMETTEUR,@TW_PRENNOMEMETTEUR,@TW_NOMDESTINATAIRE,@TW_PRENNOMDESTINATAIRE,@TW_TELEPHONEDESTINATAIRE,@TW_MONTANTOPERATION1,@TW_MONTANTOPERATION2,@ST_CODESTATUTLISTE,@TYPEOPERATION,@CODECRYPTAGE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetListeOperations(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@SM_STATUT", "@TO_CODETYPETRANSFERT", "@TW_DATEDEBUT", "@TW_DATEFIN", "@TW_TELEPHONEEMETTEUR", "@TW_COMPTEEMETTEUR", "@TW_NOMEMETTEUR", "@TW_PRENNOMEMETTEUR", "@TW_NOMDESTINATAIRE", "@TW_PRENNOMDESTINATAIRE", "@TW_TELEPHONEDESTINATAIRE", "@TW_MONTANTOPERATION1", "@TW_MONTANTOPERATION2", "@ST_CODESTATUTLISTE", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9], vppCritere[10], vppCritere[11], vppCritere[12], vppCritere[13], vppCritere[14], vppCritere[15] };
            this.vapRequete = "EXEC PS_MOBILELISTEOPERATION @AG_CODEAGENCE,@SM_STATUT,@TO_CODETYPETRANSFERT,@TW_DATEDEBUT,@TW_DATEFIN,@TW_TELEPHONEEMETTEUR,@TW_COMPTEEMETTEUR,@TW_NOMEMETTEUR,@TW_PRENNOMEMETTEUR,@TW_NOMDESTINATAIRE,@TW_PRENNOMDESTINATAIRE,@TW_TELEPHONEDESTINATAIRE,@TW_MONTANTOPERATION1,@TW_MONTANTOPERATION2,@ST_CODESTATUTLISTE,@TYPEOPERATION,@CODECRYPTAGE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public void pvgAnnulationTransfert(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TW_CODECOMPTEEMETTEUR", "@TR_CODETRANSFERT", "@TW_DATEOPERATION", "@MC_DATEPIECECOMPTABILISATION", "@OP_CODEOPERATEUR", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };
            this.vapRequete = "EXEC PS_MOBILEANNULATIONTRANSFERT @AG_CODEAGENCE,@TW_CODECOMPTEEMETTEUR,@TR_CODETRANSFERT,@TW_DATEOPERATION,@MC_DATEPIECECOMPTABILISATION,@OP_CODEOPERATEUR,@TYPEOPERATION,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE , MC_DATEPIECE FROM dbo.FT_SMSOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }




        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees via la procedure stockee PE_ACTIVITE </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsApisms">clsApisms</param>
        ///<returns>Une collection de clsApisms valeur du resultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<clsSmsout> pvgMobileSms(clsDonnee clsDonnee, clsParams clsParams)
        {
            List<clsSmsout> clsSmss = new List<clsSmsout>();
            DataSet Dataset = new DataSet();
            vapNomParametre = new string[] { "@LG_CODELANGUE", "@PV_CODEPOINTVENTE", "@CO_CODECOMPTE", "@CL_TELEPHONE", "@SM_RAISONNONENVOISMS", "@SL_MESSAGECLIENT", "@SM_DATEPIECE", "@LO_LOGICIEL", "@OB_NOMOBJET", "@EJ_IDEPARGNANTJOURNALIER", "@MB_IDTIERS", "@CL_IDCLIENT", "@TE_CODESMSTYPEOPERATION", "@SM_NUMSEQUENCE", "@SM_DATEEMISSIONSMS", "@MC_NUMPIECE", "@MC_NUMSEQUENCE", "@SM_STATUT", "@TYPEOPERATION", "@SL_LIBELLE1", "@SL_LIBELLE2", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { clsParams.LG_CODELANGUE, clsParams.PV_CODEPOINTVENTE, clsParams.CO_CODECOMPTE, clsParams.RECIPIENTPHONE, clsParams.SM_RAISONNONENVOISMS, clsParams.SMSTEXT, clsParams.SM_DATEPIECE, clsParams.LO_LOGICIEL, clsParams.OB_NOMOBJET, clsParams.EJ_IDEPARGNANTJOURNALIER, clsParams.MB_IDTIERS, clsParams.CL_IDCLIENT, clsParams.TE_CODESMSTYPEOPERATION, clsParams.SM_NUMSEQUENCE, clsParams.SM_DATEEMISSIONSMS, clsParams.MC_NUMPIECE, "", clsParams.SM_STATUT, clsParams.TYPEOPERATION, clsParams.SL_LIBELLE1, clsParams.SL_LIBELLE2, clsDonnee.vogCleCryptage };

            this.vapRequete = " EXEC PS_APISMS  @LG_CODELANGUE ,@PV_CODEPOINTVENTE,@CO_CODECOMPTE,@CL_TELEPHONE,@SM_RAISONNONENVOISMS,@SL_MESSAGECLIENT,@SM_DATEPIECE,@LO_LOGICIEL,@OB_NOMOBJET,@EJ_IDEPARGNANTJOURNALIER,@MB_IDTIERS,@CL_IDCLIENT,@TE_CODESMSTYPEOPERATION,@SM_NUMSEQUENCE,@SM_DATEEMISSIONSMS,@MC_NUMPIECE,@MC_NUMSEQUENCE,@SM_STATUT ,@TYPEOPERATION,@SL_LIBELLE1,@SL_LIBELLE2,@CODECRYPTAGE";

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);

            if (double.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                foreach (DataRow row in Dataset.Tables[0].Rows)
                {
                    clsSmsout clsSms = new clsSmsout();
                    clsSms.SL_RESULTAT = row["SL_RESULTAT"].ToString();
                    clsSms.SL_MESSAGE = row["SL_MESSAGE"].ToString();
                    clsSms.SM_TELEPHONE = row["CL_TELEPHONE"].ToString();
                    clsSms.SM_MESSAGE = row["SL_MESSAGECLIENT"].ToString();
                    clsSms.SM_DATEPIECE = DateTime.Parse(row["SM_DATEPIECE"].ToString());
                    clsSms.SM_NUMSEQUENCE = row["SM_NUMSEQUENCERETOURS"].ToString();
                    clsSmss.Add(clsSms);
                }
            }
            else
            {
                clsSmsout clsSms = new clsSmsout();
                clsSms.SL_RESULTAT = "FALSE";
                clsSms.SL_MESSAGE = "Le formatage du Sms Client à échoué";
                clsSms.SM_TELEPHONE = clsParams.RECIPIENTPHONE;
                clsSms.SM_MESSAGE = "";
                clsSms.SM_DATEPIECE = DateTime.Parse("01/01/1900");
                clsSms.SM_NUMSEQUENCE = "0";
                clsSmss.Add(clsSms);
            }
            Dataset.Dispose();
            return clsSmss;
        }




        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees via la procedure stockee PE_ACTIVITE </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsApisms">clsApisms</param>
        ///<returns>Une collection de clsApisms valeur du resultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<clsSmsout> pvgMobileSmsUpdateStatut(clsDonnee clsDonnee, string AG_CODEAGENCE, DateTime SM_DATEPIECE, DateTime SM_DATEEMISSIONSMS, string SM_NUMSEQUENCE, string SM_STATUT, string SM_RAISONNONENVOISMS)
        {
            List<clsSmsout> clsSmsouts = new List<clsSmsout>();
            DataSet Dataset = new DataSet();
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@SM_DATEPIECE", "@SM_DATEEMISSIONSMS", "@SM_NUMSEQUENCE", "@SM_STATUT", "@SM_RAISONNONENVOISMS", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { AG_CODEAGENCE, SM_DATEPIECE, SM_DATEEMISSIONSMS, SM_NUMSEQUENCE, SM_STATUT, SM_RAISONNONENVOISMS, clsDonnee.vogCleCryptage };

            this.vapRequete = " EXEC PS_MOBILESMSUPDATESTATUT  @AG_CODEAGENCE , @SM_DATEPIECE, @SM_DATEEMISSIONSMS, @SM_NUMSEQUENCE,@SM_STATUT,@SM_RAISONNONENVOISMS,@CODECRYPTAGE";


            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);

            if (double.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {

                foreach (DataRow row in Dataset.Tables[0].Rows)
                {
                    clsSmsout clsSmsout = new clsSmsout();
                    clsSmsout.SL_CODEMESSAGE = row["SL_CODEMESSAGE"].ToString();
                    clsSmsout.SL_RESULTAT = row["SL_RESULTAT"].ToString();
                    clsSmsout.SL_MESSAGE = row["SL_MESSAGE"].ToString();
                    clsSmsouts.Add(clsSmsout);
                }

            }
            Dataset.Dispose();
            return clsSmsouts;
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEMgRequeteClients, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteMgRequeteClients </returns>
        ///<author>Home Technology</author>
        public void pvgMobileInscriptionAregulariser(clsDonnee clsDonnee, string TW_MATRICULEELEVE, string TW_NOMELEVE, string TW_PRENOMSELEVE, string TW_NIVEAUELEVE, string TW_CONTACTPARENT, string TW_CODEETABLISSEMENT, string TW_NOMETABLISSEMENT, string TW_CODESESSIONANNEE, string TW_OPERATIONTRANSACTION)
        {

            vapNomParametre = new string[] { "@TW_MATRICULEELEVE", "@TW_NOMELEVE", "@TW_PRENOMSELEVE", "@TW_NIVEAUELEVE", "@TW_CONTACTPARENT", "@TW_CODEETABLISSEMENT", "@TW_NOMETABLISSEMENT", "@TW_CODESESSIONANNEE", "@TW_OPERATIONTRANSACTION" };
            vapValeurParametre = new object[] { TW_MATRICULEELEVE, TW_NOMELEVE, TW_PRENOMSELEVE, TW_NIVEAUELEVE, TW_CONTACTPARENT, TW_CODEETABLISSEMENT, TW_NOMETABLISSEMENT, TW_CODESESSIONANNEE, TW_OPERATIONTRANSACTION };

            this.vapRequete = "EXEC PS_MICCOMPTEWEBTRANSFERTREGULARISATIONINSCRIPTION  @TW_MATRICULEELEVE , @TW_NOMELEVE, @TW_PRENOMSELEVE, @TW_NIVEAUELEVE,@TW_CONTACTPARENT,@TW_CODEETABLISSEMENT,@TW_NOMETABLISSEMENT,@TW_CODESESSIONANNEE,@TW_OPERATIONTRANSACTION "; //+ this.vapCritere;
            //this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);

        }
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEMgRequeteClients, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public List<clsSmsoperateurdetlephoniecompteclient> pvgListeCompteSms(clsDonnee clsDonnee, string AG_CODEAGENCE)
        {
            List<clsSmsoperateurdetlephoniecompteclient> clsSmsoperateurdetlephoniecompteclients = new List<clsSmsoperateurdetlephoniecompteclient>();
            DataSet Dataset = new DataSet();



            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { AG_CODEAGENCE, clsDonnee.vogCleCryptage };

            this.vapRequete = "SELECT AG_CODEAGENCE  , CL_IDCLINENT  , CL_NOMUTILISATEUR  , CL_MOTDEPASSE  , CL_EMETTEUR  , CL_TYPEURL  , CL_URL  , CL_STATUT  FROM dbo.FT_SMSOPERATEURDETLEPHONIECOMPTECLIENT(@CODECRYPTAGE)  WHERE CL_STATUT='O' ";
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsSmsoperateurdetlephoniecompteclient clsSmsoperateurdetlephoniecompteclient = new clsSmsoperateurdetlephoniecompteclient();

                    clsSmsoperateurdetlephoniecompteclient.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsSmsoperateurdetlephoniecompteclient.CL_IDCLINENT = Dataset.Tables["TABLE"].Rows[Idx]["CL_IDCLINENT"].ToString();
                    clsSmsoperateurdetlephoniecompteclient.CL_NOMUTILISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CL_NOMUTILISATEUR"].ToString();
                    clsSmsoperateurdetlephoniecompteclient.CL_MOTDEPASSE = Dataset.Tables["TABLE"].Rows[Idx]["CL_MOTDEPASSE"].ToString();
                    clsSmsoperateurdetlephoniecompteclient.CL_EMETTEUR = Dataset.Tables["TABLE"].Rows[Idx]["CL_EMETTEUR"].ToString();
                    clsSmsoperateurdetlephoniecompteclient.CL_TYPEURL = Dataset.Tables["TABLE"].Rows[Idx]["CL_TYPEURL"].ToString();
                    clsSmsoperateurdetlephoniecompteclient.CL_URL = Dataset.Tables["TABLE"].Rows[Idx]["CL_URL"].ToString();
                    clsSmsoperateurdetlephoniecompteclient.CL_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["CL_STATUT"].ToString();

                    clsSmsoperateurdetlephoniecompteclients.Add(clsSmsoperateurdetlephoniecompteclient);

                }
                Dataset.Dispose();
            }
            return clsSmsoperateurdetlephoniecompteclients;
        }




        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE)</summary>
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SM_DATEPIECE=@SM_DATEPIECE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@SM_DATEPIECE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SM_DATEPIECE=@SM_DATEPIECE AND SM_NUMSEQUENCE=@SM_NUMSEQUENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@SM_DATEPIECE", "@SM_NUMSEQUENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SM_DATEPIECE=@SM_DATEPIECE AND SM_NUMSEQUENCE=@SM_NUMSEQUENCE AND TE_CODESMSTYPEOPERATION=@TE_CODESMSTYPEOPERATION";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@SM_DATEPIECE", "@SM_NUMSEQUENCE", "@TE_CODESMSTYPEOPERATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
                case 5:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SM_DATEPIECE=@SM_DATEPIECE AND SM_NUMSEQUENCE=@SM_NUMSEQUENCE AND TE_CODESMSTYPEOPERATION=@TE_CODESMSTYPEOPERATION AND CO_CODECOMPTE=@CO_CODECOMPTE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@SM_DATEPIECE", "@SM_NUMSEQUENCE", "@TE_CODESMSTYPEOPERATION", "@CO_CODECOMPTE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;
            }
        }
    }
}
