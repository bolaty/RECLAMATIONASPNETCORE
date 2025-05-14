using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.Tools.Classes;
using MgRequeteClients.DAL.Interfaces;
using MgRequeteClients.BOJ.BusinessObjects;

namespace MgRequeteClients.DAL.Classes
{
    public class clsReqemailoutWSDAL : ITableDAL<clsReqemailout>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AG_CODEAGENCE, EM_DATEPIECE, EM_NUMSEQUENCE, PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_REQEMAILOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AG_CODEAGENCE, EM_DATEPIECE, EM_NUMSEQUENCE, PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_REQEMAILOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AG_CODEAGENCE, EM_DATEPIECE, EM_NUMSEQUENCE, PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_REQEMAILOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AG_CODEAGENCE, EM_DATEPIECE, EM_NUMSEQUENCE, PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsReqemailout comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsReqemailout pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  , PW_CODEWEBTYPEOPERATION  , CU_CODECOMPTEUTULISATEUR  , EM_MESSAGE  , EM_EMAIL  , EM_STATUT  , EM_DATESAISIE  , EM_FICHERJOINT  , EM_OBJET  FROM dbo.FT_REQEMAILOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsReqemailout clsReqemailout = new clsReqemailout();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsReqemailout.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsReqemailout.PW_CODEWEBTYPEOPERATION = clsDonnee.vogDataReader["PW_CODEWEBTYPEOPERATION"].ToString();
                    clsReqemailout.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
                    clsReqemailout.EM_MESSAGE = clsDonnee.vogDataReader["EM_MESSAGE"].ToString();
                    clsReqemailout.EM_EMAIL = clsDonnee.vogDataReader["EM_EMAIL"].ToString();
                    clsReqemailout.EM_STATUT = clsDonnee.vogDataReader["EM_STATUT"].ToString();
                    clsReqemailout.EM_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["EM_DATESAISIE"].ToString());
                    clsReqemailout.EM_FICHERJOINT = clsDonnee.vogDataReader["EM_FICHERJOINT"].ToString();
                    clsReqemailout.EM_OBJET = clsDonnee.vogDataReader["EM_OBJET"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsReqemailout;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqemailout>clsReqemailout</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsReqemailout clsReqemailout)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsReqemailout.AG_CODEAGENCE;
            SqlParameter vppParamEM_DATEPIECE = new SqlParameter("@EM_DATEPIECE", SqlDbType.DateTime);
            vppParamEM_DATEPIECE.Value = clsReqemailout.EM_DATEPIECE;
            SqlParameter vppParamEM_NUMSEQUENCE = new SqlParameter("@EM_NUMSEQUENCE", SqlDbType.Int);
            vppParamEM_NUMSEQUENCE.Value = clsReqemailout.EM_NUMSEQUENCE;
            SqlParameter vppParamPW_CODEWEBTYPEOPERATION = new SqlParameter("@PW_CODEWEBTYPEOPERATION", SqlDbType.VarChar, 4);
            vppParamPW_CODEWEBTYPEOPERATION.Value = clsReqemailout.PW_CODEWEBTYPEOPERATION;
            SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
            vppParamCU_CODECOMPTEUTULISATEUR.Value = clsReqemailout.CU_CODECOMPTEUTULISATEUR;
            SqlParameter vppParamEM_MESSAGE = new SqlParameter("@EM_MESSAGE", SqlDbType.VarChar, 1000);
            vppParamEM_MESSAGE.Value = clsReqemailout.EM_MESSAGE;
            SqlParameter vppParamEM_EMAIL = new SqlParameter("@EM_EMAIL", SqlDbType.VarChar, 1000);
            vppParamEM_EMAIL.Value = clsReqemailout.EM_EMAIL;
            SqlParameter vppParamEM_STATUT = new SqlParameter("@EM_STATUT", SqlDbType.VarChar, 1);
            vppParamEM_STATUT.Value = clsReqemailout.EM_STATUT;
            SqlParameter vppParamEM_DATESAISIE = new SqlParameter("@EM_DATESAISIE", SqlDbType.DateTime);
            vppParamEM_DATESAISIE.Value = clsReqemailout.EM_DATESAISIE;
            SqlParameter vppParamEM_FICHERJOINT = new SqlParameter("@EM_FICHERJOINT", SqlDbType.VarChar, 1000);
            vppParamEM_FICHERJOINT.Value = clsReqemailout.EM_FICHERJOINT;
            if (clsReqemailout.EM_FICHERJOINT == "") vppParamEM_FICHERJOINT.Value = DBNull.Value;
            SqlParameter vppParamEM_OBJET = new SqlParameter("@EM_OBJET", SqlDbType.VarChar, 1000);
            vppParamEM_OBJET.Value = clsReqemailout.EM_OBJET;
            if (clsReqemailout.EM_OBJET == "") vppParamEM_OBJET.Value = DBNull.Value;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQEMAILOUT  @AG_CODEAGENCE, @AG_CODEAGENCE, @EM_DATEPIECE, @EM_NUMSEQUENCE, @PW_CODEWEBTYPEOPERATION, @CU_CODECOMPTEUTULISATEUR, @EM_MESSAGE, @EM_EMAIL, @EM_STATUT, @EM_DATESAISIE, @EM_FICHERJOINT, @EM_OBJET, @CODECRYPTAGE, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEM_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamEM_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamPW_CODEWEBTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
            vppSqlCmd.Parameters.Add(vppParamEM_MESSAGE);
            vppSqlCmd.Parameters.Add(vppParamEM_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamEM_STATUT);
            vppSqlCmd.Parameters.Add(vppParamEM_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamEM_FICHERJOINT);
            vppSqlCmd.Parameters.Add(vppParamEM_OBJET);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AG_CODEAGENCE, EM_DATEPIECE, EM_NUMSEQUENCE, PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqemailout>clsReqemailout</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsReqemailout clsReqemailout, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsReqemailout.AG_CODEAGENCE;
            SqlParameter vppParamEM_DATEPIECE = new SqlParameter("@EM_DATEPIECE", SqlDbType.DateTime);
            vppParamEM_DATEPIECE.Value = clsReqemailout.EM_DATEPIECE;
            SqlParameter vppParamEM_NUMSEQUENCE = new SqlParameter("@EM_NUMSEQUENCE", SqlDbType.Int);
            vppParamEM_NUMSEQUENCE.Value = clsReqemailout.EM_NUMSEQUENCE;
            SqlParameter vppParamPW_CODEWEBTYPEOPERATION = new SqlParameter("@PW_CODEWEBTYPEOPERATION", SqlDbType.VarChar, 4);
            vppParamPW_CODEWEBTYPEOPERATION.Value = clsReqemailout.PW_CODEWEBTYPEOPERATION;
            SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
            vppParamCU_CODECOMPTEUTULISATEUR.Value = clsReqemailout.CU_CODECOMPTEUTULISATEUR;
            SqlParameter vppParamEM_MESSAGE = new SqlParameter("@EM_MESSAGE", SqlDbType.VarChar, 1000);
            vppParamEM_MESSAGE.Value = clsReqemailout.EM_MESSAGE;
            SqlParameter vppParamEM_EMAIL = new SqlParameter("@EM_EMAIL", SqlDbType.VarChar, 1000);
            vppParamEM_EMAIL.Value = clsReqemailout.EM_EMAIL;
            SqlParameter vppParamEM_STATUT = new SqlParameter("@EM_STATUT", SqlDbType.VarChar, 1);
            vppParamEM_STATUT.Value = clsReqemailout.EM_STATUT;
            SqlParameter vppParamEM_DATESAISIE = new SqlParameter("@EM_DATESAISIE", SqlDbType.DateTime);
            vppParamEM_DATESAISIE.Value = clsReqemailout.EM_DATESAISIE;
            SqlParameter vppParamEM_FICHERJOINT = new SqlParameter("@EM_FICHERJOINT", SqlDbType.VarChar, 1000);
            vppParamEM_FICHERJOINT.Value = clsReqemailout.EM_FICHERJOINT;
            if (clsReqemailout.EM_FICHERJOINT == "") vppParamEM_FICHERJOINT.Value = DBNull.Value;
            SqlParameter vppParamEM_OBJET = new SqlParameter("@EM_OBJET", SqlDbType.VarChar, 1000);
            vppParamEM_OBJET.Value = clsReqemailout.EM_OBJET;
            if (clsReqemailout.EM_OBJET == "") vppParamEM_OBJET.Value = DBNull.Value;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQEMAILOUT  @AG_CODEAGENCE, @AG_CODEAGENCE, @EM_DATEPIECE, @EM_NUMSEQUENCE, @PW_CODEWEBTYPEOPERATION, @CU_CODECOMPTEUTULISATEUR, @EM_MESSAGE, @EM_EMAIL, @EM_STATUT, @EM_DATESAISIE, @EM_FICHERJOINT, @EM_OBJET, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEM_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamEM_NUMSEQUENCE);
            vppSqlCmd.Parameters.Add(vppParamPW_CODEWEBTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
            vppSqlCmd.Parameters.Add(vppParamEM_MESSAGE);
            vppSqlCmd.Parameters.Add(vppParamEM_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamEM_STATUT);
            vppSqlCmd.Parameters.Add(vppParamEM_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamEM_FICHERJOINT);
            vppSqlCmd.Parameters.Add(vppParamEM_OBJET);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AG_CODEAGENCE, EM_DATEPIECE, EM_NUMSEQUENCE, PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQEMAILOUT  @AG_CODEAGENCE, @AG_CODEAGENCE, @EM_DATEPIECE, @EM_NUMSEQUENCE, @PW_CODEWEBTYPEOPERATION, '' , '' , '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AG_CODEAGENCE, EM_DATEPIECE, EM_NUMSEQUENCE, PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsReqemailout </returns>
        ///<author>Home Technology</author>
        public List<clsReqemailout> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, AG_CODEAGENCE, EM_DATEPIECE, EM_NUMSEQUENCE, PW_CODEWEBTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, EM_MESSAGE, EM_EMAIL, EM_STATUT, EM_DATESAISIE, EM_FICHERJOINT, EM_OBJET FROM dbo.FT_REQEMAILOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsReqemailout> clsReqemailouts = new List<clsReqemailout>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsReqemailout clsReqemailout = new clsReqemailout();
                    clsReqemailout.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsReqemailout.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsReqemailout.EM_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["EM_DATEPIECE"].ToString());
                    clsReqemailout.EM_NUMSEQUENCE = int.Parse(clsDonnee.vogDataReader["EM_NUMSEQUENCE"].ToString());
                    clsReqemailout.PW_CODEWEBTYPEOPERATION = clsDonnee.vogDataReader["PW_CODEWEBTYPEOPERATION"].ToString();
                    clsReqemailout.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
                    clsReqemailout.EM_MESSAGE = clsDonnee.vogDataReader["EM_MESSAGE"].ToString();
                    clsReqemailout.EM_EMAIL = clsDonnee.vogDataReader["EM_EMAIL"].ToString();
                    clsReqemailout.EM_STATUT = clsDonnee.vogDataReader["EM_STATUT"].ToString();
                    clsReqemailout.EM_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["EM_DATESAISIE"].ToString());
                    clsReqemailout.EM_FICHERJOINT = clsDonnee.vogDataReader["EM_FICHERJOINT"].ToString();
                    clsReqemailout.EM_OBJET = clsDonnee.vogDataReader["EM_OBJET"].ToString();
                    clsReqemailouts.Add(clsReqemailout);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsReqemailouts;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AG_CODEAGENCE, EM_DATEPIECE, EM_NUMSEQUENCE, PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsReqemailout </returns>
        ///<author>Home Technology</author>
        public List<clsReqemailout> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsReqemailout> clsReqemailouts = new List<clsReqemailout>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, AG_CODEAGENCE, EM_DATEPIECE, EM_NUMSEQUENCE, PW_CODEWEBTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, EM_MESSAGE, EM_EMAIL, EM_STATUT, EM_DATESAISIE, EM_FICHERJOINT, EM_OBJET FROM dbo.FT_REQEMAILOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsReqemailout clsReqemailout = new clsReqemailout();
                    clsReqemailout.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsReqemailout.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsReqemailout.EM_DATEPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EM_DATEPIECE"].ToString());
                    clsReqemailout.EM_NUMSEQUENCE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EM_NUMSEQUENCE"].ToString());
                    clsReqemailout.PW_CODEWEBTYPEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["PW_CODEWEBTYPEOPERATION"].ToString();
                    clsReqemailout.CU_CODECOMPTEUTULISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CU_CODECOMPTEUTULISATEUR"].ToString();
                    clsReqemailout.EM_MESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["EM_MESSAGE"].ToString();
                    clsReqemailout.EM_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["EM_EMAIL"].ToString();
                    clsReqemailout.EM_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["EM_STATUT"].ToString();
                    clsReqemailout.EM_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EM_DATESAISIE"].ToString());
                    clsReqemailout.EM_FICHERJOINT = Dataset.Tables["TABLE"].Rows[Idx]["EM_FICHERJOINT"].ToString();
                    clsReqemailout.EM_OBJET = Dataset.Tables["TABLE"].Rows[Idx]["EM_OBJET"].ToString();
                    clsReqemailouts.Add(clsReqemailout);
                }
                Dataset.Dispose();
            }
            return clsReqemailouts;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AG_CODEAGENCE, EM_DATEPIECE, EM_NUMSEQUENCE, PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_REQEMAILOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, AG_CODEAGENCE, EM_DATEPIECE, EM_NUMSEQUENCE, PW_CODEWEBTYPEOPERATION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE , CU_CODECOMPTEUTULISATEUR FROM dbo.FT_REQEMAILOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, AG_CODEAGENCE, EM_DATEPIECE, EM_NUMSEQUENCE, PW_CODEWEBTYPEOPERATION)</summary>
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AG_CODEAGENCE=@AG_CODEAGENCE AND EM_DATEPIECE=@EM_DATEPIECE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@AG_CODEAGENCE", "@EM_DATEPIECE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AG_CODEAGENCE=@AG_CODEAGENCE AND EM_DATEPIECE=@EM_DATEPIECE AND EM_NUMSEQUENCE=@EM_NUMSEQUENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@AG_CODEAGENCE", "@EM_DATEPIECE", "@EM_NUMSEQUENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
                case 5:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND AG_CODEAGENCE=@AG_CODEAGENCE AND EM_DATEPIECE=@EM_DATEPIECE AND EM_NUMSEQUENCE=@EM_NUMSEQUENCE AND PW_CODEWEBTYPEOPERATION=@PW_CODEWEBTYPEOPERATION";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@AG_CODEAGENCE", "@EM_DATEPIECE", "@EM_NUMSEQUENCE", "@PW_CODEWEBTYPEOPERATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;
            }
        }
    }
}
