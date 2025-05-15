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
	public class clsRequtilisateurdroitparametreWSDAL: ITableDAL<clsRequtilisateurdroitparametre>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(DP_CODEDROITCOMPTEUTULISATEUR) AS DP_CODEDROITCOMPTEUTULISATEUR  FROM dbo.FT_REQUTILISATEURDROITPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(DP_CODEDROITCOMPTEUTULISATEUR) AS DP_CODEDROITCOMPTEUTULISATEUR  FROM dbo.FT_REQUTILISATEURDROITPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(DP_CODEDROITCOMPTEUTULISATEUR) AS DP_CODEDROITCOMPTEUTULISATEUR  FROM dbo.REQUTILISATEURDROITPARAMETRE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsRequtilisateurdroitparametre comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsRequtilisateurdroitparametre pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT DP_LIBELLEDROITCOMPTEUTULISATEUR  , DP_STATUT  FROM dbo.FT_REQUTILISATEURDROITPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsRequtilisateurdroitparametre clsRequtilisateurdroitparametre = new clsRequtilisateurdroitparametre();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsRequtilisateurdroitparametre.DP_LIBELLEDROITCOMPTEUTULISATEUR = clsDonnee.vogDataReader["DP_LIBELLEDROITCOMPTEUTULISATEUR"].ToString();
					clsRequtilisateurdroitparametre.DP_STATUT = clsDonnee.vogDataReader["DP_STATUT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsRequtilisateurdroitparametre;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsRequtilisateurdroitparametre>clsRequtilisateurdroitparametre</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsRequtilisateurdroitparametre clsRequtilisateurdroitparametre)
		{
			//Préparation des paramètres
			SqlParameter vppParamDP_CODEDROITCOMPTEUTULISATEUR = new SqlParameter("@DP_CODEDROITCOMPTEUTULISATEUR", SqlDbType.VarChar, 25);
			vppParamDP_CODEDROITCOMPTEUTULISATEUR.Value  = clsRequtilisateurdroitparametre.DP_CODEDROITCOMPTEUTULISATEUR ;
			SqlParameter vppParamDP_LIBELLEDROITCOMPTEUTULISATEUR = new SqlParameter("@DP_LIBELLEDROITCOMPTEUTULISATEUR", SqlDbType.VarChar, 150);
			vppParamDP_LIBELLEDROITCOMPTEUTULISATEUR.Value  = clsRequtilisateurdroitparametre.DP_LIBELLEDROITCOMPTEUTULISATEUR ;
			SqlParameter vppParamDP_STATUT = new SqlParameter("@DP_STATUT", SqlDbType.VarChar, 1);
			vppParamDP_STATUT.Value  = clsRequtilisateurdroitparametre.DP_STATUT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsRequtilisateurdroitparametre.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQUTILISATEURDROITPARAMETRE  @DP_CODEDROITCOMPTEUTULISATEUR, @DP_LIBELLEDROITCOMPTEUTULISATEUR, @DP_STATUT, @CODECRYPTAGE1, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDP_CODEDROITCOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamDP_LIBELLEDROITCOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamDP_STATUT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsRequtilisateurdroitparametre>clsRequtilisateurdroitparametre</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsRequtilisateurdroitparametre clsRequtilisateurdroitparametre,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamDP_CODEDROITCOMPTEUTULISATEUR = new SqlParameter("@DP_CODEDROITCOMPTEUTULISATEUR", SqlDbType.VarChar, 25);
			vppParamDP_CODEDROITCOMPTEUTULISATEUR.Value  = clsRequtilisateurdroitparametre.DP_CODEDROITCOMPTEUTULISATEUR ;
			SqlParameter vppParamDP_LIBELLEDROITCOMPTEUTULISATEUR = new SqlParameter("@DP_LIBELLEDROITCOMPTEUTULISATEUR", SqlDbType.VarChar, 150);
			vppParamDP_LIBELLEDROITCOMPTEUTULISATEUR.Value  = clsRequtilisateurdroitparametre.DP_LIBELLEDROITCOMPTEUTULISATEUR ;
			SqlParameter vppParamDP_STATUT = new SqlParameter("@DP_STATUT", SqlDbType.VarChar, 1);
			vppParamDP_STATUT.Value  = clsRequtilisateurdroitparametre.DP_STATUT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQUTILISATEURDROITPARAMETRE  @DP_CODEDROITCOMPTEUTULISATEUR, @DP_LIBELLEDROITCOMPTEUTULISATEUR, @DP_STATUT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDP_CODEDROITCOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamDP_LIBELLEDROITCOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamDP_STATUT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQUTILISATEURDROITPARAMETRE  @DP_CODEDROITCOMPTEUTULISATEUR, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsRequtilisateurdroitparametre </returns>
		///<author>Home Technology</author>
		public List<clsRequtilisateurdroitparametre> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DP_CODEDROITCOMPTEUTULISATEUR, DP_LIBELLEDROITCOMPTEUTULISATEUR, DP_STATUT FROM dbo.FT_REQUTILISATEURDROITPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsRequtilisateurdroitparametre> clsRequtilisateurdroitparametres = new List<clsRequtilisateurdroitparametre>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsRequtilisateurdroitparametre clsRequtilisateurdroitparametre = new clsRequtilisateurdroitparametre();
					clsRequtilisateurdroitparametre.DP_CODEDROITCOMPTEUTULISATEUR = clsDonnee.vogDataReader["DP_CODEDROITCOMPTEUTULISATEUR"].ToString();
					clsRequtilisateurdroitparametre.DP_LIBELLEDROITCOMPTEUTULISATEUR = clsDonnee.vogDataReader["DP_LIBELLEDROITCOMPTEUTULISATEUR"].ToString();
					clsRequtilisateurdroitparametre.DP_STATUT = clsDonnee.vogDataReader["DP_STATUT"].ToString();
					clsRequtilisateurdroitparametres.Add(clsRequtilisateurdroitparametre);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsRequtilisateurdroitparametres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsRequtilisateurdroitparametre </returns>
		///<author>Home Technology</author>
		public List<clsRequtilisateurdroitparametre> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsRequtilisateurdroitparametre> clsRequtilisateurdroitparametres = new List<clsRequtilisateurdroitparametre>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DP_CODEDROITCOMPTEUTULISATEUR, DP_LIBELLEDROITCOMPTEUTULISATEUR, DP_STATUT FROM dbo.FT_REQUTILISATEURDROITPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsRequtilisateurdroitparametre clsRequtilisateurdroitparametre = new clsRequtilisateurdroitparametre();
					clsRequtilisateurdroitparametre.DP_CODEDROITCOMPTEUTULISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["DP_CODEDROITCOMPTEUTULISATEUR"].ToString();
					clsRequtilisateurdroitparametre.DP_LIBELLEDROITCOMPTEUTULISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["DP_LIBELLEDROITCOMPTEUTULISATEUR"].ToString();
					clsRequtilisateurdroitparametre.DP_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["DP_STATUT"].ToString();
					clsRequtilisateurdroitparametres.Add(clsRequtilisateurdroitparametre);
				}
				Dataset.Dispose();
			}
		return clsRequtilisateurdroitparametres;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQUTILISATEURDROITPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT DP_CODEDROITCOMPTEUTULISATEUR , DP_LIBELLEDROITCOMPTEUTULISATEUR FROM dbo.FT_REQUTILISATEURDROITPARAMETRE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :DP_CODEDROITCOMPTEUTULISATEUR)</summary>
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
				this.vapCritere ="WHERE DP_CODEDROITCOMPTEUTULISATEUR=@DP_CODEDROITCOMPTEUTULISATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@DP_CODEDROITCOMPTEUTULISATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
