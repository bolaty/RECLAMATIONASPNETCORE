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
	public class clsReqrequeteetapeWSDAL: ITableDAL<clsReqrequeteetape>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(AT_INDEXETAPE) AS AT_INDEXETAPE  FROM dbo.FT_REQREQUETEETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(AT_INDEXETAPE) AS AT_INDEXETAPE  FROM dbo.FT_REQREQUETEETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(AT_INDEXETAPE) AS AT_INDEXETAPE  FROM dbo.REQREQUETEETAPE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqrequeteetape comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqrequeteetape pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AG_CODEAGENCE  , RQ_CODEREQUETE  , CU_CODECOMPTEUTULISATEURAGENTENCHARGE  , RE_CODEETAPE  , AT_NUMEROORDRE  , AT_DESCRIPTION  , RQ_DATESAISIE  , AT_DATEDEBUTTRAITEMENTETAPE  , AT_DATEFINTRAITEMENTETAPE  , AT_DATECLOTUREETAPE  , NS_CODENIVEAUSATISFACTION  FROM dbo.FT_REQREQUETEETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqrequeteetape clsReqrequeteetape = new clsReqrequeteetape();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqrequeteetape.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsReqrequeteetape.RQ_CODEREQUETE = clsDonnee.vogDataReader["RQ_CODEREQUETE"].ToString();
					clsReqrequeteetape.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
					clsReqrequeteetape.RE_CODEETAPE = clsDonnee.vogDataReader["RE_CODEETAPE"].ToString();
					clsReqrequeteetape.AT_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["AT_NUMEROORDRE"].ToString());
					clsReqrequeteetape.AT_DESCRIPTION = clsDonnee.vogDataReader["AT_DESCRIPTION"].ToString();
					clsReqrequeteetape.RQ_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["RQ_DATESAISIE"].ToString());
					clsReqrequeteetape.AT_DATEDEBUTTRAITEMENTETAPE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEDEBUTTRAITEMENTETAPE"].ToString());
					clsReqrequeteetape.AT_DATEFINTRAITEMENTETAPE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEFINTRAITEMENTETAPE"].ToString());
					clsReqrequeteetape.AT_DATECLOTUREETAPE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATECLOTUREETAPE"].ToString());
					clsReqrequeteetape.NS_CODENIVEAUSATISFACTION = clsDonnee.vogDataReader["NS_CODENIVEAUSATISFACTION"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqrequeteetape;
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqrequeteetape>clsReqrequeteetape</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsReqrequeteetape clsReqrequeteetape)
        {
            //Préparation des paramètres
            SqlParameter vppParamAT_INDEXETAPE = new SqlParameter("@AT_INDEXETAPE", SqlDbType.VarChar, 50);
            vppParamAT_INDEXETAPE.Value = clsReqrequeteetape.AT_INDEXETAPE;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsReqrequeteetape.AG_CODEAGENCE;
            SqlParameter vppParamRQ_CODEREQUETE = new SqlParameter("@RQ_CODEREQUETE", SqlDbType.VarChar, 50);
            vppParamRQ_CODEREQUETE.Value = clsReqrequeteetape.RQ_CODEREQUETE;
            SqlParameter vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE = new SqlParameter("@CU_CODECOMPTEUTULISATEURAGENTENCHARGE", SqlDbType.VarChar, 50);
            vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE.Value = clsReqrequeteetape.CU_CODECOMPTEUTULISATEURAGENTENCHARGE;
            SqlParameter vppParamRE_CODEETAPE = new SqlParameter("@RE_CODEETAPE", SqlDbType.VarChar, 50);
            vppParamRE_CODEETAPE.Value = clsReqrequeteetape.RE_CODEETAPE;
            SqlParameter vppParamAT_NUMEROORDRE = new SqlParameter("@AT_NUMEROORDRE", SqlDbType.Int);
            vppParamAT_NUMEROORDRE.Value = clsReqrequeteetape.AT_NUMEROORDRE;
            SqlParameter vppParamAT_DESCRIPTION = new SqlParameter("@AT_DESCRIPTION", SqlDbType.VarChar, 1000);
            vppParamAT_DESCRIPTION.Value = clsReqrequeteetape.AT_DESCRIPTION;
            if (clsReqrequeteetape.AT_DESCRIPTION == "") vppParamAT_DESCRIPTION.Value = DBNull.Value;
            SqlParameter vppParamRQ_DATESAISIE = new SqlParameter("@RQ_DATESAISIE", SqlDbType.DateTime);
            vppParamRQ_DATESAISIE.Value = clsReqrequeteetape.RQ_DATESAISIE;
            SqlParameter vppParamAT_DATEDEBUTTRAITEMENTETAPE = new SqlParameter("@AT_DATEDEBUTTRAITEMENTETAPE", SqlDbType.DateTime);
            vppParamAT_DATEDEBUTTRAITEMENTETAPE.Value = clsReqrequeteetape.AT_DATEDEBUTTRAITEMENTETAPE;
            SqlParameter vppParamAT_DATEFINTRAITEMENTETAPE = new SqlParameter("@AT_DATEFINTRAITEMENTETAPE", SqlDbType.DateTime);
            vppParamAT_DATEFINTRAITEMENTETAPE.Value = clsReqrequeteetape.AT_DATEFINTRAITEMENTETAPE;
            SqlParameter vppParamAT_DATECLOTUREETAPE = new SqlParameter("@AT_DATECLOTUREETAPE", SqlDbType.DateTime);
            vppParamAT_DATECLOTUREETAPE.Value = clsReqrequeteetape.AT_DATECLOTUREETAPE;

            SqlParameter vppParamNS_CODENIVEAUSATISFACTION = new SqlParameter("@NS_CODENIVEAUSATISFACTION", SqlDbType.VarChar, 3);
            vppParamNS_CODENIVEAUSATISFACTION.Value = clsReqrequeteetape.NS_CODENIVEAUSATISFACTION;
            if (clsReqrequeteetape.NS_CODENIVEAUSATISFACTION == "") vppParamNS_CODENIVEAUSATISFACTION.Value = DBNull.Value;

            SqlParameter vppParamAT_OBSERVATION = new SqlParameter("@AT_OBSERVATION", SqlDbType.VarChar, 1000);
            vppParamAT_OBSERVATION.Value = clsReqrequeteetape.AT_OBSERVATION;
            if (clsReqrequeteetape.AT_OBSERVATION == "") vppParamAT_OBSERVATION.Value = DBNull.Value;

            SqlParameter vppParamAT_NOMRAPPORT = new SqlParameter("@AT_NOMRAPPORT", SqlDbType.VarChar, 1000);
            vppParamAT_NOMRAPPORT.Value = clsReqrequeteetape.AT_NOMRAPPORT;
            if (clsReqrequeteetape.AT_NOMRAPPORT == "") vppParamAT_NOMRAPPORT.Value = DBNull.Value;

            SqlParameter vppParamAT_ACTIF = new SqlParameter("@AT_ACTIF", SqlDbType.VarChar, 2);
            vppParamAT_ACTIF.Value = clsReqrequeteetape.AT_ACTIF;
            if (clsReqrequeteetape.AT_ACTIF == "") vppParamAT_ACTIF.Value = DBNull.Value;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsReqrequeteetape.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQREQUETEETAPE  @AT_INDEXETAPE, @AG_CODEAGENCE, @RQ_CODEREQUETE, @CU_CODECOMPTEUTULISATEURAGENTENCHARGE, @RE_CODEETAPE, @AT_NUMEROORDRE, @AT_DESCRIPTION, @RQ_DATESAISIE, @AT_DATEDEBUTTRAITEMENTETAPE, @AT_DATEFINTRAITEMENTETAPE, @AT_DATECLOTUREETAPE, @NS_CODENIVEAUSATISFACTION,@AT_OBSERVATION,@AT_NOMRAPPORT,@AT_ACTIF, @CODECRYPTAGE1, @TYPEOPERATION ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAT_INDEXETAPE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamRQ_CODEREQUETE);
            vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE);
            vppSqlCmd.Parameters.Add(vppParamRE_CODEETAPE);
            vppSqlCmd.Parameters.Add(vppParamAT_NUMEROORDRE);
            vppSqlCmd.Parameters.Add(vppParamAT_DESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamRQ_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEDEBUTTRAITEMENTETAPE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATEFINTRAITEMENTETAPE);
            vppSqlCmd.Parameters.Add(vppParamAT_DATECLOTUREETAPE);
            vppSqlCmd.Parameters.Add(vppParamNS_CODENIVEAUSATISFACTION);
            vppSqlCmd.Parameters.Add(vppParamAT_OBSERVATION);
            vppSqlCmd.Parameters.Add(vppParamAT_NOMRAPPORT);
            vppSqlCmd.Parameters.Add(vppParamAT_ACTIF);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqrequeteetape>clsReqrequeteetape</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsReqrequeteetape clsReqrequeteetape,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamAT_INDEXETAPE = new SqlParameter("@AT_INDEXETAPE", SqlDbType.VarChar, 50);
			vppParamAT_INDEXETAPE.Value  = clsReqrequeteetape.AT_INDEXETAPE ;
			SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
			vppParamAG_CODEAGENCE.Value  = clsReqrequeteetape.AG_CODEAGENCE ;
			SqlParameter vppParamRQ_CODEREQUETE = new SqlParameter("@RQ_CODEREQUETE", SqlDbType.VarChar, 50);
			vppParamRQ_CODEREQUETE.Value  = clsReqrequeteetape.RQ_CODEREQUETE ;
			SqlParameter vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE = new SqlParameter("@CU_CODECOMPTEUTULISATEURAGENTENCHARGE", SqlDbType.VarChar, 50);
			vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE.Value  = clsReqrequeteetape.CU_CODECOMPTEUTULISATEURAGENTENCHARGE ;
			SqlParameter vppParamRE_CODEETAPE = new SqlParameter("@RE_CODEETAPE", SqlDbType.DateTime);
			vppParamRE_CODEETAPE.Value  = clsReqrequeteetape.RE_CODEETAPE ;
			SqlParameter vppParamAT_NUMEROORDRE = new SqlParameter("@AT_NUMEROORDRE", SqlDbType.Int);
			vppParamAT_NUMEROORDRE.Value  = clsReqrequeteetape.AT_NUMEROORDRE ;
			SqlParameter vppParamAT_DESCRIPTION = new SqlParameter("@AT_DESCRIPTION", SqlDbType.VarChar, 1000);
			vppParamAT_DESCRIPTION.Value  = clsReqrequeteetape.AT_DESCRIPTION ;
			if(clsReqrequeteetape.AT_DESCRIPTION== ""  ) vppParamAT_DESCRIPTION.Value  = DBNull.Value;
			SqlParameter vppParamRQ_DATESAISIE = new SqlParameter("@RQ_DATESAISIE", SqlDbType.DateTime);
			vppParamRQ_DATESAISIE.Value  = clsReqrequeteetape.RQ_DATESAISIE ;
			SqlParameter vppParamAT_DATEDEBUTTRAITEMENTETAPE = new SqlParameter("@AT_DATEDEBUTTRAITEMENTETAPE", SqlDbType.DateTime);
			vppParamAT_DATEDEBUTTRAITEMENTETAPE.Value  = clsReqrequeteetape.AT_DATEDEBUTTRAITEMENTETAPE ;
			SqlParameter vppParamAT_DATEFINTRAITEMENTETAPE = new SqlParameter("@AT_DATEFINTRAITEMENTETAPE", SqlDbType.DateTime);
			vppParamAT_DATEFINTRAITEMENTETAPE.Value  = clsReqrequeteetape.AT_DATEFINTRAITEMENTETAPE ;
			SqlParameter vppParamAT_DATECLOTUREETAPE = new SqlParameter("@AT_DATECLOTUREETAPE", SqlDbType.DateTime);
			vppParamAT_DATECLOTUREETAPE.Value  = clsReqrequeteetape.AT_DATECLOTUREETAPE ;
			SqlParameter vppParamNS_CODENIVEAUSATISFACTION = new SqlParameter("@NS_CODENIVEAUSATISFACTION", SqlDbType.VarChar, 3);
			vppParamNS_CODENIVEAUSATISFACTION.Value  = clsReqrequeteetape.NS_CODENIVEAUSATISFACTION ;
			if(clsReqrequeteetape.NS_CODENIVEAUSATISFACTION== ""  ) vppParamNS_CODENIVEAUSATISFACTION.Value  = DBNull.Value;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQREQUETEETAPE  @AT_INDEXETAPE, @AG_CODEAGENCE, @RQ_CODEREQUETE, @CU_CODECOMPTEUTULISATEURAGENTENCHARGE, @RE_CODEETAPE, @AT_NUMEROORDRE, @AT_DESCRIPTION, @RQ_DATESAISIE, @AT_DATEDEBUTTRAITEMENTETAPE, @AT_DATEFINTRAITEMENTETAPE, @AT_DATECLOTUREETAPE, @NS_CODENIVEAUSATISFACTION, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAT_INDEXETAPE);
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODEREQUETE);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE);
			vppSqlCmd.Parameters.Add(vppParamRE_CODEETAPE);
			vppSqlCmd.Parameters.Add(vppParamAT_NUMEROORDRE);
			vppSqlCmd.Parameters.Add(vppParamAT_DESCRIPTION);
			vppSqlCmd.Parameters.Add(vppParamRQ_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamAT_DATEDEBUTTRAITEMENTETAPE);
			vppSqlCmd.Parameters.Add(vppParamAT_DATEFINTRAITEMENTETAPE);
			vppSqlCmd.Parameters.Add(vppParamAT_DATECLOTUREETAPE);
			vppSqlCmd.Parameters.Add(vppParamNS_CODENIVEAUSATISFACTION);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQREQUETEETAPE  @AT_INDEXETAPE, @AG_CODEAGENCE, @RQ_CODEREQUETE, @CU_CODECOMPTEUTULISATEURAGENTENCHARGE, @RE_CODEETAPE, '' , '' , '' , '' , '' , '' , @NS_CODENIVEAUSATISFACTION, @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqrequeteetape </returns>
		///<author>Home Technology</author>
		public List<clsReqrequeteetape> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, AT_NUMEROORDRE, AT_DESCRIPTION, RQ_DATESAISIE, AT_DATEDEBUTTRAITEMENTETAPE, AT_DATEFINTRAITEMENTETAPE, AT_DATECLOTUREETAPE, NS_CODENIVEAUSATISFACTION FROM dbo.FT_REQREQUETEETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqrequeteetape> clsReqrequeteetapes = new List<clsReqrequeteetape>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqrequeteetape clsReqrequeteetape = new clsReqrequeteetape();
					clsReqrequeteetape.AT_INDEXETAPE = clsDonnee.vogDataReader["AT_INDEXETAPE"].ToString();
					clsReqrequeteetape.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsReqrequeteetape.RQ_CODEREQUETE = clsDonnee.vogDataReader["RQ_CODEREQUETE"].ToString();
					clsReqrequeteetape.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
					clsReqrequeteetape.RE_CODEETAPE = clsDonnee.vogDataReader["RE_CODEETAPE"].ToString();
					clsReqrequeteetape.AT_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["AT_NUMEROORDRE"].ToString());
					clsReqrequeteetape.AT_DESCRIPTION = clsDonnee.vogDataReader["AT_DESCRIPTION"].ToString();
					clsReqrequeteetape.RQ_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["RQ_DATESAISIE"].ToString());
					clsReqrequeteetape.AT_DATEDEBUTTRAITEMENTETAPE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEDEBUTTRAITEMENTETAPE"].ToString());
					clsReqrequeteetape.AT_DATEFINTRAITEMENTETAPE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATEFINTRAITEMENTETAPE"].ToString());
					clsReqrequeteetape.AT_DATECLOTUREETAPE = DateTime.Parse(clsDonnee.vogDataReader["AT_DATECLOTUREETAPE"].ToString());
					clsReqrequeteetape.NS_CODENIVEAUSATISFACTION = clsDonnee.vogDataReader["NS_CODENIVEAUSATISFACTION"].ToString();
					clsReqrequeteetapes.Add(clsReqrequeteetape);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqrequeteetapes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqrequeteetape </returns>
		///<author>Home Technology</author>
		public List<clsReqrequeteetape> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqrequeteetape> clsReqrequeteetapes = new List<clsReqrequeteetape>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, AT_NUMEROORDRE, AT_DESCRIPTION, RQ_DATESAISIE, AT_DATEDEBUTTRAITEMENTETAPE, AT_DATEFINTRAITEMENTETAPE, AT_DATECLOTUREETAPE, NS_CODENIVEAUSATISFACTION FROM dbo.FT_REQREQUETEETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqrequeteetape clsReqrequeteetape = new clsReqrequeteetape();
					clsReqrequeteetape.AT_INDEXETAPE = Dataset.Tables["TABLE"].Rows[Idx]["AT_INDEXETAPE"].ToString();
					clsReqrequeteetape.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsReqrequeteetape.RQ_CODEREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_CODEREQUETE"].ToString();
					clsReqrequeteetape.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = Dataset.Tables["TABLE"].Rows[Idx]["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
					clsReqrequeteetape.RE_CODEETAPE = Dataset.Tables["TABLE"].Rows[Idx]["RE_CODEETAPE"].ToString();
					clsReqrequeteetape.AT_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_NUMEROORDRE"].ToString());
					clsReqrequeteetape.AT_DESCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["AT_DESCRIPTION"].ToString();
					clsReqrequeteetape.RQ_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RQ_DATESAISIE"].ToString());
					clsReqrequeteetape.AT_DATEDEBUTTRAITEMENTETAPE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATEDEBUTTRAITEMENTETAPE"].ToString());
					clsReqrequeteetape.AT_DATEFINTRAITEMENTETAPE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATEFINTRAITEMENTETAPE"].ToString());
					clsReqrequeteetape.AT_DATECLOTUREETAPE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["AT_DATECLOTUREETAPE"].ToString());
					clsReqrequeteetape.NS_CODENIVEAUSATISFACTION = Dataset.Tables["TABLE"].Rows[Idx]["NS_CODENIVEAUSATISFACTION"].ToString();
					clsReqrequeteetapes.Add(clsReqrequeteetape);
				}
				Dataset.Dispose();
			}
		return clsReqrequeteetapes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQREQUETEETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgListeReqrequeteEtapeparRequete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereSelonRequete(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_REQREQUETEETAPE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgListeReqrequeteDoc(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritereSelonRequete(clsDonnee, vppCritere);

            this.vapCritere = "WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@RQ_CODEREQUETE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };

            this.vapRequete = "SELECT *  FROM dbo.REQREQUETEDOC " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgListeReqrequeteContentieuxDoc(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritereSelonRequete(clsDonnee, vppCritere);

            this.vapCritere = "WHERE CT_CODEREQUETECONTENTIEUX=@CT_CODEREQUETECONTENTIEUX";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@CT_CODEREQUETECONTENTIEUX" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[1] };

            this.vapRequete = "SELECT *  FROM dbo.REQUETECONTENTIEUXDOC " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgInfosDuClient(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereSelonUtilisateur(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_REQINFOSUTILISATEUR(@CODECRYPTAGE, @CU_CODECOMPTEUTULISATEUR) "; // + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgInfosDuClientNew(clsDonnee clsDonnee, params string[] vppCritere)
        {
            // pvpChoixCritereSelonUtilisateurNew(clsDonnee, vppCritere);
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@CU_CODECOMPTEUTULISATEUR", "@CU_CODECOMPTEUTULISATEURASSOCIER" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
            this.vapRequete = "EXEC dbo.SP_REQINFOSUTILISATEUR @CODECRYPTAGE ,@CU_CODECOMPTEUTULISATEUR ,@CU_CODECOMPTEUTULISATEURASSOCIER "; // + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetTraitement(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@RQ_CODEREQUETE", "@CU_CODECOMPTEUTULISATEURAGENTENCHARGE", "@TR_CODETYEREQUETE", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
            this.vapRequete = "EXEC [dbo].[PS_REQREQUETEETAPE] @AG_CODEAGENCE ,@RQ_CODEREQUETE ,@CU_CODECOMPTEUTULISATEURAGENTENCHARGE, @TR_CODETYEREQUETE,	@TYPEOPERATION,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        // laaa
        public DataSet pvgChargerDansDataSetTraitementDoc(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AT_INDEXETAPE", "@AG_CODEAGENCE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
            this.vapRequete = "SELECT * FROM REQREQUETEETAPEDOC WHERE AT_INDEXETAPE=@AT_INDEXETAPE AND AG_CODEAGENCE=@AG_CODEAGENCE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        //public DataSet pvgChargerDansDataSetTraitementDoc(clsDonnee clsDonnee, params string[] vppCritere)
        //{
        //    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@RQ_CODEREQUETE", "@TR_CODETYEREQUETE", "@TYPEOPERATION" };
        //    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
        //    this.vapRequete = "EXEC [dbo].[PS_REQREQUETEDOC] @AG_CODEAGENCE ,@RQ_CODEREQUETE , @TR_CODETYEREQUETE,	@TYPEOPERATION,@CODECRYPTAGE";
        //    this.vapCritere = "";
        //    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //    return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        //}
        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : AC_CODEACTIVITE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête</param>
        ///<param name="clsActivite">clsActivite</param>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetHistorique(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere2(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_REQREQUETE(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT AT_INDEXETAPE , AT_DESCRIPTION FROM dbo.FT_REQREQUETEETAPE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereSelonRequete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@RQ_CODEREQUETE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                
            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereSelonUtilisateur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 2:
                    this.vapCritere = "WHERE CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@CU_CODECOMPTEUTULISATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;

            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION)</summary>
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
				this.vapCritere ="WHERE AT_INDEXETAPE=@AT_INDEXETAPE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AT_INDEXETAPE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE AT_INDEXETAPE=@AT_INDEXETAPE AND AG_CODEAGENCE=@AG_CODEAGENCE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AT_INDEXETAPE","@AG_CODEAGENCE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE AT_INDEXETAPE=@AT_INDEXETAPE AND AG_CODEAGENCE=@AG_CODEAGENCE AND RQ_CODEREQUETE=@RQ_CODEREQUETE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AT_INDEXETAPE","@AG_CODEAGENCE","@RQ_CODEREQUETE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE AT_INDEXETAPE=@AT_INDEXETAPE AND AG_CODEAGENCE=@AG_CODEAGENCE AND RQ_CODEREQUETE=@RQ_CODEREQUETE AND CU_CODECOMPTEUTULISATEURAGENTENCHARGE=@CU_CODECOMPTEUTULISATEURAGENTENCHARGE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AT_INDEXETAPE","@AG_CODEAGENCE","@RQ_CODEREQUETE","@CU_CODECOMPTEUTULISATEURAGENTENCHARGE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE AT_INDEXETAPE=@AT_INDEXETAPE AND AG_CODEAGENCE=@AG_CODEAGENCE AND RQ_CODEREQUETE=@RQ_CODEREQUETE AND CU_CODECOMPTEUTULISATEURAGENTENCHARGE=@CU_CODECOMPTEUTULISATEURAGENTENCHARGE AND RE_CODEETAPE=@RE_CODEETAPE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AT_INDEXETAPE","@AG_CODEAGENCE","@RQ_CODEREQUETE","@CU_CODECOMPTEUTULISATEURAGENTENCHARGE","@RE_CODEETAPE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE AT_INDEXETAPE=@AT_INDEXETAPE AND AG_CODEAGENCE=@AG_CODEAGENCE AND RQ_CODEREQUETE=@RQ_CODEREQUETE AND CU_CODECOMPTEUTULISATEURAGENTENCHARGE=@CU_CODECOMPTEUTULISATEURAGENTENCHARGE AND RE_CODEETAPE=@RE_CODEETAPE AND NS_CODENIVEAUSATISFACTION=@NS_CODENIVEAUSATISFACTION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AT_INDEXETAPE","@AG_CODEAGENCE","@RQ_CODEREQUETE","@CU_CODECOMPTEUTULISATEURAGENTENCHARGE","@RE_CODEETAPE","@NS_CODENIVEAUSATISFACTION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere2(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
           
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND RQ_CODEREQUETE=@RQ_CODEREQUETE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@RQ_CODEREQUETE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
            }
        }
    }
}
