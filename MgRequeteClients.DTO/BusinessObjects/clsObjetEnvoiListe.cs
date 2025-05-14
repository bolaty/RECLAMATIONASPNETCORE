using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsObjetEnvoiListe
    {
        #region VARIABLES LOCALES
        private string[] _OE_PARAM = new string[] { };
        private string _RQ_CODEREQUETE = "";
        private string _TYPEOPERATION = "";
        private clsObjetEnvoi _clsObjetEnvoi;
        #endregion

        #region ACCESSEURS

        /// <summary>
        /// PARAMETRES
        /// </summary>
        public string[] OE_PARAM
        {
            get { return _OE_PARAM; }
            set { _OE_PARAM = value; }
        }

        public string RQ_CODEREQUETE
        {
            get { return _RQ_CODEREQUETE; }
            set { _RQ_CODEREQUETE = value; }
        }

        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }

        public clsObjetEnvoi clsObjetEnvoi
        {
            get { return _clsObjetEnvoi; }
            set { _clsObjetEnvoi = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsObjetEnvoiListe() { }

        public clsObjetEnvoiListe(clsObjetEnvoiListe clsObjetEnvoiListe)
        {
            this.OE_PARAM = OE_PARAM;
            this.RQ_CODEREQUETE = RQ_CODEREQUETE;
            this.TYPEOPERATION = TYPEOPERATION;
            this.clsObjetEnvoi = clsObjetEnvoiListe.clsObjetEnvoi;
        }

        #endregion
    }
}
