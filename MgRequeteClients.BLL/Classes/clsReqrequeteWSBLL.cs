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
	public class clsReqrequeteWSBLL: IObjetWSBLL<clsReqrequete>
	{
		private clsReqrequeteWSDAL clsReqrequeteWSDAL= new clsReqrequeteWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsReqrequete comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsReqrequete pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqrequete">clsReqrequete</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsReqrequete clsReqrequete , clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqrequete.RQ_CODEREQUETE = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsReqrequeteWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsReqrequeteWSDAL.pvgInsert(clsDonnee, clsReqrequete);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqrequete.RQ_CODEREQUETE.ToString(), "A"));
			return "";
		}

        //public string pvgNomDeLaStructure(clsDonnee clsDonnee, clsReqrequete clsReqrequete, clsObjetEnvoi clsObjetEnvoi)
        //{
        //    clsReqrequeteWSDAL.pvgNomDeLaStructure(clsDonnee, clsReqrequete);
        //    return "";
        //}

        public DataSet pvgNomDeLaStructure(clsDonnee clsDonnee, clsReqrequete clsReqrequete, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteWSDAL.pvgNomDeLaStructure(clsDonnee, clsReqrequete);
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsReqrequete">clsReqrequete</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMiseajour(clsDonnee clsDonnee, clsReqrequete clsReqrequete , clsObjetEnvoi clsObjetEnvoi)
		{
            if (clsReqrequete.TYPEOPERATION == "0" || clsReqrequete.TYPEOPERATION == "5" || clsReqrequete.TYPEOPERATION == "8")
                clsReqrequete.RQ_CODEREQUETE = (  double.Parse(clsReqrequeteWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
			clsReqrequeteWSDAL.pvgInsert(clsDonnee, clsReqrequete);
			//clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqrequete.RQ_CODEREQUETE.ToString(), "A"));
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsReqrequete">clsReqrequete</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMiseajour2(clsDonnee clsDonnee, clsReqrequete clsReqrequete, clsObjetEnvoi clsObjetEnvoi)
        {
            clsReqrequeteWSDAL.pvgInsertDoc(clsDonnee, clsReqrequete);
            return "";
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsReqrequetes"> Liste d'objet clsReqrequete</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsReqrequete> clsReqrequetes , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsReqrequeteWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsReqrequetes.Count; Idx++)
			{
				clsReqrequetes[Idx].RQ_CODEREQUETE = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsReqrequeteWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsReqrequeteWSDAL.pvgInsert(clsDonnee, clsReqrequetes[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqrequetes[Idx].RQ_CODEREQUETE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsReqrequete">clsReqrequete</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsReqrequete clsReqrequete,clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqrequeteWSDAL.pvgUpdate(clsDonnee, clsReqrequete, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqrequete.RQ_CODEREQUETE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsReqrequeteWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsReqrequete </returns>
		///<author>Home Technology</author>
		public List<clsReqrequete> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsReqrequete </returns>
		///<author>Home Technology</author>
		public List<clsReqrequete> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetBCAO(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteWSDAL.pvgChargerDansDataSetBCAO(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetParOperateurs(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteWSDAL.pvgChargerDansDataSetParOperateurs(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetParOperateursNotif(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteWSDAL.pvgChargerDansDataSetParOperateursClotureReq(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetRelance(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteWSDAL.pvgChargerDansDataSetRelance(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsReqrequeteWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetTableauDeBord(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteWSDAL.pvgChargerDansDataSetTableauDeBord(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetFrequenceReclamation(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteWSDAL.pvgChargerDansDataSetFrequenceReclamation(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetDASHBOARD(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteWSDAL.pvgChargerDansDataSetDASHBOARD(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetTableauDeBordstatistique(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteWSDAL.pvgChargerDansDataSetTableauDeBordstatistique(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsReqrequete">clsReqrequete</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMiseajourAvisclient(clsDonnee clsDonnee, clsReqrequete clsReqrequete, clsObjetEnvoi clsObjetEnvoi)
        {
            clsReqrequeteWSDAL.pvgInsertAvisclient(clsDonnee, clsReqrequete);
            //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsReqrequete.RQ_CODEREQUETE.ToString(), "A"));
            return "";
        }

        public string pvgAjouterdroit(clsDonnee clsDonnee, List<MgRequeteClients.BOJ.BusinessObjects.clsRequtilisateurdroitparametre> clsRequtilisateurdroitparametreAjout, clsObjetEnvoi clsObjetEnvoi)
        {

            
            for (int Idx = 0; Idx < clsRequtilisateurdroitparametreAjout.Count; Idx++)
            {
                if (clsRequtilisateurdroitparametreAjout[Idx].DP_CODEDROITCOMPTEUTULISATEUR == "12" && clsRequtilisateurdroitparametreAjout[Idx].DP_STATUT == "O")
                {
                    clsReqrequeteWSDAL.pvgTestsuroperateurDroit(clsDonnee, clsRequtilisateurdroitparametreAjout[0].CU_CODECOMPTEUTULISATEUR);
                }
            }

            if (clsRequtilisateurdroitparametreAjout.Count > 0)
                clsReqrequeteWSDAL.pvgDeleteDroit(clsDonnee, clsRequtilisateurdroitparametreAjout[0].CU_CODECOMPTEUTULISATEUR);

            for (int Idx = 0; Idx < clsRequtilisateurdroitparametreAjout.Count; Idx++)
            {
                if (clsRequtilisateurdroitparametreAjout[Idx].DP_CODEDROITCOMPTEUTULISATEUR != "0" && clsRequtilisateurdroitparametreAjout[Idx].DP_STATUT == "O")
                {
                    clsReqrequeteWSDAL.pvgInsertDroitOperateur(clsDonnee, clsRequtilisateurdroitparametreAjout[Idx]);
                }
            }
            return "";
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : RQ_CODEREQUETE, TR_CODETYEREQUETE, CU_CODECOMPTEUTULISATEUR, MC_CODEMODECOLLETE, CU_CODECOMPTEUTULISATEURAGENTENCHARGE, RQ_CODEREQUETERELANCEE, RS_CODESTATUTRECEVABILITE, NS_CODENIVEAUSATISFACTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDroitParOperateurs(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsReqrequeteWSDAL.pvgChargerDansDataSetDroitParOperateurs(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "REQREQUETE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "REQREQUETE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "REQREQUETE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "REQREQUETE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
