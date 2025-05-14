using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.DTO.BusinessObjects
{
    public class clsExerciceDTO
    {
        //private string _AG_CODEAGENCE = "";
        private string _EX_EXERCICE = "";
        //      private DateTime _JT_DATEJOURNEETRAVAIL = DateTime.Parse("01/01/1900");
        //private DateTime _EX_DATEDEBUT = DateTime.Parse("01/01/1900");
        //private DateTime _EX_DATEFIN = DateTime.Parse("01/01/1900");
        //private string _EX_DESCEXERCICE = "";
        //private string _EX_ETATEXERCICE = "";
        //private DateTime _EX_DATESAISIE = DateTime.Parse("01/01/1900");
        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";
        private string _SL_CODEMESSAGE = "";


        //      public string AG_CODEAGENCE
        //{
        //	get { return _AG_CODEAGENCE; }
        //	set { _AG_CODEAGENCE = value; }
        //}
        public string EX_EXERCICE
        {
            get { return _EX_EXERCICE; }
            set { _EX_EXERCICE = value; }
        }

        //      public DateTime JT_DATEJOURNEETRAVAIL
        //{
        //          get { return _JT_DATEJOURNEETRAVAIL; }
        //          set { _JT_DATEJOURNEETRAVAIL = value; }
        //}
        //public DateTime EX_DATEDEBUT
        //{
        //	get { return _EX_DATEDEBUT; }
        //	set { _EX_DATEDEBUT = value; }
        //}
        //public DateTime EX_DATEFIN
        //{
        //	get { return _EX_DATEFIN; }
        //	set { _EX_DATEFIN = value; }
        //}
        //public string EX_DESCEXERCICE
        //{
        //	get { return _EX_DESCEXERCICE; }
        //	set { _EX_DESCEXERCICE = value; }
        //}
        //public string EX_ETATEXERCICE
        //{
        //	get { return _EX_ETATEXERCICE; }
        //	set { _EX_ETATEXERCICE = value; }
        //}
        //public DateTime EX_DATESAISIE
        //{
        //	get { return _EX_DATESAISIE; }
        //	set { _EX_DATESAISIE = value; }
        //}

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

        public clsExerciceDTO() { }



        public clsExerciceDTO(clsExerciceDTO clsExerciceDTO)
        {
            //AG_CODEAGENCE = clsExerciceDTO.AG_CODEAGENCE;
            EX_EXERCICE = clsExerciceDTO.EX_EXERCICE;
            //         JT_DATEJOURNEETRAVAIL = clsExerciceDTO.JT_DATEJOURNEETRAVAIL;
            //EX_DATEDEBUT = clsExerciceDTO.EX_DATEDEBUT;
            //EX_DATEFIN = clsExerciceDTO.EX_DATEFIN;
            //EX_DESCEXERCICE = clsExerciceDTO.EX_DESCEXERCICE;
            //EX_ETATEXERCICE = clsExerciceDTO.EX_ETATEXERCICE;
            //EX_DATESAISIE = clsExerciceDTO.EX_DATESAISIE;
            SL_RESULTAT = clsExerciceDTO.SL_RESULTAT;
            SL_MESSAGE = clsExerciceDTO.SL_MESSAGE;
            SL_CODEMESSAGE = clsExerciceDTO.SL_CODEMESSAGE;
        }
    }
}
