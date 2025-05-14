using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using MgRequeteClients.Tools.Classes;
using MgRequeteClients.DAL.Interfaces;
using MgRequeteClients.BOJ.BusinessObjects;

namespace MgRequeteClients.DAL.Classes
{
	public class clsReqsmsoutWSDAL: ITableDAL<clsReqsmsout>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_REQSMSOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_REQSMSOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_REQSMSOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqsmsout comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqsmsout pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CU_CODECOMPTEUTULISATEUR  , TE_CODESMSTYPEOPERATION  , SM_MESSAGE  , SM_TELEPHONE  , SM_STATUT  , SM_DATEEMISSIONSMS  , SM_RAISONNONENVOISMS  , SM_DATESAISIE  FROM dbo.FT_REQSMSOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqsmsout clsReqsmsout = new clsReqsmsout();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqsmsout.CU_CODECOMPTEUTULISATEUR = decimal.Parse(clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString());
					clsReqsmsout.TE_CODESMSTYPEOPERATION = clsDonnee.vogDataReader["TE_CODESMSTYPEOPERATION"].ToString();
					clsReqsmsout.SM_MESSAGE = clsDonnee.vogDataReader["SM_MESSAGE"].ToString();
					clsReqsmsout.SM_TELEPHONE = clsDonnee.vogDataReader["SM_TELEPHONE"].ToString();
					clsReqsmsout.SM_STATUT = clsDonnee.vogDataReader["SM_STATUT"].ToString();
					clsReqsmsout.SM_DATEEMISSIONSMS = DateTime.Parse(clsDonnee.vogDataReader["SM_DATEEMISSIONSMS"].ToString());
					clsReqsmsout.SM_RAISONNONENVOISMS = clsDonnee.vogDataReader["SM_RAISONNONENVOISMS"].ToString();
					clsReqsmsout.SM_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["SM_DATESAISIE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqsmsout;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqsmsout>clsReqsmsout</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsReqsmsout clsReqsmsout)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsReqsmsout.AG_CODEAGENCE ;
			SqlParameter vppParamSM_DATEPIECE = new SqlParameter("@SM_DATEPIECE", SqlDbType.DateTime);
			vppParamSM_DATEPIECE.Value  = clsReqsmsout.SM_DATEPIECE ;
			SqlParameter vppParamSM_NUMSEQUENCE = new SqlParameter("@SM_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamSM_NUMSEQUENCE.Value  = clsReqsmsout.SM_NUMSEQUENCE ;
			SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.Decimal, 4);
			vppParamCU_CODECOMPTEUTULISATEUR.Value  = clsReqsmsout.CU_CODECOMPTEUTULISATEUR ;
			SqlParameter vppParamTE_CODESMSTYPEOPERATION = new SqlParameter("@TE_CODESMSTYPEOPERATION", SqlDbType.VarChar, 4);
			vppParamTE_CODESMSTYPEOPERATION.Value  = clsReqsmsout.TE_CODESMSTYPEOPERATION ;
			SqlParameter vppParamSM_MESSAGE = new SqlParameter("@SM_MESSAGE", SqlDbType.VarChar, 1000);
			vppParamSM_MESSAGE.Value  = clsReqsmsout.SM_MESSAGE ;
			SqlParameter vppParamSM_TELEPHONE = new SqlParameter("@SM_TELEPHONE", SqlDbType.VarChar, 1000);
			vppParamSM_TELEPHONE.Value  = clsReqsmsout.SM_TELEPHONE ;
			SqlParameter vppParamSM_STATUT = new SqlParameter("@SM_STATUT", SqlDbType.VarChar, 1);
			vppParamSM_STATUT.Value  = clsReqsmsout.SM_STATUT ;
			SqlParameter vppParamSM_DATEEMISSIONSMS = new SqlParameter("@SM_DATEEMISSIONSMS", SqlDbType.DateTime);
			vppParamSM_DATEEMISSIONSMS.Value  = clsReqsmsout.SM_DATEEMISSIONSMS ;
			SqlParameter vppParamSM_RAISONNONENVOISMS = new SqlParameter("@SM_RAISONNONENVOISMS", SqlDbType.VarChar, 1000);
			vppParamSM_RAISONNONENVOISMS.Value  = clsReqsmsout.SM_RAISONNONENVOISMS ;
			if(clsReqsmsout.SM_RAISONNONENVOISMS== ""  ) vppParamSM_RAISONNONENVOISMS.Value  = DBNull.Value;
			SqlParameter vppParamSM_DATESAISIE = new SqlParameter("@SM_DATESAISIE", SqlDbType.DateTime);
			vppParamSM_DATESAISIE.Value  = clsReqsmsout.SM_DATESAISIE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQSMSOUT  @AG_CODEAGENCE, @SM_DATEPIECE, @SM_NUMSEQUENCE, @CU_CODECOMPTEUTULISATEUR, @TE_CODESMSTYPEOPERATION, @SM_MESSAGE, @SM_TELEPHONE, @SM_STATUT, @SM_DATEEMISSIONSMS, @SM_RAISONNONENVOISMS, @SM_DATESAISIE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamSM_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamSM_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamTE_CODESMSTYPEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamSM_MESSAGE);
			vppSqlCmd.Parameters.Add(vppParamSM_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamSM_STATUT);
			vppSqlCmd.Parameters.Add(vppParamSM_DATEEMISSIONSMS);
			vppSqlCmd.Parameters.Add(vppParamSM_RAISONNONENVOISMS);
			vppSqlCmd.Parameters.Add(vppParamSM_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqsmsout>clsReqsmsout</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsReqsmsout clsReqsmsout,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsReqsmsout.AG_CODEAGENCE ;
			SqlParameter vppParamSM_DATEPIECE = new SqlParameter("@SM_DATEPIECE", SqlDbType.DateTime);
			vppParamSM_DATEPIECE.Value  = clsReqsmsout.SM_DATEPIECE ;
			SqlParameter vppParamSM_NUMSEQUENCE = new SqlParameter("@SM_NUMSEQUENCE", SqlDbType.VarChar, 25);
			vppParamSM_NUMSEQUENCE.Value  = clsReqsmsout.SM_NUMSEQUENCE ;
			SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.Decimal, 4);
			vppParamCU_CODECOMPTEUTULISATEUR.Value  = clsReqsmsout.CU_CODECOMPTEUTULISATEUR ;
			SqlParameter vppParamTE_CODESMSTYPEOPERATION = new SqlParameter("@TE_CODESMSTYPEOPERATION", SqlDbType.VarChar, 4);
			vppParamTE_CODESMSTYPEOPERATION.Value  = clsReqsmsout.TE_CODESMSTYPEOPERATION ;
			SqlParameter vppParamSM_MESSAGE = new SqlParameter("@SM_MESSAGE", SqlDbType.VarChar, 1000);
			vppParamSM_MESSAGE.Value  = clsReqsmsout.SM_MESSAGE ;
			SqlParameter vppParamSM_TELEPHONE = new SqlParameter("@SM_TELEPHONE", SqlDbType.VarChar, 1000);
			vppParamSM_TELEPHONE.Value  = clsReqsmsout.SM_TELEPHONE ;
			SqlParameter vppParamSM_STATUT = new SqlParameter("@SM_STATUT", SqlDbType.VarChar, 1);
			vppParamSM_STATUT.Value  = clsReqsmsout.SM_STATUT ;
			SqlParameter vppParamSM_DATEEMISSIONSMS = new SqlParameter("@SM_DATEEMISSIONSMS", SqlDbType.DateTime);
			vppParamSM_DATEEMISSIONSMS.Value  = clsReqsmsout.SM_DATEEMISSIONSMS ;
			SqlParameter vppParamSM_RAISONNONENVOISMS = new SqlParameter("@SM_RAISONNONENVOISMS", SqlDbType.VarChar, 1000);
			vppParamSM_RAISONNONENVOISMS.Value  = clsReqsmsout.SM_RAISONNONENVOISMS ;
			if(clsReqsmsout.SM_RAISONNONENVOISMS== ""  ) vppParamSM_RAISONNONENVOISMS.Value  = DBNull.Value;
			SqlParameter vppParamSM_DATESAISIE = new SqlParameter("@SM_DATESAISIE", SqlDbType.DateTime);
			vppParamSM_DATESAISIE.Value  = clsReqsmsout.SM_DATESAISIE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQSMSOUT  @AG_CODEAGENCE, @SM_DATEPIECE, @SM_NUMSEQUENCE, @CU_CODECOMPTEUTULISATEUR, @TE_CODESMSTYPEOPERATION, @SM_MESSAGE, @SM_TELEPHONE, @SM_STATUT, @SM_DATEEMISSIONSMS, @SM_RAISONNONENVOISMS, @SM_DATESAISIE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamSM_DATEPIECE);
			vppSqlCmd.Parameters.Add(vppParamSM_NUMSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamTE_CODESMSTYPEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamSM_MESSAGE);
			vppSqlCmd.Parameters.Add(vppParamSM_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamSM_STATUT);
			vppSqlCmd.Parameters.Add(vppParamSM_DATEEMISSIONSMS);
			vppSqlCmd.Parameters.Add(vppParamSM_RAISONNONENVOISMS);
			vppSqlCmd.Parameters.Add(vppParamSM_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQSMSOUT  @AG_CODEAGENCE, @SM_DATEPIECE, @SM_NUMSEQUENCE, @CU_CODECOMPTEUTULISATEUR, '' , '' , '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqsmsout </returns>
		///<author>Home Technology</author>
		public List<clsReqsmsout> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR, TE_CODESMSTYPEOPERATION, SM_MESSAGE, SM_TELEPHONE, SM_STATUT, SM_DATEEMISSIONSMS, SM_RAISONNONENVOISMS, SM_DATESAISIE FROM dbo.FT_REQSMSOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqsmsout> clsReqsmsouts = new List<clsReqsmsout>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqsmsout clsReqsmsout = new clsReqsmsout();
					clsReqsmsout.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsReqsmsout.SM_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["SM_DATEPIECE"].ToString());
					clsReqsmsout.SM_NUMSEQUENCE = clsDonnee.vogDataReader["SM_NUMSEQUENCE"].ToString();
					clsReqsmsout.CU_CODECOMPTEUTULISATEUR = decimal.Parse(clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString());
					clsReqsmsout.TE_CODESMSTYPEOPERATION = clsDonnee.vogDataReader["TE_CODESMSTYPEOPERATION"].ToString();
					clsReqsmsout.SM_MESSAGE = clsDonnee.vogDataReader["SM_MESSAGE"].ToString();
					clsReqsmsout.SM_TELEPHONE = clsDonnee.vogDataReader["SM_TELEPHONE"].ToString();
					clsReqsmsout.SM_STATUT = clsDonnee.vogDataReader["SM_STATUT"].ToString();
					clsReqsmsout.SM_DATEEMISSIONSMS = DateTime.Parse(clsDonnee.vogDataReader["SM_DATEEMISSIONSMS"].ToString());
					clsReqsmsout.SM_RAISONNONENVOISMS = clsDonnee.vogDataReader["SM_RAISONNONENVOISMS"].ToString();
					clsReqsmsout.SM_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["SM_DATESAISIE"].ToString());
					clsReqsmsouts.Add(clsReqsmsout);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqsmsouts;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqsmsout </returns>
		///<author>Home Technology</author>
		public List<clsReqsmsout> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqsmsout> clsReqsmsouts = new List<clsReqsmsout>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR, TE_CODESMSTYPEOPERATION, SM_MESSAGE, SM_TELEPHONE, SM_STATUT, SM_DATEEMISSIONSMS, SM_RAISONNONENVOISMS, SM_DATESAISIE FROM dbo.FT_REQSMSOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqsmsout clsReqsmsout = new clsReqsmsout();
					clsReqsmsout.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsReqsmsout.SM_DATEPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SM_DATEPIECE"].ToString());
					clsReqsmsout.SM_NUMSEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["SM_NUMSEQUENCE"].ToString();
					clsReqsmsout.CU_CODECOMPTEUTULISATEUR = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CU_CODECOMPTEUTULISATEUR"].ToString());
					clsReqsmsout.TE_CODESMSTYPEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["TE_CODESMSTYPEOPERATION"].ToString();
					clsReqsmsout.SM_MESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["SM_MESSAGE"].ToString();
					clsReqsmsout.SM_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["SM_TELEPHONE"].ToString();
					clsReqsmsout.SM_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["SM_STATUT"].ToString();
					clsReqsmsout.SM_DATEEMISSIONSMS = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SM_DATEEMISSIONSMS"].ToString());
					clsReqsmsout.SM_RAISONNONENVOISMS = Dataset.Tables["TABLE"].Rows[Idx]["SM_RAISONNONENVOISMS"].ToString();
					clsReqsmsout.SM_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["SM_DATESAISIE"].ToString());
					clsReqsmsouts.Add(clsReqsmsout);
				}
				Dataset.Dispose();
			}
		return clsReqsmsouts;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQSMSOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        public DataSet pvgChargerDansDataSetListSMS(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_REQSMSOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgChargerDansDataSetListSMSADMIN(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereADMIN(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_REQSMSOUT(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);

        }

        //laaa
        public void pvgLectureNotification(clsDonnee clsDonnee, params string[] vppCritere) 
        {
            //Préparation des paramètres
            SqlParameter vppParamSM_STATUT_LECTURE = new SqlParameter("@SM_STATUT_LECTURE", SqlDbType.VarChar, 150);
            vppParamSM_STATUT_LECTURE.Value = "O";

            //Préparation de la commande
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "UPDATE REQSMSOUT SET " +
                           "SM_STATUT_LECTURE = @SM_STATUT_LECTURE " + vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamSM_STATUT_LECTURE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , TE_CODESMSTYPEOPERATION FROM dbo.FT_REQSMSOUT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees via la procedure stockee PE_ACTIVITE </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsApisms">clsApisms</param>
        ///<returns>Une collection de clsApisms valeur du resultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<clsReqsmsout> pvgMobileSms(clsDonnee clsDonnee, clsParams clsParams)
        {
            List<clsReqsmsout> clsSmss = new List<clsReqsmsout>();
            DataSet Dataset = new DataSet();
            vapNomParametre = new string[] { "@LG_CODELANGUE", "@AG_CODEAGENCE", "@CL_TELEPHONE", "@SM_RAISONNONENVOISMS", "@SL_MESSAGECLIENT", "@SM_DATEPIECE", "@LO_LOGICIEL", "@CU_CODECOMPTEUTULISATEUR", "@TE_CODESMSTYPEOPERATION", "@SM_NUMSEQUENCE", "@SM_DATEEMISSIONSMS", "@SM_STATUT", "@TYPEOPERATION", "@SL_LIBELLE2", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { clsParams.LG_CODELANGUE, clsParams.CodeAgence, clsParams.RECIPIENTPHONE, clsParams.SM_RAISONNONENVOISMS, clsParams.SMSTEXT, clsParams.SM_DATEPIECE, clsParams.LO_LOGICIEL, clsParams.CU_CODECOMPTEUTULISATEUR, clsParams.TE_CODESMSTYPEOPERATION, clsParams.SM_NUMSEQUENCE, clsParams.SM_DATEEMISSIONSMS, clsParams.SM_STATUT, clsParams.TYPEOPERATION, clsParams.SL_LIBELLE2, clsDonnee.vogCleCryptage };

            this.vapRequete = " EXEC  [dbo].[PS_APISMS] @LG_CODELANGUE,@AG_CODEAGENCE,@CL_TELEPHONE,@SM_RAISONNONENVOISMS,@SL_MESSAGECLIENT,@SM_DATEPIECE,@LO_LOGICIEL,@CU_CODECOMPTEUTULISATEUR,@TE_CODESMSTYPEOPERATION,@SM_NUMSEQUENCE,@SM_DATEEMISSIONSMS,@SM_STATUT,@TYPEOPERATION,@SL_LIBELLE2,@CODECRYPTAGE";

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);

            if (double.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                foreach (DataRow row in Dataset.Tables[0].Rows)
                {
                    clsReqsmsout clsSms = new clsReqsmsout();
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
                clsReqsmsout clsSms = new clsReqsmsout();
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

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereADMIN(clsDonnee clsDonnee, params string[] vppCritere)
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CU_CODECOMPTEUTULISATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND TE_CODESMSTYPEOPERATION=@TE_CODESMSTYPEOPERATION";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CU_CODECOMPTEUTULISATEUR", "@TE_CODESMSTYPEOPERATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    // this.vapCritere = "WHERE SM_DATEPIECE=@SM_DATEPIECE AND TE_CODESMSTYPEOPERATION=@TE_CODESMSTYPEOPERATION AND SM_STATUT=@SM_STATUT AND SM_STATUT_LECTURE=@SM_STATUT_LECTURE";
                    // vapNomParametre = new string[] { "@CODECRYPTAGE", "@SM_DATEPIECE",  "@TE_CODESMSTYPEOPERATION", "@SM_STATUT", "@SM_STATUT_LECTURE" };
                    this.vapCritere = "WHERE SM_DATEPIECE=@SM_DATEPIECE  AND SM_STATUT=@SM_STATUT AND SM_STATUT_LECTURE=@SM_STATUT_LECTURE and (TE_CODESMSTYPEOPERATION='0010' OR TE_CODESMSTYPEOPERATION='0011' OR TE_CODESMSTYPEOPERATION='0012')";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@SM_DATEPIECE", "@SM_STATUT", "@SM_STATUT_LECTURE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[3], 'N' };
                    break;
            }
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CU_CODECOMPTEUTULISATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND TE_CODESMSTYPEOPERATION=@TE_CODESMSTYPEOPERATION";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CU_CODECOMPTEUTULISATEUR", "@TE_CODESMSTYPEOPERATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    // this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND TE_CODESMSTYPEOPERATION=@TE_CODESMSTYPEOPERATION AND SM_STATUT=@SM_STATUT AND SM_STATUT_LECTURE=@SM_STATUT_LECTURE";
                    //  vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CU_CODECOMPTEUTULISATEUR", "@TE_CODESMSTYPEOPERATION", "@SM_STATUT", "@SM_STATUT_LECTURE" };
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND SM_STATUT=@SM_STATUT AND SM_STATUT_LECTURE=@SM_STATUT_LECTURE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CU_CODECOMPTEUTULISATEUR", "@SM_STATUT", "@SM_STATUT_LECTURE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[3], 'N' };
                    break;
            }
        }
        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, CU_CODECOMPTEUTULISATEUR)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
				vapNomParametre = new string[]{"@CODECRYPTAGE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage};
				break;
				case 1 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SM_DATEPIECE=@SM_DATEPIECE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@SM_DATEPIECE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SM_DATEPIECE=@SM_DATEPIECE AND SM_NUMSEQUENCE=@SM_NUMSEQUENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@SM_DATEPIECE","@SM_NUMSEQUENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND SM_DATEPIECE=@SM_DATEPIECE AND SM_NUMSEQUENCE=@SM_NUMSEQUENCE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@SM_DATEPIECE","@SM_NUMSEQUENCE","@CU_CODECOMPTEUTULISATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
