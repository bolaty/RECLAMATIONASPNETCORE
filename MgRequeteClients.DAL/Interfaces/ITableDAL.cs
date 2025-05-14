using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.Tools.Classes;

namespace MgRequeteClients.DAL.Interfaces
{
    public interface ITableDAL<T>
    {
        ///<summary>Cette fonction permet de d'executer une requète scalaire de type count,avec des critères</summary>
        ///<param name="vppCritere">critères de la requète scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere);

        ///<summary>Cette fonction permet de d'executer une requète scalaire de type Min(sur un champs de la base),avec des critères</summary>
        ///<param name="vppCritere">critères de la requète scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere);

        /// <summary>Cette fonction permet de d'executer une requète scalaire de type Max(sur un champs de la base),avec des critères</summary>
        /// <param name="vppCritere">critères de la requète scalaire</param>
        /// <returns>Un string comme valeur du résultat de la requete</returns>
        /// <author>Home Technologie</author>
        string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere);

        /// <summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés</summary>
        /// <param name="vppCritere">critères de la requète</param>
        /// <returns>Un BusinessObject comme valeur de retour de la fonction</returns>
        /// <author>Home Technologie</author>
        T pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere);

        /// <summary>Cette fonction permet d'executer une requete DML d'insertion dans la base de donnees</summary>
        /// <param name="vppCritere">BusinessObject</param>
        /// <author>Home Technologie</author>
        void pvgInsert(clsDonnee clsDonnee, T vppCritere);

        /// <summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees</summary>
        /// <param name="vppCritere">BusinessObject</param>
        /// <param name="vppCritere1">critères de la requète</param>
        /// <author>Home Technologie</author>
        void pvgUpdate(clsDonnee clsDonnee, T vppCritere, params string[] vppCritere1);

        /// <summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees</summary>
        /// <param name="vppCritere">Les critères de suppression</param>
        /// <author>Home Technologie</author>
        void pvgDelete(clsDonnee clsDonnee, params string[] vppCritere);

        /// <summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees sans critères</summary>
        /// <returns>List<BusinessObject>,une liste d'objets</returns>
        /// <author>Home Technologie</author>
        List<T> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere);

        /// <summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec des critères</summary>
        /// <param name="vppCritere">Les critères de la requète SELECT</param>
        /// <returns>List<BusinessObject>,une liste d'objets</returns>
        /// <author>Home Technologie</author>
        List<T> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere);



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees
        ///et de remplir un Dataset avec le resultat de la requete (Ordre critere:)</summary>
        ///<param name="vppCritere">Critère de la requète SELECT</param>
        ///<returns>Un DataSet</returns>
        ///<author>Home Technologie</author>
        DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères(Ordre critere:PY_CODEPAYS)
        ///elle est destinée generalement aux combobox, treeview ...
        ///</summary>
        /// <param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        /// <returns>DataSet</returns>
        ///<author>Home Technologie</author>
        DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere);

        ///// <summary> Cette fonction permet de definir les critères d'une requête  </summary>
        ///// <param name="vppCritere">Les critères de la requète</param>
        /////<author>Home Technologie</author>
        //void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere);
    }
}
