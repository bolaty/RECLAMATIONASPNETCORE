using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqpiecejointes
    {
        #region VARIABLES LOCALES

        private string _PJ_CODEPIECEJOINT = "";
        private string _RQ_CODEREQUETE = "";
        private string _PJ_NOMPIECEJOINT = "";

        #endregion

        #region ACCESSEURS

        public string PJ_CODEPIECEJOINT
        {
            get { return _PJ_CODEPIECEJOINT; }
            set { _PJ_CODEPIECEJOINT = value; }
        }

        public string RQ_CODEREQUETE
        {
            get { return _RQ_CODEREQUETE; }
            set { _RQ_CODEREQUETE = value; }
        }

        public string PJ_NOMPIECEJOINT
        {
            get { return _PJ_NOMPIECEJOINT; }
            set { _PJ_NOMPIECEJOINT = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsReqpiecejointes() { }
        public clsReqpiecejointes(string PJ_CODEPIECEJOINT, string RQ_CODEREQUETE, string PJ_NOMPIECEJOINT)
        {
            this.PJ_CODEPIECEJOINT = PJ_CODEPIECEJOINT;
            this.RQ_CODEREQUETE = RQ_CODEREQUETE;
            this.PJ_NOMPIECEJOINT = PJ_NOMPIECEJOINT;
        }
        public clsReqpiecejointes(clsReqpiecejointes clsReqpiecejointes)
        {
            this.PJ_CODEPIECEJOINT = clsReqpiecejointes.PJ_CODEPIECEJOINT;
            this.RQ_CODEREQUETE = clsReqpiecejointes.RQ_CODEREQUETE;
            this.PJ_NOMPIECEJOINT = clsReqpiecejointes.PJ_NOMPIECEJOINT;
        }

        #endregion

    }
}
