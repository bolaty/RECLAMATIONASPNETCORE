using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace MgRequeteClients.Tools.Classes
{
    public class clsChaineCaractere
    {

        #region  declaration unique de la classe

        //declaration unique de la classe clsChaineCaractere pour tout le projet
        private readonly static clsChaineCaractere ClassesChaineCaractere = new clsChaineCaractere();
        int vapCompteur = 0;

        //constructeur privé de la classe clsDeclaration
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsChaineCaractere()
        {
        }
        //constructeur public de la classe fonction 
        public static clsChaineCaractere ClasseChaineCaractere
        {
            get { return ClassesChaineCaractere; }
        }

        #endregion
        public bool pvgTestLibelle(string vppValeurSaisie)
        {
            bool vlpResultat = true;
            try
            {
                if (vppValeurSaisie.Length > 150)
                {
                    vlpResultat = false;
                }
                return vlpResultat;


            }
            catch
            {
                return false;
                //XtraMessageBox.Show("Cette date n'est pas valide !");
            }
        }
        public static string GetRandomAlphaNumeric()
        {
            Random random = new Random();
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(8).ToArray());
        }
        //'Extrait une chaine dans une autre chaîne de caractère 
        //en précisant le caractere de separation
        public string pvgExtraireChaine(string vppValeurChaine, string vppCaractereSeparation, string vppPositionDeDepart)
        {
            int i;
            string vppValeurChaineEnCours;
            if (vppPositionDeDepart == "G")
            {
                for (i = 1; i < vppValeurChaine.Length; i++)
                {
                    vppValeurChaineEnCours = vppValeurChaine.Substring(0, i);
                    if (vppValeurChaineEnCours.Contains(vppCaractereSeparation))
                    {
                        return vppValeurChaine.Substring(0, i - 1).Trim();
                    }
                }
            }
            else
            {
                for (i = 1; i < vppValeurChaine.Length; i++)
                {
                    vppValeurChaineEnCours = vppValeurChaine.Substring(0, i);
                    if (vppValeurChaineEnCours.Contains(vppCaractereSeparation)) break;
                }
                vppValeurChaineEnCours = vppValeurChaine.Substring(0, i).Trim();
                if (vppValeurChaineEnCours.Contains(vppCaractereSeparation))
                    return vppValeurChaine.Substring(vppValeurChaineEnCours.Length, vppValeurChaine.Length - vppValeurChaineEnCours.Length).Trim();
                else
                    return vppValeurChaine.Trim();
            }

            return vppValeurChaine.Substring(0, i - 1).Trim();
        }


        public string fpbCryptage(string strChaine, bool blnCryptage, string bvlCleCryptage)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            string strCryptKey = null;
            string strLettre = null;
            string strKeyLettre = null;
            int intLettre = 0;
            int intKeyLettre = 0;
            string strResultat = null;

            if (string.IsNullOrEmpty(strChaine))
            {
                return "";
            }

            strCryptKey = bvlCleCryptage;
            //"chiffrement de Vigenere"

            for (k = 0; k <= 10; k += 1)
            {
                strResultat = "";
                for (i = 1; i <= Strings.Len(strChaine); i += 1)
                {
                    strLettre = Strings.Mid(strChaine, i, 1);
                    j = i;
                    while (j > Strings.Len(strCryptKey))
                    {
                        j = j - Strings.Len(strCryptKey);
                    }
                    strKeyLettre = Strings.Mid(strCryptKey, j, 1);
                    intLettre = Strings.Asc(strLettre);
                    intKeyLettre = Strings.Asc(strKeyLettre);

                    if (blnCryptage == true)
                    {
                        intLettre = intLettre + (intKeyLettre * Strings.Len(strChaine));
                    }
                    else
                    {
                        intLettre = intLettre - (intKeyLettre * Strings.Len(strChaine));
                    }

                    while (intLettre > 255)
                    {
                        intLettre = intLettre - 255;
                    }
                    while (intLettre < 0)
                    {
                        intLettre = intLettre + 255;
                    }
                    strResultat = strResultat + Strings.Chr(intLettre);
                }
                strChaine = strResultat;
            }
            return strResultat;
        }
        //


        //'Extrait les codes dans une chaîne de caractère avec code et libellé
        public string pvgExtraireCode(string vppValeurChaine)
        {
            string vppValeurChaineEnCours;
            int i;
            for (i = 1; i < vppValeurChaine.Length; i++)
            {
                vppValeurChaineEnCours = vppValeurChaine.Substring(0, i);
                if (vppValeurChaineEnCours.Contains("-") || vppValeurChaineEnCours.Contains(".") || vppValeurChaineEnCours.Contains("(") || vppValeurChaineEnCours.Contains("|"))
                {
                    return vppValeurChaine.Substring(0, i - 1).Trim();
                }
            }
            return vppValeurChaine.Substring(0, i - 1).Trim();
        }

        //'Extrait les libellés dans une chaîne de caractère avec code et libéllé
        public string pvgExtraireLibellé(string vppValeurChaine)
        {
            string vppValeurChaineEnCours = "";
            int i;
            for (i = 1; i < vppValeurChaine.Length; i++)
            {
                vppValeurChaineEnCours = vppValeurChaine.Substring(0, i);
                if (vppValeurChaineEnCours.Contains("-"))// || vppValeurChaineEnCours.Contains(".") || vppValeurChaineEnCours.Contains("(") || vppValeurChaineEnCours.Contains("|")
                {
                    break;
                }
            }
            vppValeurChaineEnCours = vppValeurChaine.Substring(0, i).Trim();
            if (vppValeurChaineEnCours.Contains("-"))
            {
                return vppValeurChaine.Substring(vppValeurChaineEnCours.Length, vppValeurChaine.Length - vppValeurChaineEnCours.Length).Trim();//Trim(Right(BvlObjetTexte, Len(BvlObjetTexte) - Len(ppvObjet)))
            }
            else
            {
                return vppValeurChaine.Trim();
            }
        }

        public bool pvgValidationEmail(string email)
        {
            Regex _valideMail = new Regex(@"[a-zA-Z0-9_.-]{4,30}@{1}[a-zA-Z\d.-]{3,63}\.{1}[a-zA-Z]{2,4}");
            if (email != "")
            {
                if (_valideMail.IsMatch(email))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
            //set modele = New RegExp;
            //modele.pattern = "^[\w_.~-]+@[\w][\w.\-]*[\w]\.[\w][\w.]*[a-zA-Z]$";
            //modele.global = true;
            //ValidationEmail = modele.test(email);
        }
        public bool pvgValidationHeure(string vppHeure)
        {
            //Regex _valideMail = new Regex("([01][0-9]|2[0-3]):([0-5][0-9])");
            Regex _valideMail = new Regex("([0-1][0-9]|2[0-3]):([0-5][0-9])");
            if (vppHeure != "")
            {
                if (!_valideMail.IsMatch(vppHeure)) return false;
            }
            return true;
        }

        /// <summary>
        /// Cette fonction permet de crypter une chaine de caractere
        /// </summary>
        /// <param name="strChaine">chaine à crypter</param>
        /// <returns></returns>
        /// 

        public static string pvgCrypter(string strChaine)
        {
            if (string.IsNullOrEmpty(strChaine))
                return string.Empty;

            StringBuilder vlpValeur = new StringBuilder();

            for (int i = 0; i < strChaine.Length; i++)
            {
                vlpValeur.Append(pvgGenererCaractere(3));
                char currentChar = strChaine[i];

                switch (currentChar)
                {
                    #region MAJUSCULES
                    case 'A': vlpValeur.Append("PTTUI"); break;
                    case 'B': vlpValeur.Append("KDGER"); break;
                    case 'C': vlpValeur.Append("ORYHF"); break;
                    case 'D': vlpValeur.Append("QSCER"); break;
                    case 'E': vlpValeur.Append("SEWJU"); break;
                    case 'F': vlpValeur.Append("NHYUI"); break;
                    case 'G': vlpValeur.Append("LOMJF"); break;
                    case 'H': vlpValeur.Append(";LOPU"); break;
                    case 'I': vlpValeur.Append(",DEFG"); break;
                    case 'J': vlpValeur.Append("TYEWO"); break;
                    case 'K': vlpValeur.Append("XZSAQ"); break;
                    case 'L': vlpValeur.Append("M,KL;"); break;
                    case 'M': vlpValeur.Append("U;RTG"); break;
                    case 'N': vlpValeur.Append("DV.DF"); break;
                    case 'O': vlpValeur.Append("EH.,K"); break;
                    case 'P': vlpValeur.Append(":JHT,"); break;
                    case 'Q': vlpValeur.Append("B-012"); break;
                    case 'R': vlpValeur.Append("9URYT"); break;
                    case 'S': vlpValeur.Append("120GF"); break;
                    case 'T': vlpValeur.Append("0T1ER"); break;
                    case 'U': vlpValeur.Append("GR;,."); break;
                    case 'V': vlpValeur.Append("ET,IO"); break;
                    case 'W': vlpValeur.Append("5C#9@"); break;
                    case 'X': vlpValeur.Append("78JNB"); break;
                    case 'Y': vlpValeur.Append("3T45H"); break;
                    case 'Z': vlpValeur.Append("4ORTE"); break;
                    #endregion

                    #region MINUSCULE
                    case 'a': vlpValeur.Append("pttui"); break;
                    case 'b': vlpValeur.Append("kdger"); break;
                    case 'c': vlpValeur.Append("oryhf"); break;
                    case 'd': vlpValeur.Append("qscer"); break;
                    case 'e': vlpValeur.Append("sewju"); break;
                    case 'f': vlpValeur.Append("nhyui"); break;
                    case 'g': vlpValeur.Append("lomjf"); break;
                    case 'h': vlpValeur.Append(";lopu"); break;
                    case 'i': vlpValeur.Append(",defg"); break;
                    case 'j': vlpValeur.Append("tyewo"); break;
                    case 'k': vlpValeur.Append("xzsaq"); break;
                    case 'l': vlpValeur.Append("m,kl;"); break;
                    case 'm': vlpValeur.Append("u;rtg"); break;
                    case 'n': vlpValeur.Append("dv.df"); break;
                    case 'o': vlpValeur.Append("eh.,k"); break;
                    case 'p': vlpValeur.Append(":jht,"); break;
                    case 'q': vlpValeur.Append("b-012"); break;
                    case 'r': vlpValeur.Append("9uryt"); break;
                    case 's': vlpValeur.Append("120gf"); break;
                    case 't': vlpValeur.Append("0t1er"); break;
                    case 'u': vlpValeur.Append("gr;,."); break;
                    case 'v': vlpValeur.Append("et,io"); break;
                    case 'w': vlpValeur.Append("5c#9@"); break;
                    case 'x': vlpValeur.Append("78jnb"); break;
                    case 'y': vlpValeur.Append("3t45h"); break;
                    case 'z': vlpValeur.Append("4orte"); break;
                    #endregion

                    #region SYMBOLES
                    case ' ': vlpValeur.Append("W_HRT"); break;
                    case ':': vlpValeur.Append("#FyG7"); break;
                    case ',': vlpValeur.Append("=RaGD"); break;
                    case '?': vlpValeur.Append("+TDG."); break;
                    case '=': vlpValeur.Append("9-_EW"); break;
                    case '{': vlpValeur.Append("YTe74"); break;
                    case '}': vlpValeur.Append(";)9vR"); break;
                    case '(': vlpValeur.Append("[=-9T"); break;
                    case ')': vlpValeur.Append("A;lFJ"); break;
                    case '[': vlpValeur.Append("e49uE"); break;
                    case ']': vlpValeur.Append(".zaAw"); break;
                    case '.': vlpValeur.Append("qWegl"); break;
                    case '\\': vlpValeur.Append("kKwyu"); break;
                    case '@': vlpValeur.Append("y#udl"); break;
                    case '#': vlpValeur.Append("wen_-"); break;
                    case ';': vlpValeur.Append("A7oWe"); break;
                    #endregion

                    #region CHIFFRES
                    case '0': vlpValeur.Append("RE09="); break;
                    case '1': vlpValeur.Append("8UYRM"); break;
                    case '2': vlpValeur.Append("O9)50"); break;
                    case '3': vlpValeur.Append("%67RE"); break;
                    case '4': vlpValeur.Append("i56%W"); break;
                    case '5': vlpValeur.Append("IOPQW"); break;
                    case '6': vlpValeur.Append("R89-="); break;
                    case '7': vlpValeur.Append("{OTU-"); break;
                    case '8': vlpValeur.Append("}iT_e"); break;
                    case '9': vlpValeur.Append("}-=GF"); break;
                    #endregion

                    default:
                        // Remplacement de DevExpress.XtraEditors.XtraMessageBox.Show
                        Console.WriteLine($"Caractère non supporté: {currentChar}");
                        break;
                }
            }

            return vlpValeur.ToString();
        }

        private static string pvgGenererCaractere(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
        /// <summary>
        /// Cette fonction permet de décrypter une chaine de caractere
        /// </summary>
        /// <param name="strChaine">chaine à décrypter</param>
        /// <returns></returns>
        public string pvgDeCrypter(string strChaine)
        {

            string vlpValeurNette = "";
            while (strChaine.Length > 0)
            {
                //ici on extrait les caracteres de remplissage
                if (strChaine.Length > 0)
                {
                    strChaine = strChaine.Remove(0, 3);
                    vlpValeurNette += strChaine.Substring(0, 5);
                    strChaine = strChaine.Remove(0, 5);
                    if (strChaine.Length > 0 && strChaine.Length < 5)
                    {
                        vlpValeurNette = strChaine = "";
                    }
                }
            }

            string vlpValeur = "";
            for (int i = 0; i < vlpValeurNette.Length; i += 5)
            {
                switch (vlpValeurNette.Substring(i, 5))
                {
                    #region MAJUSCULES
                    case "PTTUI":
                        vlpValeur += "A";
                        break;
                    case "KDGER":
                        vlpValeur += "B";
                        break;
                    case "ORYHF":
                        vlpValeur += "C";
                        break;
                    case "QSCER":
                        vlpValeur += "D";
                        break;
                    case "SEWJU":
                        vlpValeur += "E";
                        break;
                    case "NHYUI":
                        vlpValeur += "F";
                        break;
                    case "LOMJF":
                        vlpValeur += "G";
                        break;
                    case ";LOPU":
                        vlpValeur += "H";
                        break;
                    case ",DEFG":
                        vlpValeur += "I";
                        break;
                    case "TYEWO":
                        vlpValeur += "J";
                        break;
                    case "XZSAQ":
                        vlpValeur += "K";
                        break;
                    case "M,KL;":
                        vlpValeur += "L";
                        break;
                    case "U;RTG":
                        vlpValeur += "M";
                        break;
                    case "DV.DF":
                        vlpValeur += "N";
                        break;
                    case "EH.,K":
                        vlpValeur += "O";
                        break;
                    case ":JHT,":
                        vlpValeur += "P";
                        break;
                    case "B-012":
                        vlpValeur += "Q";
                        break;
                    case "9URYT":
                        vlpValeur += "R";
                        break;
                    case "120GF":
                        vlpValeur += "S";
                        break;
                    case "0T1ER":
                        vlpValeur += "T";
                        break;
                    case "GR;,.":
                        vlpValeur += "U";
                        break;
                    case "ET,IO":
                        vlpValeur += "V";
                        break;
                    case "5C#9@":
                        vlpValeur += "W";
                        break;
                    case "78JNB":
                        vlpValeur += "X";
                        break;
                    case "3T45H":
                        vlpValeur += "Y";
                        break;
                    case "4ORTE":
                        vlpValeur += "Z";
                        break;

                    #endregion Majuscule
                    #region MINUSCULE
                    case "pttui":
                        vlpValeur += "a";
                        break;
                    case "kdger":
                        vlpValeur += "b";
                        break;
                    case "oryhf":
                        vlpValeur += "c";
                        break;
                    case "qscer":
                        vlpValeur += "d";
                        break;
                    case "sewju":
                        vlpValeur += "e";
                        break;
                    case "nhyui":
                        vlpValeur += "f";
                        break;
                    case "lomjf":
                        vlpValeur += "g";
                        break;
                    case ";lopu":
                        vlpValeur += "h";
                        break;
                    case ",defg":
                        vlpValeur += "i";
                        break;
                    case "tyewo":
                        vlpValeur += "j";
                        break;
                    case "xzsaq":
                        vlpValeur += "k";
                        break;
                    case "m,kl;":
                        vlpValeur += "l";
                        break;
                    case "u;rtg":
                        vlpValeur += "m";
                        break;
                    case "dv.df":
                        vlpValeur += "n";
                        break;
                    case "eh.,k":
                        vlpValeur += "o";
                        break;
                    case ":jht,":
                        vlpValeur += "p";
                        break;
                    case "b-012":
                        vlpValeur += "q";
                        break;
                    case "9uryt":
                        vlpValeur += "r";
                        break;
                    case "120gf":
                        vlpValeur += "s";
                        break;
                    case "0t1er":
                        vlpValeur += "t";
                        break;
                    case "gr;,.":
                        vlpValeur += "u";
                        break;
                    case "et,io":
                        vlpValeur += "v";
                        break;
                    case "5c#9@":
                        vlpValeur += "w";
                        break;
                    case "78jnb":
                        vlpValeur += "x";
                        break;
                    case "3t45h":
                        vlpValeur += "y";
                        break;
                    case "4orte":
                        vlpValeur += "z";
                        break;
                    #endregion MINUSCULE
                    #region SYMBOLES
                    case "W_HRT":
                        vlpValeur += " ";
                        break;
                    case "#FyG7":
                        vlpValeur += ":";
                        break;
                    case "=RaGD":
                        vlpValeur += ",";
                        break;
                    case "+TDG.":
                        vlpValeur += "?";
                        break;
                    case "9-_EW":
                        vlpValeur += "=";
                        break;
                    case "YTe74":
                        vlpValeur += "{";
                        break;
                    case ";)9vR":
                        vlpValeur += "}";
                        break;
                    case "[=-9T":
                        vlpValeur += "(";
                        break;
                    case "A;lFJ":
                        vlpValeur += ")";
                        break;
                    case "e49uE":
                        vlpValeur += "[";
                        break;
                    case ".zaAw":
                        vlpValeur += "]";
                        break;
                    case "qWegl":
                        vlpValeur += ".";
                        break;
                    case "kKwyu":
                        vlpValeur += "\\";
                        break;
                    case "y#udl":
                        vlpValeur += "@";
                        break;
                    case "wen_-":
                        vlpValeur += "#";
                        break;
                    case "A7oWe":
                        vlpValeur += ";";
                        break;
                    #endregion SYMBOLES
                    #region CHIFFRES
                    case "RE09=":
                        vlpValeur += "0";
                        break;
                    case "8UYRM":
                        vlpValeur += "1";
                        break;
                    case "O9)50":
                        vlpValeur += "2";
                        break;
                    case "%67RE":
                        vlpValeur += "3";
                        break;
                    case "i56%W":
                        vlpValeur += "4";
                        break;
                    case "IOPQW":
                        vlpValeur += "5";
                        break;
                    case "R89-=":
                        vlpValeur += "6";
                        break;
                    case "{OTU-":
                        vlpValeur += "7";
                        break;
                    case "}iT_e":
                        vlpValeur += "8";
                        break;
                    case "}-=GF":
                        vlpValeur += "9";
                        break;
                        #endregion CHIFFRES
                }

            }
            return vlpValeur;
        }

        /// <summary>
        /// cette procedure permet de generer un numero de bordereau 
        /// </summary>
        /// <param name="vppChaineFixe">chaine fixe de debut</param>
        /// <param name="vppChaineAFormater">chaine a formater</param>
        /// <param name="vppLongueurFormat">longueur du formatage</param>
        /// <returns></returns>
        public string pvgGenererCode(string vppChaineFixe, string vppChaineAFormater, int vppLongueurFormat)
        {
            try
            {
                string vlpChaineFormat = "{0:0";
                for (int i = 0; i < vppLongueurFormat - 1; i++)
                {
                    vlpChaineFormat += "0";
                }
                vlpChaineFormat += "}";
                vppChaineFixe += String.Format(vlpChaineFormat, vppChaineAFormater);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return vppChaineFixe;
        }


    }
}
