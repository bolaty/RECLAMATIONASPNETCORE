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
    public class clsJourneetravailWSDAL : ITableDAL<clsJourneetravail>
    {

        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT COUNT(JT_DATEJOURNEETRAVAIL) AS JT_DATEJOURNEETRAVAIL  FROM JOURNEETRAVAIL " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgValueScalarRequeteCount1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(vppCritere);
            this.vapRequete = "SELECT COUNT(JT_DATEJOURNEETRAVAIL) AS JT_DATEJOURNEETRAVAIL  FROM JOURNEETRAVAIL " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MIN(JT_DATEJOURNEETRAVAIL) AS JT_DATEJOURNEETRAVAIL  FROM JOURNEETRAVAIL " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MAX(JT_DATEJOURNEETRAVAIL) AS JT_DATEJOURNEETRAVAIL  FROM JOURNEETRAVAIL " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgValueScalarRequeteMax1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere3(vppCritere);
            this.vapRequete = "SELECT MAX(JT_DATEJOURNEETRAVAIL) AS JT_DATEJOURNEETRAVAIL  FROM JOURNEETRAVAIL " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsJourneetravail">clsJourneetravail</param>
		///<author>Home Technologie</author>
		public clsJourneetravail pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE,OP_CODEOPERATEUR,JT_STATUT FROM JOURNEETRAVAIL " + this.vapCritere;
            this.vapCritere = "";

            clsJourneetravail clsJourneetravail = new clsJourneetravail();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsJourneetravail.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsJourneetravail.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                    clsJourneetravail.JT_STATUT = clsDonnee.vogDataReader["JT_STATUT"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsJourneetravail;
        }

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsJourneetravail">clsJourneetravail</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee, clsJourneetravail clsJourneetravail)
        {
            //Préparation des paramètres

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsJourneetravail.AG_CODEAGENCE;

            SqlParameter vppParamJT_DATEJOURNEETRAVAIL = new SqlParameter("@JT_DATEJOURNEETRAVAIL", SqlDbType.DateTime);
            vppParamJT_DATEJOURNEETRAVAIL.Value = clsJourneetravail.JT_DATEJOURNEETRAVAIL;

            SqlParameter vppParamJT_STATUT = new SqlParameter("@JT_STATUT", SqlDbType.VarChar, 1);
            vppParamJT_STATUT.Value = clsJourneetravail.JT_STATUT;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsJourneetravail.OP_CODEOPERATEUR;

            //Préparation de la commande
            this.vapRequete = "INSERT INTO JOURNEETRAVAIL " +
            " (AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT,OP_CODEOPERATEUR)" +
            " VALUES(@AG_CODEAGENCE,@JT_DATEJOURNEETRAVAIL,@JT_STATUT,@OP_CODEOPERATEUR)";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamJT_DATEJOURNEETRAVAIL);
            vppSqlCmd.Parameters.Add(vppParamJT_STATUT);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);

            //Ouverture de la connection et exécution de la commande
            vppSqlCmd.ExecuteNonQuery();
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsJourneetravail">clsJourneetravail</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsJourneetravail clsJourneetravail, params string[] vppCritere)
        {
            ////Préparation des paramètres

            //SqlParameter vppParamJT_STATUT = new SqlParameter("@JT_STATUT", SqlDbType.VarChar, 1);
            //vppParamJT_STATUT.Value = clsJourneetravail.JT_STATUT;

            // pvpChoixCritere(vppCritere); 

            ////Préparation de la commande
            //this.vapRequete = "UPDATE JOURNEETRAVAIL SET " + 
            //" JT_STATUT = @JT_STATUT " + this.vapCritere ;

            //this.vapCritere = "";

            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal); 

            ////Ajout des paramètre à la commande
            //vppSqlCmd.Parameters.Add(vppParamJT_STATUT);
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);


            //Préparation de la commande
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@PV_CODEPOINTVENTE", "@DATEJOURNEE", "@JT_STATUT" };
            vapValeurParametre = new object[] { clsJourneetravail.AG_CODEAGENCE, clsJourneetravail.PV_CODEPOINTVENTE, clsJourneetravail.JT_DATEJOURNEETRAVAIL, clsJourneetravail.JT_STATUT };
            this.vapRequete = " EXECUTE [dbo].[PB_BILANCLOTUREJOURNEETRAVAIL] @AG_CODEAGENCE,@PV_CODEPOINTVENTE,@DATEJOURNEE,@JT_STATUT";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "DELETE FROM JOURNEETRAVAIL " + this.vapCritere;
            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="vppCritere">Les critères de suppression</param>
        ///<author>Home Technologie</author>
        public void pvgDelete1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere3(vppCritere);
            this.vapRequete = "DELETE FROM JOURNEETRAVAIL " + this.vapCritere;
            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsJourneetravail </returns>
		///<author>Home Technologie</author>
		public List<clsJourneetravail> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsJourneetravail> clsJourneetravails = new List<clsJourneetravail>();

            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM JOURNEETRAVAIL " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            this.vapCritere = "";
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsJourneetravail clsJourneetravail = new clsJourneetravail();
                    clsJourneetravail.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsJourneetravail.JT_DATEJOURNEETRAVAIL = DateTime.Parse(clsDonnee.vogDataReader["JT_DATEJOURNEETRAVAIL"].ToString());
                    clsJourneetravail.JT_STATUT = clsDonnee.vogDataReader["JT_STATUT"].ToString();
                    clsJourneetravail.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                    clsJourneetravails.Add(clsJourneetravail);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsJourneetravails;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsJourneetravail </returns>
		///<author>Home Technologie</author>
		public List<clsJourneetravail> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsJourneetravail> clsJourneetravails = new List<clsJourneetravail>();
            DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM JOURNEETRAVAIL " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsJourneetravail clsJourneetravail = new clsJourneetravail();
                    clsJourneetravail.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsJourneetravail.JT_DATEJOURNEETRAVAIL = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["JT_DATEJOURNEETRAVAIL"].ToString());
                    clsJourneetravail.JT_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["JT_STATUT"].ToString();
                    clsJourneetravail.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
                    clsJourneetravails.Add(clsJourneetravail);
                }
                Dataset.Dispose();
            }
            return clsJourneetravails;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere3(vppCritere);
            this.vapRequete = "SELECT  TOP 10 * FROM VUE_JOURNEETRAVAIL " + this.vapCritere + "   ORDER BY JT_DATEJOURNEETRAVAIL DESC";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere2(vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT,OP_CODEOPERATEUR FROM VUE_JOURNEETRAVAIL " + this.vapCritere + " ORDER BY JT_DATEJOURNEETRAVAIL DESC";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
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
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  JT_DATEJOURNEETRAVAIL=@JT_DATEJOURNEETRAVAIL ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@JT_DATEJOURNEETRAVAIL" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  JT_DATEJOURNEETRAVAIL=@JT_DATEJOURNEETRAVAIL AND  JT_STATUT=@JT_STATUT ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@JT_DATEJOURNEETRAVAIL", "@JT_STATUT" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
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
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  JT_STATUT=@JT_STATUT ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@JT_STATUT" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
            }
        }

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
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  JT_STATUT=@JT_STATUT ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@JT_STATUT" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
            }
        }

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
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  YEAR(JT_DATEJOURNEETRAVAIL)=@JT_DATEJOURNEETRAVAIL ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@JT_DATEJOURNEETRAVAIL" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;

                case 3:
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  YEAR(JT_DATEJOURNEETRAVAIL)=@JT_DATEJOURNEETRAVAIL AND JT_STATUT LIKE'%'+@JT_STATUT+'%' ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@JT_DATEJOURNEETRAVAIL", "@JT_STATUT" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }

    }
}
