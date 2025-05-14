using Microsoft.AspNetCore.Mvc;
using MgRequeteClients.BLL.Classes;
using MgRequeteClients.API.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using MgRequeteClients.DAL.Classes;
using MgRequeteClients.Tools.Classes;
using MgRequeteClients.API.ServiceContract;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using MgRequeteClients.BOJ.BusinessObjects;
using System.Reflection;
using log4net;

namespace MgRequeteClients.API.Service
{
   
    public class wsAgence : IwsAgence
    {
        
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsAgenceWSBLL clsAgenceWSBLL = new clsAgenceWSBLL();
        private clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
        //Déclaration du log
        log4net.ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly clsDonnee _clsDonnee;
        private readonly IConfiguration _configuration;
        public wsAgence(IConfiguration configuration)
        {
            _configuration = configuration;
            _clsDonnee = new clsDonnee(configuration);
        }


        public string AjouterAgence(MgRequeteClients.DTO.BusinessObjects.clsAgence Objet)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            string json = "";
            string OE_D = "";

            var clsObjetEnvoi = new clsObjetEnvoi();
            var clsAgence = new MgRequeteClients.BOJ.BusinessObjects.clsAgence();

            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
           // clsObjetEnvoi.OE_D  = clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsObjetEnvoi.OE_D);
           // clsObjetEnvoi.OE_X = clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsObjetEnvoi.OE_X);


            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            var clsObjetRetour = new MgRequeteClients.DTO.BusinessObjects.clsObjetRetour();

            try
            {
                _clsDonnee.pvgDemarrerTransaction();

                /*if (Objet.clsObjetEnvoi != null)
                {
                    clsObjetEnvoi.OE_A = Objet.clsObjetEnvoi.OE_A;
                    clsObjetEnvoi.OE_Y = Objet.clsObjetEnvoi.OE_Y;
                    clsObjetEnvoi.OE_Q = Objet.clsObjetEnvoi.OE_Q;
                    if (!string.IsNullOrEmpty(Objet.clsObjetEnvoi.OE_J))
                        clsObjetEnvoi.OE_J = DateTime.Parse(Objet.clsObjetEnvoi.OE_J);
                    if (!string.IsNullOrEmpty(Objet.clsObjetEnvoi.OE_G))
                        clsObjetEnvoi.OE_G = DateTime.Parse(Objet.clsObjetEnvoi.OE_G);
                    clsObjetEnvoi.OE_T = Objet.clsObjetEnvoi.OE_T;
                    clsObjetEnvoi.OE_U = Objet.clsObjetEnvoi.OE_U;
                }

                if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(_clsDonnee, clsObjetEnvoi) == "0")
                {
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = MgRequeteClients.Tools.Classes.clsDeclaration.ClasseDeclaration.MESSAGERETOURS;
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
                else
                {*/
                    // Mapping DTO vers BOJ
                    clsAgence.AG_CODEAGENCE = Objet.AG_CODEAGENCE;
                    clsAgence.SO_CODESOCIETE = Objet.SO_CODESOCIETE;
                    clsAgence.AG_AGENCECODE = Objet.AG_AGENCECODE;
                    clsAgence.AG_RAISONSOCIAL = Objet.AG_RAISONSOCIAL;
                    clsAgence.AG_DATECREATION = DateTime.Parse(Objet.AG_DATECREATION);
                    clsAgence.AG_NUMEROAGREMENT = Objet.AG_NUMEROAGREMENT;
                    clsAgence.OP_CODEOPERATEUR = Objet.OP_CODEOPERATEUR;
                    clsAgence.AG_BOITEPOSTAL = Objet.AG_BOITEPOSTAL;
                    clsAgence.VL_CODEVILLE = Objet.VL_CODEVILLE;
                    clsAgence.AG_ADRESSEGEOGRAPHIQUE = Objet.AG_ADRESSEGEOGRAPHIQUE;
                    clsAgence.AG_TELEPHONE = Objet.AG_TELEPHONE;
                    clsAgence.AG_FAX = Objet.AG_FAX;
                    clsAgence.AG_EMAIL = Objet.AG_EMAIL;
                    clsAgence.AG_EMAILMOTDEPASSE = Objet.AG_EMAILMOTDEPASSE;
                    clsAgence.AG_NUMEROCOMPTE = Objet.AG_NUMEROCOMPTE;
                    clsAgence.AG_CINETSITEID = Objet.AG_CINETSITEID;
                    clsAgence.AG_CINETAPIKEY = Objet.AG_CINETAPIKEY;
                    clsAgence.AG_CINETAPIPWD = Objet.AG_CINETAPIPWD;
                    clsAgence.AG_CINETURLNOTIFICATIONZENITH = Objet.AG_CINETURLNOTIFICATIONZENITH;
                    clsAgence.AG_CINETURLNOTIFICATIONTONTINE = Objet.AG_CINETURLNOTIFICATIONTONTINE;
                    clsAgence.AG_URLINTOUCHCASHIN = Objet.AG_URLINTOUCHCASHIN;
                    clsAgence.AG_URLINTOUCHCASHOUT = Objet.AG_URLINTOUCHCASHOUT;
                    clsAgence.AG_TOKENTOUCHLOGIN = Objet.AG_TOKENTOUCHLOGIN;
                    clsAgence.AG_TOKENTOUCHPWD = Objet.AG_TOKENTOUCHPWD;
                    clsAgence.AG_RAISONSOCIALABREGEPOURSMS = Objet.AG_RAISONSOCIALABREGEPOURSMS;

                    clsObjetRetour.SetValue(true, clsAgenceWSBLL.pvgAjouter(_clsDonnee, clsAgence, clsObjetEnvoi));

                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        DataRow dr = dt.NewRow();
                        dr["SL_CODEMESSAGE"] = "00";
                        dr["SL_RESULTAT"] = "TRUE";
                        dr["SL_MESSAGE"] = "L'opération s'est réalisée avec succès";
                        dt.Rows.Add(dr);
                        DataSet.Tables.Add(dt);
                        json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                    }
                //}
            }
            catch (SqlException ex)
            {
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = (ex.Number == 2601 || ex.Number == 2627)
                    ? clsMessagesWSBLL.pvgTableLibelle(_clsDonnee, "GNE0003").MS_LIBELLEMESSAGE
                    : ex.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                Log.Error(ex.Message, null);
            }
            catch (Exception ex)
            {
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = ex.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                Log.Error(ex.Message, null);
            }
            finally
            {
                bool isSuccess = DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "TRUE";
                _clsDonnee.pvgTerminerTransaction(!isSuccess);
            }

            return json;
        }


    }
}
