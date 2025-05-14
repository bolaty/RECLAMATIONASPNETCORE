using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace MgRequeteClients.Tools.Classes
{
    public class clsDate
    {
        private readonly static clsDate ClassesDate = new clsDate();
        public bool pvgTestSiDate(string vppValeurSaisie)
        {
            try
            {
                //Lui dire que le format de date est français (JJ/MM/AAAA)

                // IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);

                //DateTime dtTest = System.Convert.ToDateTime(vppValeurSaisie, culture);
                DateTime dt = DateTime.ParseExact(vppValeurSaisie, "dd/MM/yyyy", null);
                return true;
            }
            catch
            {
                return false;
                //XtraMessageBox.Show("Cette date n'est pas valide !");
            }
        }

        public static clsDate ClasseDate
        {
            get { return ClassesDate; }
        }

        public DateTime pvgDateAdd(DateTime vppDate, double vppDuree, string vppDureeType)
        {
            if (vppDureeType == "J") return DateAndTime.DateAdd("D", vppDuree - 1, vppDate);
            if (vppDureeType == "M") return DateAndTime.DateAdd("M", vppDuree, vppDate);
            return DateTime.Parse("01/01/1900");
        }



        public string pvgFormaterDate(string dateAFormater)
        {
            if (String.IsNullOrEmpty(dateAFormater))
            {
                return "01/01/1900";
            }
            else
            {
                return DateTime.Parse(dateAFormater).ToShortDateString();
            }
        }

    }
}
