using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsDocEtapesDetail
    {
        private string _AT_CODEDOC = "";
        private string _AT_NOMRAPPORT = "";

        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        public string AT_CODEDOC
        {
            get { return _AT_CODEDOC; }
            set { _AT_CODEDOC = value; }
        }
        public string AT_NOMRAPPORT
        {
            get { return _AT_NOMRAPPORT; }
            set { _AT_NOMRAPPORT = value; }
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



        public clsDocEtapesDetail() { }


        public clsDocEtapesDetail(clsDocEtapesDetail clsDocEtapesDetail)
        {
            this.AT_CODEDOC = clsDocEtapesDetail.AT_CODEDOC;
            this.AT_NOMRAPPORT = clsDocEtapesDetail.AT_NOMRAPPORT;
            this.clsResultat = clsDocEtapesDetail.clsResultat;
            this.clsObjetEnvoi = clsDocEtapesDetail.clsObjetEnvoi;
        }
    }
}
