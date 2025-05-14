using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsMessages
    {
        private string _MS_CODEMESSAGE = "";
        private string _MS_LIBELLEMESSAGE = "";



        public string MS_CODEMESSAGE
        {
            get { return _MS_CODEMESSAGE; }
            set { _MS_CODEMESSAGE = value; }
        }
        public string MS_LIBELLEMESSAGE
        {
            get { return _MS_LIBELLEMESSAGE; }
            set { _MS_LIBELLEMESSAGE = value; }
        }



        public clsMessages() { }

        public clsMessages(string MS_CODEMESSAGE, string MS_LIBELLEMESSAGE)
        {
            this.MS_CODEMESSAGE = MS_CODEMESSAGE;
            this.MS_LIBELLEMESSAGE = MS_LIBELLEMESSAGE;
        }

        public clsMessages(clsMessages clsMessages)
        {
            MS_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            MS_LIBELLEMESSAGE = clsMessages.MS_LIBELLEMESSAGE;
        }
    }
}
