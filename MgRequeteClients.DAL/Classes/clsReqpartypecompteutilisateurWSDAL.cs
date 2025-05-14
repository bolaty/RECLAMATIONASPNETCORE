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
	public class clsReqpartypecompteutilisateurWSDAL: ITableDAL<clsReqpartypecompteutilisateur>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TU_CODETYPEUTILISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TU_CODETYPEUTILISATEUR) AS TU_CODETYPEUTILISATEUR  FROM dbo.FT_REQPARTYPECOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TU_CODETYPEUTILISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TU_CODETYPEUTILISATEUR) AS TU_CODETYPEUTILISATEUR  FROM dbo.FT_REQPARTYPECOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TU_CODETYPEUTILISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TU_CODETYPEUTILISATEUR) AS TU_CODETYPEUTILISATEUR  FROM dbo.FT_REQPARTYPECOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TU_CODETYPEUTILISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqpartypecompteutilisateur comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqpartypecompteutilisateur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TU_LIBELLETYPEUTILISATEUR  , TU_ACTIF  FROM dbo.FT_REQPARTYPECOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqpartypecompteutilisateur clsReqpartypecompteutilisateur = new clsReqpartypecompteutilisateur();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqpartypecompteutilisateur.TU_LIBELLETYPEUTILISATEUR = clsDonnee.vogDataReader["TU_LIBELLETYPEUTILISATEUR"].ToString();
					clsReqpartypecompteutilisateur.TU_ACTIF = clsDonnee.vogDataReader["TU_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqpartypecompteutilisateur;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqpartypecompteutilisateur>clsReqpartypecompteutilisateur</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsReqpartypecompteutilisateur clsReqpartypecompteutilisateur)
		{
			//Préparation des paramètres
			SqlParameter vppParamTU_CODETYPEUTILISATEUR = new SqlParameter("@TU_CODETYPEUTILISATEUR", SqlDbType.VarChar, 4);
			vppParamTU_CODETYPEUTILISATEUR.Value  = clsReqpartypecompteutilisateur.TU_CODETYPEUTILISATEUR ;
			SqlParameter vppParamTU_LIBELLETYPEUTILISATEUR = new SqlParameter("@TU_LIBELLETYPEUTILISATEUR", SqlDbType.VarChar, 150);
			vppParamTU_LIBELLETYPEUTILISATEUR.Value  = clsReqpartypecompteutilisateur.TU_LIBELLETYPEUTILISATEUR ;
			SqlParameter vppParamTU_ACTIF = new SqlParameter("@TU_ACTIF", SqlDbType.VarChar, 1);
			vppParamTU_ACTIF.Value  = clsReqpartypecompteutilisateur.TU_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQPARTYPECOMPTEUTILISATEUR  @TU_CODETYPEUTILISATEUR, @TU_LIBELLETYPEUTILISATEUR, @TU_ACTIF, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTU_CODETYPEUTILISATEUR);
			vppSqlCmd.Parameters.Add(vppParamTU_LIBELLETYPEUTILISATEUR);
			vppSqlCmd.Parameters.Add(vppParamTU_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TU_CODETYPEUTILISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqpartypecompteutilisateur>clsReqpartypecompteutilisateur</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsReqpartypecompteutilisateur clsReqpartypecompteutilisateur,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTU_CODETYPEUTILISATEUR = new SqlParameter("@TU_CODETYPEUTILISATEUR", SqlDbType.VarChar, 4);
			vppParamTU_CODETYPEUTILISATEUR.Value  = clsReqpartypecompteutilisateur.TU_CODETYPEUTILISATEUR ;
			SqlParameter vppParamTU_LIBELLETYPEUTILISATEUR = new SqlParameter("@TU_LIBELLETYPEUTILISATEUR", SqlDbType.VarChar, 150);
			vppParamTU_LIBELLETYPEUTILISATEUR.Value  = clsReqpartypecompteutilisateur.TU_LIBELLETYPEUTILISATEUR ;
			SqlParameter vppParamTU_ACTIF = new SqlParameter("@TU_ACTIF", SqlDbType.VarChar, 1);
			vppParamTU_ACTIF.Value  = clsReqpartypecompteutilisateur.TU_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQPARTYPECOMPTEUTILISATEUR  @TU_CODETYPEUTILISATEUR, @TU_LIBELLETYPEUTILISATEUR, @TU_ACTIF, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTU_CODETYPEUTILISATEUR);
			vppSqlCmd.Parameters.Add(vppParamTU_LIBELLETYPEUTILISATEUR);
			vppSqlCmd.Parameters.Add(vppParamTU_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TU_CODETYPEUTILISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQPARTYPECOMPTEUTILISATEUR  @TU_CODETYPEUTILISATEUR, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TU_CODETYPEUTILISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqpartypecompteutilisateur </returns>
		///<author>Home Technology</author>
		public List<clsReqpartypecompteutilisateur> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TU_CODETYPEUTILISATEUR, TU_LIBELLETYPEUTILISATEUR, TU_ACTIF FROM dbo.FT_REQPARTYPECOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqpartypecompteutilisateur> clsReqpartypecompteutilisateurs = new List<clsReqpartypecompteutilisateur>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqpartypecompteutilisateur clsReqpartypecompteutilisateur = new clsReqpartypecompteutilisateur();
					clsReqpartypecompteutilisateur.TU_CODETYPEUTILISATEUR = clsDonnee.vogDataReader["TU_CODETYPEUTILISATEUR"].ToString();
					clsReqpartypecompteutilisateur.TU_LIBELLETYPEUTILISATEUR = clsDonnee.vogDataReader["TU_LIBELLETYPEUTILISATEUR"].ToString();
					clsReqpartypecompteutilisateur.TU_ACTIF = clsDonnee.vogDataReader["TU_ACTIF"].ToString();
					clsReqpartypecompteutilisateurs.Add(clsReqpartypecompteutilisateur);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqpartypecompteutilisateurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TU_CODETYPEUTILISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqpartypecompteutilisateur </returns>
		///<author>Home Technology</author>
		public List<clsReqpartypecompteutilisateur> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqpartypecompteutilisateur> clsReqpartypecompteutilisateurs = new List<clsReqpartypecompteutilisateur>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TU_CODETYPEUTILISATEUR, TU_LIBELLETYPEUTILISATEUR, TU_ACTIF FROM dbo.FT_REQPARTYPECOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqpartypecompteutilisateur clsReqpartypecompteutilisateur = new clsReqpartypecompteutilisateur();
					clsReqpartypecompteutilisateur.TU_CODETYPEUTILISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["TU_CODETYPEUTILISATEUR"].ToString();
					clsReqpartypecompteutilisateur.TU_LIBELLETYPEUTILISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["TU_LIBELLETYPEUTILISATEUR"].ToString();
					clsReqpartypecompteutilisateur.TU_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["TU_ACTIF"].ToString();
					clsReqpartypecompteutilisateurs.Add(clsReqpartypecompteutilisateur);
				}
				Dataset.Dispose();
			}
		return clsReqpartypecompteutilisateurs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TU_CODETYPEUTILISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQPARTYPECOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TU_CODETYPEUTILISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TU_CODETYPEUTILISATEUR , TU_LIBELLETYPEUTILISATEUR FROM dbo.FT_REQPARTYPECOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TU_CODETYPEUTILISATEUR)</summary>
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
				this.vapCritere ="WHERE TU_CODETYPEUTILISATEUR=@TU_CODETYPEUTILISATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TU_CODETYPEUTILISATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
