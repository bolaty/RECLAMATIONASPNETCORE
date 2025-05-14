using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsEditionEtatReclamation
    {
        #region VARIABLES LOCALES


        private string _PY_LIBELLE = "";
        private string _AG_RAISONSOCIAL = "";

        List<clsReqrequete> _clsReqrequeteEncours = null;
        List<clsReqrequete> _clsReqrequeteTraitees = null;
        List<clsReqrequete> _clsReqrequeteSuspendues = null;
        List<clsReqrequete> _clsReqrequeteRecus = null;

        private string _RQ_MONTANTTOTALCONTENTIEUX = "0";
        private string _RQ_NOMBRETOTALCONTENTIEUX = "0";
        private string _RQ_MONTANTTOTALCONTENTIEUXAPRES = "0";
        private string _RQ_NOMBRETOTALCONTENTIEUXAPRES = "0";

        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;

        #endregion

        #region ACCESSEURS

        public string PY_LIBELLE
        {
            get { return _PY_LIBELLE; }
            set { _PY_LIBELLE = value; }
        }
        public string AG_RAISONSOCIAL
        {
            get { return _AG_RAISONSOCIAL; }
            set { _AG_RAISONSOCIAL = value; }
        }
        public List<clsReqrequete> clsReqrequeteRecus
        {
            get { return _clsReqrequeteRecus; }
            set { _clsReqrequeteRecus = value; }
        }
        public List<clsReqrequete> clsReqrequeteEncours
        {
            get { return _clsReqrequeteEncours; }
            set { _clsReqrequeteEncours = value; }
        }
        public List<clsReqrequete> clsReqrequeteTraitees
        {
            get { return _clsReqrequeteTraitees; }
            set { _clsReqrequeteTraitees = value; }
        }
        public List<clsReqrequete> clsReqrequeteSuspendues
        {
            get { return _clsReqrequeteSuspendues; }
            set { _clsReqrequeteSuspendues = value; }
        }

        public string RQ_MONTANTTOTALCONTENTIEUX
        {
            get { return _RQ_MONTANTTOTALCONTENTIEUX; }
            set { _RQ_MONTANTTOTALCONTENTIEUX = value; }
        }
        public string RQ_NOMBRETOTALCONTENTIEUX
        {
            get { return _RQ_NOMBRETOTALCONTENTIEUX; }
            set { _RQ_NOMBRETOTALCONTENTIEUX = value; }
        }

        public string RQ_MONTANTTOTALCONTENTIEUXAPRES
        {
            get { return _RQ_MONTANTTOTALCONTENTIEUXAPRES; }
            set { _RQ_MONTANTTOTALCONTENTIEUXAPRES = value; }
        }
        public string RQ_NOMBRETOTALCONTENTIEUXAPRES
        {
            get { return _RQ_NOMBRETOTALCONTENTIEUXAPRES; }
            set { _RQ_NOMBRETOTALCONTENTIEUXAPRES = value; }
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

        public clsEditionEtatReclamation() { }

        public clsEditionEtatReclamation(clsEditionEtatReclamation clsEditionEtatReclamation)
        {
            this.AG_RAISONSOCIAL = clsEditionEtatReclamation.AG_RAISONSOCIAL;
            this.PY_LIBELLE = clsEditionEtatReclamation.PY_LIBELLE;

            this.clsReqrequeteRecus = clsEditionEtatReclamation.clsReqrequeteRecus;
            this.clsReqrequeteEncours = clsEditionEtatReclamation.clsReqrequeteEncours;
            this.clsReqrequeteTraitees = clsEditionEtatReclamation.clsReqrequeteTraitees;
            this.clsReqrequeteSuspendues = clsEditionEtatReclamation.clsReqrequeteSuspendues;
            this.RQ_MONTANTTOTALCONTENTIEUX = clsEditionEtatReclamation.RQ_MONTANTTOTALCONTENTIEUX;
            this.RQ_NOMBRETOTALCONTENTIEUX = clsEditionEtatReclamation.RQ_NOMBRETOTALCONTENTIEUX;
            this.RQ_MONTANTTOTALCONTENTIEUXAPRES = clsEditionEtatReclamation.RQ_MONTANTTOTALCONTENTIEUXAPRES;
            this.RQ_NOMBRETOTALCONTENTIEUXAPRES = clsEditionEtatReclamation.RQ_NOMBRETOTALCONTENTIEUXAPRES;
            //List<clsReqrequete> clsReqrequeteEncours = null;
            //List<clsReqrequete> clsReqrequeteTraitees = null;
            //List<clsReqrequete> clsReqrequeteSuspendues = null;


            this.clsResultat = clsEditionEtatReclamation.clsResultat;
            this.clsObjetEnvoi = clsEditionEtatReclamation.clsObjetEnvoi;
        }

        #endregion
    }
}
