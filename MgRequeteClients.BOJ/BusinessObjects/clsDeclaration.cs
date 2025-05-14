using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsDeclaration
    {
        #region MESSAGE RESULTATS
        public const string ERROR_RESULTAT = "FALSE";
        public const string SUCCESS_RESULTAT = "TRUE";

        public const bool ERROR_RESULTAT_BOOL = false;
        public const bool SUCCESS_RESULTAT_BOOL = true;
        #endregion

        #region MESSAGE
        public const string MSG_LIBELLE_ECRAN_VIDE = "Le libellé de l'écran est obligatoire !!!";
        public const string MSG_LIBELLE_MOUCHARD_VIDE = "Le libellé du mouchard est obligatoire !!!";
        public const string TOKKEN_NULL = "Veuillez vous authentifier avec votre clé token.";
        public const string WS_NON_AUTORISE_COMPTE_INNEXISTANT = "Vous n'êtes pas autorisé à utiliser ce services web. Votre compte est innexistant.";
        public const string STATUT_VALIDE = "O";
        public const string WS_AUTORISE = "Vous êtes autorisé à utiliser ce services web.";
        public const string WS_NON_AUTORISE_COMPTE_INNACTIF = "Vous n'êtes pas autorisé à utiliser ce services web. Votre compte est désactivé.";
        public const string MSG_LIBELLE_SAISIE_OBLIGATOIRE = "Saisie obligatoire !!!";
        public const string MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE = "Opération effectuée avec succès !!!";
        public const string MSG_LIBELLE_AUCUN_ELT_TROUVE = "Aucun élément trouvé !!!";
        public const string MSG_LIBELLE_TYPE_OPERATION_INCORRECT = "Type opération incorrect !!!";
        public const string MSG_LIBELLE_LOGIN_OU_MOT_DE_PASSE_INVALIDE = "Login ou mot de passe invalide !!!";
        public const string MSG_LIBELLE_OPERATION_NON_EFFECTUEE = "Operation non effectuee !!!";
        public const string MSG_LIBELLE_DONNEE_EN_UTILISATION = "Donnée en utilisation !!!";
        #endregion

        #region CODE ERREUR
        public const string CODE_ERROR_SAISIE_OBLIG = "GNE0001";
        public const string CODE_ERROR_SQLEx = "GNE0003";
        public const string CODE_SUCCESS = "SUCCESS";
        public const string CODE_TYPE_OP_REQUIS = "GNE0280";
        public const string CODE_LIBELLE_REQUIS = "GNE0281";
        public const string CODE_AGENCE_REQUISE = "GNE0283";
        public const string CODE_CODE_REQUIS = "GNE0284";
        public const string CODE_OE_Y_REQUIS = "GNE0284";
        // public const string CODE_
        #endregion
        //ST0001
        #region VALEURS PAR DEFAUT

        public const string DATE_PAR_DEFAUT = "01-01-1900";
        public const string HEURE_PAR_DEFAUT = "00:00:00";
        public const string LIBELLE_DEFAULT = "OK";
        public const string LIBELLE_MOUCHARD_INTERDIT_1 = "OUI";
        public const string LIBELLE_MOUCHARD_INTERDIT_2 = "NON";
        public const int LIBELLE_MOUCHARD_MAX_LENGTH = 10;
        public const int LIBELLE_ECRAN_MAX_LENGTH = 5;

        #endregion
    }
}
