using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.BOJ.BusinessObjects;
using MgRequeteClients.DAL.Interfaces;
using MgRequeteClients.Tools.Classes;
using Microsoft.Data.SqlClient;

namespace MgRequeteClients.DAL.Classes
{
    public class clsReqcompteutilisateurWSDAL : ITableDAL<clsReqcompteutilisateur>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(CU_CODECOMPTEUTULISATEUR) AS CU_CODECOMPTEUTULISATEUR  FROM dbo.FT_REQCOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(CU_CODECOMPTEUTULISATEUR) AS CU_CODECOMPTEUTULISATEUR  FROM dbo.FT_REQCOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee ,vppCritere);
            pvpChoixCritere2(clsDonnee, vppCritere);
            this.vapRequete = "SELECT CONVERT(VARCHAR, MAX(CU_CODECOMPTEUTULISATEUR)) AS CU_CODECOMPTEUTULISATEUR  FROM dbo.FT_REQCOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsReqcompteutilisateur comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsReqcompteutilisateur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  ,CU_CODECOMPTEUTULISATEUR  , TU_CODETYPEUTILISATEUR  , CU_NUMEROUTILISATEUR  , CU_ADRESSEGEOGRAPHIQUEUTILISATEUR  , CU_NOMUTILISATEUR  , CU_CONTACT  , CU_EMAIL  , CU_LOGIN  , CU_MOTDEPASSE  , CU_DATECREATION  , CU_DATECLOTURE  , CU_TOKEN  , PI_CODEPIECE  , CU_NUMEROPIECE  , CU_DATEPIECE  , CU_NOMBRECONNECTION  , CU_CLESESSION  FROM dbo.FT_REQCOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsReqcompteutilisateur.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
                    clsReqcompteutilisateur.TU_CODETYPEUTILISATEUR = clsDonnee.vogDataReader["TU_CODETYPEUTILISATEUR"].ToString();
                    clsReqcompteutilisateur.CU_NUMEROUTILISATEUR = clsDonnee.vogDataReader["CU_NUMEROUTILISATEUR"].ToString();
                    clsReqcompteutilisateur.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = clsDonnee.vogDataReader["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                    clsReqcompteutilisateur.CU_NOMUTILISATEUR = clsDonnee.vogDataReader["CU_NOMUTILISATEUR"].ToString();
                    clsReqcompteutilisateur.CU_CONTACT = clsDonnee.vogDataReader["CU_CONTACT"].ToString();
                    clsReqcompteutilisateur.CU_EMAIL = clsDonnee.vogDataReader["CU_EMAIL"].ToString();
                    clsReqcompteutilisateur.CU_LOGIN = clsDonnee.vogDataReader["CU_LOGIN"].ToString();
                    clsReqcompteutilisateur.CU_MOTDEPASSE = clsDonnee.vogDataReader["CU_MOTDEPASSE"].ToString();
                    clsReqcompteutilisateur.CU_DATECREATION = DateTime.Parse(clsDonnee.vogDataReader["CU_DATECREATION"].ToString());
                    clsReqcompteutilisateur.CU_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["CU_DATECLOTURE"].ToString());
                    clsReqcompteutilisateur.CU_TOKEN = clsDonnee.vogDataReader["CU_TOKEN"].ToString();
                    clsReqcompteutilisateur.PI_CODEPIECE = clsDonnee.vogDataReader["PI_CODEPIECE"].ToString();
                    clsReqcompteutilisateur.CU_NUMEROPIECE = clsDonnee.vogDataReader["CU_NUMEROPIECE"].ToString();
                    clsReqcompteutilisateur.CU_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["CU_DATEPIECE"].ToString());
                    clsReqcompteutilisateur.CU_NOMBRECONNECTION = clsDonnee.vogDataReader["CU_NOMBRECONNECTION"].ToString();
                    clsReqcompteutilisateur.CU_CLESESSION = clsDonnee.vogDataReader["CU_CLESESSION"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsReqcompteutilisateur;
        }


        public DataSet pvgInsertIntoDatasetListeClient(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere11(clsDonnee, vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE  ,CU_CODECOMPTEUTULISATEUR  , TU_CODETYPEUTILISATEUR  , CU_NUMEROUTILISATEUR  , CU_ADRESSEGEOGRAPHIQUEUTILISATEUR  , CU_NOMUTILISATEUR  , CU_CONTACT  , CU_EMAIL  , CU_LOGIN  , CU_MOTDEPASSE  , CU_DATECREATION  , CU_DATECLOTURE  , CU_TOKEN  , PI_CODEPIECE  , CU_NUMEROPIECE  , CU_DATEPIECE  , CU_NOMBRECONNECTION  , CU_CLESESSION  FROM dbo.FT_REQCOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
        //      ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
        /////<param name=clsDonnee>Classe d'acces aux donnees</param>
        /////<param name="vppCritere">critères de la requête scalaire</param>
        /////<returns>Un clsReqcompteutilisateur comme valeur du résultat de la requete</returns>
        /////<author>Home Technology</author>
        //public clsReqcompteutilisateur pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        //      {
        //          pvpChoixCritere(clsDonnee, vppCritere);
        //          this.vapRequete = "SELECT AG_CODEAGENCE  ,CU_CODECOMPTEUTULISATEUR  , TU_CODETYPEUTILISATEUR  , CU_NUMEROUTILISATEUR  , CU_ADRESSEGEOGRAPHIQUEUTILISATEUR  , CU_NOMUTILISATEUR  , CU_CONTACT  , CU_EMAIL  , CU_LOGIN  , CU_MOTDEPASSE  , CU_DATECREATION  , CU_DATECLOTURE  , CU_TOKEN  , PI_CODEPIECE  , CU_NUMEROPIECE  , CU_DATEPIECE  , CU_NOMBRECONNECTION  , CU_CLESESSION  FROM dbo.FT_REQCOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
        //          this.vapCritere = "";
        //          SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //          clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
        //          if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
        //          {
        //              while (clsDonnee.vogDataReader.Read())
        //              {
        //                  clsReqcompteutilisateur.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
        //                  clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
        //                  clsReqcompteutilisateur.TU_CODETYPEUTILISATEUR = clsDonnee.vogDataReader["TU_CODETYPEUTILISATEUR"].ToString();
        //                  clsReqcompteutilisateur.CU_NUMEROUTILISATEUR = clsDonnee.vogDataReader["CU_NUMEROUTILISATEUR"].ToString();
        //                  clsReqcompteutilisateur.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = clsDonnee.vogDataReader["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
        //                  clsReqcompteutilisateur.CU_NOMUTILISATEUR = clsDonnee.vogDataReader["CU_NOMUTILISATEUR"].ToString();
        //                  clsReqcompteutilisateur.CU_CONTACT = clsDonnee.vogDataReader["CU_CONTACT"].ToString();
        //                  clsReqcompteutilisateur.CU_EMAIL = clsDonnee.vogDataReader["CU_EMAIL"].ToString();
        //                  clsReqcompteutilisateur.CU_LOGIN = clsDonnee.vogDataReader["CU_LOGIN"].ToString();
        //                  clsReqcompteutilisateur.CU_MOTDEPASSE = clsDonnee.vogDataReader["CU_MOTDEPASSE"].ToString();
        //                  clsReqcompteutilisateur.CU_DATECREATION = DateTime.Parse(clsDonnee.vogDataReader["CU_DATECREATION"].ToString());
        //                  clsReqcompteutilisateur.CU_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["CU_DATECLOTURE"].ToString());
        //                  clsReqcompteutilisateur.CU_TOKEN = clsDonnee.vogDataReader["CU_TOKEN"].ToString();
        //                  clsReqcompteutilisateur.PI_CODEPIECE = clsDonnee.vogDataReader["PI_CODEPIECE"].ToString();
        //                  clsReqcompteutilisateur.CU_NUMEROPIECE = clsDonnee.vogDataReader["CU_NUMEROPIECE"].ToString();
        //                  clsReqcompteutilisateur.CU_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["CU_DATEPIECE"].ToString());
        //                  clsReqcompteutilisateur.CU_NOMBRECONNECTION = clsDonnee.vogDataReader["CU_NOMBRECONNECTION"].ToString();
        //                  clsReqcompteutilisateur.CU_CLESESSION = clsDonnee.vogDataReader["CU_CLESESSION"].ToString();
        //              }
        //              clsDonnee.vogDataReader.Dispose();
        //          }
        //          return clsReqcompteutilisateur;
        //      }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqcompteutilisateur>clsReqcompteutilisateur</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsReqcompteutilisateur clsReqcompteutilisateur)
        {
            //Préparation des paramètres
            SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
            vppParamCU_CODECOMPTEUTULISATEUR.Value = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsReqcompteutilisateur.AG_CODEAGENCE;
            SqlParameter vppParamTU_CODETYPEUTILISATEUR = new SqlParameter("@TU_CODETYPEUTILISATEUR", SqlDbType.VarChar, 4);
            vppParamTU_CODETYPEUTILISATEUR.Value = clsReqcompteutilisateur.TU_CODETYPEUTILISATEUR;
            SqlParameter vppParamCU_NUMEROUTILISATEUR = new SqlParameter("@CU_NUMEROUTILISATEUR", SqlDbType.VarChar, 1000);
            vppParamCU_NUMEROUTILISATEUR.Value = clsReqcompteutilisateur.CU_NUMEROUTILISATEUR;
            SqlParameter vppParamCU_ADRESSEGEOGRAPHIQUEUTILISATEUR = new SqlParameter("@CU_ADRESSEGEOGRAPHIQUEUTILISATEUR", SqlDbType.VarChar, 1000);
            vppParamCU_ADRESSEGEOGRAPHIQUEUTILISATEUR.Value = clsReqcompteutilisateur.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR;
            SqlParameter vppParamCU_NOMUTILISATEUR = new SqlParameter("@CU_NOMUTILISATEUR", SqlDbType.VarChar, 1000);
            vppParamCU_NOMUTILISATEUR.Value = clsReqcompteutilisateur.CU_NOMUTILISATEUR;
            SqlParameter vppParamCU_CONTACT = new SqlParameter("@CU_CONTACT", SqlDbType.VarChar, 1000);
            vppParamCU_CONTACT.Value = clsReqcompteutilisateur.CU_CONTACT;
            SqlParameter vppParamCU_EMAIL = new SqlParameter("@CU_EMAIL", SqlDbType.VarChar, 1000);
            vppParamCU_EMAIL.Value = clsReqcompteutilisateur.CU_EMAIL;
            SqlParameter vppParamCU_LOGIN = new SqlParameter("@CU_LOGIN", SqlDbType.VarChar, 1000);
            vppParamCU_LOGIN.Value = clsReqcompteutilisateur.CU_LOGIN;
            SqlParameter vppParamCU_MOTDEPASSE = new SqlParameter("@CU_MOTDEPASSE", SqlDbType.VarChar, 1000);
            vppParamCU_MOTDEPASSE.Value = clsReqcompteutilisateur.CU_MOTDEPASSE;
            SqlParameter vppParamCU_DATECREATION = new SqlParameter("@CU_DATECREATION", SqlDbType.DateTime);
            vppParamCU_DATECREATION.Value = clsReqcompteutilisateur.CU_DATECREATION;
            SqlParameter vppParamCU_DATECLOTURE = new SqlParameter("@CU_DATECLOTURE", SqlDbType.DateTime);
            vppParamCU_DATECLOTURE.Value = clsReqcompteutilisateur.CU_DATECLOTURE;
            SqlParameter vppParamCU_TOKEN = new SqlParameter("@CU_TOKEN", SqlDbType.VarChar, 1000);
            vppParamCU_TOKEN.Value = clsReqcompteutilisateur.CU_TOKEN;
            if (clsReqcompteutilisateur.CU_TOKEN == "") vppParamCU_TOKEN.Value = DBNull.Value;
            SqlParameter vppParamPI_CODEPIECE = new SqlParameter("@PI_CODEPIECE", SqlDbType.VarChar, 5);
            vppParamPI_CODEPIECE.Value = clsReqcompteutilisateur.PI_CODEPIECE;
            if (clsReqcompteutilisateur.PI_CODEPIECE == "") vppParamPI_CODEPIECE.Value = DBNull.Value;
            SqlParameter vppParamCU_NUMEROPIECE = new SqlParameter("@CU_NUMEROPIECE", SqlDbType.VarChar, 1000);
            vppParamCU_NUMEROPIECE.Value = clsReqcompteutilisateur.CU_NUMEROPIECE;
            if (clsReqcompteutilisateur.CU_NUMEROPIECE == "") vppParamCU_NUMEROPIECE.Value = DBNull.Value;
            SqlParameter vppParamCU_DATEPIECE = new SqlParameter("@CU_DATEPIECE", SqlDbType.DateTime);
            vppParamCU_DATEPIECE.Value = clsReqcompteutilisateur.CU_DATEPIECE;
            SqlParameter vppParamCU_NOMBRECONNECTION = new SqlParameter("@CU_NOMBRECONNECTION", SqlDbType.VarChar, 25);
            vppParamCU_NOMBRECONNECTION.Value = clsReqcompteutilisateur.CU_NOMBRECONNECTION;
            SqlParameter vppParamCU_CLESESSION = new SqlParameter("@CU_CLESESSION", SqlDbType.VarChar, 1000);
            vppParamCU_CLESESSION.Value = clsReqcompteutilisateur.CU_CLESESSION;
            if (clsReqcompteutilisateur.CU_CLESESSION == "") vppParamCU_CLESESSION.Value = DBNull.Value;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsReqcompteutilisateur.TYPEOPERATION;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQCOMPTEUTILISATEUR  @CU_CODECOMPTEUTULISATEUR, @AG_CODEAGENCE, @TU_CODETYPEUTILISATEUR, @CU_NUMEROUTILISATEUR, @CU_ADRESSEGEOGRAPHIQUEUTILISATEUR, @CU_NOMUTILISATEUR, @CU_CONTACT, @CU_EMAIL, @CU_LOGIN, @CU_MOTDEPASSE, @CU_DATECREATION, @CU_DATECLOTURE, @CU_TOKEN, @PI_CODEPIECE, @CU_NUMEROPIECE, @CU_DATEPIECE, @CU_NOMBRECONNECTION, @CU_CLESESSION, @CODECRYPTAGE1, @TYPEOPERATION ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamTU_CODETYPEUTILISATEUR);
            vppSqlCmd.Parameters.Add(vppParamCU_NUMEROUTILISATEUR);
            vppSqlCmd.Parameters.Add(vppParamCU_ADRESSEGEOGRAPHIQUEUTILISATEUR);
            vppSqlCmd.Parameters.Add(vppParamCU_NOMUTILISATEUR);
            vppSqlCmd.Parameters.Add(vppParamCU_CONTACT);
            vppSqlCmd.Parameters.Add(vppParamCU_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamCU_LOGIN);
            vppSqlCmd.Parameters.Add(vppParamCU_MOTDEPASSE);
            vppSqlCmd.Parameters.Add(vppParamCU_DATECREATION);
            vppSqlCmd.Parameters.Add(vppParamCU_DATECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamCU_TOKEN);
            vppSqlCmd.Parameters.Add(vppParamPI_CODEPIECE);
            vppSqlCmd.Parameters.Add(vppParamCU_NUMEROPIECE);
            vppSqlCmd.Parameters.Add(vppParamCU_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamCU_NOMBRECONNECTION);
            vppSqlCmd.Parameters.Add(vppParamCU_CLESESSION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqcompteutilisateur>clsReqcompteutilisateur</param>
        ///<author>Home Technology</author>
        //public string pvgMiseajour(clsDonnee clsDonnee, clsReqcompteutilisateur clsReqcompteutilisateur)
        //{
        //	//Préparation des paramètres
        //	SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
        //	vppParamCU_CODECOMPTEUTULISATEUR.Value  = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR ;
        //	SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
        //	vppParamAG_CODEAGENCE.Value  = clsReqcompteutilisateur.AG_CODEAGENCE ;
        //	SqlParameter vppParamTU_CODETYPEUTILISATEUR = new SqlParameter("@TU_CODETYPEUTILISATEUR", SqlDbType.VarChar, 4);
        //	vppParamTU_CODETYPEUTILISATEUR.Value  = clsReqcompteutilisateur.TU_CODETYPEUTILISATEUR ;
        //	SqlParameter vppParamCU_NUMEROUTILISATEUR = new SqlParameter("@CU_NUMEROUTILISATEUR", SqlDbType.VarChar, 1000);
        //	vppParamCU_NUMEROUTILISATEUR.Value  = clsReqcompteutilisateur.CU_NUMEROUTILISATEUR ;
        //	SqlParameter vppParamCU_ADRESSEGEOGRAPHIQUEUTILISATEUR = new SqlParameter("@CU_ADRESSEGEOGRAPHIQUEUTILISATEUR", SqlDbType.VarChar, 1000);
        //	vppParamCU_ADRESSEGEOGRAPHIQUEUTILISATEUR.Value  = clsReqcompteutilisateur.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR ;
        //	SqlParameter vppParamCU_NOMUTILISATEUR = new SqlParameter("@CU_NOMUTILISATEUR", SqlDbType.VarChar, 1000);
        //	vppParamCU_NOMUTILISATEUR.Value  = clsReqcompteutilisateur.CU_NOMUTILISATEUR ;
        //	SqlParameter vppParamCU_CONTACT = new SqlParameter("@CU_CONTACT", SqlDbType.VarChar, 1000);
        //	vppParamCU_CONTACT.Value  = clsReqcompteutilisateur.CU_CONTACT ;
        //	SqlParameter vppParamCU_EMAIL = new SqlParameter("@CU_EMAIL", SqlDbType.VarChar, 1000);
        //	vppParamCU_EMAIL.Value  = clsReqcompteutilisateur.CU_EMAIL ;
        //	SqlParameter vppParamCU_LOGIN = new SqlParameter("@CU_LOGIN", SqlDbType.VarChar, 1000);
        //	vppParamCU_LOGIN.Value  = clsReqcompteutilisateur.CU_LOGIN ;
        //	SqlParameter vppParamCU_MOTDEPASSE = new SqlParameter("@CU_MOTDEPASSE", SqlDbType.VarChar, 1000);
        //	vppParamCU_MOTDEPASSE.Value  = clsReqcompteutilisateur.CU_MOTDEPASSE ;
        //	SqlParameter vppParamCU_DATECREATION = new SqlParameter("@CU_DATECREATION", SqlDbType.DateTime);
        //	vppParamCU_DATECREATION.Value  = clsReqcompteutilisateur.CU_DATECREATION ;
        //	SqlParameter vppParamCU_DATECLOTURE = new SqlParameter("@CU_DATECLOTURE", SqlDbType.DateTime);
        //	vppParamCU_DATECLOTURE.Value  = clsReqcompteutilisateur.CU_DATECLOTURE ;
        //	SqlParameter vppParamCU_TOKEN = new SqlParameter("@CU_TOKEN", SqlDbType.VarChar, 1000);
        //	vppParamCU_TOKEN.Value  = clsReqcompteutilisateur.CU_TOKEN ;
        //	if(clsReqcompteutilisateur.CU_TOKEN== ""  ) vppParamCU_TOKEN.Value  = DBNull.Value;
        //	SqlParameter vppParamPI_CODEPIECE = new SqlParameter("@PI_CODEPIECE", SqlDbType.VarChar, 5);
        //	vppParamPI_CODEPIECE.Value  = clsReqcompteutilisateur.PI_CODEPIECE ;
        //	if(clsReqcompteutilisateur.PI_CODEPIECE== ""  ) vppParamPI_CODEPIECE.Value  = DBNull.Value;
        //	SqlParameter vppParamCU_NUMEROPIECE = new SqlParameter("@CU_NUMEROPIECE", SqlDbType.VarChar, 1000);
        //	vppParamCU_NUMEROPIECE.Value  = clsReqcompteutilisateur.CU_NUMEROPIECE ;
        //	if(clsReqcompteutilisateur.CU_NUMEROPIECE== ""  ) vppParamCU_NUMEROPIECE.Value  = DBNull.Value;
        //	SqlParameter vppParamCU_DATEPIECE = new SqlParameter("@CU_DATEPIECE", SqlDbType.DateTime);
        //	vppParamCU_DATEPIECE.Value  = clsReqcompteutilisateur.CU_DATEPIECE ;
        //	SqlParameter vppParamCU_NOMBRECONNECTION = new SqlParameter("@CU_NOMBRECONNECTION", SqlDbType.VarChar, 25);
        //	vppParamCU_NOMBRECONNECTION.Value  = clsReqcompteutilisateur.CU_NOMBRECONNECTION ;
        //	SqlParameter vppParamCU_CLESESSION = new SqlParameter("@CU_CLESESSION", SqlDbType.VarChar, 1000);
        //	vppParamCU_CLESESSION.Value  = clsReqcompteutilisateur.CU_CLESESSION ;
        //	if(clsReqcompteutilisateur.CU_CLESESSION== ""  ) vppParamCU_CLESESSION.Value  = DBNull.Value;
        //	SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
        //	vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

        //          SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
        //          vppParamTYPEOPERATION.Value = clsReqcompteutilisateur.TYPEOPERATION;

        //          SqlParameter vppParamCU_CODECOMPTEUTULISATEURRETOUR = new SqlParameter("@CU_CODECOMPTEUTULISATEURRETOUR", SqlDbType.VarChar, 150);

        //          //Préparation de la commande
        //          //this.vapRequete = "EXECUTE PC_cinetpay_transactions  @id_cinetrans, @id_cinetpay, @id_utilisateur, @transaction_id, @montant, @payment_token, @payment_url, @statuss, @code, @messagess, @payment_method, @payment_date, @operator_id, @cel_phone_num, @api_response_id, @created_at, @CODECRYPTAGE1, @TYPEOPERATION ";
        //          //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

        //          SqlCommand vppSqlCmd = new SqlCommand("PC_REQCOMPTEUTILISATEUR", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //          vppSqlCmd.CommandType = CommandType.StoredProcedure;

        // //         //Préparation de la commande
        // //         this.vapRequete = "EXECUTE PC_REQCOMPTEUTILISATEUR  @CU_CODECOMPTEUTULISATEUR, @AG_CODEAGENCE, @TU_CODETYPEUTILISATEUR, @CU_NUMEROUTILISATEUR, @CU_ADRESSEGEOGRAPHIQUEUTILISATEUR, @CU_NOMUTILISATEUR, @CU_CONTACT, @CU_EMAIL, @CU_LOGIN, @CU_MOTDEPASSE, @CU_DATECREATION, @CU_DATECLOTURE, @CU_TOKEN, @PI_CODEPIECE, @CU_NUMEROPIECE, @CU_DATEPIECE, @CU_NOMBRECONNECTION, @CU_CLESESSION, @CODECRYPTAGE1, @TYPEOPERATION ";
        //	//SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

        //	//Ajout des paramètre à la commande
        //	vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
        //	vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
        //	vppSqlCmd.Parameters.Add(vppParamTU_CODETYPEUTILISATEUR);
        //	vppSqlCmd.Parameters.Add(vppParamCU_NUMEROUTILISATEUR);
        //	vppSqlCmd.Parameters.Add(vppParamCU_ADRESSEGEOGRAPHIQUEUTILISATEUR);
        //	vppSqlCmd.Parameters.Add(vppParamCU_NOMUTILISATEUR);
        //	vppSqlCmd.Parameters.Add(vppParamCU_CONTACT);
        //	vppSqlCmd.Parameters.Add(vppParamCU_EMAIL);
        //	vppSqlCmd.Parameters.Add(vppParamCU_LOGIN);
        //	vppSqlCmd.Parameters.Add(vppParamCU_MOTDEPASSE);
        //	vppSqlCmd.Parameters.Add(vppParamCU_DATECREATION);
        //	vppSqlCmd.Parameters.Add(vppParamCU_DATECLOTURE);
        //	vppSqlCmd.Parameters.Add(vppParamCU_TOKEN);
        //	vppSqlCmd.Parameters.Add(vppParamPI_CODEPIECE);
        //	vppSqlCmd.Parameters.Add(vppParamCU_NUMEROPIECE);
        //	vppSqlCmd.Parameters.Add(vppParamCU_DATEPIECE);
        //	vppSqlCmd.Parameters.Add(vppParamCU_NOMBRECONNECTION);
        //	vppSqlCmd.Parameters.Add(vppParamCU_CLESESSION);
        //	vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
        //	vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);


        //          vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEURRETOUR);
        //          vppParamCU_CODECOMPTEUTULISATEURRETOUR.Direction = ParameterDirection.Output;



        //          //Ouverture de la connection et exécution de la commande
        //          //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);


        //          //Ouverture de la connection et exécution de la commande
        //          clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        //          // valeurs de retour de la procedure stockée
        //          return vppSqlCmd.Parameters["@CU_CODECOMPTEUTULISATEURRETOUR"].Value.ToString();



        //          ////Ouverture de la connection et exécution de la commande
        //          //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        //      }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqcompteutilisateur>clsReqcompteutilisateur</param>
        ///<author>Home Technology</author>
        public string pvgMiseajour(clsDonnee clsDonnee, clsReqcompteutilisateur clsReqcompteutilisateur)
        {
            //Préparation des paramètres
            SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
            vppParamCU_CODECOMPTEUTULISATEUR.Value = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsReqcompteutilisateur.AG_CODEAGENCE;
            SqlParameter vppParamTU_CODETYPEUTILISATEUR = new SqlParameter("@TU_CODETYPEUTILISATEUR", SqlDbType.VarChar, 4);
            vppParamTU_CODETYPEUTILISATEUR.Value = clsReqcompteutilisateur.TU_CODETYPEUTILISATEUR;
            SqlParameter vppParamCU_NUMEROUTILISATEUR = new SqlParameter("@CU_NUMEROUTILISATEUR", SqlDbType.VarChar, 1000);
            vppParamCU_NUMEROUTILISATEUR.Value = clsReqcompteutilisateur.CU_NUMEROUTILISATEUR;
            SqlParameter vppParamCU_ADRESSEGEOGRAPHIQUEUTILISATEUR = new SqlParameter("@CU_ADRESSEGEOGRAPHIQUEUTILISATEUR", SqlDbType.VarChar, 1000);
            vppParamCU_ADRESSEGEOGRAPHIQUEUTILISATEUR.Value = clsReqcompteutilisateur.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR;
            SqlParameter vppParamCU_NOMUTILISATEUR = new SqlParameter("@CU_NOMUTILISATEUR", SqlDbType.VarChar, 1000);
            vppParamCU_NOMUTILISATEUR.Value = clsReqcompteutilisateur.CU_NOMUTILISATEUR;
            SqlParameter vppParamCU_CONTACT = new SqlParameter("@CU_CONTACT", SqlDbType.VarChar, 1000);
            vppParamCU_CONTACT.Value = clsReqcompteutilisateur.CU_CONTACT;
            SqlParameter vppParamCU_EMAIL = new SqlParameter("@CU_EMAIL", SqlDbType.VarChar, 1000);
            vppParamCU_EMAIL.Value = clsReqcompteutilisateur.CU_EMAIL;
            SqlParameter vppParamCU_LOGIN = new SqlParameter("@CU_LOGIN", SqlDbType.VarChar, 1000);
            vppParamCU_LOGIN.Value = clsReqcompteutilisateur.CU_LOGIN;
            SqlParameter vppParamCU_MOTDEPASSE = new SqlParameter("@CU_MOTDEPASSE", SqlDbType.VarChar, 1000);
            vppParamCU_MOTDEPASSE.Value = clsReqcompteutilisateur.CU_MOTDEPASSE;
            SqlParameter vppParamCU_DATECREATION = new SqlParameter("@CU_DATECREATION", SqlDbType.DateTime);
            vppParamCU_DATECREATION.Value = clsReqcompteutilisateur.CU_DATECREATION;
            SqlParameter vppParamCU_DATECLOTURE = new SqlParameter("@CU_DATECLOTURE", SqlDbType.DateTime);
            vppParamCU_DATECLOTURE.Value = clsReqcompteutilisateur.CU_DATECLOTURE;
            SqlParameter vppParamCU_TOKEN = new SqlParameter("@CU_TOKEN", SqlDbType.VarChar, 1000);
            vppParamCU_TOKEN.Value = clsReqcompteutilisateur.CU_TOKEN;
            if (clsReqcompteutilisateur.CU_TOKEN == "") vppParamCU_TOKEN.Value = DBNull.Value;
            SqlParameter vppParamPI_CODEPIECE = new SqlParameter("@PI_CODEPIECE", SqlDbType.VarChar, 5);
            vppParamPI_CODEPIECE.Value = clsReqcompteutilisateur.PI_CODEPIECE;
            if (clsReqcompteutilisateur.PI_CODEPIECE == "") vppParamPI_CODEPIECE.Value = DBNull.Value;
            SqlParameter vppParamCU_NUMEROPIECE = new SqlParameter("@CU_NUMEROPIECE", SqlDbType.VarChar, 1000);
            vppParamCU_NUMEROPIECE.Value = clsReqcompteutilisateur.CU_NUMEROPIECE;
            if (clsReqcompteutilisateur.CU_NUMEROPIECE == "") vppParamCU_NUMEROPIECE.Value = DBNull.Value;
            SqlParameter vppParamCU_DATEPIECE = new SqlParameter("@CU_DATEPIECE", SqlDbType.DateTime);
            vppParamCU_DATEPIECE.Value = clsReqcompteutilisateur.CU_DATEPIECE;
            SqlParameter vppParamCU_NOMBRECONNECTION = new SqlParameter("@CU_NOMBRECONNECTION", SqlDbType.VarChar, 25);
            vppParamCU_NOMBRECONNECTION.Value = clsReqcompteutilisateur.CU_NOMBRECONNECTION;
            SqlParameter vppParamCU_CLESESSION = new SqlParameter("@CU_CLESESSION", SqlDbType.VarChar, 1000);
            vppParamCU_CLESESSION.Value = clsReqcompteutilisateur.CU_CLESESSION;
            if (clsReqcompteutilisateur.CU_CLESESSION == "") vppParamCU_CLESESSION.Value = DBNull.Value;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.VarChar, 1);
            vppParamTYPEOPERATION.Value = clsReqcompteutilisateur.TYPEOPERATION;

            SqlParameter vppParamCU_CODECOMPTEUTULISATEURRETOUR = new SqlParameter("@CU_CODECOMPTEUTULISATEURRETOUR", SqlDbType.VarChar, 150);

            //Préparation de la commande
            //this.vapRequete = "EXECUTE PC_cinetpay_transactions  @id_cinetrans, @id_cinetpay, @id_utilisateur, @transaction_id, @montant, @payment_token, @payment_url, @statuss, @code, @messagess, @payment_method, @payment_date, @operator_id, @cel_phone_num, @api_response_id, @created_at, @CODECRYPTAGE1, @TYPEOPERATION ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            SqlCommand vppSqlCmd = new SqlCommand("PC_REQCOMPTEUTILISATEUR", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            //         //Préparation de la commande
            //         this.vapRequete = "EXECUTE PC_REQCOMPTEUTILISATEUR  @CU_CODECOMPTEUTULISATEUR, @AG_CODEAGENCE, @TU_CODETYPEUTILISATEUR, @CU_NUMEROUTILISATEUR, @CU_ADRESSEGEOGRAPHIQUEUTILISATEUR, @CU_NOMUTILISATEUR, @CU_CONTACT, @CU_EMAIL, @CU_LOGIN, @CU_MOTDEPASSE, @CU_DATECREATION, @CU_DATECLOTURE, @CU_TOKEN, @PI_CODEPIECE, @CU_NUMEROPIECE, @CU_DATEPIECE, @CU_NOMBRECONNECTION, @CU_CLESESSION, @CODECRYPTAGE1, @TYPEOPERATION ";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamTU_CODETYPEUTILISATEUR);
            vppSqlCmd.Parameters.Add(vppParamCU_NUMEROUTILISATEUR);
            vppSqlCmd.Parameters.Add(vppParamCU_ADRESSEGEOGRAPHIQUEUTILISATEUR);
            vppSqlCmd.Parameters.Add(vppParamCU_NOMUTILISATEUR);
            vppSqlCmd.Parameters.Add(vppParamCU_CONTACT);
            vppSqlCmd.Parameters.Add(vppParamCU_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamCU_LOGIN);
            vppSqlCmd.Parameters.Add(vppParamCU_MOTDEPASSE);
            vppSqlCmd.Parameters.Add(vppParamCU_DATECREATION);
            vppSqlCmd.Parameters.Add(vppParamCU_DATECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamCU_TOKEN);
            vppSqlCmd.Parameters.Add(vppParamPI_CODEPIECE);
            vppSqlCmd.Parameters.Add(vppParamCU_NUMEROPIECE);
            vppSqlCmd.Parameters.Add(vppParamCU_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamCU_NOMBRECONNECTION);
            vppSqlCmd.Parameters.Add(vppParamCU_CLESESSION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);


            vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEURRETOUR);
            vppParamCU_CODECOMPTEUTULISATEURRETOUR.Direction = ParameterDirection.Output;



            //Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);


            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@CU_CODECOMPTEUTULISATEURRETOUR"].Value.ToString();



            ////Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsReqcompteutilisateur>clsReqcompteutilisateur</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgUpdate(clsDonnee clsDonnee, clsReqcompteutilisateur clsReqcompteutilisateur, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamCU_CODECOMPTEUTULISATEUR = new SqlParameter("@CU_CODECOMPTEUTULISATEUR", SqlDbType.VarChar, 50);
            vppParamCU_CODECOMPTEUTULISATEUR.Value = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsReqcompteutilisateur.AG_CODEAGENCE;
            SqlParameter vppParamTU_CODETYPEUTILISATEUR = new SqlParameter("@TU_CODETYPEUTILISATEUR", SqlDbType.VarChar, 4);
            vppParamTU_CODETYPEUTILISATEUR.Value = clsReqcompteutilisateur.TU_CODETYPEUTILISATEUR;
            SqlParameter vppParamCU_NUMEROUTILISATEUR = new SqlParameter("@CU_NUMEROUTILISATEUR", SqlDbType.VarChar, 1000);
            vppParamCU_NUMEROUTILISATEUR.Value = clsReqcompteutilisateur.CU_NUMEROUTILISATEUR;
            SqlParameter vppParamCU_ADRESSEGEOGRAPHIQUEUTILISATEUR = new SqlParameter("@CU_ADRESSEGEOGRAPHIQUEUTILISATEUR", SqlDbType.VarChar, 1000);
            vppParamCU_ADRESSEGEOGRAPHIQUEUTILISATEUR.Value = clsReqcompteutilisateur.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR;
            SqlParameter vppParamCU_NOMUTILISATEUR = new SqlParameter("@CU_NOMUTILISATEUR", SqlDbType.VarChar, 1000);
            vppParamCU_NOMUTILISATEUR.Value = clsReqcompteutilisateur.CU_NOMUTILISATEUR;
            SqlParameter vppParamCU_CONTACT = new SqlParameter("@CU_CONTACT", SqlDbType.VarChar, 1000);
            vppParamCU_CONTACT.Value = clsReqcompteutilisateur.CU_CONTACT;
            SqlParameter vppParamCU_EMAIL = new SqlParameter("@CU_EMAIL", SqlDbType.VarChar, 1000);
            vppParamCU_EMAIL.Value = clsReqcompteutilisateur.CU_EMAIL;
            SqlParameter vppParamCU_LOGIN = new SqlParameter("@CU_LOGIN", SqlDbType.VarChar, 1000);
            vppParamCU_LOGIN.Value = clsReqcompteutilisateur.CU_LOGIN;
            SqlParameter vppParamCU_MOTDEPASSE = new SqlParameter("@CU_MOTDEPASSE", SqlDbType.VarChar, 1000);
            vppParamCU_MOTDEPASSE.Value = clsReqcompteutilisateur.CU_MOTDEPASSE;
            SqlParameter vppParamCU_DATECREATION = new SqlParameter("@CU_DATECREATION", SqlDbType.DateTime);
            vppParamCU_DATECREATION.Value = clsReqcompteutilisateur.CU_DATECREATION;
            SqlParameter vppParamCU_DATECLOTURE = new SqlParameter("@CU_DATECLOTURE", SqlDbType.DateTime);
            vppParamCU_DATECLOTURE.Value = clsReqcompteutilisateur.CU_DATECLOTURE;
            SqlParameter vppParamCU_TOKEN = new SqlParameter("@CU_TOKEN", SqlDbType.VarChar, 1000);
            vppParamCU_TOKEN.Value = clsReqcompteutilisateur.CU_TOKEN;
            if (clsReqcompteutilisateur.CU_TOKEN == "") vppParamCU_TOKEN.Value = DBNull.Value;
            SqlParameter vppParamPI_CODEPIECE = new SqlParameter("@PI_CODEPIECE", SqlDbType.VarChar, 5);
            vppParamPI_CODEPIECE.Value = clsReqcompteutilisateur.PI_CODEPIECE;
            if (clsReqcompteutilisateur.PI_CODEPIECE == "") vppParamPI_CODEPIECE.Value = DBNull.Value;
            SqlParameter vppParamCU_NUMEROPIECE = new SqlParameter("@CU_NUMEROPIECE", SqlDbType.VarChar, 1000);
            vppParamCU_NUMEROPIECE.Value = clsReqcompteutilisateur.CU_NUMEROPIECE;
            if (clsReqcompteutilisateur.CU_NUMEROPIECE == "") vppParamCU_NUMEROPIECE.Value = DBNull.Value;
            SqlParameter vppParamCU_DATEPIECE = new SqlParameter("@CU_DATEPIECE", SqlDbType.DateTime);
            vppParamCU_DATEPIECE.Value = clsReqcompteutilisateur.CU_DATEPIECE;
            SqlParameter vppParamCU_NOMBRECONNECTION = new SqlParameter("@CU_NOMBRECONNECTION", SqlDbType.VarChar, 25);
            vppParamCU_NOMBRECONNECTION.Value = clsReqcompteutilisateur.CU_NOMBRECONNECTION;
            SqlParameter vppParamCU_CLESESSION = new SqlParameter("@CU_CLESESSION", SqlDbType.VarChar, 1000);
            vppParamCU_CLESESSION.Value = clsReqcompteutilisateur.CU_CLESESSION;
            if (clsReqcompteutilisateur.CU_CLESESSION == "") vppParamCU_CLESESSION.Value = DBNull.Value;
            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQCOMPTEUTILISATEUR  @CU_CODECOMPTEUTULISATEUR, @AG_CODEAGENCE, @TU_CODETYPEUTILISATEUR, @CU_NUMEROUTILISATEUR, @CU_ADRESSEGEOGRAPHIQUEUTILISATEUR, @CU_NOMUTILISATEUR, @CU_CONTACT, @CU_EMAIL, @CU_LOGIN, @CU_MOTDEPASSE, @CU_DATECREATION, @CU_DATECLOTURE, @CU_TOKEN, @PI_CODEPIECE, @CU_NUMEROPIECE, @CU_DATEPIECE, @CU_NOMBRECONNECTION, @CU_CLESESSION, @CODECRYPTAGE, 1 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamCU_CODECOMPTEUTULISATEUR);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamTU_CODETYPEUTILISATEUR);
            vppSqlCmd.Parameters.Add(vppParamCU_NUMEROUTILISATEUR);
            vppSqlCmd.Parameters.Add(vppParamCU_ADRESSEGEOGRAPHIQUEUTILISATEUR);
            vppSqlCmd.Parameters.Add(vppParamCU_NOMUTILISATEUR);
            vppSqlCmd.Parameters.Add(vppParamCU_CONTACT);
            vppSqlCmd.Parameters.Add(vppParamCU_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamCU_LOGIN);
            vppSqlCmd.Parameters.Add(vppParamCU_MOTDEPASSE);
            vppSqlCmd.Parameters.Add(vppParamCU_DATECREATION);
            vppSqlCmd.Parameters.Add(vppParamCU_DATECLOTURE);
            vppSqlCmd.Parameters.Add(vppParamCU_TOKEN);
            vppSqlCmd.Parameters.Add(vppParamPI_CODEPIECE);
            vppSqlCmd.Parameters.Add(vppParamCU_NUMEROPIECE);
            vppSqlCmd.Parameters.Add(vppParamCU_DATEPIECE);
            vppSqlCmd.Parameters.Add(vppParamCU_NOMBRECONNECTION);
            vppSqlCmd.Parameters.Add(vppParamCU_CLESESSION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_REQCOMPTEUTILISATEUR  @CU_CODECOMPTEUTULISATEUR, @AG_CODEAGENCE, @TU_CODETYPEUTILISATEUR, '' , '' , '' , '' , '' , '' , '' , '' , '' , '' , @PI_CODEPIECE, '' , '' , '' , '' , @CODECRYPTAGE, 2 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsReqcompteutilisateur </returns>
        ///<author>Home Technology</author>
        public List<clsReqcompteutilisateur> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, CU_NUMEROUTILISATEUR, CU_ADRESSEGEOGRAPHIQUEUTILISATEUR, CU_NOMUTILISATEUR, CU_CONTACT, CU_EMAIL, CU_LOGIN, CU_MOTDEPASSE, CU_DATECREATION, CU_DATECLOTURE, CU_TOKEN, PI_CODEPIECE, CU_NUMEROPIECE, CU_DATEPIECE, CU_NOMBRECONNECTION, CU_CLESESSION FROM dbo.FT_REQCOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            List<clsReqcompteutilisateur> clsReqcompteutilisateurs = new List<clsReqcompteutilisateur>();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
                    clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR = clsDonnee.vogDataReader["CU_CODECOMPTEUTULISATEUR"].ToString();
                    clsReqcompteutilisateur.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsReqcompteutilisateur.TU_CODETYPEUTILISATEUR = clsDonnee.vogDataReader["TU_CODETYPEUTILISATEUR"].ToString();
                    clsReqcompteutilisateur.CU_NUMEROUTILISATEUR = clsDonnee.vogDataReader["CU_NUMEROUTILISATEUR"].ToString();
                    clsReqcompteutilisateur.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = clsDonnee.vogDataReader["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                    clsReqcompteutilisateur.CU_NOMUTILISATEUR = clsDonnee.vogDataReader["CU_NOMUTILISATEUR"].ToString();
                    clsReqcompteutilisateur.CU_CONTACT = clsDonnee.vogDataReader["CU_CONTACT"].ToString();
                    clsReqcompteutilisateur.CU_EMAIL = clsDonnee.vogDataReader["CU_EMAIL"].ToString();
                    clsReqcompteutilisateur.CU_LOGIN = clsDonnee.vogDataReader["CU_LOGIN"].ToString();
                    clsReqcompteutilisateur.CU_MOTDEPASSE = clsDonnee.vogDataReader["CU_MOTDEPASSE"].ToString();
                    clsReqcompteutilisateur.CU_DATECREATION = DateTime.Parse(clsDonnee.vogDataReader["CU_DATECREATION"].ToString());
                    clsReqcompteutilisateur.CU_DATECLOTURE = DateTime.Parse(clsDonnee.vogDataReader["CU_DATECLOTURE"].ToString());
                    clsReqcompteutilisateur.CU_TOKEN = clsDonnee.vogDataReader["CU_TOKEN"].ToString();
                    clsReqcompteutilisateur.PI_CODEPIECE = clsDonnee.vogDataReader["PI_CODEPIECE"].ToString();
                    clsReqcompteutilisateur.CU_NUMEROPIECE = clsDonnee.vogDataReader["CU_NUMEROPIECE"].ToString();
                    clsReqcompteutilisateur.CU_DATEPIECE = DateTime.Parse(clsDonnee.vogDataReader["CU_DATEPIECE"].ToString());
                    clsReqcompteutilisateur.CU_NOMBRECONNECTION = clsDonnee.vogDataReader["CU_NOMBRECONNECTION"].ToString();
                    clsReqcompteutilisateur.CU_CLESESSION = clsDonnee.vogDataReader["CU_CLESESSION"].ToString();
                    clsReqcompteutilisateurs.Add(clsReqcompteutilisateur);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsReqcompteutilisateurs;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsReqcompteutilisateur </returns>
        ///<author>Home Technology</author>
        public List<clsReqcompteutilisateur> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsReqcompteutilisateur> clsReqcompteutilisateurs = new List<clsReqcompteutilisateur>();
            DataSet Dataset = new DataSet();

            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT  CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, CU_NUMEROUTILISATEUR, CU_ADRESSEGEOGRAPHIQUEUTILISATEUR, CU_NOMUTILISATEUR, CU_CONTACT, CU_EMAIL, CU_LOGIN, CU_MOTDEPASSE, CU_DATECREATION, CU_DATECLOTURE, CU_TOKEN, PI_CODEPIECE, CU_NUMEROPIECE, CU_DATEPIECE, CU_NOMBRECONNECTION, CU_CLESESSION FROM dbo.FT_REQCOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
                    clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CU_CODECOMPTEUTULISATEUR"].ToString();
                    clsReqcompteutilisateur.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsReqcompteutilisateur.TU_CODETYPEUTILISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["TU_CODETYPEUTILISATEUR"].ToString();
                    clsReqcompteutilisateur.CU_NUMEROUTILISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CU_NUMEROUTILISATEUR"].ToString();
                    clsReqcompteutilisateur.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                    clsReqcompteutilisateur.CU_NOMUTILISATEUR = Dataset.Tables["TABLE"].Rows[Idx]["CU_NOMUTILISATEUR"].ToString();
                    clsReqcompteutilisateur.CU_CONTACT = Dataset.Tables["TABLE"].Rows[Idx]["CU_CONTACT"].ToString();
                    clsReqcompteutilisateur.CU_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["CU_EMAIL"].ToString();
                    clsReqcompteutilisateur.CU_LOGIN = Dataset.Tables["TABLE"].Rows[Idx]["CU_LOGIN"].ToString();
                    clsReqcompteutilisateur.CU_MOTDEPASSE = Dataset.Tables["TABLE"].Rows[Idx]["CU_MOTDEPASSE"].ToString();
                    clsReqcompteutilisateur.CU_DATECREATION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CU_DATECREATION"].ToString());
                    clsReqcompteutilisateur.CU_DATECLOTURE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CU_DATECLOTURE"].ToString());
                    clsReqcompteutilisateur.CU_TOKEN = Dataset.Tables["TABLE"].Rows[Idx]["CU_TOKEN"].ToString();
                    clsReqcompteutilisateur.PI_CODEPIECE = Dataset.Tables["TABLE"].Rows[Idx]["PI_CODEPIECE"].ToString();
                    clsReqcompteutilisateur.CU_NUMEROPIECE = Dataset.Tables["TABLE"].Rows[Idx]["CU_NUMEROPIECE"].ToString();
                    clsReqcompteutilisateur.CU_DATEPIECE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["CU_DATEPIECE"].ToString());
                    clsReqcompteutilisateur.CU_NOMBRECONNECTION = Dataset.Tables["TABLE"].Rows[Idx]["CU_NOMBRECONNECTION"].ToString();
                    clsReqcompteutilisateur.CU_CLESESSION = Dataset.Tables["TABLE"].Rows[Idx]["CU_CLESESSION"].ToString();
                    clsReqcompteutilisateurs.Add(clsReqcompteutilisateur);
                }
                Dataset.Dispose();
            }
            return clsReqcompteutilisateurs;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        //public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        //{
        //    pvpChoixCritere1(clsDonnee, vppCritere);
        //    this.vapRequete = "SELECT *  FROM dbo.FT_REQCOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
        //    this.vapCritere = "";
        //    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //    return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        //}

        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT * FROM dbo.FT_REQCOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";

            var sqlCommand = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(sqlCommand, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetRechercheUtilisateur(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@TU_CODETYPEUTILISATEUR", "@CU_NUMEROUTILISATEUR", "@CU_CONTACT", "@CL_CODECOMPTEZENITH", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
            this.vapRequete = "EXEC [dbo].[PS_REQCOMPTEUTILISATEUR] @TU_CODETYPEUTILISATEUR,@CU_NUMEROUTILISATEUR,	@CU_CONTACT,@CL_CODECOMPTEZENITH,@TYPEOPERATION,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTILISATEUR, AN_CODEANTENNE, AG_CODEAGENT, TU_CODETYPECOMPTEUTILISATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgPasswordRequest(clsDonnee clsDonnee, string CL_CONTACT, string CU_LOGIN, string TYPEOPERATION)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@CL_CONTACT", "@CU_LOGIN", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, CL_CONTACT, CU_LOGIN, TYPEOPERATION };
            this.vapRequete = "EXEC PS_MOBILEDEMANDEMOTDEPASSE  @CL_CONTACT,@CU_LOGIN,@TYPEOPERATION,@CODECRYPTAGE    ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            this.vapRequete = "SELECT CU_CODECOMPTEUTULISATEUR , CU_NOMUTILISATEUR FROM dbo.FT_REQCOMPTEUTILISATEUR(@CODECRYPTAGE) " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTILISATEUR, AN_CODEANTENNE, AG_CODEAGENT, TU_CODETYPECOMPTEUTILISATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgLogin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            string vlpCU_LOGIN = vppCritere[1].ToUpper();
            string vlpCU_MOTDEPASSE = vppCritere[2].ToUpper();
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@top_user", "@CU_LOGIN", "@CU_MOTDEPASSE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vlpCU_LOGIN, vlpCU_MOTDEPASSE };
            this.vapRequete = "EXEC PS_LOGIN @top_user,@CU_LOGIN,@CU_MOTDEPASSE,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }




        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTILISATEUR, AN_CODEANTENNE, AG_CODEAGENT, TU_CODETYPECOMPTEUTILISATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgUpdateFirstconnexion(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> clsReqcompteutilisateurs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur>();

            string vlpCU_MOTDEPASSEOLD = vppCritere[1].ToUpper();
            string vlpCU_LOGINOLD = vppCritere[2].ToUpper();
            string vlpCU_MOTDEPASSENEW = vppCritere[3].ToUpper();
            string vlpCU_LOGINNEW = vppCritere[4].ToUpper();
            string vlpCU_CLESESSION = vppCritere[5].ToUpper();
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@TU_CODETYPEUTILISATEUR", "@CU_MOTDEPASSEOLD", "@CU_LOGINOLD", "@CU_MOTDEPASSENEW", "@CU_LOGINNEW", "@CU_CLESESSION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vlpCU_MOTDEPASSEOLD, vlpCU_LOGINOLD, vlpCU_MOTDEPASSENEW, vlpCU_LOGINNEW, vlpCU_CLESESSION };
            this.vapRequete = "	EXEC  [dbo].[PS_USERUPDATELOGINPASSWORDFIRSTCONNEXION] @TU_CODETYPEUTILISATEUR  ,@CU_MOTDEPASSEOLD ,@CU_LOGINOLD,@CU_MOTDEPASSENEW ,@CU_LOGINNEW,@CU_CLESESSION,@CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            DataSet DataSet = new DataSet();
            DataSet = clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);


            if (DataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow DataRow in DataSet.Tables[0].Rows)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = DataRow["SL_CODEMESSAGE"].ToString();
                    clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = DataRow["SL_RESULTAT"].ToString();
                    clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = DataRow["SL_MESSAGE"].ToString();
                    clsReqcompteutilisateurs.Add(clsReqcompteutilisateurDTOR);
                }
            }
            else
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_LOGIN_OU_MOT_DE_PASSE_INVALIDE;
                clsReqcompteutilisateurs.Add(clsReqcompteutilisateurDTOR);
            }

            return clsReqcompteutilisateurs;
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@CU_CODECOMPTEUTULISATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@CU_CODECOMPTEUTULISATEUR", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND AG_CODEAGENCE=@AG_CODEAGENCE AND TU_CODETYPEUTILISATEUR=@TU_CODETYPEUTILISATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@CU_CODECOMPTEUTULISATEUR", "@AG_CODEAGENCE", "@TU_CODETYPEUTILISATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND AG_CODEAGENCE=@AG_CODEAGENCE AND TU_CODETYPEUTILISATEUR=@TU_CODETYPEUTILISATEUR AND PI_CODEPIECE=@PI_CODEPIECE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@CU_CODECOMPTEUTULISATEUR", "@AG_CODEAGENCE", "@TU_CODETYPEUTILISATEUR", "@PI_CODEPIECE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
            }
        }



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE)</summary>
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
                    this.vapCritere = "WHERE TU_CODETYPEUTILISATEUR=@TU_CODETYPEUTILISATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@TU_CODETYPEUTILISATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TU_CODETYPEUTILISATEUR=@TU_CODETYPEUTILISATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TU_CODETYPEUTILISATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND AG_CODEAGENCE=@AG_CODEAGENCE AND TU_CODETYPEUTILISATEUR=@TU_CODETYPEUTILISATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@CU_CODECOMPTEUTULISATEUR", "@AG_CODEAGENCE", "@TU_CODETYPEUTILISATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE CU_CODECOMPTEUTULISATEUR=@CU_CODECOMPTEUTULISATEUR AND AG_CODEAGENCE=@AG_CODEAGENCE AND TU_CODETYPEUTILISATEUR=@TU_CODETYPEUTILISATEUR AND PI_CODEPIECE=@PI_CODEPIECE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@CU_CODECOMPTEUTULISATEUR", "@AG_CODEAGENCE", "@TU_CODETYPEUTILISATEUR", "@PI_CODEPIECE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
            }
        }

        public void pvpChoixCritere11(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE TU_CODETYPEUTILISATEUR=@TU_CODETYPEUTILISATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@TU_CODETYPEUTILISATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TU_CODETYPEUTILISATEUR=@TU_CODETYPEUTILISATEUR";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@TU_CODETYPEUTILISATEUR" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
            }
        }

        public void pvpChoixCritere2(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
            }
        }
    }
}
