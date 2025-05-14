using log4net;
using MgRequeteClients.BLL.Classes;
using MgRequeteClients.Tools.Classes;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Net.Mail;
using System.Net;
using MgRequeteClients.BOJ.BusinessObjects;
using Newtonsoft.Json;
using MgRequeteClients.API.ServiceContract;

namespace MgRequeteClients.API.Service
{
    public class RequeteClientsClasse : IRequeteClientsClasse
    {
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsAgenceWSBLL clsAgenceWSBLL = new clsAgenceWSBLL();
        private clsJourneetravailWSBLL clsJourneetravailWSBLL = new clsJourneetravailWSBLL();
        private clsEditionWSBLL clsEditionWSBLL = new clsEditionWSBLL();
        private clsReqagencelogicielliaisonWSBLL clsReqagencelogicielliaisonWSBLL = new clsReqagencelogicielliaisonWSBLL();
        private clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
        

        //Déclaration du log
        log4net.ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly clsDonnee _clsDonnee;
        private readonly IConfiguration _configuration;
        public RequeteClientsClasse(IConfiguration configuration)
        {
            _configuration = configuration;
            _clsDonnee = new clsDonnee(configuration);
        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgInsertIntoDatasetListeClient(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> clsReqcompteutilisateurs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur>();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour clsObjetRetour = new MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi clsObjetEnvoi = new MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi();
            MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet clsEditionEtatGuichet = new MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet();
            clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;//new string[] { "0002" };
            }


            try
            {
                

                clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
                clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;


                _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                _clsDonnee.pvgDemarrerTransaction();

                clsObjetRetour.SetValue(true, clsReqcompteutilisateurWSBLL.pvgInsertIntoDatasetListeClient(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);

                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {

                        DataTable tableAgence = new DataTable();
                        foreach (DataRow row in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateur = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();

                            string AG_EMAIL = "";
                            string AG_EMAILMOTDEPASSE = "";
                            string AG_RAISONSOCIAL = "";
                            clsReqniveausatisfactionWSBLL clsReqniveausatisfactionWSBLL = new clsReqniveausatisfactionWSBLL();
                            DataSet DataSet = new DataSet();
                            clsObjetEnvoi.OE_PARAM = new string[] { row["AG_CODEAGENCE"].ToString() };
                            DataSet = clsReqniveausatisfactionWSBLL.pvgChargerDansDataSetAgence(_clsDonnee, clsObjetEnvoi);
                            foreach (DataRow row2 in DataSet.Tables[0].Rows)
                            {
                                AG_EMAIL = row2["AG_EMAIL"].ToString();
                                AG_EMAILMOTDEPASSE = row2["AG_EMAILMOTDEPASSE"].ToString();
                                AG_RAISONSOCIAL = row2["AG_RAISONSOCIAL"].ToString();
                            }

                            clsReqcompteutilisateur.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                            clsReqcompteutilisateur.AG_RAISONSOCIAL = AG_RAISONSOCIAL;
                            clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR = row["CU_CODECOMPTEUTULISATEUR"].ToString();
                            clsReqcompteutilisateur.TU_CODETYPEUTILISATEUR = row["TU_CODETYPEUTILISATEUR"].ToString();
                            clsReqcompteutilisateur.CU_NUMEROUTILISATEUR = row["CU_NUMEROUTILISATEUR"].ToString();
                            clsReqcompteutilisateur.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = row["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                            clsReqcompteutilisateur.CU_NOMUTILISATEUR = row["CU_NOMUTILISATEUR"].ToString();
                            clsReqcompteutilisateur.CU_CONTACT = row["CU_CONTACT"].ToString();
                            clsReqcompteutilisateur.CU_EMAIL = row["CU_EMAIL"].ToString();
                            clsReqcompteutilisateur.CU_LOGIN = row["CU_LOGIN"].ToString();
                            clsReqcompteutilisateur.CU_MOTDEPASSE = row["CU_MOTDEPASSE"].ToString();
                            clsReqcompteutilisateur.CU_DATECREATION = row["CU_DATECREATION"].ToString();
                            clsReqcompteutilisateur.CU_DATECLOTURE = row["CU_DATECLOTURE"].ToString();
                            clsReqcompteutilisateur.CU_TOKEN = row["CU_TOKEN"].ToString();
                            clsReqcompteutilisateur.PI_CODEPIECE = row["PI_CODEPIECE"].ToString();
                            clsReqcompteutilisateur.CU_NUMEROPIECE = row["CU_NUMEROPIECE"].ToString();
                            clsReqcompteutilisateur.CU_DATEPIECE = row["CU_DATEPIECE"].ToString();
                            clsReqcompteutilisateur.CU_NOMBRECONNECTION = row["CU_NOMBRECONNECTION"].ToString();
                            clsReqcompteutilisateur.CU_CLESESSION = row["CU_CLESESSION"].ToString();

                            clsReqcompteutilisateur.SL_RESULTAT = "TRUE";
                            clsReqcompteutilisateur.SL_MESSAGE = "Opération réalisée avec succès !!!";
                            clsReqcompteutilisateur.SL_CODEMESSAGE = "00";

                            clsReqcompteutilisateurs.Add(clsReqcompteutilisateur);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateur = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateur.SL_RESULTAT = "FALSE";
                        clsReqcompteutilisateur.SL_MESSAGE = "Aucun élément trouvé !!!";
                        clsReqcompteutilisateur.SL_CODEMESSAGE = "00";

                        clsReqcompteutilisateurs.Add(clsReqcompteutilisateur);
                    }

                }
            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateur = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateur.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateur.SL_MESSAGE = SQLEx.Message;
                clsReqcompteutilisateur.SL_CODEMESSAGE = "00";
                clsReqcompteutilisateurs.Add(clsReqcompteutilisateur);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            catch (Exception SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateur = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateur.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateur.SL_MESSAGE = SQLEx.Message;
                clsReqcompteutilisateur.SL_CODEMESSAGE = "00";
                clsReqcompteutilisateurs.Add(clsReqcompteutilisateur);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsReqcompteutilisateurs;

        }

        public MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur pvgMajUtilisateurs(List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();

            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;


            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> clsReqcompteutilisateurDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateur in Objets)
            {
                if (clsReqcompteutilisateur.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }




                if (string.IsNullOrEmpty(clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "2"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_CODECOMPTEUTULISATEUR";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }


                if (string.IsNullOrEmpty(clsReqcompteutilisateur.AG_CODEAGENCE) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AG_CODEAGENCE";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqcompteutilisateur.TU_CODETYPEUTILISATEUR) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TU_CODETYPEUTILISATEUR";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_NUMEROUTILISATEUR) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_NUMEROUTILISATEUR";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_ADRESSEGEOGRAPHIQUEUTILISATEUR";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_NOMUTILISATEUR) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_NOMUTILISATEUR";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }


                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_CONTACT) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_CONTACT";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_EMAIL) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_EMAIL";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_LOGIN) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_LOGIN";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_MOTDEPASSE) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_MOTDEPASSE";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_DATECREATION) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_DATECREATION";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_DATECLOTURE) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_DATECLOTURE";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqcompteutilisateur.PI_CODEPIECE) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " PI_CODEPIECE";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_NUMEROPIECE) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_NUMEROPIECE";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_DATEPIECE) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_DATEPIECE";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_NOMBRECONNECTION) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_NOMBRECONNECTION";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs[0];
                }


                if (clsReqcompteutilisateur.TU_CODETYPEUTILISATEUR == "0001")
                {
                    if (clsReqcompteutilisateur.clsReqoperateur == null)
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        //----EXEPTION
                        clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                        clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsReqoperateur";
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                        return clsReqcompteutilisateurDTOs[0];
                    }


                    if (string.IsNullOrEmpty(clsReqcompteutilisateur.clsReqoperateur.AG_CODEAGENCE) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        //----EXEPTION
                        clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                        clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AG_CODEAGENCE";
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                        return clsReqcompteutilisateurDTOs[0];
                    }

                    if (string.IsNullOrEmpty(clsReqcompteutilisateur.clsReqoperateur.PV_CODEPOINTVENTE) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        //----EXEPTION
                        clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                        clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " PV_CODEPOINTVENTE";
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                        return clsReqcompteutilisateurDTOs[0];
                    }

                    //if (string.IsNullOrEmpty(clsReqcompteutilisateur.clsReqoperateur.OP_CODEOPERATEUR) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                    //{
                    //    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    //    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //    //----EXEPTION
                    //    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    //    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    //    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " OP_CODEOPERATEUR";
                    //    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    //    return clsReqcompteutilisateurDTOs[0];
                    //}


                    if (string.IsNullOrEmpty(clsReqcompteutilisateur.clsReqoperateur.SR_CODESERVICE) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        //----EXEPTION
                        clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                        clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " SR_CODESERVICE";
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                        return clsReqcompteutilisateurDTOs[0];
                    }
                    if (string.IsNullOrEmpty(clsReqcompteutilisateur.clsReqoperateur.OP_DATESAISIE) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        //----EXEPTION
                        clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                        clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " OP_DATESAISIE";
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                        return clsReqcompteutilisateurDTOs[0];
                    }

                }
                if (clsReqcompteutilisateur.TU_CODETYPEUTILISATEUR == "0002")
                {
                    if (clsReqcompteutilisateur.clsReqmicclient == null)
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        //----EXEPTION
                        clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                        clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsReqmicclient";
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                        return clsReqcompteutilisateurDTOs[0];
                    }

                    if (string.IsNullOrEmpty(clsReqcompteutilisateur.clsReqmicclient.AG_CODEAGENCE) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        //----EXEPTION
                        clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                        clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AG_CODEAGENCE";
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                        return clsReqcompteutilisateurDTOs[0];
                    }
                    if (string.IsNullOrEmpty(clsReqcompteutilisateur.clsReqmicclient.PV_CODEPOINTVENTE) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        //----EXEPTION
                        clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                        clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " PV_CODEPOINTVENTE";
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                        return clsReqcompteutilisateurDTOs[0];
                    }
                    if (string.IsNullOrEmpty(clsReqcompteutilisateur.clsReqmicclient.CL_DATESAISIE) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        //----EXEPTION
                        clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                        clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CL_DATESAISIE";
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                        return clsReqcompteutilisateurDTOs[0];
                    }

                    //if (string.IsNullOrEmpty(clsReqcompteutilisateur.clsReqmicclient.CL_IDCLIENT) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                    //{
                    //    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    //    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //    //----EXEPTION
                    //    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    //    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    //    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CL_IDCLIENT";
                    //    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    //    return clsReqcompteutilisateurDTOs[0];
                    //}


                }

            }

            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                    //===
                    MgRequeteClients.BOJ.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurBOJ = new clsReqcompteutilisateur();
                    clsReqcompteutilisateurBOJ.CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateurDTO.CU_CODECOMPTEUTULISATEUR;
                    clsReqcompteutilisateurBOJ.AG_CODEAGENCE = clsReqcompteutilisateurDTO.AG_CODEAGENCE;
                    clsReqcompteutilisateurBOJ.TU_CODETYPEUTILISATEUR = clsReqcompteutilisateurDTO.TU_CODETYPEUTILISATEUR;
                    clsReqcompteutilisateurBOJ.CU_NUMEROUTILISATEUR = clsReqcompteutilisateurDTO.CU_NUMEROUTILISATEUR;
                    clsReqcompteutilisateurBOJ.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = clsReqcompteutilisateurDTO.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR;
                    clsReqcompteutilisateurBOJ.CU_NOMUTILISATEUR = clsReqcompteutilisateurDTO.CU_NOMUTILISATEUR;

                    clsReqcompteutilisateurBOJ.CU_CONTACT = clsReqcompteutilisateurDTO.CU_CONTACT;
                    clsReqcompteutilisateurBOJ.CU_EMAIL = clsReqcompteutilisateurDTO.CU_EMAIL;
                    clsReqcompteutilisateurBOJ.CU_LOGIN = clsReqcompteutilisateurDTO.CU_LOGIN;
                    clsReqcompteutilisateurBOJ.CU_MOTDEPASSE = clsReqcompteutilisateurDTO.CU_MOTDEPASSE;
                    clsReqcompteutilisateurBOJ.CU_DATECREATION = DateTime.Parse(clsReqcompteutilisateurDTO.CU_DATECREATION);
                    clsReqcompteutilisateurBOJ.CU_DATECLOTURE = DateTime.Parse(clsReqcompteutilisateurDTO.CU_DATECLOTURE);
                    clsReqcompteutilisateurBOJ.CU_TOKEN = clsReqcompteutilisateurDTO.CU_TOKEN;
                    clsReqcompteutilisateurBOJ.PI_CODEPIECE = clsReqcompteutilisateurDTO.PI_CODEPIECE;
                    clsReqcompteutilisateurBOJ.CU_NUMEROPIECE = clsReqcompteutilisateurDTO.CU_NUMEROPIECE;
                    clsReqcompteutilisateurBOJ.CU_DATEPIECE = DateTime.Parse(clsReqcompteutilisateurDTO.CU_DATEPIECE);
                    clsReqcompteutilisateurBOJ.CU_NOMBRECONNECTION = clsReqcompteutilisateurDTO.CU_NOMBRECONNECTION;
                    clsReqcompteutilisateurBOJ.CU_CLESESSION = clsReqcompteutilisateurDTO.CU_CLESESSION;

                    clsReqcompteutilisateurBOJ.TYPEOPERATION = clsReqcompteutilisateurDTO.clsObjetEnvoi.TYPEOPERATION;

                    //====
                    clsObjetRetour.SetValue(true, clsReqcompteutilisateurWSBLL.pvgMiseajour(_clsDonnee, clsReqcompteutilisateurBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {

                        if (clsReqcompteutilisateurDTO.clsReqoperateur != null && clsReqcompteutilisateurDTO.TU_CODETYPEUTILISATEUR == "0001")
                        {
                            clsObjetRetour clsObjetRetourclsFacturationdetailstock = new clsObjetRetour();
                            clsObjetEnvoi = new clsObjetEnvoi();
                            clsReqoperateurWSBLL clsReqoperateurWSBLL = new clsReqoperateurWSBLL();
                            //===
                            MgRequeteClients.BOJ.BusinessObjects.clsReqoperateur clsReqoperateurBOJ = new clsReqoperateur();
                            clsReqoperateurBOJ.OP_CODEOPERATEUR = clsReqcompteutilisateurDTO.clsReqoperateur.OP_CODEOPERATEUR;
                            clsReqoperateurBOJ.OP_CODEOPERATEURZENITH = clsReqcompteutilisateurDTO.clsReqoperateur.OP_CODEOPERATEURZENITH;
                            clsReqoperateurBOJ.AG_CODEAGENCE = clsReqcompteutilisateurDTO.clsReqoperateur.AG_CODEAGENCE;
                            clsReqoperateurBOJ.PV_CODEPOINTVENTE = clsReqcompteutilisateurDTO.clsReqoperateur.PV_CODEPOINTVENTE;
                            clsReqoperateurBOJ.CU_CODECOMPTEUTULISATEUR = clsObjetRetour.OR_STRING;
                            clsReqoperateurBOJ.SR_CODESERVICE = clsReqcompteutilisateurDTO.clsReqoperateur.SR_CODESERVICE;
                            clsReqoperateurBOJ.OP_DATESAISIE = DateTime.Parse(clsReqcompteutilisateurDTO.clsReqoperateur.OP_DATESAISIE);
                            clsReqoperateurBOJ.TYPEOPERATION = clsReqcompteutilisateurDTO.clsObjetEnvoi.TYPEOPERATION;
                            //====
                            clsObjetRetourclsFacturationdetailstock.SetValue(true, clsReqoperateurWSBLL.pvgMiseajour(_clsDonnee, clsReqoperateurBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                            if (clsObjetRetourclsFacturationdetailstock.OR_BOOLEEN)
                            {
                                //AppSoftCleanServeur.DTO.clsCompteutilisateur clsCompteutilisateurDTOR = new AppSoftCleanServeur.DTO.clsCompteutilisateur();
                                //clsCompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                //clsCompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = AppSoftCleanServeur.BOJ.clsDeclaration.CODE_SUCCESS;
                                //clsCompteutilisateurDTOR.clsResultat.SL_RESULTAT = AppSoftCleanServeur.BOJ.clsDeclaration.SUCCESS_RESULTAT;
                                //clsCompteutilisateurDTOR.clsResultat.SL_MESSAGE = AppSoftCleanServeur.BOJ.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                //clsCompteutilisateurDTOs.Add(clsCompteutilisateurDTOR);

                                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                                string AG_CODEAGENCE = "";
                                string SM_TELEPHONE = "";
                                string SMSTEXT = "";
                                DateTime SM_DATEPIECE = clsReqoperateurBOJ.OP_DATESAISIE;
                                string TYPEOPERATION = "";
                                string SL_LIBELLE1 = "";
                                string SL_LIBELLE2 = "";
                                string TE_CODESMSTYPEOPERATION = "";
                                string CU_CODECOMPTEUTULISATEUR = "";


                                // clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                                clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
                                clsObjetEnvoi.OE_PARAM = new string[] { clsReqoperateurBOJ.CU_CODECOMPTEUTULISATEUR }; ;
                                clsReqcompteutilisateur = clsReqcompteutilisateurWSBLL.pvgTableLibelle(_clsDonnee, clsObjetEnvoi);

                                if (clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR != "")
                                {
                                    AG_CODEAGENCE = clsReqcompteutilisateur.AG_CODEAGENCE;
                                    SM_TELEPHONE = clsReqcompteutilisateur.CU_CONTACT;
                                    SMSTEXT = "Vous avez une nouvelle requette à traiter !!!";
                                    SM_DATEPIECE = clsReqoperateurBOJ.OP_DATESAISIE;
                                    TYPEOPERATION = "0";
                                    SL_LIBELLE1 = "";
                                    SL_LIBELLE2 = "";
                                    TE_CODESMSTYPEOPERATION = "0001";
                                    CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;

                                    clsParams clsParams = new clsParams();
                                    clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                                    //public clsParams pvgTraitementSmsSimple1(_clsDonnee clsDonnee, string AG_CODEAGENCE, string SM_TELEPHONE, string SMSTEXT, DateTime SM_DATEPIECE, string TYPEOPERATION, string TE_CODESMSTYPEOPERATION, string CU_CODECOMPTEUTULISATEUR, string SL_LIBELLE1, string SL_LIBELLE2)
                                    clsParams = clsSmsoutWSBLL.pvgTraitementSmsSimple1(_clsDonnee, AG_CODEAGENCE, SM_TELEPHONE, SMSTEXT, SM_DATEPIECE, TYPEOPERATION, TE_CODESMSTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, SL_LIBELLE1, SL_LIBELLE2);
                                }
                            }
                        }


                        if (clsReqcompteutilisateurDTO.clsReqmicclient != null && clsReqcompteutilisateurDTO.TU_CODETYPEUTILISATEUR == "0002")
                        {


                            clsObjetRetour clsObjetRetourclsFacturationdetailstock = new clsObjetRetour();
                            clsObjetEnvoi = new clsObjetEnvoi();
                            clsReqmicclientWSBLL clsReqmicclientWSBLL = new clsReqmicclientWSBLL();
                            //===
                            MgRequeteClients.BOJ.BusinessObjects.clsReqmicclient clsReqmicclientBOJ = new clsReqmicclient();
                            clsReqmicclientBOJ.CL_IDCLIENT = clsReqcompteutilisateurDTO.clsReqmicclient.CL_IDCLIENT;
                            clsReqmicclientBOJ.CL_CODECLIENT = clsReqcompteutilisateurDTO.clsReqmicclient.CL_CODECLIENT;
                            clsReqmicclientBOJ.CL_CODECLIENTZENITH = clsReqcompteutilisateurDTO.clsReqmicclient.CL_CODECLIENTZENITH;
                            clsReqmicclientBOJ.AG_CODEAGENCE = clsReqcompteutilisateurDTO.clsReqmicclient.AG_CODEAGENCE;
                            clsReqmicclientBOJ.PV_CODEPOINTVENTE = clsReqcompteutilisateurDTO.clsReqmicclient.PV_CODEPOINTVENTE;
                            clsReqmicclientBOJ.CU_CODECOMPTEUTULISATEUR = clsObjetRetour.OR_STRING;
                            clsReqmicclientBOJ.CL_DATESAISIE = DateTime.Parse(clsReqcompteutilisateurDTO.clsReqmicclient.CL_DATESAISIE);
                            clsReqmicclientBOJ.CL_REGISTRECOMMERCE = clsReqcompteutilisateurDTO.clsReqmicclient.CL_REGISTRECOMMERCE;
                            clsReqmicclientBOJ.CL_NUMEROCOMPTECONTRIBUABLE = clsReqcompteutilisateurDTO.clsReqmicclient.CL_NUMEROCOMPTECONTRIBUABLE;
                            clsReqmicclientBOJ.TYPEOPERATION = clsReqcompteutilisateurDTO.clsObjetEnvoi.TYPEOPERATION;
                            //====
                            clsObjetRetourclsFacturationdetailstock.SetValue(true, clsReqmicclientWSBLL.pvgMiseajour(_clsDonnee, clsReqmicclientBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                            if (clsObjetRetourclsFacturationdetailstock.OR_BOOLEEN)
                            {
                                //AppSoftCleanServeur.DTO.clsCompteutilisateur clsCompteutilisateurDTOR = new AppSoftCleanServeur.DTO.clsCompteutilisateur();
                                //clsCompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                //clsCompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = AppSoftCleanServeur.BOJ.clsDeclaration.CODE_SUCCESS;
                                //clsCompteutilisateurDTOR.clsResultat.SL_RESULTAT = AppSoftCleanServeur.BOJ.clsDeclaration.SUCCESS_RESULTAT;
                                //clsCompteutilisateurDTOR.clsResultat.SL_MESSAGE = AppSoftCleanServeur.BOJ.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                //clsCompteutilisateurDTOs.Add(clsCompteutilisateurDTOR);
                                //MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                                //string AG_CODEAGENCE = "";
                                //string SM_TELEPHONE = "";
                                //string SMSTEXT = "";
                                //DateTime SM_DATEPIECE = clsReqmicclientBOJ.CL_DATESAISIE;
                                //string TYPEOPERATION = "";
                                //string SL_LIBELLE1 = "";
                                //string SL_LIBELLE2 = "";
                                //string TE_CODESMSTYPEOPERATION = "";
                                //string CU_CODECOMPTEUTULISATEUR = "";


                                //// clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                                //clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
                                //clsObjetEnvoi.OE_PARAM = new string[] { clsReqmicclientBOJ.CU_CODECOMPTEUTULISATEUR }; ;
                                //clsReqcompteutilisateur = clsReqcompteutilisateurWSBLL.pvgTableLibelle(_clsDonnee, clsObjetEnvoi);

                                //if (clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR != "")
                                //{
                                //    AG_CODEAGENCE = clsReqcompteutilisateur.AG_CODEAGENCE;
                                //    SM_TELEPHONE = clsReqcompteutilisateur.CU_CONTACT;
                                //    SMSTEXT = "Vous avez une nouvelle requette à traiter !!!";
                                //    SM_DATEPIECE = clsReqmicclientBOJ.CL_DATESAISIE;
                                //    TYPEOPERATION = "0";
                                //    SL_LIBELLE1 = "";
                                //    SL_LIBELLE2 = "";
                                //    TE_CODESMSTYPEOPERATION = "0001";
                                //    CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;

                                //    if (SM_TELEPHONE.Length == 10)
                                //        SM_TELEPHONE = "225" + SM_TELEPHONE;

                                //    clsParams clsParams = new clsParams();
                                //    clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                                //    //public clsParams pvgTraitementSmsSimple1(_clsDonnee clsDonnee, string AG_CODEAGENCE, string SM_TELEPHONE, string SMSTEXT, DateTime SM_DATEPIECE, string TYPEOPERATION, string TE_CODESMSTYPEOPERATION, string CU_CODECOMPTEUTULISATEUR, string SL_LIBELLE1, string SL_LIBELLE2)
                                //    clsParams = clsSmsoutWSBLL.pvgTraitementSmsSimple1(_clsDonnee, AG_CODEAGENCE, SM_TELEPHONE, SMSTEXT, SM_DATEPIECE, TYPEOPERATION, TE_CODESMSTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, SL_LIBELLE1, SL_LIBELLE2);

                                //}

                            }






                        }

                        //Envoi Email 
                        if (clsReqcompteutilisateurBOJ.CU_EMAIL != "" && clsReqcompteutilisateurDTO.TU_CODETYPEUTILISATEUR == "0001")
                        {
                            string AG_EMAIL = "";
                            string AG_EMAILMOTDEPASSE = "";
                            string AG_RAISONSOCIAL = "";
                            clsReqniveausatisfactionWSBLL clsReqniveausatisfactionWSBLL = new clsReqniveausatisfactionWSBLL();
                            DataSet DataSet = new DataSet();
                            clsObjetEnvoi.OE_PARAM = new string[] { clsReqcompteutilisateurBOJ.AG_CODEAGENCE };
                            DataSet = clsReqniveausatisfactionWSBLL.pvgChargerDansDataSetAgence(_clsDonnee, clsObjetEnvoi);
                            foreach (DataRow row in DataSet.Tables[0].Rows)
                            {
                                AG_EMAIL = row["AG_EMAIL"].ToString();
                                AG_EMAILMOTDEPASSE = row["AG_EMAILMOTDEPASSE"].ToString();
                                AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                            }

                            // Paramètres du serveur SMTP
                            string smtpServeur = "smtp.gmail.com";
                            int portSmtp = 587;
                            string adresseEmail = AG_EMAIL;//"bolatykouassieuloge@gmail.com";
                            string motDePasse = AG_EMAILMOTDEPASSE;//"nffncgqonuuildmc";

                            // Destinataire et contenu de l'e-mail
                            string destinataire = clsReqcompteutilisateurBOJ.CU_EMAIL;// "technicosup@mgdigitalplus.com";
                            string sujet = "Creation de Compte Utilisateur";
                            string corpsMessage = "";
                            if (clsReqcompteutilisateurDTO.TU_CODETYPEUTILISATEUR == "0001" || clsReqcompteutilisateurDTO.TU_CODETYPEUTILISATEUR == "0002")
                            {
                                corpsMessage =
                                     "Bienvenue dans Réclam + !\n" +
                                     "\n" +
                                     "Cher " + clsReqcompteutilisateurBOJ.CU_NOMUTILISATEUR + ",\n" +
                                     "\n" +
                                     "Votre compte a été créé avec succès, vous pouvez désormais accéder à toutes les fonctionnalités et ressources disponibles pour votre rôle.\n" +
                                     "\n" +
                                     "Voici quelques informations importantes pour commencer :\n" +


                                     //"lien de connexion : http://51.210.111.16:1010\n" +

                                     "lien de connexion : https://reclamationclient1.mgdigitalplus.com:1020\n" +


                                     "Identifiant : " + clsReqcompteutilisateurBOJ.CU_LOGIN + "\n" +
                                     "Mot de passe temporaire : " + clsReqcompteutilisateurBOJ.CU_MOTDEPASSE + "\n" +
                                     "\n" +
                                     "Vous serez invité(e) à définir un nouveau mot de passe lors de votre première connexion. Assurez vous de choisir un mot de passe fort et unique.\n" +
                                     "\n" +
                                     "Nous vous souhaitons beaucoup de succès dans vos activités avec Réclam+ !\n" +
                                     "\n" +
                                     "Cordialement,\n" +
                                     "\n" +
                                     "L'équipe de support de REMUCI";
                            }



                            // Création de l'objet MailMessage
                            MailMessage message = new MailMessage(adresseEmail, destinataire, sujet, corpsMessage);

                            // Création de l'objet SmtpClient
                            SmtpClient clientSmtp = new SmtpClient(smtpServeur, portSmtp);
                            clientSmtp.UseDefaultCredentials = false;
                            clientSmtp.Credentials = new NetworkCredential(adresseEmail, motDePasse);
                            clientSmtp.EnableSsl = true;

                            // Envoi de l'e-mail
                            clientSmtp.Send(message);

                        }


                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                        clsReqcompteutilisateurDTOR.CU_CODECOMPTEUTULISATEUR = clsObjetRetour.OR_STRING;
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqcompteutilisateurDTOs[0];

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgListeUtilisateurs(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> clsReqcompteutilisateurDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqcompteutilisateurWSBLL.pvgChargerDansDataSet(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                                clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqcompteutilisateurDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                clsReqcompteutilisateurDTOR.TU_CODETYPEUTILISATEUR = DataRow["TU_CODETYPEUTILISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.CU_NUMEROUTILISATEUR = DataRow["CU_NUMEROUTILISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = DataRow["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                                clsReqcompteutilisateurDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();
                                clsReqcompteutilisateurDTOR.CU_LOGIN = DataRow["CU_LOGIN"].ToString();
                                clsReqcompteutilisateurDTOR.CU_MOTDEPASSE = DataRow["CU_MOTDEPASSE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_DATECREATION = clsDate.ClasseDate.pvgFormaterDate(DataRow["CU_DATECREATION"].ToString()); // DataRow["CU_DATECREATION"].ToString();
                                clsReqcompteutilisateurDTOR.CU_DATECLOTURE = clsDate.ClasseDate.pvgFormaterDate(DataRow["CU_DATECLOTURE"].ToString()); //DataRow["CU_DATECLOTURE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_TOKEN = DataRow["CU_TOKEN"].ToString();
                                clsReqcompteutilisateurDTOR.PI_CODEPIECE = DataRow["PI_CODEPIECE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_NUMEROPIECE = DataRow["CU_NUMEROPIECE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_DATEPIECE = DataRow["CU_DATEPIECE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_NOMBRECONNECTION = DataRow["CU_NOMBRECONNECTION"].ToString();
                                clsReqcompteutilisateurDTOR.CU_CLESESSION = DataRow["CU_CLESESSION"].ToString();
                                clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                            clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqcompteutilisateurDTOs;

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgListeUtilisateursRechercheParAgence(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> clsReqcompteutilisateurDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                    //===
                    string agenceCode = clsObjetEnvoiListe.OE_PARAM[3];
                    clsObjetEnvoiListe.OE_PARAM[3] = "";
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqcompteutilisateurWSBLL.pvgChargerDansDataSetRechercheUtilisateur(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                if (agenceCode == DataRow["AG_CODEAGENCE"].ToString())
                                {
                                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                                    clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                    clsReqcompteutilisateurDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                    clsReqcompteutilisateurDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                    clsReqcompteutilisateurDTOR.TU_CODETYPEUTILISATEUR = DataRow["TU_CODETYPEUTILISATEUR"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_NUMEROUTILISATEUR = DataRow["CU_NUMEROUTILISATEUR"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = DataRow["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_LOGIN = DataRow["CU_LOGIN"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_MOTDEPASSE = DataRow["CU_MOTDEPASSE"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_DATECREATION = clsDate.ClasseDate.pvgFormaterDate(DataRow["CU_DATECREATION"].ToString()); // DataRow["CU_DATECREATION"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_DATECLOTURE = clsDate.ClasseDate.pvgFormaterDate(DataRow["CU_DATECLOTURE"].ToString()); //DataRow["CU_DATECLOTURE"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_TOKEN = DataRow["CU_TOKEN"].ToString();
                                    clsReqcompteutilisateurDTOR.PI_CODEPIECE = DataRow["PI_CODEPIECE"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_NUMEROPIECE = DataRow["CU_NUMEROPIECE"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_DATEPIECE = DataRow["CU_DATEPIECE"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_NOMBRECONNECTION = DataRow["CU_NOMBRECONNECTION"].ToString();
                                    clsReqcompteutilisateurDTOR.CU_CLESESSION = DataRow["CU_CLESESSION"].ToString();
                                    clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                    clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                    clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                                }

                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                            clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqcompteutilisateurDTOs;

        }



        public List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgListeUtilisateursRecherche(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> clsReqcompteutilisateurDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqcompteutilisateurWSBLL.pvgChargerDansDataSetRechercheUtilisateur(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                                clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqcompteutilisateurDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                clsReqcompteutilisateurDTOR.TU_CODETYPEUTILISATEUR = DataRow["TU_CODETYPEUTILISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.CU_NUMEROUTILISATEUR = DataRow["CU_NUMEROUTILISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = DataRow["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                                clsReqcompteutilisateurDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();
                                clsReqcompteutilisateurDTOR.CU_LOGIN = DataRow["CU_LOGIN"].ToString();
                                clsReqcompteutilisateurDTOR.CU_MOTDEPASSE = DataRow["CU_MOTDEPASSE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_DATECREATION = clsDate.ClasseDate.pvgFormaterDate(DataRow["CU_DATECREATION"].ToString()); // DataRow["CU_DATECREATION"].ToString();
                                clsReqcompteutilisateurDTOR.CU_DATECLOTURE = clsDate.ClasseDate.pvgFormaterDate(DataRow["CU_DATECLOTURE"].ToString()); //DataRow["CU_DATECLOTURE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_TOKEN = DataRow["CU_TOKEN"].ToString();
                                clsReqcompteutilisateurDTOR.PI_CODEPIECE = DataRow["PI_CODEPIECE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_NUMEROPIECE = DataRow["CU_NUMEROPIECE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_DATEPIECE = DataRow["CU_DATEPIECE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_NOMBRECONNECTION = DataRow["CU_NOMBRECONNECTION"].ToString();
                                clsReqcompteutilisateurDTOR.CU_CLESESSION = DataRow["CU_CLESESSION"].ToString();
                                clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                            clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqcompteutilisateurDTOs;

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgListeUtilisateursCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> clsReqcompteutilisateurDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur>();

           // string a = MgRequeteClients.WSTOOLS.clsChaineCaractere.ClasseChaineCaractere.pvgCrypter("Data Source=localhost;Initial Catalog=dbMgRequeteClients;;User ID=bestMan;Password=ABC123@xy8");


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqcompteutilisateurWSBLL.pvgChargerDansDataSetPourCombo(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                                clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqcompteutilisateurDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                            clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqcompteutilisateurDTOs;

        }



        public List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgLogin(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> clsReqcompteutilisateurDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqcompteutilisateurWSBLL.pvgLogin(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                                clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqcompteutilisateurDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                clsReqcompteutilisateurDTOR.TU_CODETYPEUTILISATEUR = DataRow["TU_CODETYPEUTILISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.CU_NUMEROUTILISATEUR = DataRow["CU_NUMEROUTILISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = DataRow["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                                clsReqcompteutilisateurDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                                clsReqcompteutilisateurDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();
                                clsReqcompteutilisateurDTOR.CU_LOGIN = DataRow["CU_LOGIN"].ToString();
                                clsReqcompteutilisateurDTOR.CU_MOTDEPASSE = DataRow["CU_MOTDEPASSE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_DATECREATION = clsDate.ClasseDate.pvgFormaterDate(DataRow["CU_DATECREATION"].ToString());
                                clsReqcompteutilisateurDTOR.CU_DATECLOTURE = clsDate.ClasseDate.pvgFormaterDate(DataRow["CU_DATECLOTURE"].ToString());
                                clsReqcompteutilisateurDTOR.CU_TOKEN = DataRow["CU_TOKEN"].ToString();
                                clsReqcompteutilisateurDTOR.PI_CODEPIECE = DataRow["PI_CODEPIECE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_NUMEROPIECE = DataRow["CU_NUMEROPIECE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_NOMBRECONNECTION = DataRow["CU_NOMBRECONNECTION"].ToString();
                                clsReqcompteutilisateurDTOR.CU_DATEPIECE = clsDate.ClasseDate.pvgFormaterDate(DataRow["CU_DATEPIECE"].ToString());

                                clsReqcompteutilisateurDTOR.JT_DATEJOURNEETRAVAIL = clsDate.ClasseDate.pvgFormaterDate(DataRow["JT_DATEJOURNEETRAVAIL"].ToString());
                                clsReqcompteutilisateurDTOR.EX_DATEDEBUTPREMIEREXERCIE = clsDate.ClasseDate.pvgFormaterDate(DataRow["EX_DATEDEBUTPREMIEREXERCIE"].ToString());
                                clsReqcompteutilisateurDTOR.EX_EXERCICE = DataRow["EX_EXERCICE"].ToString();
                                clsReqcompteutilisateurDTOR.EX_DATEDEBUT = clsDate.ClasseDate.pvgFormaterDate(DataRow["EX_DATEDEBUT"].ToString());
                                clsReqcompteutilisateurDTOR.EX_DATEFIN = clsDate.ClasseDate.pvgFormaterDate(DataRow["EX_DATEFIN"].ToString());
                                clsReqcompteutilisateurDTOR.EX_ETATEXERCICE = DataRow["EX_ETATEXERCICE"].ToString();
                                clsReqcompteutilisateurDTOR.EX_DATEDEBUTBILAN = clsDate.ClasseDate.pvgFormaterDate(DataRow["EX_DATEDEBUTBILAN"].ToString());

                                clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                            clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_LOGIN_OU_MOT_DE_PASSE_INVALIDE;
                            clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqcompteutilisateurDTOs;

        }


        public List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgUpdateFirstconnexion(string TU_CODETYPEUTILISATEUR, string CU_MOTDEPASSEOLD, string CU_LOGINOLD, string CU_MOTDEPASSENEW, string CU_LOGINNEW)
        {

            string CU_CLESESSION = ".";
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> clsReqcompteutilisateurDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;


            if (string.IsNullOrEmpty(TU_CODETYPEUTILISATEUR))
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //----EXEPTION
                clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TU_CODETYPEUTILISATEUR";
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                return clsReqcompteutilisateurDTOs;
            }

            if (string.IsNullOrEmpty(CU_MOTDEPASSEOLD))
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //----EXEPTION
                clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_MOTDEPASSEOLD";
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                return clsReqcompteutilisateurDTOs;
            }

            if (string.IsNullOrEmpty(CU_LOGINOLD))
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //----EXEPTION
                clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_LOGINOLD";
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                return clsReqcompteutilisateurDTOs;
            }
            if (string.IsNullOrEmpty(CU_MOTDEPASSENEW))
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //----EXEPTION
                clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_MOTDEPASSENEW";
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                return clsReqcompteutilisateurDTOs;
            }
            if (string.IsNullOrEmpty(CU_LOGINNEW))
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //----EXEPTION
                clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_LOGINNEW";
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                return clsReqcompteutilisateurDTOs;
            }
            if (string.IsNullOrEmpty(CU_CLESESSION))
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //----EXEPTION
                clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_CLESESSION";
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                return clsReqcompteutilisateurDTOs;
            }
            //string TU_CODETYPEUTILISATEUR, string CU_MOTDEPASSEOLD, string CU_LOGINOLD, string CU_MOTDEPASSENEW, string CU_LOGINNEW, string CU_CLESESSION

            try
            {

                _clsDonnee.pvgDemarrerTransaction();

                clsObjetEnvoi = new clsObjetEnvoi();
                clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                //===


                clsObjetEnvoi.OE_PARAM = new string[] { TU_CODETYPEUTILISATEUR, CU_MOTDEPASSEOLD, CU_LOGINOLD, CU_MOTDEPASSENEW, CU_LOGINNEW, CU_CLESESSION };

                //====
                clsReqcompteutilisateurDTOs = clsReqcompteutilisateurWSBLL.pvgUpdateFirstconnexion(_clsDonnee, clsObjetEnvoi);

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqcompteutilisateurDTOs;

        }

        


        #region Reqrequete
        public MgRequeteClients.DTO.BusinessObjects.clsReqrequete pvgMajReqrequete(List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequete in Objets)
            {
                if (clsReqrequete.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequete.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequete.RQ_CODEREQUETE) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "2" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "4"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_CODEREQUETE";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }


                if (string.IsNullOrEmpty(clsReqrequete.TR_CODETYEREQUETE) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TR_CODETYEREQUETE";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequete.RQ_NUMEROREQUETE) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_NUMEROREQUETE";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequete.RQ_NUMERORECOMPTE) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_NUMERORECOMPTE";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequete.CU_CODECOMPTEUTULISATEUR) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_CODECOMPTEUTULISATEUR";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequete.RQ_DESCRIPTIONREQUETE) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DESCRIPTIONREQUETE";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequete.MC_CODEMODECOLLETE) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " MC_CODEMODECOLLETE";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequete.RQ_DATESAISIEREQUETE) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DATESAISIEREQUETE";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequete.RQ_DATETRANSFERTREQUETE) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DATETRANSFERTREQUETE";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequete.RQ_OBJETREQUETE) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_OBJETREQUETE";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequete.RQ_DATEDEBUTTRAITEMENTREQUETE) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DATEDEBUTTRAITEMENTREQUETE";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequete.RQ_DATEFINTRAITEMENTREQUETE) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DATEFINTRAITEMENTREQUETE";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequete.RQ_DATECLOTUREREQUETE) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DATECLOTUREREQUETE";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequete.RQ_AFFICHERINFOCLIENT) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11" || clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_AFFICHERINFOCLIENT";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequete.RQ_AFFICHERINFOCLIENT) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "4"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_AFFICHERINFOCLIENT";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs[0];
                }
            }

            try
            {
                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
                    //===
                    MgRequeteClients.BOJ.BusinessObjects.clsReqrequete clsReqrequeteBOJ = new clsReqrequete();
                    clsReqrequeteBOJ.RQ_CODEREQUETE = clsReqrequeteDTO.RQ_CODEREQUETE;
                    clsReqrequeteBOJ.TR_CODETYEREQUETE = clsReqrequeteDTO.TR_CODETYEREQUETE;
                    clsReqrequeteBOJ.RQ_NUMEROREQUETE = clsReqrequeteDTO.RQ_NUMEROREQUETE;
                    clsReqrequeteBOJ.RQ_NUMERORECOMPTE = clsReqrequeteDTO.RQ_NUMERORECOMPTE;
                    clsReqrequeteBOJ.CU_CODECOMPTEUTULISATEUR = clsReqrequeteDTO.CU_CODECOMPTEUTULISATEUR;
                    clsReqrequeteBOJ.RQ_LOCALISATIONCLIENT = clsReqrequeteDTO.RQ_LOCALISATIONCLIENT;
                    clsReqrequeteBOJ.RQ_DESCRIPTIONREQUETE = clsReqrequeteDTO.RQ_DESCRIPTIONREQUETE;
                    clsReqrequeteBOJ.MC_CODEMODECOLLETE = clsReqrequeteDTO.MC_CODEMODECOLLETE;
                    clsReqrequeteBOJ.RQ_DATESAISIEREQUETE = DateTime.Parse(clsReqrequeteDTO.RQ_DATESAISIEREQUETE);
                    clsReqrequeteBOJ.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = clsReqrequeteDTO.CU_CODECOMPTEUTULISATEURAGENTENCHARGE;
                    clsReqrequeteBOJ.RQ_DATETRANSFERTREQUETE = DateTime.Parse(clsReqrequeteDTO.RQ_DATETRANSFERTREQUETE);
                    clsReqrequeteBOJ.RQ_CODEREQUETERELANCEE = clsReqrequeteDTO.RQ_CODEREQUETERELANCEE;
                    Byte[] RQ_SIGNATURE = null;
                    if (clsReqrequeteDTO.RQ_SIGNATURE != "")
                        RQ_SIGNATURE = System.Convert.FromBase64String(clsReqrequeteDTO.RQ_SIGNATURE);
                    clsReqrequeteBOJ.RQ_SIGNATURE = RQ_SIGNATURE;
                    clsReqrequeteBOJ.RS_CODESTATUTRECEVABILITE = clsReqrequeteDTO.RS_CODESTATUTRECEVABILITE;
                    clsReqrequeteBOJ.RQ_OBJETREQUETE = clsReqrequeteDTO.RQ_OBJETREQUETE;
                    clsReqrequeteBOJ.SR_CODESERVICE = clsReqrequeteDTO.SR_CODESERVICE;
                    clsReqrequeteBOJ.RQ_DELAITRAITEMENTREQUETE = clsReqrequeteDTO.RQ_DELAITRAITEMENTREQUETE;
                    clsReqrequeteBOJ.RQ_OBSERVATIONDELAITRAITEMENTREQUETE = clsReqrequeteDTO.RQ_OBSERVATIONDELAITRAITEMENTREQUETE;
                    clsReqrequeteBOJ.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = clsReqrequeteDTO.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE;
                    clsReqrequeteBOJ.RQ_DUREETRAITEMENTREQUETE = clsReqrequeteDTO.RQ_DUREETRAITEMENTREQUETE;
                    clsReqrequeteBOJ.RQ_DATEDEBUTTRAITEMENTREQUETE = DateTime.Parse(clsReqrequeteDTO.RQ_DATEDEBUTTRAITEMENTREQUETE);
                    clsReqrequeteBOJ.RQ_DATEFINTRAITEMENTREQUETE = DateTime.Parse(clsReqrequeteDTO.RQ_DATEFINTRAITEMENTREQUETE);
                    clsReqrequeteBOJ.AC_CODEACTIONCORRECTIVE = clsReqrequeteDTO.AC_CODEACTIONCORRECTIVE;
                    clsReqrequeteBOJ.NS_CODENIVEAUSATISFACTION = clsReqrequeteDTO.NS_CODENIVEAUSATISFACTION;
                    clsReqrequeteBOJ.RQ_DATECLOTUREREQUETE = DateTime.Parse(clsReqrequeteDTO.RQ_DATECLOTUREREQUETE);
                    clsReqrequeteBOJ.RT_CODETYPERELANCE = clsReqrequeteDTO.RT_CODETYPERELANCE;

                    clsReqrequeteBOJ.TYPEOPERATION = clsReqrequeteDTO.clsObjetEnvoi.TYPEOPERATION;

                    clsReqrequeteBOJ.RQ_NOMRAPPORT = clsReqrequeteDTO.RQ_NOMRAPPORT;

                    if (clsReqrequeteBOJ.TYPEOPERATION == "0")
                    {
                        clsReqrequeteBOJ.CU_CODECOMPTEUTULISATEURASSOCIER = clsReqrequeteDTO.CU_CODECOMPTEUTULISATEURASSOCIER;
                    }
                    else
                    {
                        clsReqrequeteBOJ.CU_CODECOMPTEUTULISATEURASSOCIER = "";
                    }

                    clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgMiseajour(_clsDonnee, clsReqrequeteBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        clsParams clsParams = new clsParams();
                        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();

                        if (clsReqrequeteBOJ.TYPEOPERATION == "0" || clsReqrequeteBOJ.TYPEOPERATION == "5" || clsReqrequeteBOJ.TYPEOPERATION == "8")
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                            string AG_CODEAGENCE = "";
                            string SM_TELEPHONE = "";
                            string SMSTEXT = "";
                            DateTime SM_DATEPIECE = clsReqrequeteBOJ.RQ_DATESAISIEREQUETE;
                            string TYPEOPERATION = "";
                            string SL_LIBELLE1 = "";
                            string SL_LIBELLE2 = "";
                            string TE_CODESMSTYPEOPERATION = "";
                            string CU_CODECOMPTEUTULISATEUR = "";

                            clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                            clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
                            clsObjetEnvoi.OE_PARAM = new string[] { clsReqrequeteBOJ.CU_CODECOMPTEUTULISATEUR }; ;
                            clsReqcompteutilisateur = clsReqcompteutilisateurWSBLL.pvgTableLibelle(_clsDonnee, clsObjetEnvoi);

                            if (clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR != "")
                            {
                                AG_CODEAGENCE = clsReqcompteutilisateur.AG_CODEAGENCE; // ;
                                SM_TELEPHONE = clsReqcompteutilisateur.CU_CONTACT;
                                SMSTEXT = "Vous avez une nouvelle requette à traiter !!!";
                                SM_DATEPIECE = clsReqrequeteBOJ.RQ_DATESAISIEREQUETE;
                                TYPEOPERATION = "0";
                                SL_LIBELLE1 = "5";
                                SL_LIBELLE2 = "";
                                if (clsReqrequeteBOJ.TYPEOPERATION == "8")
                                {
                                    TE_CODESMSTYPEOPERATION = "0012";
                                }
                                else
                                {
                                    TE_CODESMSTYPEOPERATION = "0011";
                                }

                                CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;

                                //if (SM_TELEPHONE.Length == 10)
                                //    SM_TELEPHONE = "225" + SM_TELEPHONE;

                                //public clsParams pvgTraitementSmsSimple1(_clsDonnee clsDonnee, string AG_CODEAGENCE, string SM_TELEPHONE, string SMSTEXT, DateTime SM_DATEPIECE, string TYPEOPERATION, string TE_CODESMSTYPEOPERATION, string CU_CODECOMPTEUTULISATEUR, string SL_LIBELLE1, string SL_LIBELLE2)
                                clsParams = clsSmsoutWSBLL.pvgTraitementSmsSimple1(_clsDonnee, AG_CODEAGENCE, SM_TELEPHONE, SMSTEXT, SM_DATEPIECE, TYPEOPERATION, TE_CODESMSTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, SL_LIBELLE1, SL_LIBELLE2);

                            }

                        }

                        if (clsReqrequeteBOJ.TYPEOPERATION == "0" || clsReqrequeteBOJ.TYPEOPERATION == "5" || clsReqrequeteBOJ.TYPEOPERATION == "8")
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                            string AG_CODEAGENCE = "";
                            string SM_TELEPHONE = "";
                            string SMSTEXT = "";
                            DateTime SM_DATEPIECE = clsReqrequeteBOJ.RQ_DATESAISIEREQUETE;
                            string TYPEOPERATION = "";
                            string SL_LIBELLE1 = "";
                            string SL_LIBELLE2 = "";
                            string TE_CODESMSTYPEOPERATION = "";
                            string CU_CODECOMPTEUTULISATEUR = "";

                            clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                            clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
                            clsObjetEnvoi.OE_PARAM = new string[] { clsReqrequeteBOJ.CU_CODECOMPTEUTULISATEUR }; ;
                            clsReqcompteutilisateur = clsReqcompteutilisateurWSBLL.pvgTableLibelle(_clsDonnee, clsObjetEnvoi);

                            if (clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR != "")
                            {
                                AG_CODEAGENCE = clsReqcompteutilisateur.AG_CODEAGENCE; // ;
                                SM_TELEPHONE = clsReqcompteutilisateur.CU_CONTACT;
                                SMSTEXT = "Vous avez une nouvelle requette à traiter !!!";
                                SM_DATEPIECE = clsReqrequeteBOJ.RQ_DATESAISIEREQUETE;
                                TYPEOPERATION = "0";
                                SL_LIBELLE1 = "";
                                SL_LIBELLE2 = "";
                                if (clsReqrequeteBOJ.TYPEOPERATION == "8")
                                {
                                    TE_CODESMSTYPEOPERATION = "0007";
                                }
                                else
                                {
                                    TE_CODESMSTYPEOPERATION = "0002";
                                }

                                CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;

                                //if (SM_TELEPHONE.Length == 10)
                                //    SM_TELEPHONE = "225" + SM_TELEPHONE;

                                //public clsParams pvgTraitementSmsSimple1(_clsDonnee clsDonnee, string AG_CODEAGENCE, string SM_TELEPHONE, string SMSTEXT, DateTime SM_DATEPIECE, string TYPEOPERATION, string TE_CODESMSTYPEOPERATION, string CU_CODECOMPTEUTULISATEUR, string SL_LIBELLE1, string SL_LIBELLE2)
                                clsParams = clsSmsoutWSBLL.pvgTraitementSmsSimple1(_clsDonnee, AG_CODEAGENCE, SM_TELEPHONE, SMSTEXT, SM_DATEPIECE, TYPEOPERATION, TE_CODESMSTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, SL_LIBELLE1, SL_LIBELLE2);

                            }
                        }

                        if (clsReqrequeteBOJ.TYPEOPERATION == "6")
                        {

                            MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                            string AG_CODEAGENCE = "";
                            string SM_TELEPHONE = "";
                            string SMSTEXT = "";
                            DateTime SM_DATEPIECE = clsReqrequeteBOJ.RQ_DATESAISIEREQUETE;
                            string TYPEOPERATION = "";
                            string SL_LIBELLE1 = "";
                            string SL_LIBELLE2 = "";
                            string TE_CODESMSTYPEOPERATION = "";
                            string CU_CODECOMPTEUTULISATEUR = "";


                            clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                            clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
                            clsObjetEnvoi.OE_PARAM = new string[] { clsReqrequeteBOJ.CU_CODECOMPTEUTULISATEUR }; ;
                            clsReqcompteutilisateur = clsReqcompteutilisateurWSBLL.pvgTableLibelle(_clsDonnee, clsObjetEnvoi);

                            if (clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR != "")
                            {
                                AG_CODEAGENCE = clsReqcompteutilisateur.AG_CODEAGENCE; // ;
                                SM_TELEPHONE = clsReqcompteutilisateur.CU_CONTACT;
                                SMSTEXT = "Vous avez une nouvelle requette à traiter !!!";
                                SM_DATEPIECE = clsReqrequeteBOJ.RQ_DATESAISIEREQUETE;
                                TYPEOPERATION = "0";
                                SL_LIBELLE1 = "";
                                SL_LIBELLE2 = "";
                                TE_CODESMSTYPEOPERATION = "0004";
                                CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;

                                //if (SM_TELEPHONE.Length == 10)
                                //    SM_TELEPHONE = "225" + SM_TELEPHONE;

                                //public clsParams pvgTraitementSmsSimple1(_clsDonnee clsDonnee, string AG_CODEAGENCE, string SM_TELEPHONE, string SMSTEXT, DateTime SM_DATEPIECE, string TYPEOPERATION, string TE_CODESMSTYPEOPERATION, string CU_CODECOMPTEUTULISATEUR, string SL_LIBELLE1, string SL_LIBELLE2)
                                clsParams = clsSmsoutWSBLL.pvgTraitementSmsSimple1(_clsDonnee, AG_CODEAGENCE, SM_TELEPHONE, SMSTEXT, SM_DATEPIECE, TYPEOPERATION, TE_CODESMSTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, SL_LIBELLE1, SL_LIBELLE2);

                            }
                        }

                        if (clsReqrequeteBOJ.TYPEOPERATION == "7")
                        {

                            MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                            string AG_CODEAGENCE = "";
                            string SM_TELEPHONE = "";
                            string SMSTEXT = "";
                            DateTime SM_DATEPIECE = clsReqrequeteBOJ.RQ_DATESAISIEREQUETE;
                            string TYPEOPERATION = "";
                            string SL_LIBELLE1 = "";
                            string SL_LIBELLE2 = "";
                            string TE_CODESMSTYPEOPERATION = "";
                            string CU_CODECOMPTEUTULISATEUR = "";


                            clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                            clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
                            clsObjetEnvoi.OE_PARAM = new string[] { clsReqrequeteBOJ.CU_CODECOMPTEUTULISATEUR }; ;
                            clsReqcompteutilisateur = clsReqcompteutilisateurWSBLL.pvgTableLibelle(_clsDonnee, clsObjetEnvoi);

                            if (clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR != "")
                            {
                                AG_CODEAGENCE = clsReqcompteutilisateur.AG_CODEAGENCE; // ;
                                SM_TELEPHONE = clsReqcompteutilisateur.CU_CONTACT;
                                SMSTEXT = "Vous avez une nouvelle requette à traiter !!!";
                                SM_DATEPIECE = clsReqrequeteBOJ.RQ_DATESAISIEREQUETE;
                                TYPEOPERATION = "0";
                                SL_LIBELLE1 = "";
                                SL_LIBELLE2 = clsReqrequeteBOJ.RQ_CODEREQUETE;
                                TE_CODESMSTYPEOPERATION = "0006";
                                CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;

                                //if (SM_TELEPHONE.Length == 10)
                                //    SM_TELEPHONE = "225" + SM_TELEPHONE;

                                //public clsParams pvgTraitementSmsSimple1(_clsDonnee clsDonnee, string AG_CODEAGENCE, string SM_TELEPHONE, string SMSTEXT, DateTime SM_DATEPIECE, string TYPEOPERATION, string TE_CODESMSTYPEOPERATION, string CU_CODECOMPTEUTULISATEUR, string SL_LIBELLE1, string SL_LIBELLE2)
                                clsParams = clsSmsoutWSBLL.pvgTraitementSmsSimple1(_clsDonnee, AG_CODEAGENCE, SM_TELEPHONE, SMSTEXT, SM_DATEPIECE, TYPEOPERATION, TE_CODESMSTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, SL_LIBELLE1, SL_LIBELLE2);

                            }
                        }


                        if (clsReqrequeteBOJ.TYPEOPERATION == "0" || clsReqrequeteBOJ.TYPEOPERATION == "5" || clsReqrequeteBOJ.TYPEOPERATION == "6" || clsReqrequeteBOJ.TYPEOPERATION == "7")
                        {
                            clsObjetEnvoi = new clsObjetEnvoi();
                            clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                            //===
                            clsObjetEnvoi.OE_PARAM = new string[] { "0002", clsReqrequeteBOJ.CU_CODECOMPTEUTULISATEUR, "", "", "02" };
                            MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                            //====
                            clsObjetRetour.SetValue(true, clsReqcompteutilisateurWSBLL.pvgChargerDansDataSetRechercheUtilisateur(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                            if (clsObjetRetour.OR_BOOLEEN)
                            {
                                if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                                    {

                                        clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                        clsReqcompteutilisateurDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                        clsReqcompteutilisateurDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                        clsReqcompteutilisateurDTOR.TU_CODETYPEUTILISATEUR = DataRow["TU_CODETYPEUTILISATEUR"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_NUMEROUTILISATEUR = DataRow["CU_NUMEROUTILISATEUR"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = DataRow["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_LOGIN = DataRow["CU_LOGIN"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_MOTDEPASSE = DataRow["CU_MOTDEPASSE"].ToString();

                                    }
                                }
                            }

                            // Envoi Email 
                            if (clsReqcompteutilisateurDTOR.CU_EMAIL != "")
                            {
                                string AG_EMAIL = "";
                                string AG_EMAILMOTDEPASSE = "";
                                string AG_RAISONSOCIAL = "";
                                clsReqniveausatisfactionWSBLL clsReqniveausatisfactionWSBLL = new clsReqniveausatisfactionWSBLL();
                                DataSet DataSet = new DataSet();
                                clsObjetEnvoi.OE_PARAM = new string[] { clsReqcompteutilisateurDTOR.AG_CODEAGENCE };
                                DataSet = clsReqniveausatisfactionWSBLL.pvgChargerDansDataSetAgence(_clsDonnee, clsObjetEnvoi);
                                foreach (DataRow row in DataSet.Tables[0].Rows)
                                {
                                    AG_EMAIL = row["AG_EMAIL"].ToString();
                                    AG_EMAILMOTDEPASSE = row["AG_EMAILMOTDEPASSE"].ToString();
                                    AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                                }

                                // Paramètres du serveur SMTP
                                string smtpServeur = "smtp.gmail.com";
                                int portSmtp = 587;
                                string adresseEmail = AG_EMAIL;//"bolatykouassieuloge@gmail.com";
                                string motDePasse = AG_EMAILMOTDEPASSE;//"nffncgqonuuildmc";

                                // Destinataire et contenu de l'e-mail
                                string destinataire = clsReqcompteutilisateurDTOR.CU_EMAIL;// "technicosup@mgdigitalplus.com";
                                string sujet = "Enregistrement de réclamation";
                                string corpsMessage = clsParams.SMSTEXT;// "De la " + AG_RAISONSOCIAL + ", votre requête est prise en compte sous la description : " + clsReqrequeteBOJ.RQ_DESCRIPTIONREQUETE + ",son statut est disponible via le lien http://51.210.111.16:1011 login : " + clsReqcompteutilisateurDTOR.CU_LOGIN + " Mot de passe : " + clsReqcompteutilisateurDTOR.CU_MOTDEPASSE;

                                // Création de l'objet MailMessage
                                MailMessage message = new MailMessage(adresseEmail, destinataire, sujet, corpsMessage);

                                // Création de l'objet SmtpClient
                                SmtpClient clientSmtp = new SmtpClient(smtpServeur, portSmtp);
                                clientSmtp.UseDefaultCredentials = false;
                                clientSmtp.Credentials = new NetworkCredential(adresseEmail, motDePasse);
                                clientSmtp.EnableSsl = true;

                                // Envoi de l'e-mail
                                clientSmtp.Send(message);

                            }
                        }


                        MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTOR.RQ_CODEREQUETE = clsReqrequeteBOJ.RQ_CODEREQUETE == "" ? clsObjetRetour.OR_STRING : clsReqrequeteBOJ.RQ_CODEREQUETE;
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                        clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteDTOs[0];

        }
        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgListeReqrequeteRelance(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSetRelance(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                                clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteDTOR.NR_CODENATUREREQUETE = DataRow["NR_CODENATUREREQUETE"].ToString();
                                clsReqrequeteDTOR.NR_LIBELLENATUREREQUETE = DataRow["NR_LIBELLENATUREREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_CODEREQUETE = DataRow["RQ_CODEREQUETE"].ToString();
                                clsReqrequeteDTOR.TR_CODETYEREQUETE = DataRow["TR_CODETYEREQUETE"].ToString();
                                clsReqrequeteDTOR.TR_LIBELLETYEREQUETE = DataRow["TR_LIBELLETYEREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_NUMEROREQUETE = DataRow["RQ_NUMEROREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_NUMERORECOMPTE = DataRow["RQ_NUMERORECOMPTE"].ToString();
                                clsReqrequeteDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                clsReqrequeteDTOR.RQ_LOCALISATIONCLIENT = DataRow["RQ_LOCALISATIONCLIENT"].ToString();
                                clsReqrequeteDTOR.RQ_DESCRIPTIONREQUETE = DataRow["RQ_DESCRIPTIONREQUETE"].ToString();
                                clsReqrequeteDTOR.MC_CODEMODECOLLETE = DataRow["MC_CODEMODECOLLETE"].ToString();
                                clsReqrequeteDTOR.RQ_DATESAISIEREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATESAISIEREQUETE"].ToString()); //  DataRow["RQ_DATESAISIEREQUETE"].ToString();
                                clsReqrequeteDTOR.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = DataRow["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
                                clsReqrequeteDTOR.RQ_DATETRANSFERTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATETRANSFERTREQUETE"].ToString()); //  DataRow["RQ_DATETRANSFERTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_CODEREQUETERELANCEE = DataRow["RQ_CODEREQUETERELANCEE"].ToString();
                                clsReqrequeteDTOR.RQ_SIGNATURE = DataRow["RQ_SIGNATURE"].ToString();
                                clsReqrequeteDTOR.RS_CODESTATUTRECEVABILITE = DataRow["RS_CODESTATUTRECEVABILITE"].ToString();
                                clsReqrequeteDTOR.RQ_OBJETREQUETE = DataRow["RQ_OBJETREQUETE"].ToString();
                                clsReqrequeteDTOR.SR_CODESERVICE = DataRow["SR_CODESERVICE"].ToString();
                                clsReqrequeteDTOR.RQ_DELAITRAITEMENTREQUETE = DataRow["RQ_DELAITRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_OBSERVATIONDELAITRAITEMENTREQUETE = DataRow["RQ_OBSERVATIONDELAITRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = DataRow["RQ_OBSERVATIONAGENTTRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_DUREETRAITEMENTREQUETE = DataRow["RQ_DUREETRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_DATEDEBUTTRAITEMENTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATEDEBUTTRAITEMENTREQUETE"].ToString()); // DataRow["RQ_DATEDEBUTTRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_DATEFINTRAITEMENTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATEFINTRAITEMENTREQUETE"].ToString()); // DataRow["RQ_DATEFINTRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.AC_CODEACTIONCORRECTIVE = DataRow["AC_CODEACTIONCORRECTIVE"].ToString();
                                clsReqrequeteDTOR.NS_CODENIVEAUSATISFACTION = DataRow["NS_CODENIVEAUSATISFACTION"].ToString();
                                clsReqrequeteDTOR.RQ_AFFICHERINFOCLIENT = DataRow["RQ_AFFICHERINFOCLIENT"].ToString();


                                clsReqrequeteDTOR.CU_NUMEROUTILISATEUR = "";
                                clsReqrequeteDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = "";
                                clsReqrequeteDTOR.CU_NOMUTILISATEUR = "";
                                clsReqrequeteDTOR.CU_CONTACT = "";
                                clsReqrequeteDTOR.CU_EMAIL = "";

                                clsReqrequeteDTOR.RQ_DATECLOTUREREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATECLOTUREREQUETE"].ToString()); // DataRow["RQ_DATECLOTUREREQUETE"].ToString();
                                clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteDTOs;

        }
        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgChargerDansDataSetParOperateurs(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSetParOperateurs(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                                clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteDTOR.NR_CODENATUREREQUETE = DataRow["NR_CODENATUREREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_CODEREQUETE = DataRow["RQ_CODEREQUETE"].ToString();
                                clsReqrequeteDTOR.TR_CODETYEREQUETE = DataRow["TR_CODETYEREQUETE"].ToString();
                                clsReqrequeteDTOR.TR_LIBELLETYEREQUETE = DataRow["TR_LIBELLETYEREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_NUMEROREQUETE = DataRow["RQ_NUMEROREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_NUMERORECOMPTE = DataRow["RQ_NUMERORECOMPTE"].ToString();
                                clsReqrequeteDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                clsReqrequeteDTOR.RQ_LOCALISATIONCLIENT = DataRow["RQ_LOCALISATIONCLIENT"].ToString();
                                clsReqrequeteDTOR.RQ_DESCRIPTIONREQUETE = DataRow["RQ_DESCRIPTIONREQUETE"].ToString();
                                clsReqrequeteDTOR.MC_CODEMODECOLLETE = DataRow["MC_CODEMODECOLLETE"].ToString();
                                clsReqrequeteDTOR.RQ_DATESAISIEREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATESAISIEREQUETE"].ToString()); //  DataRow["RQ_DATESAISIEREQUETE"].ToString();
                                clsReqrequeteDTOR.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = DataRow["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
                                clsReqrequeteDTOR.RQ_DATETRANSFERTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATETRANSFERTREQUETE"].ToString()); //  DataRow["RQ_DATETRANSFERTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_CODEREQUETERELANCEE = DataRow["RQ_CODEREQUETERELANCEE"].ToString();
                                clsReqrequeteDTOR.RQ_SIGNATURE = DataRow["RQ_SIGNATURE"].ToString();
                                clsReqrequeteDTOR.RS_CODESTATUTRECEVABILITE = DataRow["RS_CODESTATUTRECEVABILITE"].ToString();
                                clsReqrequeteDTOR.RQ_OBJETREQUETE = DataRow["RQ_OBJETREQUETE"].ToString();
                                clsReqrequeteDTOR.SR_CODESERVICE = DataRow["SR_CODESERVICE"].ToString();
                                clsReqrequeteDTOR.RQ_DELAITRAITEMENTREQUETE = DataRow["RQ_DELAITRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_OBSERVATIONDELAITRAITEMENTREQUETE = DataRow["RQ_OBSERVATIONDELAITRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = DataRow["RQ_OBSERVATIONAGENTTRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_DUREETRAITEMENTREQUETE = DataRow["RQ_DUREETRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_DATEDEBUTTRAITEMENTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATEDEBUTTRAITEMENTREQUETE"].ToString()); // DataRow["RQ_DATEDEBUTTRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_DATEFINTRAITEMENTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATEFINTRAITEMENTREQUETE"].ToString()); // DataRow["RQ_DATEFINTRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.AC_CODEACTIONCORRECTIVE = DataRow["AC_CODEACTIONCORRECTIVE"].ToString();
                                clsReqrequeteDTOR.NS_CODENIVEAUSATISFACTION = DataRow["NS_CODENIVEAUSATISFACTION"].ToString();
                                clsReqrequeteDTOR.RE_CODEETAPE = DataRow["RE_CODEETAPE"].ToString();
                                clsReqrequeteDTOR.RE_LIBELLEETAPE = DataRow["RE_LIBELLEETAPE"].ToString();
                                clsReqrequeteDTOR.RQ_AFFICHERINFOCLIENT = DataRow["RQ_AFFICHERINFOCLIENT"].ToString();
                                clsReqrequeteDTOR.AT_INDEXETAPE = DataRow["AT_INDEXETAPE"].ToString();

                                clsReqrequeteDTOR.RQ_NOMRAPPORT = DataRow["RQ_NOMRAPPORT"].ToString();
                                clsReqrequeteDTOR.RQ_LIENRAPPORT = _configuration.GetSection("ApiEndpoints:URL_ROOT_DOSSIER").Value ?? string.Empty;//ConfigurationManager.AppSettings["URL_ROOT_DOSSIER"];

                                clsReqrequeteDTOR.AT_DATECLOTUREETAPE = ((DateTime)DataRow["AT_DATECLOTUREETAPE"]).ToShortDateString(); //DataRow["AT_DATECLOTUREETAPE"].ToShortd();
                                clsReqrequeteDTOR.AT_DATEDEBUTTRAITEMENTETAPE = ((DateTime)DataRow["AT_DATEDEBUTTRAITEMENTETAPE"]).ToShortDateString();// DataRow["AT_DATEDEBUTTRAITEMENTETAPE"].ToString();
                                clsReqrequeteDTOR.AT_DATEFINTRAITEMENTETAPE = ((DateTime)DataRow["AT_DATEFINTRAITEMENTETAPE"]).ToShortDateString();// DataRow["AT_DATEFINTRAITEMENTETAPE"].ToString();
                                if (clsReqrequeteDTOR.RQ_AFFICHERINFOCLIENT == "O")
                                {
                                    clsReqrequeteDTOR.CU_NUMEROUTILISATEUR = DataRow["CU_NUMEROUTILISATEUR"].ToString();
                                    clsReqrequeteDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = DataRow["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                                    clsReqrequeteDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                                    clsReqrequeteDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                                    clsReqrequeteDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();
                                }
                                else
                                {
                                    clsReqrequeteDTOR.CU_NUMEROUTILISATEUR = "";
                                    clsReqrequeteDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = "";
                                    clsReqrequeteDTOR.CU_NOMUTILISATEUR = "";
                                    clsReqrequeteDTOR.CU_CONTACT = "";
                                    clsReqrequeteDTOR.CU_EMAIL = "";
                                }



                                //private string _CU_NUMEROUTILISATEUR = "";
                                //private string _CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = "";
                                //private string _CU_NOMUTILISATEUR = "";
                                //private string _CU_CONTACT = "";
                                //private string _CU_EMAIL = "";
                                //private string _RQ_AFFICHERINFOCLIENT = "";

                                clsReqrequeteDTOR.RQ_DATECLOTUREREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATECLOTUREREQUETE"].ToString()); // DataRow["RQ_DATECLOTUREREQUETE"].ToString();
                                clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteDTOs;

        }


        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgChargerDansDataSetParOperateursNotif(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;

            if (Objets[0].clsObjetEnvoi != null)
            {
                _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            }

            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();
            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            if (Objets[0].clsObjetEnvoi != null)
            {
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        //----EXEPTION
                        clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                        clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                        clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                        return clsReqrequeteDTOs;
                    }
                    if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        //----EXEPTION
                        clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                        clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                        clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                        return clsReqrequeteDTOs;
                    }
                }
            }

            try
            {
                if (Objets[0].clsObjetEnvoi != null)
                {
                    _clsDonnee.pvgDemarrerTransaction();
                }

                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
                    //===
                    if (Objets[0].clsObjetEnvoi != null)
                    {
                        clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;
                    }
                    else
                    {
                        clsObjetEnvoi.OE_PARAM = new string[] { clsObjetEnvoiListe.RQ_CODEREQUETE };
                    }

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSetParOperateursNotif(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();

                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteDTOR.RQ_CODEREQUETE = DataRow["RQ_CODEREQUETE"].ToString();
                                clsReqrequeteDTOR.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = DataRow["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();

                                clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                                clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
                                clsObjetEnvoi clsObjetEnvoi1 = new clsObjetEnvoi();
                                clsObjetEnvoi1 = new clsObjetEnvoi();
                                string[] stringArray1 = { clsReqrequeteDTOR.CU_CODECOMPTEUTULISATEURAGENTENCHARGE };
                                clsObjetEnvoi1.OE_PARAM = stringArray1;
                                clsReqcompteutilisateur = clsReqcompteutilisateurWSBLL.pvgTableLibelle(_clsDonnee, clsObjetEnvoi1);

                                //if (Objets[0].clsObjetEnvoi != null)
                                //{
                                // envoie des emails
                                // ------------------------------------------------------------ notif email
                                string AG_EMAIL = "";
                                string AG_EMAILMOTDEPASSE = "";
                                string AG_RAISONSOCIAL = "";
                                clsReqniveausatisfactionWSBLL clsReqniveausatisfactionWSBLL = new clsReqniveausatisfactionWSBLL();
                                DataSet DataSet = new DataSet();
                                clsObjetEnvoi.OE_PARAM = new string[] { clsReqcompteutilisateur.AG_CODEAGENCE };
                                DataSet = clsReqniveausatisfactionWSBLL.pvgChargerDansDataSetAgence(_clsDonnee, clsObjetEnvoi);
                                foreach (DataRow row in DataSet.Tables[0].Rows)
                                {
                                    AG_EMAIL = row["AG_EMAIL"].ToString();
                                    AG_EMAILMOTDEPASSE = row["AG_EMAILMOTDEPASSE"].ToString();
                                    AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                                }

                                // Paramètres du serveur SMTP
                                string smtpServeur = "smtp.gmail.com";
                                int portSmtp = 587;
                                string adresseEmail = AG_EMAIL;//"bolatykouassieuloge@gmail.com";
                                string motDePasse = AG_EMAILMOTDEPASSE;//"nffncgqonuuildmc";

                                // Destinataire et contenu de l'e-mail
                                string destinataire = clsReqcompteutilisateur.CU_EMAIL;// "technicosup@mgdigitalplus.com";

                                string sujet = "";
                                string corpsMessage = "";

                                if (Objets[0].clsObjetEnvoi != null)
                                {
                                    sujet = "Clôture de requête";
                                    corpsMessage = "La requête numéro " + clsReqrequeteDTOR.RQ_CODEREQUETE + " est terminée";
                                }
                                else
                                {
                                    sujet = "Tribunal";

                                    if (clsObjetEnvoiListe.TYPEOPERATION == "0")
                                    {
                                        corpsMessage = "De la " + AG_RAISONSOCIAL + ". Votre requête enregistrée sous le numéro de ticket " + clsObjetEnvoiListe.RQ_CODEREQUETE + " a été transmise au tribunal";
                                    }
                                    else
                                    {
                                        corpsMessage = "De la " + AG_RAISONSOCIAL + ". Cloture de la procédure judiciaire lié à votre requête enregistrée sous le numéro de ticket " + clsObjetEnvoiListe.RQ_CODEREQUETE;
                                    }
                                }

                                // Création de l'objet MailMessage
                                MailMessage message = new MailMessage(adresseEmail, destinataire, sujet, corpsMessage);

                                // Création de l'objet SmtpClient
                                SmtpClient clientSmtp = new SmtpClient(smtpServeur, portSmtp);
                                clientSmtp.UseDefaultCredentials = false;
                                clientSmtp.Credentials = new NetworkCredential(adresseEmail, motDePasse);
                                clientSmtp.EnableSsl = true;

                                // Envoi de l'e-mail
                                clientSmtp.Send(message);
                                // ------------------------------------------------------------ notif email
                                //}
                            }

                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                    }
                }
            }
            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            finally
            {
                if (Objets[0].clsObjetEnvoi != null)
                {
                    _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
                }
            }

            return clsReqrequeteDTOs;
        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail> pvgEnvoiEmail(List<MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;

            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            List<MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail> clsEnvoiEmailDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail>();
            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail clsEnvoiEmail in Objets)
            {
                if (clsEnvoiEmail.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail clsEnvoiEmailDTO = new MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail();
                    clsEnvoiEmailDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsEnvoiEmailDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsEnvoiEmailDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsEnvoiEmailDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsEnvoiEmailDTOs.Add(clsEnvoiEmailDTO);
                    return clsEnvoiEmailDTOs;
                }
                if (string.IsNullOrEmpty(clsEnvoiEmail.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail clsEnvoiEmailDTO = new MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail();
                    clsEnvoiEmailDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsEnvoiEmailDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsEnvoiEmailDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsEnvoiEmailDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsEnvoiEmailDTOs.Add(clsEnvoiEmailDTO);
                    return clsEnvoiEmailDTOs;
                }
            }

            try
            {

                _clsDonnee.pvgDemarrerTransaction();

                foreach (MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail clsEnvoiEmail in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();

                    MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail clsEnvoiEmailDTOR = new MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail();

                    // envoie des emails
                    string AG_EMAIL = "";
                    string AG_EMAILMOTDEPASSE = "";
                    string AG_RAISONSOCIAL = "";
                    string AG_EMAIL_RESPO = "";
                    clsReqniveausatisfactionWSBLL clsReqniveausatisfactionWSBLL = new clsReqniveausatisfactionWSBLL();
                    DataSet DataSet = new DataSet();
                    clsObjetEnvoi.OE_PARAM = new string[] { "1000" }; // preciser ici le code de l'agence mere;
                    DataSet = clsReqniveausatisfactionWSBLL.pvgChargerDansDataSetAgence(_clsDonnee, clsObjetEnvoi);
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        AG_EMAIL = row["AG_EMAIL"].ToString();
                        AG_EMAILMOTDEPASSE = row["AG_EMAILMOTDEPASSE"].ToString();
                        AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                        AG_EMAIL_RESPO = row["AG_EMAIL_RESPO"].ToString();
                    }

                    // Paramètres du serveur SMTP
                    string smtpServeur = "smtp.gmail.com";
                    int portSmtp = 587;
                    string adresseEmail = AG_EMAIL;//"bolatykouassieuloge@gmail.com";
                    string motDePasse = AG_EMAILMOTDEPASSE;//"nffncgqonuuildmc";

                    // Destinataire et contenu de l'e-mail
                    string destinataire = AG_EMAIL_RESPO; // "jeanjoblisse@gmail.com"; // preciser l'email de l'agent responsable;
                    string sujet = "Reclamation non client";
                    string corpsMessage = "M./Mme " + clsEnvoiEmail.EE_NOM + " " + clsEnvoiEmail.EE_PRENOMS + " a soumis(e) la requête suivante: " + clsEnvoiEmail.EE_OBSERVATION + ", le " + clsEnvoiEmail.EE_DATEEMISSION + ". Ses coordonnées sont les suivant:\nEmail: " + clsEnvoiEmail.EE_EMAIL + "\nNuméro téléphone: " + clsEnvoiEmail.EE_NUMTELEPHONE + "\nNuméro de compte:" + clsEnvoiEmail.EE_NUMCOMPTE;

                    // Création de l'objet MailMessage
                    MailMessage message = new MailMessage(adresseEmail, destinataire, sujet, corpsMessage);

                    // Création de l'objet SmtpClient
                    SmtpClient clientSmtp = new SmtpClient(smtpServeur, portSmtp);
                    clientSmtp.UseDefaultCredentials = false;
                    clientSmtp.Credentials = new NetworkCredential(adresseEmail, motDePasse);
                    clientSmtp.EnableSsl = true;

                    // Envoi de l'e-mail
                    clientSmtp.Send(message);

                    clsEnvoiEmailDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    clsEnvoiEmailDTOR.clsResultat.SL_CODEMESSAGE = "00";
                    clsEnvoiEmailDTOR.clsResultat.SL_RESULTAT = "TRUE";
                    clsEnvoiEmailDTOR.clsResultat.SL_MESSAGE = "Opération réalisée avec succès !";
                    clsEnvoiEmailDTOs.Add(clsEnvoiEmailDTOR);
                }
            }
            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail clsEnvoiEmailDTO = new MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail();
                clsEnvoiEmailDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsEnvoiEmailDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsEnvoiEmailDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsEnvoiEmailDTOs.Add(clsEnvoiEmailDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail clsEnvoiEmailDTO = new MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail();
                clsEnvoiEmailDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsEnvoiEmailDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsEnvoiEmailDTO.clsResultat.SL_MESSAGE = e.Message;
                clsEnvoiEmailDTOs.Add(clsEnvoiEmailDTO);
            }
            finally
            {
                if (Objets[0].clsObjetEnvoi != null)
                {
                    _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
                }
            }

            return clsEnvoiEmailDTOs;
        }


        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgListeReqrequete(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs;
                }
            }

            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSet(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                                clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteDTOR.NR_CODENATUREREQUETE = DataRow["NR_CODENATUREREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_CODEREQUETE = DataRow["RQ_CODEREQUETE"].ToString();
                                clsReqrequeteDTOR.TR_CODETYEREQUETE = DataRow["TR_CODETYEREQUETE"].ToString();
                                clsReqrequeteDTOR.TR_LIBELLETYEREQUETE = DataRow["TR_LIBELLETYEREQUETE"].ToString();
                                clsReqrequeteDTOR.TR_LIBELLETYEREQUETE_TRANSLATE = "";
                                clsReqrequeteDTOR.RQ_NUMEROREQUETE = DataRow["RQ_NUMEROREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_NUMERORECOMPTE = DataRow["RQ_NUMERORECOMPTE"].ToString();
                                clsReqrequeteDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                clsReqrequeteDTOR.CU_CODECOMPTEUTULISATEURASSOCIER = DataRow["CU_CODECOMPTEUTULISATEURASSOCIER"].ToString();
                                clsReqrequeteDTOR.RQ_LOCALISATIONCLIENT = DataRow["RQ_LOCALISATIONCLIENT"].ToString();
                                clsReqrequeteDTOR.RQ_DESCRIPTIONREQUETE = DataRow["RQ_DESCRIPTIONREQUETE"].ToString();
                                clsReqrequeteDTOR.MC_CODEMODECOLLETE = DataRow["MC_CODEMODECOLLETE"].ToString();
                                clsReqrequeteDTOR.RQ_DATESAISIEREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATESAISIEREQUETE"].ToString()); //  DataRow["RQ_DATESAISIEREQUETE"].ToString();
                                clsReqrequeteDTOR.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = DataRow["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
                                clsReqrequeteDTOR.RQ_DATETRANSFERTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATETRANSFERTREQUETE"].ToString()); //  DataRow["RQ_DATETRANSFERTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_CODEREQUETERELANCEE = DataRow["RQ_CODEREQUETERELANCEE"].ToString();
                                clsReqrequeteDTOR.RQ_SIGNATURE = DataRow["RQ_SIGNATURE"].ToString();
                                clsReqrequeteDTOR.RS_CODESTATUTRECEVABILITE = DataRow["RS_CODESTATUTRECEVABILITE"].ToString();
                                clsReqrequeteDTOR.RQ_OBJETREQUETE = DataRow["RQ_OBJETREQUETE"].ToString();
                                clsReqrequeteDTOR.SR_CODESERVICE = DataRow["SR_CODESERVICE"].ToString();
                                clsReqrequeteDTOR.RQ_DELAITRAITEMENTREQUETE = DataRow["RQ_DELAITRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_OBSERVATIONDELAITRAITEMENTREQUETE = DataRow["RQ_OBSERVATIONDELAITRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = DataRow["RQ_OBSERVATIONAGENTTRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_DUREETRAITEMENTREQUETE = DataRow["RQ_DUREETRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_DATEDEBUTTRAITEMENTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATEDEBUTTRAITEMENTREQUETE"].ToString()); // DataRow["RQ_DATEDEBUTTRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_DATEFINTRAITEMENTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATEFINTRAITEMENTREQUETE"].ToString()); // DataRow["RQ_DATEFINTRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.AC_CODEACTIONCORRECTIVE = DataRow["AC_CODEACTIONCORRECTIVE"].ToString();
                                clsReqrequeteDTOR.NS_CODENIVEAUSATISFACTION = DataRow["NS_CODENIVEAUSATISFACTION"].ToString();

                                clsReqrequeteDTOR.RQ_AFFICHERINFOCLIENT = DataRow["RQ_AFFICHERINFOCLIENT"].ToString();

                                clsReqrequeteDTOR.RQ_NOMRAPPORT = DataRow["RQ_NOMRAPPORT"].ToString();
                                clsReqrequeteDTOR.RQ_LIENRAPPORT = _configuration.GetSection("ApiEndpoints:URL_ROOT_DOSSIER").Value ?? string.Empty; //ConfigurationManager.AppSettings["URL_ROOT_DOSSIER"];

                                clsReqrequeteDTOR.CT_DATEOUVERTURECONTENTIEUX = clsDate.ClasseDate.pvgFormaterDate(DataRow["CT_DATEOUVERTURECONTENTIEUX"].ToString());
                                clsReqrequeteDTOR.CT_DATECLOTURECONTENTIEUX = clsDate.ClasseDate.pvgFormaterDate(DataRow["CT_DATECLOTURECONTENTIEUX"].ToString());

                                if (clsReqrequeteDTOR.RQ_AFFICHERINFOCLIENT == "O")
                                {
                                    clsReqrequeteDTOR.CU_NUMEROUTILISATEUR = DataRow["CU_NUMEROUTILISATEUR"].ToString();
                                    clsReqrequeteDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = DataRow["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                                    clsReqrequeteDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                                    clsReqrequeteDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                                    clsReqrequeteDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();
                                }
                                else
                                {
                                    clsReqrequeteDTOR.CU_NUMEROUTILISATEUR = "";
                                    clsReqrequeteDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = "";
                                    clsReqrequeteDTOR.CU_NOMUTILISATEUR = "";
                                    clsReqrequeteDTOR.CU_CONTACT = "";
                                    clsReqrequeteDTOR.CU_EMAIL = "";
                                }

                                clsReqrequeteDTOR.RQ_DATECLOTUREREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATECLOTUREREQUETE"].ToString()); // DataRow["RQ_DATECLOTUREREQUETE"].ToString();
                                clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                    }
                }
            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }

            return clsReqrequeteDTOs;
        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgListeReqrequeteCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSetPourCombo(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                                clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteDTOR.RQ_CODEREQUETE = DataRow["RQ_CODEREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_NUMEROREQUETE = DataRow["TR_CODETYEREQUETE"].ToString();
                                clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteDTOs;

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation> pvgListeReqrequeteBCAO(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation> clsEditionEtatReclamationDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation clsEditionEtatReclamationDTO = new MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation();
                    clsEditionEtatReclamationDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsEditionEtatReclamationDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsEditionEtatReclamationDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsEditionEtatReclamationDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsEditionEtatReclamationDTOs.Add(clsEditionEtatReclamationDTO);
                    return clsEditionEtatReclamationDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation clsEditionEtatReclamationDTO = new MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation();
                    clsEditionEtatReclamationDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsEditionEtatReclamationDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsEditionEtatReclamationDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsEditionEtatReclamationDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsEditionEtatReclamationDTOs.Add(clsEditionEtatReclamationDTO);
                    return clsEditionEtatReclamationDTOs;
                }
            }

            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSetBCAO(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        string vlpAG_RAISONSOCIAL = "";
                        string vlpPY_LIBELLE = "";
                        string vlpRQ_MONTANTTOTALCONTENTIEUX = "0";
                        string vlpRQ_NOMBRETOTALCONTENTIEUX = "0";
                        string vlpRQ_MONTANTTOTALCONTENTIEUXAPRES = "0";
                        string vlpRQ_NOMBRETOTALCONTENTIEUXAPRES = "0";

                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation clsEditionEtatReclamation = new MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation();
                            clsEditionEtatReclamation.clsReqrequeteRecus = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();
                            clsEditionEtatReclamation.clsReqrequeteTraitees = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();
                            clsEditionEtatReclamation.clsReqrequeteEncours = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();
                            clsEditionEtatReclamation.clsReqrequeteSuspendues = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                //MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation clsEditionEtatReclamationDTOR = new MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation();

                                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsEditionEtatReclamationDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                                clsEditionEtatReclamationDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;

                                vlpAG_RAISONSOCIAL = DataRow["AG_RAISONSOCIAL"].ToString();
                                vlpPY_LIBELLE = DataRow["PY_LIBELLE"].ToString();

                                vlpRQ_MONTANTTOTALCONTENTIEUX = DataRow["AG_RAISONSOCIAL"].ToString();
                                vlpRQ_NOMBRETOTALCONTENTIEUX = DataRow["PY_LIBELLE"].ToString();

                                if (DataRow["RQ_MONTANTTOTALCONTENTIEUX"].ToString() != "")
                                    vlpRQ_MONTANTTOTALCONTENTIEUX = double.Parse(DataRow["RQ_MONTANTTOTALCONTENTIEUX"].ToString()).ToString();
                                else
                                    vlpRQ_MONTANTTOTALCONTENTIEUX = "0";

                                //  vlpRQ_NOMBRETOTALCONTENTIEUX = DataRow["RQ_NOMBRETOTALCONTENTIEUX"].ToString().Replace(",",".");

                                if (DataRow["RQ_NOMBRETOTALCONTENTIEUX"].ToString() != "")
                                    vlpRQ_NOMBRETOTALCONTENTIEUX = int.Parse(DataRow["RQ_NOMBRETOTALCONTENTIEUX"].ToString()).ToString();
                                else
                                    vlpRQ_NOMBRETOTALCONTENTIEUX = "0";

                                if (DataRow["RQ_MONTANTTOTALCONTENTIEUXAPRES"].ToString() != "")
                                    vlpRQ_MONTANTTOTALCONTENTIEUXAPRES = double.Parse(DataRow["RQ_MONTANTTOTALCONTENTIEUXAPRES"].ToString()).ToString();
                                else
                                    vlpRQ_MONTANTTOTALCONTENTIEUXAPRES = "0";

                                if (DataRow["RQ_NOMBRETOTALCONTENTIEUXAPRES"].ToString() != "")
                                    vlpRQ_NOMBRETOTALCONTENTIEUXAPRES = int.Parse(DataRow["RQ_NOMBRETOTALCONTENTIEUXAPRES"].ToString()).ToString();
                                else
                                    vlpRQ_NOMBRETOTALCONTENTIEUXAPRES = "0";

                                clsEditionEtatReclamationDTOR.NR_CODENATUREREQUETE = DataRow["NR_CODENATUREREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_CODEREQUETE = DataRow["RQ_CODEREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.TR_CODETYEREQUETE = DataRow["TR_CODETYEREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.TR_LIBELLETYEREQUETE = DataRow["TR_LIBELLETYEREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_NUMEROREQUETE = DataRow["RQ_NUMEROREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_NUMERORECOMPTE = DataRow["RQ_NUMERORECOMPTE"].ToString();
                                clsEditionEtatReclamationDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_LOCALISATIONCLIENT = DataRow["RQ_LOCALISATIONCLIENT"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_DESCRIPTIONREQUETE = DataRow["RQ_DESCRIPTIONREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.MC_CODEMODECOLLETE = DataRow["MC_CODEMODECOLLETE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_DATESAISIEREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATESAISIEREQUETE"].ToString()); //  DataRow["RQ_DATESAISIEREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = DataRow["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_DATETRANSFERTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATETRANSFERTREQUETE"].ToString()); //  DataRow["RQ_DATETRANSFERTREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_CODEREQUETERELANCEE = DataRow["RQ_CODEREQUETERELANCEE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_SIGNATURE = DataRow["RQ_SIGNATURE"].ToString();
                                clsEditionEtatReclamationDTOR.RS_CODESTATUTRECEVABILITE = DataRow["RS_CODESTATUTRECEVABILITE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_OBJETREQUETE = DataRow["RQ_OBJETREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.SR_CODESERVICE = DataRow["SR_CODESERVICE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_DELAITRAITEMENTREQUETE = DataRow["RQ_DELAITRAITEMENTREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_OBSERVATIONDELAITRAITEMENTREQUETE = DataRow["RQ_OBSERVATIONDELAITRAITEMENTREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = DataRow["RQ_OBSERVATIONAGENTTRAITEMENTREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_DUREETRAITEMENTREQUETE = DataRow["RQ_DUREETRAITEMENTREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_DATEDEBUTTRAITEMENTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATEDEBUTTRAITEMENTREQUETE"].ToString()); // DataRow["RQ_DATEDEBUTTRAITEMENTREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.RQ_DATEFINTRAITEMENTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATEFINTRAITEMENTREQUETE"].ToString()); // DataRow["RQ_DATEFINTRAITEMENTREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.AC_CODEACTIONCORRECTIVE = DataRow["AC_CODEACTIONCORRECTIVE"].ToString();
                                clsEditionEtatReclamationDTOR.NS_CODENIVEAUSATISFACTION = DataRow["NS_CODENIVEAUSATISFACTION"].ToString();

                                clsEditionEtatReclamationDTOR.RQ_AFFICHERINFOCLIENT = DataRow["RQ_AFFICHERINFOCLIENT"].ToString();
                                // clsEditionEtatReclamationDTOR.RQ_DESCRIPTIONREQUETEAVISCLIENT = DataRow["RQ_DESCRIPTIONREQUETEAVISCLIENT"].ToString();

                                if (clsEditionEtatReclamationDTOR.RQ_AFFICHERINFOCLIENT == "O")
                                {
                                    clsEditionEtatReclamationDTOR.CU_NUMEROUTILISATEUR = DataRow["CU_NUMEROUTILISATEUR"].ToString();
                                    clsEditionEtatReclamationDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = DataRow["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                                    clsEditionEtatReclamationDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                                    clsEditionEtatReclamationDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                                    clsEditionEtatReclamationDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();
                                }
                                else
                                {
                                    clsEditionEtatReclamationDTOR.CU_NUMEROUTILISATEUR = "";
                                    clsEditionEtatReclamationDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = "";
                                    clsEditionEtatReclamationDTOR.CU_NOMUTILISATEUR = "";
                                    clsEditionEtatReclamationDTOR.CU_CONTACT = "";
                                    clsEditionEtatReclamationDTOR.CU_EMAIL = "";
                                }

                                clsEditionEtatReclamationDTOR.RQ_DATECLOTUREREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATECLOTUREREQUETE"].ToString()); // DataRow["RQ_DATECLOTUREREQUETE"].ToString();
                                clsEditionEtatReclamationDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsEditionEtatReclamationDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsEditionEtatReclamationDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;

                                if (DateTime.Parse(clsEditionEtatReclamationDTOR.RQ_DATESAISIEREQUETE) != DateTime.Parse("01/01/1900"))
                                    clsEditionEtatReclamation.clsReqrequeteRecus.Add(clsEditionEtatReclamationDTOR);
                                if (DateTime.Parse(clsEditionEtatReclamationDTOR.RQ_DATECLOTUREREQUETE) > DateTime.Parse("01/01/1900"))
                                    clsEditionEtatReclamation.clsReqrequeteTraitees.Add(clsEditionEtatReclamationDTOR);
                                if (DateTime.Parse(clsEditionEtatReclamationDTOR.RQ_DATECLOTUREREQUETE) == DateTime.Parse("01/01/1900"))
                                    clsEditionEtatReclamation.clsReqrequeteEncours.Add(clsEditionEtatReclamationDTOR);
                                if ((DateTime.Parse(clsEditionEtatReclamationDTOR.RQ_DATEDEBUTTRAITEMENTREQUETE) == DateTime.Parse("01/01/1900") && DateTime.Parse(clsEditionEtatReclamationDTOR.RQ_DATEFINTRAITEMENTREQUETE) == DateTime.Parse("01/01/1900")) || (clsEditionEtatReclamationDTOR.RS_CODESTATUTRECEVABILITE == "02") || (DateTime.Parse(clsEditionEtatReclamationDTOR.CT_DATEOUVERTURECONTENTIEUX) != DateTime.Parse("01/01/1900")))
                                    clsEditionEtatReclamation.clsReqrequeteSuspendues.Add(clsEditionEtatReclamationDTOR);
                            }
                            clsEditionEtatReclamation.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;

                            clsEditionEtatReclamation.AG_RAISONSOCIAL = vlpAG_RAISONSOCIAL;
                            clsEditionEtatReclamation.PY_LIBELLE = vlpPY_LIBELLE;

                            clsEditionEtatReclamation.RQ_MONTANTTOTALCONTENTIEUX = vlpRQ_MONTANTTOTALCONTENTIEUX;
                            clsEditionEtatReclamation.RQ_NOMBRETOTALCONTENTIEUX = vlpRQ_NOMBRETOTALCONTENTIEUX;

                            clsEditionEtatReclamation.RQ_MONTANTTOTALCONTENTIEUXAPRES = vlpRQ_MONTANTTOTALCONTENTIEUXAPRES;
                            clsEditionEtatReclamation.RQ_NOMBRETOTALCONTENTIEUXAPRES = vlpRQ_NOMBRETOTALCONTENTIEUXAPRES;

                            clsEditionEtatReclamation.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsEditionEtatReclamation.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsEditionEtatReclamation.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;

                            clsEditionEtatReclamationDTOs.Add(clsEditionEtatReclamation);

                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation clsEditionEtatReclamationDTOR = new MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation();
                            clsEditionEtatReclamationDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsEditionEtatReclamationDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsEditionEtatReclamationDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsEditionEtatReclamationDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsEditionEtatReclamationDTOs.Add(clsEditionEtatReclamationDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation clsEditionEtatReclamationDTOR = new MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation();
                        clsEditionEtatReclamationDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsEditionEtatReclamationDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsEditionEtatReclamationDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsEditionEtatReclamationDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsEditionEtatReclamationDTOs.Add(clsEditionEtatReclamationDTOR);
                    }
                }
            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation clsEditionEtatReclamationDTO = new MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation();
                clsEditionEtatReclamationDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsEditionEtatReclamationDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsEditionEtatReclamationDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsEditionEtatReclamationDTOs.Add(clsEditionEtatReclamationDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation clsEditionEtatReclamationDTO = new MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation();
                clsEditionEtatReclamationDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsEditionEtatReclamationDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsEditionEtatReclamationDTO.clsResultat.SL_MESSAGE = e.Message;
                clsEditionEtatReclamationDTOs.Add(clsEditionEtatReclamationDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsEditionEtatReclamationDTOs;

        }


        public MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord pvgTableauDeBord(string AG_CODEAGENCE, string RQ_DATEDEBUT, string RQ_DATEFIN, string CU_CODECOMPTEUTULISATEUR, string TYPEETAT)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord>();
            MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
            clsReqrequeteDTO.clsTableauDeBordSituationPlaintes = new List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordSituationPlainte>();
            clsReqrequeteDTO.clsTableauDeBordTauxSatisfactions = new List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction>();

            clsReqrequeteDTO.clsTableauDeBordDelaiTraiPlaintes = new List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre>();
            clsReqrequeteDTO.clsTableauDeBordNatPlainteRecurs = new List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre>();
            clsReqrequeteDTO.clsTableauDeBordNbrePlainterefs = new List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre>();

            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //----EXEPTION
                clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AG_CODEAGENCE";
                //clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                return clsReqrequeteDTO;
            }

            if (string.IsNullOrEmpty(RQ_DATEDEBUT))
            {
                clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //----EXEPTION
                clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DATEDEBUT";
                //clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                return clsReqrequeteDTO;
            }

            if (string.IsNullOrEmpty(RQ_DATEFIN))
            {
                clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //----EXEPTION
                clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DATEFIN";
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                return clsReqrequeteDTO;
            }
            if (string.IsNullOrEmpty(TYPEETAT))
            {
                clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //----EXEPTION
                clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEETAT";
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                return clsReqrequeteDTO;
            }



            try
            {

                _clsDonnee.pvgDemarrerTransaction();

                clsObjetEnvoi = new clsObjetEnvoi();
                clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
                //===
                //clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;
                string TYPEETATSTAT = "";
                if (TYPEETAT == "HEBDO")
                {
                    TYPEETATSTAT = "HEBDO";
                }
                else
                {
                    TYPEETATSTAT = "SIPRECU";
                }

                TYPEETAT = "TSCLT";
                clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, RQ_DATEDEBUT, RQ_DATEFIN, CU_CODECOMPTEUTULISATEUR, TYPEETAT };

                //====
                clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSetTableauDeBord(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.LIBELLERUBRIQUE = DataRow["LIBELLERUBRIQUE"].ToString();
                            if (DataRow["TOTALPLAINTERECUES"].ToString() != "")
                                clsReqrequeteDTOR.TOTALPLAINTERECUES = int.Parse(DataRow["TOTALPLAINTERECUES"].ToString()).ToString();
                            else
                                clsReqrequeteDTOR.TOTALPLAINTERECUES = "0";


                            if (DataRow["TOTALPLAINTETRAITES"].ToString() != "")
                                clsReqrequeteDTOR.TOTALPLAINTETRAITES = int.Parse(DataRow["TOTALPLAINTETRAITES"].ToString()).ToString();
                            else
                                clsReqrequeteDTOR.TOTALPLAINTETRAITES = "0";

                            if (DataRow["AVISCLIENTFAVORABLE"].ToString() != "")
                                clsReqrequeteDTOR.AVISCLIENTFAVORABLE = int.Parse(DataRow["AVISCLIENTFAVORABLE"].ToString()).ToString();
                            else
                                clsReqrequeteDTOR.AVISCLIENTFAVORABLE = "0";

                            if (DataRow["AVISCLIENTNONFAVORABLE"].ToString() != "")
                                clsReqrequeteDTOR.AVISCLIENTNONFAVORABLE = int.Parse(DataRow["AVISCLIENTNONFAVORABLE"].ToString()).ToString();
                            else
                                clsReqrequeteDTOR.AVISCLIENTNONFAVORABLE = "0";

                            clsReqrequeteDTOR.TAUXSATISFACTION = DataRow["TAUXSATISFACTION"].ToString();

                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsReqrequeteDTO.clsTableauDeBordTauxSatisfactions.Add(clsReqrequeteDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTO.clsTableauDeBordTauxSatisfactions.Add(clsReqrequeteDTOR);
                    }
                }
                else
                {
                    MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction();
                    clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                    clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                    clsReqrequeteDTO.clsTableauDeBordTauxSatisfactions.Add(clsReqrequeteDTOR);
                }

                //TYPEETAT = "SIPRECU";
                TYPEETAT = TYPEETATSTAT;
                clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, RQ_DATEDEBUT, RQ_DATEFIN, CU_CODECOMPTEUTULISATEUR, TYPEETAT };

                clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSetTableauDeBord(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordSituationPlainte clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordSituationPlainte();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.LIBELLERUBRIQUE = DataRow["LIBELLERUBRIQUE"].ToString();
                            if (DataRow["TOTALPLAINTERECUES"].ToString() != "")
                                clsReqrequeteDTOR.TOTALPLAINTERECUES = int.Parse(DataRow["TOTALPLAINTERECUES"].ToString()).ToString();
                            else
                                clsReqrequeteDTOR.TOTALPLAINTERECUES = "0";

                            if (DataRow["TOTALPLAINTETRAITES"].ToString() != "")
                                clsReqrequeteDTOR.TOTALPLAINTETRAITES = int.Parse(DataRow["TOTALPLAINTETRAITES"].ToString()).ToString();
                            else
                                clsReqrequeteDTOR.TOTALPLAINTETRAITES = "0";

                            if (DataRow["AVISCLIENTFAVORABLE"].ToString() != "")
                                clsReqrequeteDTOR.AVISCLIENTFAVORABLE = int.Parse(DataRow["AVISCLIENTFAVORABLE"].ToString()).ToString();
                            else
                                clsReqrequeteDTOR.AVISCLIENTFAVORABLE = "0";

                            if (DataRow["AVISCLIENTNONFAVORABLE"].ToString() != "")
                                clsReqrequeteDTOR.AVISCLIENTNONFAVORABLE = int.Parse(DataRow["AVISCLIENTNONFAVORABLE"].ToString()).ToString();
                            else
                                clsReqrequeteDTOR.AVISCLIENTNONFAVORABLE = "0";

                            clsReqrequeteDTOR.TAUXSATISFACTION = DataRow["TAUXSATISFACTION"].ToString();

                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsReqrequeteDTO.clsTableauDeBordSituationPlaintes.Add(clsReqrequeteDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordSituationPlainte clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordSituationPlainte();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTO.clsTableauDeBordSituationPlaintes.Add(clsReqrequeteDTOR);
                    }
                }
                else
                {
                    MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordSituationPlainte clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordSituationPlainte();
                    clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                    clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                    clsReqrequeteDTO.clsTableauDeBordSituationPlaintes.Add(clsReqrequeteDTOR);
                }

                TYPEETAT = "DELATTP";
                clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, RQ_DATEDEBUT, RQ_DATEFIN, CU_CODECOMPTEUTULISATEUR, TYPEETAT };

                //====
                clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSetTableauDeBord(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.LIBELLERUBRIQUE = DataRow["LIBELLERUBRIQUE"].ToString();
                            if (DataRow["NOMBRE"].ToString() != "")
                                clsReqrequeteDTOR.NOMBRE = int.Parse(DataRow["NOMBRE"].ToString()).ToString();
                            else
                                clsReqrequeteDTOR.NOMBRE = "0";

                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsReqrequeteDTO.clsTableauDeBordDelaiTraiPlaintes.Add(clsReqrequeteDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTO.clsTableauDeBordDelaiTraiPlaintes.Add(clsReqrequeteDTOR);
                    }
                }
                else
                {
                    MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre();
                    clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                    clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                    clsReqrequeteDTO.clsTableauDeBordDelaiTraiPlaintes.Add(clsReqrequeteDTOR);
                }

                TYPEETAT = "NATTP";
                clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, RQ_DATEDEBUT, RQ_DATEFIN, CU_CODECOMPTEUTULISATEUR, TYPEETAT };

                //====
                clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSetTableauDeBord(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.LIBELLERUBRIQUE = DataRow["LIBELLERUBRIQUE"].ToString();
                            if (DataRow["NOMBRE"].ToString() != "")
                                clsReqrequeteDTOR.NOMBRE = int.Parse(DataRow["NOMBRE"].ToString()).ToString();
                            else
                                clsReqrequeteDTOR.NOMBRE = "0";

                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsReqrequeteDTO.clsTableauDeBordNatPlainteRecurs.Add(clsReqrequeteDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTO.clsTableauDeBordNatPlainteRecurs.Add(clsReqrequeteDTOR);
                    }


                }
                else
                {
                    MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre();
                    clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                    clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                    clsReqrequeteDTO.clsTableauDeBordNatPlainteRecurs.Add(clsReqrequeteDTOR);
                }

                TYPEETAT = "NBCLTS";
                clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, RQ_DATEDEBUT, RQ_DATEFIN, CU_CODECOMPTEUTULISATEUR, TYPEETAT };

                //====
                clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSetTableauDeBord(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.LIBELLERUBRIQUE = DataRow["LIBELLERUBRIQUE"].ToString();
                            if (DataRow["NOMBRE"].ToString() != "")
                                clsReqrequeteDTOR.NOMBRE = int.Parse(DataRow["NOMBRE"].ToString()).ToString();
                            else
                                clsReqrequeteDTOR.NOMBRE = "0";

                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsReqrequeteDTO.clsTableauDeBordNbrePlainterefs.Add(clsReqrequeteDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTO.clsTableauDeBordNbrePlainterefs.Add(clsReqrequeteDTOR);
                    }


                }
                else
                {
                    MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre();
                    clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                    clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                    clsReqrequeteDTO.clsTableauDeBordNbrePlainterefs.Add(clsReqrequeteDTOR);
                }

                if (clsReqrequeteDTO.clsTableauDeBordSituationPlaintes != null)
                {
                    if (clsReqrequeteDTO.clsTableauDeBordSituationPlaintes.Count > 0)
                    {
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                    }
                    else
                    {
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                    }
                }

                if (clsReqrequeteDTO.clsTableauDeBordTauxSatisfactions != null)
                {
                    if (clsReqrequeteDTO.clsTableauDeBordTauxSatisfactions.Count > 0)
                    {
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                    }
                    else
                    {
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                    }
                }



            }

            catch (SqlException SQLEx)
            {
                clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            catch (Exception e)
            {
                clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteDTO;

        }

        #endregion Reqrequete


        #region Contentieux
        public MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux pvgMajReqrequeteContentieux(List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux> clsRequetecontentieuxDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieux in Objets)
            {
                if (clsRequetecontentieux.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                    clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequetecontentieuxDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
                    return clsRequetecontentieuxDTOs[0];
                }
                if (string.IsNullOrEmpty(clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                    clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequetecontentieuxDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
                    return clsRequetecontentieuxDTOs[0];
                }
                if (string.IsNullOrEmpty(clsRequetecontentieux.CT_CODEREQUETECONTENTIEUX) && (clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "1" || clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "2" || clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "4" || clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "6" || clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "7"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                    clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequetecontentieuxDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CT_CODEREQUETECONTENTIEUX";
                    clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
                    return clsRequetecontentieuxDTOs[0];
                }


                if (string.IsNullOrEmpty(clsRequetecontentieux.RQ_CODEREQUETE) && (clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "0" || clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "1" || clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                    clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequetecontentieuxDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_CODEREQUETE";
                    clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
                    return clsRequetecontentieuxDTOs[0];
                }
                if (string.IsNullOrEmpty(clsRequetecontentieux.CT_DATEOUVERTURECONTENTIEUX) && (clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "0" || clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "1" || clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                    clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequetecontentieuxDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CT_DATEOUVERTURECONTENTIEUX";
                    clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
                    return clsRequetecontentieuxDTOs[0];
                }

                if (string.IsNullOrEmpty(clsRequetecontentieux.CT_DATECLOTURECONTENTIEUX) && (clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "0" || clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "1" || clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                    clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequetecontentieuxDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CT_DATECLOTURECONTENTIEUX";
                    clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
                    return clsRequetecontentieuxDTOs[0];
                }

                if (string.IsNullOrEmpty(clsRequetecontentieux.CT_MONTANTCONTENTIEUXEXTIME) && (clsRequetecontentieux.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                    clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequetecontentieuxDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CT_MONTANTCONTENTIEUXEXTIME";
                    clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
                    return clsRequetecontentieuxDTOs[0];
                }

            }

            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsRequetecontentieuxWSBLL clsRequetecontentieuxWSBLL = new clsRequetecontentieuxWSBLL();
                    //===
                    MgRequeteClients.BOJ.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxBOJ = new clsRequetecontentieux();
                    clsRequetecontentieuxBOJ.CT_CODEREQUETECONTENTIEUX = clsRequetecontentieuxDTO.CT_CODEREQUETECONTENTIEUX;
                    clsRequetecontentieuxBOJ.RQ_CODEREQUETE = clsRequetecontentieuxDTO.RQ_CODEREQUETE;
                    if (clsRequetecontentieuxDTO.CT_DATEOUVERTURECONTENTIEUX != "")
                        clsRequetecontentieuxBOJ.CT_DATEOUVERTURECONTENTIEUX = DateTime.Parse(clsRequetecontentieuxDTO.CT_DATEOUVERTURECONTENTIEUX);
                    else
                        clsRequetecontentieuxBOJ.CT_DATEOUVERTURECONTENTIEUX = DateTime.Parse("01/01/1900");
                    if (clsRequetecontentieuxDTO.CT_DATECLOTURECONTENTIEUX != "")
                        clsRequetecontentieuxBOJ.CT_DATECLOTURECONTENTIEUX = DateTime.Parse(clsRequetecontentieuxDTO.CT_DATECLOTURECONTENTIEUX);
                    else
                        clsRequetecontentieuxBOJ.CT_DATECLOTURECONTENTIEUX = DateTime.Parse("01/01/1900");
                    if (clsRequetecontentieuxDTO.CT_MONTANTCONTENTIEUXEXTIME != "")
                        clsRequetecontentieuxBOJ.CT_MONTANTCONTENTIEUXEXTIME = double.Parse(clsRequetecontentieuxDTO.CT_MONTANTCONTENTIEUXEXTIME);
                    else
                        clsRequetecontentieuxBOJ.CT_MONTANTCONTENTIEUXEXTIME = 0;

                    if (clsRequetecontentieuxDTO.CT_MONTANTCONTENTIEUXREEL != "")
                        clsRequetecontentieuxBOJ.CT_MONTANTCONTENTIEUXREEL = double.Parse(clsRequetecontentieuxDTO.CT_MONTANTCONTENTIEUXREEL);
                    else
                        clsRequetecontentieuxBOJ.CT_MONTANTCONTENTIEUXREEL = 0;


                    clsRequetecontentieuxBOJ.CT_OBSERVATION1 = clsRequetecontentieuxDTO.CT_OBSERVATION1;
                    clsRequetecontentieuxBOJ.CT_OBSERVATION2 = clsRequetecontentieuxDTO.CT_OBSERVATION2;
                    clsRequetecontentieuxBOJ.FICHIERSJOINT = clsRequetecontentieuxDTO.FICHIERSJOINT;



                    clsRequetecontentieuxBOJ.TYPEOPERATION = clsRequetecontentieuxDTO.clsObjetEnvoi.TYPEOPERATION;
                    clsRequetecontentieuxBOJ.AN_CODEANTENNE = clsRequetecontentieuxDTO.clsObjetEnvoi.AN_CODEANTENNE;

                    clsRequetecontentieuxBOJ.CU_CODECOMPTEUTULISATEUR = clsRequetecontentieuxDTO.CU_CODECOMPTEUTULISATEUR;
                    //====
                    clsObjetRetour.SetValue(true, clsRequetecontentieuxWSBLL.pvgMiseajour(_clsDonnee, clsRequetecontentieuxBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {

                        clsParams clsParams = new clsParams();
                        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();

                        //if (clsRequetecontentieuxBOJ.TYPEOPERATION == "0" || clsReqrequeteBOJ.TYPEOPERATION == "5" || clsReqrequeteBOJ.TYPEOPERATION == "8")
                        //{
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                        string AG_CODEAGENCE = "";
                        string SM_TELEPHONE = "";
                        string SMSTEXT = "";
                        DateTime SM_DATEPIECE = clsRequetecontentieuxBOJ.CT_DATEOUVERTURECONTENTIEUX;
                        if (clsRequetecontentieuxBOJ.CT_DATEOUVERTURECONTENTIEUX == DateTime.Parse("01/01/1900"))
                        {
                            SM_DATEPIECE = clsRequetecontentieuxBOJ.CT_DATECLOTURECONTENTIEUX;
                        }

                        string TYPEOPERATION = "";
                        string SL_LIBELLE1 = "";
                        string SL_LIBELLE2 = "";
                        string TE_CODESMSTYPEOPERATION = "";
                        string CU_CODECOMPTEUTULISATEUR = "";


                        clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                        clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
                        clsObjetEnvoi.OE_PARAM = new string[] { clsRequetecontentieuxBOJ.CU_CODECOMPTEUTULISATEUR }; ;
                        clsReqcompteutilisateur = clsReqcompteutilisateurWSBLL.pvgTableLibelle(_clsDonnee, clsObjetEnvoi);

                        if (clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR != "")
                        {
                            AG_CODEAGENCE = clsReqcompteutilisateur.AG_CODEAGENCE; // ;
                            SM_TELEPHONE = clsReqcompteutilisateur.CU_CONTACT;
                            SMSTEXT = "Vous avez une nouvelle requette à traiter !!!";
                            //SM_DATEPIECE = clsRequetecontentieuxBOJ.CT_DATEOUVERTURECONTENTIEUX;
                            TYPEOPERATION = "0";
                            SL_LIBELLE1 = "";
                            SL_LIBELLE2 = clsRequetecontentieuxBOJ.RQ_CODEREQUETE;
                            if (clsRequetecontentieuxBOJ.TYPEOPERATION == "0")
                            {
                                TE_CODESMSTYPEOPERATION = "0008";
                            }
                            else
                            {
                                TE_CODESMSTYPEOPERATION = "0009";
                            }

                            CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;

                            //if (SM_TELEPHONE.Length == 10)
                            //    SM_TELEPHONE = "225" + SM_TELEPHONE;

                            //public clsParams pvgTraitementSmsSimple1(_clsDonnee clsDonnee, string AG_CODEAGENCE, string SM_TELEPHONE, string SMSTEXT, DateTime SM_DATEPIECE, string TYPEOPERATION, string TE_CODESMSTYPEOPERATION, string CU_CODECOMPTEUTULISATEUR, string SL_LIBELLE1, string SL_LIBELLE2)
                            clsParams = clsSmsoutWSBLL.pvgTraitementSmsSimple1(_clsDonnee, AG_CODEAGENCE, SM_TELEPHONE, SMSTEXT, SM_DATEPIECE, TYPEOPERATION, TE_CODESMSTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, SL_LIBELLE1, SL_LIBELLE2);
                        }
                        //}

                        string var_test = "";
                        var_test = clsRequetecontentieuxBOJ.RQ_CODEREQUETE;

                        List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> clsTableaux = new List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe>();
                        MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsTableau = new MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe();
                        clsTableau.RQ_CODEREQUETE = clsRequetecontentieuxBOJ.RQ_CODEREQUETE;
                        clsTableau.TYPEOPERATION = clsRequetecontentieuxBOJ.TYPEOPERATION;
                        clsTableaux.Add(clsTableau);
                        pvgChargerDansDataSetParOperateursNotif(clsTableaux);

                        MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                        clsRequetecontentieuxDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsRequetecontentieuxDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsRequetecontentieuxDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsRequetecontentieuxDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                        clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTOR);
                    }
                }
            }
            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = e.Message;
                clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsRequetecontentieuxDTOs[0];

        }
        public List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux> pvgListeReqrequeteContentieux(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux> clsRequetecontentieuxDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                    clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequetecontentieuxDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
                    return clsRequetecontentieuxDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                    clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequetecontentieuxDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
                    return clsRequetecontentieuxDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsRequetecontentieuxWSBLL clsRequetecontentieuxWSBLL = new clsRequetecontentieuxWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsRequetecontentieuxWSBLL.pvgChargerDansDataSet(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                                clsRequetecontentieuxDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsRequetecontentieuxDTOR.CT_CODEREQUETECONTENTIEUX = DataRow["CT_CODEREQUETECONTENTIEUX"].ToString();
                                clsRequetecontentieuxDTOR.RQ_CODEREQUETE = DataRow["RQ_CODEREQUETE"].ToString();
                                clsRequetecontentieuxDTOR.CT_DATEOUVERTURECONTENTIEUX = clsDate.ClasseDate.pvgFormaterDate(DataRow["CT_DATEOUVERTURECONTENTIEUX"].ToString()); //DataRow["CT_DATEOUVERTURECONTENTIEUX"].ToString();
                                clsRequetecontentieuxDTOR.CT_DATECLOTURECONTENTIEUX = clsDate.ClasseDate.pvgFormaterDate(DataRow["CT_DATECLOTURECONTENTIEUX"].ToString()); //DataRow["CT_DATECLOTURECONTENTIEUX"].ToString();
                                clsRequetecontentieuxDTOR.CT_MONTANTCONTENTIEUXEXTIME = DataRow["CT_MONTANTCONTENTIEUXEXTIME"].ToString();
                                clsRequetecontentieuxDTOR.CT_MONTANTCONTENTIEUXREEL = DataRow["CT_MONTANTCONTENTIEUXREEL"].ToString();
                                clsRequetecontentieuxDTOR.CT_OBSERVATION1 = DataRow["CT_OBSERVATION1"].ToString();
                                clsRequetecontentieuxDTOR.CT_OBSERVATION2 = DataRow["CT_OBSERVATION2"].ToString();
                                clsRequetecontentieuxDTOR.FICHIERSJOINT = DataRow["FICHIERSJOINT"].ToString(); //  DataRow["FICHIERSJOINT"].ToString();

                                clsRequetecontentieuxDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsRequetecontentieuxDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsRequetecontentieuxDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                            clsRequetecontentieuxDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsRequetecontentieuxDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsRequetecontentieuxDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsRequetecontentieuxDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                        clsRequetecontentieuxDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsRequetecontentieuxDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsRequetecontentieuxDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsRequetecontentieuxDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = e.Message;
                clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsRequetecontentieuxDTOs;

        }
        public List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux> pvgListeReqrequeteContentieuxCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux> clsRequetecontentieuxDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                    clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequetecontentieuxDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
                    return clsRequetecontentieuxDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                    clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequetecontentieuxDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
                    return clsRequetecontentieuxDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsRequetecontentieuxWSBLL clsRequetecontentieuxWSBLL = new clsRequetecontentieuxWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsRequetecontentieuxWSBLL.pvgChargerDansDataSetPourCombo(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                                clsRequetecontentieuxDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsRequetecontentieuxDTOR.CT_CODEREQUETECONTENTIEUX = DataRow["CT_CODEREQUETECONTENTIEUX"].ToString();
                                clsRequetecontentieuxDTOR.CT_OBSERVATION1 = DataRow["CT_OBSERVATION1"].ToString();
                                clsRequetecontentieuxDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsRequetecontentieuxDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsRequetecontentieuxDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                            clsRequetecontentieuxDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsRequetecontentieuxDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsRequetecontentieuxDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsRequetecontentieuxDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                        clsRequetecontentieuxDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsRequetecontentieuxDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsRequetecontentieuxDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsRequetecontentieuxDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = e.Message;
                clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsRequetecontentieuxDTOs;

        }

        public MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux pvgMajReqrequeteContentieuxUPloadFile()
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux> clsRequetecontentieuxDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux>();

            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            try
            {
                _clsDonnee.pvgDemarrerTransaction();

                clsObjetEnvoi = new clsObjetEnvoi();
                clsRequetecontentieuxWSBLL clsRequetecontentieuxWSBLL = new clsRequetecontentieuxWSBLL();
                MgRequeteClients.BOJ.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxBOJ = new clsRequetecontentieux();

                if (clsDeclaration.CT_CODEREQUETECONTENTIEUX != null)
                    clsRequetecontentieuxBOJ.CT_CODEREQUETECONTENTIEUX = clsDeclaration.CT_CODEREQUETECONTENTIEUX[0];

                if (clsDeclaration.DOCS_FICHIERS != null)
                {
                    foreach (var file in clsDeclaration.DOCS_FICHIERS)
                    {
                        clsRequetecontentieuxBOJ.FICHIERSJOINT = file.Replace(" ", "");

                        clsRequetecontentieuxBOJ.TYPEOPERATION = "4";

                        clsObjetRetour.SetValue(true, clsRequetecontentieuxWSBLL.pvgMiseajour(_clsDonnee, clsRequetecontentieuxBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                        if (clsObjetRetour.OR_BOOLEEN)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                            clsRequetecontentieuxDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;

                            clsRequetecontentieuxDTOR.FICHIERSJOINT = clsRequetecontentieuxBOJ.FICHIERSJOINT;
                            clsRequetecontentieuxDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsRequetecontentieuxDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsRequetecontentieuxDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTOR);
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                            clsRequetecontentieuxDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsRequetecontentieuxDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_CODE_REQUIS;
                            clsRequetecontentieuxDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsRequetecontentieuxDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_OPERATION_NON_EFFECTUEE;
                            clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTOR);
                        }
                    }
                }
            }
            catch (SqlException SQLEx)
            {
                // MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux
                MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux clsRequetecontentieuxDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux();
                clsRequetecontentieuxDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequetecontentieuxDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequetecontentieuxDTO.clsResultat.SL_MESSAGE = e.Message;
                clsRequetecontentieuxDTOs.Add(clsRequetecontentieuxDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
                //_clsDonnee.pvgDeConnectionBase();
            }

            return clsRequetecontentieuxDTOs[0];
        }
        #endregion Contentieux



        #region UtilisateurDroitParam
        public MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre pvgMajUtilisateurDroitParam(List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> clsRequtilisateurdroitparametreDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametre in Objets)
            {
                if (clsRequtilisateurdroitparametre.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                    clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                    return clsRequtilisateurdroitparametreDTOs[0];
                }
                if (string.IsNullOrEmpty(clsRequtilisateurdroitparametre.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                    clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                    return clsRequtilisateurdroitparametreDTOs[0];
                }
                if (string.IsNullOrEmpty(clsRequtilisateurdroitparametre.DP_CODEDROITCOMPTEUTULISATEUR) && (clsRequtilisateurdroitparametre.clsObjetEnvoi.TYPEOPERATION == "1" || clsRequtilisateurdroitparametre.clsObjetEnvoi.TYPEOPERATION == "2" || clsRequtilisateurdroitparametre.clsObjetEnvoi.TYPEOPERATION == "4" || clsRequtilisateurdroitparametre.clsObjetEnvoi.TYPEOPERATION == "6" || clsRequtilisateurdroitparametre.clsObjetEnvoi.TYPEOPERATION == "7"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                    clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " DP_CODEDROITCOMPTEUTULISATEUR";
                    clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                    return clsRequtilisateurdroitparametreDTOs[0];
                }


                if (string.IsNullOrEmpty(clsRequtilisateurdroitparametre.DP_LIBELLEDROITCOMPTEUTULISATEUR) && (clsRequtilisateurdroitparametre.clsObjetEnvoi.TYPEOPERATION == "0" || clsRequtilisateurdroitparametre.clsObjetEnvoi.TYPEOPERATION == "1" || clsRequtilisateurdroitparametre.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                    clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " DP_LIBELLEDROITCOMPTEUTULISATEUR";
                    clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                    return clsRequtilisateurdroitparametreDTOs[0];
                }
                if (string.IsNullOrEmpty(clsRequtilisateurdroitparametre.DP_STATUT) && (clsRequtilisateurdroitparametre.clsObjetEnvoi.TYPEOPERATION == "0" || clsRequtilisateurdroitparametre.clsObjetEnvoi.TYPEOPERATION == "1" || clsRequtilisateurdroitparametre.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                    clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " DP_STATUT";
                    clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                    return clsRequtilisateurdroitparametreDTOs[0];
                }










            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsRequtilisateurdroitparametreWSBLL clsRequtilisateurdroitparametreWSBLL = new clsRequtilisateurdroitparametreWSBLL();
                    //===
                    MgRequeteClients.BOJ.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreBOJ = new clsRequtilisateurdroitparametre();
                    clsRequtilisateurdroitparametreBOJ.DP_CODEDROITCOMPTEUTULISATEUR = clsRequtilisateurdroitparametreDTO.DP_CODEDROITCOMPTEUTULISATEUR;
                    clsRequtilisateurdroitparametreBOJ.DP_LIBELLEDROITCOMPTEUTULISATEUR = clsRequtilisateurdroitparametreDTO.DP_LIBELLEDROITCOMPTEUTULISATEUR;
                    clsRequtilisateurdroitparametreBOJ.DP_STATUT = clsRequtilisateurdroitparametreDTO.DP_STATUT;
                    clsRequtilisateurdroitparametreBOJ.TYPEOPERATION = clsRequtilisateurdroitparametreDTO.clsObjetEnvoi.TYPEOPERATION;

                    //====
                    clsObjetRetour.SetValue(true, clsRequtilisateurdroitparametreWSBLL.pvgMiseajour(_clsDonnee, clsRequtilisateurdroitparametreBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                        clsRequtilisateurdroitparametreDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsRequtilisateurdroitparametreDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsRequtilisateurdroitparametreDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsRequtilisateurdroitparametreDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                        clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = e.Message;
                clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsRequtilisateurdroitparametreDTOs[0];

        }
        public List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> pvgListeUtilisateurDroitParam(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> clsRequtilisateurdroitparametreDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                    clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                    return clsRequtilisateurdroitparametreDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                    clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                    return clsRequtilisateurdroitparametreDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsRequtilisateurdroitparametreWSBLL clsRequtilisateurdroitparametreWSBLL = new clsRequtilisateurdroitparametreWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsRequtilisateurdroitparametreWSBLL.pvgChargerDansDataSet(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                                clsRequtilisateurdroitparametreDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsRequtilisateurdroitparametreDTOR.DP_CODEDROITCOMPTEUTULISATEUR = DataRow["DP_CODEDROITCOMPTEUTULISATEUR"].ToString();
                                clsRequtilisateurdroitparametreDTOR.DP_LIBELLEDROITCOMPTEUTULISATEUR = DataRow["DP_LIBELLEDROITCOMPTEUTULISATEUR"].ToString();
                                clsRequtilisateurdroitparametreDTOR.DP_STATUT = DataRow["DP_STATUT"].ToString();

                                clsRequtilisateurdroitparametreDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsRequtilisateurdroitparametreDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsRequtilisateurdroitparametreDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                            clsRequtilisateurdroitparametreDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsRequtilisateurdroitparametreDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsRequtilisateurdroitparametreDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsRequtilisateurdroitparametreDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                        clsRequtilisateurdroitparametreDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsRequtilisateurdroitparametreDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsRequtilisateurdroitparametreDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsRequtilisateurdroitparametreDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = e.Message;
                clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsRequtilisateurdroitparametreDTOs;

        }
        public List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> pvgListeUtilisateurDroitParamCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> clsRequtilisateurdroitparametreDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                    clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                    return clsRequtilisateurdroitparametreDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                    clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                    return clsRequtilisateurdroitparametreDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsRequtilisateurdroitparametreWSBLL clsRequtilisateurdroitparametreWSBLL = new clsRequtilisateurdroitparametreWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsRequtilisateurdroitparametreWSBLL.pvgChargerDansDataSetPourCombo(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                                clsRequtilisateurdroitparametreDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsRequtilisateurdroitparametreDTOR.DP_CODEDROITCOMPTEUTULISATEUR = DataRow["DP_CODEDROITCOMPTEUTULISATEUR"].ToString();
                                clsRequtilisateurdroitparametreDTOR.DP_STATUT = DataRow["DP_LIBELLEDROITCOMPTEUTULISATEUR"].ToString();
                                clsRequtilisateurdroitparametreDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsRequtilisateurdroitparametreDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsRequtilisateurdroitparametreDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                            clsRequtilisateurdroitparametreDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsRequtilisateurdroitparametreDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsRequtilisateurdroitparametreDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsRequtilisateurdroitparametreDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                        clsRequtilisateurdroitparametreDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsRequtilisateurdroitparametreDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsRequtilisateurdroitparametreDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsRequtilisateurdroitparametreDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = e.Message;
                clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsRequtilisateurdroitparametreDTOs;

        }
        #endregion UtilisateurDroitParam


        #region UtilisateurDroit
        public MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit pvgMajUtilisateurDroit(List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetRetour clsObjetRetourDEL = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit> clsRequtilisateurdroitDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroit in Objets)
            {
                if (clsRequtilisateurdroit.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                    clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
                    return clsRequtilisateurdroitDTOs[0];
                }
                if (string.IsNullOrEmpty(clsRequtilisateurdroit.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                    clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
                    return clsRequtilisateurdroitDTOs[0];
                }
                if (string.IsNullOrEmpty(clsRequtilisateurdroit.DP_CODEDROITCOMPTEUTULISATEUR) && (clsRequtilisateurdroit.clsObjetEnvoi.TYPEOPERATION == "1" || clsRequtilisateurdroit.clsObjetEnvoi.TYPEOPERATION == "2" || clsRequtilisateurdroit.clsObjetEnvoi.TYPEOPERATION == "4" || clsRequtilisateurdroit.clsObjetEnvoi.TYPEOPERATION == "6" || clsRequtilisateurdroit.clsObjetEnvoi.TYPEOPERATION == "7"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                    clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " DP_CODEDROITCOMPTEUTULISATEUR";
                    clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
                    return clsRequtilisateurdroitDTOs[0];
                }


                if (string.IsNullOrEmpty(clsRequtilisateurdroit.CU_CODECOMPTEUTULISATEUR) && (clsRequtilisateurdroit.clsObjetEnvoi.TYPEOPERATION == "0" || clsRequtilisateurdroit.clsObjetEnvoi.TYPEOPERATION == "1" || clsRequtilisateurdroit.clsObjetEnvoi.TYPEOPERATION == "8"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                    clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_CODECOMPTEUTULISATEUR";
                    clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
                    return clsRequtilisateurdroitDTOs[0];
                }


            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();

                int NBRETOUR = 0;
                foreach (MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsRequtilisateurdroitWSBLL clsRequtilisateurdroitWSBLL = new clsRequtilisateurdroitWSBLL();
                    //===
                    MgRequeteClients.BOJ.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitBOJ = new clsRequtilisateurdroit();
                    clsRequtilisateurdroitBOJ.DP_CODEDROITCOMPTEUTULISATEUR = clsRequtilisateurdroitDTO.DP_CODEDROITCOMPTEUTULISATEUR;
                    clsRequtilisateurdroitBOJ.CU_CODECOMPTEUTULISATEUR = clsRequtilisateurdroitDTO.CU_CODECOMPTEUTULISATEUR;
                    clsRequtilisateurdroitBOJ.TYPEOPERATION = clsRequtilisateurdroitDTO.clsObjetEnvoi.TYPEOPERATION;


                    if (NBRETOUR == 0)
                    {

                        clsRequtilisateurdroitBOJ.TYPEOPERATION = "3";
                        clsObjetRetourDEL.SetValue(true, clsRequtilisateurdroitWSBLL.pvgMiseajour(_clsDonnee, clsRequtilisateurdroitBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                        if (clsObjetRetourDEL.OR_BOOLEEN)
                        {
                            //MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                            //clsRequtilisateurdroitDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            //clsRequtilisateurdroitDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            //clsRequtilisateurdroitDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            //clsRequtilisateurdroitDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            //clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTOR);
                        }


                    }


                    NBRETOUR = 1;
                    clsRequtilisateurdroitBOJ.TYPEOPERATION = clsRequtilisateurdroitDTO.clsObjetEnvoi.TYPEOPERATION;

                    //====
                    clsObjetRetour.SetValue(true, clsRequtilisateurdroitWSBLL.pvgMiseajour(_clsDonnee, clsRequtilisateurdroitBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                        clsRequtilisateurdroitDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsRequtilisateurdroitDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsRequtilisateurdroitDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsRequtilisateurdroitDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                        clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = e.Message;
                clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsRequtilisateurdroitDTOs[0];

        }
        public List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit> pvgListeUtilisateurDroit(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit> clsRequtilisateurdroitDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                    clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
                    return clsRequtilisateurdroitDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                    clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
                    return clsRequtilisateurdroitDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsRequtilisateurdroitWSBLL clsRequtilisateurdroitWSBLL = new clsRequtilisateurdroitWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsRequtilisateurdroitWSBLL.pvgChargerDansDataSet(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                                clsRequtilisateurdroitDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsRequtilisateurdroitDTOR.DP_CODEDROITCOMPTEUTULISATEUR = DataRow["DP_CODEDROITCOMPTEUTULISATEUR"].ToString();
                                clsRequtilisateurdroitDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();


                                clsRequtilisateurdroitDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsRequtilisateurdroitDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsRequtilisateurdroitDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                            clsRequtilisateurdroitDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsRequtilisateurdroitDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsRequtilisateurdroitDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsRequtilisateurdroitDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                        clsRequtilisateurdroitDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsRequtilisateurdroitDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsRequtilisateurdroitDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsRequtilisateurdroitDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = e.Message;
                clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsRequtilisateurdroitDTOs;

        }
        public List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit> pvgListeUtilisateurDroitCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit> clsRequtilisateurdroitDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                    clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
                    return clsRequtilisateurdroitDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                    clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
                    return clsRequtilisateurdroitDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsRequtilisateurdroitWSBLL clsRequtilisateurdroitWSBLL = new clsRequtilisateurdroitWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsRequtilisateurdroitWSBLL.pvgChargerDansDataSetPourCombo(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                                clsRequtilisateurdroitDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsRequtilisateurdroitDTOR.DP_CODEDROITCOMPTEUTULISATEUR = DataRow["DP_CODEDROITCOMPTEUTULISATEUR"].ToString();
                                clsRequtilisateurdroitDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsRequtilisateurdroitDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsRequtilisateurdroitDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                            clsRequtilisateurdroitDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsRequtilisateurdroitDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsRequtilisateurdroitDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsRequtilisateurdroitDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                        clsRequtilisateurdroitDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsRequtilisateurdroitDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsRequtilisateurdroitDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsRequtilisateurdroitDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = e.Message;
                clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsRequtilisateurdroitDTOs;

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit> pvgListeUtilisateurDroitInfo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit> clsRequtilisateurdroitDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                    clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
                    return clsRequtilisateurdroitDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                    clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsRequtilisateurdroitDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
                    return clsRequtilisateurdroitDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsRequtilisateurdroitWSBLL clsRequtilisateurdroitWSBLL = new clsRequtilisateurdroitWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsRequtilisateurdroitWSBLL.pvgChargerDansDataSetUtilisateurdroit(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                                clsRequtilisateurdroitDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsRequtilisateurdroitDTOR.DP_CODEDROITCOMPTEUTULISATEUR = DataRow["DP_CODEDROITCOMPTEUTULISATEUR"].ToString();
                                clsRequtilisateurdroitDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                clsRequtilisateurdroitDTOR.DP_LIBELLEDROITCOMPTEUTULISATEUR = DataRow["DP_LIBELLEDROITCOMPTEUTULISATEUR"].ToString();
                                clsRequtilisateurdroitDTOR.DP_COCHER = DataRow["DP_COCHER"].ToString();
                                clsRequtilisateurdroitDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsRequtilisateurdroitDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsRequtilisateurdroitDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                            clsRequtilisateurdroitDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsRequtilisateurdroitDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsRequtilisateurdroitDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsRequtilisateurdroitDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTOR = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                        clsRequtilisateurdroitDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsRequtilisateurdroitDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsRequtilisateurdroitDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsRequtilisateurdroitDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit clsRequtilisateurdroitDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit();
                clsRequtilisateurdroitDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsRequtilisateurdroitDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitDTO.clsResultat.SL_MESSAGE = e.Message;
                clsRequtilisateurdroitDTOs.Add(clsRequtilisateurdroitDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsRequtilisateurdroitDTOs;

        }



        #endregion UtilisateurDroit



        #region Reqrequete ETAPE
        public MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape pvgMajReqrequeteEtape(List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> clsReqrequeteetapeDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetape in Objets)
            {
                if (clsReqrequeteetape.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequeteetape.AT_INDEXETAPE) && (clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "2" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "3"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AT_INDEXETAPE";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs[0];
                }


                if (string.IsNullOrEmpty(clsReqrequeteetape.AG_CODEAGENCE) && (clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "3"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AG_CODEAGENCE";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequeteetape.RQ_CODEREQUETE) && (clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "3"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_CODEREQUETE";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequeteetape.RE_CODEETAPE) && (clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "3"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RE_CODEETAPE";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequeteetape.AT_NUMEROORDRE) && (clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AT_NUMEROORDRE";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequeteetape.AT_DESCRIPTION) && (clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AT_DESCRIPTION";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequeteetape.RQ_DATESAISIE) && (clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DATESAISIE";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequeteetape.AT_DATEDEBUTTRAITEMENTETAPE) && (clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AT_DATEDEBUTTRAITEMENTETAPE";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequeteetape.AT_DATECLOTUREETAPE) && (clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "3"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AT_DATECLOTUREETAPE";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequeteetape.CU_CODECOMPTEUTULISATEURAGENTENCHARGE) && (clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_CODECOMPTEUTULISATEURAGENTENCHARGE";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequeteetape.AT_DATEFINTRAITEMENTETAPE) && (clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AT_DATEFINTRAITEMENTETAPE";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs[0];
                }
            }

            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteetapeWSBLL clsReqrequeteetapeWSBLL = new clsReqrequeteetapeWSBLL();
                    //===
                    MgRequeteClients.BOJ.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeBOJ = new clsReqrequeteetape();
                    clsReqrequeteetapeBOJ.AT_INDEXETAPE = clsReqrequeteetapeDTO.AT_INDEXETAPE;
                    clsReqrequeteetapeBOJ.AG_CODEAGENCE = clsReqrequeteetapeDTO.AG_CODEAGENCE;
                    clsReqrequeteetapeBOJ.RQ_CODEREQUETE = clsReqrequeteetapeDTO.RQ_CODEREQUETE;
                    clsReqrequeteetapeBOJ.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = clsReqrequeteetapeDTO.CU_CODECOMPTEUTULISATEURAGENTENCHARGE;

                    clsReqrequeteetapeBOJ.RE_CODEETAPE = clsReqrequeteetapeDTO.RE_CODEETAPE;
                    clsReqrequeteetapeBOJ.AT_NUMEROORDRE = int.Parse(clsReqrequeteetapeDTO.AT_NUMEROORDRE);
                    clsReqrequeteetapeBOJ.AT_DESCRIPTION = clsReqrequeteetapeDTO.AT_DESCRIPTION;
                    clsReqrequeteetapeBOJ.RQ_DATESAISIE = DateTime.Parse(clsReqrequeteetapeDTO.RQ_DATESAISIE);
                    clsReqrequeteetapeBOJ.AT_DATEDEBUTTRAITEMENTETAPE = DateTime.Parse(clsReqrequeteetapeDTO.AT_DATEDEBUTTRAITEMENTETAPE);
                    clsReqrequeteetapeBOJ.AT_DATEFINTRAITEMENTETAPE = DateTime.Parse(clsReqrequeteetapeDTO.AT_DATEFINTRAITEMENTETAPE);
                    clsReqrequeteetapeBOJ.AT_DATECLOTUREETAPE = DateTime.Parse(clsReqrequeteetapeDTO.AT_DATECLOTUREETAPE);

                    clsReqrequeteetapeBOJ.AT_OBSERVATION = clsReqrequeteetapeDTO.AT_OBSERVATION;
                    clsReqrequeteetapeBOJ.AT_NOMRAPPORT = clsReqrequeteetapeDTO.AT_NOMRAPPORT;
                    clsReqrequeteetapeBOJ.AT_ACTIF = clsReqrequeteetapeDTO.AT_ACTIF;

                    clsReqrequeteetapeBOJ.TYPEOPERATION = clsReqrequeteetapeDTO.clsObjetEnvoi.TYPEOPERATION;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteetapeWSBLL.pvgMiseajour(_clsDonnee, clsReqrequeteetapeBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {

                        clsParams clsParams = new clsParams();
                        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();


                        MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                        string AG_CODEAGENCE = "";
                        string SM_TELEPHONE = "";
                        string SMSTEXT = "";
                        DateTime SM_DATEPIECE = clsReqrequeteetapeBOJ.RQ_DATESAISIE;
                        string TYPEOPERATION = "";
                        string SL_LIBELLE1 = "";
                        string SL_LIBELLE2 = "";
                        string TE_CODESMSTYPEOPERATION = "";
                        string CU_CODECOMPTEUTULISATEUR = "";

                        if (clsReqrequeteetapeBOJ.TYPEOPERATION == "5")
                        {
                            clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                            clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
                            clsObjetEnvoi.OE_PARAM = new string[] { clsReqrequeteetapeBOJ.CU_CODECOMPTEUTULISATEURAGENTENCHARGE };
                            clsReqcompteutilisateur = clsReqcompteutilisateurWSBLL.pvgTableLibelle(_clsDonnee, clsObjetEnvoi);

                            if (clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR != "")
                            {
                                AG_CODEAGENCE = clsReqcompteutilisateur.AG_CODEAGENCE; // ;
                                SM_TELEPHONE = clsReqcompteutilisateur.CU_CONTACT;
                                SMSTEXT = "Vous avez une nouvelle requette à traiter !!!";
                                SM_DATEPIECE = clsReqrequeteetapeBOJ.RQ_DATESAISIE;
                                TYPEOPERATION = "0";
                                SL_LIBELLE1 = "5";
                                SL_LIBELLE2 = "";
                                TE_CODESMSTYPEOPERATION = "0010";
                                CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;

                                //if (SM_TELEPHONE.Length == 10)
                                //    SM_TELEPHONE = "225" + SM_TELEPHONE;

                                //public clsParams pvgTraitementSmsSimple1(_clsDonnee clsDonnee, string AG_CODEAGENCE, string SM_TELEPHONE, string SMSTEXT, DateTime SM_DATEPIECE, string TYPEOPERATION, string TE_CODESMSTYPEOPERATION, string CU_CODECOMPTEUTULISATEUR, string SL_LIBELLE1, string SL_LIBELLE2)
                                clsParams = clsSmsoutWSBLL.pvgTraitementSmsSimple1(_clsDonnee, AG_CODEAGENCE, SM_TELEPHONE, SMSTEXT, SM_DATEPIECE, TYPEOPERATION, TE_CODESMSTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, SL_LIBELLE1, SL_LIBELLE2);

                            }
                        }

                        if (clsReqrequeteetapeBOJ.TYPEOPERATION == "0")
                        {
                            clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                            clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
                            clsObjetEnvoi.OE_PARAM = new string[] { clsReqrequeteetapeBOJ.CU_CODECOMPTEUTULISATEURAGENTENCHARGE };
                            clsReqcompteutilisateur = clsReqcompteutilisateurWSBLL.pvgTableLibelle(_clsDonnee, clsObjetEnvoi);

                            if (clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR != "")
                            {
                                AG_CODEAGENCE = clsReqcompteutilisateur.AG_CODEAGENCE; // ;
                                SM_TELEPHONE = clsReqcompteutilisateur.CU_CONTACT;
                                SMSTEXT = "Vous avez une nouvelle requette à traiter !!!";
                                SM_DATEPIECE = clsReqrequeteetapeBOJ.RQ_DATESAISIE;
                                TYPEOPERATION = "0";
                                SL_LIBELLE1 = "";
                                SL_LIBELLE2 = "";
                                TE_CODESMSTYPEOPERATION = "0003";
                                CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;

                                //if (SM_TELEPHONE.Length == 10)
                                //    SM_TELEPHONE = "225" + SM_TELEPHONE;

                                //public clsParams pvgTraitementSmsSimple1(_clsDonnee clsDonnee, string AG_CODEAGENCE, string SM_TELEPHONE, string SMSTEXT, DateTime SM_DATEPIECE, string TYPEOPERATION, string TE_CODESMSTYPEOPERATION, string CU_CODECOMPTEUTULISATEUR, string SL_LIBELLE1, string SL_LIBELLE2)
                                clsParams = clsSmsoutWSBLL.pvgTraitementSmsSimple1(_clsDonnee, AG_CODEAGENCE, SM_TELEPHONE, SMSTEXT, SM_DATEPIECE, TYPEOPERATION, TE_CODESMSTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, SL_LIBELLE1, SL_LIBELLE2);

                            }



                            clsObjetEnvoi = new clsObjetEnvoi();
                            //clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                            //===
                            clsObjetEnvoi.OE_PARAM = new string[] { "0001", clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR, "", "", "02" };
                            MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                            //====
                            clsObjetRetour.SetValue(true, clsReqcompteutilisateurWSBLL.pvgChargerDansDataSetRechercheUtilisateur(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                            if (clsObjetRetour.OR_BOOLEEN)
                            {
                                if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                                    {

                                        clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                        clsReqcompteutilisateurDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                        clsReqcompteutilisateurDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                        clsReqcompteutilisateurDTOR.TU_CODETYPEUTILISATEUR = DataRow["TU_CODETYPEUTILISATEUR"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_NUMEROUTILISATEUR = DataRow["CU_NUMEROUTILISATEUR"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = DataRow["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_LOGIN = DataRow["CU_LOGIN"].ToString();
                                        clsReqcompteutilisateurDTOR.CU_MOTDEPASSE = DataRow["CU_MOTDEPASSE"].ToString();

                                    }
                                }



                            }

                            //Envoi Email 
                            if (clsReqcompteutilisateurDTOR.CU_EMAIL != "")
                            {
                                string AG_EMAIL = "";
                                string AG_EMAILMOTDEPASSE = "";
                                string AG_RAISONSOCIAL = "";
                                clsReqniveausatisfactionWSBLL clsReqniveausatisfactionWSBLL = new clsReqniveausatisfactionWSBLL();
                                DataSet DataSet = new DataSet();
                                clsObjetEnvoi.OE_PARAM = new string[] { clsReqcompteutilisateurDTOR.AG_CODEAGENCE };
                                DataSet = clsReqniveausatisfactionWSBLL.pvgChargerDansDataSetAgence(_clsDonnee, clsObjetEnvoi);
                                foreach (DataRow row in DataSet.Tables[0].Rows)
                                {
                                    AG_EMAIL = row["AG_EMAIL"].ToString();
                                    AG_EMAILMOTDEPASSE = row["AG_EMAILMOTDEPASSE"].ToString();
                                    AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                                }

                                // Paramètres du serveur SMTP
                                string smtpServeur = "smtp.gmail.com";
                                int portSmtp = 587;
                                string adresseEmail = AG_EMAIL;//"bolatykouassieuloge@gmail.com";
                                string motDePasse = AG_EMAILMOTDEPASSE;//"nffncgqonuuildmc";

                                // Destinataire et contenu de l'e-mail
                                string destinataire = clsReqcompteutilisateurDTOR.CU_EMAIL;// "technicosup@mgdigitalplus.com";
                                string sujet = "Attribution d'etape sur Reclamation";
                                string corpsMessage = clsParams.SMSTEXT;// "De la " + AG_RAISONSOCIAL + ", Une nouvelle sur une réclamation vous est attribuée,son statut est disponible via le lien http://51.210.111.16:1011 login : " + clsReqcompteutilisateurDTOR.CU_LOGIN + " Mot de passe : " + clsReqcompteutilisateurDTOR.CU_MOTDEPASSE;

                                // Création de l'objet MailMessage
                                MailMessage message = new MailMessage(adresseEmail, destinataire, sujet, corpsMessage);

                                // Création de l'objet SmtpClient
                                SmtpClient clientSmtp = new SmtpClient(smtpServeur, portSmtp);
                                clientSmtp.UseDefaultCredentials = false;
                                clientSmtp.Credentials = new NetworkCredential(adresseEmail, motDePasse);
                                clientSmtp.EnableSsl = true;

                                // Envoi de l'e-mail
                                clientSmtp.Send(message);

                            }
                        }


                        //if (clsReqrequeteetapeBOJ.TYPEOPERATION == "3")
                        //{

                        //    clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
                        //    clsReqrequete clsReqrequete = new clsReqrequete();
                        //    clsObjetEnvoi clsObjetEnvoi1 = new clsObjetEnvoi();
                        //    clsObjetEnvoi1.OE_PARAM = new string[] { clsReqrequeteetapeBOJ.RQ_CODEREQUETE }; ;
                        //    clsReqrequete = clsReqrequeteWSBLL.pvgTableLibelle(_clsDonnee, clsObjetEnvoi1);

                        //    clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                        //    clsReqcompteutilisateur clsReqcompteutilisateur = new clsReqcompteutilisateur();
                        //    clsObjetEnvoi.OE_PARAM = new string[] { clsReqrequete.CU_CODECOMPTEUTULISATEUR }; ;
                        //    clsReqcompteutilisateur = clsReqcompteutilisateurWSBLL.pvgTableLibelle(_clsDonnee, clsObjetEnvoi);

                        //    if (clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR != "")
                        //    {
                        //        AG_CODEAGENCE = clsReqcompteutilisateur.AG_CODEAGENCE;
                        //        SM_TELEPHONE = clsReqcompteutilisateur.CU_CONTACT;
                        //        SMSTEXT = "Votre requette a été totalement traitée !!!";
                        //        SM_DATEPIECE = clsReqrequeteetapeBOJ.RQ_DATESAISIE;
                        //        TYPEOPERATION = "";
                        //        SL_LIBELLE1 = "";
                        //        SL_LIBELLE2 = "";
                        //        TE_CODESMSTYPEOPERATION = "0004";
                        //        CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR;
                        //        clsParams clsParams = new clsParams();
                        //        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                        //        clsParams = clsSmsoutWSBLL.pvgTraitementSmsSimple1(_clsDonnee, AG_CODEAGENCE, SM_TELEPHONE, SMSTEXT, SM_DATEPIECE, TYPEOPERATION, TE_CODESMSTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, SL_LIBELLE1, SL_LIBELLE2);

                        //    }
                        //}

                        clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                        clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteetapeDTOs[0];

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> pvgListeReqrequeteEtapeparRequete(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> clsReqrequeteetapeDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs;
                }
            }

            try
            {
                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteetapeWSBLL clsReqrequeteetapeWSBLL = new clsReqrequeteetapeWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteetapeWSBLL.pvgListeReqrequeteEtapeparRequete(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                                clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteetapeDTOR.AT_INDEXETAPE = DataRow["AT_INDEXETAPE"].ToString();
                                clsReqrequeteetapeDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                clsReqrequeteetapeDTOR.RQ_CODEREQUETE = DataRow["RQ_CODEREQUETE"].ToString();
                                clsReqrequeteetapeDTOR.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = DataRow["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
                                clsReqrequeteetapeDTOR.RE_CODEETAPE = DataRow["RE_CODEETAPE"].ToString();
                                clsReqrequeteetapeDTOR.AT_NUMEROORDRE = DataRow["AT_NUMEROORDRE"].ToString();
                                clsReqrequeteetapeDTOR.AT_DESCRIPTION = DataRow["AT_DESCRIPTION"].ToString();
                                clsReqrequeteetapeDTOR.RQ_DATESAISIE = DataRow["RQ_DATESAISIE"].ToString();
                                clsReqrequeteetapeDTOR.AT_DATEDEBUTTRAITEMENTETAPE = DataRow["AT_DATEDEBUTTRAITEMENTETAPE"].ToString();
                                clsReqrequeteetapeDTOR.AT_DATEFINTRAITEMENTETAPE = clsDate.ClasseDate.pvgFormaterDate(DataRow["AT_DATEFINTRAITEMENTETAPE"].ToString()); //  DataRow["AT_DATECLOTUREETAPE"].ToString();
                                clsReqrequeteetapeDTOR.AT_DATECLOTUREETAPE = clsDate.ClasseDate.pvgFormaterDate(DataRow["AT_DATECLOTUREETAPE"].ToString()); //  DataRow["AT_DATECLOTUREETAPE"].ToString();


                                clsReqrequeteetapeDTOR.NS_CODENIVEAUSATISFACTION = DataRow["NS_CODENIVEAUSATISFACTION"].ToString();
                                clsReqrequeteetapeDTOR.AT_OBSERVATION = DataRow["AT_OBSERVATION"].ToString();
                                clsReqrequeteetapeDTOR.AT_NOMRAPPORT = DataRow["AT_NOMRAPPORT"].ToString();
                                clsReqrequeteetapeDTOR.AT_ACTIF = DataRow["AT_ACTIF"].ToString();
                                clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                            clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                        clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteetapeDTOs;

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgListeReqrequeteDoc(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs;
                }
            }

            try
            {
                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteetapeWSBLL clsReqrequeteetapeWSBLL = new clsReqrequeteetapeWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //==== appel 1 • pour le doc sur les requetes
                    clsObjetRetour.SetValue(true, clsReqrequeteetapeWSBLL.pvgListeReqrequeteDoc(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequete = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                            clsReqrequete.clsDocumentAssociesALaRequetes = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                                clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteDTOR.RQ_NOMRAPPORT = DataRow["RQ_NOMRAPPORT"].ToString();
                                clsReqrequeteDTOR.RQ_CODEREQUETE = DataRow["RQ_CODEREQUETE"].ToString();

                                clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;

                                clsReqrequete.clsDocumentAssociesALaRequetes.Add(clsReqrequeteDTOR);
                            }

                            clsReqrequeteDTOs.Add(clsReqrequete);
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                    }

                    //==== appel 2 • pour le doc sur les contentieux
                    if (clsObjetEnvoi.OE_PARAM[1] != "")
                    {
                        clsObjetRetour.SetValue(true, clsReqrequeteetapeWSBLL.pvgListeReqrequeteContentieuxDoc(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                        if (clsObjetRetour.OR_BOOLEEN)
                        {
                            if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequete = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                                clsReqrequete.clsDocumentAssociesAuContentieux = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();
                                foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                                {
                                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                                    clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                    clsReqrequeteDTOR.FICHIERSJOINT = DataRow["FICHIERSJOINT"].ToString();
                                    clsReqrequeteDTOR.CT_CODEREQUETECONTENTIEUX = DataRow["CT_CODEREQUETECONTENTIEUX"].ToString();

                                    clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                    clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                    clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;

                                    clsReqrequete.clsDocumentAssociesAuContentieux.Add(clsReqrequeteDTOR);
                                }

                                clsReqrequeteDTOs.Add(clsReqrequete);
                            }
                            else
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                                clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                                clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                                clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                                clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                        }
                    }
                }
            }
            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }

            return clsReqrequeteDTOs;
        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient> pvgInfosDuClient(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient> clsReqinfosduclientDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            try
            {
                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteetapeWSBLL clsReqrequeteetapeWSBLL = new clsReqrequeteetapeWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    clsObjetRetour.SetValue(true, clsReqrequeteetapeWSBLL.pvgInfosDuClient(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient clsReqinfosduclientDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient();
                                clsReqinfosduclientDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqinfosduclientDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                clsReqinfosduclientDTOR.TU_CODETYPEUTILISATEUR = DataRow["TU_CODETYPEUTILISATEUR"].ToString();
                                clsReqinfosduclientDTOR.CU_NUMEROUTILISATEUR = DataRow["CU_NUMEROUTILISATEUR"].ToString();
                                clsReqinfosduclientDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = DataRow["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                                clsReqinfosduclientDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                                clsReqinfosduclientDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                                clsReqinfosduclientDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();

                                //if (clsObjetEnvoi.OE_PARAM.Length > 1)
                                if (clsObjetEnvoi.OE_PARAM[1] != "")
                                {
                                    clsReqinfosduclientDTOR.CU_NOMUTILISATEURASSOCIER = DataRow["CU_NOMUTILISATEURASSOCIER"].ToString();
                                    clsReqinfosduclientDTOR.CU_CONTACTUTILISATEURASSOCIER = DataRow["CU_CONTACTUTILISATEURASSOCIER"].ToString();
                                    clsReqinfosduclientDTOR.CU_EMAILUTILISATEURASSOCIER = DataRow["CU_EMAILUTILISATEURASSOCIER"].ToString();

                                }

                                clsReqinfosduclientDTOR.CU_DATECREATION = clsDate.ClasseDate.pvgFormaterDate(DataRow["CU_DATECREATION"].ToString());
                                clsReqinfosduclientDTOR.CU_DATECLOTURE = clsDate.ClasseDate.pvgFormaterDate(DataRow["CU_DATECLOTURE"].ToString());
                                clsReqinfosduclientDTOR.PI_CODEPIECE = DataRow["PI_CODEPIECE"].ToString();
                                clsReqinfosduclientDTOR.CU_NUMEROPIECE = DataRow["CU_NUMEROPIECE"].ToString();
                                clsReqinfosduclientDTOR.CU_DATEPIECE = clsDate.ClasseDate.pvgFormaterDate(DataRow["CU_DATEPIECE"].ToString());

                                clsReqinfosduclientDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqinfosduclientDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqinfosduclientDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqinfosduclientDTOs.Add(clsReqinfosduclientDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient clsReqinfosduclientDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient();
                            clsReqinfosduclientDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqinfosduclientDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqinfosduclientDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqinfosduclientDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqinfosduclientDTOs.Add(clsReqinfosduclientDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient clsReqinfosduclientDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient();
                        clsReqinfosduclientDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqinfosduclientDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqinfosduclientDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqinfosduclientDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqinfosduclientDTOs.Add(clsReqinfosduclientDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient clsReqinfosduclientDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient();
                clsReqinfosduclientDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqinfosduclientDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqinfosduclientDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqinfosduclientDTOs.Add(clsReqinfosduclientDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient clsReqinfosduclientDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient();
                clsReqinfosduclientDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqinfosduclientDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqinfosduclientDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqinfosduclientDTOs.Add(clsReqinfosduclientDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }

            return clsReqinfosduclientDTOs;
        }


        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> pvgListeReqrequeteEtape(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> clsReqrequeteetapeDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteetapeWSBLL clsReqrequeteetapeWSBLL = new clsReqrequeteetapeWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteetapeWSBLL.pvgChargerDansDataSet(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                                clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteetapeDTOR.AT_INDEXETAPE = DataRow["AT_INDEXETAPE"].ToString();
                                clsReqrequeteetapeDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                clsReqrequeteetapeDTOR.RQ_CODEREQUETE = DataRow["RQ_CODEREQUETE"].ToString();
                                clsReqrequeteetapeDTOR.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = DataRow["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
                                clsReqrequeteetapeDTOR.RE_CODEETAPE = DataRow["RE_CODEETAPE"].ToString();
                                clsReqrequeteetapeDTOR.AT_NUMEROORDRE = DataRow["AT_NUMEROORDRE"].ToString();
                                clsReqrequeteetapeDTOR.AT_DESCRIPTION = DataRow["AT_DESCRIPTION"].ToString();
                                clsReqrequeteetapeDTOR.RQ_DATESAISIE = DataRow["RQ_DATESAISIE"].ToString();
                                clsReqrequeteetapeDTOR.AT_DATEDEBUTTRAITEMENTETAPE = DataRow["AT_DATEDEBUTTRAITEMENTETAPE"].ToString();
                                clsReqrequeteetapeDTOR.AT_DATEFINTRAITEMENTETAPE = clsDate.ClasseDate.pvgFormaterDate(DataRow["AT_DATEFINTRAITEMENTETAPE"].ToString()); //  DataRow["AT_DATECLOTUREETAPE"].ToString();
                                clsReqrequeteetapeDTOR.AT_DATECLOTUREETAPE = clsDate.ClasseDate.pvgFormaterDate(DataRow["AT_DATECLOTUREETAPE"].ToString()); //  DataRow["AT_DATECLOTUREETAPE"].ToString();


                                clsReqrequeteetapeDTOR.NS_CODENIVEAUSATISFACTION = DataRow["NS_CODENIVEAUSATISFACTION"].ToString();
                                clsReqrequeteetapeDTOR.AT_OBSERVATION = DataRow["AT_OBSERVATION"].ToString();
                                clsReqrequeteetapeDTOR.AT_NOMRAPPORT = DataRow["AT_NOMRAPPORT"].ToString();
                                clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                            clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                        clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteetapeDTOs;

        }
        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> pvgListeReqrequeteEtapeCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> clsReqrequeteetapeDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteetapeWSBLL clsReqrequeteetapeWSBLL = new clsReqrequeteetapeWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteetapeWSBLL.pvgChargerDansDataSetPourCombo(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                                clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteetapeDTOR.AT_INDEXETAPE = DataRow["AT_INDEXETAPE"].ToString();
                                clsReqrequeteetapeDTOR.AT_DESCRIPTION = DataRow["AT_DESCRIPTION"].ToString();
                                clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                            clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                        clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteetapeDTOs;

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> pvgListeReqrequeteEtapeConsultation(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> clsReqrequeteetapeDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                    clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
                    return clsReqrequeteetapeDTOs;
                }

            }

            try
            {
                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteetapeWSBLL clsReqrequeteetapeWSBLL = new clsReqrequeteetapeWSBLL();

                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    clsObjetRetour.SetValue(true, clsReqrequeteetapeWSBLL.pvgChargerDansDataSetTraitement(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                                clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteetapeDTOR.AT_INDEXETAPE = DataRow["AT_INDEXETAPE"].ToString();
                                clsReqrequeteetapeDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                clsReqrequeteetapeDTOR.RQ_CODEREQUETE = DataRow["RQ_CODEREQUETE"].ToString();
                                clsReqrequeteetapeDTOR.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = DataRow["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
                                clsReqrequeteetapeDTOR.RE_CODEETAPE = DataRow["RE_CODEETAPE"].ToString();
                                clsReqrequeteetapeDTOR.AT_NUMEROORDRE = DataRow["AT_NUMEROORDRE"].ToString();
                                clsReqrequeteetapeDTOR.AT_DESCRIPTION = DataRow["AT_DESCRIPTION"].ToString();
                                clsReqrequeteetapeDTOR.RQ_DATESAISIE = DataRow["RQ_DATESAISIE"].ToString();
                                clsReqrequeteetapeDTOR.AT_DATEDEBUTTRAITEMENTETAPE = DataRow["AT_DATEDEBUTTRAITEMENTETAPE"].ToString();
                                clsReqrequeteetapeDTOR.AT_DATEFINTRAITEMENTETAPE = clsDate.ClasseDate.pvgFormaterDate(DataRow["AT_DATEFINTRAITEMENTETAPE"].ToString()); //  DataRow["AT_DATECLOTUREETAPE"].ToString();
                                clsReqrequeteetapeDTOR.AT_DATECLOTUREETAPE = clsDate.ClasseDate.pvgFormaterDate(DataRow["AT_DATECLOTUREETAPE"].ToString()); //  DataRow["AT_DATECLOTUREETAPE"].ToString();

                                clsReqrequeteetapeDTOR.NS_CODENIVEAUSATISFACTION = DataRow["NS_CODENIVEAUSATISFACTION"].ToString();
                                clsReqrequeteetapeDTOR.AT_OBSERVATION = DataRow["AT_OBSERVATION"].ToString();
                                clsReqrequeteetapeDTOR.AT_NOMRAPPORT = DataRow["AT_NOMRAPPORT"].ToString();
                                clsReqrequeteetapeDTOR.RQ_OBSERVATIONCLOTUREDEFINITIVE = DataRow["RQ_OBSERVATIONCLOTUREDEFINITIVE"].ToString();
                                clsReqrequeteetapeDTOR.RQ_OBSERVATIONANNULATIONCLOTUREDEFINITIVE = DataRow["RQ_OBSERVATIONANNULATIONCLOTUREDEFINITIVE"].ToString();


                                clsReqrequeteetapeDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                                clsReqrequeteetapeDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                                clsReqrequeteetapeDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();

                                //if (clsReqrequeteetapeDTOR.AT_NOMRAPPORT != "")
                                //    clsReqrequeteetapeDTOR.AT_NOMRAPPORT =  ConfigurationManager.AppSettings["URL_ROOT_DOSSIER"] + clsReqrequeteetapeDTOR.AT_NOMRAPPORT;

                                // --------------------------------------------------------------------- laaa
                                clsObjetEnvoi.OE_PARAM = new string[] { clsReqrequeteetapeDTOR.AT_INDEXETAPE, clsReqrequeteetapeDTOR.AG_CODEAGENCE };

                                clsObjetRetour.SetValue(true, clsReqrequeteetapeWSBLL.pvgChargerDansDataSetTraitementDoc(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                                if (clsObjetRetour.OR_BOOLEEN)
                                {
                                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                                    {
                                        clsReqrequeteetapeDTOR.clsDocEtapesDetails = new List<MgRequeteClients.DTO.BusinessObjects.clsDocEtapesDetail>();

                                        foreach (DataRow DataRow2 in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                                        {
                                            MgRequeteClients.DTO.BusinessObjects.clsDocEtapesDetail clsDocEtapesDetailDTOR = new MgRequeteClients.DTO.BusinessObjects.clsDocEtapesDetail();
                                            clsDocEtapesDetailDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                            clsDocEtapesDetailDTOR.AT_CODEDOC = DataRow2["AT_CODEDOC"].ToString();
                                            clsDocEtapesDetailDTOR.AT_NOMRAPPORT = DataRow2["AT_NOMRAPPORT"].ToString();

                                            //if (clsDocEtapesDetailDTOR.AT_NOMRAPPORT != "")
                                            //    clsDocEtapesDetailDTOR.AT_NOMRAPPORT = ConfigurationManager.AppSettings["URL_ROOT_DOSSIER"] + clsDocEtapesDetailDTOR.AT_NOMRAPPORT;

                                            clsDocEtapesDetailDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                            clsDocEtapesDetailDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                            clsDocEtapesDetailDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                            clsReqrequeteetapeDTOR.clsDocEtapesDetails.Add(clsDocEtapesDetailDTOR);
                                        }
                                    }
                                }

                                clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                                // ---------------------------------------------------------------------
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                            clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                        clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteetapeDTOs;

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgChargerDansDataSetListeHistorique(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                    clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                    clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                }

            }

            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteetapeWSBLL clsReqrequeteetapeWSBLL = new clsReqrequeteetapeWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;
                    MgRequeteClients.BOJ.BusinessObjects.clsReqrequete clsReqrequeteAffichage = new MgRequeteClients.BOJ.BusinessObjects.clsReqrequete();

                    clsObjetRetour.SetValue(true, clsReqrequeteetapeWSBLL.pvgChargerDansDataSetHistorique(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);

                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                                clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteDTOR.NR_CODENATUREREQUETE = DataRow["NR_CODENATUREREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_CODEREQUETE = DataRow["RQ_CODEREQUETE"].ToString();
                                clsReqrequeteDTOR.TR_CODETYEREQUETE = DataRow["TR_CODETYEREQUETE"].ToString();
                                clsReqrequeteDTOR.TR_LIBELLETYEREQUETE = DataRow["TR_LIBELLETYEREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_NUMEROREQUETE = DataRow["RQ_NUMEROREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_NUMERORECOMPTE = DataRow["RQ_NUMERORECOMPTE"].ToString();
                                clsReqrequeteDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                clsReqrequeteDTOR.RQ_LOCALISATIONCLIENT = DataRow["RQ_LOCALISATIONCLIENT"].ToString();
                                clsReqrequeteDTOR.RQ_DESCRIPTIONREQUETE = DataRow["RQ_DESCRIPTIONREQUETE"].ToString();
                                clsReqrequeteDTOR.MC_CODEMODECOLLETE = DataRow["MC_CODEMODECOLLETE"].ToString();
                                clsReqrequeteDTOR.RQ_DATESAISIEREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATESAISIEREQUETE"].ToString()); //  DataRow["RQ_DATESAISIEREQUETE"].ToString();
                                clsReqrequeteDTOR.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = DataRow["CU_CODECOMPTEUTULISATEURAGENTENCHARGE"].ToString();
                                clsReqrequeteDTOR.RQ_DATETRANSFERTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATETRANSFERTREQUETE"].ToString()); //  DataRow["RQ_DATETRANSFERTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_CODEREQUETERELANCEE = DataRow["RQ_CODEREQUETERELANCEE"].ToString();
                                clsReqrequeteDTOR.RQ_SIGNATURE = DataRow["RQ_SIGNATURE"].ToString();
                                clsReqrequeteDTOR.RS_CODESTATUTRECEVABILITE = DataRow["RS_CODESTATUTRECEVABILITE"].ToString();
                                clsReqrequeteDTOR.RQ_OBJETREQUETE = DataRow["RQ_OBJETREQUETE"].ToString();
                                clsReqrequeteDTOR.SR_CODESERVICE = DataRow["SR_CODESERVICE"].ToString();
                                clsReqrequeteDTOR.RQ_DELAITRAITEMENTREQUETE = DataRow["RQ_DELAITRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_OBSERVATIONDELAITRAITEMENTREQUETE = DataRow["RQ_OBSERVATIONDELAITRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = DataRow["RQ_OBSERVATIONAGENTTRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_DUREETRAITEMENTREQUETE = DataRow["RQ_DUREETRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_DATEDEBUTTRAITEMENTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATEDEBUTTRAITEMENTREQUETE"].ToString()); // DataRow["RQ_DATEDEBUTTRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.RQ_DATEFINTRAITEMENTREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATEFINTRAITEMENTREQUETE"].ToString()); // DataRow["RQ_DATEFINTRAITEMENTREQUETE"].ToString();
                                clsReqrequeteDTOR.AC_CODEACTIONCORRECTIVE = DataRow["AC_CODEACTIONCORRECTIVE"].ToString();
                                clsReqrequeteDTOR.NS_CODENIVEAUSATISFACTION = DataRow["NS_CODENIVEAUSATISFACTION"].ToString();
                                clsReqrequeteDTOR.RE_CODEETAPE = DataRow["RE_CODEETAPE"].ToString();
                                clsReqrequeteDTOR.RE_LIBELLEETAPE = DataRow["RE_LIBELLEETAPE"].ToString();
                                clsReqrequeteDTOR.RE_LIBELLEETAPE_TRANSLATE = "";
                                clsReqrequeteDTOR.RQ_AFFICHERINFOCLIENT = DataRow["RQ_AFFICHERINFOCLIENT"].ToString();
                                clsReqrequeteDTOR.AT_INDEXETAPE = DataRow["AT_INDEXETAPE"].ToString();

                                clsReqrequeteDTOR.RQ_NOMRAPPORT = DataRow["RQ_NOMRAPPORT"].ToString();
                                clsReqrequeteDTOR.RQ_LIENRAPPORT = _configuration.GetSection("ApiEndpoints:URL_ROOT_DOSSIER").Value ?? string.Empty;//ConfigurationManager.AppSettings["URL_ROOT_DOSSIER"];

                                clsReqrequeteDTOR.AT_DATECLOTUREETAPE = ((DateTime)DataRow["AT_DATECLOTUREETAPE"]).ToShortDateString(); //DataRow["AT_DATECLOTUREETAPE"].ToShortd();
                                clsReqrequeteDTOR.AT_DATEDEBUTTRAITEMENTETAPE = ((DateTime)DataRow["AT_DATEDEBUTTRAITEMENTETAPE"]).ToShortDateString();// DataRow["AT_DATEDEBUTTRAITEMENTETAPE"].ToString();
                                clsReqrequeteDTOR.AT_DATEFINTRAITEMENTETAPE = ((DateTime)DataRow["AT_DATEFINTRAITEMENTETAPE"]).ToShortDateString();// DataRow["AT_DATEFINTRAITEMENTETAPE"].ToString();
                                if (clsReqrequeteDTOR.RQ_AFFICHERINFOCLIENT == "O")
                                {
                                    clsReqrequeteDTOR.CU_NUMEROUTILISATEUR = DataRow["CU_NUMEROUTILISATEUR"].ToString();
                                    clsReqrequeteDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = DataRow["CU_ADRESSEGEOGRAPHIQUEUTILISATEUR"].ToString();
                                    clsReqrequeteDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                                    clsReqrequeteDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                                    clsReqrequeteDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();
                                }
                                else
                                {
                                    clsReqrequeteDTOR.CU_NUMEROUTILISATEUR = "";
                                    clsReqrequeteDTOR.CU_ADRESSEGEOGRAPHIQUEUTILISATEUR = "";
                                    clsReqrequeteDTOR.CU_NOMUTILISATEUR = "";
                                    clsReqrequeteDTOR.CU_CONTACT = "";
                                    clsReqrequeteDTOR.CU_EMAIL = "";
                                }

                                clsReqrequeteDTOR.RQ_DATECLOTUREREQUETE = clsDate.ClasseDate.pvgFormaterDate(DataRow["RQ_DATECLOTUREREQUETE"].ToString()); // DataRow["RQ_DATECLOTUREREQUETE"].ToString();
                                clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                    }

                }
            }
            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }

            return clsReqrequeteDTOs;
        }

        public MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape pvgpvgMajReqrequeteEtapeUPloadFile()
        {

            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> clsReqrequeteetapeDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape>();

            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            try
            {
                _clsDonnee.pvgDemarrerTransaction();

                clsObjetEnvoi = new clsObjetEnvoi();
                clsReqrequeteetapeWSBLL clsReqrequeteetapeWSBLL = new clsReqrequeteetapeWSBLL();

                MgRequeteClients.BOJ.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeBOJ = new clsReqrequeteetape();
                if (clsDeclaration.AG_CODEAGENCE != null)
                    clsReqrequeteetapeBOJ.AG_CODEAGENCE = clsDeclaration.AG_CODEAGENCE[0];
                if (clsDeclaration.RQ_CODEREQUETE != null)
                    clsReqrequeteetapeBOJ.RQ_CODEREQUETE = clsDeclaration.RQ_CODEREQUETE[0];
                if (clsDeclaration.AT_INDEXETAPE != null)
                    clsReqrequeteetapeBOJ.AT_INDEXETAPE = clsDeclaration.AT_INDEXETAPE[0];
                if (clsDeclaration.AT_DATEFINTRAITEMENTETAPE != null)
                    clsReqrequeteetapeBOJ.AT_DATEFINTRAITEMENTETAPE = DateTime.Parse(clsDeclaration.AT_DATEFINTRAITEMENTETAPE[0]);
                if (clsDeclaration.RE_CODEETAPE != null)
                    clsReqrequeteetapeBOJ.RE_CODEETAPE = clsDeclaration.RE_CODEETAPE[0];
                if (clsDeclaration.AT_OBSERVATION != null)
                    clsReqrequeteetapeBOJ.AT_OBSERVATION = clsDeclaration.AT_OBSERVATION[0];

                if (clsDeclaration.DOCS_FICHIERS != null)
                {
                    foreach (var file in clsDeclaration.DOCS_FICHIERS)
                    {
                        clsReqrequeteetapeBOJ.AT_NOMRAPPORT = file.Replace(" ", "");

                        clsReqrequeteetapeBOJ.TYPEOPERATION = "4";

                        clsObjetRetour.SetValue(true, clsReqrequeteetapeWSBLL.pvgMiseajour(_clsDonnee, clsReqrequeteetapeBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                        if (clsObjetRetour.OR_BOOLEEN)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                            clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;

                            clsReqrequeteetapeDTOR.AT_NOMRAPPORT = clsReqrequeteetapeBOJ.AT_NOMRAPPORT;
                            clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                            clsReqrequeteetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_CODE_REQUIS;
                            clsReqrequeteetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_OPERATION_NON_EFFECTUEE;
                            clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTOR);
                        }
                    }
                }
            }
            catch (SqlException SQLEx)
            {
                // MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape clsReqrequeteetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape();
                clsReqrequeteetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteetapeDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteetapeDTOs.Add(clsReqrequeteetapeDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
                //_clsDonnee.pvgDeConnectionBase();
            }

            return clsReqrequeteetapeDTOs[0];
        }


        public MgRequeteClients.DTO.BusinessObjects.clsReqrequete pvgpvgMajReqrequeteUPloadFile()
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            try
            {
                _clsDonnee.pvgDemarrerTransaction();

                clsObjetEnvoi = new clsObjetEnvoi();
                clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();

                MgRequeteClients.BOJ.BusinessObjects.clsReqrequete clsReqrequeteBOJ = new clsReqrequete();
                if (clsDeclaration.RQ_CODEREQUETE != null)
                    clsReqrequeteBOJ.RQ_CODEREQUETE = clsDeclaration.RQ_CODEREQUETE[0];
                if (clsDeclaration.DOCS_FICHIERS != null)
                {
                    foreach (var file in clsDeclaration.DOCS_FICHIERS)
                    {
                        clsReqrequeteBOJ.RQ_NOMRAPPORT = file.Replace(" ", "");

                        clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgMiseajour2(_clsDonnee, clsReqrequeteBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                        if (clsObjetRetour.OR_BOOLEEN)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;

                            clsReqrequeteDTOR.RQ_NOMRAPPORT = clsReqrequeteBOJ.RQ_NOMRAPPORT;
                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_CODE_REQUIS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_OPERATION_NON_EFFECTUEE;
                            clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                        }
                    }
                }
            }
            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }

            return clsReqrequeteDTOs[0];
        }


        // ----------------------------------------------------------- new file save
        //public MgRequeteClients.DTO.BusinessObjects.clsReqrequete pvgpvgMajReqrequeteUPloadFile(List<IFormFile> files, string rq_coderequete)
        //{
        //    clsObjetRetour clsObjetRetour = new clsObjetRetour();
        //    clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
        //    clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
        //    clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
        //    _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //    _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
        //    List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();

        //    var culture = new System.Globalization.CultureInfo("fr-FR");
        //    Thread.CurrentThread.CurrentCulture = culture;

        //    try
        //    {
        //        _clsDonnee.pvgDemarrerTransaction();
        //        clsObjetEnvoi = new clsObjetEnvoi();
        //        clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();

        //        foreach (var file in files)
        //        {
        //            // ===
        //            MgRequeteClients.BOJ.BusinessObjects.clsReqrequete clsReqrequeteBOJ = new BOJ.clsReqrequete();
        //            if (clsDeclaration.RQ_CODEREQUETE != null)
        //                clsReqrequeteBOJ.RQ_CODEREQUETE = clsDeclaration.RQ_CODEREQUETE[0];
        //            if (file != null)
        //                clsReqrequeteBOJ.RQ_NOMRAPPORT = file.FileName.Replace(" ", "");

        //            clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgMiseajour2(_clsDonnee, clsReqrequeteBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
        //            if (clsObjetRetour.OR_BOOLEEN)
        //            {
        //                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
        //                clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
        //                clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
        //                clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
        //                clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
        //                clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
        //            }
        //            else
        //            {
        //                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
        //                clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
        //                clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_CODE_REQUIS;
        //                clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
        //                clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_OPERATION_NON_EFFECTUEE;
        //                clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
        //            }
        //        }
        //    }
        //    catch (SqlException SQLEx)
        //    {
        //        MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
        //        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
        //        clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
        //        clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
        //        clsReqrequeteDTOs.Add(clsReqrequeteDTO);
        //    }
        //    catch (Exception e)
        //    {
        //        MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
        //        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
        //        clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
        //        clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
        //        clsReqrequeteDTOs.Add(clsReqrequeteDTO);
        //    }
        //    finally
        //    {
        //        _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
        //    }

        //    return clsReqrequeteDTOs[0];
        //}
        // ----------------------------------------------------------- new file save

        #endregion Reqrequete ETAPE

        #region Reqrequete ETAPE param
        public MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape pvgMajReqrequeteEtapeParam(List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape> clsReqrequeteparetapeDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetape in Objets)
            {
                if (clsReqrequeteparetape.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                    return clsReqrequeteparetapeDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                    return clsReqrequeteparetapeDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequeteparetape.RE_CODEETAPE) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "2"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RE_CODEETAPE";
                    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                    return clsReqrequeteparetapeDTOs[0];
                }


                if (string.IsNullOrEmpty(clsReqrequeteparetape.RE_LIBELLEETAPE) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RE_LIBELLEETAPE";
                    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                    return clsReqrequeteparetapeDTOs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequeteparetape.RE_ACTIF) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RE_ACTIF";
                    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                    return clsReqrequeteparetapeDTOs[0];
                }

                if (string.IsNullOrEmpty(clsReqrequeteparetape.RE_CODEETAPE) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RE_CODEETAPE";
                    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                    return clsReqrequeteparetapeDTOs[0];
                }









                //if (string.IsNullOrEmpty(clsReqrequeteparetape.AT_NUMEROORDREAGENTENCHARGE) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                //{
                //    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                //    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //    //----EXEPTION
                //    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AT_NUMEROORDREAGENTENCHARGE";
                //    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                //    return clsReqrequeteparetapeDTOs[0];
                //}





                //if (string.IsNullOrEmpty(clsReqrequeteparetape.RE_CODEETAPERELANCEE) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                //{
                //    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                //    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //    //----EXEPTION
                //    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RE_CODEETAPERELANCEE";
                //    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                //    return clsReqrequeteparetapeDTOs[0];
                //}

                //if (string.IsNullOrEmpty(clsReqrequeteparetape.RQ_SIGNATURE) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                //{
                //    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                //    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //    //----EXEPTION
                //    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_SIGNATURE";
                //    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                //    return clsReqrequeteparetapeDTOs[0];
                //}
                //if (string.IsNullOrEmpty(clsReqrequeteparetape.RS_CODESTATUTRECEVABILITE) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                //{
                //    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                //    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //    //----EXEPTION
                //    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RS_CODESTATUTRECEVABILITE";
                //    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                //    return clsReqrequeteparetapeDTOs[0];
                //}



                //if (string.IsNullOrEmpty(clsReqrequeteparetape.SR_CODESERVICE) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                //{
                //    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                //    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //    //----EXEPTION
                //    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " SR_CODESERVICE";
                //    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                //    return clsReqrequeteparetapeDTOs[0];
                //}
                //if (string.IsNullOrEmpty(clsReqrequeteparetape.RQ_DELAITRAITEMENTREQUETE) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                //{
                //    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                //    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //    //----EXEPTION
                //    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DELAITRAITEMENTREQUETE";
                //    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                //    return clsReqrequeteparetapeDTOs[0];
                //}
                //if (string.IsNullOrEmpty(clsReqrequeteparetape.RQ_OBSERVATIONDELAITRAITEMENTREQUETE) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                //{
                //    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                //    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //    //----EXEPTION
                //    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_OBSERVATIONDELAITRAITEMENTREQUETE";
                //    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                //    return clsReqrequeteparetapeDTOs[0];
                //}
                //if (string.IsNullOrEmpty(clsReqrequeteparetape.RQ_DUREETRAITEMENTREQUETE) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                //{
                //    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                //    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //    //----EXEPTION
                //    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DUREETRAITEMENTREQUETE";
                //    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                //    return clsReqrequeteparetapeDTOs[0];
                //}




                //if (string.IsNullOrEmpty(clsReqrequeteparetape.AC_CODEACTIONCORRECTIVE) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                //{
                //    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                //    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //    //----EXEPTION
                //    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AC_CODEACTIONCORRECTIVE";
                //    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                //    return clsReqrequeteparetapeDTOs[0];
                //}
                //if (string.IsNullOrEmpty(clsReqrequeteparetape.NS_CODENIVEAUSATISFACTION) && (clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqrequeteparetape.clsObjetEnvoi.TYPEOPERATION == "1"))
                //{
                //    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                //    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                //    //----EXEPTION
                //    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                //    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " NS_CODENIVEAUSATISFACTION";
                //    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                //    return clsReqrequeteparetapeDTOs[0];
                //}




            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteparetapeWSBLL clsReqrequeteparetapeWSBLL = new clsReqrequeteparetapeWSBLL();
                    //===
                    MgRequeteClients.BOJ.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeBOJ = new clsReqrequeteparetape();
                    clsReqrequeteparetapeBOJ.RE_CODEETAPE = clsReqrequeteparetapeDTO.RE_CODEETAPE;
                    clsReqrequeteparetapeBOJ.RE_LIBELLEETAPE = clsReqrequeteparetapeDTO.RE_LIBELLEETAPE;
                    clsReqrequeteparetapeBOJ.RE_ACTIF = clsReqrequeteparetapeDTO.RE_ACTIF;







                    clsReqrequeteparetapeBOJ.TYPEOPERATION = clsReqrequeteparetapeDTO.clsObjetEnvoi.TYPEOPERATION;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteparetapeWSBLL.pvgMiseajour(_clsDonnee, clsReqrequeteparetapeBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                        clsReqrequeteparetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteparetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsReqrequeteparetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsReqrequeteparetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                        clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteparetapeDTOs[0];

        }
        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape> pvgListeReqrequeteEtapeParam(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape> clsReqrequeteparetapeDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                    return clsReqrequeteparetapeDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                    return clsReqrequeteparetapeDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteparetapeWSBLL clsReqrequeteparetapeWSBLL = new clsReqrequeteparetapeWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteparetapeWSBLL.pvgChargerDansDataSet(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                                clsReqrequeteparetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteparetapeDTOR.RE_CODEETAPE = DataRow["RE_CODEETAPE"].ToString();
                                clsReqrequeteparetapeDTOR.RE_LIBELLEETAPE = DataRow["RE_LIBELLEETAPE"].ToString();
                                clsReqrequeteparetapeDTOR.RE_ACTIF = DataRow["RE_ACTIF"].ToString();




                                clsReqrequeteparetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqrequeteparetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqrequeteparetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                            clsReqrequeteparetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteparetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteparetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteparetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                        clsReqrequeteparetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteparetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteparetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteparetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteparetapeDTOs;

        }
        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape> pvgListeReqrequeteEtapeParamCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape> clsReqrequeteparetapeDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                    return clsReqrequeteparetapeDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                    clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqrequeteparetapeDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
                    return clsReqrequeteparetapeDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteparetapeWSBLL clsReqrequeteparetapeWSBLL = new clsReqrequeteparetapeWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteparetapeWSBLL.pvgChargerDansDataSetPourCombo(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                                clsReqrequeteparetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqrequeteparetapeDTOR.RE_CODEETAPE = DataRow["RE_CODEETAPE"].ToString();
                                clsReqrequeteparetapeDTOR.RE_ACTIF = DataRow["RE_ACTIF"].ToString();
                                clsReqrequeteparetapeDTOR.RE_LIBELLEETAPE = DataRow["RE_LIBELLEETAPE"].ToString();
                                clsReqrequeteparetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqrequeteparetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqrequeteparetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                            clsReqrequeteparetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqrequeteparetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteparetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteparetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                        clsReqrequeteparetapeDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqrequeteparetapeDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteparetapeDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteparetapeDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape clsReqrequeteparetapeDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape();
                clsReqrequeteparetapeDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqrequeteparetapeDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteparetapeDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteparetapeDTOs.Add(clsReqrequeteparetapeDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteparetapeDTOs;

        }

        #endregion Reqrequete ETAPE param
        public List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgPasswordRequest(List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> clsReqcompteutilisateurDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateur in Objets)
            {
                if (clsReqcompteutilisateur.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }
                if (string.IsNullOrEmpty(clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }

                if (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION != "0" && clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION != "1")
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_TYPE_OPERATION_INCORRECT + " TYPEOPERATION";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }



                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_CONTACT) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_CONTACT";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }

                if (string.IsNullOrEmpty(clsReqcompteutilisateur.CU_LOGIN) && (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                    clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqcompteutilisateurDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_LOGIN";
                    clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
                    return clsReqcompteutilisateurDTOs;
                }


            }

            try
            {
                string CL_CONTACT = "";

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateur in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqcompteutilisateurWSBLL clsReqcompteutilisateurWSBLL = new clsReqcompteutilisateurWSBLL();
                    //===
                    //if (clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION == "0")
                    //    clsReqcompteutilisateur.MO_CODEVALIDATION = MgRequeteClients.WSTOOLS.clsChaineCaractere.GetRandomAlphaNumeric();
                    CL_CONTACT = clsReqcompteutilisateur.CU_CONTACT;
                    clsObjetEnvoi.OE_PARAM = new string[] { clsReqcompteutilisateur.CU_CONTACT, clsReqcompteutilisateur.CU_LOGIN, clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION };

                    //====
                    clsObjetRetour.SetValue(true, clsReqcompteutilisateurWSBLL.pvgPasswordRequest(_clsDonnee, clsReqcompteutilisateur.CU_CONTACT, clsReqcompteutilisateur.CU_LOGIN, clsReqcompteutilisateur.clsObjetEnvoi.TYPEOPERATION), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                                clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqcompteutilisateurDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_LOGIN = DataRow["CU_LOGIN"].ToString();
                                clsReqcompteutilisateurDTOR.CU_MOTDEPASSE = DataRow["CU_MOTDEPASSE"].ToString();
                                clsReqcompteutilisateurDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                                clsReqcompteutilisateurDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();
                                clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = DataRow["SL_CODEMESSAGE"].ToString();
                                clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = DataRow["SL_RESULTAT"].ToString();
                                clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = DataRow["SL_MESSAGE"].ToString();

                                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                                string corpsMessage = "Votre mot de passe est : " + clsReqcompteutilisateurDTOR.CU_MOTDEPASSE;// SL_MESSAGECLIENT;//clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT;

                                if (clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT == "TRUE")//&& IsNetworkConnected())
                                {
                                    if (CL_CONTACT.Contains("@"))//&& IsNetworkConnected()
                                    {
                                        string AG_EMAIL = "";
                                        string AG_EMAILMOTDEPASSE = "";
                                        clsReqniveausatisfactionWSBLL clsReqniveausatisfactionWSBLL = new clsReqniveausatisfactionWSBLL();
                                        DataSet DataSet = new DataSet();
                                        clsObjetEnvoi.OE_PARAM = new string[] { clsReqcompteutilisateurDTOR.AG_CODEAGENCE };
                                        DataSet = clsReqniveausatisfactionWSBLL.pvgChargerDansDataSetAgence(_clsDonnee, clsObjetEnvoi);
                                        foreach (DataRow row in DataSet.Tables[0].Rows)
                                        {
                                            AG_EMAIL = row["AG_EMAIL"].ToString();
                                            AG_EMAILMOTDEPASSE = row["AG_EMAILMOTDEPASSE"].ToString();
                                        }

                                        // Paramètres du serveur SMTP
                                        string smtpServeur = "smtp.gmail.com";
                                        int portSmtp = 587;
                                        string adresseEmail = AG_EMAIL;// "bolatykouassieuloge@gmail.com";
                                        string motDePasse = AG_EMAILMOTDEPASSE;// "nffncgqonuuildmc";
                                                                               //string SL_MESSAGECLIENT = "";// "nffncgqonuuildmc";
                                                                               // Destinataire et contenu de l'e-mail
                                        string destinataire = CL_CONTACT;// "technicosup@mgdigitalplus.com";
                                        string sujet = "Mot de passe oublié";


                                        // Création de l'objet MailMessage
                                        MailMessage message = new MailMessage(adresseEmail, destinataire, sujet, corpsMessage);

                                        // Création de l'objet SmtpClient
                                        SmtpClient clientSmtp = new SmtpClient(smtpServeur, portSmtp);
                                        clientSmtp.UseDefaultCredentials = false;
                                        clientSmtp.Credentials = new NetworkCredential(adresseEmail, motDePasse);
                                        clientSmtp.EnableSsl = true;

                                        // Envoi de l'e-mail
                                        clientSmtp.Send(message);
                                    }
                                    else
                                    {

                                        string AG_CODEAGENCE = "";
                                        string SM_TELEPHONE = "";
                                        string SMSTEXT = "";
                                        DateTime SM_DATEPIECE = DateTime.Parse("01/01/1900");
                                        string TYPEOPERATION = "";
                                        string SL_LIBELLE1 = "";
                                        string SL_LIBELLE2 = "";


                                        AG_CODEAGENCE = "1004"; // clsReqcompteutilisateurDTOR.AG_CODEAGENCE;
                                        SM_TELEPHONE = clsReqcompteutilisateurDTOR.CU_CONTACT;
                                        SMSTEXT = corpsMessage;
                                        SM_DATEPIECE = DateTime.Parse("01/01/1900");
                                        TYPEOPERATION = "";
                                        SL_LIBELLE1 = "";
                                        SL_LIBELLE2 = "";
                                        clsParams clsParams = new clsParams();
                                        clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
                                        clsParams = clsSmsoutWSBLL.pvgTraitementSmsSimple(_clsDonnee, AG_CODEAGENCE, SM_TELEPHONE, SMSTEXT, SM_DATEPIECE, TYPEOPERATION, SL_LIBELLE1, SL_LIBELLE2);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                            clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                        clsReqcompteutilisateurDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqcompteutilisateurDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur clsReqcompteutilisateurDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur();
                clsReqcompteutilisateurDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqcompteutilisateurDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqcompteutilisateurDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqcompteutilisateurDTOs.Add(clsReqcompteutilisateurDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqcompteutilisateurDTOs;

        }


        #region Reqrequete SMSOUT

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqsmsout> pvgListeSMS(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqsmsout> clsReqsmsoutDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqsmsout>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                    clsReqsmsoutDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqsmsoutDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqsmsoutDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqsmsoutDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqsmsoutDTOs.Add(clsReqsmsoutDTO);
                    return clsReqsmsoutDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                    clsReqsmsoutDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqsmsoutDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqsmsoutDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqsmsoutDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqsmsoutDTOs.Add(clsReqsmsoutDTO);
                    return clsReqsmsoutDTOs;
                }

            }

            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqsmsoutWSBLL clsReqsmsoutWSBLL = new clsReqsmsoutWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;
                    if (clsObjetEnvoi.OE_PARAM[0].Length != 10)
                    {
                        clsObjetRetour.SetValue(true, clsReqsmsoutWSBLL.pvgChargerDansDataSetListSMS(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                        if (clsObjetRetour.OR_BOOLEEN)
                        {
                            if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                                {
                                    MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                                    clsReqsmsoutDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                    clsReqsmsoutDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                    clsReqsmsoutDTOR.SM_DATEPIECE = DataRow["SM_DATEPIECE"].ToString();
                                    clsReqsmsoutDTOR.SM_NUMSEQUENCE = DataRow["SM_NUMSEQUENCE"].ToString();
                                    clsReqsmsoutDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                    clsReqsmsoutDTOR.TE_CODESMSTYPEOPERATION = DataRow["TE_CODESMSTYPEOPERATION"].ToString();
                                    clsReqsmsoutDTOR.SM_MESSAGE = DataRow["SM_MESSAGE"].ToString();
                                    clsReqsmsoutDTOR.SM_MESSAGE_TRANSLATE = "";
                                    clsReqsmsoutDTOR.SM_TELEPHONE = DataRow["SM_TELEPHONE"].ToString();
                                    clsReqsmsoutDTOR.SM_STATUT = DataRow["SM_STATUT"].ToString();
                                    clsReqsmsoutDTOR.SM_DATEEMISSIONSMS = DataRow["SM_DATEEMISSIONSMS"].ToString();
                                    clsReqsmsoutDTOR.SM_RAISONNONENVOISMS = DataRow["SM_RAISONNONENVOISMS"].ToString();
                                    clsReqsmsoutDTOR.SM_DATESAISIE = DataRow["SM_DATESAISIE"].ToString();
                                    clsReqsmsoutDTOR.SM_STATUT_LECTURE = DataRow["SM_STATUT_LECTURE"].ToString();
                                    clsReqsmsoutDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                    clsReqsmsoutDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                    clsReqsmsoutDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                    clsReqsmsoutDTOs.Add(clsReqsmsoutDTOR);
                                }
                            }
                            else
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                                clsReqsmsoutDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqsmsoutDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                                clsReqsmsoutDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                                clsReqsmsoutDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                                clsReqsmsoutDTOs.Add(clsReqsmsoutDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                            clsReqsmsoutDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqsmsoutDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqsmsoutDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqsmsoutDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqsmsoutDTOs.Add(clsReqsmsoutDTOR);
                        }
                    }
                    if (clsObjetEnvoi.OE_PARAM[0].Length == 10)
                    {

                        clsObjetRetour.SetValue(true, clsReqsmsoutWSBLL.pvgChargerDansDataSetListSMSADMIN(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                        if (clsObjetRetour.OR_BOOLEEN)
                        {
                            if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                                {
                                    MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                                    clsReqsmsoutDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                    clsReqsmsoutDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                    clsReqsmsoutDTOR.SM_DATEPIECE = DataRow["SM_DATEPIECE"].ToString();
                                    clsReqsmsoutDTOR.SM_NUMSEQUENCE = DataRow["SM_NUMSEQUENCE"].ToString();
                                    clsReqsmsoutDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                    clsReqsmsoutDTOR.TE_CODESMSTYPEOPERATION = DataRow["TE_CODESMSTYPEOPERATION"].ToString();
                                    clsReqsmsoutDTOR.SM_MESSAGE = DataRow["SM_MESSAGE"].ToString();
                                    clsReqsmsoutDTOR.SM_MESSAGE_TRANSLATE = "";
                                    clsReqsmsoutDTOR.SM_TELEPHONE = DataRow["SM_TELEPHONE"].ToString();
                                    clsReqsmsoutDTOR.SM_STATUT = DataRow["SM_STATUT"].ToString();
                                    clsReqsmsoutDTOR.SM_DATEEMISSIONSMS = DataRow["SM_DATEEMISSIONSMS"].ToString();
                                    clsReqsmsoutDTOR.SM_RAISONNONENVOISMS = DataRow["SM_RAISONNONENVOISMS"].ToString();
                                    clsReqsmsoutDTOR.SM_DATESAISIE = DataRow["SM_DATESAISIE"].ToString();
                                    clsReqsmsoutDTOR.SM_STATUT_LECTURE = DataRow["SM_STATUT_LECTURE"].ToString();
                                    clsReqsmsoutDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                    clsReqsmsoutDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                    clsReqsmsoutDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                    clsReqsmsoutDTOs.Add(clsReqsmsoutDTOR);
                                }
                            }
                            else
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                                clsReqsmsoutDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqsmsoutDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                                clsReqsmsoutDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                                clsReqsmsoutDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                                clsReqsmsoutDTOs.Add(clsReqsmsoutDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                            clsReqsmsoutDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqsmsoutDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqsmsoutDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqsmsoutDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqsmsoutDTOs.Add(clsReqsmsoutDTOR);
                        }
                    }

                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                clsReqsmsoutDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqsmsoutDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqsmsoutDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqsmsoutDTOs.Add(clsReqsmsoutDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                clsReqsmsoutDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqsmsoutDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqsmsoutDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqsmsoutDTOs.Add(clsReqsmsoutDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqsmsoutDTOs;

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqsmsout> pvgLectureNotification(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqsmsout> clsReqsmsoutDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqsmsout>();

            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                    clsReqsmsoutDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqsmsoutDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqsmsoutDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqsmsoutDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqsmsoutDTOs.Add(clsReqsmsoutDTO);
                    return clsReqsmsoutDTOs;
                }
            }

            try
            {
                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiLectureNotif in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqsmsoutWSBLL clsReqsmsoutWSBLL = new clsReqsmsoutWSBLL();

                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiLectureNotif.OE_PARAM;

                    clsObjetRetour.SetValue(true, clsReqsmsoutWSBLL.pvgLectureNotification(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                        clsReqsmsoutDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;

                        clsReqsmsoutDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsReqsmsoutDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsReqsmsoutDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                        clsReqsmsoutDTOs.Add(clsReqsmsoutDTOR);
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                        clsReqsmsoutDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqsmsoutDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqsmsoutDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqsmsoutDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqsmsoutDTOs.Add(clsReqsmsoutDTOR);
                    }
                }
            }
            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                clsReqsmsoutDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqsmsoutDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqsmsoutDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqsmsoutDTOs.Add(clsReqsmsoutDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqsmsout clsReqsmsoutDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqsmsout();
                clsReqsmsoutDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqsmsoutDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqsmsoutDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqsmsoutDTOs.Add(clsReqsmsoutDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }

            return clsReqsmsoutDTOs;
        }

        #endregion Reqrequete SMSOUT



        #region Forgot password
        public List<MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier> pvgForgotPassword(List<MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier> clsReqmotdepasseoublierDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublier in Objets)
            {
                if (clsReqmotdepasseoublier.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublierDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier();
                    clsReqmotdepasseoublierDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqmotdepasseoublierDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqmotdepasseoublierDTOs.Add(clsReqmotdepasseoublierDTO);
                    return clsReqmotdepasseoublierDTOs;
                }
                if (string.IsNullOrEmpty(clsReqmotdepasseoublier.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublierDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier();
                    clsReqmotdepasseoublierDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqmotdepasseoublierDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqmotdepasseoublierDTOs.Add(clsReqmotdepasseoublierDTO);
                    return clsReqmotdepasseoublierDTOs;
                }

                if (clsReqmotdepasseoublier.clsObjetEnvoi.TYPEOPERATION != "0" && clsReqmotdepasseoublier.clsObjetEnvoi.TYPEOPERATION != "1")
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublierDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier();
                    clsReqmotdepasseoublierDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqmotdepasseoublierDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_TYPE_OPERATION_INCORRECT + " TYPEOPERATION";
                    clsReqmotdepasseoublierDTOs.Add(clsReqmotdepasseoublierDTO);
                    return clsReqmotdepasseoublierDTOs;
                }



                if (string.IsNullOrEmpty(clsReqmotdepasseoublier.MO_CONTACT) && (clsReqmotdepasseoublier.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqmotdepasseoublier.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublierDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier();
                    clsReqmotdepasseoublierDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqmotdepasseoublierDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " MO_CONTACT";
                    clsReqmotdepasseoublierDTOs.Add(clsReqmotdepasseoublierDTO);
                    return clsReqmotdepasseoublierDTOs;
                }

                if (string.IsNullOrEmpty(clsReqmotdepasseoublier.TU_CODETYPEUTILISATEUR) && (clsReqmotdepasseoublier.clsObjetEnvoi.TYPEOPERATION == "0" || clsReqmotdepasseoublier.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublierDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier();
                    clsReqmotdepasseoublierDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqmotdepasseoublierDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TU_CODETYPEUTILISATEUR";
                    clsReqmotdepasseoublierDTOs.Add(clsReqmotdepasseoublierDTO);
                    return clsReqmotdepasseoublierDTOs;
                }
                if (string.IsNullOrEmpty(clsReqmotdepasseoublier.MO_CODEVALIDATION) && (clsReqmotdepasseoublier.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublierDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier();
                    clsReqmotdepasseoublierDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqmotdepasseoublierDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_MOTDEPASSE";
                    clsReqmotdepasseoublierDTOs.Add(clsReqmotdepasseoublierDTO);
                    return clsReqmotdepasseoublierDTOs;
                }
                if (string.IsNullOrEmpty(clsReqmotdepasseoublier.CU_CODECOMPTEUTULISATEUR) && (clsReqmotdepasseoublier.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublierDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier();
                    clsReqmotdepasseoublierDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqmotdepasseoublierDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_CODECOMPTEUTILISATEUR";
                    clsReqmotdepasseoublierDTOs.Add(clsReqmotdepasseoublierDTO);
                    return clsReqmotdepasseoublierDTOs;
                }
                if (string.IsNullOrEmpty(clsReqmotdepasseoublier.CU_MOTDEPASSE) && (clsReqmotdepasseoublier.clsObjetEnvoi.TYPEOPERATION == "1"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublierDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier();
                    clsReqmotdepasseoublierDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqmotdepasseoublierDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqmotdepasseoublierDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " CU_MOTDEPASSE";
                    clsReqmotdepasseoublierDTOs.Add(clsReqmotdepasseoublierDTO);
                    return clsReqmotdepasseoublierDTOs;
                }



            }




            try
            {
                string CL_EMAIL = "";
                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublier in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqmotdepasseoublierWSBLL clsReqmotdepasseoublierWSBLL = new clsReqmotdepasseoublierWSBLL();
                    //===
                    if (clsReqmotdepasseoublier.clsObjetEnvoi.TYPEOPERATION == "0")
                        clsReqmotdepasseoublier.MO_CODEVALIDATION = clsChaineCaractere.GetRandomAlphaNumeric();
                    clsObjetEnvoi.OE_PARAM = new string[] { clsReqmotdepasseoublier.MO_CONTACT, clsReqmotdepasseoublier.MO_CODEVALIDATION, clsReqmotdepasseoublier.TU_CODETYPEUTILISATEUR, clsReqmotdepasseoublier.CU_CODECOMPTEUTULISATEUR, clsReqmotdepasseoublier.CU_MOTDEPASSE, clsReqmotdepasseoublier.clsObjetEnvoi.TYPEOPERATION }; ;

                    //====
                    clsObjetRetour.SetValue(true, clsReqmotdepasseoublierWSBLL.pvgForgotPassword(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublierDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier();
                                clsReqmotdepasseoublierDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqmotdepasseoublierDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                clsReqmotdepasseoublierDTOR.MO_DATE = clsDate.ClasseDate.pvgFormaterDate(DataRow["MO_DATE"].ToString());
                                clsReqmotdepasseoublierDTOR.MO_NUMEROSEQUENCE = DataRow["MO_NUMEROSEQUENCE"].ToString();
                                clsReqmotdepasseoublierDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                clsReqmotdepasseoublierDTOR.MO_CONTACT = DataRow["MO_CONTACT"].ToString();
                                clsReqmotdepasseoublierDTOR.MO_HEURE = DateTime.Parse(DataRow["MO_HEURE"].ToString()).ToShortTimeString();
                                clsReqmotdepasseoublierDTOR.MO_CODEVALIDATION = DataRow["MO_CODEVALIDATION"].ToString();
                                clsReqmotdepasseoublierDTOR.MO_DATEVALIDATION = clsDate.ClasseDate.pvgFormaterDate(DataRow["MO_DATEVALIDATION"].ToString());
                                clsReqmotdepasseoublierDTOR.clsResultat.SL_CODEMESSAGE = DataRow["SL_CODEMESSAGE"].ToString();
                                clsReqmotdepasseoublierDTOR.clsResultat.SL_RESULTAT = DataRow["SL_RESULTAT"].ToString();
                                clsReqmotdepasseoublierDTOR.clsResultat.SL_MESSAGE = DataRow["SL_MESSAGE"].ToString();
                                CL_EMAIL = clsReqmotdepasseoublierDTOR.MO_CONTACT;
                                clsReqmotdepasseoublierDTOs.Add(clsReqmotdepasseoublierDTOR);


                                if (CL_EMAIL.Contains("@"))//&& IsNetworkConnected()
                                {


                                    // Paramètres du serveur SMTP
                                    string smtpServeur = "smtp.gmail.com";
                                    int portSmtp = 587;
                                    string adresseEmail = "bolatykouassieuloge@gmail.com";
                                    string motDePasse = "nffncgqonuuildmc";
                                    string SL_MESSAGECLIENT = "";// "nffncgqonuuildmc";
                                    // Destinataire et contenu de l'e-mail
                                    string destinataire = CL_EMAIL;// "technicosup@mgdigitalplus.com";
                                    string sujet = "Code Validation";
                                    string corpsMessage = "Merci de recevoir votre code de validation : " + clsReqmotdepasseoublierDTOR.MO_CODEVALIDATION;// SL_MESSAGECLIENT;//clsMiccomptewebmotpasseoublieListe[0].SL_MESSAGECLIENT;

                                    // Création de l'objet MailMessage
                                    MailMessage message = new MailMessage(adresseEmail, destinataire, sujet, corpsMessage);

                                    // Création de l'objet SmtpClient
                                    SmtpClient clientSmtp = new SmtpClient(smtpServeur, portSmtp);
                                    clientSmtp.UseDefaultCredentials = false;
                                    clientSmtp.Credentials = new NetworkCredential(adresseEmail, motDePasse);
                                    clientSmtp.EnableSsl = true;

                                    // Envoi de l'e-mail
                                    clientSmtp.Send(message);


                                }



                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublierDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier();
                            clsReqmotdepasseoublierDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqmotdepasseoublierDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqmotdepasseoublierDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqmotdepasseoublierDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqmotdepasseoublierDTOs.Add(clsReqmotdepasseoublierDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublierDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier();
                        clsReqmotdepasseoublierDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqmotdepasseoublierDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqmotdepasseoublierDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqmotdepasseoublierDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqmotdepasseoublierDTOs.Add(clsReqmotdepasseoublierDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublierDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier();
                clsReqmotdepasseoublierDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqmotdepasseoublierDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqmotdepasseoublierDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqmotdepasseoublierDTOs.Add(clsReqmotdepasseoublierDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier clsReqmotdepasseoublierDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier();
                clsReqmotdepasseoublierDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqmotdepasseoublierDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqmotdepasseoublierDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqmotdepasseoublierDTOs.Add(clsReqmotdepasseoublierDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqmotdepasseoublierDTOs;

        }



        #endregion Forgot password


        #region Reqrequete Etat

       
        public List<MgRequeteClients.DTO.BusinessObjects.clsZoneDTO> pvgInsertIntoDatasetZoneWeb()
        {
            List<MgRequeteClients.DTO.BusinessObjects.clsZoneDTO> clsZoneDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsZoneDTO>();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour clsObjetRetour = new MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi clsObjetEnvoi = new MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi();
            MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet clsEditionEtatGuichet = new MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet();


            clsObjetEnvoi.OE_PARAM = new string[] { };

            try
            {
                clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
                clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
                _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                _clsDonnee.pvgDemarrerTransaction();

                clsObjetRetour.SetValue(true, clsEditionWSBLL.pvgInsertIntoDatasetZone(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {

                        DataTable tableAgence = new DataTable();
                        foreach (DataRow row in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsZoneDTO clsZoneDTO = new MgRequeteClients.DTO.BusinessObjects.clsZoneDTO();
                            clsZoneDTO.ZN_CODEZONE = row["ZN_CODEZONE"].ToString();
                            clsZoneDTO.ZN_NOMZONE = row["ZN_NOMZONE"].ToString();
                            clsZoneDTO.SL_RESULTAT = "TRUE";
                            clsZoneDTO.SL_MESSAGE = "Opération réalisée avec succès !!!";
                            clsZoneDTO.SL_CODEMESSAGE = "00";

                            clsZoneDTOs.Add(clsZoneDTO);

                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsZoneDTO clsZoneDTO = new MgRequeteClients.DTO.BusinessObjects.clsZoneDTO();
                        clsZoneDTO.SL_RESULTAT = "FALSE";
                        clsZoneDTO.SL_MESSAGE = "Aucun élément trouvé !!!";
                        clsZoneDTO.SL_CODEMESSAGE = "00";

                        clsZoneDTOs.Add(clsZoneDTO);
                    }

                }
                // clsObjetRetour.OR_DATASET

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsZoneDTO clsZoneDTO = new MgRequeteClients.DTO.BusinessObjects.clsZoneDTO();
                clsZoneDTO.SL_RESULTAT = "FALSE";
                clsZoneDTO.SL_MESSAGE = SQLEx.Message;
                clsZoneDTO.SL_CODEMESSAGE = "00";
                clsZoneDTOs.Add(clsZoneDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            catch (Exception SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsZoneDTO clsZoneDTO = new MgRequeteClients.DTO.BusinessObjects.clsZoneDTO();
                clsZoneDTO.SL_RESULTAT = "FALSE";
                clsZoneDTO.SL_MESSAGE = SQLEx.Message;
                clsZoneDTO.SL_CODEMESSAGE = "00";
                clsZoneDTOs.Add(clsZoneDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsZoneDTOs;

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsAgenceDTO> pvgInsertIntoDatasetAgenceWeb(string EX_EXERCICE, string SO_CODESOCIETE, string OP_CODEOPERATEUR, string ZN_CODEZONE)
        {
            List<MgRequeteClients.DTO.BusinessObjects.clsAgenceDTO> clsAgenceDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsAgenceDTO>();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour clsObjetRetour = new MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi clsObjetEnvoi = new MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi();
            MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet clsEditionEtatGuichet = new MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet();


            //clsObjetEnvoi.OE_PARAM = new string[] { EX_EXERCICE, SO_CODESOCIETE, OP_CODEOPERATEUR, ZN_CODEZONE };
            clsObjetEnvoi.OE_PARAM = new string[] { EX_EXERCICE, "0001" };

            try
            {
                clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
                clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
                _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                _clsDonnee.pvgDemarrerTransaction();

                clsObjetRetour.SetValue(true, clsEditionWSBLL.pvgInsertIntoDatasetAgence(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {

                        DataTable tableAgence = new DataTable();
                        foreach (DataRow row in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsAgenceDTO clsAgenceDTO = new MgRequeteClients.DTO.BusinessObjects.clsAgenceDTO();
                            clsAgenceDTO.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                            clsAgenceDTO.AG_RAISONSOCIAL = row["AG_RAISONSOCIAL"].ToString();
                            clsAgenceDTO.AG_RAISONSOCIAL_TRANSLATE = "";
                            clsAgenceDTO.SL_RESULTAT = "TRUE";
                            clsAgenceDTO.SL_MESSAGE = "Opération réalisée avec succès !!!";
                            clsAgenceDTO.SL_CODEMESSAGE = "00";

                            clsAgenceDTOs.Add(clsAgenceDTO);

                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsAgenceDTO clsAgenceDTO = new MgRequeteClients.DTO.BusinessObjects.clsAgenceDTO();
                        clsAgenceDTO.SL_RESULTAT = "FALSE";
                        clsAgenceDTO.SL_MESSAGE = "Aucun élément trouvé !!!";
                        clsAgenceDTO.SL_CODEMESSAGE = "00";

                        clsAgenceDTOs.Add(clsAgenceDTO);
                    }

                }
                // clsObjetRetour.OR_DATASET

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsAgenceDTO clsAgenceDTO = new MgRequeteClients.DTO.BusinessObjects.clsAgenceDTO();
                clsAgenceDTO.SL_RESULTAT = "FALSE";
                clsAgenceDTO.SL_MESSAGE = SQLEx.Message;
                clsAgenceDTO.SL_CODEMESSAGE = "00";
                clsAgenceDTOs.Add(clsAgenceDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            catch (Exception SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsAgenceDTO clsAgenceDTO = new MgRequeteClients.DTO.BusinessObjects.clsAgenceDTO();
                clsAgenceDTO.SL_RESULTAT = "FALSE";
                clsAgenceDTO.SL_MESSAGE = SQLEx.Message;
                clsAgenceDTO.SL_CODEMESSAGE = "00";
                clsAgenceDTOs.Add(clsAgenceDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsAgenceDTOs;

        }



        public List<MgRequeteClients.DTO.BusinessObjects.clsExerciceDTO> pvgInsertIntoDatasetExerciceWeb()
        {
            List<MgRequeteClients.DTO.BusinessObjects.clsExerciceDTO> clsExerciceDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsExerciceDTO>();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour clsObjetRetour = new MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi clsObjetEnvoi = new MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi();
            MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet clsEditionEtatGuichet = new MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet();


            clsObjetEnvoi.OE_PARAM = new string[] { };

            try
            {
                clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
                clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
                _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                _clsDonnee.pvgDemarrerTransaction();

                clsObjetRetour.SetValue(true, clsEditionWSBLL.pvgInsertIntoDatasetExercice(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {

                        DataTable tableAgence = new DataTable();
                        foreach (DataRow row in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsExerciceDTO clsExerciceDTO = new MgRequeteClients.DTO.BusinessObjects.clsExerciceDTO();
                            //clsExerciceDTO.AG_CODEAGENCE = row["AG_CODEAGENCE"].ToString();
                            clsExerciceDTO.EX_EXERCICE = row["EX_EXERCICE"].ToString();
                            //clsExerciceDTO.JT_DATEJOURNEETRAVAIL =DateTime.Parse( row["JT_DATEJOURNEETRAVAIL"].ToString());
                            //clsExerciceDTO.EX_DATEDEBUT = DateTime.Parse( row["EX_DATEDEBUT"].ToString());
                            //clsExerciceDTO.EX_DATEFIN = DateTime.Parse( row["EX_DATEFIN"].ToString());
                            //clsExerciceDTO.EX_DESCEXERCICE = row["EX_DESCEXERCICE"].ToString();
                            //clsExerciceDTO.EX_ETATEXERCICE = row["EX_ETATEXERCICE"].ToString();
                            //clsExerciceDTO.EX_DATESAISIE = DateTime.Parse( row["EX_DATESAISIE"].ToString());

                            clsExerciceDTO.SL_RESULTAT = "TRUE";
                            clsExerciceDTO.SL_MESSAGE = "Opération réalisée avec succès !!!";
                            clsExerciceDTO.SL_CODEMESSAGE = "00";

                            clsExerciceDTOs.Add(clsExerciceDTO);

                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsExerciceDTO clsExerciceDTO = new MgRequeteClients.DTO.BusinessObjects.clsExerciceDTO();
                        clsExerciceDTO.SL_RESULTAT = "FALSE";
                        clsExerciceDTO.SL_MESSAGE = "Aucun élément trouvé !!!";
                        clsExerciceDTO.SL_CODEMESSAGE = "00";

                        clsExerciceDTOs.Add(clsExerciceDTO);
                    }

                }
                // clsObjetRetour.OR_DATASET

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsExerciceDTO clsExerciceDTO = new MgRequeteClients.DTO.BusinessObjects.clsExerciceDTO();
                clsExerciceDTO.SL_RESULTAT = "FALSE";
                clsExerciceDTO.SL_MESSAGE = SQLEx.Message;
                clsExerciceDTO.SL_CODEMESSAGE = "00";
                clsExerciceDTOs.Add(clsExerciceDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            catch (Exception SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsExerciceDTO clsExerciceDTO = new MgRequeteClients.DTO.BusinessObjects.clsExerciceDTO();
                clsExerciceDTO.SL_RESULTAT = "FALSE";
                clsExerciceDTO.SL_MESSAGE = SQLEx.Message;
                clsExerciceDTO.SL_CODEMESSAGE = "00";
                clsExerciceDTOs.Add(clsExerciceDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsExerciceDTOs;

        }


        public List<MgRequeteClients.DTO.BusinessObjects.clsPeriodiciteDTO> pvgInsertIntoDatasetPeriodiciteWeb()
        {
            List<MgRequeteClients.DTO.BusinessObjects.clsPeriodiciteDTO> clsPeriodiciteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsPeriodiciteDTO>();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour clsObjetRetour = new MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi clsObjetEnvoi = new MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi();
            MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet clsEditionEtatGuichet = new MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet();


            clsObjetEnvoi.OE_PARAM = new string[] { };

            try
            {
                clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
                clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
                _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                _clsDonnee.pvgDemarrerTransaction();

                clsObjetRetour.SetValue(true, clsEditionWSBLL.pvgInsertIntoDatasetPeriodicite(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {

                        DataTable tableAgence = new DataTable();
                        foreach (DataRow row in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsPeriodiciteDTO clsPeriodiciteDTO = new MgRequeteClients.DTO.BusinessObjects.clsPeriodiciteDTO();
                            clsPeriodiciteDTO.PE_CODEPERIODICITE = row["PE_CODEPERIODICITE"].ToString();
                            clsPeriodiciteDTO.PE_ABREVIATION = row["PE_ABREVIATION"].ToString();
                            clsPeriodiciteDTO.PE_LIBELLE = row["PE_LIBELLE"].ToString();
                            clsPeriodiciteDTO.PE_UNITE = row["PE_UNITE"].ToString();
                            clsPeriodiciteDTO.PE_PERIODICITE = int.Parse(row["PE_PERIODICITE"].ToString());
                            //clsExerciceDTO.EX_ETATEXERCICE = row["EX_ETATEXERCICE"].ToString();
                            //clsExerciceDTO.EX_DATESAISIE = DateTime.Parse( row["EX_DATESAISIE"].ToString());

                            clsPeriodiciteDTO.SL_RESULTAT = "TRUE";
                            clsPeriodiciteDTO.SL_MESSAGE = "Opération réalisée avec succès !!!";
                            clsPeriodiciteDTO.SL_CODEMESSAGE = "00";

                            clsPeriodiciteDTOs.Add(clsPeriodiciteDTO);

                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsPeriodiciteDTO clsPeriodiciteDTO = new MgRequeteClients.DTO.BusinessObjects.clsPeriodiciteDTO();
                        clsPeriodiciteDTO.SL_RESULTAT = "FALSE";
                        clsPeriodiciteDTO.SL_MESSAGE = "Aucun élément trouvé !!!";
                        clsPeriodiciteDTO.SL_CODEMESSAGE = "00";

                        clsPeriodiciteDTOs.Add(clsPeriodiciteDTO);
                    }

                }
                // clsObjetRetour.OR_DATASET

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsPeriodiciteDTO clsPeriodiciteDTO = new MgRequeteClients.DTO.BusinessObjects.clsPeriodiciteDTO();
                clsPeriodiciteDTO.SL_RESULTAT = "FALSE";
                clsPeriodiciteDTO.SL_MESSAGE = SQLEx.Message;
                clsPeriodiciteDTO.SL_CODEMESSAGE = "00";
                clsPeriodiciteDTOs.Add(clsPeriodiciteDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            catch (Exception SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsPeriodiciteDTO clsPeriodiciteDTO = new MgRequeteClients.DTO.BusinessObjects.clsPeriodiciteDTO();
                clsPeriodiciteDTO.SL_RESULTAT = "FALSE";
                clsPeriodiciteDTO.SL_MESSAGE = SQLEx.Message;
                clsPeriodiciteDTO.SL_CODEMESSAGE = "00";
                clsPeriodiciteDTOs.Add(clsPeriodiciteDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsPeriodiciteDTOs;

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsPeriodeDTO> pvgPeriodiciteWeb(string PE_CODEPERIODICITE)
        {
            List<MgRequeteClients.DTO.BusinessObjects.clsPeriodeDTO> clsPeriodeDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsPeriodeDTO>();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour clsObjetRetour = new MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi clsObjetEnvoi = new MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi();
            MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet clsEditionEtatGuichet = new MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet();


            clsObjetEnvoi.OE_PARAM = new string[] { PE_CODEPERIODICITE };

            try
            {
                clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
                clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
                _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                _clsDonnee.pvgDemarrerTransaction();

                clsObjetRetour.SetValue(true, clsEditionWSBLL.pvgPeriodicite(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {

                        DataTable tableAgence = new DataTable();
                        foreach (DataRow row in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsPeriodeDTO clsPeriodeDTO = new MgRequeteClients.DTO.BusinessObjects.clsPeriodeDTO();
                            clsPeriodeDTO.MO_CODEMOIS = row["MO_CODEMOIS"].ToString();
                            clsPeriodeDTO.MO_LIBELLE = row["MO_LIBELLE"].ToString();


                            clsPeriodeDTO.SL_RESULTAT = "TRUE";
                            clsPeriodeDTO.SL_MESSAGE = "Opération réalisée avec succès !!!";
                            clsPeriodeDTO.SL_CODEMESSAGE = "00";

                            clsPeriodeDTOs.Add(clsPeriodeDTO);

                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsPeriodeDTO clsPeriodeDTO = new MgRequeteClients.DTO.BusinessObjects.clsPeriodeDTO();
                        clsPeriodeDTO.SL_RESULTAT = "FALSE";
                        clsPeriodeDTO.SL_MESSAGE = "Aucun élément trouvé !!!";
                        clsPeriodeDTO.SL_CODEMESSAGE = "00";

                        clsPeriodeDTOs.Add(clsPeriodeDTO);
                    }

                }
                // clsObjetRetour.OR_DATASET

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsPeriodeDTO clsPeriodeDTO = new MgRequeteClients.DTO.BusinessObjects.clsPeriodeDTO();
                clsPeriodeDTO.SL_RESULTAT = "FALSE";
                clsPeriodeDTO.SL_MESSAGE = SQLEx.Message;
                clsPeriodeDTO.SL_CODEMESSAGE = "00";
                clsPeriodeDTOs.Add(clsPeriodeDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            catch (Exception SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsPeriodeDTO clsPeriodeDTO = new MgRequeteClients.DTO.BusinessObjects.clsPeriodeDTO();
                clsPeriodeDTO.SL_RESULTAT = "FALSE";
                clsPeriodeDTO.SL_MESSAGE = SQLEx.Message;
                clsPeriodeDTO.SL_CODEMESSAGE = "00";
                clsPeriodeDTOs.Add(clsPeriodeDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsPeriodeDTOs;

        }


        public List<MgRequeteClients.DTO.BusinessObjects.clsPeriodeDateDebutDateFinDTO> pvgPeriodiciteDateDebutFin(string EX_EXERCICE, string MO_CODEMOIS, string PE_CODEPERIODICITE)
        {
            List<MgRequeteClients.DTO.BusinessObjects.clsPeriodeDateDebutDateFinDTO> clsPeriodeDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsPeriodeDateDebutDateFinDTO>();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour clsObjetRetour = new MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi clsObjetEnvoi = new MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi();
            MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet clsEditionEtatGuichet = new MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet();


            clsObjetEnvoi.OE_PARAM = new string[] { EX_EXERCICE, MO_CODEMOIS, PE_CODEPERIODICITE };

            try
            {
                clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
                clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
                _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                _clsDonnee.pvgDemarrerTransaction();
                clsObjetRetour.SetValue(true, clsEditionWSBLL.pvgPeriodiciteDateDebutFin(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {

                        DataTable tableAgence = new DataTable();
                        foreach (DataRow row in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsPeriodeDateDebutDateFinDTO clsPeriodeDTO = new MgRequeteClients.DTO.BusinessObjects.clsPeriodeDateDebutDateFinDTO();
                            clsPeriodeDTO.MO_DATEDEBUT = DateTime.Parse(row["MO_DATEDEBUT"].ToString()).ToShortDateString();
                            clsPeriodeDTO.MO_DATEFIN = DateTime.Parse(row["MO_DATEFIN"].ToString()).ToShortDateString();


                            clsPeriodeDTO.SL_RESULTAT = "TRUE";
                            clsPeriodeDTO.SL_MESSAGE = "Opération réalisée avec succès !!!";
                            clsPeriodeDTO.SL_CODEMESSAGE = "00";

                            clsPeriodeDTOs.Add(clsPeriodeDTO);

                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsPeriodeDateDebutDateFinDTO clsPeriodeDTO = new MgRequeteClients.DTO.BusinessObjects.clsPeriodeDateDebutDateFinDTO();
                        clsPeriodeDTO.SL_RESULTAT = "FALSE";
                        clsPeriodeDTO.SL_MESSAGE = "Aucun élément trouvé !!!";
                        clsPeriodeDTO.SL_CODEMESSAGE = "00";

                        clsPeriodeDTOs.Add(clsPeriodeDTO);
                    }

                }
                // clsObjetRetour.OR_DATASET

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsPeriodeDateDebutDateFinDTO clsPeriodeDTO = new MgRequeteClients.DTO.BusinessObjects.clsPeriodeDateDebutDateFinDTO();
                clsPeriodeDTO.SL_RESULTAT = "FALSE";
                clsPeriodeDTO.SL_MESSAGE = SQLEx.Message;
                clsPeriodeDTO.SL_CODEMESSAGE = "00";
                clsPeriodeDTOs.Add(clsPeriodeDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            catch (Exception SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsPeriodeDateDebutDateFinDTO clsPeriodeDTO = new MgRequeteClients.DTO.BusinessObjects.clsPeriodeDateDebutDateFinDTO();
                clsPeriodeDTO.SL_RESULTAT = "FALSE";
                clsPeriodeDTO.SL_MESSAGE = SQLEx.Message;
                clsPeriodeDTO.SL_CODEMESSAGE = "00";
                clsPeriodeDTOs.Add(clsPeriodeDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsPeriodeDTOs;

        }

        #endregion Reqrequete Etat

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete> pvgReqtyperequeteCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete> clsReqtyperequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete clsReqtyperequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete();
                    clsReqtyperequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqtyperequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqtyperequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqtyperequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqtyperequeteDTOs.Add(clsReqtyperequeteDTO);
                    return clsReqtyperequeteDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete clsReqtyperequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete();
                    clsReqtyperequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqtyperequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqtyperequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqtyperequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqtyperequeteDTOs.Add(clsReqtyperequeteDTO);
                    return clsReqtyperequeteDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqtyperequeteWSBLL clsReqtyperequeteWSBLL = new clsReqtyperequeteWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqtyperequeteWSBLL.pvgChargerDansDataSetPourCombo(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {//TR_CODETYEREQUETE , TR_LIBELLETYEREQUETE
                                MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete clsReqtyperequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete();
                                clsReqtyperequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqtyperequeteDTOR.TR_CODETYEREQUETE = DataRow["TR_CODETYEREQUETE"].ToString();
                                clsReqtyperequeteDTOR.TR_LIBELLETYEREQUETE = DataRow["TR_LIBELLETYEREQUETE"].ToString();// NR_CODENATUREREQUETE
                                clsReqtyperequeteDTOR.TR_LIBELLETYEREQUETE_TRANSLATE = "";
                                clsReqtyperequeteDTOR.NR_CODENATUREREQUETE = DataRow["NR_CODENATUREREQUETE"].ToString();
                                clsReqtyperequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqtyperequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqtyperequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqtyperequeteDTOs.Add(clsReqtyperequeteDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete clsReqtyperequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete();
                            clsReqtyperequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqtyperequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqtyperequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqtyperequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqtyperequeteDTOs.Add(clsReqtyperequeteDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete clsReqtyperequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete();
                        clsReqtyperequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqtyperequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqtyperequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqtyperequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqtyperequeteDTOs.Add(clsReqtyperequeteDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete clsReqtyperequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete();
                clsReqtyperequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqtyperequeteDTOR.clsResultat.SL_RESULTAT = "FALSE";
                clsReqtyperequeteDTOR.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqtyperequeteDTOs.Add(clsReqtyperequeteDTOR);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete clsReqtyperequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete();
                clsReqtyperequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqtyperequeteDTOR.clsResultat.SL_RESULTAT = "FALSE";
                clsReqtyperequeteDTOR.clsResultat.SL_MESSAGE = e.Message;
                clsReqtyperequeteDTOs.Add(clsReqtyperequeteDTOR);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqtyperequeteDTOs;

        }


        public List<MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte> pvgReqmodecollecteCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte> clsReqmodecollecteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte clsReqmodecollecteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte();
                    clsReqmodecollecteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqmodecollecteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqmodecollecteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqmodecollecteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqmodecollecteDTOs.Add(clsReqmodecollecteDTO);
                    return clsReqmodecollecteDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte clsReqmodecollecteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte();
                    clsReqmodecollecteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqmodecollecteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqmodecollecteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqmodecollecteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqmodecollecteDTOs.Add(clsReqmodecollecteDTO);
                    return clsReqmodecollecteDTOs;
                }

            }

            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqmodecollecteWSBLL clsReqmodecollecteWSBLL = new clsReqmodecollecteWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqmodecollecteWSBLL.pvgChargerDansDataSetPourCombo(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {//MC_CODEMODECOLLETE , MC_LIBELLEMODECOLLETE
                                MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte clsReqmodecollecteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte();
                                clsReqmodecollecteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqmodecollecteDTOR.MC_CODEMODECOLLETE = DataRow["MC_CODEMODECOLLETE"].ToString();
                                clsReqmodecollecteDTOR.MC_LIBELLEMODECOLLETE = DataRow["MC_LIBELLEMODECOLLETE"].ToString();
                                clsReqmodecollecteDTOR.MC_LIBELLEMODECOLLETE_TRANSLATE = "";
                                clsReqmodecollecteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqmodecollecteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqmodecollecteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqmodecollecteDTOs.Add(clsReqmodecollecteDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte clsReqmodecollecteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte();
                            clsReqmodecollecteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqmodecollecteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqmodecollecteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqmodecollecteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqmodecollecteDTOs.Add(clsReqmodecollecteDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte clsReqmodecollecteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte();
                        clsReqmodecollecteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqmodecollecteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqmodecollecteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqmodecollecteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqmodecollecteDTOs.Add(clsReqmodecollecteDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte clsReqmodecollecteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte();
                clsReqmodecollecteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqmodecollecteDTOR.clsResultat.SL_RESULTAT = "FALSE";
                clsReqmodecollecteDTOR.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqmodecollecteDTOs.Add(clsReqmodecollecteDTOR);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte clsReqmodecollecteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte();
                clsReqmodecollecteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqmodecollecteDTOR.clsResultat.SL_RESULTAT = "FALSE";
                clsReqmodecollecteDTOR.clsResultat.SL_MESSAGE = e.Message;
                clsReqmodecollecteDTOs.Add(clsReqmodecollecteDTOR);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqmodecollecteDTOs;

        }



        public List<MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite> pvgReqstatutrecevabiliteCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite> clsReqstatutrecevabiliteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite clsReqstatutrecevabiliteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite();
                    clsReqstatutrecevabiliteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqstatutrecevabiliteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqstatutrecevabiliteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqstatutrecevabiliteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqstatutrecevabiliteDTOs.Add(clsReqstatutrecevabiliteDTO);
                    return clsReqstatutrecevabiliteDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite clsReqstatutrecevabiliteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite();
                    clsReqstatutrecevabiliteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqstatutrecevabiliteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqstatutrecevabiliteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqstatutrecevabiliteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqstatutrecevabiliteDTOs.Add(clsReqstatutrecevabiliteDTO);
                    return clsReqstatutrecevabiliteDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqstatutrecevabiliteWSBLL clsReqstatutrecevabiliteWSBLL = new clsReqstatutrecevabiliteWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqstatutrecevabiliteWSBLL.pvgChargerDansDataSetPourCombo(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {//RS_CODESTATUTRECEVABILITE , RS_LIBELLESTATUTRECEVABILITE
                                MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite clsReqstatutrecevabiliteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite();
                                clsReqstatutrecevabiliteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqstatutrecevabiliteDTOR.RS_CODESTATUTRECEVABILITE = DataRow["RS_CODESTATUTRECEVABILITE"].ToString();
                                clsReqstatutrecevabiliteDTOR.RS_LIBELLESTATUTRECEVABILITE = DataRow["RS_LIBELLESTATUTRECEVABILITE"].ToString();
                                clsReqstatutrecevabiliteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqstatutrecevabiliteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqstatutrecevabiliteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqstatutrecevabiliteDTOs.Add(clsReqstatutrecevabiliteDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite clsReqstatutrecevabiliteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite();
                            clsReqstatutrecevabiliteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqstatutrecevabiliteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsReqstatutrecevabiliteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsReqstatutrecevabiliteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsReqstatutrecevabiliteDTOs.Add(clsReqstatutrecevabiliteDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite clsReqstatutrecevabiliteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite();
                        clsReqstatutrecevabiliteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqstatutrecevabiliteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsReqstatutrecevabiliteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsReqstatutrecevabiliteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                        clsReqstatutrecevabiliteDTOs.Add(clsReqstatutrecevabiliteDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite clsReqstatutrecevabiliteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite();
                clsReqstatutrecevabiliteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqstatutrecevabiliteDTOR.clsResultat.SL_RESULTAT = "FALSE";
                clsReqstatutrecevabiliteDTOR.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqstatutrecevabiliteDTOs.Add(clsReqstatutrecevabiliteDTOR);
            }
            catch (Exception SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite clsReqstatutrecevabiliteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite();
                clsReqstatutrecevabiliteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqstatutrecevabiliteDTOR.clsResultat.SL_RESULTAT = "FALSE";
                clsReqstatutrecevabiliteDTOR.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqstatutrecevabiliteDTOs.Add(clsReqstatutrecevabiliteDTOR);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqstatutrecevabiliteDTOs;

        }



        public List<MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective> pvgReqactioncorrectiveCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective> clsReqactioncorrectiveDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective clsReqactioncorrectiveDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective();
                    clsReqactioncorrectiveDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqactioncorrectiveDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqactioncorrectiveDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqactioncorrectiveDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqactioncorrectiveDTOs.Add(clsReqactioncorrectiveDTO);
                    return clsReqactioncorrectiveDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective clsReqactioncorrectiveDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective();
                    clsReqactioncorrectiveDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqactioncorrectiveDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqactioncorrectiveDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqactioncorrectiveDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqactioncorrectiveDTOs.Add(clsReqactioncorrectiveDTO);
                    return clsReqactioncorrectiveDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqactioncorrectiveWSBLL clsReqactioncorrectiveWSBLL = new clsReqactioncorrectiveWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqactioncorrectiveWSBLL.pvgChargerDansDataSetPourCombo(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {//AC_CODEACTIONCORRECTIVE , AC_LIBELLEACTIONCORRECTIVE
                                MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective clsReqactioncorrectiveDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective();
                                clsReqactioncorrectiveDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqactioncorrectiveDTOR.AC_CODEACTIONCORRECTIVE = DataRow["AC_CODEACTIONCORRECTIVE"].ToString();
                                clsReqactioncorrectiveDTOR.AC_LIBELLEACTIONCORRECTIVE = DataRow["AC_LIBELLEACTIONCORRECTIVE"].ToString();
                                clsReqactioncorrectiveDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqactioncorrectiveDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqactioncorrectiveDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqactioncorrectiveDTOs.Add(clsReqactioncorrectiveDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective clsReqactioncorrectiveDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective();
                            clsReqactioncorrectiveDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqactioncorrectiveDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsReqactioncorrectiveDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsReqactioncorrectiveDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsReqactioncorrectiveDTOs.Add(clsReqactioncorrectiveDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective clsReqactioncorrectiveDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective();
                        clsReqactioncorrectiveDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqactioncorrectiveDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsReqactioncorrectiveDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsReqactioncorrectiveDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                        clsReqactioncorrectiveDTOs.Add(clsReqactioncorrectiveDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective clsReqactioncorrectiveDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective();
                clsReqactioncorrectiveDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqactioncorrectiveDTOR.clsResultat.SL_RESULTAT = "FALSE";
                clsReqactioncorrectiveDTOR.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqactioncorrectiveDTOs.Add(clsReqactioncorrectiveDTOR);
            }
            catch (Exception SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective clsReqactioncorrectiveDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective();
                clsReqactioncorrectiveDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqactioncorrectiveDTOR.clsResultat.SL_RESULTAT = "FALSE";
                clsReqactioncorrectiveDTOR.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqactioncorrectiveDTOs.Add(clsReqactioncorrectiveDTOR);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqactioncorrectiveDTOs;

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction> pvgReqniveausatisfactionCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction> clsReqniveausatisfactionDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction clsReqniveausatisfactionDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction();
                    clsReqniveausatisfactionDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqniveausatisfactionDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqniveausatisfactionDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqniveausatisfactionDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqniveausatisfactionDTOs.Add(clsReqniveausatisfactionDTO);
                    return clsReqniveausatisfactionDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction clsReqniveausatisfactionDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction();
                    clsReqniveausatisfactionDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsReqniveausatisfactionDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqniveausatisfactionDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqniveausatisfactionDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqniveausatisfactionDTOs.Add(clsReqniveausatisfactionDTO);
                    return clsReqniveausatisfactionDTOs;
                }

            }

            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqniveausatisfactionWSBLL clsReqniveausatisfactionWSBLL = new clsReqniveausatisfactionWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqniveausatisfactionWSBLL.pvgChargerDansDataSetPourCombo(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {//NS_CODENIVEAUSATISFACTION , NS_LIBELLENIVEAUSATISFACTION
                                MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction clsReqniveausatisfactionDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction();
                                clsReqniveausatisfactionDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsReqniveausatisfactionDTOR.NS_CODENIVEAUSATISFACTION = DataRow["NS_CODENIVEAUSATISFACTION"].ToString();
                                clsReqniveausatisfactionDTOR.NS_LIBELLENIVEAUSATISFACTION = DataRow["NS_LIBELLENIVEAUSATISFACTION"].ToString();
                                clsReqniveausatisfactionDTOR.NS_LIBELLENIVEAUSATISFACTION_TRANSLATE = "";
                                clsReqniveausatisfactionDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqniveausatisfactionDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqniveausatisfactionDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqniveausatisfactionDTOs.Add(clsReqniveausatisfactionDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction clsReqniveausatisfactionDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction();
                            clsReqniveausatisfactionDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsReqniveausatisfactionDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsReqniveausatisfactionDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsReqniveausatisfactionDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsReqniveausatisfactionDTOs.Add(clsReqniveausatisfactionDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction clsReqniveausatisfactionDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction();
                        clsReqniveausatisfactionDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsReqniveausatisfactionDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsReqniveausatisfactionDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsReqniveausatisfactionDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                        clsReqniveausatisfactionDTOs.Add(clsReqniveausatisfactionDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction clsReqniveausatisfactionDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction();
                clsReqniveausatisfactionDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqniveausatisfactionDTOR.clsResultat.SL_RESULTAT = "FALSE";
                clsReqniveausatisfactionDTOR.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqniveausatisfactionDTOs.Add(clsReqniveausatisfactionDTOR);
            }
            catch (Exception SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction clsReqniveausatisfactionDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction();
                clsReqniveausatisfactionDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsReqniveausatisfactionDTOR.clsResultat.SL_RESULTAT = "FALSE";
                clsReqniveausatisfactionDTOR.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqniveausatisfactionDTOs.Add(clsReqniveausatisfactionDTOR);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqniveausatisfactionDTOs;

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsAgence> pvgReqAgenceCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsAgence> clsReqclsAgenceDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsAgence>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsAgence clsAgenceDTO = new MgRequeteClients.DTO.BusinessObjects.clsAgence();
                    clsAgenceDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsAgenceDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsAgenceDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsAgenceDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqclsAgenceDTOs.Add(clsAgenceDTO);
                    return clsReqclsAgenceDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsAgence clsAgenceDTO = new MgRequeteClients.DTO.BusinessObjects.clsAgence();
                    clsAgenceDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                    //----EXEPTION
                    clsAgenceDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsAgenceDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsAgenceDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqclsAgenceDTOs.Add(clsAgenceDTO);
                    return clsReqclsAgenceDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqniveausatisfactionWSBLL clsReqniveausatisfactionWSBLL = new clsReqniveausatisfactionWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqniveausatisfactionWSBLL.pvgChargerDansDataSetPourComboAgence(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {//NS_CODENIVEAUSATISFACTION , NS_LIBELLENIVEAUSATISFACTION
                                MgRequeteClients.DTO.BusinessObjects.clsAgence clsAgenceDTOR = new MgRequeteClients.DTO.BusinessObjects.clsAgence();
                                clsAgenceDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                                clsAgenceDTOR.AG_CODEAGENCE = DataRow["AG_CODEAGENCE"].ToString();
                                clsAgenceDTOR.AG_RAISONSOCIAL = DataRow["AG_RAISONSOCIAL"].ToString();
                                clsAgenceDTOR.AG_RAISONSOCIAL_TRANSLATE = "";
                                clsAgenceDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsAgenceDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsAgenceDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqclsAgenceDTOs.Add(clsAgenceDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsAgence clsAgenceDTOR = new MgRequeteClients.DTO.BusinessObjects.clsAgence();
                            clsAgenceDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                            clsAgenceDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsAgenceDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsAgenceDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsReqclsAgenceDTOs.Add(clsAgenceDTOR);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsAgence clsAgenceDTOR = new MgRequeteClients.DTO.BusinessObjects.clsAgence();
                        clsAgenceDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                        clsAgenceDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsAgenceDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsAgenceDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                        clsReqclsAgenceDTOs.Add(clsAgenceDTOR);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsAgence clsAgenceDTOR = new MgRequeteClients.DTO.BusinessObjects.clsAgence();
                clsAgenceDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsAgenceDTOR.clsResultat.SL_RESULTAT = "FALSE";
                clsAgenceDTOR.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqclsAgenceDTOs.Add(clsAgenceDTOR);
            }
            catch (Exception SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsAgence clsAgenceDTOR = new MgRequeteClients.DTO.BusinessObjects.clsAgence();
                clsAgenceDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();;
                clsAgenceDTOR.clsResultat.SL_RESULTAT = "FALSE";
                clsAgenceDTOR.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqclsAgenceDTOs.Add(clsAgenceDTOR);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqclsAgenceDTOs;

        }


        //LISTE
        public string pvgChargerDansDataSetagencelogicielliaison(MgRequeteClients.BOJ.BusinessObjects.clsReqagencelogicielliaison Objet)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            string json = "";

            MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi clsObjetEnvoi = new MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi();
            MgRequeteClients.BOJ.BusinessObjects.clsReqagencelogicielliaison clsReqagencelogicielliaison = new MgRequeteClients.BOJ.BusinessObjects.clsReqagencelogicielliaison();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //--TEST DES CHAMPS OBLIGATOIRES
            //DataSet = TestChampObligatoireListe(Objet);
            //--VERIFICATION DU RESULTAT DU TEST
            //if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            //--TEST DES TYPES DE DONNEES
            //DataSet = TestTypeDonnee(Objet);
            //--VERIFICATION DU RESULTAT DU TEST
            //if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            //--TEST CONTRAINTE
            //DataSet = TestTestContrainteListe(Objet);
            //--VERIFICATION DU RESULTAT DU TEST
            //if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            //}

            MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour clsObjetRetour = new MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour();
            try
            {
                //_clsDonnee.pvgConnectionBase();
                _clsDonnee.pvgDemarrerTransaction();
                clsObjetEnvoi.OE_PARAM = new string[] { Objet.AG_CODEAGENCE, Objet.LO_CODELOGICIEL };

                //foreach (ZenithWebServeur.DTO.clsAgence clsAgenceDTO in Objet)
                //{


                DataSet = clsReqagencelogicielliaisonWSBLL.pvgChargerDansDataSet(_clsDonnee, clsObjetEnvoi);
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
                    for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                    {
                        DataSet.Tables[0].Rows[i]["SL_CODEMESSAGE"] = "00";
                        DataSet.Tables[0].Rows[i]["SL_RESULTAT"] = "TRUE";
                        DataSet.Tables[0].Rows[i]["SL_MESSAGE"] = "L'opération s'est réalisée avec succès";
                    }

                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
                else
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = "Aucun enregistrement n'a été trouvé";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
                //}
            }
            catch (SqlException SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

            }
            catch (Exception SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

            }

            finally
            {
                bool OR_BOOLEEN = true;
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE")
                {
                    OR_BOOLEEN = false;
                }
                _clsDonnee.pvgTerminerTransaction(!OR_BOOLEEN);
                //_clsDonnee.pvgDeConnectionBase();
            }

            return json;
        }

        //SERVICE DES REQUETES
        //AJOUT
        public string pvgAjouterReqrequete(MgRequeteClients.BOJ.BusinessObjects.clsReqrequete Objet)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            string json = "";

            MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi clsObjetEnvoi = new MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi();
            MgRequeteClients.BOJ.BusinessObjects.clsReqrequete clsReqrequete = new MgRequeteClients.BOJ.BusinessObjects.clsReqrequete();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //--TEST DES CHAMPS OBLIGATOIRES
            //DataSet = TestChampObligatoireInsert(Objet);
            ////--VERIFICATION DU RESULTAT DU TEST
            //if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            ////--TEST DES TYPES DE DONNEES
            //DataSet = TestTypeDonnee(Objet);
            ////--VERIFICATION DU RESULTAT DU TEST
            //if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            ////--TEST CONTRAINTE
            //DataSet = TestTestContrainteListe(Objet);
            ////--VERIFICATION DU RESULTAT DU TEST
            //if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            //}

            MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour clsObjetRetour = new MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour();
            try
            {
                //_clsDonnee.pvgConnectionBase();
                _clsDonnee.pvgDemarrerTransaction();
                clsObjetEnvoi.OE_PARAM = new string[] { };



                clsReqrequete.RQ_CODEREQUETE = Objet.RQ_CODEREQUETE.ToString();
                clsReqrequete.TR_CODETYEREQUETE = Objet.TR_CODETYEREQUETE.ToString();
                clsReqrequete.RQ_NUMEROREQUETE = Objet.RQ_NUMEROREQUETE.ToString();
                clsReqrequete.RQ_NUMERORECOMPTE = Objet.RQ_NUMERORECOMPTE.ToString();
                clsReqrequete.CU_CODECOMPTEUTULISATEUR = Objet.CU_CODECOMPTEUTULISATEUR.ToString();
                clsReqrequete.RQ_LOCALISATIONCLIENT = Objet.RQ_LOCALISATIONCLIENT.ToString();
                clsReqrequete.RQ_DESCRIPTIONREQUETE = Objet.RQ_DESCRIPTIONREQUETE.ToString();
                clsReqrequete.MC_CODEMODECOLLETE = Objet.MC_CODEMODECOLLETE.ToString();
                clsReqrequete.RQ_DATESAISIEREQUETE = DateTime.Parse(Objet.RQ_DATESAISIEREQUETE.ToString());
                clsReqrequete.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = Objet.CU_CODECOMPTEUTULISATEURAGENTENCHARGE.ToString();
                clsReqrequete.RQ_DATETRANSFERTREQUETE = DateTime.Parse(Objet.RQ_DATETRANSFERTREQUETE.ToString());
                clsReqrequete.RQ_CODEREQUETERELANCEE = Objet.RQ_CODEREQUETERELANCEE.ToString();

                Byte[] RQ_SIGNATURE = null;
                if (Objet.RQ_SIGNATURE1 != "")
                    RQ_SIGNATURE = System.Convert.FromBase64String(Objet.RQ_SIGNATURE1);
                clsReqrequete.RQ_SIGNATURE = RQ_SIGNATURE;
                clsReqrequete.RS_CODESTATUTRECEVABILITE = Objet.RS_CODESTATUTRECEVABILITE.ToString();
                clsReqrequete.RQ_OBJETREQUETE = Objet.RQ_OBJETREQUETE.ToString();
                clsReqrequete.SR_CODESERVICE = Objet.SR_CODESERVICE.ToString();
                clsReqrequete.RQ_DELAITRAITEMENTREQUETE = Objet.RQ_DELAITRAITEMENTREQUETE.ToString();
                clsReqrequete.RQ_OBSERVATIONDELAITRAITEMENTREQUETE = Objet.RQ_OBSERVATIONDELAITRAITEMENTREQUETE.ToString();
                clsReqrequete.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = Objet.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE.ToString();
                clsReqrequete.RQ_DUREETRAITEMENTREQUETE = Objet.RQ_DUREETRAITEMENTREQUETE.ToString();
                clsReqrequete.RQ_DATEDEBUTTRAITEMENTREQUETE = DateTime.Parse(Objet.RQ_DATEDEBUTTRAITEMENTREQUETE.ToString());
                clsReqrequete.RQ_DATEFINTRAITEMENTREQUETE = DateTime.Parse(Objet.RQ_DATEFINTRAITEMENTREQUETE.ToString());
                clsReqrequete.AC_CODEACTIONCORRECTIVE = Objet.AC_CODEACTIONCORRECTIVE.ToString();
                clsReqrequete.NS_CODENIVEAUSATISFACTION = Objet.NS_CODENIVEAUSATISFACTION.ToString();
                clsReqrequete.RQ_DATECLOTUREREQUETE = DateTime.Parse(Objet.RQ_DATECLOTUREREQUETE.ToString());


                clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgAjouter(_clsDonnee, clsReqrequete, clsObjetEnvoi));
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    DataSet = new DataSet();
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
            catch (SqlException SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

            }
            catch (Exception SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

            }

            finally
            {
                bool OR_BOOLEEN = true;
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE")
                {
                    OR_BOOLEEN = false;
                }
                _clsDonnee.pvgTerminerTransaction(!OR_BOOLEEN);
                //_clsDonnee.pvgDeConnectionBase();
            }

            return json;
        }

        public string pvgNomDeLaStructure(string PP_CODEPARAMETRE)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            string json = "";

            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTORs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi clsObjetEnvoi = new MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi();
            MgRequeteClients.BOJ.BusinessObjects.clsReqrequete clsReqrequete = new MgRequeteClients.BOJ.BusinessObjects.clsReqrequete();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour clsObjetRetour = new MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour();
            try
            {
                //_clsDonnee.pvgConnectionBase();
                _clsDonnee.pvgDemarrerTransaction();
                clsObjetEnvoi.OE_PARAM = new string[] { };

                clsReqrequete.PP_CODEPARAMETRE = PP_CODEPARAMETRE.ToString();

                DataSet = clsReqrequeteWSBLL.pvgNomDeLaStructure(_clsDonnee, clsReqrequete, clsObjetEnvoi);
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
                    DataSet.Tables[0].Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
                    for (int i = 0; i < DataSet.Tables[0].Rows.Count; i++)
                    {
                        DataSet.Tables[0].Rows[i]["SL_CODEMESSAGE"] = "00";
                        DataSet.Tables[0].Rows[i]["SL_RESULTAT"] = "TRUE";
                        DataSet.Tables[0].Rows[i]["SL_MESSAGE"] = "L'opération s'est réalisée avec succès";
                    }

                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
                else
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "99";
                    dr["SL_RESULTAT"] = "FALSE";
                    dr["SL_MESSAGE"] = "Aucun enregistrement n'a été trouvé";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }
            }
            catch (SqlException SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

            }
            catch (Exception SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

            }

            finally
            {
                bool OR_BOOLEEN = true;
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE")
                {
                    OR_BOOLEEN = false;
                }
                _clsDonnee.pvgTerminerTransaction(!OR_BOOLEEN);
                //_clsDonnee.pvgDeConnectionBase();
            }

            return json;
        }

        //AJOUT
        public string pvgModifierReqrequete(MgRequeteClients.BOJ.BusinessObjects.clsReqrequete Objet)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            string json = "";

            MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi clsObjetEnvoi = new MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi();
            MgRequeteClients.BOJ.BusinessObjects.clsReqrequete clsReqrequete = new MgRequeteClients.BOJ.BusinessObjects.clsReqrequete();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;

            //for (int Idx = 0; Idx < Objet.Count; Idx++)
            //{
            //--TEST DES CHAMPS OBLIGATOIRES
            //DataSet = TestChampObligatoireInsert(Objet);
            ////--VERIFICATION DU RESULTAT DU TEST
            //if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            ////--TEST DES TYPES DE DONNEES
            //DataSet = TestTypeDonnee(Objet);
            ////--VERIFICATION DU RESULTAT DU TEST
            //if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            ////--TEST CONTRAINTE
            //DataSet = TestTestContrainteListe(Objet);
            ////--VERIFICATION DU RESULTAT DU TEST
            //if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE") { json = JsonConvert.SerializeObject(DataSet, Formatting.Indented); return json; }
            //}

            MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour clsObjetRetour = new MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour();
            try
            {
                //_clsDonnee.pvgConnectionBase();
                _clsDonnee.pvgDemarrerTransaction();
                clsObjetEnvoi.OE_PARAM = new string[] { };



                clsReqrequete.RQ_CODEREQUETE = Objet.RQ_CODEREQUETE.ToString();
                clsReqrequete.TR_CODETYEREQUETE = Objet.TR_CODETYEREQUETE.ToString();
                clsReqrequete.RQ_NUMEROREQUETE = Objet.RQ_NUMEROREQUETE.ToString();
                clsReqrequete.RQ_NUMERORECOMPTE = Objet.RQ_NUMERORECOMPTE.ToString();
                clsReqrequete.CU_CODECOMPTEUTULISATEUR = Objet.CU_CODECOMPTEUTULISATEUR.ToString();
                clsReqrequete.RQ_LOCALISATIONCLIENT = Objet.RQ_LOCALISATIONCLIENT.ToString();
                clsReqrequete.RQ_DESCRIPTIONREQUETE = Objet.RQ_DESCRIPTIONREQUETE.ToString();
                clsReqrequete.MC_CODEMODECOLLETE = Objet.MC_CODEMODECOLLETE.ToString();
                clsReqrequete.RQ_DATESAISIEREQUETE = DateTime.Parse(Objet.RQ_DATESAISIEREQUETE.ToString());
                clsReqrequete.CU_CODECOMPTEUTULISATEURAGENTENCHARGE = Objet.CU_CODECOMPTEUTULISATEURAGENTENCHARGE.ToString();
                clsReqrequete.RQ_DATETRANSFERTREQUETE = DateTime.Parse(Objet.RQ_DATETRANSFERTREQUETE.ToString());
                clsReqrequete.RQ_CODEREQUETERELANCEE = Objet.RQ_CODEREQUETERELANCEE.ToString();

                Byte[] RQ_SIGNATURE = null;
                if (Objet.RQ_SIGNATURE1 != "")
                    RQ_SIGNATURE = System.Convert.FromBase64String(Objet.RQ_SIGNATURE1);
                clsReqrequete.RQ_SIGNATURE = RQ_SIGNATURE;
                clsReqrequete.RS_CODESTATUTRECEVABILITE = Objet.RS_CODESTATUTRECEVABILITE.ToString();
                clsReqrequete.RQ_OBJETREQUETE = Objet.RQ_OBJETREQUETE.ToString();
                clsReqrequete.SR_CODESERVICE = Objet.SR_CODESERVICE.ToString();
                clsReqrequete.RQ_DELAITRAITEMENTREQUETE = Objet.RQ_DELAITRAITEMENTREQUETE.ToString();
                clsReqrequete.RQ_OBSERVATIONDELAITRAITEMENTREQUETE = Objet.RQ_OBSERVATIONDELAITRAITEMENTREQUETE.ToString();
                clsReqrequete.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = Objet.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE.ToString();
                clsReqrequete.RQ_DUREETRAITEMENTREQUETE = Objet.RQ_DUREETRAITEMENTREQUETE.ToString();
                clsReqrequete.RQ_DATEDEBUTTRAITEMENTREQUETE = DateTime.Parse(Objet.RQ_DATEDEBUTTRAITEMENTREQUETE.ToString());
                clsReqrequete.RQ_DATEFINTRAITEMENTREQUETE = DateTime.Parse(Objet.RQ_DATEFINTRAITEMENTREQUETE.ToString());
                clsReqrequete.AC_CODEACTIONCORRECTIVE = Objet.AC_CODEACTIONCORRECTIVE.ToString();
                clsReqrequete.NS_CODENIVEAUSATISFACTION = Objet.NS_CODENIVEAUSATISFACTION.ToString();
                clsReqrequete.RQ_DATECLOTUREREQUETE = DateTime.Parse(Objet.RQ_DATECLOTUREREQUETE.ToString());


                clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgModifier(_clsDonnee, clsReqrequete, clsObjetEnvoi));
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    DataSet = new DataSet();
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
            catch (SqlException SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

            }
            catch (Exception SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

            }

            finally
            {
                bool OR_BOOLEEN = true;
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE")
                {
                    OR_BOOLEEN = false;
                }
                _clsDonnee.pvgTerminerTransaction(!OR_BOOLEEN);
                //_clsDonnee.pvgDeConnectionBase();
            }

            return json;
        }



        public List<MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO> pvgFrequenceReclamation(string AG_CODEAGENCE, string RQ_DATEDEBUT, string RQ_DATEFIN, string CU_CODECOMPTEUTULISATEUR, string TYPEETAT)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO> clsFrequenceReclamationDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO>();
            MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO clsFrequenceReclamationDTO = new MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO();

            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                clsFrequenceReclamationDTO = new MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO();
                clsFrequenceReclamationDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                //----EXEPTION
                clsFrequenceReclamationDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsFrequenceReclamationDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsFrequenceReclamationDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AG_CODEAGENCE";
                clsFrequenceReclamationDTOs.Add(clsFrequenceReclamationDTO);
                return clsFrequenceReclamationDTOs;
            }

            if (string.IsNullOrEmpty(RQ_DATEDEBUT))
            {
                clsFrequenceReclamationDTO = new MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO();
                clsFrequenceReclamationDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                //----EXEPTION
                clsFrequenceReclamationDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsFrequenceReclamationDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsFrequenceReclamationDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DATEDEBUT";
                clsFrequenceReclamationDTOs.Add(clsFrequenceReclamationDTO);
                return clsFrequenceReclamationDTOs;
            }

            if (string.IsNullOrEmpty(RQ_DATEFIN))
            {
                clsFrequenceReclamationDTO = new MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO();
                clsFrequenceReclamationDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                //----EXEPTION
                clsFrequenceReclamationDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsFrequenceReclamationDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsFrequenceReclamationDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DATEFIN";
                clsFrequenceReclamationDTOs.Add(clsFrequenceReclamationDTO);
                return clsFrequenceReclamationDTOs;
            }
            if (string.IsNullOrEmpty(TYPEETAT))
            {
                clsFrequenceReclamationDTO = new MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO();
                clsFrequenceReclamationDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                //----EXEPTION
                clsFrequenceReclamationDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsFrequenceReclamationDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsFrequenceReclamationDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEETAT";
                clsFrequenceReclamationDTOs.Add(clsFrequenceReclamationDTO);
                return clsFrequenceReclamationDTOs;
            }

            try
            {

                _clsDonnee.pvgDemarrerTransaction();

                clsObjetEnvoi = new clsObjetEnvoi();
                clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();

                //TYPEETAT = "TSCLT";
                clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, RQ_DATEDEBUT, RQ_DATEFIN, CU_CODECOMPTEUTULISATEUR, TYPEETAT };

                clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSetFrequenceReclamation(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO clsFrequenceReclamationDTOR = new MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO();
                            clsFrequenceReclamationDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                            clsFrequenceReclamationDTOR.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                            clsFrequenceReclamationDTOR.CU_NUMEROUTILISATEUR = DataRow["CU_NUMEROUTILISATEUR"].ToString();
                            clsFrequenceReclamationDTOR.CU_NOMUTILISATEUR = DataRow["CU_NOMUTILISATEUR"].ToString();
                            clsFrequenceReclamationDTOR.CU_CONTACT = DataRow["CU_CONTACT"].ToString();
                            clsFrequenceReclamationDTOR.CU_EMAIL = DataRow["CU_EMAIL"].ToString();
                            //clsFrequenceReclamationDTOR.CANAL = DataRow["CANAL"].ToString();

                            string canal = DataRow["CANAL"].ToString();
                            string[] canaux = canal.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                            Dictionary<string, int> occurences = new Dictionary<string, int>();

                            // Compter le nombre d'occurrences de chaque élément
                            foreach (string element in canaux)
                            {
                                if (occurences.ContainsKey(element))
                                {
                                    occurences[element]++;
                                }
                                else
                                {
                                    occurences[element] = 1;
                                }
                            }

                            // Construire la chaîne avec le nombre d'occurrences devant chaque élément distinct
                            List<string> resultats = new List<string>();
                            foreach (var kvp in occurences)
                            {
                                resultats.Add($"{kvp.Value} fois  {kvp.Key}");
                            }

                            string canalAvecOccurences = string.Join("-", resultats);
                            clsFrequenceReclamationDTOR.CANAL = canalAvecOccurences;

                            if (DataRow["NOMBRE"].ToString() != "")
                                clsFrequenceReclamationDTOR.NOMBRE = int.Parse(DataRow["NOMBRE"].ToString()).ToString();
                            else
                                clsFrequenceReclamationDTOR.NOMBRE = "0";

                            clsFrequenceReclamationDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsFrequenceReclamationDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsFrequenceReclamationDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsFrequenceReclamationDTOs.Add(clsFrequenceReclamationDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO clsFrequenceReclamationDTOR = new MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO();
                        clsFrequenceReclamationDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        clsFrequenceReclamationDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsFrequenceReclamationDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsFrequenceReclamationDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsFrequenceReclamationDTOs.Add(clsFrequenceReclamationDTOR);
                    }
                }
                else
                {
                    MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO clsFrequenceReclamationDTOR = new MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO();
                    clsFrequenceReclamationDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    clsFrequenceReclamationDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                    clsFrequenceReclamationDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsFrequenceReclamationDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                    clsFrequenceReclamationDTOs.Add(clsFrequenceReclamationDTOR);
                }
            }

            catch (SqlException SQLEx)
            {
                clsFrequenceReclamationDTO = new MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO();
                clsFrequenceReclamationDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                clsFrequenceReclamationDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsFrequenceReclamationDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsFrequenceReclamationDTOs.Add(clsFrequenceReclamationDTO);
            }
            catch (Exception e)
            {
                clsFrequenceReclamationDTO = new MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO();
                clsFrequenceReclamationDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                clsFrequenceReclamationDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsFrequenceReclamationDTO.clsResultat.SL_MESSAGE = e.Message;
                clsFrequenceReclamationDTOs.Add(clsFrequenceReclamationDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }

            return clsFrequenceReclamationDTOs;
        }


        public List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgChargerDansDataSetDASHBOARD(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();

            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOs;
                }
            }

            try
            {
                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSetDASHBOARD(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                                clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                                clsReqrequeteDTOR.NOMBREREQUETESTOTAL = DataRow["NOMBREREQUETESTOTAL"].ToString();
                                clsReqrequeteDTOR.NOMBREREQUETES = DataRow["NOMBREREQUETES"].ToString();
                                clsReqrequeteDTOR.NOMBREREQUETESENCOURS = DataRow["NOMBREREQUETESENCOURS"].ToString();
                                clsReqrequeteDTOR.NOMBREREQUETESATTRIBUEES = DataRow["NOMBREREQUETESATTRIBUEES"].ToString();
                                clsReqrequeteDTOR.NOMBREREQUETEDEJATRAITER = DataRow["NOMBREREQUETEDEJATRAITER"].ToString();
                                clsReqrequeteDTOR.NOMBREREQUETESTRAITEESDANSDELAIS = DataRow["NOMBREREQUETESTRAITEESDANSDELAIS"].ToString();
                                clsReqrequeteDTOR.NOMBREREQUETESTRAITEESHORSDELAIS = DataRow["NOMBREREQUETESTRAITEESHORSDELAIS"].ToString();

                                clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                            clsReqrequeteDTOR.NOMBREREQUETESTOTAL = "0";
                            clsReqrequeteDTOR.NOMBREREQUETES = "0";
                            clsReqrequeteDTOR.NOMBREREQUETESENCOURS = "0";
                            clsReqrequeteDTOR.NOMBREREQUETESATTRIBUEES = "0";
                            clsReqrequeteDTOR.NOMBREREQUETEDEJATRAITER = "0";
                            clsReqrequeteDTOR.NOMBREREQUETESTRAITEESDANSDELAIS = "0";
                            clsReqrequeteDTOR.NOMBREREQUETESTRAITEESHORSDELAIS = "0";
                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTOs.Add(clsReqrequeteDTOR);
                    }
                }
            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }

            return clsReqrequeteDTOs;
        }

        public MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord pvgTableauDeBordstatistique(string AG_CODEAGENCE, string RQ_DATEDEBUT, string RQ_DATEFIN, string CU_CODECOMPTEUTULISATEUR, string TYPEETAT)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord>();
            MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
            clsReqrequeteDTO.clsTableauDeBordSituationPlaintes = new List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordSituationPlainte>();
            clsReqrequeteDTO.clsTableauDeBordTauxSatisfactions = new List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction>();

            clsReqrequeteDTO.clsTableauDeBordDelaiTraiPlaintes = new List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre>();
            clsReqrequeteDTO.clsTableauDeBordNatPlainteRecurs = new List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre>();
            clsReqrequeteDTO.clsTableauDeBordNbrePlainterefs = new List<MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordAutre>();

            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            if (string.IsNullOrEmpty(AG_CODEAGENCE))
            {
                clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                //----EXEPTION
                clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " AG_CODEAGENCE";
                //clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                return clsReqrequeteDTO;
            }

            if (string.IsNullOrEmpty(RQ_DATEDEBUT))
            {
                clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                //----EXEPTION
                clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DATEDEBUT";
                //clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                return clsReqrequeteDTO;
            }

            if (string.IsNullOrEmpty(RQ_DATEFIN))
            {
                clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                //----EXEPTION
                clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_DATEFIN";
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                return clsReqrequeteDTO;
            }
            if (string.IsNullOrEmpty(TYPEETAT))
            {
                clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                //----EXEPTION
                clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEETAT";
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
                return clsReqrequeteDTO;
            }

            try
            {
                _clsDonnee.pvgDemarrerTransaction();

                clsObjetEnvoi = new clsObjetEnvoi();
                clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
                //===
                //clsObjetEnvoi.OE_PARAM = clsObjetEnvoiListe.OE_PARAM;
                //TYPEETAT = "TSCLT";
                clsObjetEnvoi.OE_PARAM = new string[] { AG_CODEAGENCE, RQ_DATEDEBUT, RQ_DATEFIN, CU_CODECOMPTEUTULISATEUR, TYPEETAT };

                //====
                clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDansDataSetTableauDeBordstatistique(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction();
                            clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                            clsReqrequeteDTOR.TR_CODETYEREQUETE = DataRow["TR_CODETYEREQUETE"].ToString();
                            clsReqrequeteDTOR.TR_LIBELLETYEREQUETE = DataRow["TR_LIBELLETYEREQUETE"].ToString();
                            if (DataRow["NOMBRE"].ToString() != "")
                                clsReqrequeteDTOR.NOMBRE = int.Parse(DataRow["NOMBRE"].ToString()).ToString();
                            else
                                clsReqrequeteDTOR.NOMBRE = "0";
                            clsReqrequeteDTOR.NR_CODENATUREREQUETE = DataRow["NR_CODENATUREREQUETE"].ToString();

                            clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                            clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                            clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                            clsReqrequeteDTO.clsTableauDeBordTauxSatisfactions.Add(clsReqrequeteDTOR);
                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction();
                        clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsReqrequeteDTO.clsTableauDeBordTauxSatisfactions.Add(clsReqrequeteDTOR);
                    }
                }
                else
                {
                    MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction clsReqrequeteDTOR = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBordTauxSatisfaction();
                    clsReqrequeteDTOR.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    clsReqrequeteDTOR.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                    clsReqrequeteDTOR.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTOR.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                    clsReqrequeteDTO.clsTableauDeBordTauxSatisfactions.Add(clsReqrequeteDTOR);
                }

                if (clsReqrequeteDTO.clsTableauDeBordTauxSatisfactions != null)
                {
                    if (clsReqrequeteDTO.clsTableauDeBordTauxSatisfactions.Count > 0)
                    {
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                        clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                        clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                    }
                    else
                    {
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                    }
                }
            }
            catch (SqlException SQLEx)
            {
                clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            catch (Exception e)
            {
                clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteDTOs.Add(clsReqrequeteDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }

            return clsReqrequeteDTO;
        }



        public MgRequeteClients.DTO.BusinessObjects.clsReqrequete pvgMajReqrequeteAvisclient(List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTOAVIs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();


            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequete in Objets)
            {
                if (clsReqrequete.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsReqrequeteDTOAVIs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOAVIs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequete.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsReqrequeteDTOAVIs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOAVIs[0];
                }
                if (string.IsNullOrEmpty(clsReqrequete.RQ_CODEREQUETE) && (clsReqrequete.clsObjetEnvoi.TYPEOPERATION == "11"))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " RQ_CODEREQUETE";
                    clsReqrequeteDTOAVIs.Add(clsReqrequeteDTO);
                    return clsReqrequeteDTOAVIs[0];
                }



            }


            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                // foreach (MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO in Objets)
                // {
                clsObjetEnvoi = new clsObjetEnvoi();
                clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
                //===
                MgRequeteClients.BOJ.BusinessObjects.clsReqrequete clsReqrequeteBOJ = new clsReqrequete();
                clsReqrequeteBOJ.RQ_CODEREQUETE = Objets[0].RQ_CODEREQUETE;
                clsReqrequeteBOJ.RQ_OBSERVATIONAGENTTRAITEMENTREQUETE = Objets[0].RQ_OBSERVATIONAGENTTRAITEMENTREQUETE;
                clsReqrequeteBOJ.NS_CODENIVEAUSATISFACTION = Objets[0].NS_CODENIVEAUSATISFACTION;
                clsReqrequeteBOJ.TYPEOPERATION = Objets[0].clsObjetEnvoi.TYPEOPERATION;
                //====
                clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgMiseajourAvisclient(_clsDonnee, clsReqrequeteBOJ, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    clsParams clsParams = new clsParams();
                    clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();


                    MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTORss = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                    clsReqrequeteDTORss.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    clsReqrequeteDTORss.RQ_CODEREQUETE = clsReqrequeteBOJ.RQ_CODEREQUETE == "" ? clsObjetRetour.OR_STRING : clsReqrequeteBOJ.RQ_CODEREQUETE;
                    clsReqrequeteDTORss.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                    clsReqrequeteDTORss.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                    clsReqrequeteDTORss.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                    clsReqrequeteDTOAVIs.Add(clsReqrequeteDTORss);
                }
                // }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsReqrequeteDTOAVIs.Add(clsReqrequeteDTO);
            }
            catch (Exception e)
            {
                MgRequeteClients.DTO.BusinessObjects.clsReqrequete clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsReqrequete();
                clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                clsReqrequeteDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsReqrequeteDTO.clsResultat.SL_MESSAGE = e.Message;
                clsReqrequeteDTOAVIs.Add(clsReqrequeteDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsReqrequeteDTOAVIs[0];

        }




        public string pvgAjouterdroitOperateur(List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> Objet)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));
            string json = "";
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();

            List<MgRequeteClients.BOJ.BusinessObjects.clsRequtilisateurdroitparametre> clsOperateurdroitAjout = new List<MgRequeteClients.BOJ.BusinessObjects.clsRequtilisateurdroitparametre>();
            //List<ZenithWebServeur.BOJ.clsOperateurdroitagence> clsOperateurdroitagenceAjout = new List<ZenithWebServeur.BOJ.clsOperateurdroitagence>();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;



            try
            {
                //clsDonnee.pvgConnectionBase();
                _clsDonnee.pvgDemarrerTransaction();


                clsObjetEnvoi.OE_PARAM = new string[] { "O" };

                foreach (MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO in Objet)
                {
                    //ZenithWebServeur.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new ZenithWebServeur.BOJ.clsOperateurdroitagence();
                    clsObjetEnvoi = new clsObjetEnvoi();
                    MgRequeteClients.BOJ.BusinessObjects.clsRequtilisateurdroitparametre clsOperateurdroitoperateur = new MgRequeteClients.BOJ.BusinessObjects.clsRequtilisateurdroitparametre();
                    clsOperateurdroitoperateur.CU_CODECOMPTEUTULISATEUR = clsRequtilisateurdroitparametreDTO.CU_CODECOMPTEUTULISATEUR.ToString();
                    clsOperateurdroitoperateur.DP_CODEDROITCOMPTEUTULISATEUR = clsRequtilisateurdroitparametreDTO.DP_CODEDROITCOMPTEUTULISATEUR.ToString();
                    clsOperateurdroitoperateur.DP_LIBELLEDROITCOMPTEUTULISATEUR = clsRequtilisateurdroitparametreDTO.DP_LIBELLEDROITCOMPTEUTULISATEUR.ToString();
                    clsOperateurdroitoperateur.DP_STATUT = clsRequtilisateurdroitparametreDTO.DP_STATUT.ToString();

                    clsOperateurdroitAjout.Add(clsOperateurdroitoperateur);


                }
                // clsObjetRetour.SetValue(true, clsOperateurdroitagenceWSBLL.pvgAjouterdroit(clsDonnee, clsOperateurdroitagenceAjout, clsObjetEnvoi));
                clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgAjouterdroit(_clsDonnee, clsOperateurdroitAjout, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    DataSet = new DataSet();
                    DataRow dr = dt.NewRow();
                    dr["SL_CODEMESSAGE"] = "00";
                    dr["SL_RESULTAT"] = "TRUE";
                    dr["SL_MESSAGE"] = "L'opération s'est réalisée avec succès";
                    dt.Rows.Add(dr);
                    DataSet.Tables.Add(dt);
                    json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);
                }

            }
            catch (SqlException SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

            }
            catch (Exception SQLEx)
            {
                DataSet = new DataSet();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "99";
                dr["SL_RESULTAT"] = "FALSE";
                dr["SL_MESSAGE"] = SQLEx.Message;
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                json = JsonConvert.SerializeObject(DataSet, Formatting.Indented);

            }

            finally
            {
                bool OR_BOOLEEN = true;
                if (DataSet.Tables[0].Rows[0]["SL_RESULTAT"].ToString() == "FALSE")
                {
                    OR_BOOLEEN = false;
                }
                _clsDonnee.pvgTerminerTransaction(!OR_BOOLEEN);
                //clsDonnee.pvgDeConnectionBase();
            }

            return json;
        }



        public List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> pvgDroitParOperateurs(List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> Objets)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();

            clsObjetEnvoi clsObjetEnvoi = new clsObjetEnvoi();
            clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
            clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
            _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
            //List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> clsReqrequeteDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete>();
            List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> clsRequtilisateurdroitparametreDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre>();

            var culture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsObjetEnvoiListe in Objets)
            {
                if (clsObjetEnvoiListe.clsObjetEnvoi == null)
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " clsObjetEnvoi";
                    clsRequtilisateurdroitparametreDTOs.Add(clsReqrequeteDTO);
                    return clsRequtilisateurdroitparametreDTOs;
                }
                if (string.IsNullOrEmpty(clsObjetEnvoiListe.clsObjetEnvoi.TYPEOPERATION))
                {
                    MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsReqrequeteDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                    clsReqrequeteDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                    //----EXEPTION
                    clsReqrequeteDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_ERROR_SAISIE_OBLIG;
                    clsReqrequeteDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                    clsReqrequeteDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_SAISIE_OBLIGATOIRE + " TYPEOPERATION";
                    clsRequtilisateurdroitparametreDTOs.Add(clsReqrequeteDTO);
                    return clsRequtilisateurdroitparametreDTOs;
                }

            }




            try
            {

                _clsDonnee.pvgDemarrerTransaction();
                foreach (MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsObjetEnvoiListe in Objets)
                {
                    clsObjetEnvoi = new clsObjetEnvoi();
                    clsReqrequeteWSBLL clsReqrequeteWSBLL = new clsReqrequeteWSBLL();
                    //===
                    clsObjetEnvoi.OE_PARAM[0] = clsObjetEnvoiListe.CU_CODECOMPTEUTULISATEUR;

                    //====
                    clsObjetRetour.SetValue(true, clsReqrequeteWSBLL.pvgChargerDroitParOperateurs(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                    if (clsObjetRetour.OR_BOOLEEN)
                    {
                        if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DataRow in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                            {
                                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                                clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                                clsRequtilisateurdroitparametreDTO.CU_CODECOMPTEUTULISATEUR = DataRow["CU_CODECOMPTEUTULISATEUR"].ToString();
                                clsRequtilisateurdroitparametreDTO.DP_CODEDROITCOMPTEUTULISATEUR = DataRow["DP_CODEDROITCOMPTEUTULISATEUR"].ToString();
                                clsRequtilisateurdroitparametreDTO.DP_LIBELLEDROITCOMPTEUTULISATEUR = DataRow["DP_LIBELLEDROITCOMPTEUTULISATEUR"].ToString();
                                clsRequtilisateurdroitparametreDTO.DP_STATUT = DataRow["DP_STATUT"].ToString();
                                clsRequtilisateurdroitparametreDTO.DP_OBJET = DataRow["DP_OBJET"].ToString();


                                clsRequtilisateurdroitparametreDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_SUCCESS;
                                clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.SUCCESS_RESULTAT;
                                clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE;
                                clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                            }
                        }
                        else
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                            clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                            clsRequtilisateurdroitparametreDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                            clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                            clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                            clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                        }


                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                        clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                        clsRequtilisateurdroitparametreDTO.clsResultat.SL_CODEMESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.CODE_TYPE_OP_REQUIS;
                        clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.ERROR_RESULTAT;
                        clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_AUCUN_ELT_TROUVE;
                        clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                    }
                }

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = SQLEx.Message;
                clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
            }
            catch (Exception e)
            {

                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                clsRequtilisateurdroitparametreDTO.clsResultat = new MgRequeteClients.DTO.BusinessObjects.clsResultat();
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitparametreDTO.clsResultat.SL_MESSAGE = e.Message;
                clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }


            return clsRequtilisateurdroitparametreDTOs;

        }

        public List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> pvgInsertIntoDatasetListeDroitUtilisateur()
        {
            List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> clsRequtilisateurdroitparametreDTOs = new List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre>();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour clsObjetRetour = new MgRequeteClients.BOJ.BusinessObjects.clsObjetRetour();

            MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi clsObjetEnvoi = new MgRequeteClients.BOJ.BusinessObjects.clsObjetEnvoi();
            MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet clsEditionEtatGuichet = new MgRequeteClients.BOJ.BusinessObjects.clsEditionEtatGuichet();


            clsObjetEnvoi.OE_PARAM = new string[] { };

            try
            {
                clsObjetEnvoi.OE_D = _configuration.GetSection("ApiEndpoints:OE_D").Value ?? string.Empty;
                clsObjetEnvoi.OE_X = _configuration.GetSection("ApiEndpoints:OE_X").Value ?? string.Empty;
                _clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                _clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                _clsDonnee.pvgDemarrerTransaction();

                // clsObjetRetour.SetValue(true, clsRequtilisateurdroitparametreWSBLL.pvgCharger(clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                clsObjetRetour.SetValue(true, clsEditionWSBLL.pvgInsertIntoDatasetDroitUtilisateur(_clsDonnee, clsObjetEnvoi), MgRequeteClients.BOJ.BusinessObjects.clsDeclaration.MSG_LIBELLE_MISE_A_JOUR_EFFECTUEE);
                if (clsObjetRetour.OR_BOOLEEN)
                {
                    if (clsObjetRetour.OR_DATASET.Tables[0].Rows.Count > 0)
                    {

                        // DataTable tableAgence = new DataTable();
                        foreach (DataRow row in clsObjetRetour.OR_DATASET.Tables[0].Rows)
                        {
                            MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();

                            clsRequtilisateurdroitparametreDTO.DP_CODEDROITCOMPTEUTULISATEUR = row["DP_CODEDROITCOMPTEUTULISATEUR"].ToString();
                            clsRequtilisateurdroitparametreDTO.DP_LIBELLEDROITCOMPTEUTULISATEUR = row["DP_LIBELLEDROITCOMPTEUTULISATEUR"].ToString();
                            clsRequtilisateurdroitparametreDTO.DP_STATUT = row["DP_STATUT"].ToString();

                            clsRequtilisateurdroitparametreDTO.SL_RESULTAT = "TRUE";
                            clsRequtilisateurdroitparametreDTO.SL_MESSAGE = "Opération réalisée avec succès !!!";
                            clsRequtilisateurdroitparametreDTO.SL_CODEMESSAGE = "00";

                            clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);

                        }
                    }
                    else
                    {
                        MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                        clsRequtilisateurdroitparametreDTO.SL_RESULTAT = "FALSE";
                        clsRequtilisateurdroitparametreDTO.SL_MESSAGE = "Aucun élément trouvé !!!";
                        clsRequtilisateurdroitparametreDTO.SL_CODEMESSAGE = "00";

                        clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                    }

                }
                // clsObjetRetour.OR_DATASET

            }

            catch (SqlException SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                clsRequtilisateurdroitparametreDTO.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitparametreDTO.SL_MESSAGE = SQLEx.Message;
                clsRequtilisateurdroitparametreDTO.SL_CODEMESSAGE = "00";
                clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            catch (Exception SQLEx)
            {
                MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre clsRequtilisateurdroitparametreDTO = new MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre();
                clsRequtilisateurdroitparametreDTO.SL_RESULTAT = "FALSE";
                clsRequtilisateurdroitparametreDTO.SL_MESSAGE = SQLEx.Message;
                clsRequtilisateurdroitparametreDTO.SL_CODEMESSAGE = "00";
                clsRequtilisateurdroitparametreDTOs.Add(clsRequtilisateurdroitparametreDTO);
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);

            }
            finally
            {
                _clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
            }
            return clsRequtilisateurdroitparametreDTOs;

        }



    }
}
