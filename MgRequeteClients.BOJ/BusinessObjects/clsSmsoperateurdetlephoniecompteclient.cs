using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsSmsoperateurdetlephoniecompteclient
    {

        #region VARIABLES LOCALES

        private string _AG_CODEAGENCE = "";
        private string _CL_CODECOMPTECLIENT = "0";
        private string _SM_CODEOPERATEURDETELEPHONIE = "";
        private string _CL_IDCLINENT = "";
        private string _CL_NOMUTILISATEUR = "";
        private string _CL_MOTDEPASSE = "";
        private string _CL_EMETTEUR = "";
        private string _CL_TYPEURL = "";
        private string _CL_URL = "";
        private string _CL_STATUT = "";
        private string _TYPEOPERATION = "";
        #endregion

        #region ACCESSEURS

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public string CL_CODECOMPTECLIENT
        {
            get { return _CL_CODECOMPTECLIENT; }
            set { _CL_CODECOMPTECLIENT = value; }
        }

        public string SM_CODEOPERATEURDETELEPHONIE
        {
            get { return _SM_CODEOPERATEURDETELEPHONIE; }
            set { _SM_CODEOPERATEURDETELEPHONIE = value; }
        }

        public string CL_IDCLINENT
        {
            get { return _CL_IDCLINENT; }
            set { _CL_IDCLINENT = value; }
        }

        public string CL_NOMUTILISATEUR
        {
            get { return _CL_NOMUTILISATEUR; }
            set { _CL_NOMUTILISATEUR = value; }
        }

        public string CL_MOTDEPASSE
        {
            get { return _CL_MOTDEPASSE; }
            set { _CL_MOTDEPASSE = value; }
        }

        public string CL_EMETTEUR
        {
            get { return _CL_EMETTEUR; }
            set { _CL_EMETTEUR = value; }
        }

        public string CL_TYPEURL
        {
            get { return _CL_TYPEURL; }
            set { _CL_TYPEURL = value; }
        }

        public string CL_URL
        {
            get { return _CL_URL; }
            set { _CL_URL = value; }
        }

        public string CL_STATUT
        {
            get { return _CL_STATUT; }
            set { _CL_STATUT = value; }
        }
        public string TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsSmsoperateurdetlephoniecompteclient() { }

        public clsSmsoperateurdetlephoniecompteclient(clsSmsoperateurdetlephoniecompteclient clsSmsoperateurdetlephoniecompteclient)
        {
            this.AG_CODEAGENCE = clsSmsoperateurdetlephoniecompteclient.AG_CODEAGENCE;
            this.CL_CODECOMPTECLIENT = clsSmsoperateurdetlephoniecompteclient.CL_CODECOMPTECLIENT;
            this.SM_CODEOPERATEURDETELEPHONIE = clsSmsoperateurdetlephoniecompteclient.SM_CODEOPERATEURDETELEPHONIE;
            this.CL_IDCLINENT = clsSmsoperateurdetlephoniecompteclient.CL_IDCLINENT;
            this.CL_NOMUTILISATEUR = clsSmsoperateurdetlephoniecompteclient.CL_NOMUTILISATEUR;
            this.CL_MOTDEPASSE = clsSmsoperateurdetlephoniecompteclient.CL_MOTDEPASSE;
            this.CL_EMETTEUR = clsSmsoperateurdetlephoniecompteclient.CL_EMETTEUR;
            this.CL_TYPEURL = clsSmsoperateurdetlephoniecompteclient.CL_TYPEURL;
            this.CL_URL = clsSmsoperateurdetlephoniecompteclient.CL_URL;
            this.CL_STATUT = clsSmsoperateurdetlephoniecompteclient.CL_STATUT;
            this.TYPEOPERATION = clsSmsoperateurdetlephoniecompteclient.TYPEOPERATION;

        }

        #endregion


    }
}
