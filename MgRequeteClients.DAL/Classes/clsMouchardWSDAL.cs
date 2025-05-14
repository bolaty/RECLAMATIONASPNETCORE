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
    public class clsMouchardWSDAL : ITableDAL<clsMouchard>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE,MO_SEQUENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT COUNT(MO_SEQUENCE) AS MO_SEQUENCE  FROM MOUCHARD " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : AG_CODEAGENCE,MO_SEQUENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MIN(MO_SEQUENCE) AS MO_SEQUENCE  FROM MOUCHARD " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE,MO_SEQUENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MAX(MO_SEQUENCE) AS MO_SEQUENCE  FROM MOUCHARD " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : AG_CODEAGENCE,MO_SEQUENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsMouchard">clsMouchard</param>
		///<author>Home Technologie</author>
		public clsMouchard pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT OP_CODEOPERATEUR,MO_DATEACTION,MO_HEUREACTION,MO_ACTION FROM MOUCHARD " + this.vapCritere;
            this.vapCritere = "";

            clsMouchard clsMouchard = new clsMouchard();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMouchard.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                    clsMouchard.MO_DATEACTION = DateTime.Parse(clsDonnee.vogDataReader["MO_DATEACTION"].ToString());
                    clsMouchard.MO_HEUREACTION = DateTime.Parse(clsDonnee.vogDataReader["MO_HEUREACTION"].ToString());
                    clsMouchard.MO_ACTION = clsDonnee.vogDataReader["MO_ACTION"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMouchard;
        }

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMouchard">clsMouchard</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee, clsMouchard clsMouchard)
        {
            //Préparation des paramètres

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsMouchard.AG_CODEAGENCE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsMouchard.OP_CODEOPERATEUR;
            if (clsMouchard.OP_CODEOPERATEUR == "") vppParamOP_CODEOPERATEUR.Value = DBNull.Value;

            SqlParameter vppParamMO_DATEACTION = new SqlParameter("@MO_DATEACTION", SqlDbType.DateTime);
            vppParamMO_DATEACTION.Value = DateTime.Today;
            //vppParamMO_DATEACTION.Value = clsMouchard.JT_DATEJOURNEETRAVAIL;

            //
            if (clsMouchard.MO_PREMIEREEXECUTION)
            {
                vppParamAG_CODEAGENCE.Value = "1000";
                vppParamOP_CODEOPERATEUR.Value = "ADMIN0000001";
            }
            //
            SqlParameter vppParamMO_HEUREACTION = new SqlParameter("@MO_HEUREACTION", SqlDbType.DateTime);
            vppParamMO_HEUREACTION.Value = DateTime.Parse(DateTime.Now.TimeOfDay.ToString());
            //TimeSpan heureActuelle = DateTime.Now.TimeOfDay;
            //DateTime dateAvecHeureActuelle = new DateTime(clsMouchard.JT_DATEJOURNEETRAVAIL.Year, clsMouchard.JT_DATEJOURNEETRAVAIL.Month, clsMouchard.JT_DATEJOURNEETRAVAIL.Day, heureActuelle.Hours, heureActuelle.Minutes, heureActuelle.Seconds);
            //vppParamMO_HEUREACTION.Value = dateAvecHeureActuelle;

            SqlParameter vppParamMO_ACTION = new SqlParameter("@MO_ACTION", SqlDbType.VarChar, 500);
            vppParamMO_ACTION.Value = clsMouchard.MO_ACTION;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

            SqlParameter vppParamMO_TERMINALIDENTIFIANT = new SqlParameter("@MO_TERMINALIDENTIFIANT", SqlDbType.VarChar, 500);
            vppParamMO_TERMINALIDENTIFIANT.Value = clsMouchard.MO_TERMINALIDENTIFIANT;

            SqlParameter vppParamMO_TERMINALDESCRIPTION = new SqlParameter("@MO_TERMINALDESCRIPTION", SqlDbType.VarChar, 500);
            vppParamMO_TERMINALDESCRIPTION.Value = clsMouchard.MO_TERMINALDESCRIPTION;

            SqlParameter vppParamSL_CODECOMPTEWEB = new SqlParameter("@SL_CODECOMPTEWEB", SqlDbType.VarChar, 500);
            vppParamSL_CODECOMPTEWEB.Value = clsMouchard.SL_CODECOMPTEWEB;
            if (clsMouchard.SL_CODECOMPTEWEB == "") vppParamSL_CODECOMPTEWEB.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEURAPPLICATIONMOBILE = new SqlParameter("@OP_CODEOPERATEURAPPLICATIONMOBILE", SqlDbType.VarChar, 500);
            vppParamOP_CODEOPERATEURAPPLICATIONMOBILE.Value = clsMouchard.OP_CODEOPERATEURAPPLICATIONMOBILE;
            if (clsMouchard.OP_CODEOPERATEURAPPLICATIONMOBILE == "") vppParamOP_CODEOPERATEURAPPLICATIONMOBILE.Value = DBNull.Value;

            //Préparation de la commande
            this.vapRequete = "EXECUTE PS_AJOUTMOUCHARD @AG_CODEAGENCE,@OP_CODEOPERATEUR,@MO_DATEACTION,@MO_HEUREACTION,@MO_ACTION,@CODECRYPTAGE,@MO_TERMINALIDENTIFIANT,@MO_TERMINALDESCRIPTION,@SL_CODECOMPTEWEB,@OP_CODEOPERATEURAPPLICATIONMOBILE";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandTimeout = 0;

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamMO_DATEACTION);
            vppSqlCmd.Parameters.Add(vppParamMO_HEUREACTION);
            vppSqlCmd.Parameters.Add(vppParamMO_ACTION);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamMO_TERMINALIDENTIFIANT);
            vppSqlCmd.Parameters.Add(vppParamMO_TERMINALDESCRIPTION);
            vppSqlCmd.Parameters.Add(vppParamSL_CODECOMPTEWEB);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEURAPPLICATIONMOBILE);
            //Ouverture de la connection et exécution de la commande
            vppSqlCmd.ExecuteNonQuery();
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:MO_SEQUENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMouchard">clsMouchard</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsMouchard clsMouchard, params string[] vppCritere)
        {
            //Préparation des paramètres

            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsMouchard.AG_CODEAGENCE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 25);
            vppParamOP_CODEOPERATEUR.Value = clsMouchard.OP_CODEOPERATEUR;

            SqlParameter vppParamMO_DATEACTION = new SqlParameter("@MO_DATEACTION", SqlDbType.DateTime);
            vppParamMO_DATEACTION.Value = clsMouchard.MO_DATEACTION;

            SqlParameter vppParamMO_HEUREACTION = new SqlParameter("@MO_HEUREACTION", SqlDbType.DateTime);
            vppParamMO_HEUREACTION.Value = clsMouchard.MO_HEUREACTION;

            SqlParameter vppParamMO_ACTION = new SqlParameter("@MO_ACTION", SqlDbType.VarChar, 500);
            vppParamMO_ACTION.Value = clsMouchard.MO_ACTION;

            pvpChoixCritere(vppCritere);

            //Préparation de la commande
            this.vapRequete = "UPDATE MOUCHARD SET " +
            " AG_CODEAGENCE = @AG_CODEAGENCE , " +
            " OP_CODEOPERATEUR = @OP_CODEOPERATEUR , " +
            " MO_DATEACTION = @MO_DATEACTION , " +
            " MO_HEUREACTION = @MO_HEUREACTION , " +
            " MO_ACTION = @MO_ACTION" + this.vapCritere;

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamMO_DATEACTION);
            vppSqlCmd.Parameters.Add(vppParamMO_HEUREACTION);
            vppSqlCmd.Parameters.Add(vppParamMO_ACTION);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:MO_SEQUENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "DELETE FROM MOUCHARD " + this.vapCritere;
            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE,MO_SEQUENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsMouchard </returns>
		///<author>Home Technologie</author>
		public List<clsMouchard> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsMouchard> clsMouchards = new List<clsMouchard>();

            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM MOUCHARD " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            this.vapCritere = "";
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMouchard clsMouchard = new clsMouchard();
                    clsMouchard.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
                    clsMouchard.MO_SEQUENCE = clsDonnee.vogDataReader["MO_SEQUENCE"].ToString();
                    clsMouchard.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                    clsMouchard.MO_DATEACTION = DateTime.Parse(clsDonnee.vogDataReader["MO_DATEACTION"].ToString());
                    clsMouchard.MO_HEUREACTION = DateTime.Parse(clsDonnee.vogDataReader["MO_HEUREACTION"].ToString());
                    clsMouchard.MO_ACTION = clsDonnee.vogDataReader["MO_ACTION"].ToString();
                    clsMouchards.Add(clsMouchard);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMouchards;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE,MO_SEQUENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsMouchard </returns>
		///<author>Home Technologie</author>
		public List<clsMouchard> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsMouchard> clsMouchards = new List<clsMouchard>();
            DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM MOUCHARD " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsMouchard clsMouchard = new clsMouchard();
                    clsMouchard.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
                    clsMouchard.MO_SEQUENCE = Dataset.Tables["TABLE"].Rows[Idx]["MO_SEQUENCE"].ToString();
                    clsMouchard.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
                    clsMouchard.MO_DATEACTION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_DATEACTION"].ToString());
                    clsMouchard.MO_HEUREACTION = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["MO_HEUREACTION"].ToString());
                    clsMouchard.MO_ACTION = Dataset.Tables["TABLE"].Rows[Idx]["MO_ACTION"].ToString();
                    clsMouchards.Add(clsMouchard);
                }
                Dataset.Dispose();
            }
            return clsMouchards;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : AG_CODEAGENCE,MO_SEQUENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT * FROM MOUCHARD " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : AG_CODEAGENCE,MO_SEQUENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT AG_CODEAGENCE,MO_SEQUENCE,OP_CODEOPERATEUR,MO_DATEACTION,MO_HEUREACTION,MO_ACTION FROM MOUCHARD " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : AG_CODEAGENCE,MO_SEQUENCE)</summary>
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
                    this.vapCritere = " WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND  MO_SEQUENCE=@MO_SEQUENCE ";
                    vapNomParametre = new string[] { "@AG_CODEAGENCE", "@MO_SEQUENCE" };
                    vapValeurParametre = new object[] { vppCritere[0], vppCritere[1] };
                    break;
            }
        }

    }
}
