using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsEditionEtatGuichet
    {
        //    @AG_CODEAGENCE varchar(25),
        //@DATEDEBUT AS DATETIME,
        //@DATEFIN AS DATETIME,
        //@OP_CODEOPERATEUREDITION AS VARCHAR(25),
        //@TYPEETAT as varchar(50),


        private string _AG_CODEAGENCE = "";
        private string _PV_CODEPOINTVENTE = "";
        private string _DATEDEBUT = "";
        private string _DATEFIN = "";
        private string _OP_CODEOPERATEUREDITION = "";
        private string _PL_CODENUMCOMPTE1 = "";
        private string _PL_CODENUMCOMPTE2 = "";
        private string _TS_CODETYPESCHEMACOMPTABLE = "";
        private string _JO_CODEJOURNAL = "";
        private string _OP_CODEOPERATEUR = "";
        private string _TYPEETAT = "";
        private string _TYPERETOUR = "";
        private string _TYPEECRAN = "";
        private string _NBRELIGNE = "";
        private string _SUPPRIMERTABLEINTERMEDIAIRE = "";
        private string _LG_CODELANGUE = "";
        private string _MC_NUMPIECEPARAMETRE = "";
        private string _PL_CODENUMCOMPTE1CLIENT = "";
        private string _PL_CODENUMCOMPTE2CLIENT = "";

        private string _CL_CODECLIENT = "";
        private string _CL_IDCLIENT = "";
        private string _MB_IDTIERS = "";
        private string _CT_IDCARTE = "";
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
        public string PV_CODEPOINTVENTE
        {
            get { return _PV_CODEPOINTVENTE; }
            set { _PV_CODEPOINTVENTE = value; }
        }

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
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



        public string OP_CODEOPERATEUREDITION
        {
            get { return _OP_CODEOPERATEUREDITION; }
            set { _OP_CODEOPERATEUREDITION = value; }
        }

        public string TYPEETAT
        {
            get { return _TYPEETAT; }
            set { _TYPEETAT = value; }
        }
        public string TYPERETOUR
        {
            get { return _TYPERETOUR; }
            set { _TYPERETOUR = value; }
        }



        public string TYPEECRAN
        {
            get { return _TYPEECRAN; }
            set { _TYPEECRAN = value; }
        }


        public string SUPPRIMERTABLEINTERMEDIAIRE
        {
            get { return _SUPPRIMERTABLEINTERMEDIAIRE; }
            set { _SUPPRIMERTABLEINTERMEDIAIRE = value; }
        }
        public string PL_CODENUMCOMPTE1
        {
            get { return _PL_CODENUMCOMPTE1; }
            set { _PL_CODENUMCOMPTE1 = value; }
        }
        public string PL_CODENUMCOMPTE2
        {
            get { return _PL_CODENUMCOMPTE2; }
            set { _PL_CODENUMCOMPTE2 = value; }
        }
        public string TS_CODETYPESCHEMACOMPTABLE
        {
            get { return _TS_CODETYPESCHEMACOMPTABLE; }
            set { _TS_CODETYPESCHEMACOMPTABLE = value; }
        }
        public string JO_CODEJOURNAL
        {
            get { return _JO_CODEJOURNAL; }
            set { _JO_CODEJOURNAL = value; }
        }
        public string NBRELIGNE
        {
            get { return _NBRELIGNE; }
            set { _NBRELIGNE = value; }
        }

        public string LG_CODELANGUE
        {
            get { return _LG_CODELANGUE; }
            set { _LG_CODELANGUE = value; }
        }
        public string MC_NUMPIECEPARAMETRE
        {
            get { return _MC_NUMPIECEPARAMETRE; }
            set { _MC_NUMPIECEPARAMETRE = value; }
        }
        public string PL_CODENUMCOMPTE1CLIENT
        {
            get { return _PL_CODENUMCOMPTE1CLIENT; }
            set { _PL_CODENUMCOMPTE1CLIENT = value; }
        }

        public string PL_CODENUMCOMPTE2CLIENT
        {
            get { return _PL_CODENUMCOMPTE2CLIENT; }
            set { _PL_CODENUMCOMPTE2CLIENT = value; }
        }
        public string CL_CODECLIENT
        {
            get { return _CL_CODECLIENT; }
            set { _CL_CODECLIENT = value; }
        }
        public string CL_IDCLIENT
        {
            get { return _CL_IDCLIENT; }
            set { _CL_IDCLIENT = value; }
        }
        public string MB_IDTIERS
        {
            get { return _MB_IDTIERS; }
            set { _MB_IDTIERS = value; }
        }
        public string CT_IDCARTE
        {
            get { return _CT_IDCARTE; }
            set { _CT_IDCARTE = value; }
        }



        //private string _CL_CODECLIENT = "";
        //private string _CL_IDCLIENT = "";
        //private string _MB_IDTIERS = "";
        //private DateTime _MC_DATEPIECE1 = DateTime.Parse("01/01/1900");
        //private DateTime _MC_DATEPIECE2 = DateTime.Parse("01/01/1900");


        public clsEditionEtatGuichet() { }



        public clsEditionEtatGuichet(clsEditionEtatGuichet clsEditionEtatGuichet)
        {
            AG_CODEAGENCE = clsEditionEtatGuichet.AG_CODEAGENCE;
            PV_CODEPOINTVENTE = clsEditionEtatGuichet.PV_CODEPOINTVENTE;
            DATEDEBUT = clsEditionEtatGuichet.DATEDEBUT;
            DATEFIN = clsEditionEtatGuichet.DATEFIN;
            OP_CODEOPERATEUREDITION = clsEditionEtatGuichet.OP_CODEOPERATEUREDITION;
            PL_CODENUMCOMPTE1 = clsEditionEtatGuichet.PL_CODENUMCOMPTE1;
            PL_CODENUMCOMPTE2 = clsEditionEtatGuichet.PL_CODENUMCOMPTE2;
            TS_CODETYPESCHEMACOMPTABLE = clsEditionEtatGuichet.TS_CODETYPESCHEMACOMPTABLE;
            JO_CODEJOURNAL = clsEditionEtatGuichet.JO_CODEJOURNAL;
            OP_CODEOPERATEUR = clsEditionEtatGuichet.OP_CODEOPERATEUR;
            TYPEETAT = clsEditionEtatGuichet.TYPEETAT;
            TYPERETOUR = clsEditionEtatGuichet.TYPERETOUR;
            TYPEECRAN = clsEditionEtatGuichet.TYPEECRAN;
            NBRELIGNE = clsEditionEtatGuichet.NBRELIGNE;
            SUPPRIMERTABLEINTERMEDIAIRE = clsEditionEtatGuichet.SUPPRIMERTABLEINTERMEDIAIRE;
            MC_NUMPIECEPARAMETRE = clsEditionEtatGuichet.MC_NUMPIECEPARAMETRE;
            PL_CODENUMCOMPTE1CLIENT = clsEditionEtatGuichet.PL_CODENUMCOMPTE1CLIENT;
            PL_CODENUMCOMPTE2CLIENT = clsEditionEtatGuichet.PL_CODENUMCOMPTE2CLIENT;
            CL_CODECLIENT = clsEditionEtatGuichet.CL_CODECLIENT;
            CL_IDCLIENT = clsEditionEtatGuichet.CL_IDCLIENT;
            MB_IDTIERS = clsEditionEtatGuichet.MB_IDTIERS;
            CT_IDCARTE = clsEditionEtatGuichet.CT_IDCARTE;

        }
    }
    }
