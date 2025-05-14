using MgRequeteClients.BOJ.BusinessObjects;

namespace MgRequeteClients.API.ServiceContract
{
    public interface IRequeteClientsClasse
    {
       
        
       
        MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur pvgMajUtilisateurs(List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> Objets);

        
        List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgListeUtilisateurs(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

        
        List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgListeUtilisateursRecherche(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgListeUtilisateursRechercheParAgence(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);



        List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgListeUtilisateursCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

       
        
        List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgLogin(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

       
       
        List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgUpdateFirstconnexion(string TU_CODETYPEUTILISATEUR, string CU_MOTDEPASSEOLD, string CU_LOGINOLD, string CU_MOTDEPASSENEW, string CU_LOGINNEW);

        
        MgRequeteClients.DTO.BusinessObjects.clsReqrequete pvgMajReqrequete(List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> Objets);
        
       
        
        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgListeReqrequeteRelance(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

       
       
        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgChargerDansDataSetParOperateurs(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgChargerDansDataSetParOperateursNotif(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail> pvgEnvoiEmail(List<MgRequeteClients.DTO.BusinessObjects.clsEnvoiEmail> Objets);
        
       
        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgListeReqrequete(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgListeReqrequeteCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsReqtyperequete> pvgReqtyperequeteCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);


        List<MgRequeteClients.DTO.BusinessObjects.clsReqmodecollecte> pvgReqmodecollecteCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsReqstatutrecevabilite> pvgReqstatutrecevabiliteCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);


        List<MgRequeteClients.DTO.BusinessObjects.clsReqactioncorrective> pvgReqactioncorrectiveCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

        List<MgRequeteClients.DTO.BusinessObjects.clsReqniveausatisfaction> pvgReqniveausatisfactionCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

        List<MgRequeteClients.DTO.BusinessObjects.clsAgence> pvgReqAgenceCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);
        
        MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape pvgMajReqrequeteEtape(List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> Objets);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> pvgListeReqrequeteEtape(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);


        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> pvgListeReqrequeteEtapeparRequete(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgListeReqrequeteDoc(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);


        List<MgRequeteClients.DTO.BusinessObjects.clsReqinfosduclient> pvgInfosDuClient(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);


        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> pvgListeReqrequeteEtapeConsultation(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);


        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgChargerDansDataSetListeHistorique(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);


        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape> pvgListeReqrequeteEtapeCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);


        MgRequeteClients.DTO.BusinessObjects.clsReqrequeteetape pvgpvgMajReqrequeteEtapeUPloadFile();

       
        MgRequeteClients.DTO.BusinessObjects.clsReqrequete pvgpvgMajReqrequeteUPloadFile();

       
        MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape pvgMajReqrequeteEtapeParam(List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape> Objets);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape> pvgListeReqrequeteEtapeParam(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequeteparetape> pvgListeReqrequeteEtapeParamCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);


        List<MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier> pvgForgotPassword(List<MgRequeteClients.DTO.BusinessObjects.clsReqmotdepasseoublier> Objets);

        List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgPasswordRequest(List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> Objets);


        List<MgRequeteClients.DTO.BusinessObjects.clsReqsmsout> pvgListeSMS(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsReqsmsout> pvgLectureNotification(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

        string pvgNomDeLaStructure(string PP_CODEPARAMETRE);

        MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord pvgTableauDeBord(string AG_CODEAGENCE, string RQ_DATEDEBUT, string RQ_DATEFIN, string CU_CODECOMPTEUTULISATEUR, string TYPEETAT);

        List<MgRequeteClients.DTO.BusinessObjects.clsEditionEtatReclamation> pvgListeReqrequeteBCAO(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);


        MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux pvgMajReqrequeteContentieux(List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux> Objets);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux> pvgListeReqrequeteContentieux(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

        List<MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux> pvgListeReqrequeteContentieuxCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);


        MgRequeteClients.DTO.BusinessObjects.clsRequetecontentieux pvgMajReqrequeteContentieuxUPloadFile();

        MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre pvgMajUtilisateurDroitParam(List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> Objets);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> pvgListeUtilisateurDroitParam(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> pvgListeUtilisateurDroitParamCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

       
        MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit pvgMajUtilisateurDroit(List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit> Objets);

        List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit> pvgListeUtilisateurDroit(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

        List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit> pvgListeUtilisateurDroitCombo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

        List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroit> pvgListeUtilisateurDroitInfo(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsZoneDTO> pvgInsertIntoDatasetZoneWeb();

        
        List<MgRequeteClients.DTO.BusinessObjects.clsAgenceDTO> pvgInsertIntoDatasetAgenceWeb(string EX_EXERCICE, string SO_CODESOCIETE, string OP_CODEOPERATEUR, string ZN_CODEZONE);


       
        List<MgRequeteClients.DTO.BusinessObjects.clsExerciceDTO> pvgInsertIntoDatasetExerciceWeb();


        List<MgRequeteClients.DTO.BusinessObjects.clsPeriodiciteDTO> pvgInsertIntoDatasetPeriodiciteWeb();


        List<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> pvgInsertIntoDatasetListeClient(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);


        List<MgRequeteClients.DTO.BusinessObjects.clsPeriodeDTO> pvgPeriodiciteWeb(string PE_CODEPERIODICITE);

        List<MgRequeteClients.DTO.BusinessObjects.clsPeriodeDateDebutDateFinDTO> pvgPeriodiciteDateDebutFin(string EX_EXERCICE, string MO_CODEMOIS, string PE_CODEPERIODICITE);


        List<MgRequeteClients.DTO.BusinessObjects.clsFrequenceReclamationDTO> pvgFrequenceReclamation(string AG_CODEAGENCE, string RQ_DATEDEBUT, string RQ_DATEFIN, string CU_CODECOMPTEUTULISATEUR, string TYPEETAT);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> pvgChargerDansDataSetDASHBOARD(List<MgRequeteClients.DTO.BusinessObjects.clsObjetEnvoiListe> Objets);

        MgRequeteClients.DTO.BusinessObjects.clsTableauDeBord pvgTableauDeBordstatistique(string AG_CODEAGENCE, string RQ_DATEDEBUT, string RQ_DATEFIN, string CU_CODECOMPTEUTULISATEUR, string TYPEETAT);

       
        MgRequeteClients.DTO.BusinessObjects.clsReqrequete pvgMajReqrequeteAvisclient(List<MgRequeteClients.DTO.BusinessObjects.clsReqrequete> Objets);


        
        string pvgAjouterdroitOperateur(List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> Objet);

       
        List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> pvgDroitParOperateurs(List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> Objets);

        
        List<MgRequeteClients.DTO.BusinessObjects.clsRequtilisateurdroitparametre> pvgInsertIntoDatasetListeDroitUtilisateur();
    }
}
