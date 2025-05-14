using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.BOJ.BusinessObjects;
using MgRequeteClients.Tools.Classes;

namespace MgRequeteClients.DAL.Classes
{
    public class clsParametreWSDAL
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT COUNT(PP_CODEPARAMETRE) AS PP_CODEPARAMETRE  FROM PARAMETRE " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MIN(PP_CODEPARAMETRE) AS PP_CODEPARAMETRE  FROM PARAMETRE " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MAX(PP_CODEPARAMETRE) AS PP_CODEPARAMETRE  FROM PARAMETRE " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsParametre">clsParametre</param>
		///<author>Home Technologie</author>
		public clsParametre pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT PP_LIBELLE,PP_BORNEMIN,PP_BORNEMAX,PP_MONTANTMINI,PP_MONTANTMAXI,PP_TAUX,PP_MONTANT,PP_VALEUR,PL_CODENUMCOMPTE,PP_AFFICHER FROM PARAMETRE " + this.vapCritere;
            this.vapCritere = "";

            clsParametre clsParametre = new clsParametre();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsParametre.PP_LIBELLE = clsDonnee.vogDataReader["PP_LIBELLE"].ToString();
                    clsParametre.PP_BORNEMIN = double.Parse(clsDonnee.vogDataReader["PP_BORNEMIN"].ToString());
                    clsParametre.PP_BORNEMAX = double.Parse(clsDonnee.vogDataReader["PP_BORNEMAX"].ToString());
                    clsParametre.PP_MONTANTMINI = double.Parse(clsDonnee.vogDataReader["PP_MONTANTMINI"].ToString());
                    clsParametre.PP_MONTANTMAXI = double.Parse(clsDonnee.vogDataReader["PP_MONTANTMAXI"].ToString());
                    clsParametre.PP_TAUX = decimal.Parse(clsDonnee.vogDataReader["PP_TAUX"].ToString());
                    clsParametre.PP_MONTANT = double.Parse(clsDonnee.vogDataReader["PP_MONTANT"].ToString());
                    clsParametre.PP_VALEUR = clsDonnee.vogDataReader["PP_VALEUR"].ToString();
                    clsParametre.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsParametre.PP_AFFICHER = clsDonnee.vogDataReader["PP_AFFICHER"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsParametre;
        }


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête</param>
        ///<param name="clsParametre">clsParametre</param>
        ///<author>Home Technologie</author>
        public clsParametre pvgTableLabelCrypter(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',PP_LIBELLE) AS varchar(150)) AS PP_LIBELLE,PP_BORNEMIN,PP_BORNEMAX,PP_MONTANTMINI,PP_MONTANTMAXI,PP_TAUX,PP_MONTANT,CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',PP_VALEUR) AS varchar(150)) AS PP_VALEUR,PL_CODENUMCOMPTE,PP_AFFICHER FROM PARAMETRE " + this.vapCritere;
            this.vapCritere = "";

            clsParametre clsParametre = new clsParametre();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsParametre.PP_LIBELLE = clsDonnee.vogDataReader["PP_LIBELLE"].ToString();
                    clsParametre.PP_BORNEMIN = double.Parse(clsDonnee.vogDataReader["PP_BORNEMIN"].ToString());
                    clsParametre.PP_BORNEMAX = double.Parse(clsDonnee.vogDataReader["PP_BORNEMAX"].ToString());
                    clsParametre.PP_MONTANTMINI = double.Parse(clsDonnee.vogDataReader["PP_MONTANTMINI"].ToString());
                    clsParametre.PP_MONTANTMAXI = double.Parse(clsDonnee.vogDataReader["PP_MONTANTMAXI"].ToString());
                    clsParametre.PP_TAUX = decimal.Parse(clsDonnee.vogDataReader["PP_TAUX"].ToString());
                    clsParametre.PP_MONTANT = double.Parse(clsDonnee.vogDataReader["PP_MONTANT"].ToString());
                    clsParametre.PP_VALEUR = clsDonnee.vogDataReader["PP_VALEUR"].ToString();
                    clsParametre.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsParametre.PP_AFFICHER = clsDonnee.vogDataReader["PP_AFFICHER"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsParametre;
        }

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête</param>
        ///<param name="clsParametre">clsParametre</param>
        ///<author>Home Technologie</author>
        public clsAgence pvgTableLabelAgenceCrypter(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE   ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE" };
            vapValeurParametre = new object[] { vppCritere[0] };
            this.vapRequete = "SELECT AG_CODEAGENCE,AG_RAISONSOCIAL, CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',AG_CINETSITEID) AS varchar(150)) AS AG_CINETSITEID,CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',AG_CINETAPIKEY) AS varchar(150)) AS AG_CINETAPIKEY,CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',AG_CINETAPIPWD) AS varchar(150)) AS AG_CINETAPIPWD,    AG_CINETURLNOTIFICATIONZENITH,AG_CINETURLNOTIFICATIONTONTINE FROM AGENCE " + this.vapCritere;
            this.vapCritere = "";
            clsAgence clsAgence = new clsAgence();
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsAgence.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsAgence.AG_RAISONSOCIAL = clsDonnee.vogDataReader["AG_RAISONSOCIAL"].ToString();
                    clsAgence.AG_CINETSITEID = clsDonnee.vogDataReader["AG_CINETSITEID"].ToString();
                    clsAgence.AG_CINETAPIKEY = clsDonnee.vogDataReader["AG_CINETAPIKEY"].ToString();
                    clsAgence.AG_CINETAPIPWD = clsDonnee.vogDataReader["AG_CINETAPIPWD"].ToString();
                    clsAgence.AG_CINETURLNOTIFICATIONZENITH = clsDonnee.vogDataReader["AG_CINETURLNOTIFICATIONZENITH"].ToString();
                    clsAgence.AG_CINETURLNOTIFICATIONTONTINE = clsDonnee.vogDataReader["AG_CINETURLNOTIFICATIONTONTINE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsAgence;
        }


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête</param>
        ///<param name="clsParametre">clsParametre</param>
        ///<author>Home Technologie</author>
        public clsAgence pvgTableLabelAgenceCrypter2(clsDonnee clsDonnee, params string[] vppCritere)
        {
            // AG_CODEAGENCE = '1000' AND TO_CODETYPETRANSFERT = '18' AND FO_CODEFOURNISSEURAPI = '02'
            string vlpFD_ACTIF = "O";
            string vlpFO_ACTIF = "O";

            this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TO_CODETYPETRANSFERT = @TO_CODETYPETRANSFERT AND FO_CODEFOURNISSEURAPI = @FO_CODEFOURNISSEURAPI AND FD_ACTIF = @FD_ACTIF AND FO_ACTIF = @FO_ACTIF";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@TO_CODETYPETRANSFERT", "@FO_CODEFOURNISSEURAPI", "@FD_ACTIF", "@FO_ACTIF" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vlpFD_ACTIF, vlpFO_ACTIF };
            this.vapRequete = "SELECT AG_CODEAGENCE,AG_RAISONSOCIAL, CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',FD_CINETSITEID) AS varchar(150)) AS FD_CINETSITEID,CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',FD_CINETAPIKEY) AS varchar(150)) AS FD_CINETAPIKEY,CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',FD_CINETAPIPWD) AS varchar(150)) AS FD_CINETAPIPWD  ,CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',FD_TOKENTOUCHLOGIN) AS varchar(150)) AS FD_TOKENTOUCHLOGIN,CAST(DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',FD_TOKENTOUCHPWD) AS varchar(150)) AS FD_TOKENTOUCHPWD  ,    FD_CINETURLNOTIFICATIONZENITH,FD_CINETURLNOTIFICATIONTONTINE,FD_URLINTOUCHCASHIN,FD_URLINTOUCHCASHOUT FROM VUE_FOURNISSEURAPIMOBILEMONEY " + this.vapCritere;
            this.vapCritere = "";
            clsAgence clsAgence = new clsAgence();
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsAgence.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsAgence.AG_RAISONSOCIAL = clsDonnee.vogDataReader["AG_RAISONSOCIAL"].ToString();
                    clsAgence.AG_CINETSITEID = clsDonnee.vogDataReader["FD_CINETSITEID"].ToString();
                    clsAgence.AG_CINETAPIKEY = clsDonnee.vogDataReader["FD_CINETAPIKEY"].ToString();
                    clsAgence.AG_CINETAPIPWD = clsDonnee.vogDataReader["FD_CINETAPIPWD"].ToString();
                    clsAgence.AG_CINETURLNOTIFICATIONZENITH = clsDonnee.vogDataReader["FD_CINETURLNOTIFICATIONZENITH"].ToString();
                    clsAgence.AG_CINETURLNOTIFICATIONTONTINE = clsDonnee.vogDataReader["FD_CINETURLNOTIFICATIONTONTINE"].ToString();
                    clsAgence.AG_URLINTOUCHCASHIN = clsDonnee.vogDataReader["FD_URLINTOUCHCASHIN"].ToString();
                    clsAgence.AG_URLINTOUCHCASHOUT = clsDonnee.vogDataReader["FD_URLINTOUCHCASHOUT"].ToString();
                    clsAgence.AG_TOKENTOUCHLOGIN = clsDonnee.vogDataReader["FD_TOKENTOUCHLOGIN"].ToString();
                    clsAgence.AG_TOKENTOUCHPWD = clsDonnee.vogDataReader["FD_TOKENTOUCHPWD"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsAgence;
        }


        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsParametre">clsParametre</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee, clsParametre clsParametre)
        {
            //Préparation des paramètres

            SqlParameter vppParamSO_CODESOCIETE = new SqlParameter("@SO_CODESOCIETE", SqlDbType.VarChar, 4);
            vppParamSO_CODESOCIETE.Value = clsParametre.SO_CODESOCIETE;

            SqlParameter vppParamPP_CODEPARAMETRE = new SqlParameter("@PP_CODEPARAMETRE", SqlDbType.VarChar, 5);
            vppParamPP_CODEPARAMETRE.Value = clsParametre.PP_CODEPARAMETRE;

            SqlParameter vppParamPP_LIBELLE = new SqlParameter("@PP_LIBELLE", SqlDbType.VarChar, 150);
            vppParamPP_LIBELLE.Value = clsParametre.PP_LIBELLE;

            SqlParameter vppParamPP_BORNEMIN = new SqlParameter("@PP_BORNEMIN", SqlDbType.Money);
            vppParamPP_BORNEMIN.Value = clsParametre.PP_BORNEMIN;

            SqlParameter vppParamPP_BORNEMAX = new SqlParameter("@PP_BORNEMAX", SqlDbType.Money);
            vppParamPP_BORNEMAX.Value = clsParametre.PP_BORNEMAX;

            SqlParameter vppParamPP_MONTANTMINI = new SqlParameter("@PP_MONTANTMINI", SqlDbType.Money);
            vppParamPP_MONTANTMINI.Value = clsParametre.PP_MONTANTMINI;

            SqlParameter vppParamPP_MONTANTMAXI = new SqlParameter("@PP_MONTANTMAXI", SqlDbType.Money);
            vppParamPP_MONTANTMAXI.Value = clsParametre.PP_MONTANTMAXI;

            SqlParameter vppParamPP_TAUX = new SqlParameter("@PP_TAUX", SqlDbType.Decimal);
            vppParamPP_TAUX.Value = clsParametre.PP_TAUX;

            SqlParameter vppParamPP_MONTANT = new SqlParameter("@PP_MONTANT", SqlDbType.Money);
            vppParamPP_MONTANT.Value = clsParametre.PP_MONTANT;

            SqlParameter vppParamPP_VALEUR = new SqlParameter("@PP_VALEUR", SqlDbType.VarChar, 150);
            vppParamPP_VALEUR.Value = clsParametre.PP_VALEUR;

            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_CODENUMCOMPTE.Value = clsParametre.PL_CODENUMCOMPTE;

            SqlParameter vppParamPP_AFFICHER = new SqlParameter("@PP_AFFICHER", SqlDbType.VarChar, 1);
            vppParamPP_AFFICHER.Value = clsParametre.PP_AFFICHER;

            //Préparation de la commande
            this.vapRequete = "INSERT INTO PARAMETRE " +
            " (SO_CODESOCIETE,PP_CODEPARAMETRE,PP_LIBELLE,PP_BORNEMIN,PP_BORNEMAX,PP_MONTANTMINI,PP_MONTANTMAXI,PP_TAUX,PP_MONTANT,PP_VALEUR,PL_CODENUMCOMPTE,PP_AFFICHER)" +
            " VALUES(@SO_CODESOCIETE,@PP_CODEPARAMETRE,@PP_LIBELLE,@PP_BORNEMIN,@PP_BORNEMAX,@PP_MONTANTMINI,@PP_MONTANTMAXI,@PP_TAUX,@PP_MONTANT,@PP_VALEUR,@PL_CODENUMCOMPTE,@PP_AFFICHER)";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamSO_CODESOCIETE);
            vppSqlCmd.Parameters.Add(vppParamPP_CODEPARAMETRE);
            vppSqlCmd.Parameters.Add(vppParamPP_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamPP_BORNEMIN);
            vppSqlCmd.Parameters.Add(vppParamPP_BORNEMAX);
            vppSqlCmd.Parameters.Add(vppParamPP_MONTANTMINI);
            vppSqlCmd.Parameters.Add(vppParamPP_MONTANTMAXI);
            vppSqlCmd.Parameters.Add(vppParamPP_TAUX);
            vppSqlCmd.Parameters.Add(vppParamPP_MONTANT);
            vppSqlCmd.Parameters.Add(vppParamPP_VALEUR);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPP_AFFICHER);

            //Ouverture de la connection et exécution de la commande
            vppSqlCmd.ExecuteNonQuery();
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsParametre">clsParametre</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsParametre clsParametre, params string[] vppCritere)
        {
            //Préparation des paramètres

            SqlParameter vppParamSO_CODESOCIETE = new SqlParameter("@SO_CODESOCIETE1", SqlDbType.VarChar, 4);
            vppParamSO_CODESOCIETE.Value = clsParametre.SO_CODESOCIETE;

            SqlParameter vppParamPP_LIBELLE = new SqlParameter("@PP_LIBELLE", SqlDbType.VarChar, 150);
            vppParamPP_LIBELLE.Value = clsParametre.PP_LIBELLE;

            SqlParameter vppParamPP_BORNEMIN = new SqlParameter("@PP_BORNEMIN", SqlDbType.Money);
            vppParamPP_BORNEMIN.Value = clsParametre.PP_BORNEMIN;

            SqlParameter vppParamPP_BORNEMAX = new SqlParameter("@PP_BORNEMAX", SqlDbType.Money);
            vppParamPP_BORNEMAX.Value = clsParametre.PP_BORNEMAX;

            SqlParameter vppParamPP_MONTANTMINI = new SqlParameter("@PP_MONTANTMINI", SqlDbType.Money);
            vppParamPP_MONTANTMINI.Value = clsParametre.PP_MONTANTMINI;

            SqlParameter vppParamPP_MONTANTMAXI = new SqlParameter("@PP_MONTANTMAXI", SqlDbType.Money);
            vppParamPP_MONTANTMAXI.Value = clsParametre.PP_MONTANTMAXI;

            SqlParameter vppParamPP_TAUX = new SqlParameter("@PP_TAUX", SqlDbType.Decimal);
            vppParamPP_TAUX.Value = clsParametre.PP_TAUX;

            SqlParameter vppParamPP_MONTANT = new SqlParameter("@PP_MONTANT", SqlDbType.Money);
            vppParamPP_MONTANT.Value = clsParametre.PP_MONTANT;

            SqlParameter vppParamPP_VALEUR = new SqlParameter("@PP_VALEUR", SqlDbType.VarChar, 150);
            vppParamPP_VALEUR.Value = clsParametre.PP_VALEUR;

            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_CODENUMCOMPTE.Value = clsParametre.PL_CODENUMCOMPTE;

            SqlParameter vppParamPP_AFFICHER = new SqlParameter("@PP_AFFICHER", SqlDbType.VarChar, 1);
            vppParamPP_AFFICHER.Value = clsParametre.PP_AFFICHER;

            pvpChoixCritere(vppCritere);

            //Préparation de la commande
            this.vapRequete = "UPDATE PARAMETRE SET " +
            " SO_CODESOCIETE = @SO_CODESOCIETE1 , " +
            " PP_LIBELLE = @PP_LIBELLE , " +
            " PP_BORNEMIN = @PP_BORNEMIN , " +
            " PP_BORNEMAX = @PP_BORNEMAX , " +
            " PP_MONTANTMINI = @PP_MONTANTMINI , " +
            " PP_MONTANTMAXI = @PP_MONTANTMAXI , " +
            " PP_TAUX = @PP_TAUX , " +
            " PP_MONTANT = @PP_MONTANT , " +
            " PP_VALEUR = @PP_VALEUR , " +
            " PL_CODENUMCOMPTE = @PL_CODENUMCOMPTE  " + this.vapCritere;

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamSO_CODESOCIETE);
            vppSqlCmd.Parameters.Add(vppParamPP_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamPP_BORNEMIN);
            vppSqlCmd.Parameters.Add(vppParamPP_BORNEMAX);
            vppSqlCmd.Parameters.Add(vppParamPP_MONTANTMINI);
            vppSqlCmd.Parameters.Add(vppParamPP_MONTANTMAXI);
            vppSqlCmd.Parameters.Add(vppParamPP_TAUX);
            vppSqlCmd.Parameters.Add(vppParamPP_MONTANT);
            vppSqlCmd.Parameters.Add(vppParamPP_VALEUR);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPP_AFFICHER);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "DELETE FROM PARAMETRE " + this.vapCritere;
            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsParametre </returns>
		///<author>Home Technologie</author>
		public List<clsParametre> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsParametre> clsParametres = new List<clsParametre>();

            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM PARAMETRE " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            this.vapCritere = "";
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsParametre clsParametre = new clsParametre();
                    clsParametre.SO_CODESOCIETE = clsDonnee.vogDataReader["SO_CODESOCIETE"].ToString();
                    clsParametre.PP_CODEPARAMETRE = clsDonnee.vogDataReader["PP_CODEPARAMETRE"].ToString();
                    clsParametre.PP_LIBELLE = clsDonnee.vogDataReader["PP_LIBELLE"].ToString();
                    clsParametre.PP_BORNEMIN = double.Parse(clsDonnee.vogDataReader["PP_BORNEMIN"].ToString());
                    clsParametre.PP_BORNEMAX = double.Parse(clsDonnee.vogDataReader["PP_BORNEMAX"].ToString());
                    clsParametre.PP_MONTANTMINI = double.Parse(clsDonnee.vogDataReader["PP_MONTANTMINI"].ToString());
                    clsParametre.PP_MONTANTMAXI = double.Parse(clsDonnee.vogDataReader["PP_MONTANTMAXI"].ToString());
                    clsParametre.PP_TAUX = decimal.Parse(clsDonnee.vogDataReader["PP_TAUX"].ToString());
                    clsParametre.PP_MONTANT = double.Parse(clsDonnee.vogDataReader["PP_MONTANT"].ToString());
                    clsParametre.PP_VALEUR = clsDonnee.vogDataReader["PP_VALEUR"].ToString();
                    clsParametre.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsParametre.PP_AFFICHER = clsDonnee.vogDataReader["PP_AFFICHER"].ToString();
                    clsParametres.Add(clsParametre);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsParametres;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsParametre </returns>
		///<author>Home Technologie</author>
		public List<clsParametre> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsParametre> clsParametres = new List<clsParametre>();
            DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM PARAMETRE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsParametre clsParametre = new clsParametre();
                    clsParametre.SO_CODESOCIETE = Dataset.Tables["TABLE"].Rows[Idx]["SO_CODESOCIETE"].ToString();
                    clsParametre.PP_CODEPARAMETRE = Dataset.Tables["TABLE"].Rows[Idx]["PP_CODEPARAMETRE"].ToString();
                    clsParametre.PP_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PP_LIBELLE"].ToString();
                    clsParametre.PP_BORNEMIN = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_BORNEMIN"].ToString());
                    clsParametre.PP_BORNEMAX = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_BORNEMAX"].ToString());
                    clsParametre.PP_MONTANTMINI = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_MONTANTMINI"].ToString());
                    clsParametre.PP_MONTANTMAXI = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_MONTANTMAXI"].ToString());
                    clsParametre.PP_TAUX = decimal.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_TAUX"].ToString());
                    clsParametre.PP_MONTANT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PP_MONTANT"].ToString());
                    clsParametre.PP_VALEUR = Dataset.Tables["TABLE"].Rows[Idx]["PP_VALEUR"].ToString();
                    clsParametre.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
                    clsParametre.PP_AFFICHER = Dataset.Tables["TABLE"].Rows[Idx]["PP_AFFICHER"].ToString();
                    clsParametres.Add(clsParametre);
                }
                Dataset.Dispose();
            }
            return clsParametres;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT * FROM VUE_PARAMETRE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT SO_CODESOCIETE,PP_CODEPARAMETRE,PP_LIBELLE,PP_BORNEMIN,PP_BORNEMAX,PP_MONTANTMINI,PP_MONTANTMAXI,PP_TAUX,PP_MONTANT,PP_VALEUR,PL_CODENUMCOMPTE,PP_AFFICHER FROM VUE_PARAMETRE " + this.vapCritere + " AND PP_AFFICHER='O' ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EF_INDEX, EC_CODECRAN ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetTypePeriode(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@EC_CODECRAN", "@TY_ACTIF" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
            this.vapRequete = "SELECT *  FROM dbo.FT_PARAMECRANTYPEPERIODE( @EC_CODECRAN,@TY_ACTIF) ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PP_CODEPARAMETRE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {

                case 0:
                    this.vapCritere = " WHERE PP_AFFICHER='O' ";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = " WHERE PP_CODEPARAMETRE=@PP_CODEPARAMETRE   ";
                    vapNomParametre = new string[] { "@PP_CODEPARAMETRE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PP_CODEPARAMETRE=@PP_CODEPARAMETRE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PP_CODEPARAMETRE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
            }
        }
    }
}
