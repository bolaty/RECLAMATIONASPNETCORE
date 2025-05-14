using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsParametre
    {
        private string _SO_CODESOCIETE = "";
        private string _PP_CODEPARAMETRE = "";
        private string _PP_LIBELLE = "";
        private double _PP_BORNEMIN = 0;
        private double _PP_BORNEMAX = 0;
        private double _PP_MONTANTMINI = 0;
        private double _PP_MONTANTMAXI = 0;
        private decimal _PP_TAUX = 0;
        private double _PP_MONTANT = 0;
        private string _PP_VALEUR = "";
        private string _PL_CODENUMCOMPTE = "";
        private string _PL_NUMCOMPTE = "";
        private string _PP_AFFICHER = "";
        private string _SL_CODEMESSAGE = "";
        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";


        public string SO_CODESOCIETE
        {
            get { return _SO_CODESOCIETE; }
            set { _SO_CODESOCIETE = value; }
        }
        public string PP_CODEPARAMETRE
        {
            get { return _PP_CODEPARAMETRE; }
            set { _PP_CODEPARAMETRE = value; }
        }
        public string PP_LIBELLE
        {
            get { return _PP_LIBELLE; }
            set { _PP_LIBELLE = value; }
        }
        public double PP_BORNEMIN
        {
            get { return _PP_BORNEMIN; }
            set { _PP_BORNEMIN = value; }
        }
        public double PP_BORNEMAX
        {
            get { return _PP_BORNEMAX; }
            set { _PP_BORNEMAX = value; }
        }
        public double PP_MONTANTMINI
        {
            get { return _PP_MONTANTMINI; }
            set { _PP_MONTANTMINI = value; }
        }
        public double PP_MONTANTMAXI
        {
            get { return _PP_MONTANTMAXI; }
            set { _PP_MONTANTMAXI = value; }
        }
        public decimal PP_TAUX
        {
            get { return _PP_TAUX; }
            set { _PP_TAUX = value; }
        }
        public double PP_MONTANT
        {
            get { return _PP_MONTANT; }
            set { _PP_MONTANT = value; }
        }
        public string PP_VALEUR
        {
            get { return _PP_VALEUR; }
            set { _PP_VALEUR = value; }
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
        public string PP_AFFICHER
        {
            get { return _PP_AFFICHER; }
            set { _PP_AFFICHER = value; }
        }

        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
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





        public clsParametre() { }

        public clsParametre(string SO_CODESOCIETE, string PP_CODEPARAMETRE, string PP_LIBELLE, double PP_BORNEMIN, double PP_BORNEMAX, double PP_MONTANTMINI, double PP_MONTANTMAXI, decimal PP_TAUX, double PP_MONTANT, string PP_VALEUR, string PL_CODENUMCOMPTE, string PL_NUMCOMPTE, string PP_AFFICHER)
        {
            this.SO_CODESOCIETE = SO_CODESOCIETE;
            this.PP_CODEPARAMETRE = PP_CODEPARAMETRE;
            this.PP_LIBELLE = PP_LIBELLE;
            this.PP_BORNEMIN = PP_BORNEMIN;
            this.PP_BORNEMAX = PP_BORNEMAX;
            this.PP_MONTANTMINI = PP_MONTANTMINI;
            this.PP_MONTANTMAXI = PP_MONTANTMAXI;
            this.PP_TAUX = PP_TAUX;
            this.PP_MONTANT = PP_MONTANT;
            this.PP_VALEUR = PP_VALEUR;
            this.PL_CODENUMCOMPTE = PL_CODENUMCOMPTE;
            this.PL_NUMCOMPTE = PL_NUMCOMPTE;
            this.PP_AFFICHER = PP_AFFICHER;
        }

        public clsParametre(clsParametre clsParametre)
        {
            SO_CODESOCIETE = clsParametre.SO_CODESOCIETE;
            PP_CODEPARAMETRE = clsParametre.PP_CODEPARAMETRE;
            PP_LIBELLE = clsParametre.PP_LIBELLE;
            PP_BORNEMIN = clsParametre.PP_BORNEMIN;
            PP_BORNEMAX = clsParametre.PP_BORNEMAX;
            PP_MONTANTMINI = clsParametre.PP_MONTANTMINI;
            PP_MONTANTMAXI = clsParametre.PP_MONTANTMAXI;
            PP_TAUX = clsParametre.PP_TAUX;
            PP_MONTANT = clsParametre.PP_MONTANT;
            PP_VALEUR = clsParametre.PP_VALEUR;
            PL_CODENUMCOMPTE = clsParametre.PL_CODENUMCOMPTE;
            PL_NUMCOMPTE = clsParametre.PL_NUMCOMPTE;
            PP_AFFICHER = clsParametre.PP_AFFICHER;
            SL_CODEMESSAGE = clsParametre.SL_CODEMESSAGE;
            SL_RESULTAT = clsParametre.SL_RESULTAT;
            SL_MESSAGE = clsParametre.SL_MESSAGE;




        }
    }
}
