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
	public class clsReqstatutrecevabiliteWSDAL: ITableDAL<clsReqstatutrecevabilite>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : RS_CODESTATUTRECEVABILITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(RS_CODESTATUTRECEVABILITE) AS RS_CODESTATUTRECEVABILITE  FROM dbo.FT_REQSTATUTRECEVABILITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : RS_CODESTATUTRECEVABILITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(RS_CODESTATUTRECEVABILITE) AS RS_CODESTATUTRECEVABILITE  FROM dbo.FT_REQSTATUTRECEVABILITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : RS_CODESTATUTRECEVABILITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(RS_CODESTATUTRECEVABILITE) AS RS_CODESTATUTRECEVABILITE  FROM dbo.FT_REQSTATUTRECEVABILITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RS_CODESTATUTRECEVABILITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqstatutrecevabilite comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqstatutrecevabilite pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RS_LIBELLESTATUTRECEVABILITE  FROM dbo.FT_REQSTATUTRECEVABILITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqstatutrecevabilite clsReqstatutrecevabilite = new clsReqstatutrecevabilite();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqstatutrecevabilite.RS_LIBELLESTATUTRECEVABILITE = clsDonnee.vogDataReader["RS_LIBELLESTATUTRECEVABILITE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqstatutrecevabilite;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqstatutrecevabilite>clsReqstatutrecevabilite</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsReqstatutrecevabilite clsReqstatutrecevabilite)
		{
			//Préparation des paramètres
			SqlParameter vppParamRS_CODESTATUTRECEVABILITE = new SqlParameter("@RS_CODESTATUTRECEVABILITE", SqlDbType.VarChar, 2);
			vppParamRS_CODESTATUTRECEVABILITE.Value  = clsReqstatutrecevabilite.RS_CODESTATUTRECEVABILITE ;
			SqlParameter vppParamRS_LIBELLESTATUTRECEVABILITE = new SqlParameter("@RS_LIBELLESTATUTRECEVABILITE", SqlDbType.VarChar, 150);
			vppParamRS_LIBELLESTATUTRECEVABILITE.Value  = clsReqstatutrecevabilite.RS_LIBELLESTATUTRECEVABILITE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQSTATUTRECEVABILITE  @RS_CODESTATUTRECEVABILITE, @RS_LIBELLESTATUTRECEVABILITE, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRS_CODESTATUTRECEVABILITE);
			vppSqlCmd.Parameters.Add(vppParamRS_LIBELLESTATUTRECEVABILITE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : RS_CODESTATUTRECEVABILITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqstatutrecevabilite>clsReqstatutrecevabilite</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsReqstatutrecevabilite clsReqstatutrecevabilite,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamRS_CODESTATUTRECEVABILITE = new SqlParameter("@RS_CODESTATUTRECEVABILITE", SqlDbType.VarChar, 2);
			vppParamRS_CODESTATUTRECEVABILITE.Value  = clsReqstatutrecevabilite.RS_CODESTATUTRECEVABILITE ;
			SqlParameter vppParamRS_LIBELLESTATUTRECEVABILITE = new SqlParameter("@RS_LIBELLESTATUTRECEVABILITE", SqlDbType.VarChar, 150);
			vppParamRS_LIBELLESTATUTRECEVABILITE.Value  = clsReqstatutrecevabilite.RS_LIBELLESTATUTRECEVABILITE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQSTATUTRECEVABILITE  @RS_CODESTATUTRECEVABILITE, @RS_LIBELLESTATUTRECEVABILITE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRS_CODESTATUTRECEVABILITE);
			vppSqlCmd.Parameters.Add(vppParamRS_LIBELLESTATUTRECEVABILITE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : RS_CODESTATUTRECEVABILITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQSTATUTRECEVABILITE  @RS_CODESTATUTRECEVABILITE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RS_CODESTATUTRECEVABILITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqstatutrecevabilite </returns>
		///<author>Home Technology</author>
		public List<clsReqstatutrecevabilite> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RS_CODESTATUTRECEVABILITE, RS_LIBELLESTATUTRECEVABILITE FROM dbo.FT_REQSTATUTRECEVABILITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqstatutrecevabilite> clsReqstatutrecevabilites = new List<clsReqstatutrecevabilite>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqstatutrecevabilite clsReqstatutrecevabilite = new clsReqstatutrecevabilite();
					clsReqstatutrecevabilite.RS_CODESTATUTRECEVABILITE = clsDonnee.vogDataReader["RS_CODESTATUTRECEVABILITE"].ToString();
					clsReqstatutrecevabilite.RS_LIBELLESTATUTRECEVABILITE = clsDonnee.vogDataReader["RS_LIBELLESTATUTRECEVABILITE"].ToString();
					clsReqstatutrecevabilites.Add(clsReqstatutrecevabilite);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqstatutrecevabilites;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RS_CODESTATUTRECEVABILITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqstatutrecevabilite </returns>
		///<author>Home Technology</author>
		public List<clsReqstatutrecevabilite> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqstatutrecevabilite> clsReqstatutrecevabilites = new List<clsReqstatutrecevabilite>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RS_CODESTATUTRECEVABILITE, RS_LIBELLESTATUTRECEVABILITE FROM dbo.FT_REQSTATUTRECEVABILITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqstatutrecevabilite clsReqstatutrecevabilite = new clsReqstatutrecevabilite();
					clsReqstatutrecevabilite.RS_CODESTATUTRECEVABILITE = Dataset.Tables["TABLE"].Rows[Idx]["RS_CODESTATUTRECEVABILITE"].ToString();
					clsReqstatutrecevabilite.RS_LIBELLESTATUTRECEVABILITE = Dataset.Tables["TABLE"].Rows[Idx]["RS_LIBELLESTATUTRECEVABILITE"].ToString();
					clsReqstatutrecevabilites.Add(clsReqstatutrecevabilite);
				}
				Dataset.Dispose();
			}
		return clsReqstatutrecevabilites;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RS_CODESTATUTRECEVABILITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQSTATUTRECEVABILITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : RS_CODESTATUTRECEVABILITE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RS_CODESTATUTRECEVABILITE , RS_LIBELLESTATUTRECEVABILITE FROM dbo.FT_REQSTATUTRECEVABILITE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RS_CODESTATUTRECEVABILITE)</summary>
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
				this.vapCritere ="WHERE RS_CODESTATUTRECEVABILITE=@RS_CODESTATUTRECEVABILITE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RS_CODESTATUTRECEVABILITE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
