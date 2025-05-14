using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqrequeteparetape
    {
        #region VARIABLES LOCALES

        private string _RE_CODEETAPE = "";
        private string _RE_LIBELLEETAPE = "";
        private string _RE_ACTIF = "";
        private string _TYPEOPERATION = "";

        #endregion

        #region ACCESSEURS

        public string RE_CODEETAPE
        {
            get { return _RE_CODEETAPE; }
            set { _RE_CODEETAPE = value; }
        }

        public string RE_LIBELLEETAPE
        {
            get { return _RE_LIBELLEETAPE; }
            set { _RE_LIBELLEETAPE = value; }
        }

        public string RE_ACTIF
        {
            get { return _RE_ACTIF; }
            set { _RE_ACTIF = value; }
        }
        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsReqrequeteparetape() { }

        public clsReqrequeteparetape(clsReqrequeteparetape clsReqrequeteparetape)
        {
            this.RE_CODEETAPE = clsReqrequeteparetape.RE_CODEETAPE;
            this.RE_LIBELLEETAPE = clsReqrequeteparetape.RE_LIBELLEETAPE;
            this.RE_ACTIF = clsReqrequeteparetape.RE_ACTIF;
            this.TYPEOPERATION = clsReqrequeteparetape.TYPEOPERATION;
        }

        #endregion

    }
}
