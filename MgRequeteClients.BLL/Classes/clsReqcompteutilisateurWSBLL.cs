using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using MgRequeteClients.BLL.Interfaces;
using MgRequeteClients.BOJ.BusinessObjects;
using MgRequeteClients.DAL.Classes;
using MgRequeteClients.Tools.Classes;
using System.Numerics;

namespace MgRequeteClients.BLL.Classes
{
	public class clsReqcompteutilisateurWSBLL: IObjetWSBLL<clsReqcompteutilisateur>
	{
		private clsReqcompteutilisateurWSDAL clsReqcompteutilisateurWSDAL= new clsReqcompteutilisateurWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqcompteutilisateurWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqcompteutilisateurWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqcompteutilisateurWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqcompteutilisateur comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqcompteutilisateur pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqcompteutilisateurWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        public DataSet pvgInsertIntoDatasetListeClient(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqcompteutilisateurWSDAL.pvgInsertIntoDatasetListeClient(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsReqcompteutilisateur">clsReqcompteutilisateur</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouter(clsDonnee clsDonnee, clsReqcompteutilisateur clsReqcompteutilisateur , clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsReqcompteutilisateurWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsReqcompteutilisateurWSDAL.pvgInsert(clsDonnee, clsReqcompteutilisateur);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqcompteutilisateur">clsReqcompteutilisateur</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		//public string pvgMiseajour(clsDonnee clsDonnee, clsReqcompteutilisateur clsReqcompteutilisateur , clsObjetEnvoi clsObjetEnvoi)
		//{
  //          string vlpCU_CODECOMPTEUTULISATEUR = "";
  //          double maxValue = 0;
  //          if (clsReqcompteutilisateur.TYPEOPERATION == "0")
  //          {
  //              //clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR = (double.Parse(clsReqcompteutilisateurWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsReqcompteutilisateur.AG_CODEAGENCE)) + 1).ToString();
  //              clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateurWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsReqcompteutilisateur.AG_CODEAGENCE);
  //              BigInteger value = BigInteger.Parse(clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR);
  //              value += 1;
  //              clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR = value.ToString();
  //          }
              
  //          vlpCU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateurWSDAL.pvgMiseajour(clsDonnee, clsReqcompteutilisateur);
		//	//clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR.ToString(), "A"));
		//	return vlpCU_CODECOMPTEUTULISATEUR;
		//}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqcompteutilisateur">clsReqcompteutilisateur</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgMiseajour(clsDonnee clsDonnee, clsReqcompteutilisateur clsReqcompteutilisateur, clsObjetEnvoi clsObjetEnvoi)
        {
            string vlpCU_CODECOMPTEUTULISATEUR = "";
            double maxValue = 0;
            if (clsReqcompteutilisateur.TYPEOPERATION == "0")
            {
                //clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR = (double.Parse(clsReqcompteutilisateurWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsReqcompteutilisateur.AG_CODEAGENCE)) + 1).ToString();
                clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateurWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsReqcompteutilisateur.AG_CODEAGENCE);
                BigInteger value = BigInteger.Parse(clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR);
                value += 1;
                clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR = value.ToString();
            }

            vlpCU_CODECOMPTEUTULISATEUR = clsReqcompteutilisateurWSDAL.pvgMiseajour(clsDonnee, clsReqcompteutilisateur);
            //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR.ToString(), "A"));
            return vlpCU_CODECOMPTEUTULISATEUR;
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsReqcompteutilisateurs"> Liste d'objet clsReqcompteutilisateur</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsReqcompteutilisateur> clsReqcompteutilisateurs , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsReqcompteutilisateurWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsReqcompteutilisateurs.Count; Idx++)
			{
				clsReqcompteutilisateurs[Idx].CU_CODECOMPTEUTULISATEUR = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsReqcompteutilisateurWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsReqcompteutilisateurWSDAL.pvgInsert(clsDonnee, clsReqcompteutilisateurs[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqcompteutilisateurs[Idx].CU_CODECOMPTEUTULISATEUR.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqcompteutilisateur">clsReqcompteutilisateur</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsReqcompteutilisateur clsReqcompteutilisateur,clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqcompteutilisateurWSDAL.pvgUpdate(clsDonnee, clsReqcompteutilisateur, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqcompteutilisateur.CU_CODECOMPTEUTULISATEUR.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqcompteutilisateurWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsReqcompteutilisateur </returns>
		///<author>Home Technology</author>
		public List<clsReqcompteutilisateur> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqcompteutilisateurWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqcompteutilisateur </returns>
		///<author>Home Technology</author>
		public List<clsReqcompteutilisateur> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqcompteutilisateurWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqcompteutilisateurWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetRechercheUtilisateur(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqcompteutilisateurWSDAL.pvgChargerDansDataSetRechercheUtilisateur(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEWEB, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public DataSet pvgPasswordRequest(clsDonnee clsDonnee, string CL_CONTACT, string CU_LOGIN, string TYPEOPERATION)
        {
            return clsReqcompteutilisateurWSDAL.pvgPasswordRequest(clsDonnee,  CL_CONTACT, CU_LOGIN, TYPEOPERATION);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CU_CODECOMPTEUTULISATEUR, AG_CODEAGENCE, TU_CODETYPEUTILISATEUR, PI_CODEPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqcompteutilisateurWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTILISATEUR, AN_CODEANTENNE, AG_CODEAGENT, TU_CODETYPECOMPTEUTILISATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgLogin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqcompteutilisateurWSDAL.pvgLogin(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "REQCOMPTEUTILISATEUR  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "REQCOMPTEUTILISATEUR  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "REQCOMPTEUTILISATEUR  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "REQCOMPTEUTILISATEUR  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CU_CODECOMPTEUTILISATEUR, AN_CODEANTENNE, AG_CODEAGENT, TU_CODETYPECOMPTEUTILISATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgUpdateFirstconnexion(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqcompteutilisateurWSDAL.pvgUpdateFirstconnexion(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
    }
}
