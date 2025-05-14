using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqactioncorrective
    {
        #region VARIABLES LOCALES

        private string _AC_CODEACTIONCORRECTIVE = "";
        private string _AC_LIBELLEACTIONCORRECTIVE = "";

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
        }

        #endregion

    }

}
