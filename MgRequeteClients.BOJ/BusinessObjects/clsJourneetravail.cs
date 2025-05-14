using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsJourneetravail
    {
        private string _AG_CODEAGENCE = "";
        private string _PV_CODEPOINTVENTE = "";
        private DateTime _JT_DATEJOURNEETRAVAIL = DateTime.Parse("01/01/1900");
        private string _JT_STATUT = "";
        private string _OP_CODEOPERATEUR = "";



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
        public DateTime JT_DATEJOURNEETRAVAIL
        {
            get { return _JT_DATEJOURNEETRAVAIL; }
            set { _JT_DATEJOURNEETRAVAIL = value; }
        }
        public string JT_STATUT
        {
            get { return _JT_STATUT; }
            set { _JT_STATUT = value; }
        }
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }



        public clsJourneetravail() { }

        public clsJourneetravail(string AG_CODEAGENCE, string PV_CODEPOINTVENTE, DateTime JT_DATEJOURNEETRAVAIL, string JT_STATUT, string OP_CODEOPERATEUR)
        {
            this.AG_CODEAGENCE = AG_CODEAGENCE;
            this.PV_CODEPOINTVENTE = PV_CODEPOINTVENTE;
            this.JT_DATEJOURNEETRAVAIL = JT_DATEJOURNEETRAVAIL;
            this.JT_STATUT = JT_STATUT;
            this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
        }

        public clsJourneetravail(clsJourneetravail clsJourneetravail)
        {
            AG_CODEAGENCE = clsJourneetravail.AG_CODEAGENCE;
            PV_CODEPOINTVENTE = clsJourneetravail.PV_CODEPOINTVENTE;
            JT_DATEJOURNEETRAVAIL = clsJourneetravail.JT_DATEJOURNEETRAVAIL;
            JT_STATUT = clsJourneetravail.JT_STATUT;
            OP_CODEOPERATEUR = clsJourneetravail.OP_CODEOPERATEUR;
        }
    }
}
