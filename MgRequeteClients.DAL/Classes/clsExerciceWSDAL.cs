using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.BOJ.BusinessObjects;
using MgRequeteClients.DAL.Interfaces;
using MgRequeteClients.Tools.Classes;

namespace MgRequeteClients.DAL.Classes
{
    public class clsExerciceWSDAL : ITableDAL<clsExercice>
    {

        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE,EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT COUNT(EX_EXERCICE) AS EX_EXERCICE  FROM EXERCICE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : AG_CODEAGENCE,EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MIN(EX_DATEDEBUT) AS EX_DATEDEBUT  FROM EXERCICE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE,EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MAX(EX_EXERCICE) AS EX_EXERCICE  FROM EXERCICE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : AG_CODEAGENCE,EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsExercice">clsExercice</param>
		///<author>Home Technologie</author>
		public clsExercice pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT JT_DATEJOURNEETRAVAIL,EX_DATEDEBUT,EX_DATEFIN,EX_DESCEXERCICE,EX_ETATEXERCICE,EX_DATESAISIE,EX_DATEDEBUTBILAN,EX_DATEFINBILAN,EX_DATEAFFECTATIONRESULTAT,EX_DOUBLEEXERCICE FROM EXERCICE " + this.vapCritere;
            vapCritere = "";

            clsExercice clsExercice = new clsExercice();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsExercice.JT_DATEJOURNEETRAVAIL = DateTime.Parse(clsDonnee.vogDataReader["JT_DATEJOURNEETRAVAIL"].ToString());
                    clsExercice.EX_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["EX_DATEDEBUT"].ToString());
                    clsExercice.EX_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["EX_DATEFIN"].ToString());
                    clsExercice.EX_DESCEXERCICE = clsDonnee.vogDataReader["EX_DESCEXERCICE"].ToString();
                    clsExercice.EX_ETATEXERCICE = clsDonnee.vogDataReader["EX_ETATEXERCICE"].ToString();
                    clsExercice.EX_DOUBLEEXERCICE = clsDonnee.vogDataReader["EX_DOUBLEEXERCICE"].ToString();
                    clsExercice.EX_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["EX_DATESAISIE"].ToString());
                    clsExercice.EX_DATEDEBUTBILAN = DateTime.Parse(clsDonnee.vogDataReader["EX_DATEDEBUTBILAN"].ToString());
                    clsExercice.EX_DATEFINBILAN = DateTime.Parse(clsDonnee.vogDataReader["EX_DATEFINBILAN"].ToString());
                    clsExercice.EX_DATEAFFECTATIONRESULTAT = DateTime.Parse(clsDonnee.vogDataReader["EX_DATEAFFECTATIONRESULTAT"].ToString());
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsExercice;
        }

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsExercice">clsExercice</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee, clsExercice clsExercice)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsExercice.AG_CODEAGENCE;

            SqlParameter vppParamEX_EXERCICE = new SqlParameter("@EX_EXERCICE", SqlDbType.VarChar, 4);
            vppParamEX_EXERCICE.Value = clsExercice.EX_EXERCICE;

            SqlParameter vppParamJT_DATEJOURNEETRAVAIL = new SqlParameter("@JT_DATEJOURNEETRAVAIL", SqlDbType.DateTime);
            vppParamJT_DATEJOURNEETRAVAIL.Value = clsExercice.JT_DATEJOURNEETRAVAIL;

            SqlParameter vppParamEX_DATEDEBUT = new SqlParameter("@EX_DATEDEBUT", SqlDbType.DateTime);
            vppParamEX_DATEDEBUT.Value = clsExercice.EX_DATEDEBUT;

            SqlParameter vppParamEX_DATEFIN = new SqlParameter("@EX_DATEFIN", SqlDbType.DateTime);
            vppParamEX_DATEFIN.Value = clsExercice.EX_DATEFIN;

            SqlParameter vppParamEX_DESCEXERCICE = new SqlParameter("@EX_DESCEXERCICE", SqlDbType.VarChar, 50);
            vppParamEX_DESCEXERCICE.Value = clsExercice.EX_DESCEXERCICE;

            SqlParameter vppParamEX_ETATEXERCICE = new SqlParameter("@EX_ETATEXERCICE", SqlDbType.VarChar, 1);
            vppParamEX_ETATEXERCICE.Value = clsExercice.EX_ETATEXERCICE;

            SqlParameter vppParamEX_DATESAISIE = new SqlParameter("@EX_DATESAISIE", SqlDbType.DateTime);
            vppParamEX_DATESAISIE.Value = clsExercice.EX_DATESAISIE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PC_EXERCICE  @AG_CODEAGENCE, @EX_EXERCICE, @JT_DATEJOURNEETRAVAIL, @EX_DATEDEBUT, @EX_DATEFIN,@EX_DESCEXERCICE,'01/01/1900','01/01/1900',@EX_ETATEXERCICE,@EX_DATESAISIE,@CODECRYPTAGE, 0 ";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEX_EXERCICE);
            vppSqlCmd.Parameters.Add(vppParamJT_DATEJOURNEETRAVAIL);
            vppSqlCmd.Parameters.Add(vppParamEX_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamEX_DATEFIN);
            vppSqlCmd.Parameters.Add(vppParamEX_DESCEXERCICE);
            vppSqlCmd.Parameters.Add(vppParamEX_ETATEXERCICE);
            vppSqlCmd.Parameters.Add(vppParamEX_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            //Ouverture de la connection et exécution de la commande
            vppSqlCmd.ExecuteNonQuery();
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsExercice">clsExercice</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsExercice clsExercice, params string[] vppCritere)
        {
            //Préparation des paramètre

            //SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            //vppParamAG_CODEAGENCE.Value = clsExercice.AG_CODEAGENCE;

            //SqlParameter vppParamEX_EXERCICE = new SqlParameter("@EX_EXERCICE", SqlDbType.VarChar, 4);
            //vppParamEX_EXERCICE.Value = clsExercice.EX_EXERCICE;

            SqlParameter vppParamJT_DATEJOURNEETRAVAIL = new SqlParameter("@JT_DATEJOURNEETRAVAIL", SqlDbType.DateTime);
            vppParamJT_DATEJOURNEETRAVAIL.Value = clsExercice.JT_DATEJOURNEETRAVAIL;

            SqlParameter vppParamEX_DATEDEBUT = new SqlParameter("@EX_DATEDEBUT", SqlDbType.DateTime);
            vppParamEX_DATEDEBUT.Value = clsExercice.EX_DATEDEBUT;

            SqlParameter vppParamEX_DATEFIN = new SqlParameter("@EX_DATEFIN", SqlDbType.DateTime);
            vppParamEX_DATEFIN.Value = clsExercice.EX_DATEFIN;

            pvpChoixCritere(vppCritere);

            //Préparation de la commande
            this.vapRequete = "UPDATE EXERCICE SET  " +
            " JT_DATEJOURNEETRAVAIL = @JT_DATEJOURNEETRAVAIL , " +
            " EX_DATEDEBUT = @EX_DATEDEBUT , " +
            " EX_DATEFIN = @EX_DATEFIN  " + this.vapCritere;

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            //vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            //vppSqlCmd.Parameters.Add(vppParamEX_EXERCICE);
            vppSqlCmd.Parameters.Add(vppParamJT_DATEJOURNEETRAVAIL);
            vppSqlCmd.Parameters.Add(vppParamEX_DATEDEBUT);
            vppSqlCmd.Parameters.Add(vppParamEX_DATEFIN);

            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:EX_EXERCICE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsExercice">clsExercice</param>
        ///<param name="vppCritere">Les critères de modification</param>
        ///<author>Home Technologie</author>
        public void pvgUpdateDemmarrageBilan(clsDonnee clsDonnee, clsExercice clsExercice, params string[] vppCritere)
        {
            //Préparation des paramètres
            SqlParameter vppParamEX_DATEDEBUTBILAN = new SqlParameter("@EX_DATEDEBUTBILAN", SqlDbType.DateTime);
            vppParamEX_DATEDEBUTBILAN.Value = clsExercice.EX_DATEDEBUTBILAN;

            pvpChoixCritere(vppCritere);

            //Préparation de la commande
            this.vapRequete = "UPDATE EXERCICE SET " +
            " EX_DATEDEBUTBILAN = @EX_DATEDEBUTBILAN  " + this.vapCritere;

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamEX_DATEDEBUTBILAN);

            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "DELETE FROM EXERCICE " + this.vapCritere;
            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE,EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsExercice </returns>
		///<author>Home Technologie</author>
		public List<clsExercice> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsExercice> clsExercices = new List<clsExercice>();

            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM EXERCICE " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            this.vapCritere = "";
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsExercice clsExercice = new clsExercice();
                    clsExercice.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsExercice.EX_EXERCICE = clsDonnee.vogDataReader["EX_EXERCICE"].ToString();
                    clsExercice.JT_DATEJOURNEETRAVAIL = DateTime.Parse(clsDonnee.vogDataReader["JT_DATEJOURNEETRAVAIL"].ToString());
                    clsExercice.EX_DATEDEBUT = DateTime.Parse(clsDonnee.vogDataReader["EX_DATEDEBUT"].ToString());
                    clsExercice.EX_DATEFIN = DateTime.Parse(clsDonnee.vogDataReader["EX_DATEFIN"].ToString());
                    clsExercice.EX_DESCEXERCICE = clsDonnee.vogDataReader["EX_DESCEXERCICE"].ToString();
                    clsExercice.EX_ETATEXERCICE = clsDonnee.vogDataReader["EX_ETATEXERCICE"].ToString();
                    clsExercice.EX_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["EX_DATESAISIE"].ToString());
                    clsExercice.EX_DATEDEBUTBILAN = DateTime.Parse(clsDonnee.vogDataReader["EX_DATEDEBUTBILAN"].ToString());
                    clsExercice.EX_DATEFINBILAN = DateTime.Parse(clsDonnee.vogDataReader["EX_DATEFINBILAN"].ToString());
                    clsExercice.EX_DATEAFFECTATIONRESULTAT = DateTime.Parse(clsDonnee.vogDataReader["EX_DATEAFFECTATIONRESULTAT"].ToString());
                    clsExercices.Add(clsExercice);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsExercices;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE,EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsExercice </returns>
		///<author>Home Technologie</author>
		public List<clsExercice> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsExercice> clsExercices = new List<clsExercice>();
            DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM EXERCICE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsExercice clsExercice = new clsExercice();
                    clsExercice.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsExercice.EX_EXERCICE = Dataset.Tables["TABLE"].Rows[Idx]["EX_EXERCICE"].ToString();
                    clsExercice.JT_DATEJOURNEETRAVAIL = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["JT_DATEJOURNEETRAVAIL"].ToString());
                    clsExercice.EX_DATEDEBUT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EX_DATEDEBUT"].ToString());
                    clsExercice.EX_DATEFIN = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EX_DATEFIN"].ToString());
                    clsExercice.EX_DESCEXERCICE = Dataset.Tables["TABLE"].Rows[Idx]["EX_DESCEXERCICE"].ToString();
                    clsExercice.EX_ETATEXERCICE = Dataset.Tables["TABLE"].Rows[Idx]["EX_ETATEXERCICE"].ToString();
                    clsExercice.EX_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EX_DATESAISIE"].ToString());
                    clsExercice.EX_DATEDEBUTBILAN = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EX_DATEDEBUTBILAN"].ToString());
                    clsExercice.EX_DATEFINBILAN = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EX_DATEFINBILAN"].ToString());
                    clsExercice.EX_DATEAFFECTATIONRESULTAT = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["EX_DATEAFFECTATIONRESULTAT"].ToString());
                    clsExercices.Add(clsExercice);
                }
                Dataset.Dispose();
            }
            return clsExercices;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : AG_CODEAGENCE,EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT * FROM EXERCICE " + this.vapCritere + " ORDER BY EX_EXERCICE DESC";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : AG_CODEAGENCE,EX_EXERCICE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT EX_EXERCICE,EX_DATEDEBUT FROM EXERCICE " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : AG_CODEAGENCE,EX_EXERCICE)</summary>
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
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  EX_EXERCICE=@EX_EXERCICE ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@EX_EXERCICE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
            }
        }
    }
}
