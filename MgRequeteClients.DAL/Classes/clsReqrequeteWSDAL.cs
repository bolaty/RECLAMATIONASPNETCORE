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
	public class clsReqrequeteWSDAL: ITableDAL<clsReqrequete>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(RQ_CODEREQUETE) AS RQ_CODEREQUETE  FROM dbo.FT_REQREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, LO_CODELOGICIEL ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		//public string pvgNomDeLaStructure(clsDonnee clsDonnee, clsReqrequete clsReqrequete)
  //      {
  //          SqlParameter vppParamPP_CODEPARAMETRE = new SqlParameter("@PP_CODEPARAMETRE", SqlDbType.VarChar, 50);
  //          vppParamPP_CODEPARAMETRE.Value = clsReqrequete.PP_CODEPARAMETRE;

  //          this.vapRequete = "SELECT PP_VALEUR  FROM dbo.PARAMETRE WHERE PP_CODEPARAMETRE=@PP_CODEPARAMETRE";
  //          //this.vapCritere = "";
  //          SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

  //          vppSqlCmd.Parameters.Add(vppParamPP_CODEPARAMETRE);

  //          return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
  //      }
        public DataSet pvgNomDeLaStructure(clsDonnee clsDonnee, clsReqrequete clsReqrequete)
        {
            SqlParameter vppParamPP_CODEPARAMETRE = new SqlParameter("@PP_CODEPARAMETRE", SqlDbType.VarChar, 50);
            vppParamPP_CODEPARAMETRE.Value = clsReqrequete.PP_CODEPARAMETRE;

            this.vapRequete = "SELECT PP_VALEUR  FROM dbo.PARAMETRE WHERE PP_CODEPARAMETRE=@PP_CODEPARAMETRE";
            //this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            vppSqlCmd.Parameters.Add(vppParamPP_CODEPARAMETRE);

            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(RQ_CODEREQUETE) AS RQ_CODEREQUETE  FROM dbo.FT_REQREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MAX(RQ_CODEREQUETE) AS RQ_CODEREQUETE  FROM dbo.REQREQUETE " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqrequete comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqrequete pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT TR_CODETYEREQUETE  , RQ_NUMEROREQUETE  , RQ_NUMERORECOMPTE  , CU_CODECOMPTEUTULISATEUR  , RQ_LOCALISATIONCLIENT  , RQ_DESCRIPTIONREQUETE  , MC_CODEMODECOLLETE  , RQ_DATESAISIEREQUETE  , CU_CODECOMPTEUTULISATEURAGENTENCHARGE  , RQ_DATETRANSFERTREQUETE  , RQ_CODEREQUETERELANCEE  , RQ_SIGNATURE  , RS_CODESTATUTRECEVABILITE  , RQ_OBJETREQUETE  , SR_CODESERVICE  , RQ_DELAITRAITEMENTREQUETE  , RQ_OBSERVATIONDELAITRAITEMENTREQUETE  , RQ_OBSERVATIONAGENTTRAITEMENTREQUETE  , RQ_DUREETRAITEMENTREQUETE  , RQ_DATEDEBUTTRAITEMENTREQUETE  , RQ_DATEFINTRAITEMENTREQUETE  , AC_CODEACTIONCORRECTIVE  , NS_CODENIVEAUSATISFACTION  , RQ_DATECLOTUREREQUETE  FROM dbo.FT_REQREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsReqrequete clsReqrequete = new clsReqrequete();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqrequete.TR_CODETYEREQUETE = clsDonnee.vogDataReader["TR_CODETYEREQUETE"].ToString();
					clsReqrequete.RQ_NUMEROREQUETE = clsDonnee.vogDataReader["RQ_NUMEROREQUETE"].ToString();
					clsReqrequete.RQ_NUMERORECOMPTE = clsDonnee.vogDataReader["RQ_NUMERORECOMPTE"].ToString();
					clsReqrequete.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsReqrequete.RQ_LOCALISATIONCLIENT = clsDonnee.vogDataReader["RQ_LOCALISATIONCLIENT"].ToString();
					clsReqrequete.RQ_DESCRIPTIONREQUETE = clsDonnee.vogDataReader["RQ_DESCRIPTIONREQUETE"].ToString();
					clsReqrequete.MC_CODEMODECOLLETE = clsDonnee.vogDataReader["MC_CODEMODECOLLETE"].ToString();
					clsReqrequete.RQ_DATESAISIEREQUETE = DateTime.Parse(clsDonnee.vogDataReader["RQ_DATESAISIEREQUETE"].ToString());
					clsReqrequete.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
					clsReqrequete.RQ_DATETRANSFERTREQUETE = DateTime.Parse(clsDonnee.vogDataReader["RQ_DATETRANSFERTREQUETE"].ToString());
					clsReqrequete.RQ_CODEREQUETERELANCEE = clsDonnee.vogDataReader["RQ_CODEREQUETERELANCEE"].ToString();
					//clsReqrequete.RQ_SIGNATURE = (Byte[])clsDonnee.vogDataReader["RQ_SIGNATURE"];// image.Parse(clsDonnee.vogDataReader["RQ_SIGNATURE"].ToString());
					clsReqrequete.RS_CODESTATUTRECEVABILITE = clsDonnee.vogDataReader["RS_CODESTATUTRECEVABILITE"].ToString();
					clsReqrequete.RQ_OBJETREQUETE = clsDonnee.vogDataReader["RQ_OBJETREQUETE"].ToString();
					clsReqrequete.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsReqrequete.RQ_DELAITRAITEMENTREQUETE = clsDonnee.vogDataReader["RQ_DELAITRAITEMENTREQUETE"].ToString();
					clsReqrequete.RQ_OBSERVATIONDELAITRAITEMENTREQUETE = clsDonnee.vogDataReader["RQ_OBSERVATIONDELAITRAITEMENTREQUETE"].ToString();
					clsReqrequete.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = clsDonnee.vogDataReader["RQ_OBSERVATIONAGENTTRAITEMENTREQUETE"].ToString();
					clsReqrequete.RQ_DUREETRAITEMENTREQUETE = clsDonnee.vogDataReader["RQ_DUREETRAITEMENTREQUETE"].ToString();
					clsReqrequete.RQ_DATEDEBUTTRAITEMENTREQUETE = DateTime.Parse(clsDonnee.vogDataReader["RQ_DATEDEBUTTRAITEMENTREQUETE"].ToString());
					clsReqrequete.RQ_DATEFINTRAITEMENTREQUETE = DateTime.Parse(clsDonnee.vogDataReader["RQ_DATEFINTRAITEMENTREQUETE"].ToString());
					clsReqrequete.AC_CODEACTIONCORRECTIVE = clsDonnee.vogDataReader["AC_CODEACTIONCORRECTIVE"].ToString();
					clsReqrequete.NS_CODENIVEAUSATISFACTION = clsDonnee.vogDataReader["NS_CODENIVEAUSATISFACTION"].ToString();
					clsReqrequete.RQ_DATECLOTUREREQUETE = DateTime.Parse(clsDonnee.vogDataReader["RQ_DATECLOTUREREQUETE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsReqrequete;
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqrequete>clsReqrequete</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsReqrequete clsReqrequete)
        {
            //Préparation des paramètres
            SqlParameter vppParamRQ_CODEREQUETE = new SqlParameter("@RQ_CODEREQUETE", SqlDbType.VarChar, 50);
            vppParamRQ_CODEREQUETE.Value = clsReqrequete.RQ_CODEREQUETE;
            SqlParameter vppParamTR_CODETYEREQUETE = new SqlParameter("@TR_CODETYEREQUETE", SqlDbType.VarChar, 5);
            vppParamTR_CODETYEREQUETE.Value = clsReqrequete.TR_CODETYEREQUETE;
            SqlParameter vppParamRQ_NUMEROREQUETE = new SqlParameter("@RQ_NUMEROREQUETE", SqlDbType.VarChar, 1000);
            vppParamRQ_NUMEROREQUETE.Value = clsReqrequete.RQ_NUMEROREQUETE;
            SqlParameter vppParamRQ_NUMERORECOMPTE = new SqlParameter("@RQ_NUMERORECOMPTE", SqlDbType.VarChar, 1000);
            vppParamRQ_NUMERORECOMPTE.Value = clsReqrequete.RQ_NUMERORECOMPTE;
            SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
            vppParamCU_CODECOMPTEUTULISATEUR.Value = clsReqrequete.CU_CODECOMPTEUTULISATEUR;
            SqlParameter vppParamRQ_LOCALISATIONCLIENT = new SqlParameter("@RQ_LOCALISATIONCLIENT", SqlDbType.VarChar, 1000);
            vppParamRQ_LOCALISATIONCLIENT.Value = clsReqrequete.RQ_LOCALISATIONCLIENT;
            SqlParameter vppParamRQ_DESCRIPTIONREQUETE = new SqlParameter("@RQ_DESCRIPTIONREQUETE", SqlDbType.VarChar, 7000);
            vppParamRQ_DESCRIPTIONREQUETE.Value = clsReqrequete.RQ_DESCRIPTIONREQUETE;
            SqlParameter vppParamMC_CODEMODECOLLETE = new SqlParameter("@MC_CODEMODECOLLETE", SqlDbType.VarChar, 2);
            vppParamMC_CODEMODECOLLETE.Value = clsReqrequete.MC_CODEMODECOLLETE;
            SqlParameter vppParamRQ_DATESAISIEREQUETE = new SqlParameter("@RQ_DATESAISIEREQUETE", SqlDbType.DateTime);
            vppParamRQ_DATESAISIEREQUETE.Value = clsReqrequete.RQ_DATESAISIEREQUETE;
            SqlParameter vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE = new SqlParameter("@CU_CODECOMPTEUTULISATEURAGENTENCHARGE", SqlDbType.Decimal, 35);
            vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE.Value = clsReqrequete.CU_CODECOMPTEUTULISATEURAGENTENCHARGE;
            if (clsReqrequete.CU_CODECOMPTEUTULISATEURAGENTENCHARGE == "") vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE.Value = DBNull.Value;
            SqlParameter vppParamRQ_DATETRANSFERTREQUETE = new SqlParameter("@RQ_DATETRANSFERTREQUETE", SqlDbType.DateTime);
            vppParamRQ_DATETRANSFERTREQUETE.Value = clsReqrequete.RQ_DATETRANSFERTREQUETE;
            SqlParameter vppParamRQ_CODEREQUETERELANCEE = new SqlParameter("@RQ_CODEREQUETERELANCEE", SqlDbType.Decimal, 4);
            vppParamRQ_CODEREQUETERELANCEE.Value = clsReqrequete.RQ_CODEREQUETERELANCEE;
            if (clsReqrequete.RQ_CODEREQUETERELANCEE == "") vppParamRQ_CODEREQUETERELANCEE.Value = DBNull.Value;
            SqlParameter vppParamRQ_SIGNATURE = new SqlParameter("@RQ_SIGNATURE", SqlDbType.VarBinary);
            vppParamRQ_SIGNATURE.Value = clsReqrequete.RQ_SIGNATURE;
            if (clsReqrequete.RQ_SIGNATURE == null) vppParamRQ_SIGNATURE.Value = DBNull.Value;
            SqlParameter vppParamRS_CODESTATUTRECEVABILITE = new SqlParameter("@RS_CODESTATUTRECEVABILITE", SqlDbType.VarChar, 2);
            vppParamRS_CODESTATUTRECEVABILITE.Value = clsReqrequete.RS_CODESTATUTRECEVABILITE;
            if (clsReqrequete.RS_CODESTATUTRECEVABILITE == "") vppParamRS_CODESTATUTRECEVABILITE.Value = DBNull.Value;
            SqlParameter vppParamRQ_OBJETREQUETE = new SqlParameter("@RQ_OBJETREQUETE", SqlDbType.VarChar, 1000);
            vppParamRQ_OBJETREQUETE.Value = clsReqrequete.RQ_OBJETREQUETE;
            if (clsReqrequete.RQ_OBJETREQUETE == "") vppParamRQ_OBJETREQUETE.Value = DBNull.Value;
            SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
            vppParamSR_CODESERVICE.Value = clsReqrequete.SR_CODESERVICE;
            if (clsReqrequete.SR_CODESERVICE == "") vppParamSR_CODESERVICE.Value = DBNull.Value;
            SqlParameter vppParamRQ_DELAITRAITEMENTREQUETE = new SqlParameter("@RQ_DELAITRAITEMENTREQUETE", SqlDbType.VarChar, 50);
            vppParamRQ_DELAITRAITEMENTREQUETE.Value = clsReqrequete.RQ_DELAITRAITEMENTREQUETE;
            SqlParameter vppParamRQ_OBSERVATIONDELAITRAITEMENTREQUETE = new SqlParameter("@RQ_OBSERVATIONDELAITRAITEMENTREQUETE", SqlDbType.VarChar, 1000);
            vppParamRQ_OBSERVATIONDELAITRAITEMENTREQUETE.Value = clsReqrequete.RQ_OBSERVATIONDELAITRAITEMENTREQUETE;
            if (clsReqrequete.RQ_OBSERVATIONDELAITRAITEMENTREQUETE == "") vppParamRQ_OBSERVATIONDELAITRAITEMENTREQUETE.Value = DBNull.Value;
            SqlParameter vppParamRQ_OBSERVATIONAGENTTRAITEMENTREQUETE = new SqlParameter("@RQ_OBSERVATIONAGENTTRAITEMENTREQUETE", SqlDbType.VarChar, 1000);
            vppParamRQ_OBSERVATIONAGENTTRAITEMENTREQUETE.Value = clsReqrequete.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE;
            if (clsReqrequete.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE == "") vppParamRQ_OBSERVATIONAGENTTRAITEMENTREQUETE.Value = DBNull.Value;
            SqlParameter vppParamRQ_DUREETRAITEMENTREQUETE = new SqlParameter("@RQ_DUREETRAITEMENTREQUETE", SqlDbType.VarChar, 1000);
            vppParamRQ_DUREETRAITEMENTREQUETE.Value = clsReqrequete.RQ_DUREETRAITEMENTREQUETE;
            if (clsReqrequete.RQ_DUREETRAITEMENTREQUETE == "") vppParamRQ_DUREETRAITEMENTREQUETE.Value = DBNull.Value;
            SqlParameter vppParamRQ_DATEDEBUTTRAITEMENTREQUETE = new SqlParameter("@RQ_DATEDEBUTTRAITEMENTREQUETE", SqlDbType.DateTime);
            vppParamRQ_DATEDEBUTTRAITEMENTREQUETE.Value = clsReqrequete.RQ_DATEDEBUTTRAITEMENTREQUETE;
            SqlParameter vppParamRQ_DATEFINTRAITEMENTREQUETE = new SqlParameter("@RQ_DATEFINTRAITEMENTREQUETE", SqlDbType.DateTime);
            vppParamRQ_DATEFINTRAITEMENTREQUETE.Value = clsReqrequete.RQ_DATEFINTRAITEMENTREQUETE;
            SqlParameter vppParamAC_CODEACTIONCORRECTIVE = new SqlParameter("@AC_CODEACTIONCORRECTIVE", SqlDbType.VarChar, 2);
            vppParamAC_CODEACTIONCORRECTIVE.Value = clsReqrequete.AC_CODEACTIONCORRECTIVE;
            if (clsReqrequete.AC_CODEACTIONCORRECTIVE == "") vppParamAC_CODEACTIONCORRECTIVE.Value = DBNull.Value;

            SqlParameter vppParamNS_CODENIVEAUSATISFACTION = new SqlParameter("@NS_CODENIVEAUSATISFACTION", SqlDbType.VarChar, 3);
            vppParamNS_CODENIVEAUSATISFACTION.Value = clsReqrequete.NS_CODENIVEAUSATISFACTION;
            if (clsReqrequete.NS_CODENIVEAUSATISFACTION == "") vppParamNS_CODENIVEAUSATISFACTION.Value = DBNull.Value;

            SqlParameter vppParamRQ_AFFICHERINFOCLIENT = new SqlParameter("@RQ_AFFICHERINFOCLIENT", SqlDbType.VarChar, 3);
            vppParamRQ_AFFICHERINFOCLIENT.Value = clsReqrequete.RQ_AFFICHERINFOCLIENT;
            if (clsReqrequete.RQ_AFFICHERINFOCLIENT == "") vppParamRQ_AFFICHERINFOCLIENT.Value = DBNull.Value;

            SqlParameter vppParamRT_CODETYPERELANCE = new SqlParameter("@RT_CODETYPERELANCE", SqlDbType.VarChar, 3);
            vppParamRT_CODETYPERELANCE.Value = clsReqrequete.RT_CODETYPERELANCE;
            if (clsReqrequete.RT_CODETYPERELANCE == "") vppParamRT_CODETYPERELANCE.Value = DBNull.Value;

            SqlParameter vppParamRQ_DATECLOTUREREQUETE = new SqlParameter("@RQ_DATECLOTUREREQUETE", SqlDbType.DateTime);
            vppParamRQ_DATECLOTUREREQUETE.Value = clsReqrequete.RQ_DATECLOTUREREQUETE;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsReqrequete.TYPEOPERATION;

            SqlParameter vppParamRQ_NOMRAPPORT = new SqlParameter("@RQ_NOMRAPPORT", SqlDbType.VarChar, 1000);
            vppParamRQ_NOMRAPPORT.Value = clsReqrequete.RQ_NOMRAPPORT;
            if (clsReqrequete.RQ_NOMRAPPORT == "") vppParamRQ_NOMRAPPORT.Value = DBNull.Value;

            SqlParameter vppParamCU_CODECOMPTEUTULISATEURASSOCIER = new SqlParameter("@CU_CODECOMPTEUTULISATEURASSOCIER", SqlDbType.VarChar, 50);
            vppParamCU_CODECOMPTEUTULISATEURASSOCIER.Value = clsReqrequete.CU_CODECOMPTEUTULISATEURASSOCIER;
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQREQUETE  @RQ_CODEREQUETE, @TR_CODETYEREQUETE, @RQ_NUMEROREQUETE, @RQ_NUMERORECOMPTE, @CU_CODECOMPTEUTULISATEUR, @RQ_LOCALISATIONCLIENT, @RQ_DESCRIPTIONREQUETE, @MC_CODEMODECOLLETE, @RQ_DATESAISIEREQUETE, @CU_CODECOMPTEUTULISATEURAGENTENCHARGE, @RQ_DATETRANSFERTREQUETE, @RQ_CODEREQUETERELANCEE, @RQ_SIGNATURE, @RS_CODESTATUTRECEVABILITE, @RQ_OBJETREQUETE, @SR_CODESERVICE, @RQ_DELAITRAITEMENTREQUETE, @RQ_OBSERVATIONDELAITRAITEMENTREQUETE, @RQ_OBSERVATIONAGENTTRAITEMENTREQUETE, @RQ_DUREETRAITEMENTREQUETE, @RQ_DATEDEBUTTRAITEMENTREQUETE, @RQ_DATEFINTRAITEMENTREQUETE, @AC_CODEACTIONCORRECTIVE, @NS_CODENIVEAUSATISFACTION,@RQ_AFFICHERINFOCLIENT, @RQ_DATECLOTUREREQUETE, @RT_CODETYPERELANCE, @CODECRYPTAGE1, @TYPEOPERATION, @RQ_NOMRAPPORT,@CU_CODECOMPTEUTULISATEURASSOCIER ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamRQ_CODEREQUETE);
            vppSqlCmd.Parameters.Add(vppParamTR_CODETYEREQUETE);
            vppSqlCmd.Parameters.Add(vppParamRQ_NUMEROREQUETE);
            vppSqlCmd.Parameters.Add(vppParamRQ_NUMERORECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
            vppSqlCmd.Parameters.Add(vppParamRQ_LOCALISATIONCLIENT);
            vppSqlCmd.Parameters.Add(vppParamRQ_DESCRIPTIONREQUETE);
            vppSqlCmd.Parameters.Add(vppParamMC_CODEMODECOLLETE);
            vppSqlCmd.Parameters.Add(vppParamRQ_DATESAISIEREQUETE);
            vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE);
            vppSqlCmd.Parameters.Add(vppParamRQ_DATETRANSFERTREQUETE);
            vppSqlCmd.Parameters.Add(vppParamRQ_CODEREQUETERELANCEE);
            vppSqlCmd.Parameters.Add(vppParamRQ_SIGNATURE);
            vppSqlCmd.Parameters.Add(vppParamRS_CODESTATUTRECEVABILITE);
            vppSqlCmd.Parameters.Add(vppParamRQ_OBJETREQUETE);
            vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
            vppSqlCmd.Parameters.Add(vppParamRQ_DELAITRAITEMENTREQUETE);
            vppSqlCmd.Parameters.Add(vppParamRQ_OBSERVATIONDELAITRAITEMENTREQUETE);
            vppSqlCmd.Parameters.Add(vppParamRQ_OBSERVATIONAGENTTRAITEMENTREQUETE);
            vppSqlCmd.Parameters.Add(vppParamRQ_DUREETRAITEMENTREQUETE);
            vppSqlCmd.Parameters.Add(vppParamRQ_DATEDEBUTTRAITEMENTREQUETE);
            vppSqlCmd.Parameters.Add(vppParamRQ_DATEFINTRAITEMENTREQUETE);
            vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIONCORRECTIVE);
            vppSqlCmd.Parameters.Add(vppParamNS_CODENIVEAUSATISFACTION);
            vppSqlCmd.Parameters.Add(vppParamRQ_AFFICHERINFOCLIENT);

            vppSqlCmd.Parameters.Add(vppParamRQ_DATECLOTUREREQUETE);
            vppSqlCmd.Parameters.Add(vppParamRT_CODETYPERELANCE);

            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamRQ_NOMRAPPORT);
            vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEURASSOCIER);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqrequete>clsReqrequete</param>
		///<author>Home Technology</author>
		public void pvgInsertDoc(clsDonnee clsDonnee, clsReqrequete clsReqrequete)
        {
            //Préparation des paramètres
            SqlParameter vppParamRQ_CODEREQUETE = new SqlParameter("@RQ_CODEREQUETE", SqlDbType.VarChar, 50);
            vppParamRQ_CODEREQUETE.Value = clsReqrequete.RQ_CODEREQUETE;

            SqlParameter vppParamRQ_NOMRAPPORT = new SqlParameter("@RQ_NOMRAPPORT", SqlDbType.VarChar, 1000);
            vppParamRQ_NOMRAPPORT.Value = clsReqrequete.RQ_NOMRAPPORT;
            if (clsReqrequete.RQ_NOMRAPPORT == "") vppParamRQ_NOMRAPPORT.Value = DBNull.Value;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQREQUETEDOC  @RQ_CODEREQUETE, @RQ_NOMRAPPORT ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamRQ_CODEREQUETE);
            vppSqlCmd.Parameters.Add(vppParamRQ_NOMRAPPORT);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqrequete>clsReqrequete</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsReqrequete clsReqrequete,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamRQ_CODEREQUETE = new SqlParameter("@RQ_CODEREQUETE", SqlDbType.VarChar, 50);
			vppParamRQ_CODEREQUETE.Value  = clsReqrequete.RQ_CODEREQUETE ;
			SqlParameter vppParamTR_CODETYEREQUETE = new SqlParameter("@TR_CODETYEREQUETE", SqlDbType.VarChar, 5);
			vppParamTR_CODETYEREQUETE.Value  = clsReqrequete.TR_CODETYEREQUETE ;
			SqlParameter vppParamRQ_NUMEROREQUETE = new SqlParameter("@RQ_NUMEROREQUETE", SqlDbType.VarChar, 1000);
			vppParamRQ_NUMEROREQUETE.Value  = clsReqrequete.RQ_NUMEROREQUETE ;
			SqlParameter vppParamRQ_NUMERORECOMPTE = new SqlParameter("@RQ_NUMERORECOMPTE", SqlDbType.VarChar, 1000);
			vppParamRQ_NUMERORECOMPTE.Value  = clsReqrequete.RQ_NUMERORECOMPTE ;
			SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
			vppParamCU_CODECOMPTEUTULISATEUR.Value  = clsReqrequete.CU_CODECOMPTEUTULISATEUR ;
			SqlParameter vppParamRQ_LOCALISATIONCLIENT = new SqlParameter("@RQ_LOCALISATIONCLIENT", SqlDbType.VarChar, 1000);
			vppParamRQ_LOCALISATIONCLIENT.Value  = clsReqrequete.RQ_LOCALISATIONCLIENT ;
			SqlParameter vppParamRQ_DESCRIPTIONREQUETE = new SqlParameter("@RQ_DESCRIPTIONREQUETE", SqlDbType.VarChar, 1000);
			vppParamRQ_DESCRIPTIONREQUETE.Value  = clsReqrequete.RQ_DESCRIPTIONREQUETE ;
			SqlParameter vppParamMC_CODEMODECOLLETE = new SqlParameter("@MC_CODEMODECOLLETE", SqlDbType.VarChar, 2);
			vppParamMC_CODEMODECOLLETE.Value  = clsReqrequete.MC_CODEMODECOLLETE ;
			SqlParameter vppParamRQ_DATESAISIEREQUETE = new SqlParameter("@RQ_DATESAISIEREQUETE", SqlDbType.DateTime);
			vppParamRQ_DATESAISIEREQUETE.Value  = clsReqrequete.RQ_DATESAISIEREQUETE ;
			SqlParameter vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE = new SqlParameter("@CU_CODECOMPTEUTULISATEURAGENTENCHARGE", SqlDbType.Decimal, 4);
			vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE.Value  = clsReqrequete.CU_CODECOMPTEUTULISATEURAGENTENCHARGE ;
			if(clsReqrequete.CU_CODECOMPTEUTULISATEURAGENTENCHARGE== ""  ) vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE.Value  = DBNull.Value;
			SqlParameter vppParamRQ_DATETRANSFERTREQUETE = new SqlParameter("@RQ_DATETRANSFERTREQUETE", SqlDbType.DateTime);
			vppParamRQ_DATETRANSFERTREQUETE.Value  = clsReqrequete.RQ_DATETRANSFERTREQUETE ;
			SqlParameter vppParamRQ_CODEREQUETERELANCEE = new SqlParameter("@RQ_CODEREQUETERELANCEE", SqlDbType.Decimal, 4);
			vppParamRQ_CODEREQUETERELANCEE.Value  = clsReqrequete.RQ_CODEREQUETERELANCEE ;
			if(clsReqrequete.RQ_CODEREQUETERELANCEE== ""  ) vppParamRQ_CODEREQUETERELANCEE.Value  = DBNull.Value;
			SqlParameter vppParamRQ_SIGNATURE = new SqlParameter("@RQ_SIGNATURE", SqlDbType.VarBinary);
			vppParamRQ_SIGNATURE.Value  = clsReqrequete.RQ_SIGNATURE ;
			if(clsReqrequete.RQ_SIGNATURE== null  ) vppParamRQ_SIGNATURE.Value  = DBNull.Value;
			SqlParameter vppParamRS_CODESTATUTRECEVABILITE = new SqlParameter("@RS_CODESTATUTRECEVABILITE", SqlDbType.VarChar, 2);
			vppParamRS_CODESTATUTRECEVABILITE.Value  = clsReqrequete.RS_CODESTATUTRECEVABILITE ;
			if(clsReqrequete.RS_CODESTATUTRECEVABILITE== ""  ) vppParamRS_CODESTATUTRECEVABILITE.Value  = DBNull.Value;
			SqlParameter vppParamRQ_OBJETREQUETE = new SqlParameter("@RQ_OBJETREQUETE", SqlDbType.VarChar, 1000);
			vppParamRQ_OBJETREQUETE.Value  = clsReqrequete.RQ_OBJETREQUETE ;
			if(clsReqrequete.RQ_OBJETREQUETE== ""  ) vppParamRQ_OBJETREQUETE.Value  = DBNull.Value;
			SqlParameter vppParamSR_CODESERVICE = new SqlParameter("@SR_CODESERVICE", SqlDbType.VarChar, 2);
			vppParamSR_CODESERVICE.Value  = clsReqrequete.SR_CODESERVICE ;
			if(clsReqrequete.SR_CODESERVICE== ""  ) vppParamSR_CODESERVICE.Value  = DBNull.Value;
			SqlParameter vppParamRQ_DELAITRAITEMENTREQUETE = new SqlParameter("@RQ_DELAITRAITEMENTREQUETE", SqlDbType.VarChar, 50);
			vppParamRQ_DELAITRAITEMENTREQUETE.Value  = clsReqrequete.RQ_DELAITRAITEMENTREQUETE ;
			SqlParameter vppParamRQ_OBSERVATIONDELAITRAITEMENTREQUETE = new SqlParameter("@RQ_OBSERVATIONDELAITRAITEMENTREQUETE", SqlDbType.VarChar, 1000);
			vppParamRQ_OBSERVATIONDELAITRAITEMENTREQUETE.Value  = clsReqrequete.RQ_OBSERVATIONDELAITRAITEMENTREQUETE ;
			if(clsReqrequete.RQ_OBSERVATIONDELAITRAITEMENTREQUETE== ""  ) vppParamRQ_OBSERVATIONDELAITRAITEMENTREQUETE.Value  = DBNull.Value;
			SqlParameter vppParamRQ_OBSERVATIONAGENTTRAITEMENTREQUETE = new SqlParameter("@RQ_OBSERVATIONAGENTTRAITEMENTREQUETE", SqlDbType.VarChar, 1000);
			vppParamRQ_OBSERVATIONAGENTTRAITEMENTREQUETE.Value  = clsReqrequete.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE ;
			if(clsReqrequete.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE== ""  ) vppParamRQ_OBSERVATIONAGENTTRAITEMENTREQUETE.Value  = DBNull.Value;
			SqlParameter vppParamRQ_DUREETRAITEMENTREQUETE = new SqlParameter("@RQ_DUREETRAITEMENTREQUETE", SqlDbType.VarChar, 1000);
			vppParamRQ_DUREETRAITEMENTREQUETE.Value  = clsReqrequete.RQ_DUREETRAITEMENTREQUETE ;
			if(clsReqrequete.RQ_DUREETRAITEMENTREQUETE== ""  ) vppParamRQ_DUREETRAITEMENTREQUETE.Value  = DBNull.Value;
			SqlParameter vppParamRQ_DATEDEBUTTRAITEMENTREQUETE = new SqlParameter("@RQ_DATEDEBUTTRAITEMENTREQUETE", SqlDbType.DateTime);
			vppParamRQ_DATEDEBUTTRAITEMENTREQUETE.Value  = clsReqrequete.RQ_DATEDEBUTTRAITEMENTREQUETE ;
			SqlParameter vppParamRQ_DATEFINTRAITEMENTREQUETE = new SqlParameter("@RQ_DATEFINTRAITEMENTREQUETE", SqlDbType.DateTime);
			vppParamRQ_DATEFINTRAITEMENTREQUETE.Value  = clsReqrequete.RQ_DATEFINTRAITEMENTREQUETE ;
			SqlParameter vppParamAC_CODEACTIONCORRECTIVE = new SqlParameter("@AC_CODEACTIONCORRECTIVE", SqlDbType.VarChar, 2);
			vppParamAC_CODEACTIONCORRECTIVE.Value  = clsReqrequete.AC_CODEACTIONCORRECTIVE ;
			if(clsReqrequete.AC_CODEACTIONCORRECTIVE== ""  ) vppParamAC_CODEACTIONCORRECTIVE.Value  = DBNull.Value;
			SqlParameter vppParamNS_CODENIVEAUSATISFACTION = new SqlParameter("@NS_CODENIVEAUSATISFACTION", SqlDbType.VarChar, 3);
			vppParamNS_CODENIVEAUSATISFACTION.Value  = clsReqrequete.NS_CODENIVEAUSATISFACTION ;
			if(clsReqrequete.NS_CODENIVEAUSATISFACTION== ""  ) vppParamNS_CODENIVEAUSATISFACTION.Value  = DBNull.Value;
			SqlParameter vppParamRQ_DATECLOTUREREQUETE = new SqlParameter("@RQ_DATECLOTUREREQUETE", SqlDbType.DateTime);
			vppParamRQ_DATECLOTUREREQUETE.Value  = clsReqrequete.RQ_DATECLOTUREREQUETE ;
			SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQREQUETE  @RQ_CODEREQUETE, @TR_CODETYEREQUETE, @RQ_NUMEROREQUETE, @RQ_NUMERORECOMPTE, @CU_CODECOMPTEUTULISATEUR, @RQ_LOCALISATIONCLIENT, @RQ_DESCRIPTIONREQUETE, @MC_CODEMODECOLLETE, @RQ_DATESAISIEREQUETE, @CU_CODECOMPTEUTULISATEURAGENTENCHARGE, @RQ_DATETRANSFERTREQUETE, @RQ_CODEREQUETERELANCEE, @RQ_SIGNATURE, @RS_CODESTATUTRECEVABILITE, @RQ_OBJETREQUETE, @SR_CODESERVICE, @RQ_DELAITRAITEMENTREQUETE, @RQ_OBSERVATIONDELAITRAITEMENTREQUETE, @RQ_OBSERVATIONAGENTTRAITEMENTREQUETE, @RQ_DUREETRAITEMENTREQUETE, @RQ_DATEDEBUTTRAITEMENTREQUETE, @RQ_DATEFINTRAITEMENTREQUETE, @AC_CODEACTIONCORRECTIVE, @NS_CODENIVEAUSATISFACTION, @RQ_DATECLOTUREREQUETE, @CODECRYPTAGE, 1 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamRQ_CODEREQUETE);
			vppSqlCmd.Parameters.Add(vppParamTR_CODETYEREQUETE);
			vppSqlCmd.Parameters.Add(vppParamRQ_NUMEROREQUETE);
			vppSqlCmd.Parameters.Add(vppParamRQ_NUMERORECOMPTE);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
			vppSqlCmd.Parameters.Add(vppParamRQ_LOCALISATIONCLIENT);
			vppSqlCmd.Parameters.Add(vppParamRQ_DESCRIPTIONREQUETE);
			vppSqlCmd.Parameters.Add(vppParamMC_CODEMODECOLLETE);
			vppSqlCmd.Parameters.Add(vppParamRQ_DATESAISIEREQUETE);
			vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEURAGENTENCHARGE);
			vppSqlCmd.Parameters.Add(vppParamRQ_DATETRANSFERTREQUETE);
			vppSqlCmd.Parameters.Add(vppParamRQ_CODEREQUETERELANCEE);
			vppSqlCmd.Parameters.Add(vppParamRQ_SIGNATURE);
			vppSqlCmd.Parameters.Add(vppParamRS_CODESTATUTRECEVABILITE);
			vppSqlCmd.Parameters.Add(vppParamRQ_OBJETREQUETE);
			vppSqlCmd.Parameters.Add(vppParamSR_CODESERVICE);
			vppSqlCmd.Parameters.Add(vppParamRQ_DELAITRAITEMENTREQUETE);
			vppSqlCmd.Parameters.Add(vppParamRQ_OBSERVATIONDELAITRAITEMENTREQUETE);
			vppSqlCmd.Parameters.Add(vppParamRQ_OBSERVATIONAGENTTRAITEMENTREQUETE);
			vppSqlCmd.Parameters.Add(vppParamRQ_DUREETRAITEMENTREQUETE);
			vppSqlCmd.Parameters.Add(vppParamRQ_DATEDEBUTTRAITEMENTREQUETE);
			vppSqlCmd.Parameters.Add(vppParamRQ_DATEFINTRAITEMENTREQUETE);
			vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIONCORRECTIVE);
			vppSqlCmd.Parameters.Add(vppParamNS_CODENIVEAUSATISFACTION);
			vppSqlCmd.Parameters.Add(vppParamRQ_DATECLOTUREREQUETE);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_REQREQUETE  @RQ_CODEREQUETE, @TR_CODETYEREQUETE, '' , '' , @CU_CODECOMPTEUTULISATEUR, '' , '' , @MC_CODEMODECOLLETE, '' , @CU_CODECOMPTEUTULISATEURAGENTENCHARGE, '' , @RQ_CODEREQUETERELANCEE, '' , @RS_CODESTATUTRECEVABILITE, '' , '' , '' , '' , '' , '' , '' , '' , '' , @NS_CODENIVEAUSATISFACTION, '' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqrequete </returns>
		///<author>Home Technology</author>
		public List<clsReqrequete> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RQ_CODEREQUETE, TR_CODETYEREQUETE, RQ_NUMEROREQUETE, RQ_NUMERORECOMPTE, CU_CODECOMPTEUTULISATEUR, RQ_LOCALISATIONCLIENT, RQ_DESCRIPTIONREQUETE, MC_CODEMODECOLLETE, RQ_DATESAISIEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_DATETRANSFERTREQUETE, RQ_CODEREQUETERELANCEE, RQ_SIGNATURE, RS_CODESTATUTRECEVABILITE, RQ_OBJETREQUETE, SR_CODESERVICE, RQ_DELAITRAITEMENTREQUETE, RQ_OBSERVATIONDELAITRAITEMENTREQUETE, RQ_OBSERVATIONAGENTTRAITEMENTREQUETE, RQ_DUREETRAITEMENTREQUETE, RQ_DATEDEBUTTRAITEMENTREQUETE, RQ_DATEFINTRAITEMENTREQUETE, AC_CODEACTIONCORRECTIVE, NS_CODENIVEAUSATISFACTION, RQ_DATECLOTUREREQUETE FROM dbo.FT_REQREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsReqrequete> clsReqrequetes = new List<clsReqrequete>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsReqrequete clsReqrequete = new clsReqrequete();
					clsReqrequete.RQ_CODEREQUETE = clsDonnee.vogDataReader["RQ_CODEREQUETE"].ToString();
					clsReqrequete.TR_CODETYEREQUETE = clsDonnee.vogDataReader["TR_CODETYEREQUETE"].ToString();
					clsReqrequete.RQ_NUMEROREQUETE = clsDonnee.vogDataReader["RQ_NUMEROREQUETE"].ToString();
					clsReqrequete.RQ_NUMERORECOMPTE = clsDonnee.vogDataReader["RQ_NUMERORECOMPTE"].ToString();
					clsReqrequete.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsReqrequete.RQ_LOCALISATIONCLIENT = clsDonnee.vogDataReader["RQ_LOCALISATIONCLIENT"].ToString();
					clsReqrequete.RQ_DESCRIPTIONREQUETE = clsDonnee.vogDataReader["RQ_DESCRIPTIONREQUETE"].ToString();
					clsReqrequete.MC_CODEMODECOLLETE = clsDonnee.vogDataReader["MC_CODEMODECOLLETE"].ToString();
					clsReqrequete.RQ_DATESAISIEREQUETE = DateTime.Parse(clsDonnee.vogDataReader["RQ_DATESAISIEREQUETE"].ToString());
					clsReqrequete.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
					clsReqrequete.RQ_DATETRANSFERTREQUETE = DateTime.Parse(clsDonnee.vogDataReader["RQ_DATETRANSFERTREQUETE"].ToString());
					clsReqrequete.RQ_CODEREQUETERELANCEE = clsDonnee.vogDataReader["RQ_CODEREQUETERELANCEE"].ToString();
					clsReqrequete.RQ_SIGNATURE = (Byte[])clsDonnee.vogDataReader["RQ_SIGNATURE"]; //image.Parse(clsDonnee.vogDataReader["RQ_SIGNATURE"].ToString());
					clsReqrequete.RS_CODESTATUTRECEVABILITE = clsDonnee.vogDataReader["RS_CODESTATUTRECEVABILITE"].ToString();
					clsReqrequete.RQ_OBJETREQUETE = clsDonnee.vogDataReader["RQ_OBJETREQUETE"].ToString();
					clsReqrequete.SR_CODESERVICE = clsDonnee.vogDataReader["SR_CODESERVICE"].ToString();
					clsReqrequete.RQ_DELAITRAITEMENTREQUETE = clsDonnee.vogDataReader["RQ_DELAITRAITEMENTREQUETE"].ToString();
					clsReqrequete.RQ_OBSERVATIONDELAITRAITEMENTREQUETE = clsDonnee.vogDataReader["RQ_OBSERVATIONDELAITRAITEMENTREQUETE"].ToString();
					clsReqrequete.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = clsDonnee.vogDataReader["RQ_OBSERVATIONAGENTTRAITEMENTREQUETE"].ToString();
					clsReqrequete.RQ_DUREETRAITEMENTREQUETE = clsDonnee.vogDataReader["RQ_DUREETRAITEMENTREQUETE"].ToString();
					clsReqrequete.RQ_DATEDEBUTTRAITEMENTREQUETE = DateTime.Parse(clsDonnee.vogDataReader["RQ_DATEDEBUTTRAITEMENTREQUETE"].ToString());
					clsReqrequete.RQ_DATEFINTRAITEMENTREQUETE = DateTime.Parse(clsDonnee.vogDataReader["RQ_DATEFINTRAITEMENTREQUETE"].ToString());
					clsReqrequete.AC_CODEACTIONCORRECTIVE = clsDonnee.vogDataReader["AC_CODEACTIONCORRECTIVE"].ToString();
					clsReqrequete.NS_CODENIVEAUSATISFACTION = clsDonnee.vogDataReader["NS_CODENIVEAUSATISFACTION"].ToString();
					clsReqrequete.RQ_DATECLOTUREREQUETE = DateTime.Parse(clsDonnee.vogDataReader["RQ_DATECLOTUREREQUETE"].ToString());
					clsReqrequetes.Add(clsReqrequete);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsReqrequetes;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqrequete </returns>
		///<author>Home Technology</author>
		public List<clsReqrequete> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsReqrequete> clsReqrequetes = new List<clsReqrequete>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  RQ_CODEREQUETE, TR_CODETYEREQUETE, RQ_NUMEROREQUETE, RQ_NUMERORECOMPTE, CU_CODECOMPTEUTULISATEUR, RQ_LOCALISATIONCLIENT, RQ_DESCRIPTIONREQUETE, MC_CODEMODECOLLETE, RQ_DATESAISIEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_DATETRANSFERTREQUETE, RQ_CODEREQUETERELANCEE, RQ_SIGNATURE, RS_CODESTATUTRECEVABILITE, RQ_OBJETREQUETE, SR_CODESERVICE, RQ_DELAITRAITEMENTREQUETE, RQ_OBSERVATIONDELAITRAITEMENTREQUETE, RQ_OBSERVATIONAGENTTRAITEMENTREQUETE, RQ_DUREETRAITEMENTREQUETE, RQ_DATEDEBUTTRAITEMENTREQUETE, RQ_DATEFINTRAITEMENTREQUETE, AC_CODEACTIONCORRECTIVE, NS_CODENIVEAUSATISFACTION, RQ_DATECLOTUREREQUETE FROM dbo.FT_REQREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsReqrequete clsReqrequete = new clsReqrequete();
					clsReqrequete.RQ_CODEREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_CODEREQUETE"].ToString();
					clsReqrequete.TR_CODETYEREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["TR_CODETYEREQUETE"].ToString();
					clsReqrequete.RQ_NUMEROREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_NUMEROREQUETE"].ToString();
					clsReqrequete.RQ_NUMERORECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_NUMERORECOMPTE"].ToString();
					clsReqrequete.CU_CODECOMPTEUTULISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CU_CODECOMPTEUTULISATEUR"].ToString();
					clsReqrequete.RQ_LOCALISATIONCLIENT = Dataset.Tables["TABLE"].Rows[Idx]["RQ_LOCALISATIONCLIENT"].ToString();
					clsReqrequete.RQ_DESCRIPTIONREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_DESCRIPTIONREQUETE"].ToString();
					clsReqrequete.MC_CODEMODECOLLETE = Dataset.Tables["TABLE"].Rows[Idx]["MC_CODEMODECOLLETE"].ToString();
					clsReqrequete.RQ_DATESAISIEREQUETE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RQ_DATESAISIEREQUETE"].ToString());
					clsReqrequete.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = Dataset.Tables["TABLE"].Rows[Idx]["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
					clsReqrequete.RQ_DATETRANSFERTREQUETE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RQ_DATETRANSFERTREQUETE"].ToString());
					clsReqrequete.RQ_CODEREQUETERELANCEE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_CODEREQUETERELANCEE"].ToString();
					clsReqrequete.RQ_SIGNATURE = (Byte[])clsDonnee.vogDataReader["RQ_SIGNATURE"]; //image.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RQ_SIGNATURE"].ToString());
					clsReqrequete.RS_CODESTATUTRECEVABILITE = Dataset.Tables["TABLE"].Rows[Idx]["RS_CODESTATUTRECEVABILITE"].ToString();
					clsReqrequete.RQ_OBJETREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_OBJETREQUETE"].ToString();
					clsReqrequete.SR_CODESERVICE = Dataset.Tables["TABLE"].Rows[Idx]["SR_CODESERVICE"].ToString();
					clsReqrequete.RQ_DELAITRAITEMENTREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_DELAITRAITEMENTREQUETE"].ToString();
					clsReqrequete.RQ_OBSERVATIONDELAITRAITEMENTREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_OBSERVATIONDELAITRAITEMENTREQUETE"].ToString();
					clsReqrequete.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_OBSERVATIONAGENTTRAITEMENTREQUETE"].ToString();
					clsReqrequete.RQ_DUREETRAITEMENTREQUETE = Dataset.Tables["TABLE"].Rows[Idx]["RQ_DUREETRAITEMENTREQUETE"].ToString();
					clsReqrequete.RQ_DATEDEBUTTRAITEMENTREQUETE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RQ_DATEDEBUTTRAITEMENTREQUETE"].ToString());
					clsReqrequete.RQ_DATEFINTRAITEMENTREQUETE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RQ_DATEFINTRAITEMENTREQUETE"].ToString());
					clsReqrequete.AC_CODEACTIONCORRECTIVE = Dataset.Tables["TABLE"].Rows[Idx]["AC_CODEACTIONCORRECTIVE"].ToString();
					clsReqrequete.NS_CODENIVEAUSATISFACTION = Dataset.Tables["TABLE"].Rows[Idx]["NS_CODENIVEAUSATISFACTION"].ToString();
					clsReqrequete.RQ_DATECLOTUREREQUETE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["RQ_DATECLOTUREREQUETE"].ToString());
					clsReqrequetes.Add(clsReqrequete);
				}
				Dataset.Dispose();
			}
		return clsReqrequetes;
		}
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetParOperateurs(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereNewOperateur(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_REQREQUETEPAROPERATEUR(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetParOperateursClotureReq(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereOperateurParReq(clsDonnee, vppCritere);

            this.vapRequete = "SELECT DISTINCT RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE FROM dbo.FT_REQREQUETEPAROPERATEUR(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritereNew(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_REQREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetBCAO(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@NR_CODENATUREREQUETE", "@MO_DATEDEBUT", "@MO_DATEFIN", "@CU_CODECOMPTEUTULISATEUR", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0].Replace("''", "'"), vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
            this.vapRequete = "EXEC [dbo].[PS_REQREQUETBCAO] @AG_CODEAGENCE,@NR_CODENATUREREQUETE,@MO_DATEDEBUT,@MO_DATEFIN,@CU_CODECOMPTEUTULISATEUR,@TYPEOPERATION,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        //public DataSet pvgChargerDansDataSetRelance(clsDonnee clsDonnee, params string[] vppCritere)
        //{
        //    pvpChoixCritereNew(clsDonnee, vppCritere);
        //    this.vapRequete = "SELECT *  FROM dbo.FT_REQREQUETERELANCE(@CODECRYPTAGE) "+ this.vapCritere;
        //    this.vapCritere = "";
        //    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //    return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        //}

        public DataSet pvgChargerDansDataSetRelance(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@RQ_DATEJOURNEE", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };

            this.vapRequete = "EXEC [dbo].[PS_REQREQUETE] @RQ_DATEJOURNEE,@TYPEOPERATION,@CODECRYPTAGE";
            // this.vapRequete = "SELECT *  FROM dbo.FT_REQREQUETERELANCE(@CODECRYPTAGE) "+ this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT RQ_CODEREQUETE , TR_CODETYEREQUETE FROM dbo.FT_REQREQUETE(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetTableauDeBord(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@RQ_DATEDEBUT", "@RQ_DATEFIN", "@CU_CODECOMPTEUTULISATEUR", "@TYPEETAT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0].Replace("''", "'"), vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };

            this.vapRequete = "EXEC [dbo].[PS_TABLEAUDEBORDADMIN] @AG_CODEAGENCE  ,@RQ_DATEDEBUT  ,@RQ_DATEFIN, @CU_CODECOMPTEUTULISATEUR , @TYPEETAT ,@CODECRYPTAGE";
            // this.vapRequete = "SELECT *  FROM dbo.FT_REQREQUETERELANCE(@CODECRYPTAGE) "+ this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetFrequenceReclamation(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@RQ_DATEDEBUT", "@RQ_DATEFIN", "@CU_CODECOMPTEUTULISATEUR", "@TYPEETAT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0].Replace("''", "'"), vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };

            this.vapRequete = "EXEC [dbo].[PS_ETATFRQUENCERECLAMATION] @AG_CODEAGENCE  ,@RQ_DATEDEBUT  ,@RQ_DATEFIN, @CU_CODECOMPTEUTULISATEUR , @TYPEETAT ,@CODECRYPTAGE";
            // this.vapRequete = "SELECT *  FROM dbo.FT_REQREQUETERELANCE(@CODECRYPTAGE) "+ this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>

        public DataSet pvgChargerDansDataSetDASHBOARD(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@CU_CODECOMPTEUTULISATEUR", "@RQ_DATEDEBUTTRAITEMENTREQUETE", "@RQ_DATEFINTRAITEMENTREQUETE", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };

            this.vapRequete = "EXEC [dbo].[PS_REQREQUETESTATISTIQUEDASHBOARD] @AG_CODEAGENCE,@CU_CODECOMPTEUTULISATEUR,@RQ_DATEDEBUTTRAITEMENTREQUETE,@RQ_DATEFINTRAITEMENTREQUETE,@TYPEOPERATION,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetTableauDeBordstatistique(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@RQ_DATEDEBUT", "@RQ_DATEFIN", "@CU_CODECOMPTEUTULISATEUR", "@TYPEETAT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };

            this.vapRequete = "EXEC [dbo].[PS_TABLEAUDEBORDADMINSTATISTIQUE] @AG_CODEAGENCE  ,@RQ_DATEDEBUT  ,@RQ_DATEFIN, @CU_CODECOMPTEUTULISATEUR , @TYPEETAT ,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqrequete>clsReqrequete</param>
		///<author>Home Technology</author>
		public void pvgInsertAvisclient(clsDonnee clsDonnee, clsReqrequete clsReqrequete)
        {
            //Préparation des paramètres
            SqlParameter vppParamRQ_CODEREQUETE = new SqlParameter("@RQ_CODEREQUETE2", SqlDbType.VarChar, 50);
            vppParamRQ_CODEREQUETE.Value = clsReqrequete.RQ_CODEREQUETE;

            SqlParameter vppParamRQ_OBSERVATIONAGENTTRAITEMENTREQUETE = new SqlParameter("@RQ_OBSERVATIONAGENTTRAITEMENTREQUETE2", SqlDbType.VarChar, 1000);
            vppParamRQ_OBSERVATIONAGENTTRAITEMENTREQUETE.Value = clsReqrequete.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE;
            if (clsReqrequete.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE == "") vppParamRQ_OBSERVATIONAGENTTRAITEMENTREQUETE.Value = DBNull.Value;


            SqlParameter vppParamNS_CODENIVEAUSATISFACTION = new SqlParameter("@NS_CODENIVEAUSATISFACTION2", SqlDbType.VarChar, 3);
            vppParamNS_CODENIVEAUSATISFACTION.Value = clsReqrequete.NS_CODENIVEAUSATISFACTION;
            if (clsReqrequete.NS_CODENIVEAUSATISFACTION == "") vppParamNS_CODENIVEAUSATISFACTION.Value = DBNull.Value;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE2", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION2", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsReqrequete.TYPEOPERATION;



            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQREQUETEAVISCLIENT  @RQ_CODEREQUETE2, @RQ_OBSERVATIONAGENTTRAITEMENTREQUETE2, @NS_CODENIVEAUSATISFACTION2, @CODECRYPTAGE2, @TYPEOPERATION2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamRQ_CODEREQUETE);
            vppSqlCmd.Parameters.Add(vppParamRQ_OBSERVATIONAGENTTRAITEMENTREQUETE);
            vppSqlCmd.Parameters.Add(vppParamNS_CODENIVEAUSATISFACTION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsOperateurdroitagence>clsOperateurdroitagence</param>
        ///<author>Home Technology</author>
        public void pvgInsertDroitOperateur(clsDonnee clsDonnee, MgRequeteClients.BOJ.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametre)
        {
            //Préparation des paramètres
            SqlParameter vppParamCU_CODECOMPTEUSER = new SqlParameter("@CU_CODECOMPTEUSER4", SqlDbType.VarChar, 60);
            vppParamCU_CODECOMPTEUSER.Value = clsRequtilisateurdroitparametre.CU_CODECOMPTEUTULISATEUR;
            SqlParameter vppParamDP_CODEDROITCOMPTEUSER = new SqlParameter("@DP_CODEDROITCOMPTEUSER4", SqlDbType.VarChar, 25);
            vppParamDP_CODEDROITCOMPTEUSER.Value = clsRequtilisateurdroitparametre.DP_CODEDROITCOMPTEUTULISATEUR;

            //Préparation de la commande
            this.vapRequete = "INSERT INTO REQUTILISATEURDROIT ( CU_CODECOMPTEUTULISATEUR, DP_CODEDROITCOMPTEUTULISATEUR ) " +
                    "VALUES ( @CU_CODECOMPTEUSER4, @DP_CODEDROITCOMPTEUSER4) ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUSER);
            vppSqlCmd.Parameters.Add(vppParamDP_CODEDROITCOMPTEUSER);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetDroitParOperateurs(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereOperateurdroit(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_REQREQUETEDROITPAROPERATEUR(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsReqrequete>clsReqrequete</param>
		///<author>Home Technology</author>
		public void pvgTestsuroperateurDroit(clsDonnee clsDonnee, string CU_CODECOMPTEUTULISATEUR)
        {
          
            SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 1000);
            vppParamCU_CODECOMPTEUTULISATEUR.Value = CU_CODECOMPTEUTULISATEUR;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PS_REQINFOSSTATUTUTILISATEURADMIN   @CU_CODECOMPTEUTULISATEUR ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
      
            vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
          
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDeleteDroit(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR3";
            vapNomParametre = new string[] { "@CU_CODECOMPTEUTULISATEUR3" };
            vapValeurParametre = new object[] { vppCritere[0] };

            //Préparation de la commande
            this.vapRequete = "DELETE FROM  REQUTILISATEURDROIT " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }





        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereOperateurdroit(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {

                case 1:
                    this.vapCritere = "WHERE CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND DP_STATUT = 'O'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@CU_CODECOMPTEUTULISATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;

            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION)</summary>
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
				this.vapCritere ="WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RQ_CODEREQUETE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RQ_CODEREQUETE","@TR_CODETYEREQUETE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
				case 3 :
				this.vapCritere ="WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RQ_CODEREQUETE","@TR_CODETYEREQUETE","@CU_CODECOMPTEUTULISATEUR"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2]};
				break;
				case 4 :
				this.vapCritere ="WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND MC_CODEMODECOLLETE=@MC_CODEMODECOLLETE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RQ_CODEREQUETE","@TR_CODETYEREQUETE","@CU_CODECOMPTEUTULISATEUR","@MC_CODEMODECOLLETE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3]};
				break;
				case 5 :
				this.vapCritere ="WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND MC_CODEMODECOLLETE=@MC_CODEMODECOLLETE AND CU_CODECOMPTEUTULISATEURAGENTENCHARGE=@CU_CODECOMPTEUTULISATEURAGENTENCHARGE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RQ_CODEREQUETE","@TR_CODETYEREQUETE","@CU_CODECOMPTEUTULISATEUR","@MC_CODEMODECOLLETE","@CU_CODECOMPTEUTULISATEURAGENTENCHARGE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4]};
				break;
				case 6 :
				this.vapCritere ="WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND MC_CODEMODECOLLETE=@MC_CODEMODECOLLETE AND CU_CODECOMPTEUTULISATEURAGENTENCHARGE=@CU_CODECOMPTEUTULISATEURAGENTENCHARGE AND RQ_CODEREQUETERELANCEE=@RQ_CODEREQUETERELANCEE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RQ_CODEREQUETE","@TR_CODETYEREQUETE","@CU_CODECOMPTEUTULISATEUR","@MC_CODEMODECOLLETE","@CU_CODECOMPTEUTULISATEURAGENTENCHARGE","@RQ_CODEREQUETERELANCEE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5]};
				break;
				case 7 :
				this.vapCritere ="WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND MC_CODEMODECOLLETE=@MC_CODEMODECOLLETE AND CU_CODECOMPTEUTULISATEURAGENTENCHARGE=@CU_CODECOMPTEUTULISATEURAGENTENCHARGE AND RQ_CODEREQUETERELANCEE=@RQ_CODEREQUETERELANCEE AND RS_CODESTATUTRECEVABILITE=@RS_CODESTATUTRECEVABILITE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RQ_CODEREQUETE","@TR_CODETYEREQUETE","@CU_CODECOMPTEUTULISATEUR","@MC_CODEMODECOLLETE","@CU_CODECOMPTEUTULISATEURAGENTENCHARGE","@RQ_CODEREQUETERELANCEE","@RS_CODESTATUTRECEVABILITE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6]};
				break;
				case 8 :
				this.vapCritere ="WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND MC_CODEMODECOLLETE=@MC_CODEMODECOLLETE AND CU_CODECOMPTEUTULISATEURAGENTENCHARGE=@CU_CODECOMPTEUTULISATEURAGENTENCHARGE AND RQ_CODEREQUETERELANCEE=@RQ_CODEREQUETERELANCEE AND RS_CODESTATUTRECEVABILITE=@RS_CODESTATUTRECEVABILITE AND NS_CODENIVEAUSATISFACTION=@NS_CODENIVEAUSATISFACTION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@RQ_CODEREQUETE","@TR_CODETYEREQUETE","@CU_CODECOMPTEUTULISATEUR","@MC_CODEMODECOLLETE","@CU_CODECOMPTEUTULISATEURAGENTENCHARGE","@RQ_CODEREQUETERELANCEE","@RS_CODESTATUTRECEVABILITE","@NS_CODENIVEAUSATISFACTION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1],vppCritere[2],vppCritere[3],vppCritere[4],vppCritere[5],vppCritere[6],vppCritere[7]};
				break;
			}
		}



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION)</summary>
		///<param name="clsDonnee"> clsDonnee</param>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE NR_CODENATUREREQUETE=@NR_CODENATUREREQUETE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@NR_CODENATUREREQUETE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE NR_CODENATUREREQUETE=@NR_CODENATUREREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@NR_CODENATUREREQUETE", "@TR_CODETYEREQUETE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE NR_CODENATUREREQUETE=@NR_CODENATUREREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@NR_CODENATUREREQUETE", "@TR_CODETYEREQUETE", "@CU_CODECOMPTEUTULISATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND MC_CODEMODECOLLETE=@MC_CODEMODECOLLETE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@RQ_CODEREQUETE", "@TR_CODETYEREQUETE", "@CU_CODECOMPTEUTULISATEUR", "@MC_CODEMODECOLLETE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
                case 5:
                    this.vapCritere = "WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND MC_CODEMODECOLLETE=@MC_CODEMODECOLLETE AND CU_CODECOMPTEUTULISATEURAGENTENCHARGE=@CU_CODECOMPTEUTULISATEURAGENTENCHARGE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@RQ_CODEREQUETE", "@TR_CODETYEREQUETE", "@CU_CODECOMPTEUTULISATEUR", "@MC_CODEMODECOLLETE", "@CU_CODECOMPTEUTULISATEURAGENTENCHARGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;
                case 6:
                    this.vapCritere = "WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND MC_CODEMODECOLLETE=@MC_CODEMODECOLLETE AND CU_CODECOMPTEUTULISATEURAGENTENCHARGE=@CU_CODECOMPTEUTULISATEURAGENTENCHARGE AND RQ_CODEREQUETERELANCEE=@RQ_CODEREQUETERELANCEE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@RQ_CODEREQUETE", "@TR_CODETYEREQUETE", "@CU_CODECOMPTEUTULISATEUR", "@MC_CODEMODECOLLETE", "@CU_CODECOMPTEUTULISATEURAGENTENCHARGE", "@RQ_CODEREQUETERELANCEE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
                    break;
                case 7:
                    this.vapCritere = "WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND MC_CODEMODECOLLETE=@MC_CODEMODECOLLETE AND CU_CODECOMPTEUTULISATEURAGENTENCHARGE=@CU_CODECOMPTEUTULISATEURAGENTENCHARGE AND RQ_CODEREQUETERELANCEE=@RQ_CODEREQUETERELANCEE AND RS_CODESTATUTRECEVABILITE=@RS_CODESTATUTRECEVABILITE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@RQ_CODEREQUETE", "@TR_CODETYEREQUETE", "@CU_CODECOMPTEUTULISATEUR", "@MC_CODEMODECOLLETE", "@CU_CODECOMPTEUTULISATEURAGENTENCHARGE", "@RQ_CODEREQUETERELANCEE", "@RS_CODESTATUTRECEVABILITE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };
                    break;
                case 8:
                    this.vapCritere = "WHERE RQ_CODEREQUETE=@RQ_CODEREQUETE AND TR_CODETYEREQUETE=@TR_CODETYEREQUETE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND MC_CODEMODECOLLETE=@MC_CODEMODECOLLETE AND CU_CODECOMPTEUTULISATEURAGENTENCHARGE=@CU_CODECOMPTEUTULISATEURAGENTENCHARGE AND RQ_CODEREQUETERELANCEE=@RQ_CODEREQUETERELANCEE AND RS_CODESTATUTRECEVABILITE=@RS_CODESTATUTRECEVABILITE AND NS_CODENIVEAUSATISFACTION=@NS_CODENIVEAUSATISFACTION";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@RQ_CODEREQUETE", "@TR_CODETYEREQUETE", "@CU_CODECOMPTEUTULISATEUR", "@MC_CODEMODECOLLETE", "@CU_CODECOMPTEUTULISATEURAGENTENCHARGE", "@RQ_CODEREQUETERELANCEE", "@RS_CODESTATUTRECEVABILITE", "@NS_CODENIVEAUSATISFACTION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7] };
                    break;
            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereNew(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE NR_CODENATUREREQUETE=@NR_CODENATUREREQUETE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@NR_CODENATUREREQUETE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE NR_CODENATUREREQUETE=@NR_CODENATUREREQUETE AND CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@NR_CODENATUREREQUETE", "@CU_CODECOMPTEUTULISATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE NR_CODENATUREREQUETE=@NR_CODENATUREREQUETE AND AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@NR_CODENATUREREQUETE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[2] };
                    break;

            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereNewOperateur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE NR_CODENATUREREQUETE=@NR_CODENATUREREQUETE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@NR_CODENATUREREQUETE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE NR_CODENATUREREQUETE=@NR_CODENATUREREQUETE AND CU_CODECOMPTEUTULISATEURAGENTENCHARGE=@CU_CODECOMPTEUTULISATEURAGENTENCHARGE AND AT_DATECLOTUREETAPE = '01/01/1900'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@NR_CODENATUREREQUETE", "@CU_CODECOMPTEUTULISATEURAGENTENCHARGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;

            }
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritereOperateurParReq(clsDonnee clsDonnee, params string[] vppCritere)
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
        
    }
}
