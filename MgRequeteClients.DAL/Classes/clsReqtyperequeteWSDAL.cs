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
	public class clsReqtyperequeteWSDAL: ITableDAL<clsReqtyperequete>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : TR_CODETYEREQUETE, NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(TR_CODETYEREQUETE) AS TR_CODETYEREQUETE  FROM dbo.FT_REQTYPEREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : TR_CODETYEREQUETE, NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(TR_CODETYEREQUETE) AS TR_CODETYEREQUETE  FROM dbo.FT_REQTYPEREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : TR_CODETYEREQUETE, NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(TR_CODETYEREQUETE) AS TR_CODETYEREQUETE  FROM dbo.FT_REQTYPEREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TR_CODETYEREQUETE, NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqtyperequete comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqtyperequete pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NR_CODENATUREREQUETE  , TR_LIBELLETYEREQUETE  , TR_STATUT  FROM dbo.FT_REQTYPEREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqtyperequete clsReqtyperequete = new clsReqtyperequete();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqtyperequete.NR_CODENATUREREQUETE = clsDonnee.vogDataReader["NR_CODENATUREREQUETE"].ToString();
					clsReqtyperequete.TR_LIBELLETYEREQUETE = clsDonnee.vogDataReader["TR_LIBELLETYEREQUETE"].ToString();
					clsReqtyperequete.TR_STATUT = clsDonnee.vogDataReader["TR_STATUT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqtyperequete;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqtyperequete>clsReqtyperequete</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsReqtyperequete clsReqtyperequete)
		{
			//Préparation des paramètres
			SqlParameter vppParamTR_CODETYEREQUETE = new SqlParameter("@TR_CODETYEREQUETE", SqlDbType.VarChar, 5);
			vppParamTR_CODETYEREQUETE.Value  = clsReqtyperequete.TR_CODETYEREQUETE ;
			SqlParameter vppParamNR_CODENATUREREQUETE = new SqlParameter("@NR_CODENATUREREQUETE", SqlDbType.VarChar, 2);
			vppParamNR_CODENATUREREQUETE.Value  = clsReqtyperequete.NR_CODENATUREREQUETE ;
			SqlParameter vppParamTR_LIBELLETYEREQUETE = new SqlParameter("@TR_LIBELLETYEREQUETE", SqlDbType.VarChar, 150);
			vppParamTR_LIBELLETYEREQUETE.Value  = clsReqtyperequete.TR_LIBELLETYEREQUETE ;
			SqlParameter vppParamTR_STATUT = new SqlParameter("@TR_STATUT", SqlDbType.VarChar, 1);
			vppParamTR_STATUT.Value  = clsReqtyperequete.TR_STATUT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQTYPEREQUETE  @TR_CODETYEREQUETE, @NR_CODENATUREREQUETE, @TR_LIBELLETYEREQUETE, @TR_STATUT, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTR_CODETYEREQUETE);
			vppSqlCmd.Parameters.Add(vppParamNR_CODENATUREREQUETE);
			vppSqlCmd.Parameters.Add(vppParamTR_LIBELLETYEREQUETE);
			vppSqlCmd.Parameters.Add(vppParamTR_STATUT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : TR_CODETYEREQUETE, NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqtyperequete>clsReqtyperequete</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsReqtyperequete clsReqtyperequete,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamTR_CODETYEREQUETE = new SqlParameter("@TR_CODETYEREQUETE", SqlDbType.VarChar, 5);
			vppParamTR_CODETYEREQUETE.Value  = clsReqtyperequete.TR_CODETYEREQUETE ;
			SqlParameter vppParamNR_CODENATUREREQUETE = new SqlParameter("@NR_CODENATUREREQUETE", SqlDbType.VarChar, 2);
			vppParamNR_CODENATUREREQUETE.Value  = clsReqtyperequete.NR_CODENATUREREQUETE ;
			SqlParameter vppParamTR_LIBELLETYEREQUETE = new SqlParameter("@TR_LIBELLETYEREQUETE", SqlDbType.VarChar, 150);
			vppParamTR_LIBELLETYEREQUETE.Value  = clsReqtyperequete.TR_LIBELLETYEREQUETE ;
			SqlParameter vppParamTR_STATUT = new SqlParameter("@TR_STATUT", SqlDbType.VarChar, 1);
			vppParamTR_STATUT.Value  = clsReqtyperequete.TR_STATUT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQTYPEREQUETE  @TR_CODETYEREQUETE, @NR_CODENATUREREQUETE, @TR_LIBELLETYEREQUETE, @TR_STATUT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamTR_CODETYEREQUETE);
			vppSqlCmd.Parameters.Add(vppParamNR_CODENATUREREQUETE);
			vppSqlCmd.Parameters.Add(vppParamTR_LIBELLETYEREQUETE);
			vppSqlCmd.Parameters.Add(vppParamTR_STATUT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : TR_CODETYEREQUETE, NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQTYPEREQUETE  @TR_CODETYEREQUETE, @NR_CODENATUREREQUETE, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TR_CODETYEREQUETE, NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqtyperequete </returns>
		///<author>Home Technology</author>
		public List<clsReqtyperequete> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TR_CODETYEREQUETE, NR_CODENATUREREQUETE, TR_LIBELLETYEREQUETE, TR_STATUT FROM dbo.FT_REQTYPEREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqtyperequete> clsReqtyperequetes = new List<clsReqtyperequete>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqtyperequete clsReqtyperequete = new clsReqtyperequete();
					clsReqtyperequete.TR_CODETYEREQUETE = clsDonnee.vogDataReader["TR_CODETYEREQUETE"].ToString();
					clsReqtyperequete.NR_CODENATUREREQUETE = clsDonnee.vogDataReader["NR_CODENATUREREQUETE"].ToString();
					clsReqtyperequete.TR_LIBELLETYEREQUETE = clsDonnee.vogDataReader["TR_LIBELLETYEREQUETE"].ToString();
					clsReqtyperequete.TR_STATUT = clsDonnee.vogDataReader["TR_STATUT"].ToString();
					clsReqtyperequetes.Add(clsReqtyperequete);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqtyperequetes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TR_CODETYEREQUETE, NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqtyperequete </returns>
		///<author>Home Technology</author>
		public List<clsReqtyperequete> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqtyperequete> clsReqtyperequetes = new List<clsReqtyperequete>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  TR_CODETYEREQUETE, NR_CODENATUREREQUETE, TR_LIBELLETYEREQUETE, TR_STATUT FROM dbo.FT_REQTYPEREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqtyperequete clsReqtyperequete = new clsReqtyperequete();
					clsReqtyperequete.TR_CODETYEREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["TR_CODETYEREQUETE"].ToString();
					clsReqtyperequete.NR_CODENATUREREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["NR_CODENATUREREQUETE"].ToString();
					clsReqtyperequete.TR_LIBELLETYEREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["TR_LIBELLETYEREQUETE"].ToString();
					clsReqtyperequete.TR_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["TR_STATUT"].ToString();
					clsReqtyperequetes.Add(clsReqtyperequete);
				}
				Dataset.Dispose();
			}
		return clsReqtyperequetes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : TR_CODETYEREQUETE, NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQTYPEREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : TR_CODETYEREQUETE, NR_CODENATUREREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TR_CODETYEREQUETE , TR_LIBELLETYEREQUETE, NR_CODENATUREREQUETE FROM dbo.FT_REQTYPEREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :TR_CODETYEREQUETE, NR_CODENATUREREQUETE)</summary>
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
				this.vapCritere ="WHERE TR_CODETYEREQUETE=@TR_CODETYEREQUETE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TR_CODETYEREQUETE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE TR_CODETYEREQUETE=@TR_CODETYEREQUETE AND NR_CODENATUREREQUETE=@NR_CODENATUREREQUETE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@TR_CODETYEREQUETE","@NR_CODENATUREREQUETE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
