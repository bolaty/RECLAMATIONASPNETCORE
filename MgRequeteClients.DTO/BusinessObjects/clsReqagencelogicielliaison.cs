using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqagencelogicielliaison
    {
        #region VARIABLES LOCALES

        private string _AG_CODEAGENCE = "";
        private string _LO_CODELOGICIEL = "";
        private string _AL_URL = "";

        #endregion

        #region ACCESSEURS

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public string LO_CODELOGICIEL
        {
            get { return _LO_CODELOGICIEL; }
            set { _LO_CODELOGICIEL = value; }
        }

        public string AL_URL
        {
            get { return _AL_URL; }
            set { _AL_URL = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsReqagencelogicielliaison() { }
        public clsReqagencelogicielliaison(string AG_CODEAGENCE, string LO_CODELOGICIEL, string AL_URL)
        {
            this.AG_CODEAGENCE = AG_CODEAGENCE;
            this.LO_CODELOGICIEL = LO_CODELOGICIEL;
            this.AL_URL = AL_URL;
        }
        public clsReqagencelogicielliaison(clsReqagencelogicielliaison clsReqagencelogicielliaison)
        {
            this.AG_CODEAGENCE = clsReqagencelogicielliaison.AG_CODEAGENCE;
            this.LO_CODELOGICIEL = clsReqagencelogicielliaison.LO_CODELOGICIEL;
            this.AL_URL = clsReqagencelogicielliaison.AL_URL;
        }

        #endregion

    }
}
