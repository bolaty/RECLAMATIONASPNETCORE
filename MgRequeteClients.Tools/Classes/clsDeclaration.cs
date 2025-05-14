using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MgRequeteClients.Tools.Classes
{
    public class clsDeclaration
    {
        #region  declaration unique de la classe

        //declaration unique de la classe clsDeclaration pour tout le projet
        private readonly static clsDeclaration ClassesDeclaration = new clsDeclaration();
        public static string URL_ROOT_ADRESSE_API_SMS = string.Empty;
        public static string URL_ADRESSE_API_SMS = string.Empty;
        //constructeur privé de la classe clsDeclaration
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsDeclaration()
        {
        }
        //constructeur public de la classe fonction 

        public static clsDeclaration ClasseDeclaration
        {
            get { return ClassesDeclaration; }
        }

        public static void InitialiserConfiguration(IConfiguration configuration)
        {
            // Lecture de l'URL de l'API SMS depuis appsettings.json
            URL_ROOT_ADRESSE_API_SMS = configuration.GetSection("ApiEndpoints:SmsApi").Value ?? string.Empty;

            // Tu peux construire ensuite tes URL dynamiques ici
            URL_ADRESSE_API_SMS = URL_ROOT_ADRESSE_API_SMS + "Service/wsApisms.svc/SendMessage";
        }

        #endregion

       


        #region CONSTANTE
        public const string LANG_FRENCH = "FR";
        public const string LANG_ENGLISH = "EN";
        public const string ZOOM = "100";
        public const int TIMEOUT = 90000;
        public static string PATHLOGGER = "";
        public static string PATHFICHIER = "";
        #endregion
        public string MESSAGERETOURS = "";


        public struct SObjetEnvoi
        {
            public string SO_CODESOCIETE;
            public string AG_CODEAGENCE;
            public string ZN_CODEZONE;
            public string OP_CODEOPERATEUR;
            public string OP_LOGIN;
            public string DBUSER;
            public string CODEDECRYPTAGE;
            public string DERNIEREXERCICE;//Dernier exercice de l'agence sélectionné.
            public bool PREMIEREEXECUTION;//variable globale pour savoir si c'est la premiere execution du logiciel 
            public string AGENCEREFERENCE;//O=Direction générale,Z=Coordination,N=Agence simple,variable globale pour savoir si c'est l'agence de reference(direction générale) de la societe
            public DateTime JT_DATEJOURNEETRAVAIL;//Elle correspond a la date qui est définit pour travailler dans le system
            public DateTime JT_DATESYSTEMSERVEURDEMARRAGE;//Elle correspond a la date système du serveur validée au démmarrage du logiciel
            public string PARAMETRES;
            public bool POINTVENTE;
        }
        public static SObjetEnvoi vagObjetEnvoi;




    }
}
