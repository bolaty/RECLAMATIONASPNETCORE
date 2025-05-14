using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqrequeteparetape
    {
        #region VARIABLES LOCALES

        private string _RE_CODEETAPE = "";
        private string _RE_LIBELLEETAPE = "";
        private string _RE_ACTIF = "";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

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

        #endregion

        #region INSTANCIATEURS

        public clsReqrequeteparetape() { }

        public clsReqrequeteparetape(clsReqrequeteparetape clsReqrequeteparetape)
        {
            this.RE_CODEETAPE = clsReqrequeteparetape.RE_CODEETAPE;
            this.RE_LIBELLEETAPE = clsReqrequeteparetape.RE_LIBELLEETAPE;
            this.RE_ACTIF = clsReqrequeteparetape.RE_ACTIF;

            this.clsResultat = clsReqrequeteparetape.clsResultat;
            this.clsObjetEnvoi = clsReqrequeteparetape.clsObjetEnvoi;
        }

        #endregion

    }
}
