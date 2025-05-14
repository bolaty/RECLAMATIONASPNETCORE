using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsAgenceDTO
    {
        private string _AG_CODEAGENCE = "";
        private string _AG_RAISONSOCIAL = "";
        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";
        private string _SL_CODEMESSAGE = "";
        private string _AG_RAISONSOCIAL_TRANSLATE = "";

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
        public string AG_RAISONSOCIAL
        {
            get { return _AG_RAISONSOCIAL; }
            set { _AG_RAISONSOCIAL = value; }
        }

        public string AG_RAISONSOCIAL_TRANSLATE
        {
            get { return _AG_RAISONSOCIAL_TRANSLATE; }
            set { _AG_RAISONSOCIAL_TRANSLATE = value; }
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
        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
        }

        public clsAgenceDTO() { }

        public clsAgenceDTO(clsAgenceDTO clsAgenceDTO)
        {
            AG_CODEAGENCE = clsAgenceDTO.AG_CODEAGENCE;
            AG_RAISONSOCIAL = clsAgenceDTO.AG_RAISONSOCIAL;
            SL_RESULTAT = clsAgenceDTO.SL_RESULTAT;
            SL_MESSAGE = clsAgenceDTO.SL_MESSAGE;
            SL_CODEMESSAGE = clsAgenceDTO.SL_CODEMESSAGE;

            AG_RAISONSOCIAL_TRANSLATE = clsAgenceDTO.AG_RAISONSOCIAL_TRANSLATE;

        }
    }
}
