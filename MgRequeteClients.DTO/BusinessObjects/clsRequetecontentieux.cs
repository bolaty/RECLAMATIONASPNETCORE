﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsRequetecontentieux
    {
        #region VARIABLES LOCALES

        private string _CT_CODEREQUETECONTENTIEUX = "";
        private string _RQ_CODEREQUETE = "";
        private string _CT_DATEOUVERTURECONTENTIEUX = "01/01/1900";
        private string _CT_DATECLOTURECONTENTIEUX = "01/01/1900";
        private string _CT_MONTANTCONTENTIEUXEXTIME = "0";
        private string _CT_MONTANTCONTENTIEUXREEL = "0";
        private string _CT_OBSERVATION1 = "";
        private string _CT_OBSERVATION2 = "";
        private string _FICHIERSJOINT = "";
        private clsResultat _clsResultat;
        private clsObjetEnvoi _clsObjetEnvoi;
        private string _CU_CODECOMPTEUTULISATEUR = "";
        #endregion

        #region ACCESSEURS
        public string CU_CODECOMPTEUTULISATEUR
        {
            get { return _CU_CODECOMPTEUTULISATEUR; }
            set { _CU_CODECOMPTEUTULISATEUR = value; }
        }
        public string CT_CODEREQUETECONTENTIEUX
        {
            get { return _CT_CODEREQUETECONTENTIEUX; }
            set { _CT_CODEREQUETECONTENTIEUX = value; }
        }

        public string RQ_CODEREQUETE
        {
            get { return _RQ_CODEREQUETE; }
            set { _RQ_CODEREQUETE = value; }
        }

        public string CT_DATEOUVERTURECONTENTIEUX
        {
            get { return _CT_DATEOUVERTURECONTENTIEUX; }
            set { _CT_DATEOUVERTURECONTENTIEUX = value; }
        }

        public string CT_DATECLOTURECONTENTIEUX
        {
            get { return _CT_DATECLOTURECONTENTIEUX; }
            set { _CT_DATECLOTURECONTENTIEUX = value; }
        }

        public string CT_MONTANTCONTENTIEUXEXTIME
        {
            get { return _CT_MONTANTCONTENTIEUXEXTIME; }
            set { _CT_MONTANTCONTENTIEUXEXTIME = value; }
        }

        public string CT_MONTANTCONTENTIEUXREEL
        {
            get { return _CT_MONTANTCONTENTIEUXREEL; }
            set { _CT_MONTANTCONTENTIEUXREEL = value; }
        }

        public string CT_OBSERVATION1
        {
            get { return _CT_OBSERVATION1; }
            set { _CT_OBSERVATION1 = value; }
        }

        public string CT_OBSERVATION2
        {
            get { return _CT_OBSERVATION2; }
            set { _CT_OBSERVATION2 = value; }
        }

        public string FICHIERSJOINT
        {
            get { return _FICHIERSJOINT; }
            set { _FICHIERSJOINT = value; }
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

        public clsRequetecontentieux() { }

        public clsRequetecontentieux(clsRequetecontentieux clsRequetecontentieux)
        {
            this.CT_CODEREQUETECONTENTIEUX = clsRequetecontentieux.CT_CODEREQUETECONTENTIEUX;
            this.RQ_CODEREQUETE = clsRequetecontentieux.RQ_CODEREQUETE;
            this.CT_DATEOUVERTURECONTENTIEUX = clsRequetecontentieux.CT_DATEOUVERTURECONTENTIEUX;
            this.CT_DATECLOTURECONTENTIEUX = clsRequetecontentieux.CT_DATECLOTURECONTENTIEUX;
            this.CT_MONTANTCONTENTIEUXEXTIME = clsRequetecontentieux.CT_MONTANTCONTENTIEUXEXTIME;
            this.CT_MONTANTCONTENTIEUXREEL = clsRequetecontentieux.CT_MONTANTCONTENTIEUXREEL;
            this.CT_OBSERVATION1 = clsRequetecontentieux.CT_OBSERVATION1;
            this.CT_OBSERVATION2 = clsRequetecontentieux.CT_OBSERVATION2;
            this.FICHIERSJOINT = clsRequetecontentieux.FICHIERSJOINT;
            this.clsResultat = clsRequetecontentieux.clsResultat;
            this.clsObjetEnvoi = clsRequetecontentieux.clsObjetEnvoi;
            this.CU_CODECOMPTEUTULISATEUR = clsRequetecontentieux.CU_CODECOMPTEUTULISATEUR;
        }

        #endregion

    }
}
