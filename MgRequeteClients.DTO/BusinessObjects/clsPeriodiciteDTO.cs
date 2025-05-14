using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsPeriodiciteDTO
    {
        #region VARIABLES LOCALES

        private string _PE_CODEPERIODICITE = "";
        private string _PE_ABREVIATION = "";
        private string _PE_LIBELLE = "";
        private string _PE_UNITE = "";
        private int _PE_PERIODICITE = 0;
        private int _PE_MULTIPLE = 0;
        private string _PE_PRODUCTIONETATFINANCIER = "";
        private string _PE_ACTIF = "";

        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";
        private string _SL_CODEMESSAGE = "";

        #endregion

        #region ACCESSEURS

        public string PE_CODEPERIODICITE
        {
            get { return _PE_CODEPERIODICITE; }
            set { _PE_CODEPERIODICITE = value; }
        }

        public string PE_ABREVIATION
        {
            get { return _PE_ABREVIATION; }
            set { _PE_ABREVIATION = value; }
        }

        public string PE_LIBELLE
        {
            get { return _PE_LIBELLE; }
            set { _PE_LIBELLE = value; }
        }
        public string PE_UNITE
        {
            get { return _PE_UNITE; }
            set { _PE_UNITE = value; }
        }
        public int PE_PERIODICITE
        {
            get { return _PE_PERIODICITE; }
            set { _PE_PERIODICITE = value; }
        }

        public int PE_MULTIPLE
        {
            get { return _PE_MULTIPLE; }
            set { _PE_MULTIPLE = value; }
        }
        public string PE_PRODUCTIONETATFINANCIER
        {
            get { return _PE_PRODUCTIONETATFINANCIER; }
            set { _PE_PRODUCTIONETATFINANCIER = value; }
        }

        public string PE_ACTIF
        {
            get { return _PE_ACTIF; }
            set { _PE_ACTIF = value; }
        }

        public string SL_RESULTAT
        {
            get { return _SL_RESULTAT; }
            set { _SL_RESULTAT = value; }
        }

        public string SL_MESSAGE
        {
            get { return _SL_MESSAGE; }
            set { _SL_MESSAGE = value; }
        }
        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
        }
        #endregion

        #region INSTANCIATEURS

        public clsPeriodiciteDTO() { }

        public clsPeriodiciteDTO(clsPeriodiciteDTO clsPeriodiciteDTO)
        {
            this.PE_CODEPERIODICITE = clsPeriodiciteDTO.PE_CODEPERIODICITE;
            this.PE_ABREVIATION = clsPeriodiciteDTO.PE_ABREVIATION;
            this.PE_LIBELLE = clsPeriodiciteDTO.PE_LIBELLE;
            this.PE_UNITE = clsPeriodiciteDTO.PE_UNITE;
            this.PE_PERIODICITE = clsPeriodiciteDTO.PE_PERIODICITE;
            this.PE_MULTIPLE = clsPeriodiciteDTO.PE_MULTIPLE;
            this.PE_PRODUCTIONETATFINANCIER = clsPeriodiciteDTO.PE_PRODUCTIONETATFINANCIER;
            this.PE_ACTIF = clsPeriodiciteDTO.PE_ACTIF;
            SL_RESULTAT = clsPeriodiciteDTO.SL_RESULTAT;
            SL_MESSAGE = clsPeriodiciteDTO.SL_MESSAGE;
            SL_CODEMESSAGE = clsPeriodiciteDTO.SL_CODEMESSAGE;
        }

        #endregion
    }
}
