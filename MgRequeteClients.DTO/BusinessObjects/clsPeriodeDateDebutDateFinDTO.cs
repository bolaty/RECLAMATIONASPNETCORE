using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsPeriodeDateDebutDateFinDTO
    {
        #region VARIABLES LOCALES

        private string _MO_DATEDEBUT = "";
        private string _MO_DATEFIN = "";
        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";
        private string _SL_CODEMESSAGE = "";

        #endregion

        #region ACCESSEURS

        public string MO_DATEDEBUT
        {
            get { return _MO_DATEDEBUT; }
            set { _MO_DATEDEBUT = value; }
        }

        public string MO_DATEFIN
        {
            get { return _MO_DATEFIN; }
            set { _MO_DATEFIN = value; }
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

        public clsPeriodeDateDebutDateFinDTO() { }

        public clsPeriodeDateDebutDateFinDTO(clsPeriodeDateDebutDateFinDTO clsPeriodeDateDebutDateFinDTO)
        {
            this.MO_DATEDEBUT = clsPeriodeDateDebutDateFinDTO.MO_DATEDEBUT;
            this.MO_DATEFIN = clsPeriodeDateDebutDateFinDTO.MO_DATEFIN;
            SL_RESULTAT = clsPeriodeDateDebutDateFinDTO.SL_RESULTAT;
            SL_MESSAGE = clsPeriodeDateDebutDateFinDTO.SL_MESSAGE;
            SL_CODEMESSAGE = clsPeriodeDateDebutDateFinDTO.SL_CODEMESSAGE;
        }

        #endregion
    }
}
