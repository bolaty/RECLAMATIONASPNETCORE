using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsObjetEnvoi
    {
        private string _ET_CODEETABLISSEMENT = "";
        private string _AG_CODEAGENCE = "";
        private string _TYPEOPERATION = "";
        private string _DATEDEBUT = "01-01-1900";
        private string _DATEFIN = "01-01-1900";
        private string _AN_CODEANTENNE = "";




        public string AN_CODEANTENNE
        {
            get { return _AN_CODEANTENNE; }
            set { _AN_CODEANTENNE = value; }
        }

        public string ET_CODEETABLISSEMENT
        {
            get { return _ET_CODEETABLISSEMENT; }
            set { _ET_CODEETABLISSEMENT = value; }
        }


        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }


        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }
        public string DATEDEBUT
        {
            get { return _DATEDEBUT; }
            set { _DATEDEBUT = value; }
        }
        public string DATEFIN
        {
            get { return _DATEFIN; }
            set { _DATEFIN = value; }
        }

        public clsObjetEnvoi() { }



        public clsObjetEnvoi(clsObjetEnvoi clsObjetEnvoi)
        {
            this.ET_CODEETABLISSEMENT = clsObjetEnvoi.ET_CODEETABLISSEMENT;
            this.AG_CODEAGENCE = clsObjetEnvoi.AG_CODEAGENCE;
            this.TYPEOPERATION = clsObjetEnvoi.TYPEOPERATION;
            this.DATEDEBUT = clsObjetEnvoi.DATEDEBUT;
            this.DATEFIN = clsObjetEnvoi.DATEFIN;
            this.AN_CODEANTENNE = clsObjetEnvoi.AN_CODEANTENNE;
        }


    }
}
