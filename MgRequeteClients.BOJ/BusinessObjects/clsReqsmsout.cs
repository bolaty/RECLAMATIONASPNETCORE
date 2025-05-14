using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqsmsout
    {
        #region VARIABLES LOCALES

        private string _AG_CODEAGENCE = "";
        private DateTime _SM_DATEPIECE = DateTime.Parse("01/01/1900");
        private string _SM_NUMSEQUENCE = "";
        private decimal _CU_CODECOMPTEUTULISATEUR = 0;
        private string _TE_CODESMSTYPEOPERATION = "";
        private string _SM_MESSAGE = "";
        private string _SM_TELEPHONE = "";
        private string _SM_STATUT = "";
        private DateTime _SM_DATEEMISSIONSMS = DateTime.Parse("01/01/1900");
        private string _SM_RAISONNONENVOISMS = "";
        private DateTime _SM_DATESAISIE = DateTime.Parse("01/01/1900");

        private string _SL_CODEMESSAGE = "";
        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";//--le message informant sur l'execution du service MgRequeteClients



        #endregion

        #region ACCESSEURS

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public DateTime SM_DATEPIECE
        {
            get { return _SM_DATEPIECE; }
            set { _SM_DATEPIECE = value; }
        }

        public string SM_NUMSEQUENCE
        {
            get { return _SM_NUMSEQUENCE; }
            set { _SM_NUMSEQUENCE = value; }
        }

        public decimal CU_CODECOMPTEUTULISATEUR
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

        public DateTime SM_DATEEMISSIONSMS
        {
            get { return _SM_DATEEMISSIONSMS; }
            set { _SM_DATEEMISSIONSMS = value; }
        }

        public string SM_RAISONNONENVOISMS
        {
            get { return _SM_RAISONNONENVOISMS; }
            set { _SM_RAISONNONENVOISMS = value; }
        }

        public DateTime SM_DATESAISIE
        {
            get { return _SM_DATESAISIE; }
            set { _SM_DATESAISIE = value; }
        }

        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
        }

        public string SL_RESULTAT
        {
            get { return _SL_RESULTAT; }
            set { _SL_RESULTAT = value; }
        }
        public string SL_MESSAGE
        {
            get { return _SL_MESSAGE; }
            set { _SL_MESSAGE = value; }
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

            this.SL_CODEMESSAGE = clsReqsmsout.SL_CODEMESSAGE;
            this.SL_RESULTAT = clsReqsmsout.SL_RESULTAT;
            this.SL_MESSAGE = clsReqsmsout.SL_MESSAGE;
        }

        #endregion

    }
}
