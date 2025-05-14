using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqactioncorrective
    {
        #region VARIABLES LOCALES

        private string _AC_CODEACTIONCORRECTIVE = "";
        private string _AC_LIBELLEACTIONCORRECTIVE = "";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;
        #endregion

        #region ACCESSEURS

        public string AC_CODEACTIONCORRECTIVE
        {
            get { return _AC_CODEACTIONCORRECTIVE; }
            set { _AC_CODEACTIONCORRECTIVE = value; }
        }

        public string AC_LIBELLEACTIONCORRECTIVE
        {
            get { return _AC_LIBELLEACTIONCORRECTIVE; }
            set { _AC_LIBELLEACTIONCORRECTIVE = value; }
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

        public clsReqactioncorrective() { }
        public clsReqactioncorrective(string AC_CODEACTIONCORRECTIVE, string AC_LIBELLEACTIONCORRECTIVE)
        {
            this.AC_CODEACTIONCORRECTIVE = AC_CODEACTIONCORRECTIVE;
            this.AC_LIBELLEACTIONCORRECTIVE = AC_LIBELLEACTIONCORRECTIVE;

        }
        public clsReqactioncorrective(clsReqactioncorrective clsReqactioncorrective)
        {
            this.AC_CODEACTIONCORRECTIVE = clsReqactioncorrective.AC_CODEACTIONCORRECTIVE;
            this.AC_LIBELLEACTIONCORRECTIVE = clsReqactioncorrective.AC_LIBELLEACTIONCORRECTIVE;
            this.clsResultat = clsReqactioncorrective.clsResultat;
            this.clsObjetEnvoi = clsReqactioncorrective.clsObjetEnvoi;
        }

        #endregion

    }
}
