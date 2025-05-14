using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsReqmotdepasseoublier
    {
        #region VARIABLES LOCALES

        private string _AG_CODEAGENCE = "";
        private DateTime _MO_DATE = DateTime.Parse("01/01/1900");
        private int _MO_NUMEROSEQUENCE = 0;
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _MO_CONTACT = "";
        private DateTime _MO_HEURE = DateTime.Parse("01/01/1900");
        private string _MO_CODEVALIDATION = "";
        private DateTime _MO_DATEVALIDATION = DateTime.Parse("01/01/1900");

        #endregion

        #region ACCESSEURS

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public DateTime MO_DATE
        {
            get { return _MO_DATE; }
            set { _MO_DATE = value; }
        }

        public int MO_NUMEROSEQUENCE
        {
            get { return _MO_NUMEROSEQUENCE; }
            set { _MO_NUMEROSEQUENCE = value; }
        }

        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
        }

        public string MO_CONTACT
        {
            get { return _MO_CONTACT; }
            set { _MO_CONTACT = value; }
        }

        public DateTime MO_HEURE
        {
            get { return _MO_HEURE; }
            set { _MO_HEURE = value; }
        }

        public string MO_CODEVALIDATION
        {
            get { return _MO_CODEVALIDATION; }
            set { _MO_CODEVALIDATION = value; }
        }

        public DateTime MO_DATEVALIDATION
        {
            get { return _MO_DATEVALIDATION; }
            set { _MO_DATEVALIDATION = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsReqmotdepasseoublier() { }
        public clsReqmotdepasseoublier(string AG_CODEAGENCE, DateTime MO_DATE, int MO_NUMEROSEQUENCE, string CU_CODECOMPTEUTULISATEUR, string MO_CONTACT, DateTime MO_HEURE, string MO_CODEVALIDATION, DateTime MO_DATEVALIDATION)
        {
            this.AG_CODEAGENCE = AG_CODEAGENCE;
            this.MO_DATE = MO_DATE;
            this.MO_NUMEROSEQUENCE = MO_NUMEROSEQUENCE;
            this.CU_CODECOMPTEUTULISATEUR = CU_CODECOMPTEUTULISATEUR;
            this.MO_CONTACT = MO_CONTACT;
            this.MO_HEURE = MO_HEURE;
            this.MO_CODEVALIDATION = MO_CODEVALIDATION;
            this.MO_DATEVALIDATION = MO_DATEVALIDATION;
        }
        public clsReqmotdepasseoublier(clsReqmotdepasseoublier clsReqmotdepasseoublier)
        {
            this.AG_CODEAGENCE = clsReqmotdepasseoublier.AG_CODEAGENCE;
            this.MO_DATE = clsReqmotdepasseoublier.MO_DATE;
            this.MO_NUMEROSEQUENCE = clsReqmotdepasseoublier.MO_NUMEROSEQUENCE;
            this.CU_CODECOMPTEUTULISATEUR = clsReqmotdepasseoublier.CU_CODECOMPTEUTULISATEUR;
            this.MO_CONTACT = clsReqmotdepasseoublier.MO_CONTACT;
            this.MO_HEURE = clsReqmotdepasseoublier.MO_HEURE;
            this.MO_CODEVALIDATION = clsReqmotdepasseoublier.MO_CODEVALIDATION;
            this.MO_DATEVALIDATION = clsReqmotdepasseoublier.MO_DATEVALIDATION;
        }

        #endregion
    }
}
