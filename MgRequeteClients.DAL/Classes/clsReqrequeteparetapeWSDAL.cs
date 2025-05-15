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
	public class clsReqrequeteparetapeWSDAL: ITableDAL<clsReqrequeteparetape>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : RE_CODEETAPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(RE_CODEETAPE) AS RE_CODEETAPE  FROM dbo.FT_REQREQUETEPARETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : RE_CODEETAPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(RE_CODEETAPE) AS RE_CODEETAPE  FROM dbo.FT_REQREQUETEPARETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : RE_CODEETAPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(RE_CODEETAPE) AS RE_CODEETAPE  FROM dbo.FT_REQREQUETEPARETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODEETAPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqrequeteparetape comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqrequeteparetape pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RE_LIBELLEETAPE  , RE_ACTIF  FROM dbo.FT_REQREQUETEPARETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqrequeteparetape clsReqrequeteparetape = new clsReqrequeteparetape();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqrequeteparetape.RE_LIBELLEETAPE = clsDonnee.vogDataReader["RE_LIBELLEETAPE"].ToString();
					clsReqrequeteparetape.RE_ACTIF = clsDonnee.vogDataReader["RE_ACTIF"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqrequeteparetape;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqrequeteparetape>clsReqrequeteparetape</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsReqrequeteparetape clsReqrequeteparetape)
		{
			//Préparation des paramètres
			SqlParameter vppParamRE_CODEETAPE = new SqlParameter("@RE_CODEETAPE", SqlDbType.VarChar, 50);
			vppParamRE_CODEETAPE.Value  = clsReqrequeteparetape.RE_CODEETAPE ;
			SqlParameter vppParamRE_LIBELLEETAPE = new SqlParameter("@RE_LIBELLEETAPE", SqlDbType.VarChar, 1000);
			vppParamRE_LIBELLEETAPE.Value  = clsReqrequeteparetape.RE_LIBELLEETAPE ;
			SqlParameter vppParamRE_ACTIF = new SqlParameter("@RE_ACTIF", SqlDbType.VarChar, 1);
			vppParamRE_ACTIF.Value  = clsReqrequeteparetape.RE_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsReqrequeteparetape.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQREQUETEPARETAPE  @RE_CODEETAPE, @RE_LIBELLEETAPE, @RE_ACTIF, @CODECRYPTAGE1, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRE_CODEETAPE);
			vppSqlCmd.Parameters.Add(vppParamRE_LIBELLEETAPE);
			vppSqlCmd.Parameters.Add(vppParamRE_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : RE_CODEETAPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqrequeteparetape>clsReqrequeteparetape</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsReqrequeteparetape clsReqrequeteparetape,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamRE_CODEETAPE = new SqlParameter("@RE_CODEETAPE", SqlDbType.VarChar, 50);
			vppParamRE_CODEETAPE.Value  = clsReqrequeteparetape.RE_CODEETAPE ;
			SqlParameter vppParamRE_LIBELLEETAPE = new SqlParameter("@RE_LIBELLEETAPE", SqlDbType.VarChar, 1000);
			vppParamRE_LIBELLEETAPE.Value  = clsReqrequeteparetape.RE_LIBELLEETAPE ;
			SqlParameter vppParamRE_ACTIF = new SqlParameter("@RE_ACTIF", SqlDbType.VarChar, 1);
			vppParamRE_ACTIF.Value  = clsReqrequeteparetape.RE_ACTIF ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQREQUETEPARETAPE  @RE_CODEETAPE, @RE_LIBELLEETAPE, @RE_ACTIF, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRE_CODEETAPE);
			vppSqlCmd.Parameters.Add(vppParamRE_LIBELLEETAPE);
			vppSqlCmd.Parameters.Add(vppParamRE_ACTIF);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : RE_CODEETAPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQREQUETEPARETAPE  @RE_CODEETAPE, '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODEETAPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqrequeteparetape </returns>
		///<author>Home Technology</author>
		public List<clsReqrequeteparetape> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RE_CODEETAPE, RE_LIBELLEETAPE, RE_ACTIF FROM dbo.FT_REQREQUETEPARETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqrequeteparetape> clsReqrequeteparetapes = new List<clsReqrequeteparetape>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqrequeteparetape clsReqrequeteparetape = new clsReqrequeteparetape();
					clsReqrequeteparetape.RE_CODEETAPE = clsDonnee.vogDataReader["RE_CODEETAPE"].ToString();
					clsReqrequeteparetape.RE_LIBELLEETAPE = clsDonnee.vogDataReader["RE_LIBELLEETAPE"].ToString();
					clsReqrequeteparetape.RE_ACTIF = clsDonnee.vogDataReader["RE_ACTIF"].ToString();
					clsReqrequeteparetapes.Add(clsReqrequeteparetape);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqrequeteparetapes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODEETAPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqrequeteparetape </returns>
		///<author>Home Technology</author>
		public List<clsReqrequeteparetape> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqrequeteparetape> clsReqrequeteparetapes = new List<clsReqrequeteparetape>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RE_CODEETAPE, RE_LIBELLEETAPE, RE_ACTIF FROM dbo.FT_REQREQUETEPARETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqrequeteparetape clsReqrequeteparetape = new clsReqrequeteparetape();
					clsReqrequeteparetape.RE_CODEETAPE = Dataset.Tables["TABLE"].Rows[Idx]["RE_CODEETAPE"].ToString();
					clsReqrequeteparetape.RE_LIBELLEETAPE = Dataset.Tables["TABLE"].Rows[Idx]["RE_LIBELLEETAPE"].ToString();
					clsReqrequeteparetape.RE_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["RE_ACTIF"].ToString();
					clsReqrequeteparetapes.Add(clsReqrequeteparetape);
				}
				Dataset.Dispose();
			}
		return clsReqrequeteparetapes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RE_CODEETAPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQREQUETEPARETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : RE_CODEETAPE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RE_CODEETAPE , RE_LIBELLEETAPE,RE_ACTIF FROM dbo.FT_REQREQUETEPARETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RE_CODEETAPE)</summary>
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
				this.vapCritere ="WHERE RE_CODEETAPE=@RE_CODEETAPE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RE_CODEETAPE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
