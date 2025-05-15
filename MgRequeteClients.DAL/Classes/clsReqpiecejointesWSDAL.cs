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
	public class clsReqpiecejointesWSDAL: ITableDAL<clsReqpiecejointes>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PJ_CODEPIECEJOINT, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PJ_CODEPIECEJOINT) AS PJ_CODEPIECEJOINT  FROM dbo.FT_REQPIECEJOINTES(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PJ_CODEPIECEJOINT, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PJ_CODEPIECEJOINT) AS PJ_CODEPIECEJOINT  FROM dbo.FT_REQPIECEJOINTES(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PJ_CODEPIECEJOINT, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PJ_CODEPIECEJOINT) AS PJ_CODEPIECEJOINT  FROM dbo.FT_REQPIECEJOINTES(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PJ_CODEPIECEJOINT, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqpiecejointes comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqpiecejointes pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RQ_CODEREQUETE  , PJ_NOMPIECEJOINT  FROM dbo.FT_REQPIECEJOINTES(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqpiecejointes clsReqpiecejointes = new clsReqpiecejointes();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqpiecejointes.RQ_CODEREQUETE = clsDonnee.vogDataReader["RQ_CODEREQUETE"].ToString();
					clsReqpiecejointes.PJ_NOMPIECEJOINT = clsDonnee.vogDataReader["PJ_NOMPIECEJOINT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqpiecejointes;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqpiecejointes>clsReqpiecejointes</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsReqpiecejointes clsReqpiecejointes)
		{
			//Préparation des paramètres
			SqlParameter vppParamPJ_CODEPIECEJOINT = new SqlParameter("@PJ_CODEPIECEJOINT", SqlDbType.VarChar, 50);
			vppParamPJ_CODEPIECEJOINT.Value  = clsReqpiecejointes.PJ_CODEPIECEJOINT ;
			SqlParameter vppParamRQ_CODEREQUETE = new SqlParameter("@RQ_CODEREQUETE", SqlDbType.VarChar, 50);
			vppParamRQ_CODEREQUETE.Value  = clsReqpiecejointes.RQ_CODEREQUETE ;
			SqlParameter vppParamPJ_NOMPIECEJOINT = new SqlParameter("@PJ_NOMPIECEJOINT", SqlDbType.VarChar, 1000);
			vppParamPJ_NOMPIECEJOINT.Value  = clsReqpiecejointes.PJ_NOMPIECEJOINT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQPIECEJOINTES  @PJ_CODEPIECEJOINT, @RQ_CODEREQUETE, @PJ_NOMPIECEJOINT, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPJ_CODEPIECEJOINT);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODEREQUETE);
			vppSqlCmd.Parameters.Add(vppParamPJ_NOMPIECEJOINT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PJ_CODEPIECEJOINT, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqpiecejointes>clsReqpiecejointes</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsReqpiecejointes clsReqpiecejointes,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPJ_CODEPIECEJOINT = new SqlParameter("@PJ_CODEPIECEJOINT", SqlDbType.VarChar, 50);
			vppParamPJ_CODEPIECEJOINT.Value  = clsReqpiecejointes.PJ_CODEPIECEJOINT ;
			SqlParameter vppParamRQ_CODEREQUETE = new SqlParameter("@RQ_CODEREQUETE", SqlDbType.VarChar, 50);
			vppParamRQ_CODEREQUETE.Value  = clsReqpiecejointes.RQ_CODEREQUETE ;
			SqlParameter vppParamPJ_NOMPIECEJOINT = new SqlParameter("@PJ_NOMPIECEJOINT", SqlDbType.VarChar, 1000);
			vppParamPJ_NOMPIECEJOINT.Value  = clsReqpiecejointes.PJ_NOMPIECEJOINT ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQPIECEJOINTES  @PJ_CODEPIECEJOINT, @RQ_CODEREQUETE, @PJ_NOMPIECEJOINT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPJ_CODEPIECEJOINT);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODEREQUETE);
			vppSqlCmd.Parameters.Add(vppParamPJ_NOMPIECEJOINT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PJ_CODEPIECEJOINT, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQPIECEJOINTES  @PJ_CODEPIECEJOINT, @RQ_CODEREQUETE, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PJ_CODEPIECEJOINT, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqpiecejointes </returns>
		///<author>Home Technology</author>
		public List<clsReqpiecejointes> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PJ_CODEPIECEJOINT, RQ_CODEREQUETE, PJ_NOMPIECEJOINT FROM dbo.FT_REQPIECEJOINTES(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqpiecejointes> clsReqpiecejointess = new List<clsReqpiecejointes>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqpiecejointes clsReqpiecejointes = new clsReqpiecejointes();
					clsReqpiecejointes.PJ_CODEPIECEJOINT = clsDonnee.vogDataReader["PJ_CODEPIECEJOINT"].ToString();
					clsReqpiecejointes.RQ_CODEREQUETE = clsDonnee.vogDataReader["RQ_CODEREQUETE"].ToString();
					clsReqpiecejointes.PJ_NOMPIECEJOINT = clsDonnee.vogDataReader["PJ_NOMPIECEJOINT"].ToString();
					clsReqpiecejointess.Add(clsReqpiecejointes);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqpiecejointess;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PJ_CODEPIECEJOINT, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqpiecejointes </returns>
		///<author>Home Technology</author>
		public List<clsReqpiecejointes> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqpiecejointes> clsReqpiecejointess = new List<clsReqpiecejointes>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PJ_CODEPIECEJOINT, RQ_CODEREQUETE, PJ_NOMPIECEJOINT FROM dbo.FT_REQPIECEJOINTES(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqpiecejointes clsReqpiecejointes = new clsReqpiecejointes();
					clsReqpiecejointes.PJ_CODEPIECEJOINT = Dataset.Tables["TABLE"].Rows[Idx]["PJ_CODEPIECEJOINT"].ToString();
					clsReqpiecejointes.RQ_CODEREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_CODEREQUETE"].ToString();
					clsReqpiecejointes.PJ_NOMPIECEJOINT = Dataset.Tables["TABLE"].Rows[Idx]["PJ_NOMPIECEJOINT"].ToString();
					clsReqpiecejointess.Add(clsReqpiecejointes);
				}
				Dataset.Dispose();
			}
		return clsReqpiecejointess;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PJ_CODEPIECEJOINT, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQPIECEJOINTES(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PJ_CODEPIECEJOINT, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PJ_CODEPIECEJOINT , PJ_NOMPIECEJOINT FROM dbo.FT_REQPIECEJOINTES(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PJ_CODEPIECEJOINT, RQ_CODEREQUETE)</summary>
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
				this.vapCritere ="WHERE PJ_CODEPIECEJOINT=@PJ_CODEPIECEJOINT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PJ_CODEPIECEJOINT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE PJ_CODEPIECEJOINT=@PJ_CODEPIECEJOINT AND RQ_CODEREQUETE=@RQ_CODEREQUETE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PJ_CODEPIECEJOINT","@RQ_CODEREQUETE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
