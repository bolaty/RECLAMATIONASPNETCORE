using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsReqemailout
    {
        #region VARIABLES LOCALES

        private string _AG_CODEAGENCE = "";
        private DateTime _EM_DATEPIECE = DateTime.Parse("01/01/1900");
        private int _EM_NUMSEQUENCE = 0;
        private string _PW_CODEWEBTYPEOPERATION = "";
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _EM_MESSAGE = "";
        private string _EM_EMAIL = "";
        private string _EM_STATUT = "";
        private DateTime _EM_DATESAISIE = DateTime.Parse("01/01/1900");
        private string _EM_FICHERJOINT = "";
        private string _EM_OBJET = "";

        #endregion

        #region ACCESSEURS



        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public DateTime EM_DATEPIECE
        {
            get { return _EM_DATEPIECE; }
            set { _EM_DATEPIECE = value; }
        }

        public int EM_NUMSEQUENCE
        {
            get { return _EM_NUMSEQUENCE; }
            set { _EM_NUMSEQUENCE = value; }
        }

        public string PW_CODEWEBTYPEOPERATION
        {
            get { return _PW_CODEWEBTYPEOPERATION; }
            set { _PW_CODEWEBTYPEOPERATION = value; }
        }

        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
        }

        public string EM_MESSAGE
        {
            get { return _EM_MESSAGE; }
            set { _EM_MESSAGE = value; }
        }

        public string EM_EMAIL
        {
            get { return _EM_EMAIL; }
            set { _EM_EMAIL = value; }
        }

        public string EM_STATUT
        {
            get { return _EM_STATUT; }
            set { _EM_STATUT = value; }
        }

        public DateTime EM_DATESAISIE
        {
            get { return _EM_DATESAISIE; }
            set { _EM_DATESAISIE = value; }
        }

        public string EM_FICHERJOINT
        {
            get { return _EM_FICHERJOINT; }
            set { _EM_FICHERJOINT = value; }
        }

        public string EM_OBJET
        {
            get { return _EM_OBJET; }
            set { _EM_OBJET = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsReqemailout() { }
        public clsReqemailout(string AG_CODEAGENCE, DateTime EM_DATEPIECE, int EM_NUMSEQUENCE, string PW_CODEWEBTYPEOPERATION, string CU_CODECOMPTEUTULISATEUR, string EM_MESSAGE, string EM_EMAIL, string EM_STATUT, DateTime EM_DATESAISIE, string EM_FICHERJOINT, string EM_OBJET)
        {
            this.AG_CODEAGENCE = AG_CODEAGENCE;
            this.EM_DATEPIECE = EM_DATEPIECE;
            this.EM_NUMSEQUENCE = EM_NUMSEQUENCE;
            this.PW_CODEWEBTYPEOPERATION = PW_CODEWEBTYPEOPERATION;
            this.CU_CODECOMPTEUTULISATEUR = CU_CODECOMPTEUTULISATEUR;
            this.EM_MESSAGE = EM_MESSAGE;
            this.EM_EMAIL = EM_EMAIL;
            this.EM_STATUT = EM_STATUT;
            this.EM_DATESAISIE = EM_DATESAISIE;
            this.EM_FICHERJOINT = EM_FICHERJOINT;
            this.EM_OBJET = EM_OBJET;
        }
        public clsReqemailout(clsReqemailout clsReqemailout)
        {
            this.AG_CODEAGENCE = clsReqemailout.AG_CODEAGENCE;
            this.AG_CODEAGENCE = clsReqemailout.AG_CODEAGENCE;
            this.EM_DATEPIECE = clsReqemailout.EM_DATEPIECE;
            this.EM_NUMSEQUENCE = clsReqemailout.EM_NUMSEQUENCE;
            this.PW_CODEWEBTYPEOPERATION = clsReqemailout.PW_CODEWEBTYPEOPERATION;
            this.CU_CODECOMPTEUTULISATEUR = clsReqemailout.CU_CODECOMPTEUTULISATEUR;
            this.EM_MESSAGE = clsReqemailout.EM_MESSAGE;
            this.EM_EMAIL = clsReqemailout.EM_EMAIL;
            this.EM_STATUT = clsReqemailout.EM_STATUT;
            this.EM_DATESAISIE = clsReqemailout.EM_DATESAISIE;
            this.EM_FICHERJOINT = clsReqemailout.EM_FICHERJOINT;
            this.EM_OBJET = clsReqemailout.EM_OBJET;
        }

        #endregion

    }
}
