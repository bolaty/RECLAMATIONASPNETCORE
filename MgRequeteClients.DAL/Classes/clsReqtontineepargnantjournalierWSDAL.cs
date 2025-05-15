using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
//using System.Data.SqlClient;
using MgRequeteClients.Tools.Classes;
using MgRequeteClients.DAL.Interfaces;
using MgRequeteClients.BOJ.BusinessObjects;
using Microsoft.Data.SqlClient;

namespace MgRequeteClients.DAL.Classes
{
	public class clsReqtontineepargnantjournalierWSDAL: ITableDAL<clsReqtontineepargnantjournalier>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(EJ_IDEPARGNANTJOURNALIER) AS EJ_IDEPARGNANTJOURNALIER  FROM dbo.FT_REQTONTINEEPARGNANTJOURNALIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(EJ_IDEPARGNANTJOURNALIER) AS EJ_IDEPARGNANTJOURNALIER  FROM dbo.FT_REQTONTINEEPARGNANTJOURNALIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(EJ_IDEPARGNANTJOURNALIER) AS EJ_IDEPARGNANTJOURNALIER  FROM dbo.REQTONTINEEPARGNANTJOURNALIER " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqtontineepargnantjournalier comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqtontineepargnantjournalier pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EJ_CODEEPARGNANTJOURNALIERZENITH  , AG_CODEAGENCE  , PV_CODEPOINTVENTE  , CU_CODECOMPTEUTULISATEUR  , EJ_DATESAISIE  FROM dbo.FT_REQTONTINEEPARGNANTJOURNALIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqtontineepargnantjournalier clsReqtontineepargnantjournalier = new clsReqtontineepargnantjournalier();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqtontineepargnantjournalier.EJ_CODEEPARGNANTJOURNALIERZENITH = clsDonnee.vogDataReader["EJ_CODEEPARGNANTJOURNALIERZENITH"].ToString();
					clsReqtontineepargnantjournalier.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsReqtontineepargnantjournalier.PV_CODEPOINTVENTE = clsDonnee.vogDataReader["PV_CODEPOINTVENTE"].ToString();
					clsReqtontineepargnantjournalier.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsReqtontineepargnantjournalier.EJ_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["EJ_DATESAISIE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqtontineepargnantjournalier;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqtontineepargnantjournalier>clsReqtontineepargnantjournalier</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsReqtontineepargnantjournalier clsReqtontineepargnantjournalier)
		{
			//Préparation des paramètres
			SqlParameter vppParamEJ_IDEPARGNANTJOURNALIER = new SqlParameter("@EJ_IDEPARGNANTJOURNALIER", SqlDbType.VarChar, 50);
			vppParamEJ_IDEPARGNANTJOURNALIER.Value  = clsReqtontineepargnantjournalier.EJ_IDEPARGNANTJOURNALIER ;
			SqlParameter vppParamEJ_CODEEPARGNANTJOURNALIERZENITH = new SqlParameter("@EJ_CODEEPARGNANTJOURNALIERZENITH", SqlDbType.VarChar, 1000);
			vppParamEJ_CODEEPARGNANTJOURNALIERZENITH.Value  = clsReqtontineepargnantjournalier.EJ_CODEEPARGNANTJOURNALIERZENITH ;
			if(clsReqtontineepargnantjournalier.EJ_CODEEPARGNANTJOURNALIERZENITH== ""  ) vppParamEJ_CODEEPARGNANTJOURNALIERZENITH.Value  = DBNull.Value;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsReqtontineepargnantjournalier.AG_CODEAGENCE ;
			SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 25);
			vppParamPV_CODEPOINTVENTE.Value  = clsReqtontineepargnantjournalier.PV_CODEPOINTVENTE ;
			SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
			vppParamCU_CODECOMPTEUTULISATEUR.Value  = clsReqtontineepargnantjournalier.CU_CODECOMPTEUTULISATEUR ;
			SqlParameter vppParamEJ_DATESAISIE = new SqlParameter("@EJ_DATESAISIE", SqlDbType.DateTime);
			vppParamEJ_DATESAISIE.Value  = clsReqtontineepargnantjournalier.EJ_DATESAISIE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsReqtontineepargnantjournalier.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQTONTINEEPARGNANTJOURNALIER  @EJ_IDEPARGNANTJOURNALIER, @EJ_CODEEPARGNANTJOURNALIERZENITH, @AG_CODEAGENCE, @PV_CODEPOINTVENTE, @CU_CODECOMPTEUTULISATEUR, @EJ_DATESAISIE, @CODECRYPTAGE1, @TYPEOPERATION";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEJ_IDEPARGNANTJOURNALIER);
			vppSqlCmd.Parameters.Add(vppParamEJ_CODEEPARGNANTJOURNALIERZENITH);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamEJ_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqtontineepargnantjournalier>clsReqtontineepargnantjournalier</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsReqtontineepargnantjournalier clsReqtontineepargnantjournalier,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamEJ_IDEPARGNANTJOURNALIER = new SqlParameter("@EJ_IDEPARGNANTJOURNALIER", SqlDbType.VarChar, 50);
			vppParamEJ_IDEPARGNANTJOURNALIER.Value  = clsReqtontineepargnantjournalier.EJ_IDEPARGNANTJOURNALIER ;
			SqlParameter vppParamEJ_CODEEPARGNANTJOURNALIERZENITH = new SqlParameter("@EJ_CODEEPARGNANTJOURNALIERZENITH", SqlDbType.VarChar, 1000);
			vppParamEJ_CODEEPARGNANTJOURNALIERZENITH.Value  = clsReqtontineepargnantjournalier.EJ_CODEEPARGNANTJOURNALIERZENITH ;
			if(clsReqtontineepargnantjournalier.EJ_CODEEPARGNANTJOURNALIERZENITH== ""  ) vppParamEJ_CODEEPARGNANTJOURNALIERZENITH.Value  = DBNull.Value;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsReqtontineepargnantjournalier.AG_CODEAGENCE ;
			SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 25);
			vppParamPV_CODEPOINTVENTE.Value  = clsReqtontineepargnantjournalier.PV_CODEPOINTVENTE ;
			SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
			vppParamCU_CODECOMPTEUTULISATEUR.Value  = clsReqtontineepargnantjournalier.CU_CODECOMPTEUTULISATEUR ;
			SqlParameter vppParamEJ_DATESAISIE = new SqlParameter("@EJ_DATESAISIE", SqlDbType.DateTime);
			vppParamEJ_DATESAISIE.Value  = clsReqtontineepargnantjournalier.EJ_DATESAISIE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQTONTINEEPARGNANTJOURNALIER  @EJ_IDEPARGNANTJOURNALIER, @EJ_CODEEPARGNANTJOURNALIERZENITH, @AG_CODEAGENCE, @PV_CODEPOINTVENTE, @CU_CODECOMPTEUTULISATEUR, @EJ_DATESAISIE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamEJ_IDEPARGNANTJOURNALIER);
			vppSqlCmd.Parameters.Add(vppParamEJ_CODEEPARGNANTJOURNALIERZENITH);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamEJ_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQTONTINEEPARGNANTJOURNALIER  @EJ_IDEPARGNANTJOURNALIER, '' , '' , '' , @CU_CODECOMPTEUTULISATEUR, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqtontineepargnantjournalier </returns>
		///<author>Home Technology</author>
		public List<clsReqtontineepargnantjournalier> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  EJ_IDEPARGNANTJOURNALIER, EJ_CODEEPARGNANTJOURNALIERZENITH, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR, EJ_DATESAISIE FROM dbo.FT_REQTONTINEEPARGNANTJOURNALIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqtontineepargnantjournalier> clsReqtontineepargnantjournaliers = new List<clsReqtontineepargnantjournalier>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqtontineepargnantjournalier clsReqtontineepargnantjournalier = new clsReqtontineepargnantjournalier();
					clsReqtontineepargnantjournalier.EJ_IDEPARGNANTJOURNALIER = clsDonnee.vogDataReader["EJ_IDEPARGNANTJOURNALIER"].ToString();
					clsReqtontineepargnantjournalier.EJ_CODEEPARGNANTJOURNALIERZENITH = clsDonnee.vogDataReader["EJ_CODEEPARGNANTJOURNALIERZENITH"].ToString();
					clsReqtontineepargnantjournalier.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsReqtontineepargnantjournalier.PV_CODEPOINTVENTE = clsDonnee.vogDataReader["PV_CODEPOINTVENTE"].ToString();
					clsReqtontineepargnantjournalier.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsReqtontineepargnantjournalier.EJ_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["EJ_DATESAISIE"].ToString());
					clsReqtontineepargnantjournaliers.Add(clsReqtontineepargnantjournalier);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqtontineepargnantjournaliers;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqtontineepargnantjournalier </returns>
		///<author>Home Technology</author>
		public List<clsReqtontineepargnantjournalier> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqtontineepargnantjournalier> clsReqtontineepargnantjournaliers = new List<clsReqtontineepargnantjournalier>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  EJ_IDEPARGNANTJOURNALIER, EJ_CODEEPARGNANTJOURNALIERZENITH, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR, EJ_DATESAISIE FROM dbo.FT_REQTONTINEEPARGNANTJOURNALIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqtontineepargnantjournalier clsReqtontineepargnantjournalier = new clsReqtontineepargnantjournalier();
					clsReqtontineepargnantjournalier.EJ_IDEPARGNANTJOURNALIER = Dataset.Tables["TABLE"].Rows[Idx]["EJ_IDEPARGNANTJOURNALIER"].ToString();
					clsReqtontineepargnantjournalier.EJ_CODEEPARGNANTJOURNALIERZENITH = Dataset.Tables["TABLE"].Rows[Idx]["EJ_CODEEPARGNANTJOURNALIERZENITH"].ToString();
					clsReqtontineepargnantjournalier.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsReqtontineepargnantjournalier.PV_CODEPOINTVENTE = Dataset.Tables["TABLE"].Rows[Idx]["PV_CODEPOINTVENTE"].ToString();
					clsReqtontineepargnantjournalier.CU_CODECOMPTEUTULISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsReqtontineepargnantjournalier.EJ_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EJ_DATESAISIE"].ToString());
					clsReqtontineepargnantjournaliers.Add(clsReqtontineepargnantjournalier);
				}
				Dataset.Dispose();
			}
		return clsReqtontineepargnantjournaliers;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQTONTINEEPARGNANTJOURNALIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT EJ_IDEPARGNANTJOURNALIER , EJ_CODEEPARGNANTJOURNALIERZENITH FROM dbo.FT_REQTONTINEEPARGNANTJOURNALIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR)</summary>
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
				this.vapCritere ="WHERE EJ_IDEPARGNANTJOURNALIER=@EJ_IDEPARGNANTJOURNALIER";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@EJ_IDEPARGNANTJOURNALIER"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE EJ_IDEPARGNANTJOURNALIER=@EJ_IDEPARGNANTJOURNALIER AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@EJ_IDEPARGNANTJOURNALIER","@CU_CODECOMPTEUTULISATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
