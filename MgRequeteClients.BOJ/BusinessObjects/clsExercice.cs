using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.BOJ.BusinessObjects
{
    public class clsExercice
    {
        private string _AG_CODEAGENCE = "";
        private string _EX_EXERCICE = "";
        private DateTime _JT_DATEJOURNEETRAVAIL = DateTime.Parse("01/01/1900");
        private DateTime _EX_DATEDEBUT = DateTime.Parse("01/01/1900");
        private DateTime _EX_DATEFIN = DateTime.Parse("01/01/1900");

        private DateTime _EX_DATEDEBUTBILAN = DateTime.Parse("01/01/1900");
        private DateTime _EX_DATEFINBILAN = DateTime.Parse("01/01/1900");
        private DateTime _EX_DATEAFFECTATIONRESULTAT = DateTime.Parse("01/01/1900");

        private string _EX_DESCEXERCICE = "";
        private string _EX_ETATEXERCICE = "";
        private string _EX_DOUBLEEXERCICE = "";


        private DateTime _EX_DATESAISIE = DateTime.Parse("01/01/1900");



        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
        public string EX_EXERCICE
        {
            get { return _EX_EXERCICE; }
            set { _EX_EXERCICE = value; }
        }

        public DateTime JT_DATEJOURNEETRAVAIL
        {
            get { return _JT_DATEJOURNEETRAVAIL; }
            set { _JT_DATEJOURNEETRAVAIL = value; }
        }
        public DateTime EX_DATEDEBUT
        {
            get { return _EX_DATEDEBUT; }
            set { _EX_DATEDEBUT = value; }
        }
        public DateTime EX_DATEFIN
        {
            get { return _EX_DATEFIN; }
            set { _EX_DATEFIN = value; }
        }
        public string EX_DESCEXERCICE
        {
            get { return _EX_DESCEXERCICE; }
            set { _EX_DESCEXERCICE = value; }
        }
        public string EX_ETATEXERCICE
        {
            get { return _EX_ETATEXERCICE; }
            set { _EX_ETATEXERCICE = value; }
        }
        public string EX_DOUBLEEXERCICE
        {
            get { return _EX_DOUBLEEXERCICE; }
            set { _EX_DOUBLEEXERCICE = value; }
        }
        public DateTime EX_DATESAISIE
        {
            get { return _EX_DATESAISIE; }
            set { _EX_DATESAISIE = value; }
        }
        public DateTime EX_DATEDEBUTBILAN
        {
            get { return _EX_DATEDEBUTBILAN; }
            set { _EX_DATEDEBUTBILAN = value; }
        }
        public DateTime EX_DATEFINBILAN
        {
            get { return _EX_DATEFINBILAN; }
            set { _EX_DATEFINBILAN = value; }
        }
        public DateTime EX_DATEAFFECTATIONRESULTAT
        {
            get { return _EX_DATEAFFECTATIONRESULTAT; }
            set { _EX_DATEAFFECTATIONRESULTAT = value; }
        }
        public clsExercice() { }

        public clsExercice(string AG_CODEAGENCE, string EX_EXERCICE, DateTime JT_DATEJOURNEETRAVAIL, DateTime EX_DATEDEBUT, DateTime EX_DATEFIN, string EX_DESCEXERCICE, string EX_ETATEXERCICE, DateTime EX_DATESAISIE)
        {
            this.AG_CODEAGENCE = AG_CODEAGENCE;
            this.EX_EXERCICE = EX_EXERCICE;
            this.JT_DATEJOURNEETRAVAIL = JT_DATEJOURNEETRAVAIL;
            this.EX_DOUBLEEXERCICE = EX_DOUBLEEXERCICE;
            this.EX_DATEDEBUT = EX_DATEDEBUT;
            this.EX_DATEFIN = EX_DATEFIN;
            this.EX_DESCEXERCICE = EX_DESCEXERCICE;
            this.EX_ETATEXERCICE = EX_ETATEXERCICE;
            this.EX_DATESAISIE = EX_DATESAISIE;
        }

        public clsExercice(clsExercice clsExercice)
        {
            AG_CODEAGENCE = clsExercice.AG_CODEAGENCE;
            EX_EXERCICE = clsExercice.EX_EXERCICE;
            JT_DATEJOURNEETRAVAIL = clsExercice.JT_DATEJOURNEETRAVAIL;
            EX_DOUBLEEXERCICE = clsExercice.EX_DOUBLEEXERCICE;
            EX_DATEDEBUT = clsExercice.EX_DATEDEBUT;
            EX_DATEFIN = clsExercice.EX_DATEFIN;
            EX_DESCEXERCICE = clsExercice.EX_DESCEXERCICE;
            EX_ETATEXERCICE = clsExercice.EX_ETATEXERCICE;
            EX_DATESAISIE = clsExercice.EX_DATESAISIE;


            EX_DATEDEBUTBILAN = clsExercice.EX_DATEDEBUTBILAN;
            EX_DATEFINBILAN = clsExercice.EX_DATEFINBILAN;
            EX_DATEAFFECTATIONRESULTAT = clsExercice.EX_DATEAFFECTATIONRESULTAT;

        }
    }
}
