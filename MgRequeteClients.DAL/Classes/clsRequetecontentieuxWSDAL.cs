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
	public class clsRequetecontentieuxWSDAL: ITableDAL<clsRequetecontentieux>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CT_CODEREQUETECONTENTIEUX, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CT_CODEREQUETECONTENTIEUX) AS CT_CODEREQUETECONTENTIEUX  FROM dbo.FT_REQUETECONTENTIEUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CT_CODEREQUETECONTENTIEUX, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CT_CODEREQUETECONTENTIEUX) AS CT_CODEREQUETECONTENTIEUX  FROM dbo.FT_REQUETECONTENTIEUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CT_CODEREQUETECONTENTIEUX, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CT_CODEREQUETECONTENTIEUX) AS CT_CODEREQUETECONTENTIEUX  FROM dbo.REQUETECONTENTIEUX " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODEREQUETECONTENTIEUX, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsRequetecontentieux comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsRequetecontentieux pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RQ_CODEREQUETE  , CT_DATEOUVERTURECONTENTIEUX  , CT_DATECLOTURECONTENTIEUX  , CT_MONTANTCONTENTIEUXEXTIME  , CT_MONTANTCONTENTIEUXREEL  , CT_OBSERVATION1  , CT_OBSERVATION2  , FICHIERSJOINT  FROM dbo.FT_REQUETECONTENTIEUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsRequetecontentieux clsRequetecontentieux = new clsRequetecontentieux();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsRequetecontentieux.RQ_CODEREQUETE = clsDonnee.vogDataReader["RQ_CODEREQUETE"].ToString();
					clsRequetecontentieux.CT_DATEOUVERTURECONTENTIEUX = DateTime.Parse(clsDonnee.vogDataReader["CT_DATEOUVERTURECONTENTIEUX"].ToString());
					clsRequetecontentieux.CT_DATECLOTURECONTENTIEUX = DateTime.Parse(clsDonnee.vogDataReader["CT_DATECLOTURECONTENTIEUX"].ToString());
					clsRequetecontentieux.CT_MONTANTCONTENTIEUXEXTIME = double.Parse(clsDonnee.vogDataReader["CT_MONTANTCONTENTIEUXEXTIME"].ToString());
					clsRequetecontentieux.CT_MONTANTCONTENTIEUXREEL = double.Parse(clsDonnee.vogDataReader["CT_MONTANTCONTENTIEUXREEL"].ToString());
					clsRequetecontentieux.CT_OBSERVATION1 = clsDonnee.vogDataReader["CT_OBSERVATION1"].ToString();
					clsRequetecontentieux.CT_OBSERVATION2 = clsDonnee.vogDataReader["CT_OBSERVATION2"].ToString();
					clsRequetecontentieux.FICHIERSJOINT = clsDonnee.vogDataReader["FICHIERSJOINT"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsRequetecontentieux;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsRequetecontentieux>clsRequetecontentieux</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsRequetecontentieux clsRequetecontentieux)
		{
			//Préparation des paramètres
			SqlParameter vppParamCT_CODEREQUETECONTENTIEUX = new SqlParameter("@CT_CODEREQUETECONTENTIEUX", SqlDbType.VarChar, 50);
			vppParamCT_CODEREQUETECONTENTIEUX.Value  = clsRequetecontentieux.CT_CODEREQUETECONTENTIEUX ;
			SqlParameter vppParamRQ_CODEREQUETE = new SqlParameter("@RQ_CODEREQUETE", SqlDbType.VarChar, 50);
			vppParamRQ_CODEREQUETE.Value  = clsRequetecontentieux.RQ_CODEREQUETE ;
			SqlParameter vppParamCT_DATEOUVERTURECONTENTIEUX = new SqlParameter("@CT_DATEOUVERTURECONTENTIEUX", SqlDbType.DateTime);
			vppParamCT_DATEOUVERTURECONTENTIEUX.Value  = clsRequetecontentieux.CT_DATEOUVERTURECONTENTIEUX ;
			SqlParameter vppParamCT_DATECLOTURECONTENTIEUX = new SqlParameter("@CT_DATECLOTURECONTENTIEUX", SqlDbType.DateTime);
			vppParamCT_DATECLOTURECONTENTIEUX.Value  = clsRequetecontentieux.CT_DATECLOTURECONTENTIEUX ;
			SqlParameter vppParamCT_MONTANTCONTENTIEUXEXTIME = new SqlParameter("@CT_MONTANTCONTENTIEUXEXTIME", SqlDbType.Money);
			vppParamCT_MONTANTCONTENTIEUXEXTIME.Value  = clsRequetecontentieux.CT_MONTANTCONTENTIEUXEXTIME ;
			SqlParameter vppParamCT_MONTANTCONTENTIEUXREEL = new SqlParameter("@CT_MONTANTCONTENTIEUXREEL", SqlDbType.Money);
			vppParamCT_MONTANTCONTENTIEUXREEL.Value  = clsRequetecontentieux.CT_MONTANTCONTENTIEUXREEL ;
			SqlParameter vppParamCT_OBSERVATION1 = new SqlParameter("@CT_OBSERVATION1", SqlDbType.VarChar, 1000);
			vppParamCT_OBSERVATION1.Value  = clsRequetecontentieux.CT_OBSERVATION1 ;
			if(clsRequetecontentieux.CT_OBSERVATION1== ""  ) vppParamCT_OBSERVATION1.Value  = DBNull.Value;
			SqlParameter vppParamCT_OBSERVATION2 = new SqlParameter("@CT_OBSERVATION2", SqlDbType.VarChar, 1000);
			vppParamCT_OBSERVATION2.Value  = clsRequetecontentieux.CT_OBSERVATION2 ;
			if(clsRequetecontentieux.CT_OBSERVATION2== ""  ) vppParamCT_OBSERVATION2.Value  = DBNull.Value;
			SqlParameter vppParamFICHIERSJOINT = new SqlParameter("@FICHIERSJOINT", SqlDbType.VarChar, 1000);
			vppParamFICHIERSJOINT.Value  = clsRequetecontentieux.FICHIERSJOINT ;
			if(clsRequetecontentieux.FICHIERSJOINT== ""  ) vppParamFICHIERSJOINT.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsRequetecontentieux.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQUETECONTENTIEUX  @CT_CODEREQUETECONTENTIEUX, @RQ_CODEREQUETE, @CT_DATEOUVERTURECONTENTIEUX, @CT_DATECLOTURECONTENTIEUX, @CT_MONTANTCONTENTIEUXEXTIME, @CT_MONTANTCONTENTIEUXREEL, @CT_OBSERVATION1, @CT_OBSERVATION2, @FICHIERSJOINT, @CODECRYPTAGE1, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCT_CODEREQUETECONTENTIEUX);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODEREQUETE);
			vppSqlCmd.Parameters.Add(vppParamCT_DATEOUVERTURECONTENTIEUX);
			vppSqlCmd.Parameters.Add(vppParamCT_DATECLOTURECONTENTIEUX);
			vppSqlCmd.Parameters.Add(vppParamCT_MONTANTCONTENTIEUXEXTIME);
			vppSqlCmd.Parameters.Add(vppParamCT_MONTANTCONTENTIEUXREEL);
			vppSqlCmd.Parameters.Add(vppParamCT_OBSERVATION1);
			vppSqlCmd.Parameters.Add(vppParamCT_OBSERVATION2);
			vppSqlCmd.Parameters.Add(vppParamFICHIERSJOINT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CT_CODEREQUETECONTENTIEUX, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsRequetecontentieux>clsRequetecontentieux</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsRequetecontentieux clsRequetecontentieux,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCT_CODEREQUETECONTENTIEUX = new SqlParameter("@CT_CODEREQUETECONTENTIEUX", SqlDbType.VarChar, 50);
			vppParamCT_CODEREQUETECONTENTIEUX.Value  = clsRequetecontentieux.CT_CODEREQUETECONTENTIEUX ;
			SqlParameter vppParamRQ_CODEREQUETE = new SqlParameter("@RQ_CODEREQUETE", SqlDbType.VarChar, 50);
			vppParamRQ_CODEREQUETE.Value  = clsRequetecontentieux.RQ_CODEREQUETE ;
			SqlParameter vppParamCT_DATEOUVERTURECONTENTIEUX = new SqlParameter("@CT_DATEOUVERTURECONTENTIEUX", SqlDbType.DateTime);
			vppParamCT_DATEOUVERTURECONTENTIEUX.Value  = clsRequetecontentieux.CT_DATEOUVERTURECONTENTIEUX ;
			SqlParameter vppParamCT_DATECLOTURECONTENTIEUX = new SqlParameter("@CT_DATECLOTURECONTENTIEUX", SqlDbType.DateTime);
			vppParamCT_DATECLOTURECONTENTIEUX.Value  = clsRequetecontentieux.CT_DATECLOTURECONTENTIEUX ;
			SqlParameter vppParamCT_MONTANTCONTENTIEUXEXTIME = new SqlParameter("@CT_MONTANTCONTENTIEUXEXTIME", SqlDbType.Money);
			vppParamCT_MONTANTCONTENTIEUXEXTIME.Value  = clsRequetecontentieux.CT_MONTANTCONTENTIEUXEXTIME ;
			SqlParameter vppParamCT_MONTANTCONTENTIEUXREEL = new SqlParameter("@CT_MONTANTCONTENTIEUXREEL", SqlDbType.Money);
			vppParamCT_MONTANTCONTENTIEUXREEL.Value  = clsRequetecontentieux.CT_MONTANTCONTENTIEUXREEL ;
			SqlParameter vppParamCT_OBSERVATION1 = new SqlParameter("@CT_OBSERVATION1", SqlDbType.VarChar, 1000);
			vppParamCT_OBSERVATION1.Value  = clsRequetecontentieux.CT_OBSERVATION1 ;
			if(clsRequetecontentieux.CT_OBSERVATION1== ""  ) vppParamCT_OBSERVATION1.Value  = DBNull.Value;
			SqlParameter vppParamCT_OBSERVATION2 = new SqlParameter("@CT_OBSERVATION2", SqlDbType.VarChar, 1000);
			vppParamCT_OBSERVATION2.Value  = clsRequetecontentieux.CT_OBSERVATION2 ;
			if(clsRequetecontentieux.CT_OBSERVATION2== ""  ) vppParamCT_OBSERVATION2.Value  = DBNull.Value;
			SqlParameter vppParamFICHIERSJOINT = new SqlParameter("@FICHIERSJOINT", SqlDbType.VarChar, 1000);
			vppParamFICHIERSJOINT.Value  = clsRequetecontentieux.FICHIERSJOINT ;
			if(clsRequetecontentieux.FICHIERSJOINT== ""  ) vppParamFICHIERSJOINT.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQUETECONTENTIEUX  @CT_CODEREQUETECONTENTIEUX, @RQ_CODEREQUETE, @CT_DATEOUVERTURECONTENTIEUX, @CT_DATECLOTURECONTENTIEUX, @CT_MONTANTCONTENTIEUXEXTIME, @CT_MONTANTCONTENTIEUXREEL, @CT_OBSERVATION1, @CT_OBSERVATION2, @FICHIERSJOINT, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCT_CODEREQUETECONTENTIEUX);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODEREQUETE);
			vppSqlCmd.Parameters.Add(vppParamCT_DATEOUVERTURECONTENTIEUX);
			vppSqlCmd.Parameters.Add(vppParamCT_DATECLOTURECONTENTIEUX);
			vppSqlCmd.Parameters.Add(vppParamCT_MONTANTCONTENTIEUXEXTIME);
			vppSqlCmd.Parameters.Add(vppParamCT_MONTANTCONTENTIEUXREEL);
			vppSqlCmd.Parameters.Add(vppParamCT_OBSERVATION1);
			vppSqlCmd.Parameters.Add(vppParamCT_OBSERVATION2);
			vppSqlCmd.Parameters.Add(vppParamFICHIERSJOINT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CT_CODEREQUETECONTENTIEUX, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQUETECONTENTIEUX  @CT_CODEREQUETECONTENTIEUX, @RQ_CODEREQUETE, '' , '' , '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODEREQUETECONTENTIEUX, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsRequetecontentieux </returns>
		///<author>Home Technology</author>
		public List<clsRequetecontentieux> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CT_CODEREQUETECONTENTIEUX, RQ_CODEREQUETE, CT_DATEOUVERTURECONTENTIEUX, CT_DATECLOTURECONTENTIEUX, CT_MONTANTCONTENTIEUXEXTIME, CT_MONTANTCONTENTIEUXREEL, CT_OBSERVATION1, CT_OBSERVATION2, FICHIERSJOINT FROM dbo.FT_REQUETECONTENTIEUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsRequetecontentieux> clsRequetecontentieuxs = new List<clsRequetecontentieux>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsRequetecontentieux clsRequetecontentieux = new clsRequetecontentieux();
					clsRequetecontentieux.CT_CODEREQUETECONTENTIEUX = clsDonnee.vogDataReader["CT_CODEREQUETECONTENTIEUX"].ToString();
					clsRequetecontentieux.RQ_CODEREQUETE = clsDonnee.vogDataReader["RQ_CODEREQUETE"].ToString();
					clsRequetecontentieux.CT_DATEOUVERTURECONTENTIEUX = DateTime.Parse(clsDonnee.vogDataReader["CT_DATEOUVERTURECONTENTIEUX"].ToString());
					clsRequetecontentieux.CT_DATECLOTURECONTENTIEUX = DateTime.Parse(clsDonnee.vogDataReader["CT_DATECLOTURECONTENTIEUX"].ToString());
					clsRequetecontentieux.CT_MONTANTCONTENTIEUXEXTIME = double.Parse(clsDonnee.vogDataReader["CT_MONTANTCONTENTIEUXEXTIME"].ToString());
					clsRequetecontentieux.CT_MONTANTCONTENTIEUXREEL = double.Parse(clsDonnee.vogDataReader["CT_MONTANTCONTENTIEUXREEL"].ToString());
					clsRequetecontentieux.CT_OBSERVATION1 = clsDonnee.vogDataReader["CT_OBSERVATION1"].ToString();
					clsRequetecontentieux.CT_OBSERVATION2 = clsDonnee.vogDataReader["CT_OBSERVATION2"].ToString();
					clsRequetecontentieux.FICHIERSJOINT = clsDonnee.vogDataReader["FICHIERSJOINT"].ToString();
					clsRequetecontentieuxs.Add(clsRequetecontentieux);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsRequetecontentieuxs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODEREQUETECONTENTIEUX, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsRequetecontentieux </returns>
		///<author>Home Technology</author>
		public List<clsRequetecontentieux> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsRequetecontentieux> clsRequetecontentieuxs = new List<clsRequetecontentieux>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CT_CODEREQUETECONTENTIEUX, RQ_CODEREQUETE, CT_DATEOUVERTURECONTENTIEUX, CT_DATECLOTURECONTENTIEUX, CT_MONTANTCONTENTIEUXEXTIME, CT_MONTANTCONTENTIEUXREEL, CT_OBSERVATION1, CT_OBSERVATION2, FICHIERSJOINT FROM dbo.FT_REQUETECONTENTIEUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsRequetecontentieux clsRequetecontentieux = new clsRequetecontentieux();
					clsRequetecontentieux.CT_CODEREQUETECONTENTIEUX = Dataset.Tables["TABLE"].Rows[Idx]["CT_CODEREQUETECONTENTIEUX"].ToString();
					clsRequetecontentieux.RQ_CODEREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_CODEREQUETE"].ToString();
					clsRequetecontentieux.CT_DATEOUVERTURECONTENTIEUX = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CT_DATEOUVERTURECONTENTIEUX"].ToString());
					clsRequetecontentieux.CT_DATECLOTURECONTENTIEUX = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CT_DATECLOTURECONTENTIEUX"].ToString());
					clsRequetecontentieux.CT_MONTANTCONTENTIEUXEXTIME = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CT_MONTANTCONTENTIEUXEXTIME"].ToString());
					clsRequetecontentieux.CT_MONTANTCONTENTIEUXREEL = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CT_MONTANTCONTENTIEUXREEL"].ToString());
					clsRequetecontentieux.CT_OBSERVATION1 = Dataset.Tables["TABLE"].Rows[Idx]["CT_OBSERVATION1"].ToString();
					clsRequetecontentieux.CT_OBSERVATION2 = Dataset.Tables["TABLE"].Rows[Idx]["CT_OBSERVATION2"].ToString();
					clsRequetecontentieux.FICHIERSJOINT = Dataset.Tables["TABLE"].Rows[Idx]["FICHIERSJOINT"].ToString();
					clsRequetecontentieuxs.Add(clsRequetecontentieux);
				}
				Dataset.Dispose();
			}
		return clsRequetecontentieuxs;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CT_CODEREQUETECONTENTIEUX, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQUETECONTENTIEUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CT_CODEREQUETECONTENTIEUX, RQ_CODEREQUETE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CT_CODEREQUETECONTENTIEUX , CT_OBSERVATION1 FROM dbo.FT_REQUETECONTENTIEUX(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CT_CODEREQUETECONTENTIEUX, RQ_CODEREQUETE)</summary>
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
				this.vapCritere ="WHERE CT_CODEREQUETECONTENTIEUX=@CT_CODEREQUETECONTENTIEUX";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CT_CODEREQUETECONTENTIEUX"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE CT_CODEREQUETECONTENTIEUX=@CT_CODEREQUETECONTENTIEUX AND RQ_CODEREQUETE=@RQ_CODEREQUETE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CT_CODEREQUETECONTENTIEUX","@RQ_CODEREQUETE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
