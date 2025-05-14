using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.Tools.Classes;
using MgRequeteClients.DAL.Interfaces;
using MgRequeteClients.BOJ.BusinessObjects;

namespace MgRequeteClients.DAL.Classes
{
	public class clsReqmicclientWSDAL: ITableDAL<clsReqmicclient>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CL_IDCLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(CL_IDCLIENT) AS CL_IDCLIENT  FROM dbo.FT_REQMICCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CL_IDCLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(CL_IDCLIENT) AS CL_IDCLIENT  FROM dbo.FT_REQMICCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CL_IDCLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(CL_IDCLIENT) AS CL_IDCLIENT  FROM dbo.REQMICCLIENT " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CL_IDCLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqmicclient comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqmicclient pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CL_CODECLIENT  , CL_CODECLIENTZENITH  , AG_CODEAGENCE  , PV_CODEPOINTVENTE  , CL_DATESAISIE  , CL_REGISTRECOMMERCE  , CL_NUMEROCOMPTECONTRIBUABLE  FROM dbo.FT_REQMICCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqmicclient clsReqmicclient = new clsReqmicclient();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqmicclient.CL_CODECLIENT = clsDonnee.vogDataReader["CL_CODECLIENT"].ToString();
					clsReqmicclient.CL_CODECLIENTZENITH = clsDonnee.vogDataReader["CL_CODECLIENTZENITH"].ToString();
					clsReqmicclient.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsReqmicclient.PV_CODEPOINTVENTE = clsDonnee.vogDataReader["PV_CODEPOINTVENTE"].ToString();
					clsReqmicclient.CL_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["CL_DATESAISIE"].ToString());
					clsReqmicclient.CL_REGISTRECOMMERCE = clsDonnee.vogDataReader["CL_REGISTRECOMMERCE"].ToString();
					clsReqmicclient.CL_NUMEROCOMPTECONTRIBUABLE = clsDonnee.vogDataReader["CL_NUMEROCOMPTECONTRIBUABLE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqmicclient;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqmicclient>clsReqmicclient</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsReqmicclient clsReqmicclient)
		{
			//Préparation des paramètres
			SqlParameter vppParamCL_IDCLIENT = new SqlParameter("@CL_IDCLIENT", SqlDbType.VarChar, 25);
			vppParamCL_IDCLIENT.Value  = clsReqmicclient.CL_IDCLIENT ;
			SqlParameter vppParamCL_CODECLIENT = new SqlParameter("@CL_CODECLIENT", SqlDbType.VarChar, 1000);
			vppParamCL_CODECLIENT.Value  = clsReqmicclient.CL_CODECLIENT ;

			SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 1000);
            vppParamCU_CODECOMPTEUTULISATEUR.Value  = clsReqmicclient.CU_CODECOMPTEUTULISATEUR;

			SqlParameter vppParamCL_CODECLIENTZENITH = new SqlParameter("@CL_CODECLIENTZENITH", SqlDbType.VarChar, 1000);
			vppParamCL_CODECLIENTZENITH.Value  = clsReqmicclient.CL_CODECLIENTZENITH ;
			if(clsReqmicclient.CL_CODECLIENTZENITH== ""  ) vppParamCL_CODECLIENTZENITH.Value  = DBNull.Value;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsReqmicclient.AG_CODEAGENCE ;
			SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 25);
			vppParamPV_CODEPOINTVENTE.Value  = clsReqmicclient.PV_CODEPOINTVENTE ;
			SqlParameter vppParamCL_DATESAISIE = new SqlParameter("@CL_DATESAISIE", SqlDbType.DateTime);
			vppParamCL_DATESAISIE.Value  = clsReqmicclient.CL_DATESAISIE ;
			if(clsReqmicclient.CL_DATESAISIE.Year < 1900 ) vppParamCL_DATESAISIE.Value  = DateTime.Parse("01/01/1900");
			SqlParameter vppParamCL_REGISTRECOMMERCE = new SqlParameter("@CL_REGISTRECOMMERCE", SqlDbType.VarChar, 1000);
			vppParamCL_REGISTRECOMMERCE.Value  = clsReqmicclient.CL_REGISTRECOMMERCE ;
			if(clsReqmicclient.CL_REGISTRECOMMERCE== ""  ) vppParamCL_REGISTRECOMMERCE.Value  = DBNull.Value;
			SqlParameter vppParamCL_NUMEROCOMPTECONTRIBUABLE = new SqlParameter("@CL_NUMEROCOMPTECONTRIBUABLE", SqlDbType.VarChar, 1000);
			vppParamCL_NUMEROCOMPTECONTRIBUABLE.Value  = clsReqmicclient.CL_NUMEROCOMPTECONTRIBUABLE ;
			if(clsReqmicclient.CL_NUMEROCOMPTECONTRIBUABLE== ""  ) vppParamCL_NUMEROCOMPTECONTRIBUABLE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsReqmicclient.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQMICCLIENT  @CL_IDCLIENT, @CL_CODECLIENT, @CU_CODECOMPTEUTULISATEUR, @CL_CODECLIENTZENITH, @AG_CODEAGENCE, @PV_CODEPOINTVENTE, @CL_DATESAISIE, @CL_REGISTRECOMMERCE, @CL_NUMEROCOMPTECONTRIBUABLE, @CODECRYPTAGE1, @TYPEOPERATION ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCL_IDCLIENT);
			vppSqlCmd.Parameters.Add(vppParamCL_CODECLIENT);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamCL_CODECLIENTZENITH);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);
			vppSqlCmd.Parameters.Add(vppParamCL_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCL_REGISTRECOMMERCE);
			vppSqlCmd.Parameters.Add(vppParamCL_NUMEROCOMPTECONTRIBUABLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CL_IDCLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqmicclient>clsReqmicclient</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsReqmicclient clsReqmicclient,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamCL_IDCLIENT = new SqlParameter("@CL_IDCLIENT", SqlDbType.VarChar, 25);
			vppParamCL_IDCLIENT.Value  = clsReqmicclient.CL_IDCLIENT ;
			SqlParameter vppParamCL_CODECLIENT = new SqlParameter("@CL_CODECLIENT", SqlDbType.VarChar, 1000);
			vppParamCL_CODECLIENT.Value  = clsReqmicclient.CL_CODECLIENT ;
			SqlParameter vppParamCL_CODECLIENTZENITH = new SqlParameter("@CL_CODECLIENTZENITH", SqlDbType.VarChar, 1000);
			vppParamCL_CODECLIENTZENITH.Value  = clsReqmicclient.CL_CODECLIENTZENITH ;
			if(clsReqmicclient.CL_CODECLIENTZENITH== ""  ) vppParamCL_CODECLIENTZENITH.Value  = DBNull.Value;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsReqmicclient.AG_CODEAGENCE ;
			SqlParameter vppParamPV_CODEPOINTVENTE = new SqlParameter("@PV_CODEPOINTVENTE", SqlDbType.VarChar, 25);
			vppParamPV_CODEPOINTVENTE.Value  = clsReqmicclient.PV_CODEPOINTVENTE ;
			SqlParameter vppParamCL_DATESAISIE = new SqlParameter("@CL_DATESAISIE", SqlDbType.DateTime);
			vppParamCL_DATESAISIE.Value  = clsReqmicclient.CL_DATESAISIE ;
			if(clsReqmicclient.CL_DATESAISIE.Year < 1900 ) vppParamCL_DATESAISIE.Value  = DateTime.Parse("01/01/1900");
			SqlParameter vppParamCL_REGISTRECOMMERCE = new SqlParameter("@CL_REGISTRECOMMERCE", SqlDbType.VarChar, 1000);
			vppParamCL_REGISTRECOMMERCE.Value  = clsReqmicclient.CL_REGISTRECOMMERCE ;
			if(clsReqmicclient.CL_REGISTRECOMMERCE== ""  ) vppParamCL_REGISTRECOMMERCE.Value  = DBNull.Value;
			SqlParameter vppParamCL_NUMEROCOMPTECONTRIBUABLE = new SqlParameter("@CL_NUMEROCOMPTECONTRIBUABLE", SqlDbType.VarChar, 1000);
			vppParamCL_NUMEROCOMPTECONTRIBUABLE.Value  = clsReqmicclient.CL_NUMEROCOMPTECONTRIBUABLE ;
			if(clsReqmicclient.CL_NUMEROCOMPTECONTRIBUABLE== ""  ) vppParamCL_NUMEROCOMPTECONTRIBUABLE.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQMICCLIENT  @CL_IDCLIENT, @CL_CODECLIENT, @CL_CODECLIENTZENITH, @AG_CODEAGENCE, @PV_CODEPOINTVENTE, @CL_DATESAISIE, @CL_REGISTRECOMMERCE, @CL_NUMEROCOMPTECONTRIBUABLE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamCL_IDCLIENT);
			vppSqlCmd.Parameters.Add(vppParamCL_CODECLIENT);
			vppSqlCmd.Parameters.Add(vppParamCL_CODECLIENTZENITH);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPV_CODEPOINTVENTE);
			vppSqlCmd.Parameters.Add(vppParamCL_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamCL_REGISTRECOMMERCE);
			vppSqlCmd.Parameters.Add(vppParamCL_NUMEROCOMPTECONTRIBUABLE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CL_IDCLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQMICCLIENT  @CL_IDCLIENT, '' , '' , '' , '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CL_IDCLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqmicclient </returns>
		///<author>Home Technology</author>
		public List<clsReqmicclient> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CL_IDCLIENT, CL_CODECLIENT, CL_CODECLIENTZENITH, AG_CODEAGENCE, PV_CODEPOINTVENTE, CL_DATESAISIE, CL_REGISTRECOMMERCE, CL_NUMEROCOMPTECONTRIBUABLE FROM dbo.FT_REQMICCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqmicclient> clsReqmicclients = new List<clsReqmicclient>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqmicclient clsReqmicclient = new clsReqmicclient();
					clsReqmicclient.CL_IDCLIENT = clsDonnee.vogDataReader["CL_IDCLIENT"].ToString();
					clsReqmicclient.CL_CODECLIENT = clsDonnee.vogDataReader["CL_CODECLIENT"].ToString();
					clsReqmicclient.CL_CODECLIENTZENITH = clsDonnee.vogDataReader["CL_CODECLIENTZENITH"].ToString();
					clsReqmicclient.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsReqmicclient.PV_CODEPOINTVENTE = clsDonnee.vogDataReader["PV_CODEPOINTVENTE"].ToString();
					clsReqmicclient.CL_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["CL_DATESAISIE"].ToString());
					clsReqmicclient.CL_REGISTRECOMMERCE = clsDonnee.vogDataReader["CL_REGISTRECOMMERCE"].ToString();
					clsReqmicclient.CL_NUMEROCOMPTECONTRIBUABLE = clsDonnee.vogDataReader["CL_NUMEROCOMPTECONTRIBUABLE"].ToString();
					clsReqmicclients.Add(clsReqmicclient);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqmicclients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CL_IDCLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqmicclient </returns>
		///<author>Home Technology</author>
		public List<clsReqmicclient> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqmicclient> clsReqmicclients = new List<clsReqmicclient>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  CL_IDCLIENT, CL_CODECLIENT, CL_CODECLIENTZENITH, AG_CODEAGENCE, PV_CODEPOINTVENTE, CL_DATESAISIE, CL_REGISTRECOMMERCE, CL_NUMEROCOMPTECONTRIBUABLE FROM dbo.FT_REQMICCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqmicclient clsReqmicclient = new clsReqmicclient();
					clsReqmicclient.CL_IDCLIENT = Dataset.Tables["TABLE"].Rows[Idx]["CL_IDCLIENT"].ToString();
					clsReqmicclient.CL_CODECLIENT = Dataset.Tables["TABLE"].Rows[Idx]["CL_CODECLIENT"].ToString();
					clsReqmicclient.CL_CODECLIENTZENITH = Dataset.Tables["TABLE"].Rows[Idx]["CL_CODECLIENTZENITH"].ToString();
					clsReqmicclient.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsReqmicclient.PV_CODEPOINTVENTE = Dataset.Tables["TABLE"].Rows[Idx]["PV_CODEPOINTVENTE"].ToString();
					clsReqmicclient.CL_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CL_DATESAISIE"].ToString());
					clsReqmicclient.CL_REGISTRECOMMERCE = Dataset.Tables["TABLE"].Rows[Idx]["CL_REGISTRECOMMERCE"].ToString();
					clsReqmicclient.CL_NUMEROCOMPTECONTRIBUABLE = Dataset.Tables["TABLE"].Rows[Idx]["CL_NUMEROCOMPTECONTRIBUABLE"].ToString();
					clsReqmicclients.Add(clsReqmicclient);
				}
				Dataset.Dispose();
			}
		return clsReqmicclients;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CL_IDCLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQMICCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CL_IDCLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CL_IDCLIENT , CL_CODECLIENT FROM dbo.FT_REQMICCLIENT(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CL_IDCLIENT)</summary>
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
				this.vapCritere ="WHERE CL_IDCLIENT=@CL_IDCLIENT";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@CL_IDCLIENT"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
			}
		}
	}
}
