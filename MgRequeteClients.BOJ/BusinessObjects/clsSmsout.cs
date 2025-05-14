using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsSmsout
    {
        #region VARIABLES LOCALES

        private string _AG_CODEAGENCE = "";
        private DateTime _SM_DATEPIECE = DateTime.Parse("01/01/1900");
        private string _SM_NUMSEQUENCE = "";
        private DateTime _MC_DATEPIECE = DateTime.Parse("01/01/1900");
        private string _MC_NUMPIECE = "";
        private string _MC_NUMSEQUENCE = "";
        private string _TE_CODESMSTYPEOPERATION = "";
        private string _CO_CODECOMPTE = "";
        private string _SM_MESSAGE = "";//--le sms envoyé
        private string _SM_TELEPHONE = "";
        private string _SM_STATUT = "";
        private string _SL_CODEMESSAGE = "";
        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";//--le message informant sur l'execution du service MgRequeteClients

        private DateTime _SM_DATEEMISSIONSMS = DateTime.Parse("01/01/1900");
        private DateTime _SM_DATESAISIE = DateTime.Parse("01/01/1900");




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

        public DateTime MC_DATEPIECE
        {
            get { return _MC_DATEPIECE; }
            set { _MC_DATEPIECE = value; }
        }

        public string MC_NUMPIECE
        {
            get { return _MC_NUMPIECE; }
            set { _MC_NUMPIECE = value; }
        }

        public string MC_NUMSEQUENCE
        {
            get { return _MC_NUMSEQUENCE; }
            set { _MC_NUMSEQUENCE = value; }
        }

        public string TE_CODESMSTYPEOPERATION
        {
            get { return _TE_CODESMSTYPEOPERATION; }
            set { _TE_CODESMSTYPEOPERATION = value; }
        }

        public string CO_CODECOMPTE
        {
            get { return _CO_CODECOMPTE; }
            set { _CO_CODECOMPTE = value; }
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



        public DateTime SM_DATEEMISSIONSMS
        {
            get { return _SM_DATEEMISSIONSMS; }
            set { _SM_DATEEMISSIONSMS = value; }
        }

        public DateTime SM_DATESAISIE
        {
            get { return _SM_DATESAISIE; }
            set { _SM_DATESAISIE = value; }
        }







        #endregion

        #region INSTANCIATEURS

        public clsSmsout() { }

        public clsSmsout(clsSmsout clsSmsout)
        {
            this.AG_CODEAGENCE = clsSmsout.AG_CODEAGENCE;
            this.SM_DATEPIECE = clsSmsout.SM_DATEPIECE;
            this.SM_NUMSEQUENCE = clsSmsout.SM_NUMSEQUENCE;
            this.MC_DATEPIECE = clsSmsout.MC_DATEPIECE;
            this.MC_NUMPIECE = clsSmsout.MC_NUMPIECE;
            this.MC_NUMSEQUENCE = clsSmsout.MC_NUMSEQUENCE;
            this.TE_CODESMSTYPEOPERATION = clsSmsout.TE_CODESMSTYPEOPERATION;
            this.CO_CODECOMPTE = clsSmsout.CO_CODECOMPTE;
            this.SM_MESSAGE = clsSmsout.SM_MESSAGE;
            this.SM_TELEPHONE = clsSmsout.SM_TELEPHONE;
            this.SM_STATUT = clsSmsout.SM_STATUT;
            this.SL_CODEMESSAGE = clsSmsout.SL_CODEMESSAGE;
            this.SL_RESULTAT = clsSmsout.SL_RESULTAT;
            this.SL_MESSAGE = clsSmsout.SL_MESSAGE;
            this.SM_DATEEMISSIONSMS = clsSmsout.SM_DATEEMISSIONSMS;
            this.SM_DATESAISIE = clsSmsout.SM_DATESAISIE;




        }

        #endregion
    }
}
