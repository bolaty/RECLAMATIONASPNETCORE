using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsObjetEnvoi
    {
        private string _OE_A = "";// CODE AGENCE
        private string _OE_O = "";// CODE SOCIETE
        private string _OE_D = "";// CODE DE CRYPTAGE
        private string _OE_X = "";// UTILISATEUR de la base de données sur le serveur
        private string _OE_Y = "";// OPERATEUR,utile pour le mouchard et le test de la cloture d'une caisse de façon spécifique sans fermer la journée de travail
        private string _OE_U = "";// LOGIN OPERATEUR EN COURS

        private string _OE_M = "";//Facultatif,Correspond à la variable qui permet d'envoyer un code de message au serveur,afin qu'il envoi un message d'érreur que nous souhaitons nous même
        private bool _OE_Z = false;//Facultatif,Correspond à la variable qui permet de savoir si c'est
                                   //la première execution du logiciel ou non
        private string _OE_R = "N";//O=Direction générale,Z=Coordination,N=Agence simple,variable globale pour savoir si c'est l'agence de reference(direction générale) de la societe,ou si il s'agit d'une coordination ou d'une agence simple.
                                   //O=Charge toutes les agences,Z=Charges la liste des agence uniquement de la coordination,N=Charge la seule agence elle même.
        private string _OE_E = "";//Le code zone de l'agence sélectioné
        private DateTime _OE_J = DateTime.Parse("01/01/1900");//Facultatif,La date de la journée de travail
        private DateTime _OE_S = DateTime.Parse("01/01/1900");//Facultatif,La date système
        private string _OE_F = "";//Facultatif,l'écran qui exécute la procedure en cours,utiliser dans:démmarrage du bilan,affectation resultat...etc.
        private DateTime _OE_G = DateTime.Parse("01/01/1900");//Date de démmarrage du bilan de l'exercice en cours
        private DateTime _OE_H = DateTime.Parse("01/01/1900");//Date d'affectation du résultat du bilan de l'exercice en cours

        private string _OE_Q = "";// Facultatif,Le dernier exercice de l'agence
        private string _OE_T = "";// Le statut de cloture de l'exercice en cours

        //Facultatif,veut dire que cette variable ne doit pas être dans la macro,mais utilisé au cas par cas
        //car c'est quand on en a besoin qu'on se rend compte de cela.

        private string[] _OE_PARAM = new string[] { "" };

        /// <summary>
        /// CODE AGENCE
        /// </summary>
        public string OE_A
        {
            get { return _OE_A; }
            set { _OE_A = value; }
        }
        /// <summary>
        /// CODE SOCIETE
        /// </summary>
        public string OE_O
        {
            get { return _OE_O; }
            set { _OE_O = value; }
        }
        /// <summary>
        /// CODE DE CRYPTAGE
        /// </summary>
        public string OE_D
        {
            get { return _OE_D; }
            set { _OE_D = value; }
        }

        /// <summary>
        /// UTILISATEUR
        /// </summary>
        public string OE_X
        {
            get { return _OE_X; }
            set { _OE_X = value; }
        }
        /// <summary>
        /// OPERATEUR
        /// </summary>
        public string OE_Y
        {
            get { return _OE_Y; }
            set { _OE_Y = value; }
        }
        /// <summary>
        /// LOGIN
        /// </summary>
        public string OE_U
        {
            get { return _OE_U; }
            set { _OE_U = value; }
        }
        /// <summary>
        /// CODE MESSAGE
        /// </summary>
        public string OE_M
        {
            get { return _OE_M; }
            set { _OE_M = value; }
        }
        /// <summary>
        /// PREMIERE EXECUTION DU LOGICIEL
        /// </summary>
        public bool OE_Z
        {
            get { return _OE_Z; }
            set { _OE_Z = value; }
        }
        /// <summary>
        /// AGENCE DE REFERENCE
        /// </summary>
        public string OE_R
        {
            get { return _OE_R; }
            set { _OE_R = value; }
        }

        /// <summary>
        /// Code zone de l'agence selectionné
        /// </summary>
        public string OE_E
        {
            get { return _OE_E; }
            set { _OE_E = value; }
        }
        /// <summary>
        /// La date de la journée de travail
        /// </summary>
        public DateTime OE_J
        {
            get { return _OE_J; }
            set { _OE_J = value; }
        }
        /// <summary>
        /// La date système du serveur
        /// </summary>
        public DateTime OE_S
        {
            get { return _OE_S; }
            set { _OE_S = value; }
        }

        /// <summary>
        /// Le dernier exercice de l'agence
        /// </summary>
        public string OE_Q
        {
            get { return _OE_Q; }
            set { _OE_Q = value; }
        }

        /// <summary>
        /// Le statut de l'exercice en cours
        /// </summary>
        public string OE_T
        {
            get { return _OE_T; }
            set { _OE_T = value; }
        }

        //private string _OE_F = "";//Facultatif,l'écran qui exécute la procedure en cours,utiliser dans:démmarrage du bilan,affectation resultat...etc.
        //private DateTime _OE_G = DateTime.Parse("01/01/1900");//Date de démmarrage du bilan de l'exercice en cours
        //private DateTime _OE_H = DateTime.Parse("01/01/1900");//Date d'affectation du résultat du bilan de l'exercice en cours

        /// <summary>
        /// L'écran en cours
        /// </summary>
        public string OE_F
        {
            get { return _OE_F; }
            set { _OE_F = value; }
        }
        /// <summary>
        /// Date de démmarrage du bilan de l'exercice en cours
        /// </summary>
        public DateTime OE_G
        {
            get { return _OE_G; }
            set { _OE_G = value; }
        }
        /// <summary>
        /// Date d'affectation du résultat du bilan de l'exercice en cours
        /// </summary>
        public DateTime OE_H
        {
            get { return _OE_H; }
            set { _OE_H = value; }
        }


        /// <summary>
        /// PARAMETRES
        /// </summary>
        public string[] OE_PARAM
        {
            get { return _OE_PARAM; }
            set { _OE_PARAM = value; }
        }

        public clsObjetEnvoi() { }

        public clsObjetEnvoi(string OE_A, string OE_O, string OE_D, string OE_X,
            string OE_Y, string OE_U, string OE_M, bool OE_Z, string OE_R, string OE_E, string OE_Q, string OE_T,
            string OE_F, DateTime OE_G, DateTime OE_H,
            DateTime OE_J, DateTime OE_S, string[] OE_PARAM)
        {
            this.OE_PARAM = OE_PARAM;
            this.OE_A = OE_A;
            this.OE_O = OE_O;
            this.OE_D = OE_D;
            this.OE_X = OE_X;
            this.OE_Y = OE_Y;
            this.OE_U = OE_U;
            this.OE_D = OE_M;
            this.OE_Z = OE_Z;
            this.OE_R = OE_R;
            this.OE_E = OE_E;
            this.OE_J = OE_J;
            this.OE_S = OE_S;
            this.OE_Q = OE_Q;
            this.OE_T = OE_T;

            this.OE_F = OE_F;
            this.OE_G = OE_G;
            this.OE_H = OE_H;


        }

        public clsObjetEnvoi(clsObjetEnvoi clsObjetEnvoi)
        {
            OE_PARAM = clsObjetEnvoi.OE_PARAM;
            OE_A = clsObjetEnvoi.OE_A;
            OE_O = clsObjetEnvoi.OE_O;
            OE_D = clsObjetEnvoi.OE_D;
            OE_X = clsObjetEnvoi.OE_X;
            OE_Y = clsObjetEnvoi.OE_Y;
            OE_U = clsObjetEnvoi.OE_U;
            OE_M = clsObjetEnvoi.OE_M;
            OE_Z = clsObjetEnvoi.OE_Z;
            OE_R = clsObjetEnvoi.OE_R;
            OE_E = clsObjetEnvoi.OE_E;
            OE_Q = clsObjetEnvoi.OE_Q;
            OE_J = clsObjetEnvoi.OE_J;
            OE_S = clsObjetEnvoi.OE_S;
            OE_T = clsObjetEnvoi.OE_T;
            OE_F = clsObjetEnvoi.OE_F;
            OE_G = clsObjetEnvoi.OE_G;
            OE_H = clsObjetEnvoi.OE_H;
        }

        public clsObjetEnvoi SetValue(string OE_A, string OE_O, string OE_D, string OE_X, string OE_Y, string OE_U,
            bool OE_Z, string OE_R, string OE_E, string OE_Q, string OE_T, string OE_F, DateTime OE_G, DateTime OE_H,
            DateTime OE_J, DateTime OE_S, string[] OE_PARAM)
        {
            this.OE_A = OE_A;
            this.OE_O = OE_O;
            this.OE_D = OE_D;
            this.OE_X = OE_X;
            this.OE_Y = OE_Y;
            this.OE_U = OE_U;
            this.OE_M = OE_M;
            this.OE_Z = OE_Z;
            this.OE_R = OE_R;
            this.OE_E = OE_E;
            this.OE_J = OE_J;
            this.OE_S = OE_S;
            this.OE_Q = OE_Q;
            this.OE_T = OE_T;

            this.OE_F = OE_F;
            this.OE_G = OE_G;
            this.OE_H = OE_H;
            this.OE_PARAM = OE_PARAM;
            return this;
        }
    }
}
