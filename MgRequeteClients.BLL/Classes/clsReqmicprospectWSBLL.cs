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
	public class clsReqmicprospectWSBLL: IObjetWSBLL<clsReqmicprospect>
	{
		private clsReqmicprospectWSDAL clsReqmicprospectWSDAL= new clsReqmicprospectWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqmicprospectWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqmicprospectWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqmicprospectWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqmicprospect comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqmicprospect pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqmicprospectWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqmicprospect">clsReqmicprospect</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsReqmicprospect clsReqmicprospect , clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqmicprospect.PR_IDPROSPECT = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsReqmicprospectWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsReqmicprospectWSDAL.pvgInsert(clsDonnee, clsReqmicprospect);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqmicprospect.PR_IDPROSPECT.ToString(), "A"));
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsReqmicprospect">clsReqmicprospect</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMiseajour(clsDonnee clsDonnee, clsReqmicprospect clsReqmicprospect , clsObjetEnvoi clsObjetEnvoi)
        {
            if (clsReqmicprospect.TYPEOPERATION == "0")
                clsReqmicprospect.PR_IDPROSPECT = ( double.Parse(clsReqmicprospectWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
	        clsReqmicprospectWSDAL.pvgInsert(clsDonnee, clsReqmicprospect);
	        //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqmicprospect.PR_IDPROSPECT.ToString(), "A"));
	        return "";
        }


		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqmicprospects"> Liste d'objet clsReqmicprospect</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsReqmicprospect> clsReqmicprospects , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsReqmicprospectWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsReqmicprospects.Count; Idx++)
			{
				clsReqmicprospects[Idx].PR_IDPROSPECT = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsReqmicprospectWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsReqmicprospectWSDAL.pvgInsert(clsDonnee, clsReqmicprospects[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqmicprospects[Idx].PR_IDPROSPECT.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqmicprospect">clsReqmicprospect</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsReqmicprospect clsReqmicprospect,clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqmicprospectWSDAL.pvgUpdate(clsDonnee, clsReqmicprospect, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqmicprospect.PR_IDPROSPECT.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqmicprospectWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsReqmicprospect </returns>
		///<author>Home Technology</author>
		public List<clsReqmicprospect> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqmicprospectWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqmicprospect </returns>
		///<author>Home Technology</author>
		public List<clsReqmicprospect> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqmicprospectWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqmicprospectWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : PR_IDPROSPECT, AG_CODEAGENCE, PV_CODEPOINTVENTE, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqmicprospectWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "REQMICPROSPECT  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "REQMICPROSPECT  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "REQMICPROSPECT  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "REQMICPROSPECT  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
