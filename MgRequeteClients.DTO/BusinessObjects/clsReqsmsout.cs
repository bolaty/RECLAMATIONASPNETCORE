using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqsmsout
    {
        #region VARIABLES LOCALES

        private string _AG_CODEAGENCE = "";
        private string _SM_DATEPIECE = "01/01/1900";
        private string _SM_NUMSEQUENCE = "";
        private string _CU_CODECOMPTEUTULISATEUR = "0";
        private string _TE_CODESMSTYPEOPERATION = "";
        private string _SM_MESSAGE = "";
        private string _SM_TELEPHONE = "";
        private string _SM_STATUT = "";
        private string _SM_DATEEMISSIONSMS = "01/01/1900";
        private string _SM_RAISONNONENVOISMS = "";
        private string _SM_DATESAISIE = "01/01/1900";
        private string _SM_MESSAGE_TRANSLATE = "";
        private string _SM_STATUT_LECTURE = "";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        #endregion

        #region ACCESSEURS

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public string SM_DATEPIECE
        {
            get { return _SM_DATEPIECE; }
            set { _SM_DATEPIECE = value; }
        }

        public string SM_NUMSEQUENCE
        {
            get { return _SM_NUMSEQUENCE; }
            set { _SM_NUMSEQUENCE = value; }
        }

        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
        }

        public string TE_CODESMSTYPEOPERATION
        {
            get { return _TE_CODESMSTYPEOPERATION; }
            set { _TE_CODESMSTYPEOPERATION = value; }
        }

        public string SM_MESSAGE
        {
            get { return _SM_MESSAGE; }
            set { _SM_MESSAGE = value; }
        }

        public string SM_MESSAGE_TRANSLATE
        {
            get { return _SM_MESSAGE_TRANSLATE; }
            set { _SM_MESSAGE_TRANSLATE = value; }
        }

        public string SM_TELEPHONE
        {
            get { return _SM_TELEPHONE; }
            set { _SM_TELEPHONE = value; }
        }

        public string SM_STATUT
        {
            get { return _SM_STATUT; }
            set { _SM_STATUT = value; }
        }

        public string SM_DATEEMISSIONSMS
        {
            get { return _SM_DATEEMISSIONSMS; }
            set { _SM_DATEEMISSIONSMS = value; }
        }

        public string SM_RAISONNONENVOISMS
        {
            get { return _SM_RAISONNONENVOISMS; }
            set { _SM_RAISONNONENVOISMS = value; }
        }

        public string SM_DATESAISIE
        {
            get { return _SM_DATESAISIE; }
            set { _SM_DATESAISIE = value; }
        }

        public string SM_STATUT_LECTURE
        {
            get { return _SM_STATUT_LECTURE; }
            set { _SM_STATUT_LECTURE = value; }
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

        public clsReqsmsout() { }

        public clsReqsmsout(clsReqsmsout clsReqsmsout)
        {
            this.AG_CODEAGENCE = clsReqsmsout.AG_CODEAGENCE;
            this.SM_DATEPIECE = clsReqsmsout.SM_DATEPIECE;
            this.SM_NUMSEQUENCE = clsReqsmsout.SM_NUMSEQUENCE;
            this.CU_CODECOMPTEUTULISATEUR = clsReqsmsout.CU_CODECOMPTEUTULISATEUR;
            this.TE_CODESMSTYPEOPERATION = clsReqsmsout.TE_CODESMSTYPEOPERATION;
            this.SM_MESSAGE = clsReqsmsout.SM_MESSAGE;
            this.SM_TELEPHONE = clsReqsmsout.SM_TELEPHONE;
            this.SM_STATUT = clsReqsmsout.SM_STATUT;
            this.SM_DATEEMISSIONSMS = clsReqsmsout.SM_DATEEMISSIONSMS;
            this.SM_RAISONNONENVOISMS = clsReqsmsout.SM_RAISONNONENVOISMS;
            this.SM_DATESAISIE = clsReqsmsout.SM_DATESAISIE;
            this.SM_MESSAGE_TRANSLATE = clsReqsmsout.SM_MESSAGE_TRANSLATE;

            this.SM_STATUT_LECTURE = clsReqsmsout.SM_STATUT_LECTURE;

            this.clsResultat = clsReqsmsout.clsResultat;
            this.clsObjetEnvoi = clsReqsmsout.clsObjetEnvoi;
        }

        #endregion

    }
}
