using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsTableauDeBordAutre
    {
        #region VARIABLES LOCALES
        private string _LIBELLERUBRIQUE = "";
        private string _NOMBRE = "0";


        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        #endregion

        #region ACCESSEURS

        public string LIBELLERUBRIQUE
        {
            get { return _LIBELLERUBRIQUE; }
            set { _LIBELLERUBRIQUE = value; }
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

        #endregion

        #region INSTANCIATEURS

        public clsTableauDeBordAutre() { }

        public clsTableauDeBordAutre(clsTableauDeBordAutre clsTableauDeBordAutre)
        {
            this.LIBELLERUBRIQUE = clsTableauDeBordAutre.LIBELLERUBRIQUE;
            this.NOMBRE = clsTableauDeBordAutre.NOMBRE;
            this.clsResultat = clsTableauDeBordAutre.clsResultat;
            this.clsObjetEnvoi = clsTableauDeBordAutre.clsObjetEnvoi;
        }

        #endregion
    }
}
