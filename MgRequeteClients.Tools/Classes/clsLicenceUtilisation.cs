using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgRequeteClients.Tools.Classes
{
    public class clsLicenceUtilisation
    {
        #region  declaration unique de la classe

        //declaration unique de la classe clsLicenceUtilisation pour tout le projet
        private readonly static clsLicenceUtilisation ClasseLicenceUtilisation = new clsLicenceUtilisation();

        //constructeur privé de la classe clsDeclaration
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsLicenceUtilisation()
        {
        }
        //constructeur public de la classe fonction 
        public static clsLicenceUtilisation ClassecLicenceUtilisation
        {
            get { return ClasseLicenceUtilisation; }
        }

        #endregion

        ///<summary>Cette fonction permet de recupérer la valeur de la garantie d'un véhicule donnée,et aussi toutes les réductions liées à la garantie</summary>
        ///<returns>Un clsPrimeauto comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public bool pvgControlAdressesMACs
        (List<string[]> maList)
        {
            if (maList.Count > 0)
            {
                string[] vlpAdresseMac;
                for (int i = 0; i < maList.Count; i++)
                {
                    vlpAdresseMac = maList[i];
                    if (pvgTestAdresseMAC(vlpAdresseMac[1].ToString())) return true;
                }
            }
            return false;
        }



        ///<summary>Cette fonction permet de recupérer la valeur de la garantie 
        ///d'un véhicule donnée,et aussi toutes les réductions liées à la garantie</summary>
        ///<returns>Un clsPrimeauto comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public bool pvgTestAdresseMAC(string vppAdresseMAC)
        {
            MgRequeteClients.Tools.Classes.clsDeclaration.vagObjetEnvoi.POINTVENTE = false;
            //1-MON PROPRE PC
            if (vppAdresseMAC == "08:00:27:00:74:9F" || vppAdresseMAC == "F0:BF:97:02:79:5D"
                || vppAdresseMAC == "00:0F:B0:9C:0C:1F" || vppAdresseMAC == "0A:00:27:00:00:08")
            {
                //MgRequeteClients.Tools.clsDeclaration.vagObjetEnvoi.POINTVENTE = true;
                return true;
            }

            //4-PC DE CEFA GABIADJI
            else if (
                vppAdresseMAC == "70:71:BC:69:6B:76" || vppAdresseMAC == "EC:A8:6B:62:D7:BB" ||
                vppAdresseMAC == "00:21:5A:5D:5B:64" || vppAdresseMAC == "00:14:2A:CB:01:31" ||
                vppAdresseMAC == "3C:D9:2B:79:7C:92" || vppAdresseMAC == "F4:CE:46:F2:C9:DA" ||
                vppAdresseMAC == "F4:CE:46:F2:BE:58" || vppAdresseMAC == "F4:CE:46:F2:4D:5E" ||
                vppAdresseMAC == "70:71:BC:54:C5:2D" || vppAdresseMAC == "EC:A8:6B:60:A0:AD" ||
                vppAdresseMAC == "88:51:FB:57:77:A9" || vppAdresseMAC == "88:51:FB:57:77:F4"
                || vppAdresseMAC == "78:45:C4:1F:AA:FA" || vppAdresseMAC == "88:51:FB:57:77:A9"
                || vppAdresseMAC == "88:51:FB:57:77:F4" || vppAdresseMAC == "78:84:3C:F6:21:8E"
                || vppAdresseMAC == "94:39:E5:B5:A5:E7"
                )
            {
                return true;
            }
            //5-PC CREDIT FEF
            else if (
                //I-ORDINATEURS DU SIEGE
                //SERVEUR
                vppAdresseMAC == "E0:07:1B:FF:73:29"
                //DIRECTEUR RISQUE
                || vppAdresseMAC == "50:65:F3:39:88:F5"
                //DRH
                || vppAdresseMAC == "50:65:F3:39:87:E5"
                //DC
                || vppAdresseMAC == "50:65:F3:39:8F:3E"
                //DE
                || vppAdresseMAC == "50:65:F3:39:8F:4C"
                //C CLIENTELE  
                || vppAdresseMAC == "50:65:F3:39:85:21"
                //RESPONSABLE CAISSE
                || vppAdresseMAC == "50:65:F3:39:8F:64"
                //CS CREDIT
                || vppAdresseMAC == "50:65:F3:39:92:C4"
                //CS CONTROLE   
                || vppAdresseMAC == "50:65:F3:3A:06:E2"
                //M GENERAUX  
                || vppAdresseMAC == "50:65:F3:39:8E:8A"
                //DAF  
                || vppAdresseMAC == "50:65:F3:3B:88:3A"
                //DG BUREAU  
                || vppAdresseMAC == "50:65:F3:4E:20:83"

                //23/06/2018

                //AUDITEUR INTERNE   
                || vppAdresseMAC == "10:E7:C6:A5:C4:CE"//Ethernet
                || vppAdresseMAC == "80:C5:F2:73:A8:4D"//Wifi

                //CAISSIERE GENERALE  
                || vppAdresseMAC == "10:E7:C6:A5:CA:4E"//Ethernet
                || vppAdresseMAC == "80:C5:F2:73:A8:4B"//Wifi

                //COMPTABLE  
                || vppAdresseMAC == "10:E7:C6:A5:CA:52"//Ethernet
                || vppAdresseMAC == "80:C5:F2:73:A3:A1"//Wifi

                //POSTE DAF  
                || vppAdresseMAC == "30:E1:71:90:67:55"//Ethernet
                || vppAdresseMAC == "98:54:1B:95:7A:90"//Wifi

                //POSTE DC 
                || vppAdresseMAC == "10:E7:C6:A5:C5:D3"//Ethernet
                || vppAdresseMAC == "80:C5:F2:73:9E:2B"//Wifi

                //POSTE DG 
                || vppAdresseMAC == "D0:17:C2:C4:3F:1A"//Ethernet
                || vppAdresseMAC == "74:C6:3B:32:60:5B"//Wifi

                //POSTE DIRECTRICE COLLETE
                || vppAdresseMAC == "10:E7:C6:A6:E0:D2"//Ethernet
                || vppAdresseMAC == "80:C5:F2:73:A2:3D"//Wifi

                //POSTE DM
                || vppAdresseMAC == "10:E7:C6:A5:C9:76"//Ethernet
                || vppAdresseMAC == "80:C5:F2:73:9E:4D"//Wifi

                //POSTE DRH
                || vppAdresseMAC == "98:29:A6:06:D7:90"//Ethernet
                || vppAdresseMAC == "3E:95:DC:FF:EB:DD"//Wifi

                //POSTE DSI
                || vppAdresseMAC == "D0:17:C2:C4:41:15"//Ethernet
                || vppAdresseMAC == "74:C6:3B:32:5E:E3"//Wifi

                //POSTE MG
                || vppAdresseMAC == "10:E7:C6:A5:C8:E1"//Ethernet
                || vppAdresseMAC == "80:C5:F2:73:A3:2D"//Wifi

                //POSTE PCA
                || vppAdresseMAC == "D0:17:C2:C1:D3:98"//Ethernet
                || vppAdresseMAC == "74:C6:3B:20:B6:D3"//Wifi

                //POSTE RECOUVREMENT
                || vppAdresseMAC == "10:E7:C6:A6:BB:04"//Ethernet
                || vppAdresseMAC == "80:C5:F2:73:22:75"//Wifi

                //POSTE 1
                || vppAdresseMAC == "10:E7:C6:A5:C8:76"//Ethernet
                || vppAdresseMAC == "80:C5:F2:73:A8:41"//Wifi

                //POSTE 3
                || vppAdresseMAC == "30:E1:71:8E:84:61"//Ethernet
                || vppAdresseMAC == "98:54:1B:17:AF:84"//Wifi




                //Serveur Marcory
                || vppAdresseMAC == "DC:4A:3E:72:EE:26"
                || vppAdresseMAC == "48:0F:CF:4D:3E:A4"//Caisse 01 Marcory: 
                || vppAdresseMAC == "48:0F:CF:4D:7C:F6"//Caisse 02 Marcory: 
                || vppAdresseMAC == "F4:39:09:42:79:D9"//Caisse 03 Marcory: 



                //Serveur Port bouet
                || vppAdresseMAC == "DC:4A:3E:72:EF:AA"
                || vppAdresseMAC == "48:0F:CF:4D:DD:5C"//Caisse 01 Port Bouet: 
                || vppAdresseMAC == "48:0F:CF:53:40:4F"//Caisse 02 Port Bouet: 
                                                       //Serveur Abobo
                || vppAdresseMAC == "DC:4A:3E:71:E9:74"
                || vppAdresseMAC == "48:0F:CF:4D:3F:DB"//Caisse 01 Abobo: 
                || vppAdresseMAC == "48:0F:CF:47:A4:F2"//Caisse 02 Abobo: 
                                                       //Serveur Adjame 1
                || vppAdresseMAC == "DC:4A:3E:72:ED:52"
                || vppAdresseMAC == "48:0F:CF:48:F4:81"//Caisse 01 Adjame 1:
                || vppAdresseMAC == "48:0F:CF:52:C3:5F"  //Caisse 02 Adjame 1: 



                //NOUVEAUX ORDINATEURS
                || vppAdresseMAC == "DC:4A:3E:7B:76:85"
                || vppAdresseMAC == "DC:4A:3E:86:FF:47"
                || vppAdresseMAC == "DC:4A:3E:75:52:6A"
                || vppAdresseMAC == "DC:4A:3E:9C:44:FC"

                || vppAdresseMAC == "70:5A:0F:2F:45:67"
                || vppAdresseMAC == "70:5A:0F:2F:46:F5"
                || vppAdresseMAC == "70:5A:0F:2F:42:F2"
                || vppAdresseMAC == "DC:4A:3E:75:51:43"
                || vppAdresseMAC == "DC:4A:3E:9C:42:7D"

                //
                || vppAdresseMAC == "DC:4A:3E:71:E7:1C" //SERVEUR BOUAKE:
                || vppAdresseMAC == "DC:4A:3E:71:E8:13"//SERVEUR DALOA:
                || vppAdresseMAC == "DC:4A:3E:78:C8:BB"//SERVEUR SAN PEDRO:
                || vppAdresseMAC == "DC:4A:3E:78:C7:55"//SERVEUR KORHOGO:
                || vppAdresseMAC == "DC:4A:3E:71:E9:87"//SERVEUR DIANRA: 
                || vppAdresseMAC == "DC:4A:3E:78:C8:D3"//SERVEUR MAN : 
                || vppAdresseMAC == "DC:4A:3E:7B:E6:30" //SERVEUR DABOU: 



                //AGENCE DE PORT BOUET
                || vppAdresseMAC == "48:0F:CF:4D:2D:5C"
                || vppAdresseMAC == "EC:B1:D7:34:63:14"
                || vppAdresseMAC == "40:A8:F0:5B:68:50"

                //AGENCE DE ABOBO
                || vppAdresseMAC == "40:A8:F0:59:F6:D0"
                || vppAdresseMAC == "00:01:6C:6B:6B:EA"

                //01/06/2018 ABOBO
                || vppAdresseMAC == "EC:B1:D7:34:54:40"
                || vppAdresseMAC == "EC:B1:D7:31:BC:7A"


                //AGENCE DE ADJAME 01
                || vppAdresseMAC == "48:0F:CF:60:F1:8B"
                || vppAdresseMAC == "48:0F:CF:59:0B:D2"
                || vppAdresseMAC == "00:01:6C:6C:7A:4F"
                || vppAdresseMAC == "C4:34:6B:78:F8:67"
                //10-03-2018
                || vppAdresseMAC == "48:0F:CF:4D:48:9E"
                || vppAdresseMAC == "DC:4A:3E:7B:7E:86"




                //Agence ADJAME LIBERTE
                || vppAdresseMAC == "48:0F:CF:57:16:4E"
                || vppAdresseMAC == "50:65:F3:37:E5:27"
                || vppAdresseMAC == "50:65:F3:37:E5:F6"
                || vppAdresseMAC == "DC:4A:3E:9C:49:AE"
                || vppAdresseMAC == "48:0F:CF:67:C2:0F"

                //23/06/2018
                || vppAdresseMAC == "3C:52:82:7A:16:90"//POSTE 1 ADJAME LIBERTE
                || vppAdresseMAC == "18:60:24:7B:49:89"//POSTE 2 ADJAME LIBERTE

                //18/03/2020
                || vppAdresseMAC == "F4:39:09:42:7B:0D"//POSTE 1 ADJAME LIBERTE
                || vppAdresseMAC == "F4:39:09:3F:3B:5C"//POSTE 2 ADJAME LIBERTE




                //Agence d'ANGRE
                || vppAdresseMAC == "48:0F:CF:4D:7A:CF"
                || vppAdresseMAC == "48:0F:CF:4D:77:DD"
                || vppAdresseMAC == "48:0F:CF:52:C3:AD"
                || vppAdresseMAC == "48:0F:CF:4D:3C:E0"
                || vppAdresseMAC == "48:0F:CF:4D:6F:41"

                //23/06/2018
                || vppAdresseMAC == "3C:52:82:78:6E:6E"//POSTE 2 ANGRE
                                                       //23/05/2019
                || vppAdresseMAC == "10:62:E5:0E:CC:E4"

                //Agence YOPOUGON
                || vppAdresseMAC == "74:46:A0:A7:79:F4"
                || vppAdresseMAC == "50:65:F3:3A:06:ED"
                || vppAdresseMAC == "48:0F:CF:5C:73:95"
                || vppAdresseMAC == "48:0F:CF:57:16:83"
                || vppAdresseMAC == "50:65:F3:39:86:57"
                || vppAdresseMAC == "2C:4D:54:95:3D:2F"

                //01/06/2018 YOPOUGON
                || vppAdresseMAC == "40:A8:F0:64:24:75"
                || vppAdresseMAC == "50:65:F3:31:1D:52"

                //18/03/2020 YOPOUGON ANNANERAIE
                || vppAdresseMAC == "C4:65:16:13:C8:08"
                || vppAdresseMAC == "F4:39:09:3F:48:5F"


                //AGENCE DE DABOU ET BASSAM 
                || vppAdresseMAC == "48:0F:CF:59:0B:B9"
                || vppAdresseMAC == "DC:4A:3E:75:4D:79"
                || vppAdresseMAC == "DC:4A:3E:75:57:F7"
                || vppAdresseMAC == "70:5A:0F:2F:44:A5"
                || vppAdresseMAC == "DC:4A:3E:75:52:2C"
                || vppAdresseMAC == "DC:4A:3E:9C:46:44"
                || vppAdresseMAC == "DC:4A:3E:9C:4A:34"
                || vppAdresseMAC == "DC:4A:3E:75:52:10"
                //Serveur bassam
                || vppAdresseMAC == "48:0F:CF:5C:77:E8"
                //23/06/2018 DABOU
                || vppAdresseMAC == "18:60:24:7B:48:DB"//POSTE 1
                || vppAdresseMAC == "70:5A:0F:37:1E:58"//POSTE 2

                //18/05/2018
                || vppAdresseMAC == "DC:4A:3E:9C:46:66"//POSTE 1
                || vppAdresseMAC == "48:0F:CF:48:F1:A8"//POSTE 2

                //18/03/2020
                || vppAdresseMAC == "F4:39:09:42:79:99"//POSTE 1
                || vppAdresseMAC == "F4:39:09:41:F4:02"//POSTE 2




                //Agence SAN PEDRO
                || vppAdresseMAC == "70:5A:0F:2F:45:EB"
                || vppAdresseMAC == "DC:4A:3E:9C:41:1D"
                || vppAdresseMAC == "DC:4A:3E:9C:41:5C"
                || vppAdresseMAC == "DC:4A:3E:8D:87:6E"
                || vppAdresseMAC == "DC:4A:3E:7B:7E:D1"
                || vppAdresseMAC == "48:0F:CF:59:0B:80"
                || vppAdresseMAC == "50:65:F3:3B:85:21"
                || vppAdresseMAC == "48:0F:CF:67:C2:0F"
                || vppAdresseMAC == "48:0F:CF:5C:7C:F1" //SERVEUR


                //Agence DALOA
                || vppAdresseMAC == "48:0F:CF:5A:5F:89"
                || vppAdresseMAC == "48:0F:CF:45:AA:A6"
                || vppAdresseMAC == "48:0F:CF:65:83:8C"
                || vppAdresseMAC == "48:0F:CF:5A:6C:7F"
                || vppAdresseMAC == "48:0F:CF:5A:66:2B"
                || vppAdresseMAC == "48:0F:CF:59:0B:80"
                || vppAdresseMAC == "50:65:F3:3B:85:21"
                || vppAdresseMAC == "48:0F:CF:67:C2:0F"
                //08-05-2019               
                || vppAdresseMAC == "10:62:E5:0E:C1:EC"

                //Agence MAN
                || vppAdresseMAC == "48:0F:CF:46:31:37"
                || vppAdresseMAC == "48:0F:CF:5A:67:D4"
                || vppAdresseMAC == "48:0F:CF:5A:5F:D4"
                || vppAdresseMAC == "48:0F:CF:59:0B:80"
                || vppAdresseMAC == "50:65:F3:3B:85:21"
                || vppAdresseMAC == "48:0F:CF:67:C2:0F"

                //01/06/2018 MAN
                || vppAdresseMAC == "3C:52:82:6B:2D:17"



                //Agence BOUAKE
                || vppAdresseMAC == "48:0F:CF:5B:33:13"
                || vppAdresseMAC == "48:0F:CF:65:8D:9A"
                || vppAdresseMAC == "48:0F:CF:65:88:4C"
                || vppAdresseMAC == "48:0F:CF:63:91:59"
                || vppAdresseMAC == "70:5A:0F:2F:46:5A"
                || vppAdresseMAC == "48:0F:CF:59:0B:80"
                || vppAdresseMAC == "50:65:F3:3B:85:21"
                || vppAdresseMAC == "48:0F:CF:67:C2:0F"

                //01/06/2018 BOUAKE
                || vppAdresseMAC == "18:60:24:7B:4F:D5"
                || vppAdresseMAC == "3C:52:82:67:F5:7A"


                //Agence KORHOGO
                || vppAdresseMAC == "DC:4A:3E:9C:47:08"
                || vppAdresseMAC == "DC:4A:3E:75:53:6C"
                || vppAdresseMAC == "48:0F:CF:65:83:8C"
                || vppAdresseMAC == "48:0F:CF:5A:16:9C"
                || vppAdresseMAC == "48:0F:CF:5B:33:61"
                || vppAdresseMAC == "48:0F:CF:59:0B:80"
                || vppAdresseMAC == "50:65:F3:3B:85:21"
                || vppAdresseMAC == "48:0F:CF:67:C2:0F"
                || vppAdresseMAC == "48:0F:CF:5D:F5:35"
                || vppAdresseMAC == "A0:8C:FD:CB:46:33" //SERVEUR EN PANNE ?
                                                        //19-03-2018
                || vppAdresseMAC == "A0:8C:FD:CB:46:33"//SERVEUR KORHOGO 



                //Agence DIANRA
                || vppAdresseMAC == "48:0F:CF:5A:6C:C1"
                || vppAdresseMAC == "48:0F:CF:5A:67:E1"
                || vppAdresseMAC == "48:0F:CF:5A:67:DD"
                || vppAdresseMAC == "48:0F:CF:4D:C3:DC"
                || vppAdresseMAC == "48:0F:CF:59:0B:80"
                || vppAdresseMAC == "50:65:F3:3B:85:21"
                || vppAdresseMAC == "48:0F:CF:67:C2:0F"
                || vppAdresseMAC == "A0:8C:FD:C4:7F:A9" //SERVEUR

                //Agence YOPOUGON
                || vppAdresseMAC == "48:0F:CF:5C:7C:F1"
                || vppAdresseMAC == "DC:4A:3E:99:5F:B0"

                || vppAdresseMAC == "70:5A:0F:2F:42:F2"
                || vppAdresseMAC == "48:0F:CF:52:B1:36"
                || vppAdresseMAC == "48:0F:CF:46:30:0D"
                || vppAdresseMAC == "48:0F:CF:45:FC:2F"
                || vppAdresseMAC == "48:0F:CF:47:A2:8A"
                || vppAdresseMAC == "48:0F:CF:45:B8:F5"
                || vppAdresseMAC == "48:0F:CF:45:FC:55"
                || vppAdresseMAC == "48:0F:CF:45:AF:F1"
                //Agence YOPOUGON SERVEUR
                || vppAdresseMAC == "DC:4A:3E:99:5F:BC"


                //16-03-2018
                || vppAdresseMAC == "A0:8C:FD:CB:52:E9"//SERVEUR ABOISSO 


                //16/03/2018
                || vppAdresseMAC == "C8:D3:FF:BE:C0:81" //SERVEUR2

                || vppAdresseMAC == "70:5A:0F:2F:44:9E"
                || vppAdresseMAC == "70:5A:0F:37:16:32"
                || vppAdresseMAC == "DC:4A:3E:75:52:1F"

                || vppAdresseMAC == "70:5A:0F:2F:46:63"
                || vppAdresseMAC == "70:5A:0F:2F:4A:37"

                || vppAdresseMAC == "70:5A:0F:2F:46:1F"
                || vppAdresseMAC == "DC:4A:3E:87:20:96"
                || vppAdresseMAC == "70:5A:0F:2F:46:A7"
                || vppAdresseMAC == "DC:4A:3E:81:3E:F0"

                || vppAdresseMAC == "DC:4A:3E:9C:42:10"
                || vppAdresseMAC == "C8:D3:FF:B2:7E:4B"
                || vppAdresseMAC == "AC:81:12:B9:91:9B"
                || vppAdresseMAC == "C8:D3:FF:BB:E3:4B"


                //15-05-2018
                || vppAdresseMAC == "F4:03:43:FF:F9:84"//Serveur
                || vppAdresseMAC == "F4:03:43:FF:F9:85"//Serveur
                || vppAdresseMAC == "50:65:F3:24:2B:B3"//POSTE 1

                || vppAdresseMAC == "48:0F:CF:65:88:6A"//POSTE 3
                || vppAdresseMAC == "EA:BB:9E:FE:EC:80"//WIFI


                //01/06/2018 treichville
                || vppAdresseMAC == "48:0F:CF:31:0D:F0"
                || vppAdresseMAC == "48:0F:CF:47:92:88"


                //09-07-2018
                //SERVEUR SIEGE
                || vppAdresseMAC == "3C:52:82:73:F5:9E"


                //18/07/2018 DUEKOUE
                || vppAdresseMAC == "DC:4A:3E:75:53:9A"//SERVEUR
                || vppAdresseMAC == "3C:52:82:73:2E:AC"//POSTE 1
                || vppAdresseMAC == "3C:52:82:73:F6:10"//POSTE 2
                || vppAdresseMAC == "3C:52:82:73:2E:24"//POSTE 3
                || vppAdresseMAC == "3C:52:82:75:64:B6"//POSTE 4
                || vppAdresseMAC == "3C:52:82:75:A0:4E"//POSTE 5
                                                       //21-02-2020
                || vppAdresseMAC == "F4:39:09:41:F4:0F"//POSTE 6



                //18/07/2018 MEAGUI
                || vppAdresseMAC == "70:5A:0F:2F:46:50"//SERVEUR
                || vppAdresseMAC == "3C:52:82:75:66:A4"//POSTE 1
                || vppAdresseMAC == "3C:52:82:73:2E:15"//POSTE 2
                || vppAdresseMAC == "3C:52:82:73:F5:E2"//POSTE 3
                || vppAdresseMAC == "3C:52:82:75:64:E7"//POSTE 4
                || vppAdresseMAC == "3C:52:82:75:64:90"//POSTE 5

                //06/09/2018 SOUBRE
                || vppAdresseMAC == "34:64:A9:2A:DE:94"//SERVEUR
                || vppAdresseMAC == "6C:4B:90:3A:8C:55"//POSTE 1
                || vppAdresseMAC == "6C:4B:90:3A:8B:A9"//POSTE 2
                || vppAdresseMAC == "6C:4B:90:3A:8D:DB"//POSTE 3
                || vppAdresseMAC == "6C:4B:90:3A:8D:45"//POSTE 4
                || vppAdresseMAC == "6C:4B:90:3A:8B:DF"//POSTE 5


                //16-11-2018 ISSIA 
                || vppAdresseMAC == "48:0F:CF:60:05:CD"//SERVEUR


                //23-11-2018 GAGNOA
                || vppAdresseMAC == "6C:4B:90:3A:90:D8"//SERVEUR

                //23-11-2018 DIVO
                || vppAdresseMAC == "6C:4B:90:3A:6C:B1"//SERVEUR


                //29/11/2018
                || vppAdresseMAC == "6C:4B:90:3A:8C:87"//POSTE 1
                || vppAdresseMAC == "6C:4B:90:3A:8B:DA"//POSTE 2
                || vppAdresseMAC == "6C:4B:90:3A:8C:30"//POSTE 3
                || vppAdresseMAC == "6C:4B:90:3A:8C:3E"//POSTE 4
                || vppAdresseMAC == "6C:4B:90:3A:8C:FE"//POSTE 5
                || vppAdresseMAC == "6C:4B:90:3A:8B:97"//POSTE 6

                || vppAdresseMAC == "6C:4B:90:3A:8C:4F"//POSTE 7
                || vppAdresseMAC == "6C:4B:90:3A:8B:D7"//POSTE 8
                || vppAdresseMAC == "6C:4B:90:37:7B:84"//POSTE 9
                || vppAdresseMAC == "6C:4B:90:3A:8C:2F"//POSTE 10
                || vppAdresseMAC == "6C:4B:90:3A:8C:4D"//POSTE 11
                || vppAdresseMAC == "E8:2A:44:EF:60:D3"//POSTE 12/WIFI. 

                || vppAdresseMAC == "8C:16:45:30:EF:03"//POSTE 13/ETHERNET. 
                || vppAdresseMAC == "E8:2A:44:EF:69:0F"//POSTE 13/WIFI. 



                //11-01-2019- AGBOVILLE
                || vppAdresseMAC == "6C:4B:90:2F:2F:96"//PC1/ETHERNET. 
                || vppAdresseMAC == "9C:DA:3E:73:A4:E7"//PC1/WIFI. 

                || vppAdresseMAC == "6C:4B:90:3A:8B:C3"//PC2/ETHERNET. 

                || vppAdresseMAC == "28:C6:3F:12:D2:F2"//PC3/ETHERNET. 
                || vppAdresseMAC == "6C:4B:90:2E:43:FE"//PC3/WIFI. 

                || vppAdresseMAC == "9C:DA:3E:74:6B:CA"//PC4/ETHERNET. 
                || vppAdresseMAC == "6C:4B:90:2F:2E:C3"//PC4/WIFI. 

                || vppAdresseMAC == "28:C6:3F:12:DE:82"//PC5/ETHERNET. 
                || vppAdresseMAC == "6C:4B:90:2F:30:2F"//PC5/WIFI. 


                || vppAdresseMAC == "30:E1:71:C8:E7:F3"//PC6/ETHERNET. 
                || vppAdresseMAC == "26:18:FE:51:A1:45"//PC6/WIFI. 
                || vppAdresseMAC == "6C:4B:90:58:DA:2A"//SERVEUR/ETHERNET. 

                //FERKESSEDOUGOU 06/02/2019
                || vppAdresseMAC == "18:60:24:9D:83:5A"//pc1
                || vppAdresseMAC == "18:60:24:9D:83:C5"//pc2: 
                || vppAdresseMAC == "18:60:24:9B:2A:DE"//pc3:
                || vppAdresseMAC == "18:60:24:99:7D:72"//pc4:  
                || vppAdresseMAC == "18:60:24:9B:2A:56"//pc5: 
                || vppAdresseMAC == "10:E7:C6:1A:9B:1B"//serveur: 






                //YABAYO 26/03/2019
                || vppAdresseMAC == "10:62:E5:0E:C1:E3"//pc1
                || vppAdresseMAC == "10:62:E5:0E:CB:B8"//pc2: 
                || vppAdresseMAC == "10:62:E5:0E:CC:DF"//pc3:
                || vppAdresseMAC == "10:62:E5:0E:C1:FF"//pc4:  
                || vppAdresseMAC == "10:62:E5:0E:CD:D3"//pc5: 
                || vppAdresseMAC == "10:E7:C6:4A:14:89"//serveur: 

                //GABIADJI 26/03/2019
                || vppAdresseMAC == "10:62:E5:0E:C1:FD"//pc1
                || vppAdresseMAC == "10:62:E5:0E:C1:DE"//pc2: 
                || vppAdresseMAC == "10:62:E5:0E:C4:38"//pc3:
                || vppAdresseMAC == "10:62:E5:0E:C2:65"//pc4:  
                || vppAdresseMAC == "10:62:E5:0E:C6:43"//pc5: 
                || vppAdresseMAC == "10:62:E5:0E:C2:8E"//pc6: 
                || vppAdresseMAC == "10:E7:C6:4A:14:C0"//serveur: 

                //SIEGE 27-11-2019
                || vppAdresseMAC == "D6:48:54:58:98:32"//wifi
                || vppAdresseMAC == "30:E1:71:8E:84:61"//ETHERNET 
                || vppAdresseMAC == "28:C6:3F:8B:8B:93"//DAF WIFI
                || vppAdresseMAC == "48:BA:4E:5A:9E:C0"//DAF ETHERNET  

                //CREDIT 09-12-2019
                || vppAdresseMAC == "8C:16:45:30:EC:AA"//CREDIT ETHERNET
                || vppAdresseMAC == "EA:2A:47:EF:86:08"//CREDIT WIFI 

                //DG 09-12-2019
                || vppAdresseMAC == "10:62:E5:0E:C3:30"//CREDIT ETHERNET
                || vppAdresseMAC == "74:40:BB:14:2D:EF"//CREDIT WIFI 

                //DMG 09-12-2019
                || vppAdresseMAC == "10:62:E5:0E:C4:56"//CREDIT ETHERNET


                //DRH 09-12-2019
                || vppAdresseMAC == "18:60:24:7D:6C:7B"//CREDIT ETHERNET
                || vppAdresseMAC == "50:3E:AA:AD:9A:DC"//CREDIT WIFI 

                //MARKETING 09-12-2019
                || vppAdresseMAC == "E4:E7:49:C0:55:D0"//CREDIT ETHERNET
                || vppAdresseMAC == "D0:C5:D3:ED:03:2F"//CREDIT WIFI 

                //MONETIQUE 09-12-2019
                || vppAdresseMAC == "8C:16:45:30:F1:6F"//CREDIT ETHERNET
                || vppAdresseMAC == "E8:2A:44:EF:69:47"//CREDIT WIFI 


                //PCC 09-12-2019
                || vppAdresseMAC == "DC:4A:3E:9C:4A:5B"//CREDIT ETHERNET

                //PRESIDENT 09-12-2019
                || vppAdresseMAC == "E4:E7:49:40:48:0F"//CREDIT ETHERNET
                || vppAdresseMAC == "DC:8B:28:4D:F8:CD"//CREDIT WIFI 

                //SECRETAIRE 09-12-2019
                || vppAdresseMAC == "8C:16:45:2A:40:03"//CREDIT ETHERNET
                || vppAdresseMAC == "E8:2A:44:EF:60:33"//CREDIT WIFI 

                //SECRETAIRE 2 09-12-2019
                || vppAdresseMAC == "6C:4B:90:2F:30:10"//CREDIT ETHERNET
                || vppAdresseMAC == "9C:DA:3E:73:A4:C4"//CREDIT WIFI 

                //STAGIAIRE 2 09-12-2019
                || vppAdresseMAC == "10:62:E5:0E:C2:EE"//CREDIT ETHERNET

                //VPCC 09-12-2019
                || vppAdresseMAC == "10:E7:C6:A5:C5:B4"//CREDIT ETHERNET
                || vppAdresseMAC == "80:C5:F2:73:A3:59"//CREDIT WIFI 


                //DE 09-12-2019
                || vppAdresseMAC == "50:7B:9D:33:C9:43"//CREDIT ETHERNET
                || vppAdresseMAC == "B2:64:CD:37:09:0C"//CREDIT WIFI 


                //POSTE 09-12-2019
                || vppAdresseMAC == "98:40:BB:20:62:29"//CREDIT ETHERNET
                || vppAdresseMAC == "28:56:5A:58:1F:2D"//CREDIT WIFI 


                //SERVEUR N°2 12-12-2019
                || vppAdresseMAC == "98:F2:B3:E9:F6:B1"// ETHERNET1
                || vppAdresseMAC == "98:F2:B3:E9:F6:B0"// ETHERNET2
                || vppAdresseMAC == "98:F2:B3:E9:F6:B3"// ETHERNET3
                || vppAdresseMAC == "98:F2:B3:E9:F6:B2"// ETHERNET4


                //ANYAMA 18-03-2020
                || vppAdresseMAC == "F4:39:09:3F:3B:57"//pc3
                || vppAdresseMAC == "F4:39:09:2A:58:6C"//pc4

                //PORT BOUET 18-03-2020
                || vppAdresseMAC == "F4:39:09:3F:3B:50"//pc1
                || vppAdresseMAC == "F4:39:09:3F:40:BF"//pc2









                )
            {
                return true;
            }
            //5-PC CREDIT FEF:POINTE DE VENTE
            else if (
                   vppAdresseMAC == "00:12:79:67:9A:48")
            {
                MgRequeteClients.Tools.Classes.clsDeclaration.vagObjetEnvoi.POINTVENTE = true;
                return true;
            }


            //6-PC FCEC
            else if (

                   vppAdresseMAC == "3C:D9:2B:70:B1:AE" || vppAdresseMAC == "C4:65:16:3C:4A:E8"
                || vppAdresseMAC == "04:0E:3C:10:4B:B5" || vppAdresseMAC == "18:60:24:A7:09:17"
                || vppAdresseMAC == "50:3E:AA:B7:A5:83" || vppAdresseMAC == "C4:54:44:ED:3D:38"
                || vppAdresseMAC == "80:19:34:14:25:CB" || vppAdresseMAC == "A4:5D:36:C4:E2:AD"
                || vppAdresseMAC == "A4:5D:36:C4:E2:AC" || vppAdresseMAC == "48:0F:CF:60:04:D8"
                || vppAdresseMAC == "00:25:AB:AA:C7:C9" || vppAdresseMAC == "28:B2:BD:31:C3:01"
                || vppAdresseMAC == "70:5A:0F:44:CB:57" || vppAdresseMAC == "18:60:24:9E:0E:3B"

                || vppAdresseMAC == "08:00:27:00:14:BF" //POSTE 2

                || vppAdresseMAC == "80:E8:2C:D4:0F:94" || vppAdresseMAC == "00:68:EB:A2:D8:8D"
                || vppAdresseMAC == "78:98:E8:C0:CA:11" || vppAdresseMAC == "00:68:EB:A2:D8:C0"
                || vppAdresseMAC == "78:98:E8:C0:D7:36"

                //15-02-2022
                || vppAdresseMAC == "2C:41:38:8C:6D:D1" || vppAdresseMAC == "C8:D3:A3:0B:5E:46"


                //17-02-2023
                || vppAdresseMAC == "18:60:24:82:6A:04" || vppAdresseMAC == "C8:D3:A3:0B:5E:46"

                //17-05-2023
                || vppAdresseMAC == "18:60:24:A7:09:17" || vppAdresseMAC == "50:3E:AA:B7:A5:83"



                )
            {
                return true;
            }
            //7-PC CMEC N'ZIANOUAN
            else if (
                   vppAdresseMAC == "18:A9:05:B7:97:36" || vppAdresseMAC == "00:16:35:61:AF:AB"
                || vppAdresseMAC == "14:FE:B5:E8:F0:6D" || vppAdresseMAC == "00:A1:B0:81:35:0D"
                || vppAdresseMAC == "00:22:64:BE:3E:6D" || vppAdresseMAC == "00:0F:FE:5F:14:CD"
                || vppAdresseMAC == "50:65:F3:24:33:81"

                || vppAdresseMAC == "48:0F:CF:65:8F:A0"
                || vppAdresseMAC == "18:60:24:9B:2A:E7"//13-08-2018

                || vppAdresseMAC == "10:E7:C6:49:DA:71"//26-03-2019

                || vppAdresseMAC == "00:68:EB:B2:5E:F6"//06-07-2021


                || vppAdresseMAC == "6C:4B:90:E8:86:5F"//26-11-2021
                || vppAdresseMAC == "6C:4B:90:E8:82:3D"//26-11-2021
                                                       //04 - 05 - 2022
                || vppAdresseMAC == "1C:69:7A:4F:95:6C"
                || vppAdresseMAC == "98:29:A6:06:D7:BD"

                //15-09-2022
                || vppAdresseMAC == "10:E7:C6:01:33:A9"
                || vppAdresseMAC == "3C:33:00:60:34:A1"




                )
            {
                return true;
            }



            //3-PC DE DIARRASSOUBA
            else if (vppAdresseMAC == "08:00:27:00:AC:39" || vppAdresseMAC == "50:B7:C3:F4:39:BD" || vppAdresseMAC == "50:B7:C3:94:3E:0F")
            {
                return true;
            }
            //8-PC CMEC KOUMASSI
            else if (
                   vppAdresseMAC == "BC:30:5B:BA:91:03" || vppAdresseMAC == "D4:85:64:0C:04:C2"
                || vppAdresseMAC == "00:24:01:A6:DB:69" || vppAdresseMAC == "0F:FE:90:82:C5"
                )
            {
                return true;
            }
            //9-PC CMEC KOFFIKRO
            else if (
                   vppAdresseMAC == "28:F3:66:A3:ED:CE" || vppAdresseMAC == "74:46:A0:A5:CF:29"
                || vppAdresseMAC == "40:61:86:9B:07:73" || vppAdresseMAC == "D8:9C:67:25:25:09"
                 || vppAdresseMAC == "F4:39:09:C7:43:78"
                 //08/02/2023
                 || vppAdresseMAC == "5C:60:BA:33:EB:AC"
                )
            {
                return true;
            }
            //11-PC TRANSUA
            else if (
                 vppAdresseMAC == "00:08:02:BB:1F:FC" || vppAdresseMAC == "74:46:A0:AB:61:8F"
                )
            {
                return true;
            }
            //11-PC ASSUEFRY
            else if (
                  vppAdresseMAC == "10:E7:C6:4D:D6:99" || vppAdresseMAC == "00:E0:4C:36:0A:6E"
                )
            {
                return true;
            }

            //12-PC TABAGNE
            else if (
                   vppAdresseMAC == "38:60:77:4C:1D:01" || vppAdresseMAC == "74:DE:2B:25:33:CF"
                )
            {
                return true;
            }

            //13-PC TANKESSE
            else if (
                   vppAdresseMAC == "00:0F:FE:30:40:60" || vppAdresseMAC == "00:13:21:F0:E6:A3"
                || vppAdresseMAC == "F4:B7:E2:18:65:17"
                )
            {
                return true;
            }

            //14-PC GOUMERE
            else if (
                   vppAdresseMAC == "00:0F:FE:30:41:57" || vppAdresseMAC == "00:19:DB:51:E4:BA"
                || vppAdresseMAC == "B8:88:E3:04:A7:D9" || vppAdresseMAC == "08:00:27:00:BC:6B"
                || vppAdresseMAC == "C8:1F:66:1A:51:39"
                || vppAdresseMAC == "08:ED:B9:F0:49:EF" || vppAdresseMAC == "08:00:27:00:A0:6A"
                )
            {
                return true;
            }
            //15-PC BONDOUKOU
            else if (
                   vppAdresseMAC == "E8:03:9A:97:AD:C2" || vppAdresseMAC == "00:23:7D:C8:78:76"
                || vppAdresseMAC == "00:19:DB:50:EC:AC" || vppAdresseMAC == "00:1C:C4:18:F5:76"
                || vppAdresseMAC == "00:0F:FE:01:06:78" || vppAdresseMAC == "00:0F:FE:11:91:4B"
                || vppAdresseMAC == "B8:03:05:4C:2C:8C" || vppAdresseMAC == "E8:03:9A:97:AD:C2"
                //06/05/2022
                || vppAdresseMAC == "48:0F:CF:4E:A8:77" || vppAdresseMAC == "04:0C:73:20:AC:E8"
                || vppAdresseMAC == "3C:D9:2B:53:3A:C4" || vppAdresseMAC == "A0:D3:C1:28:2D:1C"

                //06/07/2022
                || vppAdresseMAC == "A0:D3:C1:28:7D:1C" || vppAdresseMAC == "C8:1F:66:16:05:09"
                || vppAdresseMAC == "14:6B:9C:02:11:5A"
                )
            {
                return true;
            }
            //17-PC CPFCI
            else if (
                vppAdresseMAC == "78:AC:C0:B2:94:29" || vppAdresseMAC == "2C:27:D7:42:42:A9" || vppAdresseMAC == "00:8C:FA:3A:CF:82"
                || vppAdresseMAC == "08:00:27:00:94:CB"
                )
            {
                return true;
            }
            //18-wittifinances
            else if (
                vppAdresseMAC == "9C:B6:54:0D:39:FC" || vppAdresseMAC == "A0:D3:C1:17:03:6E"
                || vppAdresseMAC == "A0:48:1C:A3:B8:AE" || vppAdresseMAC == "F0:92:1C:ED:26:7B" || vppAdresseMAC == "A0:D3:C1:0D:F2:4D"
                || vppAdresseMAC == "38:B1:DB:CA:A7:3F" || vppAdresseMAC == "34:64:A9:16:9F:E4" || vppAdresseMAC == "34:64:A9:16:9F:19"
                || vppAdresseMAC == "38:63:BB:BC:42:9B" || vppAdresseMAC == "F0:92:1C:F6:D8:B7" || vppAdresseMAC == "9C:B6:54:EA:9D:1E" || vppAdresseMAC == "9C:B6:54:EA:92:1E"

                //ORDINATEUR PORTABLE PCA
                || vppAdresseMAC == "00:22:5F:C0:A3:CE" || vppAdresseMAC == "00:23:5A:F9:FC:0F"

                //ORDINATEUR NOUVEAU COMPTABLE wittifinances
                || vppAdresseMAC == "00:13:77:D8:89:3B" || vppAdresseMAC == "00:24:D2:29:12:20"

                || vppAdresseMAC == "1E:84:DC:0C:C7:9E" //INFOR        
                || vppAdresseMAC == "A0:D3:C1:1B:85:59" //CONSEILLER

                || vppAdresseMAC == "70:5A:0F:35:DE:FB" //APIAH      
                || vppAdresseMAC == "DC:4A:3E:72:FF:57" //RESP EXPLOI

                || vppAdresseMAC == "70:5A:0F:37:EE:F2" //TOUMODI 1          
                || vppAdresseMAC == "DC:4A:3E:71:EF:F1" //TOUMODI 2    


                || vppAdresseMAC == "70:5A:0F:33:99:A3" //PORT-BOUËT       
                || vppAdresseMAC == "40:B0:34:97:2C:A8" //M ZAHOULI  
                || vppAdresseMAC == "40:B0:34:6D:09:64" //MONSIEUR DENOUMAN

                //Ordinateur informaticien pour formation
                || vppAdresseMAC == "40:B0:34:97:2C:A8"
                || vppAdresseMAC == "58:00:E3:7E:56:13"

                //Nouveau ordinateur le 20/10/2017
                || vppAdresseMAC == "A0:D3:C1:0D:20:CE"
                || vppAdresseMAC == "00:09:0F:FF:00:01"
                || vppAdresseMAC == "00:09:0F:FE:00:01"

                //Nouveau ordinateur le 06/08/2019
                || vppAdresseMAC == "18:60:24:8F:90:1B"//DAF
                || vppAdresseMAC == "18:60:24:8D:57:54"//JURIDIQUE


                //Nouveau ordinateur Fah SANOGO le 11/05/2021
                || vppAdresseMAC == "E0:D4:64:3C:D2:BE"//WIFI
                || vppAdresseMAC == "54:05:DB:FE:7E:9C"//ETHERNET

                //Nouveau ordinateur Marie-isabelle  le 11/06/2021
                || vppAdresseMAC == "A4:B1:C1:E4:1D:3A"//WIFI
                || vppAdresseMAC == "00:E0:4C:36:07:DB"//ETHERNET

                //Nouveau ordinateur le 15/06/2021
                || vppAdresseMAC == "9C:7B:EF:3E:E6:D3"//ACCUEIL ETHERNET : 
                || vppAdresseMAC == "80:E8:2C:F7:CC:FE" //CAF ETHERNET : 
                || vppAdresseMAC == "8C:8C:AA:A9:4E:AF"//JEAN CLAUDEL ETHERNET :  
                || vppAdresseMAC == "E8:F4:08:1D:F0:92"//JEAN CLAUDEL WIFI :  
                || vppAdresseMAC == "8C:8C:AA:34:36:7C"//JEAN FABRICE ETHERNET : 
                || vppAdresseMAC == "40:EC:99:85:E2:A6"//JEAN LUC WIFI:


                //Nouveau ordinateur le 19/06/2021
                || vppAdresseMAC == "A8:7E:EA:22:1B:EA" //POSTE 1 / ISMAEL DIABAKATE WIFI
                || vppAdresseMAC == "1C:BF:C0:84:BB:89"//POSTE 2 / DANE WIFI :  
                || vppAdresseMAC == "28:CD:C4:0C:19:83"//AIMEE WIFI :  
                || vppAdresseMAC == "8C:8C:AA:DD:1A:81"//CLOVIS ETHERNET : 
                || vppAdresseMAC == "64:BC:58:FB:2F:D4"//CLOVIS WIFI:

                || vppAdresseMAC == "F4:69:D5:C8:15:4F"//CHRISTIAN ETHERNET
                || vppAdresseMAC == "78:2B:46:D2:DE:49" //CHRISTIAN WIFI
                || vppAdresseMAC == "F8:AC:65:A9:0B:46"//ESTELLE WIFI :  
                || vppAdresseMAC == "5C:3A:45:84:EA:D1"//SAM WIFI
                                                       //12-08-2021
                || vppAdresseMAC == "00:68:EB:B1:13:CA"//POSTE 1 ETHERNET
                || vppAdresseMAC == "A4:97:B1:E5:0F:37" //POSTE  2 ETHERNET
                || vppAdresseMAC == "00:68:EB:B0:3C:D2"//POSTE 1 ETHERNET
                || vppAdresseMAC == "60:18:95:0C:37:93"//POSTE 4 Mathieu  ETHERNET
                || vppAdresseMAC == "60:18:95:0C:A3:7D"//POSTE 5  Vincent  Mathieu  ETHERNET
                || vppAdresseMAC == "C0:3E:BA:1C:78:EC"//POSTE 2  ETHERNET
                                                       //24-08-2021
                || vppAdresseMAC == "3C:9C:0F:5E:D7:65"//CLOVIS WIFI
                || vppAdresseMAC == "3C:9C:0F:70:AB:B1" //FABRICE WIFI
                || vppAdresseMAC == "C8:F7:50:31:92:EC"//MORY ETHERNET
                || vppAdresseMAC == "D8:F2:CA:48:CF:9C"//MORY WIFI

                //25-08-2021
                || vppAdresseMAC == "00:0C:29:3A:81:63"
                || vppAdresseMAC == "00:0C:29:3A:81:6D"
                || vppAdresseMAC == "34:7D:F6:AE:0A:D3"
                || vppAdresseMAC == "34:7D:F6:AE:0A:D4"


                //02-09-2021
                || vppAdresseMAC == "60:18:95:1E:34:8C"  // POSTE 2 ETHERNET
                || vppAdresseMAC == "50:2F:9B:9B:A4:1F" // POSTE 2 WIFI
                || vppAdresseMAC == "8C:8C:AA:34:32:AD"  // POSTE 3 ETHERNET
                || vppAdresseMAC == "3C:9C:0F:72:A7:BD" // POSTE 3 WIFI


                //07-10-2021
                || vppAdresseMAC == "30:D0:42:0F:63:CD"  // POSTE 1 DELL ETHERNET
                || vppAdresseMAC == "5C:BA:EF:E1:28:75" // POSTE 1 DELL WIFI
                || vppAdresseMAC == "30:D0:42:0F:6C:01"  //POSTE 2 NAMORY MEITE ETHERNET
                || vppAdresseMAC == "5C:BA:EF:E0:C5:BD" //POSTE 2 NAMORY MEITE WIFI
                || vppAdresseMAC == "30:D0:42:10:CB:5D"  //POSTE 3 PARFAIT KOBENAN  ETHERNET
                || vppAdresseMAC == "5C:BA:EF:C2:10:DD" //POSTE 3 PARFAIT KOBENAN  WIFI


                //11-10-2021
                || vppAdresseMAC == "00:0E:19:90:1D:83"  // CLOVIS AKPO ETHERNET
                || vppAdresseMAC == "84:1B:77:12:0A:4D" // CLOVIS AKPO WIFI


                //04-11-2021
                || vppAdresseMAC == "E0:2B:E9:7F:01:1B"  // POSTE ERIC IRRA ECOCRED WIFI
                || vppAdresseMAC == "00:E0:4C:36:00:0F" // POSTE ERIC IRRA ECOCRED ETHERNET
                || vppAdresseMAC == "A4:97:B1:17:71:0B"  //POSTE ELYSE OULAI ECOCRED  WIFI
                || vppAdresseMAC == "30:D0:42:29:DB:D4" //POSTE ELYSE OULAI ECOCRED  ETHERNET

                || vppAdresseMAC == "60:18:95:1E:B3:1F"  // POSTE 1 ETHERNET
                || vppAdresseMAC == "E0:2B:E9:2C:A3:8A" // POSTE 2 ETHERNET
                || vppAdresseMAC == "C0:3E:BA:1C:5B:5A"  //POSTE 3 ETHERNET
                || vppAdresseMAC == "1C:BF:C0:77:65:79" //POSTE 3  WIFI
                || vppAdresseMAC == "60:18:95:1E:A5:E0"  //POSTE 4 ETHERNET
                || vppAdresseMAC == "E0:2B:E9:0F:9C:4F" //POSTE 5 ETHERNET
                || vppAdresseMAC == "E0:2B:E9:2C:5B:1E"  //POSTE 6 ETHERNET
                || vppAdresseMAC == "60:18:95:1E:A7:57" //POSTE 7  ETHERNET 
                || vppAdresseMAC == "C8:F7:50:1F:4E:7A" //POSTE 8  ETHERNET 

                //19-11-2021
                || vppAdresseMAC == "C8:F7:50:1F:4E:7A" //POSTE 7  ETHERNET 
                || vppAdresseMAC == "D8:F2:CA:4B:EF:60" //POSTE 8  ETHERNET 


                //01-12-2021
                || vppAdresseMAC == "84:A9:3E:76:A1:D8"  // POSTE 1 ETHERNET
                || vppAdresseMAC == "00:68:EB:C7:C0:34" // POSTE 2 ETHERNET
                || vppAdresseMAC == "00:68:EB:C6:76:AB"  //POSTE 3 ETHERNET
                || vppAdresseMAC == "00:68:68:EB:C7:F1" //POSTE 3  WIFI
                || vppAdresseMAC == "00:68:EB:C6:76:B5"  //POSTE 4 ETHERNET
                || vppAdresseMAC == "00:68:EB:C7:F5:EB" //POSTE 5 ETHERNET 

                //13-12-2021
                || vppAdresseMAC == "E0:2B:E9:9F:3C:5B"  // POSTE 1 ETHERNET
                || vppAdresseMAC == "60:18:95:51:73:24" // POSTE 2 ETHERNET
                || vppAdresseMAC == "C4:23:60:6A:EF:2D"  //POSTE 2 WIFI
                || vppAdresseMAC == "60:18:95:21:0F:72" //POSTE 3  ETHERNET
                || vppAdresseMAC == "5C:61:99:30:5F:67"  //POSTE 3 WIFI
                || vppAdresseMAC == "60:18:95:51:7E:EB" //POSTE 4 ETHERNET 
                || vppAdresseMAC == "C4:23:60:6D:45:ED" //POSTE 4 WIFI 
                || vppAdresseMAC == "84:2A:FD:71:CA:B6" //POSTE 5 ETHERNET 
                || vppAdresseMAC == "5C:3A:45:93:C7:D7" //POSTE 5 WIFI 
                || vppAdresseMAC == "60:18:95:51:72:79" //POSTE 6 ETHERNET 
                || vppAdresseMAC == "C4:23:60:6D:47:0A" //POSTE 6 WIFI 
                || vppAdresseMAC == "5C:3A:45:93:C7:D7" //POSTE 7 ETHERNET 
                || vppAdresseMAC == "84:2A:FD:71:CA:B6" //POSTE 7 WIFI 

                || vppAdresseMAC == "00:68:EB:C6:76:D0"  // POSTE 1
                || vppAdresseMAC == "00:68:EB:C6:76:86" // POSTE 2
                || vppAdresseMAC == "00:68:EB:C7:BF:72"  //POSTE 3
                || vppAdresseMAC == "00:68:EB:C6:76:5F" //POSTE 4
                || vppAdresseMAC == "30:D0:42:1F:FD:34"  //POSTE 5
                || vppAdresseMAC == "18:47:3D:DB:DC:55" //POSTE 5 
                || vppAdresseMAC == "A4:97:B1:AB:6F:9F" //POSTE 6
                || vppAdresseMAC == "30:D0:42:33:72:F9" //POSTE 6

                || vppAdresseMAC == "74:4C:A1:52:9E:5F"  // POSTE 1
                || vppAdresseMAC == "E4:A8:DF:F6:10:C3" // POSTE 1
                || vppAdresseMAC == "18:47:3D:DC:0C:31"  //POSTE 2 
                || vppAdresseMAC == "30:D0:42:1F:FD:79" //POSTE 2
                || vppAdresseMAC == "18:47:3D:DB:DB:AB"  //POSTE 3
                || vppAdresseMAC == "30:D0:42:1F:FD:26" //POSTE 3
                || vppAdresseMAC == "18:47:3D:DC:7D:51" //POSTE 4 
                || vppAdresseMAC == "30:D0:42:1F:FE:FA" //POSTE 4
                || vppAdresseMAC == "18:47:3D:DC:7C:EF" //POSTE 5
                || vppAdresseMAC == "30:D0:42:1F:FE:0E" //POSTE 5
                || vppAdresseMAC == "C8:3D:D4:70:13:CF" //POSTE 6
                || vppAdresseMAC == "C8:5B:76:A5:F9:7B" //POSTE 6
                || vppAdresseMAC == "00:68:EB:C7:6A:41" //POSTE 7

                //11-01-2022
                || vppAdresseMAC == "00:68:EB:C7:BD:21" // POSTE 1
                || vppAdresseMAC == "00:68:EB:C6:BF:74"  //POSTE 2 
                || vppAdresseMAC == "00:68:EB:C7:C0:5D" //POSTE 3


                //14-02-2022
                || vppAdresseMAC == "50:81:40:4C:5E:F0" // POSTE 1
                || vppAdresseMAC == "74:12:B3:F4:AE:F1" // POSTE 1
                || vppAdresseMAC == "50:81:40:32:6D:E0"  //POSTE 2 
                || vppAdresseMAC == "80:D2:1D:F6:0D:05"  //POSTE 2 
                || vppAdresseMAC == "00:2B:67:77:4B:D1" //POSTE 3
                || vppAdresseMAC == "3C:58:C2:D7:65:40" //POSTE 3
                || vppAdresseMAC == "50:81:40:32:C8:16" // POSTE 4
                || vppAdresseMAC == "80:D2:1D:F4:94:C3" // POSTE 4
                || vppAdresseMAC == "8C:8C:AA:3F:FB:44" // POSTE 5
                || vppAdresseMAC == "8C:8D:28:35:98:05" // POSTE 5

                //09-03-2022
                || vppAdresseMAC == "14:CB:19:CE:2D:C0" // ANO 1
                || vppAdresseMAC == "90:0F:0C:27:5D:7D" // ANO 1
                || vppAdresseMAC == "8C:8C:AA:DD:17:8D" //FABRICE 3
                || vppAdresseMAC == "38:FC:98:9D:8A:EB" //FABRICE 3
                || vppAdresseMAC == "60:18:95:50:22:6C" // OUDOU 4
                || vppAdresseMAC == "94:E2:3C:E8:C1:41" // OUDOU 4
                || vppAdresseMAC == "60:18:95:51:6D:7C" // WIFRIED 5
                || vppAdresseMAC == "14:85:7F:C3:3D:B3" // WIFRIED 5
                || vppAdresseMAC == "60:18:95:51:6C:4E" // YVES 6
                || vppAdresseMAC == "C4:23:60:6A:3B:14" // YVES 6

                //12-03-2022
                || vppAdresseMAC == "00:68:EB:BF:C4:AB"
                || vppAdresseMAC == "00:68:EB:B1:F5:AF"
                || vppAdresseMAC == "00:68:EB:BB:5E:0E"

                //28-03-2022
                || vppAdresseMAC == "00:68:EB:C6:76:A8"
                || vppAdresseMAC == "00:68:EB:C7:6C:F1"
                || vppAdresseMAC == "CC:F9:E4:96:CE:68"
                || vppAdresseMAC == "B4:A9:FC:94:A3:C8"

                //08-04-2022
                || vppAdresseMAC == "B0:22:7A:F8:4F:4E"
                || vppAdresseMAC == "A4:97:B1:BF:BF:35"
                || vppAdresseMAC == "B0:22:7A:F8:CE:0F"
                || vppAdresseMAC == "A4:97:B1:BF:9F:4B"

                || vppAdresseMAC == "60:18:95:50:1D:4F"
                || vppAdresseMAC == "14:85:7F:63:04:1B"
                || vppAdresseMAC == "60:18:95:51:6E:67"
                || vppAdresseMAC == "14:85:7F:C3:71:A2"

                || vppAdresseMAC == "30:D0:42:20:AE:B3"
                || vppAdresseMAC == "18:47:3D:44:45:23"

                || vppAdresseMAC == "60:18:95:50:22:27"
                || vppAdresseMAC == "94:E2:3C:EB:F5:46"
                || vppAdresseMAC == "30:D0:42:24:58:F1"
                || vppAdresseMAC == "18:47:3D:2D:1A:9F"


                || vppAdresseMAC == "B0:22:7A:F8:50:58"
                || vppAdresseMAC == "A4:97:B1:BF:7D:5B"
                || vppAdresseMAC == "B0:22:7A:F8:CE:40"
                || vppAdresseMAC == "A4:97:B1:BF:A3:71"

                || vppAdresseMAC == "B0:22:7A:F8:50:AF"
                || vppAdresseMAC == "A4:97:B1:C0:3D:93"
                || vppAdresseMAC == "60:18:95:51:6D:9D"
                || vppAdresseMAC == "14:85:7F:C2:D6:8E"

                || vppAdresseMAC == "60:18:95:50:1C:EE"
                || vppAdresseMAC == "14:85:7F:5F:29:6D"
                || vppAdresseMAC == "60:18:95:51:6D:7F"
                || vppAdresseMAC == "14:85:7F:C3:46:23"

                //13-04-2022
                || vppAdresseMAC == "00:68:EB:C6:73:EE"
                || vppAdresseMAC == "00:68:EB:C7:7D:1C"
                || vppAdresseMAC == "00:68:EB:C6:D9:BA"



                //27-04-2022
                || vppAdresseMAC == "B0:22:7A:F8:CE:0F"
                || vppAdresseMAC == "A4:97:B1:BF:9F:4B"
                || vppAdresseMAC == "84:1B:77:6C:BB:AF"
                || vppAdresseMAC == "A0:29:19:59:D8:F4"
                || vppAdresseMAC == "60:A5:E2:48:5B:A7"

                )
            {
                return true;
            }
            //18-wittifinances BOUAKE
            else if (
                vppAdresseMAC == "EC:B1:D7:4D:BC:97" || vppAdresseMAC == "EC:B1:D7:51:DB:6C"
                || vppAdresseMAC == "EC:B1:D7:5C:87:FC"
                || vppAdresseMAC == "48:0F:CF:4E:88:87"//Agent de credit bouaké
                || vppAdresseMAC == "48:0F:CF:4E:88:65"//Caissiere 2 bouaké
                )
            {
                return true;
            }

            //19-wittifinances PORT-BOUET
            else if (
                vppAdresseMAC == "F0:92:1C:F5:5E:D0" || vppAdresseMAC == "F0:92:1C:F6:D8:19"
                || vppAdresseMAC == "F0:92:1C:F0:17:53"
                )
            {
                return true;
            }

            //19-YVEO-FINANCES
            else if (
                vppAdresseMAC == "5C:93:A2:DF:14:A8" || vppAdresseMAC == "EC:B1:D7:94:C3:57" || vppAdresseMAC == "40:F2:E9:F8:7A:41"
                || vppAdresseMAC == "40:F2:E9:F8:7A:40" || vppAdresseMAC == "40:F2:E9:F8:7A:43" || vppAdresseMAC == "40:F2:E9:F8:7A:42"
                || vppAdresseMAC == "C4:34:6B:60:59:66" || vppAdresseMAC == "C4:34:6B:60:59:DC" || vppAdresseMAC == "C4:34:6B:4F:B9:7C"
                || vppAdresseMAC == "5C:B9:01:43:10:22" || vppAdresseMAC == "34:68:95:A1:38:21"

                //VIRTUALBOX YVEO
                || vppAdresseMAC == "08:00:27:00:20:D7"

                //-SIEGE
                || vppAdresseMAC == "5C:93:A2:DF:14:A8"//Client PC HP Carte Wifi    : 
                || vppAdresseMAC == "EC:B1:D7:94:C3:57"//Client PC HP Carte Ethernet:
                || vppAdresseMAC == "AC:16:2D:09:44:DE " //SERVEUR Carte Ethernet:



                //-SERVEUR/20-11-2017
                || vppAdresseMAC == "9C:DC:71:AF:9D:48"//
                || vppAdresseMAC == "9C:DC:71:AF:9D:49"//

                //Ordinateurs Clients/20-11-2017
                || vppAdresseMAC == "70:5A:0F:44:CB:D7" || vppAdresseMAC == "70:5A:0F:40:5C:51" || vppAdresseMAC == "70:5A:0F:43:D6:8E"
                || vppAdresseMAC == "70:5A:0F:43:D7:CF" || vppAdresseMAC == "70:5A:0F:44:89:90" || vppAdresseMAC == "70:5A:0F:3E:7A:C0"
                || vppAdresseMAC == "70:5A:0F:44:CC:0F"


                //15-05-2018
                || vppAdresseMAC == "54:E1:AD:5E:6F:CD"// Mme Fofana ethernet
                || vppAdresseMAC == "3C:95:09:F7:66:A5"// Mme Fofana WIFI
                || vppAdresseMAC == "3C:52:82:13:68:EC"//ETHERNET Mr EGNAKOU
                || vppAdresseMAC == "3C:A0:67:BA:3F:45"//WIFI Mr EGNAKOU
                || vppAdresseMAC == "18:60:24:BE:94:6E"//RTHERNET Mr KOUYATE
                || vppAdresseMAC == "40:9F:38:63:7B:75"//WIFI Mr KOUYATE
                || vppAdresseMAC == "54:E1:AD:5D:8B:FB"//ETHERNET MR KEKE
                || vppAdresseMAC == "3C:95:09:F7:D5:27"//WIFI MR KEKE
                || vppAdresseMAC == "48:0F:CF:48:3A:C5"//RTHERNET: POST 1
                || vppAdresseMAC == "74:46:A0:B3:87:1B"//ETHENET: POSTE 2
                || vppAdresseMAC == "50:65:F3:2A:FA:5B"//ETHERNET:POSTE 3
                || vppAdresseMAC == "E8:39:35:40:E4:28"//ETHERNET:POSTE 4

                || vppAdresseMAC == "F4:30:B9:98:91:20"//ETHERNET:POSTE 5 Reponsable Commerciale 
                || vppAdresseMAC == "54:13:79:AC:ED:B3"//WIFI:POSTE 5 Reponsable Commerciale 


                //04-08-2019
                || vppAdresseMAC == "8C:89:A5:F6:18:58"// PC 1  ethernet
                || vppAdresseMAC == "8C:89:A5:F6:18:56"// COMPTABLE ethernet
                || vppAdresseMAC == "5C:B9:01:43:0E:F8"//CONTROLER INTERNE ethernet
                || vppAdresseMAC == "34:68:95:A1:83:D7"//CONTROLER INTERNE WIFI
                || vppAdresseMAC == "78:45:C4:B0:F5:A0"//FORMATEUR ethernet
                || vppAdresseMAC == "C0:18:85:C7:20:0F"//FORMATEUR WIFI
                || vppAdresseMAC == "70:F3:95:05:65:3D"//SECRETAIRE ethernet

                //08/02/2021
                || vppAdresseMAC == "D4:BE:D9:86:14:0C"//AGENT DE CREDIT/ETHERNET
                || vppAdresseMAC == "B8:EE:65:46:2E:46"//AGENT DE CREDIT/WIFI
                || vppAdresseMAC == "F0:1F:AF:3A:62:6C"//GERANTE/ETHERNET
                || vppAdresseMAC == "A4:4E:31:35:FC:80"//GERANTE/WIFI

                //04/10/2022
                || vppAdresseMAC == "9C:B6:54:F2:77:C1"
                || vppAdresseMAC == "00:68:EB:99:7F:8B"
                || vppAdresseMAC == "9C:B6:54:F2:78:F9"

                //09-11-2022
                || vppAdresseMAC == "E4:6F:13:F4:06:EE"


                )
            {
                return true;
            }
            //20-PC Louis
            else if (
                vppAdresseMAC == "B8:70:F4:57:9C:3E" || vppAdresseMAC == "B4:74:9F:C6:8C:72"
                || vppAdresseMAC == "08:00:27:00:68:07"
                )
            {
                return true;
            }
            //21-PC RAOUDA FINANCE
            else if (
                   vppAdresseMAC == "00:23:7D:1E:B4:5D" || vppAdresseMAC == "40:F0:2F:11:DB:07" || vppAdresseMAC == "A0:D3:C1:0D:23:77"
                || vppAdresseMAC == "A0:1D:48:70:EF:26" || vppAdresseMAC == "28:E3:47:81:CB:54" || vppAdresseMAC == "40:A8:F0:02:98:7C"
                || vppAdresseMAC == "40:A8:F0:02:9C:E5" || vppAdresseMAC == "00:23:79:1E:B4:5D" || vppAdresseMAC == "00:23:79:1E:B4:5D"
                || vppAdresseMAC == "A0:D3:C1:0D:D3:FF" || vppAdresseMAC == "90:1B:0E:1D:48:3B" || vppAdresseMAC == "A0:D3:C1:0D:D4:2C"
                || vppAdresseMAC == "40:A8:F0:02:9C:E5" || vppAdresseMAC == "1A:E3:47:81:CB:5E" || vppAdresseMAC == "A0:1D:48:BB:98:DF"
                || vppAdresseMAC == "40:F0:2F:11:E4:93" || vppAdresseMAC == "28:E3:47:7C:BE:DF" || vppAdresseMAC == "28:E3:47:81:CB:5E"
                || vppAdresseMAC == "08:00:27:00:94:3A" || vppAdresseMAC == "40:A8:F0:02:9C:EE" || vppAdresseMAC == "28:92:4A:2B:F4:39"
                || vppAdresseMAC == "28:92:4A:2B:F4:38" || vppAdresseMAC == "D0:BF:9C:89:FD:25" || vppAdresseMAC == "74:29:AF:70:01:87"
                || vppAdresseMAC == "14:58:D0:C9:50:73" || vppAdresseMAC == "30:10:B3:0C:75:B7" || vppAdresseMAC == "08:00:27:00:40:AA"//08:00:27:00:40:AA est de virtualbox machine test.

                //RAOUDA KOUMASSI
                || vppAdresseMAC == "DC:4A:3E:D1:D9:1A" || vppAdresseMAC == "60:6D:C7:E5:D3:F7" || vppAdresseMAC == "DC:4A:3E:D1:D8:E3"
                || vppAdresseMAC == "60:6D:C7:E6:1C:DD" || vppAdresseMAC == "00:24:BE:7A:3C:2C" || vppAdresseMAC == "00:26:5E:FD:FE:B8"
                || vppAdresseMAC == "8C:DC:D4:4F:FA:F9"
                //22/03/2020
                || vppAdresseMAC == "A4:BA:DB:9D:6D:07" //KONAN ETHERNET
                || vppAdresseMAC == "70:1A:04:E3:4A:88" //KONAN WIFI




                //NEWS PC
                || vppAdresseMAC == "34:DE:1A:E9:1F:4C" || vppAdresseMAC == "50:7B:9D:7F:03:DE"

                //NEWS PC2
                || vppAdresseMAC == "1C:39:47:DA:36:E7" || vppAdresseMAC == "E4:02:9B:27:C7:6B" || vppAdresseMAC == "E4:02:9B:27:C7:67"

                //NEWS RAOUDA FINANCE 30-01-2018
                || vppAdresseMAC == "C0:21:0D:5E:31:C1" || vppAdresseMAC == "C2:21:0D:5E:31:C1"

                //16-07-2018
                || vppAdresseMAC == "50:7B:9D:7F:03:DE" //poste 1  Carte wifi 
                || vppAdresseMAC == "2C:FD:A1:AA:90:B5" //poste 2 Carte ethernet
                || vppAdresseMAC == "98:22:EF:2B:9E:F7" //poste 2  Carte wifi 
                || vppAdresseMAC == "2C:FD:A1:AA:91:85" //poste 3 Carte ethernet
                || vppAdresseMAC == "98:22:EF:2B:9F:38" //poste 3  Carte wifi 
                || vppAdresseMAC == "2C:FD:A1:AB:15:DB" //poste 4 Carte ethernet
                || vppAdresseMAC == "98:22:EF:36:2B:67" //poste 4  Carte wifi 
                || vppAdresseMAC == "2C:FD:A1:AB:15:5E" //poste 5 Carte ethernet
                || vppAdresseMAC == "98:22:EF:36:31:08" //poste 5  Carte wifi 
                || vppAdresseMAC == "2C:FD:A1:AA:91:D0" //poste 6 Carte ethernet
                || vppAdresseMAC == "98:22:EF:2B:9B:24" //poste 6  Carte wifi 
                || vppAdresseMAC == "2C:FD:A1:56:2D:1F" //poste 7 Carte ethernet
                || vppAdresseMAC == "98:22:EF:32:6A:46" //poste 7  Carte wifi 
                || vppAdresseMAC == "10:E7:C6:79:89:15" //poste 8 Carte ethernet
                || vppAdresseMAC == "E0:9D:31:DF:13:6D" //poste 8  Carte wifi 

                //06-09-2018
                || vppAdresseMAC == "58:8A:5A:15:07:F2" //Carte ethernet
                || vppAdresseMAC == "B0:52:16:C1:F8:BD" //Carte Wifi    
                || vppAdresseMAC == "2C:FD:A1:AB:16:38" //POSTE 34  
                || vppAdresseMAC == "98:22:EF:36:31:48" //POSTE 34  
                || vppAdresseMAC == "E0:9D:31:DF:13:6C" //poste 37

                //21-11-2018
                || vppAdresseMAC == "2C:FD:A1:AB:2D:A2" //PO42_RC ETHERNET
                || vppAdresseMAC == "98:22:EF:2E:63:EB" //PO42_RC    WIFI
                || vppAdresseMAC == "2C:FD:A1:AB:28:0F" //Poste 72 Gerante   ETHERNET
                || vppAdresseMAC == "98:22:EF:2E:67:D7" //Poste 72 Gerante WIFI

                //BOUAKE 07-12-2018
                || vppAdresseMAC == "00:22:64:BC:77:28" // ETHERNET


                //22-03-2020
                || vppAdresseMAC == "00:0F:FE:CD:91:20" //BUREAU 1 ETHERNET
                || vppAdresseMAC == "F4:BC:EB:4C:9F:0B" //BUREAU 1 WIFI

                || vppAdresseMAC == "64:31:50:1D:D1:29" //BUREAU 2 ETHERNET
                || vppAdresseMAC == "1C:BF:CE:42:94:74" //BUREAU 2 WIFI

                || vppAdresseMAC == "68:F7:28:47:73:64" //PORTABLE 1 ETHERNET
                || vppAdresseMAC == "5C:C5:D4:09:6C:6C" //PORTABLE 1 WIFI	

                || vppAdresseMAC == "28:D2:44:B9:34:08" //PORTABLE 2 ETHERNET
                || vppAdresseMAC == "28:B2:BD:32:0C:17" //PORTABLE 2 WIFI

                || vppAdresseMAC == "28:D2:44:DB:6E:A4" //PORTABLE 3 ETHERNET
                || vppAdresseMAC == "28:B2:BD:8D:CF:39" //PORTABLE 3 WIFI

                || vppAdresseMAC == "68:F7:28:45:F5:F1" //PORTABLE 4 ETHERNET
                || vppAdresseMAC == "5C:C5:D4:0C:69:5D" //PORTABLE 4 WIFI

                || vppAdresseMAC == "28:D2:44:BC:E3:F7" //PORTABLE 5 ETHERNET
                || vppAdresseMAC == "28:B2:BD:2B:55:11" //PORTABLE 5 WIFI




                //DIRECTION GENERALE 07-12-2018
                || vppAdresseMAC == "5C:B9:01:AB:73:57" //GERANTE-ETHERNET
                || vppAdresseMAC == "D8:FC:93:AC:4C:DE" //GERANTE-WIFI

                //DIRECTION GENERALE 21-01-2019
                || vppAdresseMAC == "2C:FD:A1:AA:E1:2D" //ETHERNET
                || vppAdresseMAC == "98:22:EF:2B:9F:1F" //WIFI


                //DIRECTION GENERALE 20-08-2019
                || vppAdresseMAC == "54:48:10:C1:47:25" //ABDUL ETHERNET
                || vppAdresseMAC == "74:40:BB:1C:6F:5D" //ABDUL WIFI


                //DIRECTION GENERALE 12-10-2019
                || vppAdresseMAC == "B4:B6:86:0F:B4:5F" //MEHI ETHERNET
                || vppAdresseMAC == "80:C5:F2:86:B6:FD" //MEHI WIFI
                || vppAdresseMAC == "08:ED:B9:43:83:59" //ODAHIN WIFI
                || vppAdresseMAC == "F0:DE:F1:EC:CC:43" //ODAHIN ETHERNET


                //04-02-2020
                || vppAdresseMAC == "28:80:23:C2:2B:BD" //BAKAYOKO ETHERNET
                || vppAdresseMAC == "28:E3:47:85:85:81" //BAKAYOKO WIFI
                || vppAdresseMAC == "00:1B:77:87:05:93" //BEDIAKON ETHERNET
                || vppAdresseMAC == "E8:6A:64:C9:F6:99" //ROKIA ETHERNET 
                || vppAdresseMAC == "3C:91:80:28:F0:5D" //ROKIA WIFI
                || vppAdresseMAC == "28:92:4A:26:04:CD" //TIMITE ETHERNET
                || vppAdresseMAC == "74:E5:43:EF:67:49" //TIMITE WIFI
                || vppAdresseMAC == "DC:0E:A1:1B:D5:94" //FATIME ETHERNET
                || vppAdresseMAC == "74:DE:2B:E4:36:DA" //FATIME ETHERNET

                //22-03-2020
                || vppAdresseMAC == "30:65:EC:8A:B7:CD" //BEDIAKON ABDULAYE ETHERNET
                || vppAdresseMAC == "94:65:9C:EF:4F:48" //BEDIAKON ABDULAYE WIFI
                || vppAdresseMAC == "84:A9:3E:5C:BD:6C" //LE GERANT ETHERNET
                || vppAdresseMAC == "D8:9C:67:24:39:FD" //LE GERANT WIFI 
                || vppAdresseMAC == "70:10:6F:B0:AD:D0" //SERVEUR ETHERNET
                || vppAdresseMAC == "70:10:6F:B0:AD:D1" //SERVEUR ETHERNET
                || vppAdresseMAC == "70:10:6F:B0:AD:D2" //SERVEUR ETHERNET
                || vppAdresseMAC == "70:10:6F:B0:AD:D3" //SERVEUR ETHERNET
                || vppAdresseMAC == "70:10:6F:B0:AD:D4" //SERVEUR ETHERNET


                //18/04/2020
                || vppAdresseMAC == "C4:65:16:12:99:72" //Bureau 1  M/066 ETHERNET
                || vppAdresseMAC == "C4:65:16:12:98:3C" //Bureau 2  M/065 ETHERNET
                || vppAdresseMAC == "C4:65:16:12:98:EE" //Bureau 3  M/067 ETHERNET
                || vppAdresseMAC == "C4:65:16:11:4A:97" //Bureau 4  M/068 ETHERNET 
                || vppAdresseMAC == "7C:8A:E1:1B:AF:18" //Portable ETHERNET
                || vppAdresseMAC == "28:39:26:AF:E8:99" //Portable WIFI


                //16/09/2020
                || vppAdresseMAC == "F0:DE:F1:D9:5F:32" //ETHERNET
                || vppAdresseMAC == "08:11:96:E6:9F:A8" //WIFI

                //09/12/2020
                || vppAdresseMAC == "44:1C:A8:3A:E3:41" //ETHERNET 


                //16/08/2021
                || vppAdresseMAC == "74:E5:43:EF:67:49" //POSTE 1 WIFI
                || vppAdresseMAC == "FC:01:7C:6A:1F:C1" //POSTE 2 WIFI
                || vppAdresseMAC == "B4:B6:86:90:9B:C4" //POSTE 2 ETHERNET

                //20/10/2021
                || vppAdresseMAC == "00:19:99:FB:B3:C2"


                //04/11/2021
                || vppAdresseMAC == "0C:8B:FD:3C:BF:7C" //POSTE 1 ETHERNET
                || vppAdresseMAC == "00:26:22:7F:41:47" //POSTE 2 ETHERNET 

                //28-02-2022
                || vppAdresseMAC == "82:C5:EA:42:78:B0"

                //18/03/2022
                || vppAdresseMAC == "90:FB:A6:04:56:23" //POSTE 1 WIFI
                || vppAdresseMAC == "90:FB:A6:04:26:9A" //POSTE 2 WIFI
                || vppAdresseMAC == "00:23:24:6D:31:63" //POSTE 2 ETHERNET
                || vppAdresseMAC == "D0:27:88:8C:FA:51" //POSTE 2 ETHERNET


                //30/03/2022
                || vppAdresseMAC == "90:FB:A6:04:56:23"
                || vppAdresseMAC == "90:FB:A6:04:26:9A"
                || vppAdresseMAC == "00:23:24:6D:31:63"
                || vppAdresseMAC == "D0:27:88:8C:FA:51"
                //10-06-2022
                || vppAdresseMAC == "E4:B3:18:D3:1D:91"


                //23/09/2022
                || vppAdresseMAC == "2C:FD:A1:AB:16:5E"
                || vppAdresseMAC == "98:22:EF:36:31:08"

                //16/12/2022
                || vppAdresseMAC == "F4:8C:EB:4C:9F:08"
                || vppAdresseMAC == "00:22:64:BC:77:28"


                //03/04/2023 
                || vppAdresseMAC == "76:01:DE:60:0F:56"



                )
            {
                return true;
            }
            //22-PC FONIC GABIADJI
            else if (
                    vppAdresseMAC == "40:B0:34:94:39:15" //PC  HP
                    || vppAdresseMAC == "40:B0:34:6E:27:58" //PC HP
                    || vppAdresseMAC == "50:65:F3:4E:02:3B"//ORD BUREAU CAISSE
                    || vppAdresseMAC == "50:65:F3:4E:0D:1C" //ORD BUREAU HALL
                    || vppAdresseMAC == "DC:4A:3E:6A:89:C0" //SERVEUR
                                                            //22-07-2021
                    || vppAdresseMAC == "6C:3B:E5:26:55:8E" //POSTE 1 / ISMAEL DIABAKATE

                    //07-04-2023
                    || vppAdresseMAC == "C8:5A:CF:0D:EE:C4"
                )
            {
                return true;
            }
            //22-PC FONIC SANPEDRO
            else if (
                    vppAdresseMAC == "00:21:5A:20:06:6D" //HALL:
                    || vppAdresseMAC == "EC:B1:D7:45:C5:B7" //CREDIT: 
                    || vppAdresseMAC == "8C:DC:D4:4F:F2:BE"//COMPTABILITE:
                    || vppAdresseMAC == "00:E0:4F:D9:50:62" //CAISSE2:
                    || vppAdresseMAC == "00:E0:4C:07:D3:78" //CAISSE2:
                    || vppAdresseMAC == "48:0F:CF:33:9A:26"//CAISSE1 :  
                    || vppAdresseMAC == "44:87:FC:AD:41:89" //ORDINATEUR
                    || vppAdresseMAC == "70:5A:B6:C0:97:D4"//PORTABLE :
                    || vppAdresseMAC == "DC:4A:3E:6A:89:9F"//SERVEUR






                )
            {
                return true;
            }

            //24-PC LAFINANCIERE,Il faut contrôler les adresses mac des ordinateurs et les ordinateurs réels,car cela est anormale
            else if (
                vppAdresseMAC == "A0:B3:CC:E0:82:2A" || vppAdresseMAC == "84:34:97:8E:34:F1" || vppAdresseMAC == "B4:B5:2F:B8:83:F8"
                || vppAdresseMAC == "00:19:21:15:A3:98" || vppAdresseMAC == "00:1B:B9:C5:24:D0" || vppAdresseMAC == "00:1B:B9:CF:20:F4"
                || vppAdresseMAC == "B4:B5:2F:B8:87:04" || vppAdresseMAC == "E8:40:F2:0E:0E:C6" || vppAdresseMAC == "E0:06:E6:F5:91:CB"
                || vppAdresseMAC == "A0:D3:C1:28:48:2E" || vppAdresseMAC == "40:A8:F0:45:00:0D"
                || vppAdresseMAC == "04:7D:7B:02:57:C1" || vppAdresseMAC == "74:DE:2B:85:9A:FE"
                || vppAdresseMAC == "38:60:77:D8:79:CA" || vppAdresseMAC == "74:DE:2B:B9:0A:12"
                || vppAdresseMAC == "84:34:97:91:A6:03" || vppAdresseMAC == "A4:17:31:58:E9:16"
                || vppAdresseMAC == "A0:B3:CC:E0:76:9A" || vppAdresseMAC == "A0:B3:CC:E0:76:9B"
                || vppAdresseMAC == "8C:DC:D4:4C:86:F0" || vppAdresseMAC == "50:65:F3:28:09:23"

                //SEGUELA
                || vppAdresseMAC == "6C:3B:E5:2C:81:19" || vppAdresseMAC == "6C:3B:E5:2B:47:0F"


                //TOUMODI
                || vppAdresseMAC == "E8:39:35:59:82:31" || vppAdresseMAC == "00:E0:4C:36:1C:9E"
                || vppAdresseMAC == "00:E0:4C:36:1C:65" || vppAdresseMAC == "7C:4F:B5:14:0C:CD"
                || vppAdresseMAC == "B8:70:F4:4D:1F:OE"
                )
            {
                return true;
            }
            //22-PC FONIC DOKOUI
            else if (
                vppAdresseMAC == "28:92:4A:2B:AB:90" || vppAdresseMAC == "00:E0:4c:50:FA:EB" || vppAdresseMAC == "44:87:FC:AD:42:8A"
                || vppAdresseMAC == "00:E0:4C:3B:4B:2C" || vppAdresseMAC == "00:21:97:79:63:3C" || vppAdresseMAC == "D0:27:88:0A:C7:CE"
                || vppAdresseMAC == "00:19:DB:53:39:13" || vppAdresseMAC == "F0:7B:CB:62:A7:94" || vppAdresseMAC == "C8:0A:A9:3F:DF:44"
                || vppAdresseMAC == "06:24:D2:69:62:A7" || vppAdresseMAC == "00:1E:33:BD:C8:B2" || vppAdresseMAC == "00:E0:4C:50:FA:EB"
                || vppAdresseMAC == "00:E0:4C:3B:5D:AA" || vppAdresseMAC == "00:E0:4A:09:E6:AA"

                || vppAdresseMAC == "00:0A:17:0D:00:18" //SERVEUR
                || vppAdresseMAC == "00:07:0B:01:10:23"//MISS ANGELE 

                //NOUVEAUX POSTES DU 14-12-2017
                || vppAdresseMAC == "00:0F:FE:24:81:76"
                || vppAdresseMAC == "00:07:0B:0D:1A:3A"

                //NOUVEAUX POSTES DU 20-01-2018, ORDINATEUR mr kouadio
                || vppAdresseMAC == "00:0F:EF:24:81:76"

                //NOUVEAUX POSTES DU 25-04-2018
                || vppAdresseMAC == "00:04:09:11:0A:10"

                //NOUVEAUX POSTES DU 01-06-2018
                || vppAdresseMAC == "00:03:14:09:1B:11"

                //07-12-2018
                || vppAdresseMAC == "00:E0:4D:B9:1B:42"

                //03/06/2020
                || vppAdresseMAC == "EC:B1:D7:99:85:7D"// GERANTE ETHERNET
                || vppAdresseMAC == "80:19:34:F1:50:90"// GERANTE WIFI

                //17/08/2020
                || vppAdresseMAC == "78:AC:C0:A4:6B:9A"// CAISSE 3 ETHERNET
                || vppAdresseMAC == "C8:D9:D2:2D:69:35"// POSTE 1 ETHERNET
                || vppAdresseMAC == "C8:D9:D2:31:ED:90"// POSTE 2  ETHERNET
                || vppAdresseMAC == "38:22:E2:C1:F6:6D"// POSTE 3  ETHERNET
                || vppAdresseMAC == "3C:D9:2B:6C:4C:F9"// AGENT DE CREDIT ETHERNET

                || vppAdresseMAC == "C8:D9:D2:31:FE:85"// MACHINE VIRTUELLE  ETHERNET





                )
            {
                return true;
            }
            //23-PC CREDIT MUTUEL PLATEAU
            else if (
                vppAdresseMAC == "64:51:06:36:8D:ED" || vppAdresseMAC == "80:C1:6E:ED:D7:DA" || vppAdresseMAC == "64:51:06:3B:C1:AE"
                || vppAdresseMAC == "80:C1:6E:ED:D5:14" || vppAdresseMAC == "64:51:06:30:24:C3" || vppAdresseMAC == "64:51:06:30:25:EA"
                || vppAdresseMAC == "C4:34:6B:55:48:A8" || vppAdresseMAC == "64:51:06:30:25:27"
                )
            {
                return true;
            }
            //24-PC CELPAID
            else if (
                vppAdresseMAC == "38:60:77:9B:67:74" || vppAdresseMAC == "70:5A:B6:B7:8A:C2"
                || vppAdresseMAC == "EC:B1:D7:2F:3E:0A" || vppAdresseMAC == "EC:B1:D7:2F:3B:60" || vppAdresseMAC == "EC:B1:D7:2F:3C:96" || vppAdresseMAC == "EC:B1:D7:31:AD:58"
                || vppAdresseMAC == "EC:B1:D7:31:B5:76" || vppAdresseMAC == "EC:B1:D7:31:B3:EC" || vppAdresseMAC == "EC:B1:D7:34:54:B4" || vppAdresseMAC == "84:8F:69:E4:7A:A1"
                || vppAdresseMAC == "84:8F:69:E4:7A:A5" || vppAdresseMAC == "84:8F:69:E4:7A:A3" || vppAdresseMAC == "84:8F:69:E4:7A:A7"
                || vppAdresseMAC == "34:68:95:AA:FF:63" || vppAdresseMAC == "5C:B9:01:40:EA:C1" || vppAdresseMAC == "34:68:95:AB:15:E1" || vppAdresseMAC == "5C:B9:01:40:EB:EB"
                || vppAdresseMAC == "8C:DC:D4:4C:97:8C" || vppAdresseMAC == "D8:5D:E2:9E:22:E7" || vppAdresseMAC == "58:20:B1:3E:AC:0A" || vppAdresseMAC == "C4:E9:84:00:7F:D4"
                || vppAdresseMAC == "C4:E9:84:00:48:F6" || vppAdresseMAC == "0A:00:27:00:00:28"


                //MACHINE VIRTUEL DU POSTE ISOLE
                || vppAdresseMAC == "0A:00:27:00:00:09"

                //NOUVEAUX POSTES DE CELPAID
                || vppAdresseMAC == "00:01:6C:D7:9E:B5" || vppAdresseMAC == "00:01:6C:D7:4B:F8" || vppAdresseMAC == "00:01:6C:D7:98:9F" || vppAdresseMAC == "00:01:6C:D7:78:36"
                || vppAdresseMAC == "00:01:6C:D7:9D:46" || vppAdresseMAC == "00:01:6C:D7:9C:DC" || vppAdresseMAC == "00:01:6C:D7:98:BD" || vppAdresseMAC == "00:01:6C:D7:77:9A"
                || vppAdresseMAC == "00:01:6C:D7:9D:23" || vppAdresseMAC == "00:01:6C:D7:9D:4A" || vppAdresseMAC == "00:01:6C:D7:53:62" || vppAdresseMAC == "00:01:6C:D7:9E:39"
                || vppAdresseMAC == "00:01:6C:D7:9D:03" || vppAdresseMAC == "00:01:6C:D7:96:E0" || vppAdresseMAC == "00:01:6C:D7:9D:05" || vppAdresseMAC == "00:01:6C:D7:98:2E"
                || vppAdresseMAC == "00:01:6C:D7:99:84" || vppAdresseMAC == "00:01:6C:D7:9C:6E" || vppAdresseMAC == "00:01:6C:D7:9A:2D" || vppAdresseMAC == "00:01:6C:D7:7F:50"

                //NOUVEAUX POSTES DE CELPAID MR BAMBA
                || vppAdresseMAC == "E8:40:F2:73:DB:13"


                //NOUVEAUX POSTES DE CELPAID DEUXIEMME VAGUE
                || vppAdresseMAC == "00:01:6C:D7:9B:2E" || vppAdresseMAC == "00:01:6C:D7:9A:A6" || vppAdresseMAC == "00:01:6C:D7:9D:D6" || vppAdresseMAC == "00:01:6C:D7:98:B5"
                || vppAdresseMAC == "00:01:6C:D7:9A:43" || vppAdresseMAC == "00:01:6C:D7:9D:14" || vppAdresseMAC == "00:01:6C:D7:9C:BD" || vppAdresseMAC == "00:01:6C:D7:9B:D0"
                || vppAdresseMAC == "00:01:6C:D7:78:3F" || vppAdresseMAC == "00:01:6C:D7:9B:8E" || vppAdresseMAC == "00:01:6C:D7:7E:E9" || vppAdresseMAC == "00:01:6C:D7:77:F0"
                || vppAdresseMAC == "00:01:6C:D7:97:03" || vppAdresseMAC == "00:01:6C:D7:9D:C5"

                //ex credit1-bonoua,caisse-aboisso,caisse-anyama,caisse-bonoua
                //caisse-yopougon,credit1-aboisso,credit1-adzope,credit1-anyama
                //credit1-yopougon,credit2_adzope,credit2-aboisso,credit2-anyama
                //credit2-bonoua,credit2-yopougon
                || vppAdresseMAC == "00:01:6C:D7:9E:38" || vppAdresseMAC == "00:01:6C:D7:9B:7D" || vppAdresseMAC == "00:01:6C:D7:9D:C5" || vppAdresseMAC == "00:01:6C:D7:79:3A"
                || vppAdresseMAC == "00:01:6C:D7:9A:43" || vppAdresseMAC == "00:01:6C:D7:9D:4E" || vppAdresseMAC == "00:01:6C:D7:78:D3" || vppAdresseMAC == "00:01:6C:D7:9D:71"
                || vppAdresseMAC == "00:01:6C:D7:9B:5E" || vppAdresseMAC == "00:01:6C:D7:97:F4" || vppAdresseMAC == "00:01:6C:D7:7F:4E" || vppAdresseMAC == "00:01:6C:D7:9D:OA"
                || vppAdresseMAC == "00:01:6C:D7:9D:B8" || vppAdresseMAC == "00:01:6C:D7:9B:FF"


                //ORDINATEUR PORTABLE OUATTARA
                || vppAdresseMAC == "DC:4A:3E:A7:C9:80"//Carte ethernet:  
                || vppAdresseMAC == "E0:94:67:55:9B:05"//Carte wifi 
                || vppAdresseMAC == "08:00:27:00:BC:13"//Carte virtualbox 


                //ORDINATEUR ISOLE BAMBA
                || vppAdresseMAC == "0A:00:27:00:00:06"//VirtualBox 

                //ORDINATEUR PRESIDENTE
                || vppAdresseMAC == "A0:8C:FD:7B:2F:29"//Carte ethernet


                //ORDINATEUR grand-bassam_caisse
                || vppAdresseMAC == "00:01:6C:D7:96:F9"
                //ORDINATEUR grand-bassam_credit1
                || vppAdresseMAC == "00:01:6C:D7:9D:0A"



                || vppAdresseMAC == "00:01:6C:D7:A8:77" || vppAdresseMAC == "00:01:6C:D7:A8:7F" || vppAdresseMAC == "00:01:6C:D7:97:FA" || vppAdresseMAC == "00:01:6C:D7:9D:84"
                || vppAdresseMAC == "00:01:6C:D7:98:42" || vppAdresseMAC == "00:01:6C:D7:98:DB" || vppAdresseMAC == "00:01:6C:D7:9D:0B" || vppAdresseMAC == "00:01:6C:D7:9B:58"
                || vppAdresseMAC == "00:01:6C:D7:9D:B7" || vppAdresseMAC == "00:01:6C:D7:97:29" || vppAdresseMAC == "00:01:6C:D7:98:8F" || vppAdresseMAC == "00:01:6C:D7:9D:D4"
                || vppAdresseMAC == "00:01:6C:D7:7F:05" || vppAdresseMAC == "00:01:6C:D7:99:08"

                || vppAdresseMAC == "00:01:6C:D7:9C:B1" || vppAdresseMAC == "00:01:6C:D7:9D:34" || vppAdresseMAC == "00:01:6C:D7:54:19" || vppAdresseMAC == "00:01:6C:D7:9C:87"
                || vppAdresseMAC == "00:01:6C:D7:98:8C" || vppAdresseMAC == "00:01:6C:D7:97:27" || vppAdresseMAC == "00:01:6C:D7:9D:6B" || vppAdresseMAC == "00:01:6C:D7:99:82"
                || vppAdresseMAC == "00:01:6C:D7:9C:F6" || vppAdresseMAC == "00:01:6C:D7:9E:15"

                //HOLDING-COMPTA_ROKIA: 
                || vppAdresseMAC == "00:01:6C:D7:9A:A8"

                //HOLDING-COMPTA_COUL:  
                || vppAdresseMAC == "00:01:6C:D7:97:FB"

                //LES @MAC DE NOUVELLES MACHINES 1
                || vppAdresseMAC == "00:01:6C:D7:9C:F1" || vppAdresseMAC == "00:01:6C:D7:97:50" || vppAdresseMAC == "00:01:6C:D7:9C:C9" || vppAdresseMAC == "00:01:6C:D7:A8:38"
                || vppAdresseMAC == "00:01:6C:D7:9D:2A" || vppAdresseMAC == "00:01:6C:D7:7F:56" || vppAdresseMAC == "00:01:6C:D7:99:23" || vppAdresseMAC == "00:01:6C:D7:9C:50"
                || vppAdresseMAC == "00:01:6C:D7:9D:15" || vppAdresseMAC == "00:01:6C:D7:9A:A7" || vppAdresseMAC == "00:01:6C:D7:98:FA" || vppAdresseMAC == "00:01:6C:D7:97:97"
                || vppAdresseMAC == "00:01:6C:D7:98:96" || vppAdresseMAC == "00:01:6C:D7:97:A4" || vppAdresseMAC == "00:01:6C:D7:9D:5C" || vppAdresseMAC == "00:01:6C:D7:98:69"
                || vppAdresseMAC == "00:19:99:61:50:A9" || vppAdresseMAC == "08:00:27:00:5C:B4"

                //LES @MAC DE NOUVELLES MACHINES 2
                || vppAdresseMAC == "12:34:56:78:91:02" || vppAdresseMAC == "00:01:6C:D7:98:50" || vppAdresseMAC == "00:01:6C:D7:7F:26" || vppAdresseMAC == "00:01:6C:D7:9C:B8"
                || vppAdresseMAC == "00:01:6C:D7:9A:D4" || vppAdresseMAC == "00:01:6C:D7:98:D0" || vppAdresseMAC == "00:01:6C:D7:98:3D" || vppAdresseMAC == "00:01:6C:D7:97:FE"
                || vppAdresseMAC == "00:01:6C:D7:77:B8" || vppAdresseMAC == "00:01:6C:D7:97:06" || vppAdresseMAC == "00:01:6C:D6:D3:FC" || vppAdresseMAC == "00:01:6C:D7:96:D2"
                || vppAdresseMAC == "00:01:6C:D7:98:D6" || vppAdresseMAC == "00:01:6C:D7:98:67" || vppAdresseMAC == "00:01:6C:D7:9D:10" || vppAdresseMAC == "00:01:6C:D7:97:ED"
                || vppAdresseMAC == "00:01:6C:D7:97:91"




                //ADRESSE MAC
                || vppAdresseMAC == "4C:72:B9:CB:88 " || vppAdresseMAC == "C8:D3:FF:D2:AD:CA"


                //NOUVEAUX POSTES DE CELPAID 03-08-2017
                || vppAdresseMAC == "F4:4D:30:13:E3:EB" || vppAdresseMAC == "F4:4D:30:13:DE:8E" || vppAdresseMAC == "F4:4D:30:13:4B:3A" || vppAdresseMAC == "F4:4D:30:13:45:C2"
                || vppAdresseMAC == "F4:4D:30:13:DE:91" || vppAdresseMAC == "F4:4D:30:13:49:71" || vppAdresseMAC == "F4:4D:30:13:49:74" || vppAdresseMAC == "F4:4D:30:13:4A:7F"
                || vppAdresseMAC == "F4:4D:30:13:52:CF" || vppAdresseMAC == "F4:4D:30:13:4C:B7" || vppAdresseMAC == "F4:4D:30:13:4B:0E" || vppAdresseMAC == "F4:4D:30:13:4A:7E"
                || vppAdresseMAC == "F4:4D:30:13:E3:E6" || vppAdresseMAC == "F4:4D:30:13:47:A6" || vppAdresseMAC == "F4:4D:30:13:DE:70" || vppAdresseMAC == "F4:4D:30:13:4E:29"
                || vppAdresseMAC == "F4:4D:30:13:49:B3" || vppAdresseMAC == "F4:4D:30:13:48:52" || vppAdresseMAC == "F4:4D:30:13:49:B8" || vppAdresseMAC == "F4:4D:30:13:4A:7C"

                || vppAdresseMAC == "F4:4D:30:13:4B:35" || vppAdresseMAC == "F4:4D:30:13:E5:1F" || vppAdresseMAC == "F4:4D:30:13:E3:D9" || vppAdresseMAC == "F4:4D:30:10:7F:15"
                || vppAdresseMAC == "F4:4D:30:11:A9:83" || vppAdresseMAC == "F4:4D:30:13:E0:43" || vppAdresseMAC == "F4:4D:30:13:53:E2" || vppAdresseMAC == "F4:4D:30:13:4E:51"
                || vppAdresseMAC == "F4:4D:30:11:5C:18" || vppAdresseMAC == "F4:4D:30:13:49:52" || vppAdresseMAC == "F4:4D:30:13:48:3A" || vppAdresseMAC == "F4:4D:30:13:49:34"
                || vppAdresseMAC == "F4:4D:30:13:49:35" || vppAdresseMAC == "F4:4D:30:13:4A:17" || vppAdresseMAC == "F4:4D:30:13:4A:83" || vppAdresseMAC == "F4:4D:30:13:4B:14"
                || vppAdresseMAC == "F4:4D:30:13:49:2D" || vppAdresseMAC == "F4:4D:30:13:E3:E1" || vppAdresseMAC == "F4:4D:30:13:49:5C" || vppAdresseMAC == "F4:4D:30:13:4A:06"

                || vppAdresseMAC == "F4:4D:30:13:4A:E0" || vppAdresseMAC == "F4:4D:30:13:4E:1D" || vppAdresseMAC == "F4:4D:30:13:49:AC" || vppAdresseMAC == "F4:4D:30:13:47:89"
                || vppAdresseMAC == "F4:4D:30:13:DD:BC" || vppAdresseMAC == "F4:4D:30:13:4C:CF" || vppAdresseMAC == "F4:4D:30:13:4E:15" || vppAdresseMAC == "F4:4D:30:13:4D:FF"
                || vppAdresseMAC == "F4:4D:30:13:4E:0B" || vppAdresseMAC == "4C:72:B9:58:CB:88"


                //NOUVEAUX POSTES DE CELPAID UNIVERSITE
                || vppAdresseMAC == "E8:40:F2:81:F4:CF" || vppAdresseMAC == "DC:4A:3E:75:4B:13" || vppAdresseMAC == "00:01:6C:D7:9C:EA" || vppAdresseMAC == "F4:4D:30:13:49:21"
                || vppAdresseMAC == "4C:72:B9:72:B6:CB" || vppAdresseMAC == "DC:4A:3E:86:FA:2C" || vppAdresseMAC == "38:60:77:9B:67:74" || vppAdresseMAC == "F4:4D:30:13:4B:1E"
                || vppAdresseMAC == "F4:4D:30:13:4E:00" || vppAdresseMAC == "F4:4D:30:13:49:C0" || vppAdresseMAC == "F4:4D:30:13:4E:20" || vppAdresseMAC == "78:96:32:14:57:89"
                || vppAdresseMAC == "4C:72:B9:73:02:E3"

                //NOUVEAUX POSTES DE CELPAID 31-12-2017 / 10 POSTES
                || vppAdresseMAC == "00:24:E8:92:EA:45" || vppAdresseMAC == "00:24:E8:F5:D3:56" || vppAdresseMAC == "00:21:70:BA:62:77" || vppAdresseMAC == "00:26:B9:BA:D9:75"
                || vppAdresseMAC == "00:1D:60:F4:27:9C" || vppAdresseMAC == "00:24:E8:9B:9B:38" || vppAdresseMAC == "00:24:E8:9B:95:FA" || vppAdresseMAC == "00:A0:D1:49:6F:A6"
                || vppAdresseMAC == "00:18:8B:C4:29:87" || vppAdresseMAC == "00:16:D4:8E:6B:F7"

                //DEUX NOUVEAUX POSTES
                || vppAdresseMAC == "00:26:B9:B4:7A:A7" || vppAdresseMAC == "00:1B:38:0F:50:73"


                //24-06-2018.NOUVEAU SERVEUR 
                || vppAdresseMAC == "98:F2:B3:EB:69:73" //Embedded LOM 1  HPE Ethernet 1G  
                || vppAdresseMAC == "98:F2:B3:EB:69:70" //Embedded LOM 1  HPE Ethernet 1G 
                || vppAdresseMAC == "98:F2:B3:EB:69:71" //Embedded LOM 1  HPE Ethernet 1G 
                || vppAdresseMAC == "98:F2:B3:EB:69:72" //Embedded LOM 1  HPE Ethernet 1G  





                //SERVEUR CELPAID DE TEST////17-09-2018 SERVEUR POUR LES TEST INSTALLER A HOME TECHNOLOGY
                || vppAdresseMAC == "84:8F:69:E3:C6:16" || vppAdresseMAC == "84:8F:69:E3:C6:14"
                || vppAdresseMAC == "0A:00:27:00:00:1F"
                || vppAdresseMAC == "84:8F:69:E3:C6:10" //Embedded LOM 1  HPE Ethernet 1G  
                || vppAdresseMAC == "84:8F:69:E3:C6:12" //Embedded LOM 1  HPE Ethernet 1G  
                || vppAdresseMAC == "0A:00:27:00:00:14"//Virtualbox


                //28-06-2019
                || vppAdresseMAC == "2C:44:FD:69:E5:FD" //PCA
                || vppAdresseMAC == "40:A8:F0:48:71:C1"//JEROME
                || vppAdresseMAC == "C4:E9:84:00:05:AC" //DIVO 


                //20-12-2019
                || vppAdresseMAC == "44:1C:A8:AB:4E:88" //POSTE 1
                || vppAdresseMAC == "60:14:B3:83:FE:20"//POSTE 2
                || vppAdresseMAC == "98:29:A6:11:53:C2" //POSTE 3
                || vppAdresseMAC == "60:14:B3:83:FC:EC" //POSTE 4
                || vppAdresseMAC == "C8:3D:D4:9A:59:98"//POSTE 5
                || vppAdresseMAC == "C4:65:16:20:69:34" //POSTE 6 
                || vppAdresseMAC == "C4:65:16:20:69:8F" //POSTE 7
                || vppAdresseMAC == "C4:65:16:20:69:8B"//POSTE 8


                //10-02-2020
                || vppAdresseMAC == "EC:8E:B5:0F:B6:70" //POSTE 1
                || vppAdresseMAC == "FC:45:96:8D:F2:D3"//POSTE 2
                || vppAdresseMAC == "98:29:A6:11:55:C9" //POSTE 3
                || vppAdresseMAC == "98:29:A6:11:57:E3" //POSTE 4
                || vppAdresseMAC == "C4:65:16:1F:9F:82"//POSTE 5
                || vppAdresseMAC == "C4:65:16:11:2C:D1" //POSTE 6 
                || vppAdresseMAC == "C4:65:16:11:2B:91" //POSTE 7
                || vppAdresseMAC == "F8:75:A4:5D:EC:DD"//POSTE 8


                //14-07-2020 hyper v
                || vppAdresseMAC == "00:15:5D:01:C7:09" //Hyperv01 
                || vppAdresseMAC == "00:15:5D:01:C7:0A"//Hyperv02 
                || vppAdresseMAC == "00:15:5D:01:C7:0F" //Hyperv03 
                || vppAdresseMAC == "00:15:5D:01:C7:0B" //Hyperv04 
                || vppAdresseMAC == "00:15:5D:01:C7:0C"//Hyperv05 
                || vppAdresseMAC == "00:15:5D:01:C7:0D" //Hyperv06  
                || vppAdresseMAC == "00:15:5D:01:C7:0E" //Hyperv07 
                || vppAdresseMAC == "00:15:5D:01:C7:10"//Hyperv08 

                //20-05-2021
                || vppAdresseMAC == "24:BE:05:13:84:75" //ETHERNET 1  PCA
                || vppAdresseMAC == "5C:5F:67:1E:65:9A"//WIFI     1  PCA
                || vppAdresseMAC == "B4:B6:86:E8:8E:4D" //ETHERNET 2 
                || vppAdresseMAC == "E4:AA:EA:AE:BA:35" //WIFI     2   



                //13-12-2021
                || vppAdresseMAC == "50:65:F3:30:BB:29"
                || vppAdresseMAC == "EC:8E:B5:59:55:D0"
                || vppAdresseMAC == "00:01:6C:D7:99:F7"
                || vppAdresseMAC == "F8:75:A4:5D:F1:39"
                || vppAdresseMAC == "10:63:C8:EE:45:2F"
                || vppAdresseMAC == "58:20:B1:79:3F:02"
                || vppAdresseMAC == "AC:FD:CE:AA:AA:FF"
                || vppAdresseMAC == "38:63:BB:89:C9:F4"
                || vppAdresseMAC == "AC:FD:CE:AA:92:8B"
                || vppAdresseMAC == "58:20:B1:79:42:51"
                || vppAdresseMAC == "F8:16:54:42:F9:82"
                || vppAdresseMAC == "3C:A8:2A:E0:DC:F0"
                || vppAdresseMAC == "34:E6:AD:08:5D:A9"
                || vppAdresseMAC == "B0:22:7A:8D:8C:97"


                //18-03-2022
                || vppAdresseMAC == "1C:98:EC:12:52:D8"
                || vppAdresseMAC == "1C:98:EC:12:52:D9"
                || vppAdresseMAC == "1C:98:EC:12:52:DA"
                || vppAdresseMAC == "1C:98:EC:12:52:DB"

                //04-02-2023
                || vppAdresseMAC == "AC:E2:D3:9D:A5:DB"
                || vppAdresseMAC == "F8:94:C2:16:B3:6E"
                || vppAdresseMAC == "98:E7:F4:68:CF:3B"
                || vppAdresseMAC == "F0:D5:BF:0E:1B:CD"

                || vppAdresseMAC == "AC:E2:D3:9D:D4:68"
                || vppAdresseMAC == "E4:42:A6:EA:F5:98"
                || vppAdresseMAC == "F4:39:09:7A:BA:0F"
                || vppAdresseMAC == "14:4F:8A:84:71:C4"
                )
            {
                return true;
            }

            //25-PC CANARI
            else if (
                vppAdresseMAC == "50:AF:73:6C:9B:EC" || vppAdresseMAC == "50:AF:73:6C:9D:89"
                || vppAdresseMAC == "50:AF:73:6C:9D:9E"


                //SERVEUR
                || vppAdresseMAC == "50:65:F3:7A:E0:68" || vppAdresseMAC == "50:65:F3:7A:E0:69"

                //COMPTABILITE
                || vppAdresseMAC == "00:21:85:57:E0:5F"


                //CREDIT
                || vppAdresseMAC == "00:1D:92:7C:8E:C9"


                //TCHAN BI
                || vppAdresseMAC == "00:21:85:57:E0:5F"

                //26-08-2018
                || vppAdresseMAC == "00:13:3B:10:11:64"



                //14-09-2018-PLATEAU
                || vppAdresseMAC == "78:AC:C0:B0:1C:82"//POSTE 1
                || vppAdresseMAC == "0C:54:A5:01:7B:A3"//CAISSE ETHERNET: 
                || vppAdresseMAC == "00:E6:2D:04:27:D0"//CAISSE WIFI: 
                || vppAdresseMAC == "10:E7:C6:79:A4:BF"//POSTE 2 ETHERNET 
                || vppAdresseMAC == "9C:30:5B:E1:95:6D"//POSTE 2 WIFI 


                //16-11-2018-YOPOUGON
                || vppAdresseMAC == "10:62:E5:09:E1:34"//POSTE 2
                || vppAdresseMAC == "10:62:E5:09:E9:DC"//AG CREDIT

                )
            {

                return true;
            }
            //25-PC CPZ BONDOUKOU
            else if (
                vppAdresseMAC == "00:22:64:26:47:53" || vppAdresseMAC == "A0:D3:C1:21:26:75" || vppAdresseMAC == "A0:D3:C1:28:4A:8F" || vppAdresseMAC == "00:1D:92:0E:DE:E6"
                || vppAdresseMAC == "00:19:DB:BF:E7:02" || vppAdresseMAC == "00:23:5A:0E:36:B5" || vppAdresseMAC == "00:22:5F:AB:1F:60" || vppAdresseMAC == "08:2E:5F:74:B5:9A"
                || vppAdresseMAC == "68:5D:43:40:05:47" || vppAdresseMAC == "6C:C2:17:85:6E:6C" || vppAdresseMAC == "6C:C2:17:85:6E:6D"
                )
            {
                return true;
            }

            //26-PC SERVICE COMMERCIAL
            else if (
                vppAdresseMAC == "08:00:27:00:40:DE" || vppAdresseMAC == "88:AE:1D:AC:78:13" || vppAdresseMAC == "00:27:10:0D:DB:D0" || vppAdresseMAC == "68:B5:99:FA:31:15"
                || vppAdresseMAC == "58:94:6B:B1:0E:EC" || vppAdresseMAC == "08:00:27:00:60:0E"

                //ACHAT DU 20-01-2018 HP-NOUVEL ORDINATEUR
                || vppAdresseMAC == "10:1F:74:E4:71:D6" || vppAdresseMAC == "A0:88:B4:C4:B9:34" || vppAdresseMAC == "0A:00:27:00:00:0A"
                )
            {
                return true;
            }

            //27-PC CMECEL
            else if (
                vppAdresseMAC == "00:FF:8A:82:18:68" || vppAdresseMAC == "D4:AE:52:BF:29:A9" || vppAdresseMAC == "78:45:C4:1F:79:C6" || vppAdresseMAC == "18:A9:05:89:43:31"
                || vppAdresseMAC == "00:1E:65:E3:F3:A4")
            {
                return true;
            }


            //1-ORDINATEUR POUR LES DEMO
            if (vppAdresseMAC == "C8:0A:A9:CD:82:C3" //carte ethernet : 
            || vppAdresseMAC == "F0:7B:CB:A4:6A:E8")//carte wifi     
            {
                return true;
            }

            //1-ORDINATEUR DIGBEU, virtualbox
            if (vppAdresseMAC == "00:0C:29:EA:00:1E")
            {
                return true;
            }




            //I- MAC ADEC SIEGE
            if (
            vppAdresseMAC == "A0:48:1C:A3:BF:93" //Comptabilté 
            || vppAdresseMAC == "78:45:C4:1F:78:88" //Credit
            || vppAdresseMAC == "74:46:A0:9A:4C:E6"//Affaire Juridique  
            || vppAdresseMAC == "D0:27:88:91:A4:EC" //Directrice Réseau
            || vppAdresseMAC == "D0:27:88:91:A4:A1"//Accueil
            || vppAdresseMAC == "D0:27:88:91:A4:87" //Comptabilité 2
            || vppAdresseMAC == "1C:98:EC:1E:63:4E"//Serveur 
            || vppAdresseMAC == "1C:98:EC:1E:63:4C" //Serveur 
            || vppAdresseMAC == "1C:98:EC:1E:63:4D" //Serveur
            || vppAdresseMAC == "1C:98:EC:1E:63:4F"//Serveur

            //II-MAC ADEC MARCORY
            || vppAdresseMAC == "D0:27:88:91:D2:4C" //CAISSE 1 
            || vppAdresseMAC == "4C:72:B9:1D:B3:84" //CAISSE 1
            || vppAdresseMAC == "4C:72:B9:4A:BF:35"//Chef agence2

            //MAC ADEC AUTRES
            || vppAdresseMAC == "D0:27:88:91:A3:F6" //POSTE 1  
            || vppAdresseMAC == "00:21:5A:71:51:16" //POSTE 2 
            || vppAdresseMAC == "AC:16:2D:0A:23:A6"//POSTE 3 
            || vppAdresseMAC == "3C:D9:2B:6E:44:3C" //POSTE 4  
            || vppAdresseMAC == "34:64:A9:24:8B:79" //POSTE 5
            || vppAdresseMAC == "D0:27:88:91:A3:B3"//POSTE 6
            || vppAdresseMAC == "D0:27:88:91:A3:F8" //POSTE 7 
            || vppAdresseMAC == "E8:40:F2:96:B4:12"//POSTE 8  
            || vppAdresseMAC == "AC:16:2D:0F:BC:6E" //POSTE 9
            || vppAdresseMAC == "38:63:BB:83:24:1E" //PORTABLE ETHERNET
            || vppAdresseMAC == "C0:38:96:8B:FF:1B"//PORTABLE WIFI



            || vppAdresseMAC == "E8:40:F2:97:10:99"
            || vppAdresseMAC == "34:64:A9:2A:E5:CD"
            || vppAdresseMAC == "A0:48:1C:A3:B8:9F"
            || vppAdresseMAC == "30:8D:99:22:38:1B"
            || vppAdresseMAC == "34:64:A9:2A:E6:25"//ADRESSE MAC PCA

            //ADEC ADJAME
            || vppAdresseMAC == "34:64:A9:2A:E6:A9"
            || vppAdresseMAC == "10:60:4B:6F:09:49"
            || vppAdresseMAC == "D0:27:88:91:A2:46"

                )
            {

                return true;
            }

            //1-poste de la secretaire
            if (vppAdresseMAC == "BC:85:56:1E:63:F3" || vppAdresseMAC == "74:86:7A:1B:0D:5C")
            {
                return true;
            }

            //1-ORDINATEUR bureau I3,service technique
            if (
             vppAdresseMAC == "3C:52:82:75:90:F9" //Ethernet: 
            || vppAdresseMAC == "1C:BF:CE-88:17:39" //WIFI
            || vppAdresseMAC == "0A:00:27:00:00:11" //Virtual box BLY



            //21-10-2021 NOUVELLE MACHINES EN I 7
            || vppAdresseMAC == "6C:C2:17:7E:B6:A4" //ETHERNET
            || vppAdresseMAC == "C4:D9:87:E6:D1:AB" //WIFI
            || vppAdresseMAC == "0A:00:27:00:00:2D" //VIRTUALBOX TABI
            || vppAdresseMAC == "8C:DC:D4:D4:74:6A" //ETHERNET
            || vppAdresseMAC == "8C:BF:8A:5D:51:5C" //CELLULAIRE

            //06/07/2022
            || vppAdresseMAC == "F8:16:54:D6:B7:D5"
            || vppAdresseMAC == "0A:00:27:00:00:07"



            )
            {
                return true;
            }

            //ECO FINANCE
            if (vppAdresseMAC == "00:9C:02:9A:1D:A4" //SERVEUR Carte Ethernet 1
            || vppAdresseMAC == "00:9C:02:9A:1D:A5" //SERVEUR Carte Ethernet 2
            || vppAdresseMAC == "00:22:64:27:1F:4A" //POSTE 2

            || vppAdresseMAC == "58:20:B1:7A:FB:9F" //ORDINATEUR PORTABLE ETHERNET
            || vppAdresseMAC == "D8:5D:E2:AA:0C:89" //ORDINATEUR PORTABLE WIFI

            || vppAdresseMAC == "0A:00:27:00:00:0F" //VIRTUAL BOX

            || vppAdresseMAC == "40:61:86:59:70:86" //NOUVEAU POSTE
            )
            {
                return true;
            }

            //CEPECI
            if (vppAdresseMAC == "00:16:17:5A:A9:8D" //POSTE 1
            || vppAdresseMAC == "70:71:BC:55:00:C7" //POSTE 2
            || vppAdresseMAC == "00:0F:FE:FB:A1:B1" //POSTE 3

            || vppAdresseMAC == "00:0F:FE:C9:84:C2" //serveur
            || vppAdresseMAC == "00:1A:A0:D1:E1:5F" //POSTE 5

            //PCA CEPECI 22/03/2018
            || vppAdresseMAC == "2C:D0:5A:5A:3B:DF" //WIFI
            || vppAdresseMAC == "60:A4:4C:7D:16:FE" //ETHERNET

            //PCA CEPECI 10/11/2018
            || vppAdresseMAC == "44:37:E6:C3:63:C9" //AGENT CREDIT
            || vppAdresseMAC == "FC:4D:D4:37:03:9E" //CAISSIERE

            //PCA CEPECI 23/08/2019
            || vppAdresseMAC == "18:03:73:B0:05:62"
            || vppAdresseMAC == "78:32:1B:F6:EC:6D"
            )
            {
                return true;
            }
            //ORDINATEUR PORTABLE GBOBIA
            if (vppAdresseMAC == "0A:00:27:00:00:09" //virtualbox 
            || vppAdresseMAC == "30:E1:71:17:C4:6A" //ethernet   
            || vppAdresseMAC == "98:54:1B:11:13:59" //WIFI  
            )
            {
                return true;
            }
            //MAC CADES YAKASSE ATTOUBRO
            if (vppAdresseMAC == "00:21:9B:39:9A:25" //Directrice
            || vppAdresseMAC == "00:30:6E:4C:F4:A2" //Caisse,ethernet   
            || vppAdresseMAC == "00:0F:FE:53:18:26" //Agent Credit,ethernet  
            || vppAdresseMAC == "C8:D3:FF:B8:A2:B0" //(Serveur) 
            //Caisse 01/02/2018
            || vppAdresseMAC == "C8:D3:FF:B2:7F:70"

            //17/05/2018
            || vppAdresseMAC == "18:60:24:7D:6C:80"

            //05/12/2020
            || vppAdresseMAC == "DC:4A:3E:7E:C0:DB"


            //25/08/2020
            || vppAdresseMAC == "00:0F:FE:C0:E9:16"
            || vppAdresseMAC == "00:E0:4C:68:12:9D"

            //12/12/2022
            || vppAdresseMAC == "6C:62:6D:0D:13:0D"


            )
            {
                return true;
            }

            //ORDINATEUR COMPTABILITE HOME TECHNOLOGY
            if (vppAdresseMAC == "6C:62:6D:A5:D0:53" // ethernet
            )
            {
                return true;
            }

            //ORDINATEUR AGIR FINANCE
            if (vppAdresseMAC == "70:5A:0F:48:7F:9C" // SERVEUR ETHERNET
            || vppAdresseMAC == "E8:39:35:41:57:0E" //POSTE 1    ETHERNET
            || vppAdresseMAC == "F8:28:19:46:D2:AF" // DASSE FLORENT ETHERNET
            || vppAdresseMAC == "F4:30:B9:85:49:54" //DASSE FLORENT WIFI 
            || vppAdresseMAC == "48:E2:44:D7:19:9F" // MR GOUEU BI ETHERNET
            || vppAdresseMAC == "70:5A:0F:64:9E:56" //MR GOUEU BI WIFI  
            || vppAdresseMAC == "F0:7B:CB:20:57:76" // MR DIOMANDE EMILE ETHERNET
            || vppAdresseMAC == "C8:0A:A9:22:B8:BD" //MR DIOMANDE EMILE WIFI  
            || vppAdresseMAC == "F4:30:B9:98:20:E4" // DG ETHERNET
            || vppAdresseMAC == "E4:42:A6:AA:66:21" //DG WIFI  
            || vppAdresseMAC == "DC:85:DE:E5:00:39" //MME TANO EMA PAULE WIFI  
            || vppAdresseMAC == "48:BA:4E:46:87:FB" // RACHMAN NYAMKE ETHERNET
            || vppAdresseMAC == "F4:96:34:F0:3F:E8" //RACHMAN NYAMKE WIFI 
            || vppAdresseMAC == "30:E1:71:18:E8:57" // SERGE ALLICO ETHERNET
            || vppAdresseMAC == "9A:59:3A:50:94:D7" //SERGE ALLICO WIFI 


            //10-05-2019
            || vppAdresseMAC == "F4:39:09:3D:3B:B4" //MABO
            || vppAdresseMAC == "F4:39:09:3A:BA:1D" //M'BAHIA  
            || vppAdresseMAC == "F4:39:09:3D:3B:E9" //TANO
            || vppAdresseMAC == "F4:39:09:3B:22:C3" //GOUELIBI             
            || vppAdresseMAC == "F4:39:09:3D:3B:B2" //RASHMANE 
            || vppAdresseMAC == "F4:39:09:08:E2:D6" //DG
            || vppAdresseMAC == "54:80:28:55:11:5B" //SERVEUR ETHERNET 1
            || vppAdresseMAC == "54:80:28:55:11:5A" //SERVEUR ETHERNET 2
            || vppAdresseMAC == "54:80:28:55:11:5D" //SERVEUR ETHERNET 3
            || vppAdresseMAC == "54:80:28:55:11:5C" //SERVEUR ETHERNET 4

            //14-05-2019
            || vppAdresseMAC == "F4:39:09:3A:BA:7D" //ACCUEIL 2
            || vppAdresseMAC == "F4:39:09:3B:25:0B" //POSTE 7
            || vppAdresseMAC == "F4:39:09:3A:BA:4B" //CAISSE 1
            || vppAdresseMAC == "F4:39:09:3D:3C:85" //POSTE 6                        
            || vppAdresseMAC == "F4:39:09:3B:22:03" //POSTE 5 
            || vppAdresseMAC == "E4:E7:49:48:48:A9" //PORTABLE ETHERNET
            || vppAdresseMAC == "A0:A4:C5:53:24:65" //PORTABLE WIFI
            || vppAdresseMAC == "F4:39:09:3B:21:F7" //POSTE 4
            || vppAdresseMAC == "F4:39:09:3B:23:BD" //POSTE 3
            || vppAdresseMAC == "F4:39:09:3B:22:C5" //POSTE 2
            || vppAdresseMAC == "F4:39:09:3D:3C:5A" //POSTE 1
            || vppAdresseMAC == "F4:39:09:3B:23:52" //SALAHOU


            //16-05-2019
            || vppAdresseMAC == "E4:E7:49:47:F6:C3" //PORTABLE 1 ETHERNET
            || vppAdresseMAC == "A0:A4:C5:55:EC:F4" //PORTABLE 1 WIFI
            || vppAdresseMAC == "E4:E7:49:48:4B:30" //PORTABLE 2 ETHERNET
            || vppAdresseMAC == "A0:A4:C5:52:78:F8" //PORTABLE 2 WIFI                   
            || vppAdresseMAC == "E4:E7:49:48:4A:66" //PORTABLE 3 ETHERNET
            || vppAdresseMAC == "A0:A4:C5:57:76:9B" //PORTABLE 3 WIFI
            || vppAdresseMAC == "E4:E7:49:48:47:6E" //PORTABLE 4 ETHERNET
            || vppAdresseMAC == "A0:A4:C5:56:8E:B6" //PORTABLE 4 WIFI
            || vppAdresseMAC == "E4:E7:49:48:4A:3E" //PORTABLE 5 ETHERNET
            || vppAdresseMAC == "A0:A4:C5:57:77:9F" //PORTABLE 5 WIFI
            || vppAdresseMAC == "F4:39:09:3B:22:1F" //BURO
            || vppAdresseMAC == "40:B0:34:96:5E:CD" //DASSE
            || vppAdresseMAC == "58:00:E3:7E:F1:E3" //DASSE

            //02-07-2020 AGENCE VRIDI
            || vppAdresseMAC == "9C:7B:EF:32:1E:30" //POSTE 1
            || vppAdresseMAC == "9C:7B:EF:32:1C:B8" //POSTE 2
            || vppAdresseMAC == "84:A9:3E:92:85:20" //POSTE 3


            //21-05-2021 PCA AGIR FINANCE
            || vppAdresseMAC == "BC:E9:2F:7D:B7:23" //ETHERNET
            || vppAdresseMAC == "A8:7E:EA:21:ED:3C" //WIFI



            )
            {
                return true;
            }

            //ORDINATEUR SUCCESSEED
            if (vppAdresseMAC == "00:09:0B:08:01:18" // SERVEUR ETHERNET
            || vppAdresseMAC == "70:F3:95:05:F4:65" //SERVEUR    ETHERNET
            || vppAdresseMAC == "00:1D:92:D8:FB:01" //POSTE 4 ETHERNET
            || vppAdresseMAC == "44:37:E6:AC:E9:9E" //CAISSE1 ETHERNET 
            || vppAdresseMAC == "44:37:E6:73:1B:2C" //CAISSE 2 ETHERNET
            || vppAdresseMAC == "00:24:1D:AB:67:52" //ACCUEIL  ETHERNET
            || vppAdresseMAC == "44:37:E6:CC:19:F9" //RESPONSABLE ADMINISTRATIF ETHERNET
            || vppAdresseMAC == "00:24:21:0F:7D:64" //COMPTABLE ETHERNET

            //07-12-2018
            || vppAdresseMAC == "00:1D:92:21:A9:BF" //EHTERNET AG DE CREDIT
            || vppAdresseMAC == "00:19:DB:AB:AD:B7" //ETHERNET DE PCA
            || vppAdresseMAC == "AE:82:5A:46:98:30" //WIFI PCA
            //24-04-2019 PC DE TEST
            || vppAdresseMAC == "5C:E0:C5:79:87:F4" //WIFI PCA
            || vppAdresseMAC == "0A:00:27:00:00:0A" //VIRTUAL BOX


            )
            {
                return true;
            }


            //FOSAT- 27-08-2018
            if (vppAdresseMAC == "F4:30:B9:AD:5E:C6" // GERANTE,mme yapi,ordinateur portable ETHERNET
            || vppAdresseMAC == "A0:88:69:D5:F5:0C" // GERANTE,mme yapi,ordinateur portable  WIFI
            || vppAdresseMAC == "0A:00:27:00:00:1D" // mme yapi,ordinateur portable  VIRTUAL BOX 

            || vppAdresseMAC == "8C:16:45:EF:C0:E1" // COMPTABLE  ETHERNET
            || vppAdresseMAC == "00:F4:8D:A6:21:BF" //COMPTABLE  WIFI

            || vppAdresseMAC == "10:E7:C6:2F:E8:E0" //SERVEUR TEMPORAIRE

            //01-07-2021
            || vppAdresseMAC == "94:40:C9:46:CE:EC" // Ethernet 1
            || vppAdresseMAC == "94:40:C9:46:CE:ED" //Ethernet 2
            || vppAdresseMAC == "94:40:C9:46:CE:EE" // Ethernet 3
            || vppAdresseMAC == "94:40:C9:46:CE:EF" //Ethernet 4

            //06-09-2021
            || vppAdresseMAC == "A4:1F:72:50:10:C0" // NDA Ethernet 
            || vppAdresseMAC == "00:E9:3A:10:32:B7" // NDA wifi 
            || vppAdresseMAC == "08:00:27:00:FC:FB" // NDA virtualbox 

            //14-04-2022
            || vppAdresseMAC == "10:6F:D9:C5:68:2D" // NDA wifi  
            || vppAdresseMAC == "00:FF:CF:EB:82:84" // NDA Ethernet  

            //25-11-2022
            || vppAdresseMAC == "6C:02:E0:63:43:12"
            || vppAdresseMAC == "6C:02:E0:63:41:77"
            || vppAdresseMAC == "D4:BE:D9:D5:B5:41"

            //13-03-2023   
            || vppAdresseMAC == "50:81:40:2A:EA:2D"
            || vppAdresseMAC == "50:81:40:2A:EB:6D"
            || vppAdresseMAC == "50:81:40:2A:EF:B0"
            || vppAdresseMAC == "50:81:40:2A:EB:64"


            //30-03-2023
            || vppAdresseMAC == "50:65:F3:27:7F:66"
            || vppAdresseMAC == "70:66:55:E4:12:37"



            )
            {
                return true;
            }


            //24-10-2018-ORDINATEUR PORTABLE HP PROBOOK DIARRASSOUBA
            if (vppAdresseMAC == "7C:B0:C2:6A:D9:E8" // WIFI
            || vppAdresseMAC == "40:B0:34:48:9D:C2" //ETHERNET    
            || vppAdresseMAC == "0A:00:27:00:00:09" //VIRTUAL BOX  
            )
            {
                return true;
            }

            //30-10-2018-ORDINATEUR PORTABLE HP PROBOOK DIARRASSOUBA
            if (vppAdresseMAC == "6C:4B:90:3A:8B:BB" // POSTE 1
            || vppAdresseMAC == "6C:4B:90:3A:8B:EC" //POSTE 2    
            || vppAdresseMAC == "6C:4B:90:3A:8B:F1" //POSTE 3 
            || vppAdresseMAC == "8C:DC:D4:4F:ED:F7" //SERVEUR
            )
            {
                return true;
            }

            //22-05-2019 MAC FCR TOUIH
            if (vppAdresseMAC == "E4:6F:13:A9:65:DE" //ANCIEN SERVEUR
            || vppAdresseMAC == "40:B0:34:3B:32:84" //CAISSE 2    
            || vppAdresseMAC == "40:B0:34:3B:07:BA" //CAISSE 1
            || vppAdresseMAC == "6C:62:6D:E9:F6:C2" //COMPTABLE
            || vppAdresseMAC == "F4:CE:46:F2:4A:E1" //AGENT CREDIT
            || vppAdresseMAC == "A0:48:1C:82:70:12" //GERANT   

            || vppAdresseMAC == "84:A9:3E:5C:89:58" //GERANT PORTABLE ETHERNET
            || vppAdresseMAC == "D8:9C:67:24:52:61" //GERANT PORTABLE WIFI   
            || vppAdresseMAC == "C8:D9:D2:01:1F:08" //SERVEUR 
            //17-09-2019
            || vppAdresseMAC == "6C:62:6D:E4:64:25" //CONTROLEUR 

            //07/06/2022
            || vppAdresseMAC == "00:E0:4C:68:00:05"

            //23-02-2023
            || vppAdresseMAC == "84:69:93:C6:C2:04"
            || vppAdresseMAC == "D8:80:83:C6:D8:AB"


            //06-03-2023
            || vppAdresseMAC == "3C:A8:2A:88:12:9C"
            || vppAdresseMAC == "AC:FD:CE:01:B9:0E"

            )
            {
                return true;
            }
            //ORDINATEUR MAC SERVICE COMMERCIAL 27-07-2020
            if (vppAdresseMAC == "90:FD:61:ED:9A:A6" //WIFI 			
            || vppAdresseMAC == "0A:00:27:00:00:24" //VIRTUAL BOX
            || vppAdresseMAC == "AC:87:A3:04:C1:98" //ETHERNET
            )
            {
                return true;
            }

            //ORDINATEUR SIRIUS FINANCES 05-01-2021
            if (vppAdresseMAC == "BC:E9:2F:84:BD:6C" //DG ETHERNET 			
            || vppAdresseMAC == "EE:7C:8E:6C:3B:18" //DG WIFI
            || vppAdresseMAC == "B0:0C:D1:F3:48:A0" //POSTE 1 ETHERNET
            || vppAdresseMAC == "DC:F5:05:62:CA:59" //POSTE 1 WIFI

            || vppAdresseMAC == "BC:E9:2F:C0:6E:D9" //POSTE 2 ETHERNET
            || vppAdresseMAC == "70:66:55:E3:1B:2D" //POSTE 2 WIFI

            || vppAdresseMAC == "C8:D9:D2:AF:C3:24" //POSTE 3 ETHERNET
            || vppAdresseMAC == "D0:C5:D3:02:42:FD" //POSTE 3 WIFI


            || vppAdresseMAC == "84:2A:FD:90:3F:4F" //POSTE 4 ETHERNET
            || vppAdresseMAC == "28:CD:C4:52:4D:A3" //POSTE 4 WIFI


            //02-03-2021
            || vppAdresseMAC == "9C:7B:EF:4A:99:4C" //POSTE 1 ETHERNET
            || vppAdresseMAC == "9C:7B:EF:49:C0:CB" //POSTE 2 ETHERNET
            || vppAdresseMAC == "9C:7B:EF:49:C1:41" //POSTE 3 ETHERNET
            || vppAdresseMAC == "94:40:C9:12:A2:B4" //SERVEUR ETHERNET
            || vppAdresseMAC == "94:40:C9:12:A2:B5" //SERVEUR ETHERNET
            || vppAdresseMAC == "9A:E4:35:5F:13:A8" //SERVEUR ETHERNET


            //Nouveau ordinateur le 27/06/2021
            || vppAdresseMAC == "6C:02:E0:CD:6F:52"//POSTE 1 ETHERNET : 
            || vppAdresseMAC == "A4:97:B1:50:8E:BF" //POSTE 1 WIFI : 
            || vppAdresseMAC == "6C:02:E0:CD:6E:E0"//POSTE 2 ETHERNET :  
            || vppAdresseMAC == "A4:97:B1:51:27:99"//POSTE 2 WIFI :  

            //Nouveau ordinateur le 08/09/2021
            || vppAdresseMAC == "5C:BA:EF:DB:FE:C9"//POSTE 1 WIFI  : 
            || vppAdresseMAC == "F8:0D:AC:BA:1D:BF" //POSTE 1 ETHERNET :

            //Nouveau ordinateur le 17/09/2021
            || vppAdresseMAC == "30:24:A9:3E:F0:B1"//POSTE 1  ETHERNET : 
            || vppAdresseMAC == "18:47:3D:6C:7E:93" //POSTE 1 WIFI :

            //Nouveau ordinateur le 07/11/2021
            || vppAdresseMAC == "30:24:A9:3F:00:C7"//POSTE 1  ETHERNET : 
            || vppAdresseMAC == "18:47:3D:7B:FA:BD" //POSTE 1 WIFI :


            //Nouveau ordinateur le 28/07/2022, Serveur de test.
            || vppAdresseMAC == "8C:C6:81:01:1D:8C"
            || vppAdresseMAC == "BC:E9:2F:FC:60:99"
            || vppAdresseMAC == "0A:00:27:00:00:0D"


            //26/08/2022
            || vppAdresseMAC == "A8:B1:3B:80:F1:05"
            || vppAdresseMAC == "7C:21:4A:D4:A8:E1"
            || vppAdresseMAC == "A8:B1:3B:8D:F5:1F"

            || vppAdresseMAC == "7C:21:4A:D7:82:E1"
            || vppAdresseMAC == "A8:B1:3B:80:F1:0F"
            || vppAdresseMAC == "7C:21:4A:D3:73:B8"

            //02/09/2022
            || vppAdresseMAC == "50:81:40:2F:FE:71"


            //14/01/2023
            || vppAdresseMAC == "84:69:93:6B:AD:2D"
            || vppAdresseMAC == "10:A5:1D:54:64:E7"
            || vppAdresseMAC == "84:69:93:6B:AB:5A"
            || vppAdresseMAC == "10:A5:1D:54:65:5F"


            )
            {
                return true;
            }

            //ORDINATEUR MAC SERVICE DEVELLOPPEMENT HP ESTELLE 26-06-2021
            if (vppAdresseMAC == "B4:D5:BD:CE:51:B2" //WIFI 			
            || vppAdresseMAC == "0A:00:27:00:00:11" //VIRTUAL BOX
            || vppAdresseMAC == "80:CE:62:4D:EB:44" //ETHERNET
            )
            {
                return true;
            }

            //ORDINATEUR STAGIERES 19-07-2021
            if (vppAdresseMAC == "C4:65:16:E7:E6:72" //KPEYA ETHERNET		
            || vppAdresseMAC == "10:5B:AD:95:DD:47" //KPEYA WIFI
            || vppAdresseMAC == "58:20:B1:7D:FF:AE" //TA BI ETHERNET
            || vppAdresseMAC == "40:B8:9A:1A:C7:42" //TA BI WIFI
            )
            {
                return true;
            }

            //SIEGE RCMEC 23-08-2021
            if (vppAdresseMAC == "30:24:A9:0D:16:A5" //DG ETHERNET		
            || vppAdresseMAC == "C8:E2:65:F0:1B:3A" //DG WIFI
            || vppAdresseMAC == "B0:5A:DA:3E:1D:96" //BOUATENIN ETHERNET1
            || vppAdresseMAC == "00:E0:4E:68:AB:3A" //BOUATENIN ETHERNET2
            || vppAdresseMAC == "30:24:A9:0D:36:AB" //DOUKOURE ETHERNET
            || vppAdresseMAC == "C8:E2:65:F0:63:E7" //DOUKOURE WIFI
            || vppAdresseMAC == "00:19:99:61:50:C6" //ZABRI ETHERNET
            || vppAdresseMAC == "40:61:86:09:CA:0E" //MME YAO ETHERNET
            || vppAdresseMAC == "00:26:6C:2F:77:68" //APPOLINAIRE ETHERNET
            || vppAdresseMAC == "6C:4B:90:E7:BB:0F" //SECRETARIAT ETHERNET

            //13-09-2021
            || vppAdresseMAC == "00:68:EB:B1:14:05" //POSTE 1 ETHERNET
            || vppAdresseMAC == "00:68:EB:B1:14:5C" //POSTE 2 ETHERNET
            || vppAdresseMAC == "6C:02:E0:90:1D:FC" //POSTE 3 ETHERNET
            || vppAdresseMAC == "E8:84:A5:E0:06:C8" //POSTE 3 ETHERNET

            //24-09-2021
            || vppAdresseMAC == "C0:25:A5:67:B6:A2" //POSTE 4 ETHERNET
            || vppAdresseMAC == "38:87:D5:F8:F7:CD" //POSTE 4 WIFI

            //21-10-2021
            || vppAdresseMAC == "00:68:EB:B2:5E:F6" //ETHERNET
            //20-07-2022
            || vppAdresseMAC == "38:87:D5:F8:F7:CD"
            || vppAdresseMAC == "C0:25:A5:67:B6:A2"

            //03-10-2022, serveur 
            || vppAdresseMAC == "D4:F5:EF:3D:1B:27"

            //23-02-2023
            || vppAdresseMAC == "30:E1:71:7A:BB:32"
            || vppAdresseMAC == "34:F3:9A:7B:16:05"


            )
            {
                return true;
            }

            //FPPN 23-08-2021
            if (vppAdresseMAC == "6C:4B:90:E7:C0:97" //POSTE 1  ETHERNET		
            || vppAdresseMAC == "6C:4B:90:E8:8A:34" //POSTE 2  ETHERNET
            || vppAdresseMAC == "6C:4B:90:E8:89:4D" //POSTE 3  ETHERNET
            || vppAdresseMAC == "6C:4B:90:E8:89:C6" //POSTE 4 ETHERNET
            || vppAdresseMAC == "6C:4B:90:E8:8A:63" //POSTE 5  ETHERNET
            || vppAdresseMAC == "E4:54:E8:D7:48:7A" //SERVEUR ETHERNET
            || vppAdresseMAC == "6C:4B:90:E7:C0:97"
            || vppAdresseMAC == "00:68:EB:B1:15:13"

            //SERVEUR 10-11-2022
            || vppAdresseMAC == "D4:F5:EF:72:EB:AC"

            )
            {
                return true;
            }

            //-PC CMEC BINGERVILLE
            else if (
                vppAdresseMAC == "00:19:DB:DE:14:B8" || vppAdresseMAC == "00:1D:92:67:7F:FA"
                || vppAdresseMAC == "00:10:18:09:E9:E7" || vppAdresseMAC == "8C:DC:D4:45:75:4B" || vppAdresseMAC == "3C:52:82:55:E1:BA"
                )
            {
                return true;
            }
            //GBOBIA 13-09-2021
            else if (
                vppAdresseMAC == "B0:22:7A:F8:CF:CB"//ETHERNET
                || vppAdresseMAC == "A4:97:B1:C0:33:97"//WIFI

                )
            {
                return true;
            }

            //ORDINATEUR IPI 17-11-2021
            if (
            //  SIEGE (DALOA)
            vppAdresseMAC == "9C:D6:43:83:F6:74" //Poste 1 (M. KOLEA)	 			
            || vppAdresseMAC == "80:C1:6E:FC:EE:7E" //POSTE 2 ( Mlle SAHORE EULODIE)	
            || vppAdresseMAC == "54:B8:0A:FD:6A:8F" //POSTE 3 ( Mme KAKOU ALEXANDRA)	
            || vppAdresseMAC == "E4:6F:13:8E:18:CB" //POSTE 4 (Mme GNEPI DESIREE)		
            || vppAdresseMAC == "B0:52:16:6A:03:4D" //POSTE 5(  M. OKOBE)	  	
            || vppAdresseMAC == "C4:85:08:83:B6:DE" //POSTE 6 (M.ATSE )	
            //DALOA
            || vppAdresseMAC == "00:23:24:01:BF:89" //1er Poste 	
            || vppAdresseMAC == "00:1E:C9:6A:9E:64" //2è Poste 	
            //WONSEALY
            || vppAdresseMAC == "D4:85:64:BB:6A:7D" //1er Poste
            //BUYO	
            || vppAdresseMAC == "00:0F:FE:C5:5F:92" //1er Poste 
            || vppAdresseMAC == "C0:A0:BB:BA:35:B4" //1er Poste 
            || vppAdresseMAC == "00:11:85:75:7C:A2" //2è Poste 	
            || vppAdresseMAC == "9C:D6:43:76:E4:AB" //2è Poste 	
            //SOUBRE
            || vppAdresseMAC == "00:0F:FE:FE:72:6D" //1er Poste 
            || vppAdresseMAC == "64:31:50:47:97:DC" //2è Poste 	
            || vppAdresseMAC == "9C:D6:43:69:52:FD" //2è Poste 
            //ISSIA
            || vppAdresseMAC == "BC:30:5B:B8:77:42" //1er Poste 
            || vppAdresseMAC == "14:FE:B5:ED:BB:B4" //2è Poste 	
            //GONATE
            || vppAdresseMAC == "00:0F:FE:C4:72:76" //1er Poste 
            || vppAdresseMAC == "1C:C1:DE:53:D5:D4" //2è Poste 	
            //BELLEVILLE
            || vppAdresseMAC == "BC:30:5B:BC:78:99" //1er Poste 
            || vppAdresseMAC == "FC:4D:D4:2D:FC:59" //2è Poste 	
            || vppAdresseMAC == "90:FB:A6:05:99:12" //3è Poste 	
            //IBOGUHE
            || vppAdresseMAC == "00:21:85:57:02:52" //1er Poste 
            || vppAdresseMAC == "00:24:21:1A:16:AA" //2è Poste  	
            //DAPEOUA
            || vppAdresseMAC == "00:0F:FE:F4:2F:9F" //1er Poste 
            || vppAdresseMAC == "00:0F:FE:F3:B5:7C" //2è Poste  	
            //GUESSABO
            || vppAdresseMAC == "00:25:64:EE:C5:CA" //1er Poste 
            || vppAdresseMAC == "2C:41:38:B4:5C:A5" //2è Poste  	
            || vppAdresseMAC == "E0:DB:55:D2:89:45" //3è Poste  


            //ADRESSE COMPLEMENTAIRES 10-01-2022
            || vppAdresseMAC == "24:BE:05:24:C2:95"
            || vppAdresseMAC == "88:51:FB:47:10:F2"
            || vppAdresseMAC == "2C:44:FD:11:27:96"
            || vppAdresseMAC == "88:51:FB:43:D3:AF"
            || vppAdresseMAC == "3C:D9:2B:63:C6:7B"
            || vppAdresseMAC == "A0:48:1C:98:75:19"
            || vppAdresseMAC == "B4:B5:2F:D2:07:8A"
            || vppAdresseMAC == "48:EE:0C:1C:ED:9C"
            || vppAdresseMAC == "2C:27:D7:29:5E:95"
            || vppAdresseMAC == "24:BE:05:02:E4:54"
            || vppAdresseMAC == "3C:D9:2B:79:42:F9"
            || vppAdresseMAC == "24:BE:05:02:E4:50"
            || vppAdresseMAC == "A0:9F:10:B9:61:76"
            || vppAdresseMAC == "48:EE:0C:E5:B0:9B"
            || vppAdresseMAC == "90:8D:78:F6:99:3C"
            || vppAdresseMAC == "54:B8:0A:89:A0:E9"
            || vppAdresseMAC == "74:EE:2A:FC:3E:83"
            || vppAdresseMAC == "F4:06:69:72:9D:36"
            || vppAdresseMAC == "30:8D:99:69:5C:56"
            || vppAdresseMAC == "AC:E2:D3:68:C2:76"
            || vppAdresseMAC == "44:1C:A8:E8:66:35"
            || vppAdresseMAC == "70:5A:0F:B3:EF:EA"

            //ADRESSE COMPLEMENTAIRES 13-01-2022
            || vppAdresseMAC == "00:E0:32:2E:9D:66"
            || vppAdresseMAC == "F4:06:69:72:9D:3A"
            || vppAdresseMAC == "00:FF:BE:A1:53:C3"
            || vppAdresseMAC == "6C:62:6D:48:D9:96"
            || vppAdresseMAC == "74:EE:2A:FC:C0:F8"
            || vppAdresseMAC == "00:FF:66:2C:02:86"
            || vppAdresseMAC == "C0:3F:D5:B4:EC:4B"
            || vppAdresseMAC == "70:62:B8:C2:47:96"
            || vppAdresseMAC == "C0:3F:D5:B5:11:D4"
            || vppAdresseMAC == "D8:FE:E3:FE:31:25"
            || vppAdresseMAC == "C0:3F:D5:B5:A4:A9"
            || vppAdresseMAC == "E8:CC:18:C2:71:5A"
            || vppAdresseMAC == "24:BE:05:15:A0:64"
            || vppAdresseMAC == "E4:6F:13:8E:15:D3"
            || vppAdresseMAC == "80:C1:6E:FD:4C:0E"
            || vppAdresseMAC == "70:62:B8:77:B3:FE"
            || vppAdresseMAC == "00:E0:2A:2E:75:44"
            || vppAdresseMAC == "00:FF:72:90:8A:9E"
            || vppAdresseMAC == "74:EE:2A:FB:7D:A1"
            || vppAdresseMAC == "C0:A0:BB:7E:E9:8E"
            || vppAdresseMAC == "00:E0:26:2E:44:D7"
            || vppAdresseMAC == "00:FF:57:68:D8:A3"
            || vppAdresseMAC == "9C:D6:43:6A:D8:60"
            || vppAdresseMAC == "00:FF:01:DF:13:E7"
            || vppAdresseMAC == "00:FF:07:4E:F1:08"
            || vppAdresseMAC == "00:FF:6F:A0:A8:48"
            || vppAdresseMAC == "00:FF:B6:59:2C:9C"
            || vppAdresseMAC == "00:FF:F8:17:BB:BF"
            || vppAdresseMAC == "48:EE:0C:1C:ED:9C"
            || vppAdresseMAC == "48:EE:0C:1C:ED:9D"
            || vppAdresseMAC == "00:FF:DF:17:F9:82"
            || vppAdresseMAC == "00:FF:5A:0E:D6:BE"
            || vppAdresseMAC == "00:FF:91:7B:F2:5A"


            //ADRESSE COMPLEMENTAIRES 20-01-2022
            || vppAdresseMAC == "00:E0:32:2E:9D:66"
            || vppAdresseMAC == "F4:06:69:72:9D:3A"
            || vppAdresseMAC == "00:FF:BE:A1:53:C3"
            || vppAdresseMAC == "6C:62:6D:48:D9:96"
            || vppAdresseMAC == "74:EE:2A:FC:C0:F8"
            || vppAdresseMAC == "00:FF:66:2C:02:86"
            || vppAdresseMAC == "C0:3F:D5:B4:EC:4B"
            || vppAdresseMAC == "70:62:B8:C2:47:96"
            || vppAdresseMAC == "C0:3F:D5:B5:11:D4"
            || vppAdresseMAC == "D8:FE:E3:FE:31:25"


            //ADRESSE COMPLEMENTAIRES 20-03-2022
            || vppAdresseMAC == "00:23:24:30:50:28"
            || vppAdresseMAC == "E4:6F:13:8E:1A:72"
            || vppAdresseMAC == "70:F3:95:5C:0E:FF"
            || vppAdresseMAC == "1C:C1:DE:92:6D:A3"
            || vppAdresseMAC == "00:27:10:36:41:F0"
            || vppAdresseMAC == "6C:3B:E5:3B:CE:9E"
            || vppAdresseMAC == "80:E8:2C:C2:22:8F"
            || vppAdresseMAC == "80:91:33:3C:0A:43"
            || vppAdresseMAC == "00:0F:FE:D0:78:6E"
            )
            {
                return true;
            }
            // cmec nzikro 02-06-2022
            else if (
            vppAdresseMAC == "18:60:24:90:10:D8"
            || vppAdresseMAC == "60:18:95:5B:62:53"
            || vppAdresseMAC == "C8:94:02:71:B6:1F"
            //17-05-2023
            || vppAdresseMAC == "38:CA:84:45:B1:01"
            )
            {
                return true;
            }

            // cmec bacon 25-01-2023
            else if (
            vppAdresseMAC == "C0:3F:D5:72:4D:CB"
            || vppAdresseMAC == "00:68:EB:B1:63:34"
            || vppAdresseMAC == "00:68:EB:33:36:FF"
            || vppAdresseMAC == "DC:71:96:4D:4A:95"

            )
            {
                return true;
            }

            //soutra finance 27-07-2022
            else if (
            //POSTE CAISSE
            vppAdresseMAC == "B4:B6:86:8E:76:67"
            || vppAdresseMAC == "7C:76:35:42:C7:F5"
            //POSTE ACCUEIL
            || vppAdresseMAC == "A0:66:10:00:D2:B3"
            || vppAdresseMAC == "F8:63:3F:75:58:19"
            //POSTE DE LA GERANTE (PCA)
            || vppAdresseMAC == "20:16:B9:D5:0B:D3"
            || vppAdresseMAC == "F4:39:09:83:CD:25"
            )
            {
                return true;
            }

            return false;
        }
    }
}
