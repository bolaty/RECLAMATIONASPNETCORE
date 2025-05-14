using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsMouchard
    {
        private string _AG_CODEAGENCE = "";
        private string _MO_SEQUENCE = "";
        private string _OP_CODEOPERATEUR = "";
        private DateTime _MO_DATEACTION = DateTime.Parse("01/01/1900");
        private DateTime _MO_HEUREACTION = DateTime.Parse("01/01/1900");
        private string _MO_ACTION = "";
        private bool _MO_PREMIEREEXECUTION = false;
        private string _MO_TERMINALIDENTIFIANT = "";
        private string _MO_TERMINALDESCRIPTION = "";
        private string _SL_CODECOMPTEWEB = "";
        private string _OP_CODEOPERATEURAPPLICATIONMOBILE = "";
        private DateTime _JT_DATEJOURNEETRAVAIL = DateTime.Parse("01/01/1900");

        public string MO_TERMINALIDENTIFIANT
        {
            get { return _MO_TERMINALIDENTIFIANT; }
            set { _MO_TERMINALIDENTIFIANT = value; }
        }
        public string MO_TERMINALDESCRIPTION
        {
            get { return _MO_TERMINALDESCRIPTION; }
            set { _MO_TERMINALDESCRIPTION = value; }
        }
        public string SL_CODECOMPTEWEB
        {
            get { return _SL_CODECOMPTEWEB; }
            set { _SL_CODECOMPTEWEB = value; }
        }
        public string OP_CODEOPERATEURAPPLICATIONMOBILE
        {
            get { return _OP_CODEOPERATEURAPPLICATIONMOBILE; }
            set { _OP_CODEOPERATEURAPPLICATIONMOBILE = value; }
        }
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
        public string MO_SEQUENCE
        {
            get { return _MO_SEQUENCE; }
            set { _MO_SEQUENCE = value; }
        }
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
        public DateTime MO_DATEACTION
        {
            get { return _MO_DATEACTION; }
            set { _MO_DATEACTION = value; }
        }
        public DateTime MO_HEUREACTION
        {
            get { return _MO_HEUREACTION; }
            set { _MO_HEUREACTION = value; }
        }
        public string MO_ACTION
        {
            get { return _MO_ACTION; }
            set { _MO_ACTION = value; }
        }
        public bool MO_PREMIEREEXECUTION
        {
            get { return _MO_PREMIEREEXECUTION; }
            set { _MO_PREMIEREEXECUTION = value; }
        }

        public DateTime JT_DATEJOURNEETRAVAIL
        {
            get { return _JT_DATEJOURNEETRAVAIL; }
            set { _JT_DATEJOURNEETRAVAIL = value; }
        }


        public clsMouchard() { }

        public clsMouchard(string AG_CODEAGENCE, string MO_SEQUENCE, string OP_CODEOPERATEUR, DateTime MO_DATEACTION, DateTime MO_HEUREACTION, string MO_ACTION, bool MO_PREMIEREEXECUTION, DateTime JT_DATEJOURNEETRAVAIL)
        {
            this.AG_CODEAGENCE = AG_CODEAGENCE;
            this.MO_SEQUENCE = MO_SEQUENCE;
            this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
            this.MO_DATEACTION = MO_DATEACTION;
            this.MO_HEUREACTION = MO_HEUREACTION;
            this.MO_ACTION = MO_ACTION;
            this.MO_PREMIEREEXECUTION = MO_PREMIEREEXECUTION;
            this.JT_DATEJOURNEETRAVAIL = JT_DATEJOURNEETRAVAIL;
        }

        public clsMouchard(clsMouchard clsMouchard)
        {
            AG_CODEAGENCE = clsMouchard.AG_CODEAGENCE;
            MO_SEQUENCE = clsMouchard.MO_SEQUENCE;
            OP_CODEOPERATEUR = clsMouchard.OP_CODEOPERATEUR;
            MO_DATEACTION = clsMouchard.MO_DATEACTION;
            MO_HEUREACTION = clsMouchard.MO_HEUREACTION;
            MO_ACTION = clsMouchard.MO_ACTION;
            MO_PREMIEREEXECUTION = clsMouchard.MO_PREMIEREEXECUTION;
            MO_TERMINALIDENTIFIANT = clsMouchard.MO_TERMINALIDENTIFIANT;
            MO_TERMINALDESCRIPTION = clsMouchard.MO_TERMINALDESCRIPTION;
            SL_CODECOMPTEWEB = clsMouchard.SL_CODECOMPTEWEB;
            OP_CODEOPERATEURAPPLICATIONMOBILE = clsMouchard.OP_CODEOPERATEURAPPLICATIONMOBILE;
            JT_DATEJOURNEETRAVAIL = clsMouchard.JT_DATEJOURNEETRAVAIL;
        }
    }
}
