using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsPlancomptable
    {
        private string _SO_CODESOCIETE = "";
        private string _AG_CODEAGENCE = "";

        private string _PL_CODENUMCOMPTE = "";
        private string _PL_NUMCOMPTE = "";
        private string _PL_LIBELLE = "";
        private string _PL_COMPTECOLLECTIF = "";
        private double _PL_REPORTDEBIT = 0;
        private double _PL_REPORTCREDIT = 0;
        private double _PL_MONTANTPERIODEPRECEDENTDEBIT = 0;
        private double _PL_MONTANTPERIODEPRECEDENTCREDIT = 0;
        private double _PL_MONTANTPERIODEDEBITENCOURS = 0;
        private double _PL_MONTANTPERIODECREDITENCOURS = 0;
        private double _PL_MONTANTSOLDEFINALDEBIT = 0;
        private double _PL_MONTANTSOLDEFINALCREDIT = 0;
        private double _PL_SOLDECOMPTE = 0;
        private string _PL_COMPTETIERS = "0";//Est-ce que le compte appartient à la table MICCOMPTEPRODUITSOUSPRODUIT
        private string _PL_SENS = "";
        private string _PL_TYPECOMPTE = "";
        private string _PL_ACTIF = "";
        private string _PL_COMPTEREFERENTIELCOMPTABLE = "";
        private string _PL_AUTORISEINVERSION = "";
        private string _PL_SAISIE_ANALYTIQUE = "";
        private string _PL_TESTSURCOMPTETIERS = "";
        public string SO_CODESOCIETE
        {
            get { return _SO_CODESOCIETE; }
            set { _SO_CODESOCIETE = value; }
        }
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public string PL_CODENUMCOMPTE
        {
            get { return _PL_CODENUMCOMPTE; }
            set { _PL_CODENUMCOMPTE = value; }
        }
        public string PL_NUMCOMPTE
        {
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
        }
        public string PL_LIBELLE
        {
            get { return _PL_LIBELLE; }
            set { _PL_LIBELLE = value; }
        }
        public string PL_COMPTECOLLECTIF
        {
            get { return _PL_COMPTECOLLECTIF; }
            set { _PL_COMPTECOLLECTIF = value; }
        }
        public double PL_REPORTDEBIT
        {
            get { return _PL_REPORTDEBIT; }
            set { _PL_REPORTDEBIT = value; }
        }
        public double PL_REPORTCREDIT
        {
            get { return _PL_REPORTCREDIT; }
            set { _PL_REPORTCREDIT = value; }
        }
        public double PL_MONTANTPERIODEPRECEDENTDEBIT
        {
            get { return _PL_MONTANTPERIODEPRECEDENTDEBIT; }
            set { _PL_MONTANTPERIODEPRECEDENTDEBIT = value; }
        }
        public double PL_MONTANTPERIODEPRECEDENTCREDIT
        {
            get { return _PL_MONTANTPERIODEPRECEDENTCREDIT; }
            set { _PL_MONTANTPERIODEPRECEDENTCREDIT = value; }
        }
        public double PL_MONTANTPERIODEDEBITENCOURS
        {
            get { return _PL_MONTANTPERIODEDEBITENCOURS; }
            set { _PL_MONTANTPERIODEDEBITENCOURS = value; }
        }
        public double PL_MONTANTPERIODECREDITENCOURS
        {
            get { return _PL_MONTANTPERIODECREDITENCOURS; }
            set { _PL_MONTANTPERIODECREDITENCOURS = value; }
        }
        public double PL_MONTANTSOLDEFINALDEBIT
        {
            get { return _PL_MONTANTSOLDEFINALDEBIT; }
            set { _PL_MONTANTSOLDEFINALDEBIT = value; }
        }
        public double PL_MONTANTSOLDEFINALCREDIT
        {
            get { return _PL_MONTANTSOLDEFINALCREDIT; }
            set { _PL_MONTANTSOLDEFINALCREDIT = value; }
        }
        public double PL_SOLDECOMPTE
        {
            get { return _PL_SOLDECOMPTE; }
            set { _PL_SOLDECOMPTE = value; }
        }

        public string PL_COMPTETIERS
        {
            get { return _PL_COMPTETIERS; }
            set { _PL_COMPTETIERS = value; }
        }

        public string PL_SENS
        {
            get { return _PL_SENS; }
            set { _PL_SENS = value; }
        }
        public string PL_TYPECOMPTE
        {
            get { return _PL_TYPECOMPTE; }
            set { _PL_TYPECOMPTE = value; }
        }
        public string PL_ACTIF
        {
            get { return _PL_ACTIF; }
            set { _PL_ACTIF = value; }
        }
        public string PL_COMPTEREFERENTIELCOMPTABLE
        {
            get { return _PL_COMPTEREFERENTIELCOMPTABLE; }
            set { _PL_COMPTEREFERENTIELCOMPTABLE = value; }
        }

        public string PL_AUTORISEINVERSION
        {
            get { return _PL_AUTORISEINVERSION; }
            set { _PL_AUTORISEINVERSION = value; }
        }

        public string PL_SAISIE_ANALYTIQUE
        {
            get { return _PL_SAISIE_ANALYTIQUE; }
            set { _PL_SAISIE_ANALYTIQUE = value; }
        }
        public string PL_TESTSURCOMPTETIERS
        {
            get { return _PL_TESTSURCOMPTETIERS; }
            set { _PL_TESTSURCOMPTETIERS = value; }
        }
        public clsPlancomptable() { }

        public clsPlancomptable(clsPlancomptable clsPlancomptable)
        {
            SO_CODESOCIETE = clsPlancomptable.SO_CODESOCIETE;
            AG_CODEAGENCE = clsPlancomptable.AG_CODEAGENCE;
            PL_CODENUMCOMPTE = clsPlancomptable.PL_CODENUMCOMPTE;
            PL_NUMCOMPTE = clsPlancomptable.PL_NUMCOMPTE;
            PL_LIBELLE = clsPlancomptable.PL_LIBELLE;
            PL_COMPTECOLLECTIF = clsPlancomptable.PL_COMPTECOLLECTIF;
            PL_REPORTDEBIT = clsPlancomptable.PL_REPORTDEBIT;
            PL_REPORTCREDIT = clsPlancomptable.PL_REPORTCREDIT;
            PL_MONTANTPERIODEPRECEDENTDEBIT = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTDEBIT;
            PL_MONTANTPERIODEPRECEDENTCREDIT = clsPlancomptable.PL_MONTANTPERIODEPRECEDENTCREDIT;
            PL_MONTANTPERIODEDEBITENCOURS = clsPlancomptable.PL_MONTANTPERIODEDEBITENCOURS;
            PL_MONTANTPERIODECREDITENCOURS = clsPlancomptable.PL_MONTANTPERIODECREDITENCOURS;
            PL_MONTANTSOLDEFINALDEBIT = clsPlancomptable.PL_MONTANTSOLDEFINALDEBIT;
            PL_MONTANTSOLDEFINALCREDIT = clsPlancomptable.PL_MONTANTSOLDEFINALCREDIT;
            PL_SOLDECOMPTE = clsPlancomptable.PL_SOLDECOMPTE;
            PL_COMPTETIERS = clsPlancomptable.PL_COMPTETIERS;
            PL_SENS = clsPlancomptable.PL_SENS;
            PL_TYPECOMPTE = clsPlancomptable.PL_TYPECOMPTE;
            PL_ACTIF = clsPlancomptable.PL_ACTIF;
            PL_COMPTEREFERENTIELCOMPTABLE = clsPlancomptable.PL_COMPTEREFERENTIELCOMPTABLE;
            PL_AUTORISEINVERSION = clsPlancomptable.PL_AUTORISEINVERSION;
            PL_SAISIE_ANALYTIQUE = clsPlancomptable.PL_SAISIE_ANALYTIQUE;
            PL_TESTSURCOMPTETIERS = clsPlancomptable.PL_TESTSURCOMPTETIERS;

        }
    }
}
