using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsFrequenceReclamationDTO
    {
        private string _CU_CODECOMPTEUTULISATEUR = "";
        private string _CU_NUMEROUTILISATEUR = "";
        private string _CU_NOMUTILISATEUR = "";
        private string _CU_CONTACT = "";
        private string _CU_EMAIL = "";
        private string _CANAL = "";
        private string _NOMBRE = "0";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
        }
        public string CU_NUMEROUTILISATEUR
        {
            get { return _CU_NUMEROUTILISATEUR; }
            set { _CU_NUMEROUTILISATEUR = value; }
        }
        public string CU_NOMUTILISATEUR
        {
            get { return _CU_NOMUTILISATEUR; }
            set { _CU_NOMUTILISATEUR = value; }
        }
        public string CU_CONTACT
        {
            get { return _CU_CONTACT; }
            set { _CU_CONTACT = value; }
        }
        public string CU_EMAIL
        {
            get { return _CU_EMAIL; }
            set { _CU_EMAIL = value; }
        }
        public string CANAL
        {
            get { return _CANAL; }
            set { _CANAL = value; }
        }
        public string NOMBRE
        {
            get { return _NOMBRE; }
            set { _NOMBRE = value; }
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

        public clsFrequenceReclamationDTO() { }

        public clsFrequenceReclamationDTO(clsFrequenceReclamationDTO clsFrequenceReclamationDTO)
        {
            CU_CODECOMPTEUTULISATEUR = clsFrequenceReclamationDTO.CU_CODECOMPTEUTULISATEUR;
            CU_NUMEROUTILISATEUR = clsFrequenceReclamationDTO.CU_NUMEROUTILISATEUR;
            CU_NOMUTILISATEUR = clsFrequenceReclamationDTO.CU_NOMUTILISATEUR;
            CU_CONTACT = clsFrequenceReclamationDTO.CU_CONTACT;
            CU_EMAIL = clsFrequenceReclamationDTO.CU_EMAIL;
            CANAL = clsFrequenceReclamationDTO.CANAL;
            NOMBRE = clsFrequenceReclamationDTO.NOMBRE;
            this.clsResultat = clsFrequenceReclamationDTO.clsResultat;
            this.clsObjetEnvoi = clsFrequenceReclamationDTO.clsObjetEnvoi;

        }
    }
}
