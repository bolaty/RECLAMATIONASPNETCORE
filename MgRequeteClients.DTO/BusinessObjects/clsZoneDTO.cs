using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsZoneDTO
    {
        //ZN_CODEZONE,ZN_NOMZONE,SO_CODESOCIETE,ZN_DESCRIPTION

        private string _ZN_CODEZONE = "";
        private string _ZN_NOMZONE = "";
        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";
        private string _SL_CODEMESSAGE = "";

        public string ZN_CODEZONE
        {
            get { return _ZN_CODEZONE; }
            set { _ZN_CODEZONE = value; }
        }
        public string ZN_NOMZONE
        {
            get { return _ZN_NOMZONE; }
            set { _ZN_NOMZONE = value; }
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

        public clsZoneDTO() { }

        public clsZoneDTO(clsZoneDTO clsZoneDTO)
        {
            ZN_CODEZONE = clsZoneDTO.ZN_CODEZONE;
            ZN_NOMZONE = clsZoneDTO.ZN_NOMZONE;
            SL_RESULTAT = clsZoneDTO.SL_RESULTAT;
            SL_MESSAGE = clsZoneDTO.SL_MESSAGE;
            SL_CODEMESSAGE = clsZoneDTO.SL_CODEMESSAGE;

        }
    }
}
