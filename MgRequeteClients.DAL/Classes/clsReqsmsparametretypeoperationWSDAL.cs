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
	public class clsReqsmsparametretypeoperationWSDAL: ITableDAL<clsReqsmsparametretypeoperation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TE_CODESMSTYPEOPERATION) AS TE_CODESMSTYPEOPERATION  FROM dbo.FT_REQSMSPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TE_CODESMSTYPEOPERATION) AS TE_CODESMSTYPEOPERATION  FROM dbo.FT_REQSMSPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TE_CODESMSTYPEOPERATION) AS TE_CODESMSTYPEOPERATION  FROM dbo.FT_REQSMSPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqsmsparametretypeoperation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqsmsparametretypeoperation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TS_CODETYPESCHEMACOMPTABLE  , TE_LIBELLE  , TE_NATUREOPERATION  , TE_ACTIF  FROM dbo.FT_REQSMSPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqsmsparametretypeoperation clsReqsmsparametretypeoperation = new clsReqsmsparametretypeoperation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqsmsparametretypeoperation.TS_CODETYPESCHEMACOMPTABLE = clsDonnee.vogDataReader["TS_CODETYPESCHEMACOMPTABLE"].ToString();
					clsReqsmsparametretypeoperation.TE_LIBELLE = clsDonnee.vogDataReader["TE_LIBELLE"].ToString();
					clsReqsmsparametretypeoperation.TE_NATUREOPERATION = clsDonnee.vogDataReader["TE_NATUREOPERATION"].ToString();
					clsReqsmsparametretypeoperation.TE_ACTIF = clsDonnee.vogDataReader["TE_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqsmsparametretypeoperation;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqsmsparametretypeoperation>clsReqsmsparametretypeoperation</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsReqsmsparametretypeoperation clsReqsmsparametretypeoperation)
		{
			//Préparation des paramètres
			SqlParameter vppParamTE_CODESMSTYPEOPERATION = new SqlParameter("@TE_CODESMSTYPEOPERATION", SqlDbType.VarChar, 4);
			vppParamTE_CODESMSTYPEOPERATION.Value  = clsReqsmsparametretypeoperation.TE_CODESMSTYPEOPERATION ;
			SqlParameter vppParamTS_CODETYPESCHEMACOMPTABLE = new SqlParameter("@TS_CODETYPESCHEMACOMPTABLE", SqlDbType.VarChar, 5);
			vppParamTS_CODETYPESCHEMACOMPTABLE.Value  = clsReqsmsparametretypeoperation.TS_CODETYPESCHEMACOMPTABLE ;
			if(clsReqsmsparametretypeoperation.TS_CODETYPESCHEMACOMPTABLE== ""  ) vppParamTS_CODETYPESCHEMACOMPTABLE.Value  = DBNull.Value;
			SqlParameter vppParamTE_LIBELLE = new SqlParameter("@TE_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTE_LIBELLE.Value  = clsReqsmsparametretypeoperation.TE_LIBELLE ;
			SqlParameter vppParamTE_NATUREOPERATION = new SqlParameter("@TE_NATUREOPERATION", SqlDbType.VarChar, 1);
			vppParamTE_NATUREOPERATION.Value  = clsReqsmsparametretypeoperation.TE_NATUREOPERATION ;
			SqlParameter vppParamTE_ACTIF = new SqlParameter("@TE_ACTIF", SqlDbType.VarChar, 1);
			vppParamTE_ACTIF.Value  = clsReqsmsparametretypeoperation.TE_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQSMSPARAMETRETYPEOPERATION  @TE_CODESMSTYPEOPERATION, @TS_CODETYPESCHEMACOMPTABLE, @TE_LIBELLE, @TE_NATUREOPERATION, @TE_ACTIF, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTE_CODESMSTYPEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamTS_CODETYPESCHEMACOMPTABLE);
			vppSqlCmd.Parameters.Add(vppParamTE_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTE_NATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamTE_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqsmsparametretypeoperation>clsReqsmsparametretypeoperation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsReqsmsparametretypeoperation clsReqsmsparametretypeoperation,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTE_CODESMSTYPEOPERATION = new SqlParameter("@TE_CODESMSTYPEOPERATION", SqlDbType.VarChar, 4);
			vppParamTE_CODESMSTYPEOPERATION.Value  = clsReqsmsparametretypeoperation.TE_CODESMSTYPEOPERATION ;
			SqlParameter vppParamTS_CODETYPESCHEMACOMPTABLE = new SqlParameter("@TS_CODETYPESCHEMACOMPTABLE", SqlDbType.VarChar, 5);
			vppParamTS_CODETYPESCHEMACOMPTABLE.Value  = clsReqsmsparametretypeoperation.TS_CODETYPESCHEMACOMPTABLE ;
			if(clsReqsmsparametretypeoperation.TS_CODETYPESCHEMACOMPTABLE== ""  ) vppParamTS_CODETYPESCHEMACOMPTABLE.Value  = DBNull.Value;
			SqlParameter vppParamTE_LIBELLE = new SqlParameter("@TE_LIBELLE", SqlDbType.VarChar, 150);
			vppParamTE_LIBELLE.Value  = clsReqsmsparametretypeoperation.TE_LIBELLE ;
			SqlParameter vppParamTE_NATUREOPERATION = new SqlParameter("@TE_NATUREOPERATION", SqlDbType.VarChar, 1);
			vppParamTE_NATUREOPERATION.Value  = clsReqsmsparametretypeoperation.TE_NATUREOPERATION ;
			SqlParameter vppParamTE_ACTIF = new SqlParameter("@TE_ACTIF", SqlDbType.VarChar, 1);
			vppParamTE_ACTIF.Value  = clsReqsmsparametretypeoperation.TE_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQSMSPARAMETRETYPEOPERATION  @TE_CODESMSTYPEOPERATION, @TS_CODETYPESCHEMACOMPTABLE, @TE_LIBELLE, @TE_NATUREOPERATION, @TE_ACTIF, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTE_CODESMSTYPEOPERATION);
			vppSqlCmd.Parameters.Add(vppParamTS_CODETYPESCHEMACOMPTABLE);
			vppSqlCmd.Parameters.Add(vppParamTE_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamTE_NATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamTE_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQSMSPARAMETRETYPEOPERATION  @TE_CODESMSTYPEOPERATION, '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqsmsparametretypeoperation </returns>
		///<author>Home Technology</author>
		public List<clsReqsmsparametretypeoperation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TE_CODESMSTYPEOPERATION, TS_CODETYPESCHEMACOMPTABLE, TE_LIBELLE, TE_NATUREOPERATION, TE_ACTIF FROM dbo.FT_REQSMSPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqsmsparametretypeoperation> clsReqsmsparametretypeoperations = new List<clsReqsmsparametretypeoperation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqsmsparametretypeoperation clsReqsmsparametretypeoperation = new clsReqsmsparametretypeoperation();
					clsReqsmsparametretypeoperation.TE_CODESMSTYPEOPERATION = clsDonnee.vogDataReader["TE_CODESMSTYPEOPERATION"].ToString();
					clsReqsmsparametretypeoperation.TS_CODETYPESCHEMACOMPTABLE = clsDonnee.vogDataReader["TS_CODETYPESCHEMACOMPTABLE"].ToString();
					clsReqsmsparametretypeoperation.TE_LIBELLE = clsDonnee.vogDataReader["TE_LIBELLE"].ToString();
					clsReqsmsparametretypeoperation.TE_NATUREOPERATION = clsDonnee.vogDataReader["TE_NATUREOPERATION"].ToString();
					clsReqsmsparametretypeoperation.TE_ACTIF = clsDonnee.vogDataReader["TE_ACTIF"].ToString();
					clsReqsmsparametretypeoperations.Add(clsReqsmsparametretypeoperation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqsmsparametretypeoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqsmsparametretypeoperation </returns>
		///<author>Home Technology</author>
		public List<clsReqsmsparametretypeoperation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqsmsparametretypeoperation> clsReqsmsparametretypeoperations = new List<clsReqsmsparametretypeoperation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TE_CODESMSTYPEOPERATION, TS_CODETYPESCHEMACOMPTABLE, TE_LIBELLE, TE_NATUREOPERATION, TE_ACTIF FROM dbo.FT_REQSMSPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqsmsparametretypeoperation clsReqsmsparametretypeoperation = new clsReqsmsparametretypeoperation();
					clsReqsmsparametretypeoperation.TE_CODESMSTYPEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["TE_CODESMSTYPEOPERATION"].ToString();
					clsReqsmsparametretypeoperation.TS_CODETYPESCHEMACOMPTABLE = Dataset.Tables["TABLE"].Rows[Idx]["TS_CODETYPESCHEMACOMPTABLE"].ToString();
					clsReqsmsparametretypeoperation.TE_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["TE_LIBELLE"].ToString();
					clsReqsmsparametretypeoperation.TE_NATUREOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["TE_NATUREOPERATION"].ToString();
					clsReqsmsparametretypeoperation.TE_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["TE_ACTIF"].ToString();
					clsReqsmsparametretypeoperations.Add(clsReqsmsparametretypeoperation);
				}
				Dataset.Dispose();
			}
		return clsReqsmsparametretypeoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQSMSPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TE_CODESMSTYPEOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TE_CODESMSTYPEOPERATION , TS_CODETYPESCHEMACOMPTABLE FROM dbo.FT_REQSMSPARAMETRETYPEOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TE_CODESMSTYPEOPERATION)</summary>
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
				this.vapCritere ="WHERE TE_CODESMSTYPEOPERATION=@TE_CODESMSTYPEOPERATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TE_CODESMSTYPEOPERATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
