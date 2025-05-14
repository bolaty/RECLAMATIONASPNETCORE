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
	public class clsReqnaturerequeteWSDAL: ITableDAL<clsReqnaturerequete>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT COUNT(NR_CODENATUREREQUETE) AS NR_CODENATUREREQUETE  FROM dbo.REQNATUREREQUETE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MIN(NR_CODENATUREREQUETE) AS NR_CODENATUREREQUETE  FROM dbo.REQNATUREREQUETE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT MAX(NR_CODENATUREREQUETE) AS NR_CODENATUREREQUETE  FROM dbo.REQNATUREREQUETE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqnaturerequete comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqnaturerequete pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT NR_LIBELLENATUREREQUETE  , NR_STATUT  FROM dbo.REQNATUREREQUETE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqnaturerequete clsReqnaturerequete = new clsReqnaturerequete();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqnaturerequete.NR_LIBELLENATUREREQUETE = clsDonnee.vogDataReader["NR_LIBELLENATUREREQUETE"].ToString();
					clsReqnaturerequete.NR_STATUT = clsDonnee.vogDataReader["NR_STATUT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqnaturerequete;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqnaturerequete>clsReqnaturerequete</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsReqnaturerequete clsReqnaturerequete)
		{
			//Préparation des paramètres
			SqlParameter vppParamNR_CODENATUREREQUETE = new SqlParameter("@NR_CODENATUREREQUETE", SqlDbType.VarChar, 2);
			vppParamNR_CODENATUREREQUETE.Value  = clsReqnaturerequete.NR_CODENATUREREQUETE ;
			SqlParameter vppParamNR_LIBELLENATUREREQUETE = new SqlParameter("@NR_LIBELLENATUREREQUETE", SqlDbType.VarChar, 150);
			vppParamNR_LIBELLENATUREREQUETE.Value  = clsReqnaturerequete.NR_LIBELLENATUREREQUETE ;
			SqlParameter vppParamNR_STATUT = new SqlParameter("@NR_STATUT", SqlDbType.VarChar, 1);
			vppParamNR_STATUT.Value  = clsReqnaturerequete.NR_STATUT ;

			//Préparation de la commande
			 this.vapRequete = "INSERT INTO REQNATUREREQUETE (  NR_CODENATUREREQUETE, NR_LIBELLENATUREREQUETE, NR_STATUT) " +
					 "VALUES ( @NR_CODENATUREREQUETE, @NR_LIBELLENATUREREQUETE, @NR_STATUT) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNR_CODENATUREREQUETE);
			vppSqlCmd.Parameters.Add(vppParamNR_LIBELLENATUREREQUETE);
			vppSqlCmd.Parameters.Add(vppParamNR_STATUT);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqnaturerequete>clsReqnaturerequete</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsReqnaturerequete clsReqnaturerequete,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamNR_LIBELLENATUREREQUETE = new SqlParameter("@NR_LIBELLENATUREREQUETE", SqlDbType.VarChar, 150);
			vppParamNR_LIBELLENATUREREQUETE.Value  = clsReqnaturerequete.NR_LIBELLENATUREREQUETE ;
			SqlParameter vppParamNR_STATUT = new SqlParameter("@NR_STATUT", SqlDbType.VarChar, 1);
			vppParamNR_STATUT.Value  = clsReqnaturerequete.NR_STATUT ;

			//Préparation de la commande
			 pvpChoixCritere(vppCritere); 
			 this.vapRequete = "UPDATE REQNATUREREQUETE SET " +
							"NR_LIBELLENATUREREQUETE = @NR_LIBELLENATUREREQUETE, "+
							"NR_STATUT = @NR_STATUT " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNR_LIBELLENATUREREQUETE);
			vppSqlCmd.Parameters.Add(vppParamNR_STATUT);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  REQNATUREREQUETE "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqnaturerequete </returns>
		///<author>Home Technology</author>
		public List<clsReqnaturerequete> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  NR_CODENATUREREQUETE, NR_LIBELLENATUREREQUETE, NR_STATUT FROM dbo.REQNATUREREQUETE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqnaturerequete> clsReqnaturerequetes = new List<clsReqnaturerequete>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqnaturerequete clsReqnaturerequete = new clsReqnaturerequete();
					clsReqnaturerequete.NR_CODENATUREREQUETE = clsDonnee.vogDataReader["NR_CODENATUREREQUETE"].ToString();
					clsReqnaturerequete.NR_LIBELLENATUREREQUETE = clsDonnee.vogDataReader["NR_LIBELLENATUREREQUETE"].ToString();
					clsReqnaturerequete.NR_STATUT = clsDonnee.vogDataReader["NR_STATUT"].ToString();
					clsReqnaturerequetes.Add(clsReqnaturerequete);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqnaturerequetes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqnaturerequete </returns>
		///<author>Home Technology</author>
		public List<clsReqnaturerequete> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqnaturerequete> clsReqnaturerequetes = new List<clsReqnaturerequete>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT  NR_CODENATUREREQUETE, NR_LIBELLENATUREREQUETE, NR_STATUT FROM dbo.REQNATUREREQUETE " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqnaturerequete clsReqnaturerequete = new clsReqnaturerequete();
					clsReqnaturerequete.NR_CODENATUREREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["NR_CODENATUREREQUETE"].ToString();
					clsReqnaturerequete.NR_LIBELLENATUREREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["NR_LIBELLENATUREREQUETE"].ToString();
					clsReqnaturerequete.NR_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["NR_STATUT"].ToString();
					clsReqnaturerequetes.Add(clsReqnaturerequete);
				}
				Dataset.Dispose();
			}
		return clsReqnaturerequetes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.REQNATUREREQUETE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(vppCritere);
			this.vapRequete = "SELECT NR_CODENATUREREQUETE , NR_LIBELLENATUREREQUETE FROM dbo.REQNATUREREQUETE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :NR_CODENATUREREQUETE)</summary>
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
				this.vapCritere ="WHERE NR_CODENATUREREQUETE=@NR_CODENATUREREQUETE";
				vapNomParametre = new string[]{"@NR_CODENATUREREQUETE"};
				vapValeurParametre = new object[]{vppCritere[0]};
				break;
			}
		}
	}
}
