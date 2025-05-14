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
	public class clsReqrequeteetapeWSBLL: IObjetWSBLL<clsReqrequeteetape>
	{
		private clsReqrequeteetapeWSDAL clsReqrequeteetapeWSDAL= new clsReqrequeteetapeWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteetapeWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteetapeWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteetapeWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqrequeteetape comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqrequeteetape pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteetapeWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqrequeteetape">clsReqrequeteetape</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsReqrequeteetape clsReqrequeteetape , clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqrequeteetape.AT_INDEXETAPE = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsReqrequeteetapeWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsReqrequeteetapeWSDAL.pvgInsert(clsDonnee, clsReqrequeteetape);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqrequeteetape.AT_INDEXETAPE.ToString(), "A"));
			return "";
		}
		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqrequeteetape">clsReqrequeteetape</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgMiseajour(clsDonnee clsDonnee, clsReqrequeteetape clsReqrequeteetape , clsObjetEnvoi clsObjetEnvoi)
		{
            if (clsReqrequeteetape.TYPEOPERATION == "0")
                clsReqrequeteetape.AT_INDEXETAPE = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsReqrequeteetapeWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsReqrequeteetapeWSDAL.pvgInsert(clsDonnee, clsReqrequeteetape);
			//clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqrequeteetape.AT_INDEXETAPE.ToString(), "A"));
			return "";
		}



		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqrequeteetapes"> Liste d'objet clsReqrequeteetape</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsReqrequeteetape> clsReqrequeteetapes , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsReqrequeteetapeWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsReqrequeteetapes.Count; Idx++)
			{
				clsReqrequeteetapes[Idx].AT_INDEXETAPE = (double.Parse(clsReqrequeteetapeWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
				clsReqrequeteetapeWSDAL.pvgInsert(clsDonnee, clsReqrequeteetapes[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqrequeteetapes[Idx].AT_INDEXETAPE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqrequeteetape">clsReqrequeteetape</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsReqrequeteetape clsReqrequeteetape,clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqrequeteetapeWSDAL.pvgUpdate(clsDonnee, clsReqrequeteetape, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqrequeteetape.AT_INDEXETAPE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqrequeteetapeWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsReqrequeteetape </returns>
		///<author>Home Technology</author>
		public List<clsReqrequeteetape> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteetapeWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqrequeteetape </returns>
		///<author>Home Technology</author>
		public List<clsReqrequeteetape> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteetapeWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteetapeWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgListeReqrequeteEtapeparRequete(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteetapeWSDAL.pvgListeReqrequeteEtapeparRequete(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgListeReqrequeteDoc(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteetapeWSDAL.pvgListeReqrequeteDoc(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgListeReqrequeteContentieuxDoc(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteetapeWSDAL.pvgListeReqrequeteContentieuxDoc(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgInfosDuClient(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            
            //if (clsObjetEnvoi.OE_PARAM.Length > 1)
            if (clsObjetEnvoi.OE_PARAM[1] != "")
            {
                return clsReqrequeteetapeWSDAL.pvgInfosDuClientNew(clsDonnee, clsObjetEnvoi.OE_PARAM);
            }
            else
            {
                return clsReqrequeteetapeWSDAL.pvgInfosDuClient(clsDonnee, clsObjetEnvoi.OE_PARAM);
            }
            
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetTraitement(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteetapeWSDAL.pvgChargerDansDataSetTraitement(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetTraitementDoc(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteetapeWSDAL.pvgChargerDansDataSetTraitementDoc(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        //public DataSet pvgChargerDansDataSetTraitementDoc(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        //{
        //    return clsReqrequeteetapeWSDAL.pvgChargerDansDataSetTraitementDoc(clsDonnee, clsObjetEnvoi.OE_PARAM);
        //}

        public DataSet pvgChargerDansDataSetHistorique(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteetapeWSDAL.pvgChargerDansDataSetHistorique(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AT_INDEXETAPE, AG_CODEAGENCE, RQ_CODEREQUETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RE_CODEETAPE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteetapeWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "REQREQUETEETAPE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "REQREQUETEETAPE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "REQREQUETEETAPE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "REQREQUETEETAPE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
