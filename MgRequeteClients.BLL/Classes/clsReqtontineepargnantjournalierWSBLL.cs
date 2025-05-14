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
	public class clsReqtontineepargnantjournalierWSBLL: IObjetWSBLL<clsReqtontineepargnantjournalier>
	{
		private clsReqtontineepargnantjournalierWSDAL clsReqtontineepargnantjournalierWSDAL= new clsReqtontineepargnantjournalierWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqtontineepargnantjournalierWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqtontineepargnantjournalierWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqtontineepargnantjournalierWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqtontineepargnantjournalier comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqtontineepargnantjournalier pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqtontineepargnantjournalierWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqtontineepargnantjournalier">clsReqtontineepargnantjournalier</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsReqtontineepargnantjournalier clsReqtontineepargnantjournalier , clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqtontineepargnantjournalier.EJ_IDEPARGNANTJOURNALIER = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsReqtontineepargnantjournalierWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsReqtontineepargnantjournalierWSDAL.pvgInsert(clsDonnee, clsReqtontineepargnantjournalier);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqtontineepargnantjournalier.EJ_IDEPARGNANTJOURNALIER.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqtontineepargnantjournalier">clsReqtontineepargnantjournalier</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgMiseajour(clsDonnee clsDonnee, clsReqtontineepargnantjournalier clsReqtontineepargnantjournalier , clsObjetEnvoi clsObjetEnvoi)
		{
            if (clsReqtontineepargnantjournalier.TYPEOPERATION == "0")
                clsReqtontineepargnantjournalier.EJ_IDEPARGNANTJOURNALIER =( double.Parse(clsReqtontineepargnantjournalierWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
			clsReqtontineepargnantjournalierWSDAL.pvgInsert(clsDonnee, clsReqtontineepargnantjournalier);
			//clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqtontineepargnantjournalier.EJ_IDEPARGNANTJOURNALIER.ToString(), "A"));
			return "";
		}


		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqtontineepargnantjournaliers"> Liste d'objet clsReqtontineepargnantjournalier</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsReqtontineepargnantjournalier> clsReqtontineepargnantjournaliers , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsReqtontineepargnantjournalierWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsReqtontineepargnantjournaliers.Count; Idx++)
			{
				clsReqtontineepargnantjournaliers[Idx].EJ_IDEPARGNANTJOURNALIER = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsReqtontineepargnantjournalierWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsReqtontineepargnantjournalierWSDAL.pvgInsert(clsDonnee, clsReqtontineepargnantjournaliers[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqtontineepargnantjournaliers[Idx].EJ_IDEPARGNANTJOURNALIER.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqtontineepargnantjournalier">clsReqtontineepargnantjournalier</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsReqtontineepargnantjournalier clsReqtontineepargnantjournalier,clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqtontineepargnantjournalierWSDAL.pvgUpdate(clsDonnee, clsReqtontineepargnantjournalier, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqtontineepargnantjournalier.EJ_IDEPARGNANTJOURNALIER.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqtontineepargnantjournalierWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsReqtontineepargnantjournalier </returns>
		///<author>Home Technology</author>
		public List<clsReqtontineepargnantjournalier> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqtontineepargnantjournalierWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqtontineepargnantjournalier </returns>
		///<author>Home Technology</author>
		public List<clsReqtontineepargnantjournalier> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqtontineepargnantjournalierWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqtontineepargnantjournalierWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : EJ_IDEPARGNANTJOURNALIER, CU_CODECOMPTEUTULISATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqtontineepargnantjournalierWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "REQTONTINEEPARGNANTJOURNALIER  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "REQTONTINEEPARGNANTJOURNALIER  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "REQTONTINEEPARGNANTJOURNALIER  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "REQTONTINEEPARGNANTJOURNALIER  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
