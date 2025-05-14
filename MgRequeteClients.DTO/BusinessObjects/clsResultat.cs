using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsResultat
    {
        private string _SL_NOM = "";
        private string _SL_PRENOMS = "";
        private string _SL_NUMEROBORDERAU = "";
        private string _SL_CODEMESSAGE = "";
        private string _SL_MESSAGE = "";
        private string _SL_RESULTAT = "";

        public string SL_NOM
        {
            get { return _SL_NOM; }
            set { _SL_NOM = value; }
        }
        public string SL_PRENOMS
        {
            get { return _SL_PRENOMS; }
            set { _SL_PRENOMS = value; }
        }


        public string SL_NUMEROBORDERAU
        {
            get { return _SL_NUMEROBORDERAU; }
            set { _SL_NUMEROBORDERAU = value; }
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


        public clsResultat() { }


        public clsResultat(clsResultat clsResultat)
        {
            this.SL_NOM = clsResultat.SL_NOM;
            this.SL_PRENOMS = clsResultat.SL_PRENOMS;
            this.SL_NUMEROBORDERAU = clsResultat.SL_NUMEROBORDERAU;
            this.SL_CODEMESSAGE = clsResultat.SL_CODEMESSAGE;
            this.SL_MESSAGE = clsResultat.SL_MESSAGE;
            this.SL_RESULTAT = clsResultat.SL_RESULTAT;
        }
    }
}
