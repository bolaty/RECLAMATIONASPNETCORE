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
	public class clsReqmodecollecteWSDAL: ITableDAL<clsReqmodecollecte>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MC_CODEMODECOLLETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(MC_CODEMODECOLLETE) AS MC_CODEMODECOLLETE  FROM dbo.REQMODECOLLECTE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MC_CODEMODECOLLETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(MC_CODEMODECOLLETE) AS MC_CODEMODECOLLETE  FROM dbo.REQMODECOLLECTE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MC_CODEMODECOLLETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(MC_CODEMODECOLLETE) AS MC_CODEMODECOLLETE  FROM dbo.REQMODECOLLECTE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MC_CODEMODECOLLETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqmodecollecte comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqmodecollecte pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MC_LIBELLEMODECOLLETE  , MC_STATUT  FROM dbo.REQMODECOLLECTE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqmodecollecte clsReqmodecollecte = new clsReqmodecollecte();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqmodecollecte.MC_LIBELLEMODECOLLETE = clsDonnee.vogDataReader["MC_LIBELLEMODECOLLETE"].ToString();
					clsReqmodecollecte.MC_STATUT = clsDonnee.vogDataReader["MC_STATUT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqmodecollecte;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqmodecollecte>clsReqmodecollecte</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsReqmodecollecte clsReqmodecollecte)
		{
			//Préparation des paramètres
			SqlParameter vppParamMC_CODEMODECOLLETE = new SqlParameter("@MC_CODEMODECOLLETE", SqlDbType.VarChar, 2);
			vppParamMC_CODEMODECOLLETE.Value  = clsReqmodecollecte.MC_CODEMODECOLLETE ;
			SqlParameter vppParamMC_LIBELLEMODECOLLETE = new SqlParameter("@MC_LIBELLEMODECOLLETE", SqlDbType.VarChar, 150);
			vppParamMC_LIBELLEMODECOLLETE.Value  = clsReqmodecollecte.MC_LIBELLEMODECOLLETE ;
			SqlParameter vppParamMC_STATUT = new SqlParameter("@MC_STATUT", SqlDbType.VarChar, 1);
			vppParamMC_STATUT.Value  = clsReqmodecollecte.MC_STATUT ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO REQMODECOLLECTE (  MC_CODEMODECOLLETE, MC_LIBELLEMODECOLLETE, MC_STATUT) " +
					 "VALUES ( @MC_CODEMODECOLLETE, @MC_LIBELLEMODECOLLETE, @MC_STATUT) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMC_CODEMODECOLLETE);
			vppSqlCmd.Parameters.Add(vppParamMC_LIBELLEMODECOLLETE);
			vppSqlCmd.Parameters.Add(vppParamMC_STATUT);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MC_CODEMODECOLLETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqmodecollecte>clsReqmodecollecte</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsReqmodecollecte clsReqmodecollecte,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamMC_LIBELLEMODECOLLETE = new SqlParameter("@MC_LIBELLEMODECOLLETE", SqlDbType.VarChar, 150);
			vppParamMC_LIBELLEMODECOLLETE.Value  = clsReqmodecollecte.MC_LIBELLEMODECOLLETE ;
			SqlParameter vppParamMC_STATUT = new SqlParameter("@MC_STATUT", SqlDbType.VarChar, 1);
			vppParamMC_STATUT.Value  = clsReqmodecollecte.MC_STATUT ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE REQMODECOLLECTE SET " +
							"MC_LIBELLEMODECOLLETE = @MC_LIBELLEMODECOLLETE, "+
							"MC_STATUT = @MC_STATUT " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamMC_LIBELLEMODECOLLETE);
			vppSqlCmd.Parameters.Add(vppParamMC_STATUT);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MC_CODEMODECOLLETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  REQMODECOLLECTE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MC_CODEMODECOLLETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqmodecollecte </returns>
		///<author>Home Technology</author>
		public List<clsReqmodecollecte> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  MC_CODEMODECOLLETE, MC_LIBELLEMODECOLLETE, MC_STATUT FROM dbo.REQMODECOLLECTE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqmodecollecte> clsReqmodecollectes = new List<clsReqmodecollecte>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqmodecollecte clsReqmodecollecte = new clsReqmodecollecte();
					clsReqmodecollecte.MC_CODEMODECOLLETE = clsDonnee.vogDataReader["MC_CODEMODECOLLETE"].ToString();
					clsReqmodecollecte.MC_LIBELLEMODECOLLETE = clsDonnee.vogDataReader["MC_LIBELLEMODECOLLETE"].ToString();
					clsReqmodecollecte.MC_STATUT = clsDonnee.vogDataReader["MC_STATUT"].ToString();
					clsReqmodecollectes.Add(clsReqmodecollecte);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqmodecollectes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MC_CODEMODECOLLETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqmodecollecte </returns>
		///<author>Home Technology</author>
		public List<clsReqmodecollecte> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqmodecollecte> clsReqmodecollectes = new List<clsReqmodecollecte>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  MC_CODEMODECOLLETE, MC_LIBELLEMODECOLLETE, MC_STATUT FROM dbo.REQMODECOLLECTE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqmodecollecte clsReqmodecollecte = new clsReqmodecollecte();
					clsReqmodecollecte.MC_CODEMODECOLLETE = Dataset.Tables["TABLE"].Rows[Idx]["MC_CODEMODECOLLETE"].ToString();
					clsReqmodecollecte.MC_LIBELLEMODECOLLETE = Dataset.Tables["TABLE"].Rows[Idx]["MC_LIBELLEMODECOLLETE"].ToString();
					clsReqmodecollecte.MC_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["MC_STATUT"].ToString();
					clsReqmodecollectes.Add(clsReqmodecollecte);
				}
				Dataset.Dispose();
			}
		return clsReqmodecollectes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MC_CODEMODECOLLETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.REQMODECOLLECTE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MC_CODEMODECOLLETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MC_CODEMODECOLLETE , MC_LIBELLEMODECOLLETE FROM dbo.REQMODECOLLECTE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :MC_CODEMODECOLLETE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere( params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
				this.vapCritere ="";
				vapNomParametre = new string[]{};
				vapValeurParametre = new object[]{};
				break;
				case 1 :
				this.vapCritere ="WHERE MC_CODEMODECOLLETE=@MC_CODEMODECOLLETE";
				vapNomParametre = new string[]{"@MC_CODEMODECOLLETE"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
			}
		}
	}
}
