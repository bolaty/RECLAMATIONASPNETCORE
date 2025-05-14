using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.BOJ.BusinessObjects;
using MgRequeteClients.Tools.Classes;

namespace MgRequeteClients.BLL.Interfaces
{
    internal interface IObjetWSBLL<T>
    {
        ///<summary>Cette fonction permet de d'executer une requète scalaire de type count,avec des critères(Ordre critere:ET_INDEX)</summary>
        /// <param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="vppCritere">critères de la requète scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi);

        ///<summary>Cette fonction permet de d'executer une requète scalaire de type Min(sur un champs de la base),avec des critères(Ordre critere:ET_INDEX)</summary>
        ///<param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="vppCritere">critères de la requète scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi);

        ///<summary>Cette fonction permet de d'executer une requète scalaire de type Max(sur un champs de la base),avec des critères(Ordre critere:ET_INDEX)</summary>
        /// <param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="vppCritere">critères de la requète scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi);

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:ET_INDEX)</summary>
        ///<param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="vppCritere">critères de la requète scalaire</param>
        ///<returns>Un BusinessObject comme valeur de retour de la fonction</returns>
        ///<author>Home Technologie</author>
        T pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi);

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
        ///<param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="clsPays">clsPays </param>
        ///<returns>Un string comme valeur de retour de la fonction</returns>
        ///<author>Home Technologie</author>
        string pvgAjouter(clsDonnee clsDonnee, T vppObjet1, clsObjetEnvoi clsObjetEnvoi);

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
        ///<param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="clsPayss">Liste</param>
        ///<param name="vppCritere">critères de la requète </param>
        ///<returns>Un string comme valeur de retour de la fonction</returns>
        ///<author>Home Technologie</author>
        string pvgAjouterListe(clsDonnee clsDonnee, List<T> vppObjet1, clsObjetEnvoi clsObjetEnvoi);

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:ET_INDEX)</summary>
        /// <param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="clsPays">clsPays </param>
        ///<param name="vppCritere">critères de la requète de modification</param>
        ///<returns>Un string comme valeur de retour de la fonction</returns>
        ///<author>Home Technologie</author>
        string pvgModifier(clsDonnee clsDonnee, T vppObjet1, clsObjetEnvoi clsObjetEnvoi);

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees(Ordre critere:ET_INDEX)</summary>
        ///<param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="vppCritere">Les critères de suppression</param>
        ///<returns>string</returns>
        ///<author>Home Technologie</author>
        string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec des critères(Ordre critere:ET_INDEX)</summary>
        ///<param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="vppCritere">Chaine de la requète SELECT</param>
        ///<returns>une liste d'objets</returns>
        ///<author>Home Technologie</author>
        List<T> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi);

        /// <summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec des critères</summary>
        /// <param name="vppCritere">Les critères de la requète SELECT</param>
        /// <returns>List<BusinessObject>,une liste d'objets</returns>
        /// <author>Home Technologie</author>
        List<T> pvgChargerAPartirDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi);

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:ET_INDEX)</summary>
        /// <param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="vppCritere">Critère de la requète SELECT</param>
        ///<returns>Un DataSet</returns>
        ///<author>Home Technologie</author>
        DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères(Ordre critere:PY_CODEPAYS)
        ///elle est destinée generalement aux combobox, treeview ...
        ///</summary>
        /// <param name="clsDonnee"> Classe d'accès aux données</param>
        ///<param name="vppCritere">Les critères de la requète SELECT</param>
        /// <returns>DataSet</returns>
        ///<author>Home Technologie</author>
        DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi);

        /////<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères(Ordre critere:PY_CODEPAYS) elle est destinée generalement aux combobox, treeview ...</summary>
        ///// <param name="clsDonnee"> Classe d'accès aux données</param>
        ///// <param name="vppChamp">Champs du SELECT séparés par des virgules</param>
        ///// <param name="vppChampOrdre">Champs du ORDER BY séparés par des virgules</param>
        /////<param name="vppCritere">Les critères de la requète SELECT</param>
        ///// <returns> DataSet</returns>
        /////<author>Home Technologie</author>
        //DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, string vppChamps, string vppChampOrdre, T vppObjet);

        /// <summary>
        /// Cette fonction permet de generer le mouchard
        /// </summary>
        /// <param name="vppAction">Action réalisé</param>
        /// <param name="vppTypeAction">Type d'action</param>
        /// <returns>clsMouchard</returns>
        clsMouchard pvpGenererMouchard(clsObjetEnvoi clsObjetEnvoi, string vppAction, string vppTypeAction);
    }
}
