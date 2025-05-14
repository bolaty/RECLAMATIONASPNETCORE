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
	public class clsReqmicprospectWSDAL: ITableDAL<clsReqmicprospect>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(PR_IDPROSPECT) AS PR_IDPROSPECT  FROM dbo.FT_REQMICPROSPECT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(PR_IDPROSPECT) AS PR_IDPROSPECT  FROM dbo.FT_REQMICPROSPECT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(PR_IDPROSPECT) AS PR_IDPROSPECT  FROM dbo.REQMICPROSPECT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqmicprospect comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqmicprospect pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , PV_CODEPOINTVENTE  , CU_CODECOMPTEUTULISATEUR  , PR_DATESAISIE  , PR_REGISTRECOMMERCE  , PR_NUMEROCOMPTECONTRIBUABLE  FROM dbo.FT_REQMICPROSPECT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqmicprospect clsReqmicprospect = new clsReqmicprospect();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqmicprospect.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsReqmicprospect.PV_CODEPOINTVENTE = clsDonnee.vogDataReader["PV_CODEPOINTVENTE"].ToString();
					clsReqmicprospect.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsReqmicprospect.PR_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["PR_DATESAISIE"].ToString());
					clsReqmicprospect.PR_REGISTRECOMMERCE = clsDonnee.vogDataReader["PR_REGISTRECOMMERCE"].ToString();
					clsReqmicprospect.PR_NUMEROCOMPTECONTRIBUABLE = clsDonnee.vogDataReader["PR_NUMEROCOMPTECONTRIBUABLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqmicprospect;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqmicprospect>clsReqmicprospect</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsReqmicprospect clsReqmicprospect)
		{
			//Préparation des paramètres
			SqlParameter vppParamPR_IDPROSPECT = new SqlParameter("@PR_IDPROSPECT", SqlDbType.VarChar, 25);
			vppParamPR_IDPROSPECT.Value  = clsReqmicprospect.PR_IDPROSPECT ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsReqmicprospect.AG_CODEAGENCE ;
			SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 25);
			vppParamPV_CODEPOINTVENTE.Value  = clsReqmicprospect.PV_CODEPOINTVENTE ;
			SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
			vppParamCU_CODECOMPTEUTULISATEUR.Value  = clsReqmicprospect.CU_CODECOMPTEUTULISATEUR ;
			SqlParameter vppParamPR_DATESAISIE = new SqlParameter("@PR_DATESAISIE", SqlDbType.DateTime);
			vppParamPR_DATESAISIE.Value  = clsReqmicprospect.PR_DATESAISIE ;
			if(clsReqmicprospect.PR_DATESAISIE.Year < 1900 ) vppParamPR_DATESAISIE.Value  = DateTime.Parse("01/01/1900");
			SqlParameter vppParamPR_REGISTRECOMMERCE = new SqlParameter("@PR_REGISTRECOMMERCE", SqlDbType.VarChar, 1000);
			vppParamPR_REGISTRECOMMERCE.Value  = clsReqmicprospect.PR_REGISTRECOMMERCE ;
			if(clsReqmicprospect.PR_REGISTRECOMMERCE== ""  ) vppParamPR_REGISTRECOMMERCE.Value  = DBNull.Value;
			SqlParameter vppParamPR_NUMEROCOMPTECONTRIBUABLE = new SqlParameter("@PR_NUMEROCOMPTECONTRIBUABLE", SqlDbType.VarChar, 1000);
			vppParamPR_NUMEROCOMPTECONTRIBUABLE.Value  = clsReqmicprospect.PR_NUMEROCOMPTECONTRIBUABLE ;
			if(clsReqmicprospect.PR_NUMEROCOMPTECONTRIBUABLE== ""  ) vppParamPR_NUMEROCOMPTECONTRIBUABLE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;


            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsReqmicprospect.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQMICPROSPECT  @PR_IDPROSPECT, @AG_CODEAGENCE, @PV_CODEPOINTVENTE, @CU_CODECOMPTEUTULISATEUR, @PR_DATESAISIE, @PR_REGISTRECOMMERCE, @PR_NUMEROCOMPTECONTRIBUABLE, @CODECRYPTAGE1, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPR_IDPROSPECT);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamPR_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamPR_REGISTRECOMMERCE);
			vppSqlCmd.Parameters.Add(vppParamPR_NUMEROCOMPTECONTRIBUABLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqmicprospect>clsReqmicprospect</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsReqmicprospect clsReqmicprospect,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamPR_IDPROSPECT = new SqlParameter("@PR_IDPROSPECT", SqlDbType.VarChar, 25);
			vppParamPR_IDPROSPECT.Value  = clsReqmicprospect.PR_IDPROSPECT ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsReqmicprospect.AG_CODEAGENCE ;
			SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 25);
			vppParamPV_CODEPOINTVENTE.Value  = clsReqmicprospect.PV_CODEPOINTVENTE ;
			SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
			vppParamCU_CODECOMPTEUTULISATEUR.Value  = clsReqmicprospect.CU_CODECOMPTEUTULISATEUR ;
			SqlParameter vppParamPR_DATESAISIE = new SqlParameter("@PR_DATESAISIE", SqlDbType.DateTime);
			vppParamPR_DATESAISIE.Value  = clsReqmicprospect.PR_DATESAISIE ;
			if(clsReqmicprospect.PR_DATESAISIE.Year < 1900 ) vppParamPR_DATESAISIE.Value  = DateTime.Parse("01/01/1900");
			SqlParameter vppParamPR_REGISTRECOMMERCE = new SqlParameter("@PR_REGISTRECOMMERCE", SqlDbType.VarChar, 1000);
			vppParamPR_REGISTRECOMMERCE.Value  = clsReqmicprospect.PR_REGISTRECOMMERCE ;
			if(clsReqmicprospect.PR_REGISTRECOMMERCE== ""  ) vppParamPR_REGISTRECOMMERCE.Value  = DBNull.Value;
			SqlParameter vppParamPR_NUMEROCOMPTECONTRIBUABLE = new SqlParameter("@PR_NUMEROCOMPTECONTRIBUABLE", SqlDbType.VarChar, 1000);
			vppParamPR_NUMEROCOMPTECONTRIBUABLE.Value  = clsReqmicprospect.PR_NUMEROCOMPTECONTRIBUABLE ;
			if(clsReqmicprospect.PR_NUMEROCOMPTECONTRIBUABLE== ""  ) vppParamPR_NUMEROCOMPTECONTRIBUABLE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQMICPROSPECT  @PR_IDPROSPECT, @AG_CODEAGENCE, @PV_CODEPOINTVENTE, @CU_CODECOMPTEUTULISATEUR, @PR_DATESAISIE, @PR_REGISTRECOMMERCE, @PR_NUMEROCOMPTECONTRIBUABLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamPR_IDPROSPECT);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamPR_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamPR_REGISTRECOMMERCE);
			vppSqlCmd.Parameters.Add(vppParamPR_NUMEROCOMPTECONTRIBUABLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQMICPROSPECT  @PR_IDPROSPECT, @AG_CODEAGENCE, @PV_CODEPOINTVENTE, @CU_CODECOMPTEUTULISATEUR, '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqmicprospect </returns>
		///<author>Home Technology</author>
		public List<clsReqmicprospect> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR, PR_DATESAISIE, PR_REGISTRECOMMERCE, PR_NUMEROCOMPTECONTRIBUABLE FROM dbo.FT_REQMICPROSPECT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqmicprospect> clsReqmicprospects = new List<clsReqmicprospect>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqmicprospect clsReqmicprospect = new clsReqmicprospect();
					clsReqmicprospect.PR_IDPROSPECT = clsDonnee.vogDataReader["PR_IDPROSPECT"].ToString();
					clsReqmicprospect.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsReqmicprospect.PV_CODEPOINTVENTE = clsDonnee.vogDataReader["PV_CODEPOINTVENTE"].ToString();
					clsReqmicprospect.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsReqmicprospect.PR_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["PR_DATESAISIE"].ToString());
					clsReqmicprospect.PR_REGISTRECOMMERCE = clsDonnee.vogDataReader["PR_REGISTRECOMMERCE"].ToString();
					clsReqmicprospect.PR_NUMEROCOMPTECONTRIBUABLE = clsDonnee.vogDataReader["PR_NUMEROCOMPTECONTRIBUABLE"].ToString();
					clsReqmicprospects.Add(clsReqmicprospect);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqmicprospects;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqmicprospect </returns>
		///<author>Home Technology</author>
		public List<clsReqmicprospect> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqmicprospect> clsReqmicprospects = new List<clsReqmicprospect>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR, PR_DATESAISIE, PR_REGISTRECOMMERCE, PR_NUMEROCOMPTECONTRIBUABLE FROM dbo.FT_REQMICPROSPECT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqmicprospect clsReqmicprospect = new clsReqmicprospect();
					clsReqmicprospect.PR_IDPROSPECT = Dataset.Tables["TABLE"].Rows[Idx]["PR_IDPROSPECT"].ToString();
					clsReqmicprospect.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsReqmicprospect.PV_CODEPOINTVENTE = Dataset.Tables["TABLE"].Rows[Idx]["PV_CODEPOINTVENTE"].ToString();
					clsReqmicprospect.CU_CODECOMPTEUTULISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsReqmicprospect.PR_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PR_DATESAISIE"].ToString());
					clsReqmicprospect.PR_REGISTRECOMMERCE = Dataset.Tables["TABLE"].Rows[Idx]["PR_REGISTRECOMMERCE"].ToString();
					clsReqmicprospect.PR_NUMEROCOMPTECONTRIBUABLE = Dataset.Tables["TABLE"].Rows[Idx]["PR_NUMEROCOMPTECONTRIBUABLE"].ToString();
					clsReqmicprospects.Add(clsReqmicprospect);
				}
				Dataset.Dispose();
			}
		return clsReqmicprospects;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQMICPROSPECT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT PR_IDPROSPECT , PR_DATESAISIE FROM dbo.FT_REQMICPROSPECT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR)</summary>
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
				this.vapCritere ="WHERE PR_IDPROSPECT=@PR_IDPROSPECT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PR_IDPROSPECT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE PR_IDPROSPECT=@PR_IDPROSPECT AND AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PR_IDPROSPECT","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE PR_IDPROSPECT=@PR_IDPROSPECT AND AG_CODEAGENCE=@AG_CODEAGENCE AND PV_CODEPOINTVENTE=@PV_CODEPOINTVENTE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PR_IDPROSPECT","@AG_CODEAGENCE","@PV_CODEPOINTVENTE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE PR_IDPROSPECT=@PR_IDPROSPECT AND AG_CODEAGENCE=@AG_CODEAGENCE AND PV_CODEPOINTVENTE=@PV_CODEPOINTVENTE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@PR_IDPROSPECT","@AG_CODEAGENCE","@PV_CODEPOINTVENTE","@CU_CODECOMPTEUTULISATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
