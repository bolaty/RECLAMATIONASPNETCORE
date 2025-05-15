using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.DAL.Interfaces;
using MgRequeteClients.BOJ.BusinessObjects;
using MgRequeteClients.Tools.Classes;
using Microsoft.Data.SqlClient;

namespace MgRequeteClients.DAL.Classes
{
    public class clsPlancomptableWSDAL : ITableDAL<clsPlancomptable>
    {

        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT COUNT(PL_CODENUMCOMPTE) AS PL_CODENUMCOMPTE  FROM PLANCOMPTABLE " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MIN(PL_CODENUMCOMPTE) AS PL_CODENUMCOMPTE  FROM PLANCOMPTABLE " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MAX(PL_CODENUMCOMPTE) AS PL_CODENUMCOMPTE  FROM PLANCOMPTABLE " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsPlancomptable">clsPlancomptable</param>
		///<author>Home Technologie</author>
		public clsPlancomptable pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT PL_CODENUMCOMPTE,PL_LIBELLE,PL_COMPTECOLLECTIF,PL_REPORTDEBIT,PL_REPORTCREDIT,PL_MONTANTPERIODEPRECEDENTDEBIT,PL_MONTANTPERIODEPRECEDENTCREDIT,PL_MONTANTPERIODEDEBITENCOURS,PL_MONTANTPERIODECREDITENCOURS,PL_MONTANTSOLDEFINALDEBIT,PL_MONTANTSOLDEFINALCREDIT,PL_SENS,PL_TYPECOMPTE,PL_ACTIF,PL_COMPTEREFERENTIELCOMPTABLE FROM PLANCOMPTABLE " + this.vapCritere + "  AND PL_ACTIF='O'";
            this.vapCritere = "";

            clsPlancomptable clsPlancomptable = new clsPlancomptable();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsPlancomptable.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsPlancomptable.PL_LIBELLE = clsDonnee.vogDataReader["PL_LIBELLE"].ToString();
                    clsPlancomptable.PL_COMPTECOLLECTIF = clsDonnee.vogDataReader["PL_COMPTECOLLECTIF"].ToString();
                    clsPlancomptable.PL_REPORTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTDEBIT"].ToString());
                    clsPlancomptable.PL_REPORTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTCREDIT"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURS"].ToString());
                    clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBIT"].ToString());
                    clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALCREDIT"].ToString());
                    clsPlancomptable.PL_SENS = clsDonnee.vogDataReader["PL_SENS"].ToString();
                    clsPlancomptable.PL_TYPECOMPTE = clsDonnee.vogDataReader["PL_TYPECOMPTE"].ToString();
                    clsPlancomptable.PL_ACTIF = clsDonnee.vogDataReader["PL_ACTIF"].ToString();
                    clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE = clsDonnee.vogDataReader["PL_COMPTEREFERENTIELCOMPTABLE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsPlancomptable;
        }

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête</param>
        ///<param name="clsPlancomptable">clsPlancomptable</param>
        ///<author>Home Technologie</author>
        public clsPlancomptable pvgTableLabelAvecSolde(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritereAvecSolde(vppCritere);

            //this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE=@PL_NUMCOMPTE ";
            vapNomParametre = new string[] { "@SO_CODESOCIETE", "@AG_CODEAGENCE", "@PL_NUMCOMPTE", "@JT_DATEJOURNEETRAVAIL" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
            //
            this.vapRequete = "SELECT PL_CODENUMCOMPTE,PL_LIBELLE,PL_TYPECOMPTE,PL_ACTIF,PL_COMPTETIERS,PL_SOLDECOMPTE,PL_SAISIE_ANALYTIQUE,PL_TESTSURCOMPTETIERS FROM " +
            "[dbo].[FC_PLANCOMPTABLEAVECSOLDEUNITAIRE](@SO_CODESOCIETE,	@AG_CODEAGENCE,	@PL_NUMCOMPTE,@JT_DATEJOURNEETRAVAIL) "
            + this.vapCritere + " ";
            this.vapCritere = "";

            clsPlancomptable clsPlancomptable = new clsPlancomptable();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandTimeout = 0;

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsPlancomptable.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsPlancomptable.PL_LIBELLE = clsDonnee.vogDataReader["PL_LIBELLE"].ToString();
                    //clsPlancomptable.PL_COMPTECOLLECTIF = clsDonnee.vogDataReader["PL_COMPTECOLLECTIF"].ToString();
                    //clsPlancomptable.PL_REPORTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTDEBIT"].ToString());
                    //clsPlancomptable.PL_REPORTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTCREDIT"].ToString());
                    //clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
                    //clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
                    //clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
                    //clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURS"].ToString());
                    //clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBIT"].ToString());
                    //clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALCREDIT"].ToString());
                    //clsPlancomptable.PL_SENS = clsDonnee.vogDataReader["PL_SENS"].ToString();
                    clsPlancomptable.PL_TYPECOMPTE = clsDonnee.vogDataReader["PL_TYPECOMPTE"].ToString();
                    clsPlancomptable.PL_ACTIF = clsDonnee.vogDataReader["PL_ACTIF"].ToString();
                    //clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE = clsDonnee.vogDataReader["PL_COMPTEREFERENTIELCOMPTABLE"].ToString();
                    //clsPlancomptable.PL_SENS = clsDonnee.vogDataReader["PL_SENS"].ToString();
                    //clsPlancomptable.PL_TYPECOMPTE = clsDonnee.vogDataReader["PL_TYPECOMPTE"].ToString();
                    //clsPlancomptable.PL_ACTIF = clsDonnee.vogDataReader["PL_ACTIF"].ToString();
                    //clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE = clsDonnee.vogDataReader["PL_COMPTEREFERENTIELCOMPTABLE"].ToString();
                    clsPlancomptable.PL_COMPTETIERS = clsDonnee.vogDataReader["PL_COMPTETIERS"].ToString();
                    clsPlancomptable.PL_SAISIE_ANALYTIQUE = clsDonnee.vogDataReader["PL_SAISIE_ANALYTIQUE"].ToString();
                    clsPlancomptable.PL_TESTSURCOMPTETIERS = clsDonnee.vogDataReader["PL_TESTSURCOMPTETIERS"].ToString();
                    clsPlancomptable.PL_SOLDECOMPTE = double.Parse(clsDonnee.vogDataReader["PL_SOLDECOMPTE"].ToString());
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsPlancomptable;
        }

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsPlancomptable">clsPlancomptable</param>
		///<author>Home Technologie</author>
		public clsPlancomptable pvgTableLabel1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere2(vppCritere);
            this.vapRequete = "SELECT PL_NUMCOMPTE,PL_LIBELLE,PL_COMPTECOLLECTIF,PL_REPORTDEBIT,PL_REPORTCREDIT,PL_MONTANTPERIODEPRECEDENTDEBIT,PL_MONTANTPERIODEPRECEDENTCREDIT,PL_MONTANTPERIODEDEBITENCOURS,PL_MONTANTPERIODECREDITENCOURS,PL_MONTANTSOLDEFINALDEBIT,PL_MONTANTSOLDEFINALCREDIT,PL_SENS,PL_TYPECOMPTE,PL_ACTIF,PL_COMPTEREFERENTIELCOMPTABLE FROM PLANCOMPTABLE " + this.vapCritere + "  AND PL_ACTIF='O'";
            this.vapCritere = "";

            clsPlancomptable clsPlancomptable = new clsPlancomptable();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsPlancomptable.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
                    clsPlancomptable.PL_LIBELLE = clsDonnee.vogDataReader["PL_LIBELLE"].ToString();
                    clsPlancomptable.PL_COMPTECOLLECTIF = clsDonnee.vogDataReader["PL_COMPTECOLLECTIF"].ToString();
                    clsPlancomptable.PL_REPORTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTDEBIT"].ToString());
                    clsPlancomptable.PL_REPORTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTCREDIT"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURS"].ToString());
                    clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBIT"].ToString());
                    clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALCREDIT"].ToString());
                    clsPlancomptable.PL_SENS = clsDonnee.vogDataReader["PL_SENS"].ToString();
                    clsPlancomptable.PL_TYPECOMPTE = clsDonnee.vogDataReader["PL_TYPECOMPTE"].ToString();
                    clsPlancomptable.PL_ACTIF = clsDonnee.vogDataReader["PL_ACTIF"].ToString();
                    clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE = clsDonnee.vogDataReader["PL_COMPTEREFERENTIELCOMPTABLE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsPlancomptable;
        }

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPlancomptable">clsPlancomptable</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee, clsPlancomptable clsPlancomptable)
        {
            //Préparation des paramètres

            SqlParameter vppParamSO_CODESOCIETE = new SqlParameter("@SO_CODESOCIETE", SqlDbType.VarChar, 4);
            vppParamSO_CODESOCIETE.Value = clsPlancomptable.SO_CODESOCIETE;

            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_CODENUMCOMPTE.Value = clsPlancomptable.PL_CODENUMCOMPTE;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_NUMCOMPTE.Value = clsPlancomptable.PL_NUMCOMPTE;

            SqlParameter vppParamPL_LIBELLE = new SqlParameter("@PL_LIBELLE", SqlDbType.VarChar, 150);
            vppParamPL_LIBELLE.Value = clsPlancomptable.PL_LIBELLE;

            SqlParameter vppParamPL_COMPTECOLLECTIF = new SqlParameter("@PL_COMPTECOLLECTIF", SqlDbType.VarChar, 25);
            vppParamPL_COMPTECOLLECTIF.Value = clsPlancomptable.PL_COMPTECOLLECTIF;

            SqlParameter vppParamPL_REPORTDEBIT = new SqlParameter("@PL_REPORTDEBIT", SqlDbType.Money);
            vppParamPL_REPORTDEBIT.Value = clsPlancomptable.PL_REPORTDEBIT;

            SqlParameter vppParamPL_REPORTCREDIT = new SqlParameter("@PL_REPORTCREDIT", SqlDbType.Money);
            vppParamPL_REPORTCREDIT.Value = clsPlancomptable.PL_REPORTCREDIT;

            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBIT", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTDEBIT.Value = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT;

            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTCREDIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTCREDIT", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTCREDIT.Value = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT;

            SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURS = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURS", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEDEBITENCOURS.Value = clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS;

            SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURS = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURS", SqlDbType.Money);
            vppParamPL_MONTANTPERIODECREDITENCOURS.Value = clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS;

            SqlParameter vppParamPL_MONTANTSOLDEFINALDEBIT = new SqlParameter("@PL_MONTANTSOLDEFINALDEBIT", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALDEBIT.Value = clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT;

            SqlParameter vppParamPL_MONTANTSOLDEFINALCREDIT = new SqlParameter("@PL_MONTANTSOLDEFINALCREDIT", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALCREDIT.Value = clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT;

            SqlParameter vppParamPL_SENS = new SqlParameter("@PL_SENS", SqlDbType.VarChar, 2);
            vppParamPL_SENS.Value = clsPlancomptable.PL_SENS;

            SqlParameter vppParamPL_TYPECOMPTE = new SqlParameter("@PL_TYPECOMPTE", SqlDbType.VarChar, 1);
            vppParamPL_TYPECOMPTE.Value = clsPlancomptable.PL_TYPECOMPTE;

            SqlParameter vppParamPL_ACTIF = new SqlParameter("@PL_ACTIF", SqlDbType.VarChar, 1);
            vppParamPL_ACTIF.Value = clsPlancomptable.PL_ACTIF;

            SqlParameter vppParamPL_COMPTEREFERENTIELCOMPTABLE = new SqlParameter("@PL_COMPTEREFERENTIELCOMPTABLE", SqlDbType.VarChar, 1);
            vppParamPL_COMPTEREFERENTIELCOMPTABLE.Value = clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE;

            //Préparation de la commande
            this.vapRequete = "INSERT INTO PLANCOMPTABLE " +
            " (SO_CODESOCIETE,PL_CODENUMCOMPTE,PL_NUMCOMPTE,PL_LIBELLE,PL_COMPTECOLLECTIF,PL_REPORTDEBIT,PL_REPORTCREDIT,PL_MONTANTPERIODEPRECEDENTDEBIT,PL_MONTANTPERIODEPRECEDENTCREDIT,PL_MONTANTPERIODEDEBITENCOURS,PL_MONTANTPERIODECREDITENCOURS,PL_MONTANTSOLDEFINALDEBIT,PL_MONTANTSOLDEFINALCREDIT,PL_SENS,PL_TYPECOMPTE,PL_ACTIF,PL_COMPTEREFERENTIELCOMPTABLE)" +
            " VALUES(@SO_CODESOCIETE,@PL_CODENUMCOMPTE,@PL_NUMCOMPTE,@PL_LIBELLE,@PL_COMPTECOLLECTIF,@PL_REPORTDEBIT,@PL_REPORTCREDIT,@PL_MONTANTPERIODEPRECEDENTDEBIT,@PL_MONTANTPERIODEPRECEDENTCREDIT,@PL_MONTANTPERIODEDEBITENCOURS,@PL_MONTANTPERIODECREDITENCOURS,@PL_MONTANTSOLDEFINALDEBIT,@PL_MONTANTSOLDEFINALCREDIT,@PL_SENS,@PL_TYPECOMPTE,@PL_ACTIF,@PL_COMPTEREFERENTIELCOMPTABLE)";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //this.vapRequete = "EXEC [dbo].[PC_PLANCOMPTABLE] @PL_CODENUMCOMPTE,@SO_CODESOCIETE,@AG_CODEAGENCE,@PL_NUMCOMPTE,@PL_LIBELLE, " +
            //" @PL_COMPTECOLLECTIF,@PL_REPORTDEBIT,@PL_REPORTCREDIT,PL_MONTANTPERIODEPRECEDENTDEBIT,  " +
            //" @PL_MONTANTPERIODEPRECEDENTCREDIT,@PL_MONTANTPERIODEDEBITENCOURS,@PL_MONTANTPERIODECREDITENCOURS,  " +
            //" @PL_MONTANTSOLDEFINALDEBIT,@PL_MONTANTSOLDEFINALCREDIT,@PL_SENS,@PL_TYPECOMPTE,  " +
            //" @PL_COMPTERESULTATINSTANCE,@PL_EXCEDENTEXERCICE,@PL_DEFICITEXERCICE,  " +
            //" @PL_ACTIF,@PL_AUTORISEINVERSION,@PL_COMPTEREFERENTIELCOMPTABLE,@CODECRYPTAGE,@TYPEOPERATION ";

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamSO_CODESOCIETE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamPL_COMPTECOLLECTIF);
            vppSqlCmd.Parameters.Add(vppParamPL_REPORTDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_REPORTCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURS);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURS);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPL_SENS);
            vppSqlCmd.Parameters.Add(vppParamPL_TYPECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_ACTIF);
            vppSqlCmd.Parameters.Add(vppParamPL_COMPTEREFERENTIELCOMPTABLE);

            //Ouverture de la connection et exécution de la commande
            vppSqlCmd.ExecuteNonQuery();
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPlancomptable">clsPlancomptable</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPlancomptable clsPlancomptable, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamSO_CODESOCIETE = new SqlParameter("@SO_CODESOCIETE", SqlDbType.VarChar, 4);
            vppParamSO_CODESOCIETE.Value = clsPlancomptable.SO_CODESOCIETE;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_NUMCOMPTE.Value = clsPlancomptable.PL_NUMCOMPTE;

            SqlParameter vppParamPL_LIBELLE = new SqlParameter("@PL_LIBELLE", SqlDbType.VarChar, 150);
            vppParamPL_LIBELLE.Value = clsPlancomptable.PL_LIBELLE;

            SqlParameter vppParamPL_COMPTECOLLECTIF = new SqlParameter("@PL_COMPTECOLLECTIF", SqlDbType.VarChar, 25);
            vppParamPL_COMPTECOLLECTIF.Value = clsPlancomptable.PL_COMPTECOLLECTIF;

            SqlParameter vppParamPL_REPORTDEBIT = new SqlParameter("@PL_REPORTDEBIT", SqlDbType.Money);
            vppParamPL_REPORTDEBIT.Value = clsPlancomptable.PL_REPORTDEBIT;

            SqlParameter vppParamPL_REPORTCREDIT = new SqlParameter("@PL_REPORTCREDIT", SqlDbType.Money);
            vppParamPL_REPORTCREDIT.Value = clsPlancomptable.PL_REPORTCREDIT;

            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTDEBIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTDEBIT", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTDEBIT.Value = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT;

            SqlParameter vppParamPL_MONTANTPERIODEPRECEDENTCREDIT = new SqlParameter("@PL_MONTANTPERIODEPRECEDENTCREDIT", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEPRECEDENTCREDIT.Value = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT;

            SqlParameter vppParamPL_MONTANTPERIODEDEBITENCOURS = new SqlParameter("@PL_MONTANTPERIODEDEBITENCOURS", SqlDbType.Money);
            vppParamPL_MONTANTPERIODEDEBITENCOURS.Value = clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS;

            SqlParameter vppParamPL_MONTANTPERIODECREDITENCOURS = new SqlParameter("@PL_MONTANTPERIODECREDITENCOURS", SqlDbType.Money);
            vppParamPL_MONTANTPERIODECREDITENCOURS.Value = clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS;

            SqlParameter vppParamPL_MONTANTSOLDEFINALDEBIT = new SqlParameter("@PL_MONTANTSOLDEFINALDEBIT", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALDEBIT.Value = clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT;

            SqlParameter vppParamPL_MONTANTSOLDEFINALCREDIT = new SqlParameter("@PL_MONTANTSOLDEFINALCREDIT", SqlDbType.Money);
            vppParamPL_MONTANTSOLDEFINALCREDIT.Value = clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT;

            SqlParameter vppParamPL_SENS = new SqlParameter("@PL_SENS", SqlDbType.VarChar, 2);
            vppParamPL_SENS.Value = clsPlancomptable.PL_SENS;

            SqlParameter vppParamPL_TYPECOMPTE = new SqlParameter("@PL_TYPECOMPTE", SqlDbType.VarChar, 1);
            vppParamPL_TYPECOMPTE.Value = clsPlancomptable.PL_TYPECOMPTE;

            SqlParameter vppParamPL_ACTIF = new SqlParameter("@PL_ACTIF", SqlDbType.VarChar, 1);
            vppParamPL_ACTIF.Value = clsPlancomptable.PL_ACTIF;

            SqlParameter vppParamPL_COMPTEREFERENTIELCOMPTABLE = new SqlParameter("@PL_COMPTEREFERENTIELCOMPTABLE", SqlDbType.VarChar, 1);
            vppParamPL_COMPTEREFERENTIELCOMPTABLE.Value = clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE;

            pvpChoixCritere(vppCritere);

            //Préparation de la commande
            this.vapRequete = "UPDATE PLANCOMPTABLE SET " +
            " SO_CODESOCIETE = @SO_CODESOCIETE , " +
            " PL_NUMCOMPTE = @PL_NUMCOMPTE , " +
            " PL_LIBELLE = @PL_LIBELLE , " +
            " PL_COMPTECOLLECTIF = @PL_COMPTECOLLECTIF , " +
            " PL_REPORTDEBIT = @PL_REPORTDEBIT , " +
            " PL_REPORTCREDIT = @PL_REPORTCREDIT , " +
            " PL_MONTANTPERIODEPRECEDENTDEBIT = @PL_MONTANTPERIODEPRECEDENTDEBIT , " +
            " PL_MONTANTPERIODEPRECEDENTCREDIT = @PL_MONTANTPERIODEPRECEDENTCREDIT , " +
            " PL_MONTANTPERIODEDEBITENCOURS = @PL_MONTANTPERIODEDEBITENCOURS , " +
            " PL_MONTANTPERIODECREDITENCOURS = @PL_MONTANTPERIODECREDITENCOURS , " +
            " PL_MONTANTSOLDEFINALDEBIT = @PL_MONTANTSOLDEFINALDEBIT , " +
            " PL_MONTANTSOLDEFINALCREDIT = @PL_MONTANTSOLDEFINALCREDIT , " +
            " PL_SENS = @PL_SENS , " +
            " PL_TYPECOMPTE = @PL_TYPECOMPTE , " +
            " PL_ACTIF = @PL_ACTIF , " +
            " PL_COMPTEREFERENTIELCOMPTABLE = @PL_COMPTEREFERENTIELCOMPTABLE" + this.vapCritere;

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamSO_CODESOCIETE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamPL_COMPTECOLLECTIF);
            vppSqlCmd.Parameters.Add(vppParamPL_REPORTDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_REPORTCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEPRECEDENTCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODEDEBITENCOURS);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTPERIODECREDITENCOURS);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALDEBIT);
            vppSqlCmd.Parameters.Add(vppParamPL_MONTANTSOLDEFINALCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPL_SENS);
            vppSqlCmd.Parameters.Add(vppParamPL_TYPECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_ACTIF);
            vppSqlCmd.Parameters.Add(vppParamPL_COMPTEREFERENTIELCOMPTABLE);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPlancomptable">clsPlancomptable</param>
        ///<param name="vppCritere">Les critères de modification</param>
        ///<author>Home Technologie</author>
        public void pvgUpdatePlanComptable(clsDonnee clsDonnee, clsPlancomptable clsPlancomptable, params string[] vppCritere)
        {
            //Préparation des paramètres

            SqlParameter vppParamSO_CODESOCIETE = new SqlParameter("@SO_CODESOCIETE", SqlDbType.VarChar, 25);
            vppParamSO_CODESOCIETE.Value = clsPlancomptable.SO_CODESOCIETE;

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPlancomptable.AG_CODEAGENCE;

            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_CODENUMCOMPTE.Value = clsPlancomptable.PL_CODENUMCOMPTE;

            SqlParameter vppParamPL_LIBELLE = new SqlParameter("@PL_LIBELLE", SqlDbType.VarChar, 150);
            vppParamPL_LIBELLE.Value = clsPlancomptable.PL_LIBELLE;


            SqlParameter vppParamPL_AUTORISEINVERSION = new SqlParameter("@PL_AUTORISEINVERSION", SqlDbType.VarChar, 1);
            vppParamPL_AUTORISEINVERSION.Value = clsPlancomptable.PL_AUTORISEINVERSION;

            SqlParameter vppParamPL_SAISIE_ANALYTIQUE = new SqlParameter("@PL_SAISIE_ANALYTIQUE", SqlDbType.VarChar, 1);
            vppParamPL_SAISIE_ANALYTIQUE.Value = clsPlancomptable.PL_SAISIE_ANALYTIQUE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;
            //
            this.vapRequete = "EXEC [dbo].[PC_PLANCOMPTABLE] @PL_CODENUMCOMPTE,@SO_CODESOCIETE,@AG_CODEAGENCE,'',@PL_LIBELLE, " +
            " '',0,0,0,0,0,0,0,0,'','','','','','',@PL_AUTORISEINVERSION,@PL_SAISIE_ANALYTIQUE,'',@CODECRYPTAGE,3";

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamSO_CODESOCIETE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);

            vppSqlCmd.Parameters.Add(vppParamPL_LIBELLE);
            vppSqlCmd.Parameters.Add(vppParamPL_AUTORISEINVERSION);
            vppSqlCmd.Parameters.Add(vppParamPL_SAISIE_ANALYTIQUE);

            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);

            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPlancomptable">clsPlancomptable</param>
        ///<param name="vppCritere">Les critères de modification</param>
        ///<author>Home Technologie</author>
        public void pvgUpdatePlanComptableDesactiverCompte(clsDonnee clsDonnee, clsPlancomptable clsPlancomptable, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamSO_CODESOCIETE = new SqlParameter("@SO_CODESOCIETE", SqlDbType.VarChar, 25);
            vppParamSO_CODESOCIETE.Value = clsPlancomptable.SO_CODESOCIETE;

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsPlancomptable.AG_CODEAGENCE;

            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_CODENUMCOMPTE.Value = clsPlancomptable.PL_CODENUMCOMPTE;

            SqlParameter vppParamPL_ACTIF = new SqlParameter("@PL_ACTIF", SqlDbType.VarChar, 1);
            vppParamPL_ACTIF.Value = clsPlancomptable.PL_ACTIF;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;
            //
            this.vapRequete = "EXEC [dbo].[PC_PLANCOMPTABLE] @PL_CODENUMCOMPTE,@SO_CODESOCIETE,@AG_CODEAGENCE,'','', " +
            " '',0,0,0,0,0,0,0,0,'','','','','',@PL_ACTIF,'','','',@CODECRYPTAGE,4";

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamSO_CODESOCIETE);
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);

            vppSqlCmd.Parameters.Add(vppParamPL_ACTIF);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);

            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "DELETE FROM PLANCOMPTABLE " + this.vapCritere;
            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsPlancomptable </returns>
		///<author>Home Technologie</author>
		public List<clsPlancomptable> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsPlancomptable> clsPlancomptables = new List<clsPlancomptable>();

            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM PLANCOMPTABLE " + this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            this.vapCritere = "";
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsPlancomptable clsPlancomptable = new clsPlancomptable();
                    clsPlancomptable.SO_CODESOCIETE = clsDonnee.vogDataReader["SO_CODESOCIETE"].ToString();
                    clsPlancomptable.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsPlancomptable.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
                    clsPlancomptable.PL_LIBELLE = clsDonnee.vogDataReader["PL_LIBELLE"].ToString();
                    clsPlancomptable.PL_COMPTECOLLECTIF = clsDonnee.vogDataReader["PL_COMPTECOLLECTIF"].ToString();
                    clsPlancomptable.PL_REPORTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTDEBIT"].ToString());
                    clsPlancomptable.PL_REPORTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_REPORTCREDIT"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS = double.Parse(clsDonnee.vogDataReader["PL_MONTANTPERIODECREDITENCOURS"].ToString());
                    clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALDEBIT"].ToString());
                    clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT = double.Parse(clsDonnee.vogDataReader["PL_MONTANTSOLDEFINALCREDIT"].ToString());
                    clsPlancomptable.PL_SENS = clsDonnee.vogDataReader["PL_SENS"].ToString();
                    clsPlancomptable.PL_TYPECOMPTE = clsDonnee.vogDataReader["PL_TYPECOMPTE"].ToString();
                    clsPlancomptable.PL_ACTIF = clsDonnee.vogDataReader["PL_ACTIF"].ToString();
                    clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE = clsDonnee.vogDataReader["PL_COMPTEREFERENTIELCOMPTABLE"].ToString();
                    clsPlancomptables.Add(clsPlancomptable);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsPlancomptables;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsPlancomptable </returns>
		///<author>Home Technologie</author>
		public List<clsPlancomptable> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsPlancomptable> clsPlancomptables = new List<clsPlancomptable>();
            DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM PLANCOMPTABLE " + this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsPlancomptable clsPlancomptable = new clsPlancomptable();
                    clsPlancomptable.SO_CODESOCIETE = Dataset.Tables["TABLE"].Rows[Idx]["SO_CODESOCIETE"].ToString();
                    clsPlancomptable.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
                    clsPlancomptable.PL_NUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_NUMCOMPTE"].ToString();
                    clsPlancomptable.PL_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["PL_LIBELLE"].ToString();
                    clsPlancomptable.PL_COMPTECOLLECTIF = Dataset.Tables["TABLE"].Rows[Idx]["PL_COMPTECOLLECTIF"].ToString();
                    clsPlancomptable.PL_REPORTDEBIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_REPORTDEBIT"].ToString());
                    clsPlancomptable.PL_REPORTCREDIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_REPORTCREDIT"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEPRECEDENTDEBIT"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEPRECEDENTCREDIT"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODEDEBITENCOURS"].ToString());
                    clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTPERIODECREDITENCOURS"].ToString());
                    clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTSOLDEFINALDEBIT"].ToString());
                    clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PL_MONTANTSOLDEFINALCREDIT"].ToString());
                    clsPlancomptable.PL_SENS = Dataset.Tables["TABLE"].Rows[Idx]["PL_SENS"].ToString();
                    clsPlancomptable.PL_TYPECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_TYPECOMPTE"].ToString();
                    clsPlancomptable.PL_ACTIF = Dataset.Tables["TABLE"].Rows[Idx]["PL_ACTIF"].ToString();
                    clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE = Dataset.Tables["TABLE"].Rows[Idx]["PL_COMPTEREFERENTIELCOMPTABLE"].ToString();
                    clsPlancomptables.Add(clsPlancomptable);
                }
                Dataset.Dispose();
            }
            return clsPlancomptables;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT * FROM PLANCOMPTABLE " + this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT PL_CODENUMCOMPTE,PL_NUMCOMPTE,PL_LIBELLE FROM PLANCOMPTABLE " + this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgValueScalarRequeteMaxConfigurationConditionCpteEpargneProjet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MAX(PL_CODENUMCOMPTE) AS PL_CODENUMCOMPTE  FROM PLANCOMPTABLE " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetListeComptePlanComptable(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_TYPECOMPTE", "@TYPEECRAN" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };

            this.vapRequete = "EXEC [dbo].[PS_LISTECOMPTEPLANCOMPTABLE] @SO_CODESOCIETE,@PL_TYPECOMPTE,@TYPEECRAN ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetListeComptePlanComptableCompteAmodiffier(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_TYPECOMPTE", "@PL_CODENUMCOMPTE", "@TYPEECRAN" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };

            this.vapRequete = "EXEC [dbo].[PS_LISTECOMPTEPLANCOMPTABLE1] @SO_CODESOCIETE,@PL_TYPECOMPTE,@PL_CODENUMCOMPTE,@TYPEECRAN ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans criteres (Ordre Criteres : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les criteres de la requete SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetCompteAutoriseEnODAvecProduit(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PS_CODESOUSPRODUIT", "@PL_TYPECOMPTE" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
            this.vapRequete = "EXEC  [dbo].[PS_MICCOMPTEPRODUITSOUSPRODUITCOMPTEAUTORISEENODLISTE] @SO_CODESOCIETE,@PS_CODESOUSPRODUIT,@PL_TYPECOMPTE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetComptesIndividuels(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere3(vppCritere);
            this.vapRequete = "SELECT PL_CODENUMCOMPTE, PL_NUMCOMPTE, PL_LIBELLE FROM VUE_PLANCOMPTABLE " + this.vapCritere + " AND PL_ACTIF='O' AND PL_TYPECOMPTE = 'I' ORDER BY PL_NUMCOMPTE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

        public DataSet pvgChargerDansDataSetOperation(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere1(vppCritere);

            //this.vapCritere = " WHERE @FO_CODEFAMILLEOPERATION=@SO_CODESOCIETE ";
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@OP_CODEOPERATEUR", "@FO_CODEFAMILLEOPERATION" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };

            this.vapRequete = "EXEC [dbo].[PS_FAMILLEOPERATIONCOMPTEPLANCOMPTABLE]  @AG_CODEAGENCE,@OP_CODEOPERATEUR,@FO_CODEFAMILLEOPERATION";// +this.vapCritere + " AND PL_ACTIF='O' ORDER BY PL_NUMCOMPTE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }





        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere3(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {

                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    //this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND PL_TYPECOMPTE='I' ";
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%'";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;

                case 4:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE  +@PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND NC_CODENATURECOMPTE LIKE '%' +@NC_CODENATURECOMPTE+'%'  ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@NC_CODENATURECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;

            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
		public void pvpChoixCritere(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE=@PL_NUMCOMPTE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE=@PL_NUMCOMPTE AND PL_TYPECOMPTE=@PL_TYPECOMPTE  ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE=@PL_NUMCOMPTE AND PL_TYPECOMPTE=@PL_TYPECOMPTE AND PL_ACTIF=@PL_ACTIF ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE", "@PL_ACTIF" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;
            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere1(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {

                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%'";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE LIKE @PL_NUMCOMPTE+'%' AND PL_TYPECOMPTE=@PL_TYPECOMPTE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE", "@PL_TYPECOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere2(params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { };
                    vapValeurParametre = new object[] { };
                    break;
                case 1:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_CODENUMCOMPTE=@PL_CODENUMCOMPTE";
                    vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_CODENUMCOMPTE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
            }
        }

        /////<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : SO_CODESOCIETE,PL_CODENUMCOMPTE)</summary>
        /////<param name="vppCritere">Les critères de la requète</param>
        /////<author>Home Technologie</author>
        //public void pvpChoixCritereAvecSolde(params string[] vppCritere)
        //{
        //    switch (vppCritere.Length)
        //    {
        //        case 0:
        //            this.vapCritere = "";
        //            vapNomParametre = new string[] { };
        //            vapValeurParametre = new object[] { };
        //            break;
        //        case 1:
        //            this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE ";
        //            vapNomParametre = new string[] { "@SO_CODESOCIETE" };
        //            vapValeurParametre = new object[] { vppCritere[0] };
        //            break;
        //        case 2:
        //        case 3:
        //        case 4:
        //            this.vapCritere = " WHERE SO_CODESOCIETE=@SO_CODESOCIETE AND  PL_NUMCOMPTE=@PL_NUMCOMPTE ";
        //            vapNomParametre = new string[] { "@SO_CODESOCIETE", "@PL_NUMCOMPTE" };
        //            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
        //            break;
        //    }
        //}


    }
}
