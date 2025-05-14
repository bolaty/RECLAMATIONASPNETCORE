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
	public class clsRequtilisateurdroitWSDAL: ITableDAL<clsRequtilisateurdroit>
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
			this.vapRequete = "SELECT COUNT(DP_CODEDROITCOMPTEUTULISATEUR) AS DP_CODEDROITCOMPTEUTULISATEUR  FROM dbo.FT_REQUTILISATEURDROIT(@CODECRYPTAGE) " + this.vapCritere;
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
			this.vapRequete = "SELECT MIN(DP_CODEDROITCOMPTEUTULISATEUR) AS DP_CODEDROITCOMPTEUTULISATEUR  FROM dbo.FT_REQUTILISATEURDROIT(@CODECRYPTAGE) " + this.vapCritere;
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
			this.vapRequete = "SELECT MAX(DP_CODEDROITCOMPTEUTULISATEUR) AS DP_CODEDROITCOMPTEUTULISATEUR  FROM dbo.FT_REQUTILISATEURDROIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsRequtilisateurdroit comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsRequtilisateurdroit pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CU_CODECOMPTEUTULISATEUR  FROM dbo.FT_REQUTILISATEURDROIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsRequtilisateurdroit clsRequtilisateurdroit = new clsRequtilisateurdroit();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsRequtilisateurdroit.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsRequtilisateurdroit;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsRequtilisateurdroit>clsRequtilisateurdroit</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsRequtilisateurdroit clsRequtilisateurdroit)
		{
			//Préparation des paramètres
			SqlParameter vppParamDP_CODEDROITCOMPTEUTULISATEUR = new SqlParameter("@DP_CODEDROITCOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
			vppParamDP_CODEDROITCOMPTEUTULISATEUR.Value  = clsRequtilisateurdroit.DP_CODEDROITCOMPTEUTULISATEUR ;
			SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
			vppParamCU_CODECOMPTEUTULISATEUR.Value  = clsRequtilisateurdroit.CU_CODECOMPTEUTULISATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsRequtilisateurdroit.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQUTILISATEURDROIT  @DP_CODEDROITCOMPTEUTULISATEUR, @CU_CODECOMPTEUTULISATEUR, @CODECRYPTAGE1, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDP_CODEDROITCOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsRequtilisateurdroit>clsRequtilisateurdroit</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsRequtilisateurdroit clsRequtilisateurdroit,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamDP_CODEDROITCOMPTEUTULISATEUR = new SqlParameter("@DP_CODEDROITCOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
			vppParamDP_CODEDROITCOMPTEUTULISATEUR.Value  = clsRequtilisateurdroit.DP_CODEDROITCOMPTEUTULISATEUR ;
			SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
			vppParamCU_CODECOMPTEUTULISATEUR.Value  = clsRequtilisateurdroit.CU_CODECOMPTEUTULISATEUR ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQUTILISATEURDROIT  @DP_CODEDROITCOMPTEUTULISATEUR, @CU_CODECOMPTEUTULISATEUR, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamDP_CODEDROITCOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
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
			 this.vapRequete = "EXECUTE PC_REQUTILISATEURDROIT  @DP_CODEDROITCOMPTEUTULISATEUR, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsRequtilisateurdroit </returns>
		///<author>Home Technology</author>
		public List<clsRequtilisateurdroit> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DP_CODEDROITCOMPTEUTULISATEUR, CU_CODECOMPTEUTULISATEUR FROM dbo.FT_REQUTILISATEURDROIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsRequtilisateurdroit> clsRequtilisateurdroits = new List<clsRequtilisateurdroit>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsRequtilisateurdroit clsRequtilisateurdroit = new clsRequtilisateurdroit();
					clsRequtilisateurdroit.DP_CODEDROITCOMPTEUTULISATEUR = clsDonnee.vogDataReader["DP_CODEDROITCOMPTEUTULISATEUR"].ToString();
					clsRequtilisateurdroit.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsRequtilisateurdroits.Add(clsRequtilisateurdroit);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsRequtilisateurdroits;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsRequtilisateurdroit </returns>
		///<author>Home Technology</author>
		public List<clsRequtilisateurdroit> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsRequtilisateurdroit> clsRequtilisateurdroits = new List<clsRequtilisateurdroit>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  DP_CODEDROITCOMPTEUTULISATEUR, CU_CODECOMPTEUTULISATEUR FROM dbo.FT_REQUTILISATEURDROIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsRequtilisateurdroit clsRequtilisateurdroit = new clsRequtilisateurdroit();
					clsRequtilisateurdroit.DP_CODEDROITCOMPTEUTULISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["DP_CODEDROITCOMPTEUTULISATEUR"].ToString();
					clsRequtilisateurdroit.CU_CODECOMPTEUTULISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsRequtilisateurdroits.Add(clsRequtilisateurdroit);
				}
				Dataset.Dispose();
			}
		return clsRequtilisateurdroits;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQUTILISATEURDROIT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : DP_CODEDROITCOMPTEUTULISATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetUtilisateurdroit(clsDonnee clsDonnee, params string[] vppCritere)
        {

            vapNomParametre = new string[] { "@CODECRYPTAGE", "@CU_CODECOMPTEUTULISATEUR", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0],vppCritere[1] };
            this.vapRequete = "EXEC [dbo].[PS_REQUTILISATEURDROIT]@CU_CODECOMPTEUTULISATEUR,@TYPEOPERATION ,@CODECRYPTAGE ";
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
			this.vapRequete = "SELECT DP_CODEDROITCOMPTEUTULISATEUR , CU_CODECOMPTEUTULISATEUR FROM dbo.FT_REQUTILISATEURDROIT(@CODECRYPTAGE) " + this.vapCritere;
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
