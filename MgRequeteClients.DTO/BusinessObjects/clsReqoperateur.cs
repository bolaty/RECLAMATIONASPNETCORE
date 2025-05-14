using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqoperateur
    {
        #region VARIABLES LOCALES

        private string _OP_CODEOPERATEUR = "";
        private string _OP_CODEOPERATEURZENITH = "";
        private string _AG_CODEAGENCE = "";
        private string _PV_CODEPOINTVENTE = "";
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _SR_CODESERVICE = "";
        private string _OP_DATESAISIE = "01/01/1900";

        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        #endregion

        #region ACCESSEURS

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

        public string OP_CODEOPERATEURZENITH
        {
            get { return _OP_CODEOPERATEURZENITH; }
            set { _OP_CODEOPERATEURZENITH = value; }
        }

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public string PV_CODEPOINTVENTE
        {
            get { return _PV_CODEPOINTVENTE; }
            set { _PV_CODEPOINTVENTE = value; }
        }

        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
        }

        public string SR_CODESERVICE
        {
            get { return _SR_CODESERVICE; }
            set { _SR_CODESERVICE = value; }
        }

        public string OP_DATESAISIE
        {
            get { return _OP_DATESAISIE; }
            set { _OP_DATESAISIE = value; }
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

        public clsReqoperateur() { }

        public clsReqoperateur(clsReqoperateur clsReqoperateur)
        {
            this.OP_CODEOPERATEUR = clsReqoperateur.OP_CODEOPERATEUR;
            this.OP_CODEOPERATEURZENITH = clsReqoperateur.OP_CODEOPERATEURZENITH;
            this.AG_CODEAGENCE = clsReqoperateur.AG_CODEAGENCE;
            this.PV_CODEPOINTVENTE = clsReqoperateur.PV_CODEPOINTVENTE;
            this.CU_CODECOMPTEUTULISATEUR = clsReqoperateur.CU_CODECOMPTEUTULISATEUR;
            this.SR_CODESERVICE = clsReqoperateur.SR_CODESERVICE;
            this.OP_DATESAISIE = clsReqoperateur.OP_DATESAISIE;
            this.clsResultat = clsReqoperateur.clsResultat;
            this.clsObjetEnvoi = clsReqoperateur.clsObjetEnvoi;
        }

        #endregion
    }
}
