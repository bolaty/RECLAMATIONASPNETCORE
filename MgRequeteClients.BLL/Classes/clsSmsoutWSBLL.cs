using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using MgRequeteClients.BLL.Interfaces;
using MgRequeteClients.BOJ.BusinessObjects;
using MgRequeteClients.DAL.Classes;
using MgRequeteClients.Tools.Classes;

namespace MgRequeteClients.BLL.Classes
{
	public class clsSmsoutWSBLL: IObjetWSBLL<clsSmsout>
	{
		private clsSmsoutWSDAL clsSmsoutWSDAL= new clsSmsoutWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsSmsout comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsSmsout pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsSmsout">clsSmsout</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsSmsout clsSmsout , clsObjetEnvoi clsObjetEnvoi)
		{
			clsSmsout.AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsSmsoutWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsSmsoutWSDAL.pvgInsert(clsDonnee, clsSmsout);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsSmsout.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsSmsouts"> Liste d'objet clsSmsout</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsSmsout> clsSmsouts , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsSmsoutWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsSmsouts.Count; Idx++)
			{
				clsSmsouts[Idx].AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsSmsoutWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsSmsoutWSDAL.pvgInsert(clsDonnee, clsSmsouts[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsSmsouts[Idx].AG_CODEAGENCE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsSmsout">clsSmsout</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsSmsout clsSmsout,clsObjetEnvoi clsObjetEnvoi)
		{
			clsSmsoutWSDAL.pvgUpdate(clsDonnee, clsSmsout, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsSmsout.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}
        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsSmsout">clsSmsout</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMobileSmsUpdateStatut(clsDonnee clsDonnee, string AG_CODEAGENCE, DateTime SM_DATEPIECE, DateTime SM_DATEEMISSIONSMS, string SM_NUMSEQUENCE, string SM_STATUT, string SM_RAISONNONENVOISMS)
        {
            clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee,  AG_CODEAGENCE,  SM_DATEPIECE,SM_DATEEMISSIONSMS,  SM_NUMSEQUENCE,  SM_STATUT,  SM_RAISONNONENVOISMS);
	        return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsSmsout">clsSmsout</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMobileInscriptionAregulariser(clsDonnee clsDonnee, string TW_MATRICULEELEVE, string TW_NOMELEVE, string TW_PRENOMSELEVE, string TW_NIVEAUELEVE, string TW_CONTACTPARENT, string TW_CODEETABLISSEMENT, string TW_NOMETABLISSEMENT, string TW_CODESESSIONANNEE, string TW_OPERATIONTRANSACTION)
        {
            clsSmsoutWSDAL.pvgMobileInscriptionAregulariser(clsDonnee,  TW_MATRICULEELEVE,  TW_NOMELEVE,  TW_PRENOMSELEVE,  TW_NIVEAUELEVE,  TW_CONTACTPARENT,  TW_CODEETABLISSEMENT,  TW_NOMETABLISSEMENT,  TW_CODESESSIONANNEE,  TW_OPERATIONTRANSACTION);
	        return "";
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEMgRequeteClients, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public List<clsSmsoperateurdetlephoniecompteclient> pvgListeCompteSms(clsDonnee clsDonnee, string AG_CODEAGENCE)
        {
            return clsSmsoutWSDAL.pvgListeCompteSms(clsDonnee, AG_CODEAGENCE);
        }


		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsSmsoutWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsSmsout </returns>
		///<author>Home Technology</author>
		public List<clsSmsout> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsSmsout </returns>
		///<author>Home Technology</author>
		public List<clsSmsout> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetAPI(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsSmsoutWSDAL.pvgChargerDansDataSetAPI(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetAPI2(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsSmsoutWSDAL.pvgChargerDansDataSetAPI2(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet PvgUpdateStatutInscription(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsSmsoutWSDAL.PvgUpdateStatutInscription(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetListeSMS(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsSmsoutWSDAL.pvgChargerDansDataSetListeSMS(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetListeOperations(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsSmsoutWSDAL.pvgChargerDansDataSetListeOperations(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgAnnulationTransfert(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
             clsSmsoutWSDAL.pvgAnnulationTransfert(clsDonnee, clsObjetEnvoi.OE_PARAM);
             return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsSmsout">clsSmsout</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public clsParams pvgTraitementSms(clsDonnee clsDonnee, string AG_CODEAGENCE, string PV_CODEPOINTVENTE, string CO_CODECOMPTE, string OB_NOMOBJET, string    SM_TELEPHONE, string OP_CODEOPERATEUR, DateTime SM_DATEPIECE, string MB_IDTIERS, string CL_IDCLIENT, string EJ_IDEPARGNANTJOURNALIER, string SMSTEXT, string    TE_CODESMSTYPEOPERATION, string SM_NUMSEQUENCE, string SM_DATEEMISSIONSMS, string MC_NUMPIECE, string MC_NUMSEQUENCE, string SM_STATUT, string TYPEOPERATION, string   SL_LIBELLE1, string SL_LIBELLE2)
        {


            ////Processus d'envoi du sms
            clsParams clsParams = new clsParams();//BOJ model de retour
            List<clsParams> clsParamss = new List<clsParams>();//liste BOJ selon model retourne
            List<clsParams> Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
            clsSmsoutWSDAL clsSmsoutWSDAL = new clsSmsoutWSDAL();
            clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();


            Objet = clsSmsoutWSBLL.pvpPreparationSms(clsDonnee,  AG_CODEAGENCE, PV_CODEPOINTVENTE, CO_CODECOMPTE, OB_NOMOBJET, SM_TELEPHONE, OP_CODEOPERATEUR, SM_DATEPIECE, MB_IDTIERS,    CL_IDCLIENT, EJ_IDEPARGNANTJOURNALIER, SMSTEXT, TE_CODESMSTYPEOPERATION, SM_NUMSEQUENCE, SM_DATEEMISSIONSMS, MC_NUMPIECE, null, SM_STATUT, TYPEOPERATION, SL_LIBELLE1,    SL_LIBELLE2);

            try
            {

                if (!clsAppelServiceWebNew.IsValidateIP(MgRequeteClients.Tools.Classes.clsDeclaration.URL_ROOT_ADRESSE_API_SMS))
                {
                    clsParams = new clsParams();
                    clsParams.SL_CODEMESSAGE = "99";
                    clsParams.SL_MESSAGE = "L'API sms non déployé !!!";
                    clsParams.SL_RESULTAT = "FALSE";
                    Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
                    Objet.Add(clsParams);
                }
                else
                {
                    //--Preparation d'appel de l'apisms et mise a jour de sms
                    //--appel de l'api sms
                    if (Objet[0].SL_RESULTAT != "TRUE") return Objet[0];
                    clsParamss = clsAppelServiceWebNew.excecuteServiceWeb(clsParams, Objet, "post", MgRequeteClients.Tools.Classes.clsDeclaration.URL_ADRESSE_API_SMS).ToList();
                    if (clsParamss.Count > 0)
                    {
                        //--mise a jour du statut de sms 
                        if (clsParamss[0].SL_RESULTAT == "TRUE")
                            clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "E", "OK");
                        if (clsParamss[0].SL_RESULTAT == "FALSE")
                        {
                            clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", clsParamss[0].SL_MESSAGE);
                            clsParamss[0].SL_RESULTAT = "FALSE";
                            clsParamss[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                            Objet[0].SL_RESULTAT = clsParamss[0].SL_RESULTAT;
                            Objet[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                        }
                    }
                    else
                    {
                        clsParams = new clsParams();
                        clsParams.SL_CODEMESSAGE = "99";
                        clsParams.SL_MESSAGE = "L'API sms n'a pas répondu, revoir les paramètres de configurations de l'API sms !!!";
                        clsParams.SL_RESULTAT = "FALSE";
                        Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
                        Objet.Add(clsParams);
                    }
                   
                }


                
            }
            catch (System.Net.WebException e)
            {
                clsParamss[0].SL_RESULTAT = "FALSE";
                clsParamss[0].SL_MESSAGE = e.Message.ToString();
                clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", e.Message.ToString());
            }
            catch (Exception ex)
            {
                 clsParams = new clsParams();
                clsParams.SL_RESULTAT= "FALSE";
                clsParams.SL_MESSAGE = ex.Message.ToString();
                clsParamss.Add(clsParams);
                clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", ex.Message.ToString());
            }
            return Objet[0];
        }




        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsSmsout">clsSmsout</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public clsParams pvgTraitementSmsSimple(clsDonnee clsDonnee,string AG_CODEAGENCE, string SM_TELEPHONE, string SMSTEXT, DateTime SM_DATEPIECE,  string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2)
        {


            ////Processus d'envoi du sms
            clsParams clsParams = new clsParams();//BOJ model de retour
            List<clsParams> clsParamss = new List<clsParams>();//liste BOJ selon model retourne
            List<clsParams> Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
            clsSmsoutWSDAL clsSmsoutWSDAL = new clsSmsoutWSDAL();
            clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
            //string CL_TELEPHONE,  string SMSTEXT,   string SM_DATEEMISSIONSMS,string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2

            Objet = clsSmsoutWSBLL.pvpPreparationSmsSimple(clsDonnee, AG_CODEAGENCE, SM_TELEPHONE,  SMSTEXT,SM_DATEPIECE.ToShortDateString(), TYPEOPERATION, SL_LIBELLE1, SL_LIBELLE2);


            try
            {

                if (!clsAppelServiceWebNew.IsValidateIP(MgRequeteClients.Tools.Classes.clsDeclaration.URL_ROOT_ADRESSE_API_SMS))
                {
                    clsParams = new clsParams();
                    clsParams.SL_CODEMESSAGE = "99";
                    clsParams.SL_MESSAGE = "L'API sms non déployé !!!";
                    clsParams.SL_RESULTAT = "FALSE";
                    Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
                    Objet.Add(clsParams);
                }
                else
                {
                    //--Preparation d'appel de l'apisms et mise a jour de sms
                    //--appel de l'api sms
                    if (Objet[0].SL_RESULTAT != "TRUE") return Objet[0];
                    clsParamss = clsAppelServiceWebNew.excecuteServiceWeb(clsParams, Objet, "post", MgRequeteClients.Tools.Classes.clsDeclaration.URL_ADRESSE_API_SMS).ToList();
                    if (clsParamss.Count > 0)
                    {
                        //--mise a jour du statut de sms 
                        if (clsParamss[0].SL_RESULTAT == "TRUE")
                           // clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "E", "OK");
                        if (clsParamss[0].SL_RESULTAT == "FALSE")
                        {
                           // clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", clsParamss[0].SL_MESSAGE);
                            clsParamss[0].SL_RESULTAT = "FALSE";
                            clsParamss[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                            Objet[0].SL_RESULTAT = clsParamss[0].SL_RESULTAT;
                            Objet[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                        }
                    }
                    else
                    {
                        clsParams = new clsParams();
                        clsParams.SL_CODEMESSAGE = "99";
                        clsParams.SL_MESSAGE = "L'API sms n'a pas répondu, revoir les paramètres de configurations de l'API sms !!!";
                        clsParams.SL_RESULTAT = "FALSE";
                        Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
                        Objet.Add(clsParams);
                    }
                    //--mise a jour du statut de sms 
                    //if (clsParamss[0].SL_RESULTAT == "TRUE")
                    //    clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "E", "OK");
                    //if (clsParamss[0].SL_RESULTAT == "FALSE")
                    //{
                    //    clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", clsParamss[0].SL_MESSAGE);
                    //    clsParamss[0].SL_RESULTAT = "FALSE";
                    //    clsParamss[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                    //    Objet[0].SL_RESULTAT = clsParamss[0].SL_RESULTAT;
                    //    Objet[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                    //}

                }



            }
            catch (System.Net.WebException e)
            {
                //clsParamss[0].SL_RESULTAT = "FALSE";
                //clsParamss[0].SL_MESSAGE = e.Message.ToString();
                //clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", e.Message.ToString());
            }
            catch (Exception ex)
            {
                //clsParams = new clsParams();
                //clsParams.SL_RESULTAT = "FALSE";
                //clsParams.SL_MESSAGE = ex.Message.ToString();
                //clsParamss.Add(clsParams);
                //clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", ex.Message.ToString());
            }
            return Objet[0];
        }



        ///<summary>Cette fonction permet de definir les criteres d'une requete avec ou sans criteres (Ordre Criteres :AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE,TE_CODESMSTYPEOPERATION, CO_CODECOMPTE)</summary>
		///<param name="clsDonnee"> clsDonnee</param>
		///<param name="vppCritere">Les criteres de la requete</param>
		///<author>Home Technologie</author>
		public List<clsParams> pvpPreparationSms(clsDonnee clsDonnee, string AG_CODEAGENCE, string PV_CODEPOINTVENTE, string CO_CODECOMPTE, string OB_NOMOBJET, string CL_TELEPHONE,string OP_CODEOPERATEUR, DateTime CL_DATECREATION, string MB_IDTIERS, string CL_IDCLIENT, string EJ_IDEPARGNANTJOURNALIER, string SMSTEXT, string TE_CODESMSTYPEOPERATION, string SM_NUMSEQUENCE, string SM_DATEEMISSIONSMS, string MC_NUMPIECE, string MC_NUMSEQUENCE, string SM_STATUT, string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2)
        {
            //Processus d'envoi du sms
            //clsParams clsParams = new clsParams();//BOJ model de retour
            List<clsParams> clsParamss = new List<clsParams>();//liste BOJ selon model retourne
            clsParams clsParams = new clsParams();//liste BOJ selon model retourne
            //List<clsParams> Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
            List<clsSmsout> clsSmsouts = new List<clsSmsout>();

            clsParams.CodeAgence = AG_CODEAGENCE;
            clsParams.LibelleMouchard = "";
            clsParams.LibelleEcran = "";
            clsParams.LG_CODELANGUE = "FR";
            clsParams.SL_LIBELLE1 = SL_LIBELLE1;
            clsParams.SL_LIBELLE2 = SL_LIBELLE2;
            clsParams.CO_CODECOMPTE = CO_CODECOMPTE;
            clsParams.LO_LOGICIEL = "1";
            clsParams.OB_NOMOBJET = OB_NOMOBJET;
            clsParams.SL_VALEURRETOURS = "";
            clsParams.INDICATIF = "";
            clsParams.RECIPIENTPHONE = CL_TELEPHONE;
            clsParams.PV_CODEPOINTVENTE = PV_CODEPOINTVENTE;
            clsParams.CodeOperateur = OP_CODEOPERATEUR;
            clsParams.SM_DATEPIECE = CL_DATECREATION.ToShortDateString().Replace("/", "-");
            clsParams.SM_RAISONNONENVOISMS = "";
            clsParams.TYPEOPERATION = TYPEOPERATION;
            clsParams.SMSTEXT = SMSTEXT;
            clsParams.MB_IDTIERS = MB_IDTIERS;
            clsParams.EJ_IDEPARGNANTJOURNALIER = EJ_IDEPARGNANTJOURNALIER;
            clsParams.CL_IDCLIENT = CL_IDCLIENT;
            clsParams.TE_CODESMSTYPEOPERATION = TE_CODESMSTYPEOPERATION;
            clsParams.SM_NUMSEQUENCE = SM_NUMSEQUENCE;
            clsParams.SM_DATEEMISSIONSMS = DateTime.Parse(SM_DATEEMISSIONSMS);
            clsParams.MC_NUMPIECE = MC_NUMPIECE;
            clsParams.MC_NUMSEQUENCE = MC_NUMSEQUENCE;
            clsParams.SM_STATUT = SM_STATUT;


            clsSmsouts = clsSmsoutWSDAL.pvgMobileSms(clsDonnee, clsParams);

            clsParams.SM_NUMSEQUENCE = clsSmsouts[0].SM_NUMSEQUENCE;
            clsParams.SMSTEXT = clsSmsouts[0].SM_MESSAGE;
            clsParams.RECIPIENTPHONE = clsSmsouts[0].SM_TELEPHONE;
            clsParams.SL_CODEMESSAGE = clsSmsouts[0].SL_CODEMESSAGE;
            clsParams.SL_MESSAGE = clsSmsouts[0].SL_MESSAGE;
            clsParams.SL_RESULTAT = clsSmsouts[0].SL_RESULTAT;



            clsParamss.Add(clsParams);

            return clsParamss;
        }


        ///<summary>Cette fonction permet de definir les criteres d'une requete avec ou sans criteres (Ordre Criteres :AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE,TE_CODESMSTYPEOPERATION, CO_CODECOMPTE)</summary>
		///<param name="clsDonnee"> clsDonnee</param>
		///<param name="vppCritere">Les criteres de la requete</param>
		///<author>Home Technologie</author>
		public List<clsParams> pvpPreparationSmsSimple(clsDonnee clsDonnee, string AG_CODEAGENCE, string CL_TELEPHONE,  string SMSTEXT,   string SM_DATEEMISSIONSMS,string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2)
        {
            //Processus d'envoi du sms
            //clsParams clsParams = new clsParams();//BOJ model de retour
            List<clsParams> clsParamss = new List<clsParams>();//liste BOJ selon model retourne
            clsParams clsParams = new clsParams();//liste BOJ selon model retourne
            //List<clsParams> Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
            List<clsSmsout> clsSmsouts = new List<clsSmsout>();

            clsParams.CodeAgence = AG_CODEAGENCE;
            clsParams.LibelleMouchard = "";
            clsParams.LibelleEcran = "";
            clsParams.LG_CODELANGUE = "FR";
            clsParams.SL_LIBELLE1 = SL_LIBELLE1;
            clsParams.SL_LIBELLE2 = SL_LIBELLE2;
            clsParams.CO_CODECOMPTE = "";
            clsParams.LO_LOGICIEL = "1";
            clsParams.OB_NOMOBJET = "";
            clsParams.SL_VALEURRETOURS = "";
            clsParams.INDICATIF = "";
            clsParams.RECIPIENTPHONE = CL_TELEPHONE;
            clsParams.PV_CODEPOINTVENTE = "";
            clsParams.CodeOperateur = "";
            clsParams.SM_DATEPIECE = SM_DATEEMISSIONSMS.Replace("/", "-");
            clsParams.SM_RAISONNONENVOISMS = "";
            clsParams.TYPEOPERATION = TYPEOPERATION;
            clsParams.SMSTEXT = SMSTEXT;
            clsParams.MB_IDTIERS = "";
            clsParams.EJ_IDEPARGNANTJOURNALIER = "";
            clsParams.CL_IDCLIENT = "";
            clsParams.TE_CODESMSTYPEOPERATION = "";
            clsParams.SM_NUMSEQUENCE = "";
            clsParams.SM_DATEEMISSIONSMS = DateTime.Parse(SM_DATEEMISSIONSMS);
            clsParams.MC_NUMPIECE = "";
            clsParams.MC_NUMSEQUENCE = "";
            clsParams.SM_STATUT = "";


            //clsSmsouts = clsSmsoutWSDAL.pvgMobileSms(clsDonnee, clsParams);

            //clsParams.SM_NUMSEQUENCE = clsSmsouts[0].SM_NUMSEQUENCE;
            //clsParams.SMSTEXT = clsSmsouts[0].SM_MESSAGE;
            //clsParams.RECIPIENTPHONE = clsSmsouts[0].SM_TELEPHONE;
            clsParams.SL_CODEMESSAGE = "99";
            clsParams.SL_MESSAGE = "ok";
            clsParams.SL_RESULTAT ="TRUE";



            clsParamss.Add(clsParams);

            return clsParamss;
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsSmsout">clsSmsout</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public clsParams pvgTraitementSmsSimple1(clsDonnee clsDonnee, string AG_CODEAGENCE, string SM_TELEPHONE, string SMSTEXT, DateTime SM_DATEPIECE, string TYPEOPERATION, string TE_CODESMSTYPEOPERATION, string CU_CODECOMPTEUTULISATEUR, string SL_LIBELLE1, string SL_LIBELLE2)
        {


            ////Processus d'envoi du sms
            clsParams clsParams = new clsParams();//BOJ model de retour
            List<clsParams> clsParamss = new List<clsParams>();//liste BOJ selon model retourne
            List<clsParams> Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
            clsSmsoutWSDAL clsSmsoutWSDAL = new clsSmsoutWSDAL();
            clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
            //string CL_TELEPHONE,  string SMSTEXT,   string SM_DATEEMISSIONSMS,string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2

            Objet = clsSmsoutWSBLL.pvpPreparationSmsSimple1(clsDonnee, AG_CODEAGENCE, SM_TELEPHONE, SMSTEXT, SM_DATEPIECE.ToShortDateString(), TYPEOPERATION, TE_CODESMSTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, SL_LIBELLE1, SL_LIBELLE2);


            try
            {
                if (SL_LIBELLE1 != "5")
                {
                    if (!clsAppelServiceWebNew.IsValidateIP(MgRequeteClients.Tools.Classes.clsDeclaration.URL_ROOT_ADRESSE_API_SMS))
                    {
                        clsParams = new clsParams();
                        clsParams.SL_CODEMESSAGE = "99";
                        clsParams.SL_MESSAGE = "L'API sms non déployé !!!";
                        clsParams.SL_RESULTAT = "FALSE";
                        Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
                        Objet.Add(clsParams);
                    }
                    else
                    {
                        //--Preparation d'appel de l'apisms et mise a jour de sms
                        //--appel de l'api sms
                        if (Objet[0].SL_RESULTAT != "TRUE") return Objet[0];
                        SMSTEXT = Objet[0].SMSTEXT;
                        clsParamss = clsAppelServiceWebNew.excecuteServiceWeb(clsParams, Objet, "post", MgRequeteClients.Tools.Classes.clsDeclaration.URL_ADRESSE_API_SMS).ToList();
                        if (clsParamss.Count > 0)
                        {
                            clsParamss[0].SMSTEXT = SMSTEXT;


                            //--mise a jour du statut de sms 
                            if (clsParamss[0].SL_RESULTAT == "TRUE")
                                // clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "E", "OK");
                                if (clsParamss[0].SL_RESULTAT == "FALSE")
                                {
                                    // clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", clsParamss[0].SL_MESSAGE);
                                    clsParamss[0].SL_RESULTAT = "FALSE";
                                    clsParamss[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                                    Objet[0].SL_RESULTAT = clsParamss[0].SL_RESULTAT;
                                    Objet[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                                }
                        }
                        else
                        {
                            clsParams = new clsParams();
                            clsParams.SL_CODEMESSAGE = "99";
                            clsParams.SL_MESSAGE = "L'API sms n'a pas répondu, revoir les paramètres de configurations de l'API sms !!!";
                            clsParams.SL_RESULTAT = "FALSE";
                            Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
                            Objet.Add(clsParams);
                        }
                        //--mise a jour du statut de sms 
                        //if (clsParamss[0].SL_RESULTAT == "TRUE")
                        //    clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "E", "OK");
                        //if (clsParamss[0].SL_RESULTAT == "FALSE")
                        //{
                        //    clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", clsParamss[0].SL_MESSAGE);
                        //    clsParamss[0].SL_RESULTAT = "FALSE";
                        //    clsParamss[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                        //    Objet[0].SL_RESULTAT = clsParamss[0].SL_RESULTAT;
                        //    Objet[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                        //}

                    }
                }




            }
            catch (System.Net.WebException e)
            {
                //clsParamss[0].SL_RESULTAT = "FALSE";
                //clsParamss[0].SL_MESSAGE = e.Message.ToString();
                //clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", e.Message.ToString());
            }
            catch (Exception ex)
            {
                //clsParams = new clsParams();
                //clsParams.SL_RESULTAT = "FALSE";
                //clsParams.SL_MESSAGE = ex.Message.ToString();
                //clsParamss.Add(clsParams);
                //clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", ex.Message.ToString());
            }
            return Objet[0];
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsSmsout">clsSmsout</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public clsParams pvgTraitementSmsSimple2(clsDonnee clsDonnee, string AG_CODEAGENCE, string SM_TELEPHONE, string SMSTEXT, DateTime SM_DATEPIECE, string TYPEOPERATION, string TE_CODESMSTYPEOPERATION, string CU_CODECOMPTEUTULISATEUR, string SL_LIBELLE1, string SL_LIBELLE2)
        {
            ////Processus d'envoi du sms
            clsParams clsParams = new clsParams();//BOJ model de retour
            List<clsParams> clsParamss = new List<clsParams>();//liste BOJ selon model retourne
            List<clsParams> Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
            clsSmsoutWSDAL clsSmsoutWSDAL = new clsSmsoutWSDAL();
            clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
            //string CL_TELEPHONE,  string SMSTEXT,   string SM_DATEEMISSIONSMS,string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2

            Objet = clsSmsoutWSBLL.pvpPreparationSmsSimple1(clsDonnee, AG_CODEAGENCE, SM_TELEPHONE, SMSTEXT, SM_DATEPIECE.ToShortDateString(), TYPEOPERATION, TE_CODESMSTYPEOPERATION, CU_CODECOMPTEUTULISATEUR, SL_LIBELLE1, SL_LIBELLE2);
            
            try
            {
                if (!clsAppelServiceWebNew.IsValidateIP(MgRequeteClients.Tools.Classes.clsDeclaration.URL_ROOT_ADRESSE_API_SMS))
                {
                    clsParams = new clsParams();
                    clsParams.SL_CODEMESSAGE = "99";
                    clsParams.SL_MESSAGE = "L'API sms non déployé !!!";
                    clsParams.SL_RESULTAT = "FALSE";
                    Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
                    Objet.Add(clsParams);
                }
                else
                {
                    //--Preparation d'appel de l'apisms et mise a jour de sms
                    //--appel de l'api sms
                    if (Objet[0].SL_RESULTAT != "TRUE") return Objet[0];
                    SMSTEXT = Objet[0].SMSTEXT;
                    //clsParamss = clsAppelServiceWeb.excecuteServiceWeb(clsParams, Objet, "post", MgRequeteClients.WSTOOLS.clsDeclaration.URL_ADRESSE_API_SMS).ToList();
                    //if (clsParamss.Count > 0)
                    //{
                        clsParamss[0].SMSTEXT = SMSTEXT;
                        
                        //--mise a jour du statut de sms 
                        if (clsParamss[0].SL_RESULTAT == "TRUE")
                            // clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "E", "OK");
                            if (clsParamss[0].SL_RESULTAT == "FALSE")
                            {
                                // clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", clsParamss[0].SL_MESSAGE);
                                clsParamss[0].SL_RESULTAT = "FALSE";
                                clsParamss[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                                Objet[0].SL_RESULTAT = clsParamss[0].SL_RESULTAT;
                                Objet[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                            Objet[0].SMSTEXT = clsParamss[0].SMSTEXT;
                        }
                    //}
                    //else
                    //{
                    //    clsParams = new clsParams();
                    //    clsParams.SL_CODEMESSAGE = "99";
                    //    clsParams.SL_MESSAGE = "L'API sms n'a pas répondu, revoir les paramètres de configurations de l'API sms !!!";
                    //    clsParams.SL_RESULTAT = "FALSE";
                    //    Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
                    //    Objet.Add(clsParams);
                    //}
                }
            }
            catch (System.Net.WebException e)
            {
                //clsParamss[0].SL_RESULTAT = "FALSE";
                //clsParamss[0].SL_MESSAGE = e.Message.ToString();
                //clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", e.Message.ToString());
            }
            catch (Exception ex)
            {
                //clsParams = new clsParams();
                //clsParams.SL_RESULTAT = "FALSE";
                //clsParams.SL_MESSAGE = ex.Message.ToString();
                //clsParamss.Add(clsParams);
                //clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", ex.Message.ToString());
            }
            return Objet[0];
        }


        ///<summary>Cette fonction permet de definir les criteres d'une requete avec ou sans criteres (Ordre Criteres :AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE,TE_CODESMSTYPEOPERATION, CO_CODECOMPTE)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les criteres de la requete</param>
        ///<author>Home Technologie</author>
        public List<clsParams> pvpPreparationSmsSimple1(clsDonnee clsDonnee, string AG_CODEAGENCE, string CL_TELEPHONE, string SMSTEXT, string SM_DATEEMISSIONSMS, string TYPEOPERATION, string TE_CODESMSTYPEOPERATION, string CU_CODECOMPTEUTULISATEUR, string SL_LIBELLE1, string SL_LIBELLE2)
        {
            //Processus d'envoi du sms
            //clsParams clsParams = new clsParams();//BOJ model de retour
            List<clsParams> clsParamss = new List<clsParams>();//liste BOJ selon model retourne
            clsParams clsParams = new clsParams();//liste BOJ selon model retourne
            //List<clsParams> Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
            List<clsReqsmsout> clsSmsouts = new List<clsReqsmsout>();

            //"CO_CODECOMPTE": "",
            //"CodeAgence": "1002",
            //"RECIPIENTPHONE": "2250759588384",
            //"SM_RAISONNONENVOISMS": "xxx",
            //"SM_DATEPIECE": "12-05-2022",
            //"LO_LOGICIEL": "01",
            //"OB_NOMOBJET": "test",
            //"SMSTEXT": "TEST",
            //"INDICATIF": "225",
            //"SM_NUMSEQUENCE": "1",
            //"SM_STATUT": "E"

            clsParams.CO_CODECOMPTE = "";
            clsParams.CodeAgence = AG_CODEAGENCE;
            clsParams.RECIPIENTPHONE = CL_TELEPHONE;
            clsParams.SM_RAISONNONENVOISMS = "";
            clsParams.SM_DATEPIECE = SM_DATEEMISSIONSMS.Replace("/", "-");
            clsParams.LO_LOGICIEL = "01";
            clsParams.OB_NOMOBJET = "";
            clsParams.SMSTEXT = SMSTEXT;
            clsParams.INDICATIF = "225";
            clsParams.SM_STATUT = "E"; // "";

            clsParams.TYPEOPERATION = TYPEOPERATION;
            clsParams.CU_CODECOMPTEUTULISATEUR = CU_CODECOMPTEUTULISATEUR;
            clsParams.TE_CODESMSTYPEOPERATION = TE_CODESMSTYPEOPERATION;
            clsParams.SM_DATEEMISSIONSMS = DateTime.Parse(SM_DATEEMISSIONSMS);
            clsParams.SM_NUMSEQUENCE = "";
            clsParams.SL_LIBELLE2 = SL_LIBELLE2;

            //clsParams.LibelleEcran = "";
            //clsParams.LG_CODELANGUE = "FR";
            //clsParams.SL_LIBELLE1 = SL_LIBELLE1;
            //clsParams.LibelleMouchard = "";
            //clsParams.PV_CODEPOINTVENTE = "";
            //clsParams.CodeOperateur = "";
            //clsParams.SL_VALEURRETOURS = "";
            //clsParams.CL_IDCLIENT = "";
            //clsParams.EJ_IDEPARGNANTJOURNALIER = "";
            //clsParams.MB_IDTIERS = "";
            //clsParams.MC_NUMPIECE = "";
            //clsParams.MC_NUMSEQUENCE = "";

            clsReqsmsoutWSDAL clsReqsmsoutWSDAL = new clsReqsmsoutWSDAL();
            clsSmsouts = clsReqsmsoutWSDAL.pvgMobileSms(clsDonnee, clsParams);

            clsParams.SM_NUMSEQUENCE = clsSmsouts[0].SM_NUMSEQUENCE;
            clsParams.SMSTEXT = clsSmsouts[0].SM_MESSAGE; //.Substring(0, 70);  // "TEST DU SMS"; //
            clsParams.RECIPIENTPHONE = clsSmsouts[0].SM_TELEPHONE;
            clsParams.SL_CODEMESSAGE = "99";
            clsParams.SL_MESSAGE = "ok";
            clsParams.SL_RESULTAT = "TRUE";



            clsParamss.Add(clsParams);

            return clsParamss;
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de generer le mouchard</summary>
		///<param name="vppAction">Action réalisé</param>
		///<param name="vppTypeAction">Type d'action</param>
		///<returns>clsMouchard</returns>
		///<author>Home Technologie</author>
		public clsMouchard pvpGenererMouchard(clsObjetEnvoi clsObjetEnvoi,string vppAction, string vppTypeAction)
		{
			clsMouchard clsMouchard = new clsMouchard();
			clsMouchard.AG_CODEAGENCE = clsObjetEnvoi.OE_A;
			clsMouchard.OP_CODEOPERATEUR = clsObjetEnvoi.OE_Y;
			switch (vppTypeAction)
			{
				case "A":
					clsMouchard.MO_ACTION = "SMSOUT  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "SMSOUT  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "SMSOUT  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "SMSOUT  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
