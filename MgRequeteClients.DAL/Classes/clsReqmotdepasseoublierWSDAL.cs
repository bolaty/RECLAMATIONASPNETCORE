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
	public class clsReqmotdepasseoublierWSDAL: ITableDAL<clsReqmotdepasseoublier>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MO_DATE, MO_NUMEROSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_REQMOTDEPASSEOUBLIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MO_DATE, MO_NUMEROSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_REQMOTDEPASSEOUBLIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MO_DATE, MO_NUMEROSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AG_CODEAGENCE) AS AG_CODEAGENCE  FROM dbo.FT_REQMOTDEPASSEOUBLIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MO_DATE, MO_NUMEROSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqmotdepasseoublier comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqmotdepasseoublier pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT CU_CODECOMPTEUTULISATEUR  , MO_CONTACT  , MO_HEURE  , MO_CODEVALIDATION  , MO_DATEVALIDATION  FROM dbo.FT_REQMOTDEPASSEOUBLIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqmotdepasseoublier clsReqmotdepasseoublier = new clsReqmotdepasseoublier();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqmotdepasseoublier.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsReqmotdepasseoublier.MO_CONTACT = clsDonnee.vogDataReader["MO_CONTACT"].ToString();
					clsReqmotdepasseoublier.MO_HEURE = DateTime.Parse(clsDonnee.vogDataReader["MO_HEURE"].ToString());
					clsReqmotdepasseoublier.MO_CODEVALIDATION = clsDonnee.vogDataReader["MO_CODEVALIDATION"].ToString();
					clsReqmotdepasseoublier.MO_DATEVALIDATION = DateTime.Parse(clsDonnee.vogDataReader["MO_DATEVALIDATION"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqmotdepasseoublier;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqmotdepasseoublier>clsReqmotdepasseoublier</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsReqmotdepasseoublier clsReqmotdepasseoublier)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsReqmotdepasseoublier.AG_CODEAGENCE ;
			SqlParameter vppParamMO_DATE = new SqlParameter("@MO_DATE", SqlDbType.DateTime);
			vppParamMO_DATE.Value  = clsReqmotdepasseoublier.MO_DATE ;
			SqlParameter vppParamMO_NUMEROSEQUENCE = new SqlParameter("@MO_NUMEROSEQUENCE", SqlDbType.Int);
			vppParamMO_NUMEROSEQUENCE.Value  = clsReqmotdepasseoublier.MO_NUMEROSEQUENCE ;
			SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
			vppParamCU_CODECOMPTEUTULISATEUR.Value  = clsReqmotdepasseoublier.CU_CODECOMPTEUTULISATEUR ;
			SqlParameter vppParamMO_CONTACT = new SqlParameter("@MO_CONTACT", SqlDbType.VarChar, 100);
			vppParamMO_CONTACT.Value  = clsReqmotdepasseoublier.MO_CONTACT ;
			SqlParameter vppParamMO_HEURE = new SqlParameter("@MO_HEURE", SqlDbType.DateTime);
			vppParamMO_HEURE.Value  = clsReqmotdepasseoublier.MO_HEURE ;
			SqlParameter vppParamMO_CODEVALIDATION = new SqlParameter("@MO_CODEVALIDATION", SqlDbType.VarChar, 1000);
			vppParamMO_CODEVALIDATION.Value  = clsReqmotdepasseoublier.MO_CODEVALIDATION ;
			if(clsReqmotdepasseoublier.MO_CODEVALIDATION== ""  ) vppParamMO_CODEVALIDATION.Value  = DBNull.Value;
			SqlParameter vppParamMO_DATEVALIDATION = new SqlParameter("@MO_DATEVALIDATION", SqlDbType.DateTime);
			vppParamMO_DATEVALIDATION.Value  = clsReqmotdepasseoublier.MO_DATEVALIDATION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQMOTDEPASSEOUBLIER  @AG_CODEAGENCE, @MO_DATE, @MO_NUMEROSEQUENCE, @CU_CODECOMPTEUTULISATEUR, @MO_CONTACT, @MO_HEURE, @MO_CODEVALIDATION, @MO_DATEVALIDATION, @CODECRYPTAGE, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMO_DATE);
			vppSqlCmd.Parameters.Add(vppParamMO_NUMEROSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamMO_CONTACT);
			vppSqlCmd.Parameters.Add(vppParamMO_HEURE);
			vppSqlCmd.Parameters.Add(vppParamMO_CODEVALIDATION);
			vppSqlCmd.Parameters.Add(vppParamMO_DATEVALIDATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MO_DATE, MO_NUMEROSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqmotdepasseoublier>clsReqmotdepasseoublier</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsReqmotdepasseoublier clsReqmotdepasseoublier,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsReqmotdepasseoublier.AG_CODEAGENCE ;
			SqlParameter vppParamMO_DATE = new SqlParameter("@MO_DATE", SqlDbType.DateTime);
			vppParamMO_DATE.Value  = clsReqmotdepasseoublier.MO_DATE ;
			SqlParameter vppParamMO_NUMEROSEQUENCE = new SqlParameter("@MO_NUMEROSEQUENCE", SqlDbType.Int);
			vppParamMO_NUMEROSEQUENCE.Value  = clsReqmotdepasseoublier.MO_NUMEROSEQUENCE ;
			SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
			vppParamCU_CODECOMPTEUTULISATEUR.Value  = clsReqmotdepasseoublier.CU_CODECOMPTEUTULISATEUR ;
			SqlParameter vppParamMO_CONTACT = new SqlParameter("@MO_CONTACT", SqlDbType.VarChar, 100);
			vppParamMO_CONTACT.Value  = clsReqmotdepasseoublier.MO_CONTACT ;
			SqlParameter vppParamMO_HEURE = new SqlParameter("@MO_HEURE", SqlDbType.DateTime);
			vppParamMO_HEURE.Value  = clsReqmotdepasseoublier.MO_HEURE ;
			SqlParameter vppParamMO_CODEVALIDATION = new SqlParameter("@MO_CODEVALIDATION", SqlDbType.VarChar, 1000);
			vppParamMO_CODEVALIDATION.Value  = clsReqmotdepasseoublier.MO_CODEVALIDATION ;
			if(clsReqmotdepasseoublier.MO_CODEVALIDATION== ""  ) vppParamMO_CODEVALIDATION.Value  = DBNull.Value;
			SqlParameter vppParamMO_DATEVALIDATION = new SqlParameter("@MO_DATEVALIDATION", SqlDbType.DateTime);
			vppParamMO_DATEVALIDATION.Value  = clsReqmotdepasseoublier.MO_DATEVALIDATION ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQMOTDEPASSEOUBLIER  @AG_CODEAGENCE, @MO_DATE, @MO_NUMEROSEQUENCE, @CU_CODECOMPTEUTULISATEUR, @MO_CONTACT, @MO_HEURE, @MO_CODEVALIDATION, @MO_DATEVALIDATION, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamMO_DATE);
			vppSqlCmd.Parameters.Add(vppParamMO_NUMEROSEQUENCE);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamMO_CONTACT);
			vppSqlCmd.Parameters.Add(vppParamMO_HEURE);
			vppSqlCmd.Parameters.Add(vppParamMO_CODEVALIDATION);
			vppSqlCmd.Parameters.Add(vppParamMO_DATEVALIDATION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MO_DATE, MO_NUMEROSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQMOTDEPASSEOUBLIER  @AG_CODEAGENCE, @MO_DATE, @MO_NUMEROSEQUENCE, @CU_CODECOMPTEUTULISATEUR, '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MO_DATE, MO_NUMEROSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqmotdepasseoublier </returns>
		///<author>Home Technology</author>
		public List<clsReqmotdepasseoublier> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, MO_DATE, MO_NUMEROSEQUENCE, CU_CODECOMPTEUTULISATEUR, MO_CONTACT, MO_HEURE, MO_CODEVALIDATION, MO_DATEVALIDATION FROM dbo.FT_REQMOTDEPASSEOUBLIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqmotdepasseoublier> clsReqmotdepasseoubliers = new List<clsReqmotdepasseoublier>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqmotdepasseoublier clsReqmotdepasseoublier = new clsReqmotdepasseoublier();
					clsReqmotdepasseoublier.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsReqmotdepasseoublier.MO_DATE = DateTime.Parse(clsDonnee.vogDataReader["MO_DATE"].ToString());
					clsReqmotdepasseoublier.MO_NUMEROSEQUENCE = int.Parse(clsDonnee.vogDataReader["MO_NUMEROSEQUENCE"].ToString());
					clsReqmotdepasseoublier.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsReqmotdepasseoublier.MO_CONTACT = clsDonnee.vogDataReader["MO_CONTACT"].ToString();
					clsReqmotdepasseoublier.MO_HEURE = DateTime.Parse(clsDonnee.vogDataReader["MO_HEURE"].ToString());
					clsReqmotdepasseoublier.MO_CODEVALIDATION = clsDonnee.vogDataReader["MO_CODEVALIDATION"].ToString();
					clsReqmotdepasseoublier.MO_DATEVALIDATION = DateTime.Parse(clsDonnee.vogDataReader["MO_DATEVALIDATION"].ToString());
					clsReqmotdepasseoubliers.Add(clsReqmotdepasseoublier);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqmotdepasseoubliers;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MO_DATE, MO_NUMEROSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqmotdepasseoublier </returns>
		///<author>Home Technology</author>
		public List<clsReqmotdepasseoublier> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqmotdepasseoublier> clsReqmotdepasseoubliers = new List<clsReqmotdepasseoublier>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AG_CODEAGENCE, MO_DATE, MO_NUMEROSEQUENCE, CU_CODECOMPTEUTULISATEUR, MO_CONTACT, MO_HEURE, MO_CODEVALIDATION, MO_DATEVALIDATION FROM dbo.FT_REQMOTDEPASSEOUBLIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqmotdepasseoublier clsReqmotdepasseoublier = new clsReqmotdepasseoublier();
					clsReqmotdepasseoublier.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsReqmotdepasseoublier.MO_DATE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_DATE"].ToString());
					clsReqmotdepasseoublier.MO_NUMEROSEQUENCE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_NUMEROSEQUENCE"].ToString());
					clsReqmotdepasseoublier.CU_CODECOMPTEUTULISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsReqmotdepasseoublier.MO_CONTACT = Dataset.Tables["TABLE"].Rows[Idx]["MO_CONTACT"].ToString();
					clsReqmotdepasseoublier.MO_HEURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_HEURE"].ToString());
					clsReqmotdepasseoublier.MO_CODEVALIDATION = Dataset.Tables["TABLE"].Rows[Idx]["MO_CODEVALIDATION"].ToString();
					clsReqmotdepasseoublier.MO_DATEVALIDATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_DATEVALIDATION"].ToString());
					clsReqmotdepasseoubliers.Add(clsReqmotdepasseoublier);
				}
				Dataset.Dispose();
			}
		return clsReqmotdepasseoubliers;
		}




        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTILISATEUR, AN_CODEANTENNE, AG_CODEAGENT, TU_CODETYPECOMPTEUTILISATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgForgotPassword(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //clsMotdepasseoublier.MO_CONTACT, clsMotdepasseoublier.MO_CODEVALIDATION, clsMotdepasseoublier.TU_CODETYPEUTILISATEUR, clsMotdepasseoublier.CU_MOTDEPASSE , clsMotdepasseoublier.TYPEOPERATION
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@MO_CONTACT", "@MO_CODEVALIDATION", "@TU_CODETYPEUTILISATEUR", "@CU_CODECOMPTEUTILISATEUR", "@CU_MOTDEPASSE", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
            this.vapRequete = "EXEC PS_MOTDEPASSEOUBLIER @MO_CONTACT,@MO_CODEVALIDATION,@TU_CODETYPEUTILISATEUR,@CU_CODECOMPTEUTILISATEUR, @CU_MOTDEPASSE, @CODECRYPTAGE, @TYPEOPERATION    ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

       

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MO_DATE, MO_NUMEROSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQMOTDEPASSEOUBLIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, MO_DATE, MO_NUMEROSEQUENCE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE , MO_CONTACT FROM dbo.FT_REQMOTDEPASSEOUBLIER(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, MO_DATE, MO_NUMEROSEQUENCE, CU_CODECOMPTEUTULISATEUR)</summary>
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
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MO_DATE=@MO_DATE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MO_DATE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MO_DATE=@MO_DATE AND MO_NUMEROSEQUENCE=@MO_NUMEROSEQUENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MO_DATE","@MO_NUMEROSEQUENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND MO_DATE=@MO_DATE AND MO_NUMEROSEQUENCE=@MO_NUMEROSEQUENCE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE","@MO_DATE","@MO_NUMEROSEQUENCE","@CU_CODECOMPTEUTULISATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
			}
		}
	}
}
