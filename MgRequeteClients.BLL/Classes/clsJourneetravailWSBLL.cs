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
    public class clsJourneetravailWSBLL : IObjetWSBLL<clsJourneetravail>
    {

        private clsJourneetravailWSDAL clsJourneetravailWSDAL = new clsJourneetravailWSDAL();
        private clsOperateurWSDAL clsOperateurWSDAL = new clsOperateurWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count,avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsJourneetravailWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type count,avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteCount1(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsJourneetravailWSDAL.pvgValueScalarRequeteCount1(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requète scalaire de type count,avec des critères(Ordre critere:OP_CODEOPERATEUR,CP_NOMFEUILLE,CP_NOMCOMMANDE)</summary>
        ///<param name="vppCritere">critères de la requète scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgValeurScalaireRequeteCountold(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            MgRequeteClients.Tools.Classes.clsDeclaration.ClasseDeclaration.MESSAGERETOURS = "";
            //Code agence////Date journée de travail//Statut de la journée de travail
            string vlpResultat = clsJourneetravailWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_A, clsObjetEnvoi.OE_J.ToShortDateString(), "O");

            //Si la journée est encore ouverte
            if (vlpResultat != "0")
            {
                //On doit verifier si la journée est fermée pour un caissier,si c'est un caissier qui éffectue cette opération.
                //Recupération du statut de OP_JOURNEEOUVERTE de l'opérateur
                clsOperateur clsOperateur = new clsOperateur(clsOperateurWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_A, clsObjetEnvoi.OE_Y));
                //Si la journée est encore ouverte et que la journée est fermée pour un opérateur caissier en cours,
                //alors on considère que la journée est globalement fermée pour ce opérateur(vlpResultat = "0"),même si la journée est ouverte.
                if (clsOperateur.OP_JOURNEEOUVERTE == "N" && clsOperateur.OP_CAISSIER == "O") vlpResultat = "0";
                //Si la journée de travail est ouverte et que l'opérateur en cours est l'opérateur du bilan,alors il faut considerer qque la journée est
                //fermée,car l'opérateur du bilan ne peut travailler dans une journée fermée.
                if (clsObjetEnvoi.OE_U.Contains("BILAN") && clsObjetEnvoi.OE_J.ToShortDateString().Contains("31/12/"))
                    return "0";
            }

            //Si la journée en cours est fermée et est un 31/12/  et que l'opérateur en cours est l'opérateur du bilan,
            //et que le bilan a démmaré et que nous ne somme pas sur l'écran de démmarrage,
            //alors la journée peut être considéré comme ouverte même si elle est fermée.
            if (vlpResultat == "0" && clsObjetEnvoi.OE_J.ToShortDateString().Contains("31/12/"))
                if (clsObjetEnvoi.OE_U.Contains("BILAN"))
                {
                    if (clsObjetEnvoi.OE_G != DateTime.Parse("01/01/1900") && clsObjetEnvoi.OE_F != "FrmBilanDemarrage")
                        vlpResultat = "1";
                    //Si le bilan n'a pas encore été démmarré et que nous somme sur l'écran de démmarrage du bilan
                    //alors la journée peut être considéré comme ouverte même si elle est fermée.
                    if (clsObjetEnvoi.OE_G == DateTime.Parse("01/01/1900") && clsObjetEnvoi.OE_F == "FrmBilanDemarrage")
                        vlpResultat = "1";
                }

            //Si l'exercice est cloturée ,alors on a aucune possibilité pour travailler dans une journée de travail de l'exercice en question meme pour 
            //l'opérateur du bilan
            //if (clsObjetEnvoi.OE_T=="F") vlpResultat = "0";


            //Si l'exercice est cloturée ,alors on a aucune possibilité pour travailler dans une journée de travail de l'exercice en question meme pour 
            //l'opérateur du bilan
            if (clsObjetEnvoi.OE_T == "F")
            {
                vlpResultat = "0";
                MgRequeteClients.Tools.Classes.clsDeclaration.ClasseDeclaration.MESSAGERETOURS = " L'exercice est cloturé !!!";
            }

            return vlpResultat;
        }



        ///<summary>
        /// Cette fonction permet d'exécuter une requête scalaire de type count avec des critères 
        /// (Ordre critère : OP_CODEOPERATEUR, CP_NOMFEUILLE, CP_NOMCOMMANDE)
        ///</summary>
        ///<param name="clsDonnee">Objet contenant les informations de connexion</param>
        ///<param name="clsObjetEnvoi">Objet contenant les paramètres de la requête</param>
        ///<returns>Un string représentant le résultat de la requête</returns>
        ///<author>Home Technologie</author>
        public string pvgValeurScalaireRequeteCount2(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            MgRequeteClients.Tools.Classes.clsDeclaration.ClasseDeclaration.MESSAGERETOURS = "";

            // Vérification de l'exercice clôturé
            if (clsObjetEnvoi.OE_T == "F")
            {
                MgRequeteClients.Tools.Classes.clsDeclaration.ClasseDeclaration.MESSAGERETOURS = "L'exercice est clôturé !!!";
                return "0";
            }

            // Récupération du statut de la journée de travail
            string vlpResultat = clsJourneetravailWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_A, clsObjetEnvoi.OE_J.ToShortDateString(), "O");

            // Récupération des informations de l'opérateur
            clsOperateur clsOperateur = new clsOperateur(clsOperateurWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_A, clsObjetEnvoi.OE_Y));

            // Gestion spécifique pour l'opérateur bilan
            bool isBilan = clsObjetEnvoi.OE_U.Contains("BILAN");
            bool isJournee31Decembre = clsObjetEnvoi.OE_J.ToShortDateString().Contains("31/12/");

            if (isBilan)
            {
                // 1. Il ne doit pas travailler dans une journée ouverte
                if (vlpResultat != "0")
                {
                    MgRequeteClients.Tools.Classes.clsDeclaration.ClasseDeclaration.MESSAGERETOURS = "l'opérateur bilan ne doit pas travailler dans une journée ouverte !!!";
                    return "0";
                }

                // 2. Il ne doit pas travailler en dehors du 31/12/xxxx
                if (!isJournee31Decembre)
                {
                    MgRequeteClients.Tools.Classes.clsDeclaration.ClasseDeclaration.MESSAGERETOURS = "l'opérateur bilan ne doit pas travailler en dehors du 31/12/xxxx !!!";
                    return "0";
                }

                // 3. Il ne doit pas travailler tant que le bilan n'a pas démarré
                if (clsObjetEnvoi.OE_G == DateTime.Parse("01/01/1900") && clsObjetEnvoi.OE_F != "FrmBilanDemarrage")
                {
                    MgRequeteClients.Tools.Classes.clsDeclaration.ClasseDeclaration.MESSAGERETOURS = "l'opérateur bilan ne doit pas travailler tant que le bilan n'a pas démarré !!!";
                    return "0";
                }


                // 4. Si le bilan a démarré mais que nous sommes sur l'écran de démarrage, la journée peut être considérée comme ouverte
                if (clsObjetEnvoi.OE_G != DateTime.Parse("01/01/1900") && clsObjetEnvoi.OE_F == "FrmBilanDemarrage")
                    return "1";

                // 4. FIN TEST
                if (clsObjetEnvoi.OE_F == "" || clsObjetEnvoi.OE_F == "FrmBilanDemarrage")
                    return "1";
            }
            else
            {
                // 1. Il ne doit pas travailler dans une journée fermée
                if (vlpResultat == "0")
                {
                    MgRequeteClients.Tools.Classes.clsDeclaration.ClasseDeclaration.MESSAGERETOURS = "Opération impossible, Journée Fermée !!!";
                    return "0";
                }

                // Gestion pour les autres opérateurs (caissiers, etc.)
                if (clsOperateur.OP_JOURNEEOUVERTE == "N" && clsOperateur.OP_CAISSIER == "O")
                {
                    MgRequeteClients.Tools.Classes.clsDeclaration.ClasseDeclaration.MESSAGERETOURS = "Opération impossible, Journée Fermée !!!";
                    return "0";
                }
                // vlpResultat = "0";
            }

            return vlpResultat;
        }




        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min(sur un champs de la base),avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsJourneetravailWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base),avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsJourneetravailWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max(sur un champs de la base),avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
        public string pvgValueScalarRequeteMax1(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsJourneetravailWSDAL.pvgValueScalarRequeteMax1(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de retourner une ou plusieurs valeur de champs d'une table en fonction des criteres spécifiés(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">critères de la requête scalaire</param>
		///<returns>clsJourneetravail </returns>
		///<author>Home Technologie</author>
		public clsJourneetravail pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsJourneetravailWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsJourneetravail">clsJourneetravail</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsJourneetravail clsJourneetravail, clsObjetEnvoi clsObjetEnvoi)
        {
            clsJourneetravailWSDAL.pvgInsert(clsDonnee, clsJourneetravail);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsJourneetravail.JT_DATEJOURNEETRAVAIL.ToString(), "A"));
            return "";
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion multiple dans la base de donnees</summary>
		///<param name="clsDonnee"> Classe d'accès aux données</param>
		///<param name="clsJourneetravails">Collection de clsJourneetravail </param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsJourneetravail> clsJourneetravails, clsObjetEnvoi clsObjetEnvoi)
        {
            clsJourneetravailWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            for (int Idx = 0; Idx < clsJourneetravails.Count; Idx++)
            {
                clsJourneetravailWSDAL.pvgInsert(clsDonnee, clsJourneetravails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsJourneetravails[Idx].JT_DATEJOURNEETRAVAIL.ToString(), "A"));
            }
            return "";
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees,avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsJourneetravail">clsJourneetravail</param>
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgModifier(clsDonnee clsDonnee, clsJourneetravail clsJourneetravail, clsObjetEnvoi clsObjetEnvoi)
        {
            clsJourneetravailWSDAL.pvgUpdate(clsDonnee, clsJourneetravail, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsJourneetravail.JT_DATEJOURNEETRAVAIL.ToString(), "M"));
            return "";
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees,avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Les critères de suppression</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technologie</author>
		public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsJourneetravailWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            string vppValeurMouchard = clsObjetEnvoi.OE_PARAM.Length > 0 ? clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
            return "";
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsJourneetravail</returns>
		///<author>Home Technologie</author>
		public List<clsJourneetravail> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsJourneetravailWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees ,avec ou sans critères(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Chaine de la requête SELECT</param>
		///<returns>Collection de clsJourneetravail</returns>
		///<author>Home Technologie</author>
		public List<clsJourneetravail> pvgChargerAPartirDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsJourneetravailWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT)</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsJourneetravailWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees avec ou sans critères
		///(Ordre critere:JT_DATEJOURNEETRAVAIL,JT_STATUT) elle est destinée generalement aux combobox, treeview ...</summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param> 
		///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
		///<returns>DataSet</returns>
		///<author>Home Technologie</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsJourneetravailWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
                    clsMouchard.MO_ACTION = "JOURNEETRAVAIL  (Ajout)  : " + vppAction;
                    break;
                case "M":
                    clsMouchard.MO_ACTION = "JOURNEETRAVAIL  (Modification)  : " + vppAction;
                    break;
                case "S":
                    clsMouchard.MO_ACTION = "JOURNEETRAVAIL  (Suppression)  : " + vppAction;
                    break;
                case "E":
                    clsMouchard.MO_ACTION = "JOURNEETRAVAIL  (Edition de l'etatEdition de l'etat)  : " + vppAction;
                    break;
            }
            return clsMouchard;
        }



    }
}
