using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.Common.Base;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsAgence : clsEntitieBase
    {
        private string _SO_CODESOCIETE = "";
        private string _AG_CODEAGENCE = "";
        private string _AG_AGENCECODE = "";
        private string _PY_CODEPAYS = "";
        private string _VL_CODEVILLE = "";
        private string _ZN_CODEZONE = "";
        private string _AG_RAISONSOCIAL = "";
        private string _AG_BOITEPOSTAL = "";
        private string _AG_ADRESSEGEOGRAPHIQUE = "";
        private string _AG_TELEPHONE = "";
        private string _AG_FAX = "";
        private string _AG_EMAIL = "";
        private string _AG_NUMEROAGREMENT = "";
        private string _AG_REFERENCE = "N";
        private string _AG_DATECREATION = "01/01/1900";
        private string _AG_ACTIF = "O";
        private string _OP_CODEOPERATEUR = "";
        private string _DY_CODEDOCUMENT = "";

        private string _AG_RAISONSOCIALABREGEPOURSMS = "";
        private string _AG_EMAILMOTDEPASSE = "";
        private string _AG_NUMEROCOMPTE = "";
        private string _AG_CINETSITEID = "";
        private string _AG_CINETAPIKEY = "";
        private string _AG_CINETAPIPWD = "";
        private string _AG_CINETURLNOTIFICATIONZENITH = "";
        private string _AG_CINETURLNOTIFICATIONTONTINE = "";
        private string _AG_URLINTOUCHCASHIN = "";
        private string _AG_URLINTOUCHCASHOUT = "";
        private string _AG_TOKENTOUCHLOGIN = "";
        private string _AG_TOKENTOUCHPWD = "";
        private string _AG_RAISONSOCIAL_TRANSLATE = "";

        private string _EX_EXERCICE = "";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;
        public string AG_RAISONSOCIAL_TRANSLATE
        {
            get { return _AG_RAISONSOCIAL_TRANSLATE; }
            set { _AG_RAISONSOCIAL_TRANSLATE = value; }
        }
        public clsResultat clsResultat
        {
            get { return _clsResultat; }
            set { _clsResultat = value; }
        }
        public clsObjetEnvoi clsObjetEnvoi
        {
            get { return _clsObjetEnvoi; }
            set { _clsObjetEnvoi = value; }
        }

        public string EX_EXERCICE
        {
            get { return _EX_EXERCICE; }
            set { _EX_EXERCICE = value; }
        }


        public string AG_RAISONSOCIALABREGEPOURSMS
        {
            get { return _AG_RAISONSOCIALABREGEPOURSMS; }
            set { _AG_RAISONSOCIALABREGEPOURSMS = value; }
        }
        public string AG_EMAILMOTDEPASSE
        {
            get { return _AG_EMAILMOTDEPASSE; }
            set { _AG_EMAILMOTDEPASSE = value; }
        }
        public string AG_NUMEROCOMPTE
        {
            get { return _AG_NUMEROCOMPTE; }
            set { _AG_NUMEROCOMPTE = value; }
        }
        public string AG_CINETSITEID
        {
            get { return _AG_CINETSITEID; }
            set { _AG_CINETSITEID = value; }
        }
        public string AG_CINETAPIKEY
        {
            get { return _AG_CINETAPIKEY; }
            set { _AG_CINETAPIKEY = value; }
        }
        public string AG_CINETAPIPWD
        {
            get { return _AG_CINETAPIPWD; }
            set { _AG_CINETAPIPWD = value; }
        }
        public string AG_CINETURLNOTIFICATIONZENITH
        {
            get { return _AG_CINETURLNOTIFICATIONZENITH; }
            set { _AG_CINETURLNOTIFICATIONZENITH = value; }
        }
        public string AG_CINETURLNOTIFICATIONTONTINE
        {
            get { return _AG_CINETURLNOTIFICATIONTONTINE; }
            set { _AG_CINETURLNOTIFICATIONTONTINE = value; }
        }
        public string AG_URLINTOUCHCASHIN
        {
            get { return _AG_URLINTOUCHCASHIN; }
            set { _AG_URLINTOUCHCASHIN = value; }
        }
        public string AG_URLINTOUCHCASHOUT
        {
            get { return _AG_URLINTOUCHCASHOUT; }
            set { _AG_URLINTOUCHCASHOUT = value; }
        }
        public string AG_TOKENTOUCHLOGIN
        {
            get { return _AG_TOKENTOUCHLOGIN; }
            set { _AG_TOKENTOUCHLOGIN = value; }
        }
        public string AG_TOKENTOUCHPWD
        {
            get { return _AG_TOKENTOUCHPWD; }
            set { _AG_TOKENTOUCHPWD = value; }
        }


        public string DY_CODEDOCUMENT
        {
            get { return _DY_CODEDOCUMENT; }
            set { _DY_CODEDOCUMENT = value; }
        }

        public string SO_CODESOCIETE
        {
            get { return _SO_CODESOCIETE; }
            set { _SO_CODESOCIETE = value; }
        }
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
        public string AG_AGENCECODE
        {
            get { return _AG_AGENCECODE; }
            set { _AG_AGENCECODE = value; }
        }
        public string PY_CODEPAYS
        {
            get { return _PY_CODEPAYS; }
            set { _PY_CODEPAYS = value; }
        }
        public string VL_CODEVILLE
        {
            get { return _VL_CODEVILLE; }
            set { _VL_CODEVILLE = value; }
        }
        public string ZN_CODEZONE
        {
            get { return _ZN_CODEZONE; }
            set { _ZN_CODEZONE = value; }
        }
        public string AG_RAISONSOCIAL
        {
            get { return _AG_RAISONSOCIAL; }
            set { _AG_RAISONSOCIAL = value; }
        }
        public string AG_BOITEPOSTAL
        {
            get { return _AG_BOITEPOSTAL; }
            set { _AG_BOITEPOSTAL = value; }
        }
        public string AG_ADRESSEGEOGRAPHIQUE
        {
            get { return _AG_ADRESSEGEOGRAPHIQUE; }
            set { _AG_ADRESSEGEOGRAPHIQUE = value; }
        }
        public string AG_TELEPHONE
        {
            get { return _AG_TELEPHONE; }
            set { _AG_TELEPHONE = value; }
        }
        public string AG_FAX
        {
            get { return _AG_FAX; }
            set { _AG_FAX = value; }
        }
        public string AG_EMAIL
        {
            get { return _AG_EMAIL; }
            set { _AG_EMAIL = value; }
        }
        public string AG_NUMEROAGREMENT
        {
            get { return _AG_NUMEROAGREMENT; }
            set { _AG_NUMEROAGREMENT = value; }
        }
        public string AG_REFERENCE
        {
            get { return _AG_REFERENCE; }
            set { _AG_REFERENCE = value; }
        }
        public string AG_DATECREATION
        {
            get { return _AG_DATECREATION; }
            set { _AG_DATECREATION = value; }
        }
        public string AG_ACTIF
        {
            get { return _AG_ACTIF; }
            set { _AG_ACTIF = value; }
        }
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }



        public clsAgence() { }

        public clsAgence(string SO_CODESOCIETE, string AG_CODEAGENCE, string AG_AGENCECODE, string _PY_CODEPAYS, string VL_CODEVILLE, string ZN_CODEZONE, string AG_RAISONSOCIAL, string AG_BOITEPOSTAL, string AG_ADRESSEGEOGRAPHIQUE, string AG_TELEPHONE, string AG_FAX, string AG_EMAIL, string AG_NUMEROAGREMENT, string AG_REFERENCE, string AG_DATECREATION, string AG_ACTIF, string OP_CODEOPERATEUR, string DY_CODEDOCUMENT, string AG_RAISONSOCIALABREGEPOURSMS, string AG_EMAILMOTDEPASSE, string AG_NUMEROCOMPTE, string AG_CINETSITEID, string AG_CINETAPIKEY, string AG_CINETAPIPWD, string AG_CINETURLNOTIFICATIONZENITH, string AG_CINETURLNOTIFICATIONTONTINE, string AG_URLINTOUCHCASHIN, string AG_URLINTOUCHCASHOUT, string AG_TOKENTOUCHLOGIN, string AG_TOKENTOUCHPWD, string EX_EXERCICE)
        {
            this.SO_CODESOCIETE = SO_CODESOCIETE;
            this.AG_CODEAGENCE = AG_CODEAGENCE;
            this.AG_AGENCECODE = AG_AGENCECODE;
            this._PY_CODEPAYS = _PY_CODEPAYS;
            this.VL_CODEVILLE = VL_CODEVILLE;
            this.ZN_CODEZONE = ZN_CODEZONE;
            this.AG_RAISONSOCIAL = AG_RAISONSOCIAL;
            this.AG_BOITEPOSTAL = AG_BOITEPOSTAL;
            this.AG_ADRESSEGEOGRAPHIQUE = AG_ADRESSEGEOGRAPHIQUE;
            this.AG_TELEPHONE = AG_TELEPHONE;
            this.AG_FAX = AG_FAX;
            this.AG_EMAIL = AG_EMAIL;
            this.AG_NUMEROAGREMENT = AG_NUMEROAGREMENT;
            this.AG_REFERENCE = AG_REFERENCE;
            this.AG_DATECREATION = AG_DATECREATION;
            this.AG_ACTIF = AG_ACTIF;
            this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
            this.DY_CODEDOCUMENT = DY_CODEDOCUMENT;

            this.AG_RAISONSOCIALABREGEPOURSMS = AG_RAISONSOCIALABREGEPOURSMS;
            this.AG_EMAILMOTDEPASSE = AG_EMAILMOTDEPASSE;
            this.AG_NUMEROCOMPTE = AG_NUMEROCOMPTE;
            this.AG_CINETSITEID = AG_CINETSITEID;
            this.AG_CINETAPIKEY = AG_CINETAPIKEY;
            this.AG_CINETAPIPWD = AG_CINETAPIPWD;
            this.AG_CINETURLNOTIFICATIONZENITH = AG_CINETURLNOTIFICATIONZENITH;
            this.AG_CINETURLNOTIFICATIONTONTINE = AG_CINETURLNOTIFICATIONTONTINE;
            this.AG_URLINTOUCHCASHIN = AG_URLINTOUCHCASHIN;
            this.AG_URLINTOUCHCASHOUT = AG_URLINTOUCHCASHOUT;
            this.AG_TOKENTOUCHLOGIN = AG_TOKENTOUCHLOGIN;
            this.AG_TOKENTOUCHPWD = AG_TOKENTOUCHPWD;

            this.EX_EXERCICE = EX_EXERCICE;
        }

        public clsAgence(clsAgence clsAgence)
        {
            SO_CODESOCIETE = clsAgence.SO_CODESOCIETE;
            AG_CODEAGENCE = clsAgence.AG_CODEAGENCE;
            AG_AGENCECODE = clsAgence.AG_AGENCECODE;
            _PY_CODEPAYS = clsAgence._PY_CODEPAYS;
            VL_CODEVILLE = clsAgence.VL_CODEVILLE;
            ZN_CODEZONE = clsAgence.ZN_CODEZONE;
            AG_RAISONSOCIAL = clsAgence.AG_RAISONSOCIAL;
            AG_BOITEPOSTAL = clsAgence.AG_BOITEPOSTAL;
            AG_ADRESSEGEOGRAPHIQUE = clsAgence.AG_ADRESSEGEOGRAPHIQUE;
            AG_TELEPHONE = clsAgence.AG_TELEPHONE;
            AG_FAX = clsAgence.AG_FAX;
            AG_EMAIL = clsAgence.AG_EMAIL;
            AG_NUMEROAGREMENT = clsAgence.AG_NUMEROAGREMENT;
            AG_REFERENCE = clsAgence.AG_REFERENCE;
            AG_DATECREATION = clsAgence.AG_DATECREATION;
            AG_ACTIF = clsAgence.AG_ACTIF;
            OP_CODEOPERATEUR = clsAgence.OP_CODEOPERATEUR;
            DY_CODEDOCUMENT = clsAgence.DY_CODEDOCUMENT;

            AG_RAISONSOCIALABREGEPOURSMS = clsAgence.AG_RAISONSOCIALABREGEPOURSMS;
            AG_EMAILMOTDEPASSE = clsAgence.AG_EMAILMOTDEPASSE;
            AG_NUMEROCOMPTE = clsAgence.AG_NUMEROCOMPTE;
            AG_CINETSITEID = clsAgence.AG_CINETSITEID;
            AG_CINETAPIKEY = clsAgence.AG_CINETAPIKEY;
            AG_CINETAPIPWD = clsAgence.AG_CINETAPIPWD;
            AG_CINETURLNOTIFICATIONZENITH = clsAgence.AG_CINETURLNOTIFICATIONZENITH;
            AG_CINETURLNOTIFICATIONTONTINE = clsAgence.AG_CINETURLNOTIFICATIONTONTINE;
            AG_URLINTOUCHCASHIN = clsAgence.AG_URLINTOUCHCASHIN;
            AG_URLINTOUCHCASHOUT = clsAgence.AG_URLINTOUCHCASHOUT;
            AG_TOKENTOUCHLOGIN = clsAgence.AG_TOKENTOUCHLOGIN;
            AG_TOKENTOUCHPWD = clsAgence.AG_TOKENTOUCHPWD;

            EX_EXERCICE = clsAgence.EX_EXERCICE;
            this.AG_RAISONSOCIAL_TRANSLATE = clsAgence.AG_RAISONSOCIAL_TRANSLATE;
            this.clsResultat = clsAgence.clsResultat;
            this.clsObjetEnvoi = clsAgence.clsObjetEnvoi;
        }
    }
}
