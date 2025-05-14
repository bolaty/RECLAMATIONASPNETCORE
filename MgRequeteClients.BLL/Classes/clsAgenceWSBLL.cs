using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.BLL.Interfaces;
using MgRequeteClients.BOJ.BusinessObjects;
using MgRequeteClients.DAL.Classes;
using MgRequeteClients.Tools.Classes;

namespace MgRequeteClients.BLL.Classes
{
    public class clsAgenceWSBLL : IObjetWSBLL<clsAgence>
    {
        DateTime vlpDatePremiereJourneTravail;
        private clsOperateurWSDAL clsOperateurWSDAL = new clsOperateurWSDAL();
        private clsExerciceWSDAL clsExerciceWSDAL = new clsExerciceWSDAL();
        private clsJourneetravailWSDAL clsJourneetravailWSDAL = new clsJourneetravailWSDAL();
        private clsAgenceWSDAL clsAgenceWSDAL = new clsAgenceWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count,avec ou sans critères(Ordre critere:SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsAgenceWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base),avec ou sans critères(Ordre critere:SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsAgenceWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base),avec ou sans critères(Ordre critere:SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsAgenceWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>clsAgence </returns>
		///<author>Home Technologie</author>
		public clsAgence pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsAgenceWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsAgence">clsAgence</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsAgence clsAgence, clsObjetEnvoi clsObjetEnvoi)
        {
            clsAgence.AG_CODEAGENCE = (double.Parse(clsAgenceWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();//"1000";// 
            clsAgenceWSDAL.pvgInsert(clsDonnee, clsAgence);
            //Recupération du code de l'agence en cours de création
            clsObjetEnvoi.OE_A = clsAgence.AG_CODEAGENCE;
            //Création automatique de la première journée de travail
            clsJourneetravailWSDAL.pvgInsert(clsDonnee, pvpRecuperationParametreObjet(new clsJourneetravail(), clsObjetEnvoi));
            //Création automatique de l'exercice de l'agence crée
            clsExerciceWSDAL.pvgInsert(clsDonnee, pvpRecuperationParametreObjet(new clsExercice(), clsObjetEnvoi));
            //Création automatique de l'opérateur de l'agence crée : ADMIN ET BILAN.
            clsOperateurWSDAL.pvgInsert(clsDonnee, pvpRecuperationParametreObjet1(clsDonnee, new clsOperateur(), clsObjetEnvoi));
            clsOperateurWSDAL.pvgInsert(clsDonnee, pvpRecuperationParametreObjet2(clsDonnee, new clsOperateur(), clsObjetEnvoi));
            //le mouchard sera executé si ce n'est pas la première execution
            if (!clsObjetEnvoi.OE_Z)
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsAgence.AG_CODEAGENCE.ToString(), "A"));
            return "";
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
		///<param name="clsDonnee"> Classe d'accès aux données</param>
		///<param name="clsAgences">Collection de clsAgence </param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsAgence> clsAgences, clsObjetEnvoi clsObjetEnvoi)
        {
            clsAgenceWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            for (int Idx = 0; Idx < clsAgences.Count; Idx++)
            {
                clsAgences[Idx].AG_CODEAGENCE = (double.Parse(clsAgenceWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
                clsAgenceWSDAL.pvgInsert(clsDonnee, clsAgences[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsAgences[Idx].AG_CODEAGENCE.ToString(), "A"));
            }
            return "";
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees,avec ou sans critères(Ordre critere:SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsAgence">clsAgence</param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgModifier(clsDonnee clsDonnee, clsAgence clsAgence, clsObjetEnvoi clsObjetEnvoi)
        {
            clsAgenceWSDAL.pvgUpdate(clsDonnee, clsAgence, clsObjetEnvoi.OE_PARAM);
            //le mouchard sera executé si ce n'est pas la première execution
            if (!clsObjetEnvoi.OE_Z)
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsAgence.AG_CODEAGENCE.ToString(), "M"));
            return "";
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees,avec ou sans critères(Ordre critere:SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsExerciceWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsJourneetravailWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsOperateurWSDAL.pvgDelete1(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            //Reconstruction des paramètres nésséssaire à la suppression d'une agence:société dabors, ensuite agence.
            //ici,cette reconstruction est dûe au fait que la bllcleint de suppression ne contient pas le paramètre société.
            List<String> vppParams = new List<String>();
            vppParams.Add(clsObjetEnvoi.OE_O);
            for (int i = 0; i < clsObjetEnvoi.OE_PARAM.Length; i++)
                vppParams.Add(clsObjetEnvoi.OE_PARAM[i]);
            clsObjetEnvoi.OE_PARAM = vppParams.ToArray();
            //Suppression de la table agence
            clsAgenceWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            string vppValeurMouchard = clsObjetEnvoi.OE_PARAM.Length > 0 ? clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
            //le mouchard sera executé si ce n'est pas la première execution
            if (!clsObjetEnvoi.OE_Z)
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
            return "";
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsAgence</returns>
		///<author>Home Technologie</author>
		public List<clsAgence> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsAgenceWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsAgence</returns>
		///<author>Home Technologie</author>
		public List<clsAgence> pvgChargerAPartirDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsAgenceWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsAgenceWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:SO_CODESOCIETE,AG_CODEAGENCE)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsAgenceWSDAL.pvgChargerDansDataSet1(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		///(Ordre critere:SO_CODESOCIETE,AG_CODEAGENCE) elle est destinée generalement aux combobox, treeview ...</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            ////O=Charge toutes les agences.
            ////if (clsObjetEnvoi.OE_R == "O")
            ////{
            ////   return clsAgenceWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee , clsObjetEnvoi.OE_PARAM);
            ////}
            ////Z=Charges la liste des agence uniquement de la coordination.
            //if(clsObjetEnvoi.OE_R == "Z")
            //{
            //    List<String> vppParams = new List<String>();
            //    vppParams.Add(clsObjetEnvoi.OE_O);//Société
            //    vppParams.Add(clsObjetEnvoi.OE_Q);//EXERCICE
            //    vppParams.Add(clsObjetEnvoi.OE_E);//Zone ou coordination
            //    clsObjetEnvoi.OE_PARAM = vppParams.ToArray();
            //}
            ////N=Charge la seule agence elle même.
            //else if(clsObjetEnvoi.OE_R == "N")
            //{
            //    List<String> vppParams = new List<String>();
            //    vppParams.Add(clsObjetEnvoi.OE_O);//Société
            //    vppParams.Add(clsObjetEnvoi.OE_A);//Agence
            //    clsObjetEnvoi.OE_PARAM = vppParams.ToArray();
            //}
            return clsAgenceWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de generer le mouchard</summary>
		///<param name="vppAction">Action réalisé</param>
		///<param name="vppTypeAction">Type d'action</param>
		///<returns>clsMouchard</returns>
		///<author>Home Technologie</author>
		public clsMouchard pvpGenererMouchard(clsObjetEnvoi clsObjetEnvoi, string vppAction, string vppTypeAction)
        {
            clsMouchard clsMouchard = new clsMouchard();
            clsMouchard.AG_CODEAGENCE = clsObjetEnvoi.OE_A;
            clsMouchard.OP_CODEOPERATEUR = clsObjetEnvoi.OE_Y;
            switch (vppTypeAction)
            {
                case "A":
                    clsMouchard.MO_ACTION = "AGENCE  (Ajout)  : " + vppAction;
                    break;
                case "M":
                    clsMouchard.MO_ACTION = "AGENCE  (Modification)  : " + vppAction;
                    break;
                case "S":
                    clsMouchard.MO_ACTION = "AGENCE  (Suppression)  : " + vppAction;
                    break;
                case "E":
                    clsMouchard.MO_ACTION = "AGENCE  (Edition de l'etatEdition de l'etat)  : " + vppAction;
                    break;
            }
            return clsMouchard;
        }

        private clsJourneetravail pvpRecuperationParametreObjet(clsJourneetravail clsJourneetravail, clsObjetEnvoi clsObjetEnvoi)
        {
            clsDate clsDate = new clsDate();
            clsJourneetravail.AG_CODEAGENCE = clsObjetEnvoi.OE_A;

            vlpDatePremiereJourneTravail = DateTime.Parse("07" + "/01/" + clsObjetEnvoi.OE_Q);
            //Si le jour sélectioné est un samedi,il faut ajouter un jour de plus
            if (vlpDatePremiereJourneTravail.DayOfWeek == DayOfWeek.Saturday)
                vlpDatePremiereJourneTravail = clsDate.pvgDateAdd(vlpDatePremiereJourneTravail, 2, "J");
            //Si le jour sélectioné est un dimanche,il faut ajouter un jour de plus
            if (vlpDatePremiereJourneTravail.DayOfWeek == DayOfWeek.Sunday)
                vlpDatePremiereJourneTravail = clsDate.pvgDateAdd(vlpDatePremiereJourneTravail, 2, "J");
            //
            //Affichage par defaut de la date de fin  de l'exercice
            clsJourneetravail.JT_DATEJOURNEETRAVAIL = vlpDatePremiereJourneTravail;
            clsJourneetravail.JT_STATUT = "O";
            clsJourneetravail.OP_CODEOPERATEUR = clsObjetEnvoi.OE_Y;
            return clsJourneetravail;
        }

        private clsExercice pvpRecuperationParametreObjet(clsExercice clsExercice, clsObjetEnvoi clsObjetEnvoi)
        {
            clsExercice.AG_CODEAGENCE = clsObjetEnvoi.OE_A;
            clsExercice.EX_EXERCICE = clsObjetEnvoi.OE_Z ? clsObjetEnvoi.OE_S.Year.ToString() : clsObjetEnvoi.OE_J.Year.ToString();
            clsExercice.JT_DATEJOURNEETRAVAIL = vlpDatePremiereJourneTravail;
            if (clsObjetEnvoi.OE_Z)
                clsExercice.EX_DATEDEBUT = DateTime.Parse("01/01/" + DateTime.Today.Year);
            else
                clsExercice.EX_DATEDEBUT = DateTime.Parse("01/01/" + clsObjetEnvoi.OE_J.Year);

            //Affichage par defaut de la date de fin  de l'exercice
            clsExercice.EX_DATEFIN = DateTime.Parse("31/12/" + clsExercice.EX_EXERCICE);
            clsExercice.EX_ETATEXERCICE = "O";
            clsExercice.EX_DESCEXERCICE = "EXERCICE " + clsExercice.EX_EXERCICE;
            clsExercice.EX_DATESAISIE = clsObjetEnvoi.OE_J;
            return clsExercice;
        }

        private clsOperateur pvpRecuperationParametreObjet1(clsDonnee clsDonnee, clsOperateur clsOperateur, clsObjetEnvoi clsObjetEnvoi)
        {
            clsOperateur.AG_CODEAGENCE = clsObjetEnvoi.OE_A;
            clsOperateur.OP_CODEOPERATEUR = clsObjetEnvoi.OE_A + string.Format("{0:00000}", 1);
            if (clsObjetEnvoi.OE_A.Length == 4)
                clsOperateur.OP_LOGIN = "ADMIN00" + clsObjetEnvoi.OE_A;
            if (clsObjetEnvoi.OE_A.Length == 5)
                clsOperateur.OP_LOGIN = "ADMIN0" + clsObjetEnvoi.OE_A;

            clsOperateur.OP_NOMPRENOM = "ADMINISTRATEUR";
            clsOperateur.OP_MOTPASSE = "123";
            clsOperateur.OP_ACTIF = "O";
            clsOperateur.OP_JOURNEEOUVERTE = "O";
            clsOperateur.PO_CODEPROFIL = "01";
            clsOperateur.OP_TELEPHONE = "00-00-00-00";
            if (clsObjetEnvoi.OE_A.Length == 4)
                clsOperateur.OP_EMAIL = "admin00" + clsObjetEnvoi.OE_A + "@gmail.com";
            if (clsObjetEnvoi.OE_A.Length == 5)
                clsOperateur.OP_EMAIL = "admin0" + clsObjetEnvoi.OE_A + "@gmail.com";
            clsOperateur.OP_DATESAISIE = clsObjetEnvoi.OE_J;
            return clsOperateur;
        }

        private clsOperateur pvpRecuperationParametreObjet2(clsDonnee clsDonnee, clsOperateur clsOperateur, clsObjetEnvoi clsObjetEnvoi)
        {
            clsOperateur.AG_CODEAGENCE = clsObjetEnvoi.OE_A;
            clsOperateur.OP_CODEOPERATEUR = clsObjetEnvoi.OE_A + string.Format("{0:00000}", 2);
            if (clsObjetEnvoi.OE_A.Length == 4)
                clsOperateur.OP_LOGIN = "BILAN00" + clsObjetEnvoi.OE_A;
            if (clsObjetEnvoi.OE_A.Length == 5)
                clsOperateur.OP_LOGIN = "BILAN0" + clsObjetEnvoi.OE_A;
            clsOperateur.OP_NOMPRENOM = "BILAN";
            clsOperateur.OP_MOTPASSE = "123";
            clsOperateur.OP_ACTIF = "O";
            clsOperateur.OP_JOURNEEOUVERTE = "O";
            clsOperateur.PO_CODEPROFIL = "02";
            clsOperateur.OP_TELEPHONE = "00-00-00-00";
            if (clsObjetEnvoi.OE_A.Length == 4)
                clsOperateur.OP_EMAIL = "bilan00" + clsObjetEnvoi.OE_A + "@gmail.com";
            if (clsObjetEnvoi.OE_A.Length == 5)
                clsOperateur.OP_EMAIL = "bilan0" + clsObjetEnvoi.OE_A + "@gmail.com";
            clsOperateur.OP_DATESAISIE = clsObjetEnvoi.OE_J;
            return clsOperateur;
        }
    }
}
