using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgRequeteClients.Common.Base;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsEnvoiEmail
    {
        private string _EE_NOM = "";
        private string _EE_PRENOMS = "";
        private string _EE_EMAIL = "";
        private string _EE_NUMTELEPHONE = "";
        private string _EE_NUMCOMPTE = "";
        private string _EE_OBSERVATION = "";
        private string _EE_DATEEMISSION = "";

        private string _SL_CODEMESSAGE = "";
        private string _SL_MESSAGE = "";
        private string _SL_RESULTAT = "";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        public string EE_NOM
        {
            get { return _EE_NOM; }
            set { _EE_NOM = value; }
        }
        public string EE_PRENOMS
        {
            get { return _EE_PRENOMS; }
            set { _EE_PRENOMS = value; }
        }
        public string EE_EMAIL
        {
            get { return _EE_EMAIL; }
            set { _EE_EMAIL = value; }
        }
        public string EE_NUMTELEPHONE
        {
            get { return _EE_NUMTELEPHONE; }
            set { _EE_NUMTELEPHONE = value; }
        }
        public string EE_NUMCOMPTE
        {
            get { return _EE_NUMCOMPTE; }
            set { _EE_NUMCOMPTE = value; }
        }
        public string EE_OBSERVATION
        {
            get { return _EE_OBSERVATION; }
            set { _EE_OBSERVATION = value; }
        }
        public string EE_DATEEMISSION
        {
            get { return _EE_DATEEMISSION; }
            set { _EE_DATEEMISSION = value; }
        }


        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
        }

        public string SL_MESSAGE
        {
            get { return _SL_MESSAGE; }
            set { _SL_MESSAGE = value; }
        }


        public string SL_RESULTAT
        {
            get { return _SL_RESULTAT; }
            set { _SL_RESULTAT = value; }
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

        public clsEnvoiEmail() { }


        public clsEnvoiEmail(clsEnvoiEmail clsEnvoiEmail)
        {
            this.EE_NOM = clsEnvoiEmail.EE_NOM;
            this.EE_PRENOMS = clsEnvoiEmail.EE_PRENOMS;
            this.EE_EMAIL = clsEnvoiEmail.EE_EMAIL;
            this.EE_NUMTELEPHONE = clsEnvoiEmail.EE_NUMTELEPHONE;
            this.EE_NUMCOMPTE = clsEnvoiEmail.EE_NUMCOMPTE;
            this.EE_OBSERVATION = clsEnvoiEmail.EE_OBSERVATION;
            this.EE_DATEEMISSION = clsEnvoiEmail.EE_DATEEMISSION;

            this.SL_CODEMESSAGE = clsEnvoiEmail.SL_CODEMESSAGE;
            this.SL_MESSAGE = clsEnvoiEmail.SL_MESSAGE;
            this.SL_RESULTAT = clsEnvoiEmail.SL_RESULTAT;

            this.clsResultat = clsEnvoiEmail.clsResultat;
            this.clsObjetEnvoi = clsEnvoiEmail.clsObjetEnvoi;
        }
    }
}
