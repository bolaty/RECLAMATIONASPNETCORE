using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.BOJ.BusinessObjects;
using MgRequeteClients.Tools.Classes;
using MgRequeteClients.DAL.Interfaces;
using Microsoft.Data.SqlClient;

namespace MgRequeteClients.DAL.Classes
{
    public class clsMessagesWSDAL : ITableDAL<clsMessages>
    {
        private string vapCritere = "";
        private string vapRequete = "";
        private string[] vapNomParametre = new string[] { };
        private object[] vapValeurParametre = new object[] { };

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count (sur un champs de la base) avec ou sans critères (Ordre Critères : MS_CODEMESSAGE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT COUNT(MS_CODEMESSAGE) AS MS_CODEMESSAGE  FROM MESSAGES " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base)avec ou sans critères (Ordre Critères : MS_CODEMESSAGE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MIN(MS_CODEMESSAGE) AS MS_CODEMESSAGE  FROM MESSAGES " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base) avec ou sans critères (Ordre Critères : MS_CODEMESSAGE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MAX(MS_CODEMESSAGE) AS MS_CODEMESSAGE  FROM MESSAGES " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : MS_CODEMESSAGE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="vppCritere">critères de la requête</param>
		///<param name="clsMessages">clsMessages</param>
		///<author>Home Technologie</author>
		public clsMessages pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MS_LIBELLEMESSAGE FROM MESSAGES " + this.vapCritere;
            this.vapCritere = "";

            clsMessages clsMessages = new clsMessages();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMessages.MS_LIBELLEMESSAGE = clsDonnee.vogDataReader["MS_LIBELLEMESSAGE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMessages;
        }


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés  (Ordre Critères : MS_CODEMESSAGE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="vppCritere">critères de la requête</param>
        ///<param name="clsMessages">clsMessages</param>
        ///<author>Home Technologie</author>
        public clsMessages pvgTableLabelSupplementaire(clsDonnee clsDonnee, params string[] vppCritere)
        {

            this.vapRequete = "SELECT TOP 1 MESSAGESUPPLEMENTAIRE FROM MESSAGESUPPLEMENTAIRE ";
            this.vapCritere = "";

            clsMessages clsMessages = new clsMessages();

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMessages.MS_LIBELLEMESSAGE = clsDonnee.vogDataReader["MESSAGESUPPLEMENTAIRE"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMessages;
        }

        ///<summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMessages">clsMessages</param>
		///<author>Home Technologie</author>
		public void pvgInsert(clsDonnee clsDonnee, clsMessages clsMessages)
        {
            //Préparation des paramètres

            SqlParameter vppParamMS_CODEMESSAGE = new SqlParameter("@MS_CODEMESSAGE", SqlDbType.VarChar, 7);
            vppParamMS_CODEMESSAGE.Value = clsMessages.MS_CODEMESSAGE;

            SqlParameter vppParamMS_LIBELLEMESSAGE = new SqlParameter("@MS_LIBELLEMESSAGE", SqlDbType.VarChar, 150);
            vppParamMS_LIBELLEMESSAGE.Value = clsMessages.MS_LIBELLEMESSAGE;

            //Préparation de la commande
            this.vapRequete = "INSERT INTO MESSAGES " +
            " (MS_CODEMESSAGE,MS_LIBELLEMESSAGE)" +
            " VALUES(@MS_CODEMESSAGE,@MS_LIBELLEMESSAGE)";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamMS_CODEMESSAGE);
            vppSqlCmd.Parameters.Add(vppParamMS_LIBELLEMESSAGE);

            //Ouverture de la connection et exécution de la commande
            vppSqlCmd.ExecuteNonQuery();
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees avec critères(Ordre critere:MS_CODEMESSAGE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsMessages">clsMessages</param>
		///<param name="vppCritere">Les critères de modification</param>
		///<author>Home Technologie</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsMessages clsMessages, params string[] vppCritere)
        {
            //Préparation des paramètres

            SqlParameter vppParamMS_LIBELLEMESSAGE = new SqlParameter("@MS_LIBELLEMESSAGE", SqlDbType.VarChar, 150);
            vppParamMS_LIBELLEMESSAGE.Value = clsMessages.MS_LIBELLEMESSAGE;

            pvpChoixCritere(vppCritere);

            //Préparation de la commande
            this.vapRequete = "UPDATE MESSAGES SET " +
            " MS_LIBELLEMESSAGE = @MS_LIBELLEMESSAGE" + this.vapCritere;

            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamMS_LIBELLEMESSAGE);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre critere:MS_CODEMESSAGE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de suppression</param>
		///<author>Home Technologie</author>
		public void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "DELETE FROM MESSAGES " + this.vapCritere;
            this.vapCritere = "";

            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : MS_CODEMESSAGE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsMessages </returns>
		///<author>Home Technologie</author>
		public List<clsMessages> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsMessages> clsMessagess = new List<clsMessages>();

            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM MESSAGES " + this.vapCritere;
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            this.vapCritere = "";
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsMessages clsMessages = new clsMessages();
                    clsMessages.MS_CODEMESSAGE = clsDonnee.vogDataReader["MS_CODEMESSAGE"].ToString();
                    clsMessages.MS_LIBELLEMESSAGE = clsDonnee.vogDataReader["MS_LIBELLEMESSAGE"].ToString();
                    clsMessagess.Add(clsMessages);
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMessagess;
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères (Ordre Critères : MS_CODEMESSAGE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns> une Collection de clsMessages </returns>
		///<author>Home Technologie</author>
		public List<clsMessages> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            List<clsMessages> clsMessagess = new List<clsMessages>();
            DataSet Dataset = new DataSet();
            pvpChoixCritere(vppCritere);

            this.vapRequete = "SELECT * FROM MESSAGES " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);
            if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            {
                for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
                {
                    clsMessages clsMessages = new clsMessages();
                    clsMessages.MS_CODEMESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["MS_CODEMESSAGE"].ToString();
                    clsMessages.MS_LIBELLEMESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["MS_LIBELLEMESSAGE"].ToString();
                    clsMessagess.Add(clsMessages);
                }
                Dataset.Dispose();
            }
            return clsMessagess;
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  avec ou sans critères (Ordre Critères : MS_CODEMESSAGE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT * FROM MESSAGES " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete avec ou sans critères (Ordre Critères : MS_CODEMESSAGE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="vppCritere">Les critères de la requète SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(vppCritere);
            this.vapRequete = "SELECT MS_CODEMESSAGE,MS_LIBELLEMESSAGE FROM MESSAGES " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }



        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères : MS_CODEMESSAGE)</summary>
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
                    this.vapCritere = " WHERE MS_CODEMESSAGE=@MS_CODEMESSAGE ";
                    vapNomParametre = new string[] { "@MS_CODEMESSAGE" };
                    vapValeurParametre = new object[] { vppCritere[0] };
                    break;
            }
        }

    }
}
