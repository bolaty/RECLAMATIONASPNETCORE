using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MgRequeteClients.Tools.Classes
{
    public class clsDonnee
    {
        private readonly string _connectionString;
        #region Variables
        // Nombre de lignes du résultat d'une requête
        private string vapNombreLigneRequeteLocal;
        //Nombre de colonnes du résultat d'une requête
        private int vapNombreColonneRequeteLocal;
        //variable objet tableau contenant le contenu d'une requete
        private Object[,] vopRequeteDansTableau;
        // Instruction SQL
        private SqlCommand vapObjetCommandeLocal;
        // Flux de lignes de données stockant le résultat d'une requête
        private SqlDataReader vapObjetDataReaderLocal;
        // DataAdapter
        private SqlDataAdapter vapObjetDataAdapterLocal;
        // DataSet
        private DataSet vapDataSetLocal;
        //Objet connection
        private SqlConnection vapObjetConnexionLocal;
        //// Transaction
        private SqlTransaction vapObjetTransactionLocal;
        // EtatConnexion
        bool vagEtatConnexion;
        // Clé de cryptage décryptage
        private string vapCleCryptage;
        // Nom d'utilisateur
        private string vapUtilisateur;

        #endregion

        #region Propriétés

        public string vagNombreLigneRequete
        {
            get { return vapNombreLigneRequeteLocal; }
        }
        public int vagNombreColonneRequete
        {
            get { return vapNombreColonneRequeteLocal; }
        }
        public Object[,] vogDonneeDansTableau
        {
            get { return vopRequeteDansTableau; }
        }
        public SqlDataReader vogDataReader
        {
            get
            {
                return vapObjetDataReaderLocal;
            }
        }
        public DataSet vogDataSet
        {
            get
            {
                return vapDataSetLocal;
            }
            set
            {
                vapDataSetLocal = value;
            }
        }
        public SqlTransaction vogObjetTransactionLocal
        {
            get
            {
                return vapObjetTransactionLocal;
            }
            set
            {
                vapObjetTransactionLocal = value;
            }
        }
        public SqlConnection vogObjetConnexionLocal
        {
            get
            {
                return vapObjetConnexionLocal;
            }
            set
            {
                vapObjetConnexionLocal = value;
            }
        }

        public string vogCleCryptage
        {
            get { return vapCleCryptage; }
            set { vapCleCryptage = clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(value); }
        }

        public string vogUtilisateur
        {
            get { return vapUtilisateur; }
            set
            {
                vapUtilisateur = clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(value);
                this.vogObjetConnexionLocal.ConnectionString = String.Format(this.vogObjetConnexionLocal.ConnectionString, vapUtilisateur);
            }
        }

        #endregion

        #region  constructeur privé
        //constructeur privé de la classe clsDeclaration
        public clsDonnee(IConfiguration configuration)
        {
            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;


            vapNombreLigneRequeteLocal = "0";
            vapNombreColonneRequeteLocal = 0;
            vapObjetDataReaderLocal = null;
            vapObjetConnexionLocal = new SqlConnection(clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(configuration.GetConnectionString("DefaultConnection").ToString()));
        }
        #endregion

        #region Connexion à la base de données SQLServer
        public bool pvgConnectionBase()
        {
            try
            {
                if (vapObjetConnexionLocal.State != ConnectionState.Open)
                {
                    vapObjetConnexionLocal.Open();
                }
                return true;
            }
            catch
            {
                if (vagEtatConnexion)
                {
                    return true;
                }
                return false;
            }
        }
        #endregion

        #region Gère les transactions

        public void pvgDemarrerTransaction()
        {
            pvgConnectionBase();
            vapObjetTransactionLocal = vapObjetConnexionLocal.BeginTransaction();
        }

        public void pvgValiderTransaction()
        {
            vapObjetTransactionLocal.Commit();
        }

        public void pvgAnnulerTransaction()
        {
            if (vapObjetTransactionLocal != null)
            { vapObjetTransactionLocal.Rollback(); }
        }

        public bool pvgTerminerTransaction(bool vppResultatMiseAjour)
        {
            //Validation de la transaction
            if (vapObjetTransactionLocal != null)
            {
                if (vppResultatMiseAjour)
                {
                    pvgAnnulerTransaction();
                    //Fermeture de la connection
                    if (vapObjetConnexionLocal.State == ConnectionState.Open)
                    {
                        pvgDeConnectionBase();
                    }
                    return false;
                }
                else
                {
                    try
                    {
                        pvgValiderTransaction();
                        //Fermeture de la connection
                        if (vapObjetConnexionLocal.State == ConnectionState.Open)
                        {
                            pvgDeConnectionBase();
                        }
                        return true;
                    }
                    catch
                    {
                        pvgAnnulerTransaction();
                        //Fermeture de la connection
                        if (vapObjetConnexionLocal.State == ConnectionState.Open)
                        {
                            pvgDeConnectionBase();
                        }
                        return false;
                    }
                }
            }
            return false;
        }

        #endregion

        #region Récupère la valeur de l'agregat:ExecuteScalar
        public string pvgValueScalarRequete(SqlCommand vppSqlCommand, string[] vppNomParametre, object[] vppValeurParametre)
        {
            if (pvgConnectionBase())
            {
                try
                {
                    if (vppNomParametre != null && vppValeurParametre != null)
                        for (int i = 0; i < vppNomParametre.Length; i++)
                        {
                            vppSqlCommand.Parameters.Add(new SqlParameter(vppNomParametre[i], vppValeurParametre[i]));
                        }
                    if (vppSqlCommand.ExecuteScalar().ToString() == "") return "0";
                    vapNombreLigneRequeteLocal = vppSqlCommand.ExecuteScalar().ToString();
                    return vapNombreLigneRequeteLocal.ToString();
                }
                catch (SqlException SQLEx)
                {
                    throw SQLEx;
                }
                finally
                {
                    vppSqlCommand = null;
                }
            }
            else
            {
                return "0";
            }
        }
        #endregion

        #region Remplit un DataReader
        public bool pvgRemplirDataReader(SqlCommand vppSqlCommand, string[] vppNomParametre, object[] vppValeurParametre)
        {
            if (pvgConnectionBase())
            {
                try
                {
                    vapObjetDataReaderLocal = null;
                    if (vppNomParametre != null && vppValeurParametre != null)
                        for (int i = 0; i < vppNomParametre.Length; i++)
                        {
                            vppSqlCommand.Parameters.Add(new SqlParameter(vppNomParametre[i], vppValeurParametre[i]));
                        }

                    vapObjetDataReaderLocal = vppSqlCommand.ExecuteReader();
                    //Nombre total de champs dans la table
                    vapNombreColonneRequeteLocal = vapObjetDataReaderLocal.FieldCount;

                    //on initialise le nombre de ligne
                    vapNombreLigneRequeteLocal = "0";
                    double vlpNombreLigneRequeteLocal = 0;
                    while (vapObjetDataReaderLocal.Read())
                    {
                        vlpNombreLigneRequeteLocal++;
                    }
                    vapNombreLigneRequeteLocal = vlpNombreLigneRequeteLocal.ToString();
                    vapObjetDataReaderLocal.Dispose();
                    vapObjetDataReaderLocal = vppSqlCommand.ExecuteReader();

                    if (int.Parse(vapNombreLigneRequeteLocal) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        vapObjetDataReaderLocal.Dispose();
                        return false;
                    }
                }
                catch (SqlException SQLEx)
                {
                    throw SQLEx;
                }
                finally
                {
                    //destruction de la commande
                    vppSqlCommand.Dispose();
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Remplit un DataSet

        public DataSet pvgRemplirDataset(SqlCommand vppSqlCommand, string[] vppNomParametre, object[] vppValeurParametre, bool vppValeur)
        {
            vapDataSetLocal = new DataSet();
            vapDataSetLocal.Clear();
            vapNombreLigneRequeteLocal = "0";
            if (pvgConnectionBase())
            {
                try
                {
                    if (vppNomParametre != null && vppValeurParametre != null)
                        for (int i = 0; i < vppNomParametre.Length; i++)
                        {
                            vppSqlCommand.Parameters.Add(new SqlParameter(vppNomParametre[i], vppValeurParametre[i]));
                        }
                    vapObjetDataAdapterLocal = new SqlDataAdapter(vppSqlCommand);
                    vapObjetDataAdapterLocal.Fill(vapDataSetLocal, "TABLE");
                    vapNombreLigneRequeteLocal = vapDataSetLocal.Tables["TABLE"].Rows.Count.ToString();
                    vapObjetDataAdapterLocal.Dispose();
                }
                catch (SqlException SQLEx)
                {
                    throw SQLEx;
                }
                finally
                {
                    vapObjetDataAdapterLocal = null;
                }
            }
            return vapDataSetLocal;

        }

        public bool pvgRemplirDataset(SqlCommand vppSqlCommand, string[] vppNomParametre, object[] vppValeurParametre, DataSet mondataset)
        {
            vapNombreLigneRequeteLocal = "0";
            if (pvgConnectionBase())
            {
                try
                {
                    if (vppNomParametre != null && vppValeurParametre != null)
                        for (int i = 0; i < vppNomParametre.Length; i++)
                        {
                            vppSqlCommand.Parameters.Add(new SqlParameter(vppNomParametre[i], vppValeurParametre[i]));
                        }
                    vapObjetDataAdapterLocal = new SqlDataAdapter(vppSqlCommand);
                    vapObjetDataAdapterLocal.Fill(mondataset, "TABLE");
                    vapNombreLigneRequeteLocal = mondataset.Tables["TABLE"].Rows.Count.ToString();
                    vapObjetDataAdapterLocal.Dispose();

                    if (int.Parse(vapNombreLigneRequeteLocal) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (SqlException SQLEx)
                {
                    throw SQLEx;
                    //return false;
                }
                finally
                {
                    vapObjetDataAdapterLocal = null;
                }
            }
            else
            {
                return false;
            }

        }

        #endregion

        #region  Déconnexion de la base de données SQLServer
        public bool pvgDeConnectionBase()
        {
            try
            {
                vapObjetConnexionLocal.Close();
                vapObjetConnexionLocal.Dispose();
                vapObjetConnexionLocal = null;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Lance un ordre SQL de INSERT, UPDATE ou DELETE

        public void pvgMiseAJourBaseDeDonnees(SqlCommand vppSqlCommand, string[] vppNomParametre, object[] vppValeurParametre)
        {
            try
            {
                if (vppNomParametre != null && vppValeurParametre != null)
                    for (int i = 0; i < vppNomParametre.Length; i++)
                    {
                        vppSqlCommand.Parameters.Add(new SqlParameter(vppNomParametre[i], vppValeurParametre[i]));
                    }
                vppSqlCommand.ExecuteNonQuery();
                vapObjetCommandeLocal = null;
            }
            catch (SqlException SQLEx)
            {
                vapObjetCommandeLocal = null;
                throw SQLEx;
            }
        }

        public void pvgMiseAJourBaseDeDonneesAvecValeurRetour(SqlCommand vppSqlCommand, string[] vppNomParametre, object[] vppValeurParametre)
        {
            try
            {
                if (vppNomParametre != null && vppValeurParametre != null)
                    for (int i = 0; i < vppNomParametre.Length; i++)
                    {
                        vppSqlCommand.Parameters.Add(new SqlParameter(vppNomParametre[i], vppValeurParametre[i]));
                    }
                vppSqlCommand.ExecuteScalar();
                vapObjetCommandeLocal = null;
            }
            catch (SqlException SQLEx)
            {
                vapObjetCommandeLocal = null;
                throw SQLEx;
            }
        }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppChaineValeur">Valeur a prendre en compte dans le IN</param>
        /// <param name="vppchamp">champ sur leqel on doit faire le IN</param>
        /// <returns></returns>
        public string pvpParametreIN(string vppChaineValeur, string vppchamp)
        {
            string[] vppValeurIN = vppChaineValeur.Split('#');
            string vlpValeur = "";
            for (int i = 0; i < vppValeurIN.Length; i++)
            {
                vlpValeur += i == vppValeurIN.Length - 1 ? "@" + vppchamp + i.ToString() : "@" + vppchamp + i.ToString() + ",";
            }
            return vlpValeur;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppNomParametre">Tableau contenant les Noms des parametres de la requete préparée</param>
        /// <param name="vppChaineValeur">Valeur a prendre en compte dans le IN</param>
        /// <param name="vppPosition">position du parametre sur lequel se fait le IN</param>
        /// <param name="vppchamp"> champ sur leqel on doit faire le IN</param>
        public string[] pvpTransformationIN(string[] vppNomParametre, string vppChaineValeur, int vppPosition, string vppchamp)
        {
            List<string> vppListeNomParametre = new List<string>();
            string[] vppValeurIN = new string[] { };
            vppListeNomParametre = vppNomParametre.ToList();
            vppListeNomParametre.RemoveAt(vppPosition);
            vppValeurIN = vppChaineValeur.Split('#');
            for (int i = 0; i < vppValeurIN.Length; i++)
                vppListeNomParametre.Add("@" + vppchamp + i.ToString());

            vppNomParametre = vppListeNomParametre.ToArray();
            return vppNomParametre;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vppNomParametre">Tableau contenant les Noms des parametres de la requete préparée</param>
        ///// <param name="vppChaineValeur">Valeur a prendre en compte dans le IN</param>
        ///// <param name="vppPosition">position du parametre sur lequel se fait le IN</param>
        ///// <param name="vppchamp"> champ sur leqel on doit faire le IN</param>
        //public string[] pvpTransformationIN(List<string> vppNomParametre, string vppChaineValeur, int vppPosition, string vppchamp)
        //{
        //    string[] vppValeurIN = new string[] { };
        //    //1- extraction du nom du parametre a transformer
        //    vppNomParametre.RemoveAt(vppPosition);
        //    //2- transforme la chaine de valeur du in en tableau
        //    vppValeurIN = vppChaineValeur.Split('#');
        //    //3- on parcoure le tableau pour créer puis ajouter les noms des nouveaux  parametres  a la liste 
        //    for (int i = 0; i < vppValeurIN.Length; i++)
        //        vppNomParametre.Add("@" + vppchamp + i.ToString());
        //    return vppNomParametre.ToArray();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppValeurParametre">Tableau contenant les valeurs des parametres de la requete préparée</param>
        /// <param name="vppPosition">position de la valeur contenant le IN</param>
        /// <param name="vppchamp">champ sur leqel on doit faire le IN</param>
        /// <returns></returns>
        public object[] pvpTransformationIN(object[] vppValeurParametre, int vppPosition, string vppchamp)
        {
            List<object> vppListeValeurParametre = new List<object>();
            string[] vppValeurIN = new string[] { };
            vppListeValeurParametre = vppValeurParametre.ToList();
            vppValeurIN = vppValeurParametre[vppPosition].ToString().Split('#');
            vppListeValeurParametre.RemoveAt(vppPosition);
            for (int i = 0; i < vppValeurIN.Length; i++)
                vppListeValeurParametre.Add(vppValeurIN[i]);
            vppValeurParametre = vppListeValeurParametre.ToArray();
            return vppValeurParametre;
        }
    }
}
