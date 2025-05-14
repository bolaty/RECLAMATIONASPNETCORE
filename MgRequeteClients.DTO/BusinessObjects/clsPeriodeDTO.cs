using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsPeriodeDTO
    {
        #region VARIABLES LOCALES

        private string _MO_CODEMOIS = "";
        private string _MO_LIBELLE = "";
        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";
        private string _SL_CODEMESSAGE = "";

        #endregion

        #region ACCESSEURS

        public string MO_CODEMOIS
        {
            get { return _MO_CODEMOIS; }
            set { _MO_CODEMOIS = value; }
        }

        public string MO_LIBELLE
        {
            get { return _MO_LIBELLE; }
            set { _MO_LIBELLE = value; }
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

        public clsPeriodeDTO() { }

        public clsPeriodeDTO(clsPeriodeDTO clsPeriodeDTO)
        {
            this.MO_CODEMOIS = clsPeriodeDTO.MO_CODEMOIS;
            this.MO_LIBELLE = clsPeriodeDTO.MO_LIBELLE;
            SL_RESULTAT = clsPeriodeDTO.SL_RESULTAT;
            SL_MESSAGE = clsPeriodeDTO.SL_MESSAGE;
            SL_CODEMESSAGE = clsPeriodeDTO.SL_CODEMESSAGE;
        }

        #endregion

    }
}
