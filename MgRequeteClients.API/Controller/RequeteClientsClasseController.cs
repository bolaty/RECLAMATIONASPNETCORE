using System.Security.Cryptography.Xml;
using MgRequeteClients.API.Service;
using MgRequeteClients.DTO.BusinessObjects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MgRequeteClients.API.Controller
{
    [Route("RequeteClientsClasse.svc/")]
    
    public class RequeteClientsClasseController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<RequeteClientsClasseController> _logger;
        private readonly IWebHostEnvironment _env;

        
        public RequeteClientsClasseController(IConfiguration configuration, ILogger<RequeteClientsClasseController> logger, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _logger = logger;
            _env = env;
        }

        public class ObjetsWrapper<T>
        {
            public List<T> Objets { get; set; }
        }


        [HttpPost("pvgMajUtilisateurs")]
        public ActionResult<MgRequeteClients.DTO.BusinessObjects.clsReqcompteutilisateur> MajUtilisateurs([FromBody] UtilisateurWrapper input )
        {
            if (input?.Objets == null || input.Objets.Count == 0)
            {
                return BadRequest("La liste des utilisateurs est vide.");
            }

            try
            {
                _logger.LogInformation("Endpoint appelé");
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgMajUtilisateurs(input.Objets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite : {ex.Message}");
            }
        }

        

        [HttpPost("pvgListeUtilisateurs")]
        public ActionResult<List<clsReqcompteutilisateur>> ListeUtilisateurs([FromBody] ObjetsEnvoiListeWrapper data)
        {
            if (data == null || data.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeUtilisateurs(data.Objets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeUtilisateurs");
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }


        [HttpPost("pvgListeUtilisateursRecherche")]
        public ActionResult<List<clsReqcompteutilisateur>> ListeUtilisateursRecherche([FromBody] ObjetsEnvoiListeWrapper data)
        {
            if (data == null || data.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeUtilisateursRecherche(data.Objets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeUtilisateursRecherche");
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }

        [HttpPost("pvgListeUtilisateursRechercheParAgence")]
        public ActionResult<List<clsReqcompteutilisateur>> ListeUtilisateursRechercheParAgence([FromBody] ObjetsEnvoiListeWrapper data)
        {
            if (data == null || data.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeUtilisateursRechercheParAgence(data.Objets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeUtilisateursRechercheParAgence");
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }

        [HttpPost("pvgListeUtilisateursCombo")]
        public ActionResult<List<clsReqcompteutilisateur>> ListeUtilisateursCombo([FromBody] ObjetsEnvoiListeWrapper data)
        {
            if (data == null || data.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeUtilisateursCombo(data.Objets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeUtilisateursCombo");
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }

        [HttpPost("pvgLogin")]
        public ActionResult<List<clsReqcompteutilisateur>> Login([FromBody] ObjetsEnvoiListeWrapper data)
        {
            if (data == null || data.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgLogin(data.Objets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgLogin");
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }

        [HttpPost("pvgUpdateFirstconnexion")]
        public ActionResult<List<clsReqcompteutilisateur>> UpdateFirstConnexion(
        [FromQuery] string TU_CODETYPEUTILISATEUR,
        [FromQuery] string CU_MOTDEPASSEOLD,
        [FromQuery] string CU_LOGINOLD,
        [FromQuery] string CU_MOTDEPASSENEW,
        [FromQuery] string CU_LOGINNEW)
        {
            if (string.IsNullOrEmpty(CU_LOGINOLD) || string.IsNullOrEmpty(CU_MOTDEPASSEOLD))
                return BadRequest("Identifiants actuels manquants.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgUpdateFirstconnexion(
                    TU_CODETYPEUTILISATEUR,
                    CU_MOTDEPASSEOLD,
                    CU_LOGINOLD,
                    CU_MOTDEPASSENEW,
                    CU_LOGINNEW
                );
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgUpdateFirstconnexion");
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }

        [HttpPost("pvgMajReqrequete")]
        public ActionResult<clsReqrequete> pvgMajReqrequete([FromBody] ObjetsWrapper<clsReqrequete> data)
        {
            if (data == null || data.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgMajReqrequete(data.Objets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgMajReqrequete");
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }

        [HttpPost("pvgListeReqrequeteRelance")]
        public ActionResult<List<clsReqrequete>> pvgListeReqrequeteRelance([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeReqrequeteRelance(data.Objets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeReqrequeteRelance");
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }



        [HttpPost("pvgChargerDansDataSetParOperateurs")]
        public ActionResult<List<clsReqrequete>> pvgChargerDansDataSetParOperateurs([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgChargerDansDataSetParOperateurs(data.Objets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgChargerDansDataSetParOperateurs");
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }

        [HttpPost("pvgChargerDansDataSetParOperateursNotif")]
        public ActionResult<List<clsReqrequete>> pvgChargerDansDataSetParOperateursNotif([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgChargerDansDataSetParOperateursNotif(data.Objets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgChargerDansDataSetParOperateursNotif");
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }

        [HttpPost("pvgEnvoiEmail")]
        public ActionResult<List<clsEnvoiEmail>> pvgEnvoiEmail([FromBody] ObjetsWrapper<clsEnvoiEmail> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgEnvoiEmail(data.Objets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgEnvoiEmail");
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }

        [HttpPost("pvgListeReqrequete")]
        public ActionResult<List<clsReqrequete>> pvgListeReqrequete([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeReqrequete(data.Objets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeReqrequete");
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }


        [HttpPost("pvgMajReqrequeteEtape")]
        public ActionResult<clsReqrequeteetape> pvgMajReqrequeteEtape([FromBody] ObjetsWrapper<clsReqrequeteetape> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgMajReqrequeteEtape(data.Objets);
                return Ok(new { Objet = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgMajReqrequeteEtape");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeReqrequeteEtape")]
        public ActionResult<List<clsReqrequeteetape>> pvgListeReqrequeteEtape([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeReqrequeteEtape(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeReqrequeteEtape");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeReqrequeteEtapeparRequete")]
        public ActionResult<List<clsReqrequeteetape>> pvgListeReqrequeteEtapeparRequete([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeReqrequeteEtapeparRequete(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeReqrequeteEtapeparRequete");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeReqrequeteDoc")]
        public ActionResult<List<clsReqrequete>> pvgListeReqrequeteDoc([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeReqrequeteDoc(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeReqrequeteDoc");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgInfosDuClient")]
        public ActionResult<List<clsReqinfosduclient>> pvgInfosDuClient([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgInfosDuClient(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgInfosDuClient");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeReqrequeteEtapeConsultation")]
        public ActionResult<List<clsReqrequeteetape>> pvgListeReqrequeteEtapeConsultation([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeReqrequeteEtapeConsultation(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeReqrequeteEtapeConsultation");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgChargerDansDataSetListeHistorique")]
        public ActionResult<List<clsReqrequete>> pvgChargerDansDataSetListeHistorique([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgChargerDansDataSetListeHistorique(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgChargerDansDataSetListeHistorique");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeReqrequeteEtapeCombo")]
        public ActionResult<List<clsReqrequeteetape>> pvgListeReqrequeteEtapeCombo([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeReqrequeteEtapeCombo(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeReqrequeteEtapeCombo");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }


        //************************************************/


        [HttpPost("pvgMajReqrequeteEtapeParam")]
        public ActionResult<clsReqrequeteparetape> pvgMajReqrequeteEtapeParam([FromBody] ObjetsWrapper<clsReqrequeteparetape> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgMajReqrequeteEtapeParam(data.Objets);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgMajReqrequeteEtapeParam");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeReqrequeteEtapeParam")]
        public ActionResult<List<clsReqrequeteparetape>> pvgListeReqrequeteEtapeParam([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeReqrequeteEtapeParam(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeReqrequeteEtapeParam");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeReqrequeteEtapeParamCombo")]
        public ActionResult<List<clsReqrequeteparetape>> pvgListeReqrequeteEtapeParamCombo([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeReqrequeteEtapeParamCombo(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeReqrequeteEtapeParamCombo");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgForgotPassword")]
        public ActionResult<List<clsReqmotdepasseoublier>> pvgForgotPassword([FromBody] ObjetsWrapper<clsReqmotdepasseoublier> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgForgotPassword(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgForgotPassword");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgPasswordRequest")]
        public ActionResult<List<clsReqcompteutilisateur>> pvgPasswordRequest([FromBody] ObjetsWrapper<clsReqcompteutilisateur> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgPasswordRequest(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgPasswordRequest");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeSMS")]
        public ActionResult<List<clsReqsmsout>> pvgListeSMS([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeSMS(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeSMS");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgLectureNotification")]
        public ActionResult<List<clsReqsmsout>> pvgLectureNotification([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgLectureNotification(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgLectureNotification");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeReqrequeteBCAO")]
        public ActionResult<List<clsEditionEtatReclamation>> pvgListeReqrequeteBCAO([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeReqrequeteBCAO(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeReqrequeteBCAO");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgMajReqrequeteContentieux")]
        public ActionResult<List<clsRequetecontentieux>> pvgMajReqrequeteContentieux([FromBody] ObjetsWrapper<clsRequetecontentieux> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgMajReqrequeteContentieux(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgMajReqrequeteContentieux");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeReqrequeteContentieux")]
        public ActionResult<List<clsRequetecontentieux>> pvgListeReqrequeteContentieux([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeReqrequeteContentieux(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeReqrequeteContentieux");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeReqrequeteContentieuxCombo")]
        public ActionResult<List<clsRequetecontentieux>> pvgListeReqrequeteContentieuxCombo([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeReqrequeteContentieuxCombo(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeReqrequeteContentieuxCombo");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }


        //[HttpPost("pvgMajReqrequeteContentieuxUPloadFile")]
        //public ActionResult<clsRequetecontentieux> pvgMajReqrequeteContentieuxUPloadFile()
        //{
        //    try
        //    {
        //        var service = new RequeteClientsClasse(_configuration);
        //        var result = service.pvgMajReqrequeteContentieuxUPloadFile();
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Erreur dans pvgMajReqrequeteContentieuxUPloadFile");
        //        return StatusCode(500, new { Erreur = ex.Message });
        //    }
        //}

       // [HttpPost("pvgpvgMajReqrequeteEtapeUPloadFile")]
        //public ActionResult<clsReqrequeteetape> pvgpvgMajReqrequeteEtapeUPloadFile()
        //{
        //    try
        //    {
        //        var service = new RequeteClientsClasse(_configuration);
        //        var result = service.pvgpvgMajReqrequeteEtapeUPloadFile();
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Erreur dans pvgpvgMajReqrequeteEtapeUPloadFile");
        //        return StatusCode(500, new { Erreur = ex.Message });
        //    }
        //}

        //[HttpPost("pvgpvgMajReqrequeteUPloadFile")]
        //public ActionResult<clsReqrequete> pvgpvgMajReqrequeteUPloadFile()
        //{
        //    try
        //    {
        //        var service = new RequeteClientsClasse(_configuration);
        //        var result = service.pvgpvgMajReqrequeteUPloadFile();
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Erreur dans pvgpvgMajReqrequeteUPloadFile");
        //        return StatusCode(500, new { Erreur = ex.Message });
        //    }
        //}

        [HttpPost("pvgNomDeLaStructure")]
        public ActionResult<string> pvgNomDeLaStructure([FromQuery] string PP_CODEPARAMETRE)
        {
            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgNomDeLaStructure(PP_CODEPARAMETRE);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgNomDeLaStructure");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgTableauDeBord")]
        public ActionResult<clsTableauDeBord> pvgTableauDeBord([FromQuery] string AG_CODEAGENCE, [FromQuery] string RQ_DATEDEBUT, [FromQuery] string RQ_DATEFIN, [FromQuery] string CU_CODECOMPTEUTULISATEUR, [FromQuery] string TYPEETAT)
        {
            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgTableauDeBord(AG_CODEAGENCE, RQ_DATEDEBUT, RQ_DATEFIN, CU_CODECOMPTEUTULISATEUR, TYPEETAT);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgTableauDeBord");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgMajUtilisateurDroitParam")]
        public ActionResult<List<clsRequtilisateurdroitparametre>> pvgMajUtilisateurDroitParam([FromBody] ObjetsWrapper<clsRequtilisateurdroitparametre> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgMajUtilisateurDroitParam(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgMajUtilisateurDroitParam");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeUtilisateurDroitParam")]
        public ActionResult<List<clsRequtilisateurdroitparametre>> pvgListeUtilisateurDroitParam([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeUtilisateurDroitParam(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeUtilisateurDroitParam");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }


        [HttpPost("pvgListeUtilisateurDroitParamCombo")]
        public ActionResult<List<clsRequtilisateurdroitparametre>> pvgListeUtilisateurDroitParamCombo([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeUtilisateurDroitParamCombo(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeUtilisateurDroitParamCombo");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgMajUtilisateurDroit")]
        public ActionResult<List<clsRequtilisateurdroit>> pvgMajUtilisateurDroit([FromBody] ObjetsWrapper<clsRequtilisateurdroit> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgMajUtilisateurDroit(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgMajUtilisateurDroit");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }


        [HttpPost("pvgListeUtilisateurDroit")]
        public ActionResult<List<clsRequtilisateurdroit>> pvgListeUtilisateurDroit([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeUtilisateurDroit(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeUtilisateurDroit");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeUtilisateurDroitCombo")]
        public ActionResult<List<clsRequtilisateurdroit>> pvgListeUtilisateurDroitCombo([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeUtilisateurDroitCombo(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeUtilisateurDroitCombo");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgListeUtilisateurDroitInfo")]
        public ActionResult<List<clsRequtilisateurdroit>> pvgListeUtilisateurDroitInfo([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgListeUtilisateurDroitInfo(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgListeUtilisateurDroitInfo");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }


        [HttpPost("pvgInsertIntoDatasetZoneWeb")]
        public ActionResult<clsZoneDTO> pvgInsertIntoDatasetZoneWeb()
        {
            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgInsertIntoDatasetZoneWeb();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgInsertIntoDatasetZoneWeb");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgInsertIntoDatasetAgenceWeb")]
        public ActionResult<clsAgenceDTO> pvgInsertIntoDatasetAgenceWeb([FromQuery] string EX_EXERCICE, [FromQuery] string SO_CODESOCIETE, [FromQuery] string OP_CODEOPERATEUR, [FromQuery] string ZN_CODEZONE)
        {
            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgInsertIntoDatasetAgenceWeb(EX_EXERCICE, SO_CODESOCIETE, OP_CODEOPERATEUR, ZN_CODEZONE);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgInsertIntoDatasetAgenceWeb");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }


        [HttpPost("pvgInsertIntoDatasetExerciceWeb")]
        public ActionResult<clsExerciceDTO> pvgInsertIntoDatasetExerciceWeb()
        {
            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgInsertIntoDatasetExerciceWeb();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgInsertIntoDatasetExerciceWeb");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgInsertIntoDatasetPeriodiciteWeb")]
        public ActionResult<clsPeriodiciteDTO> pvgInsertIntoDatasetPeriodiciteWeb()
        {
            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgInsertIntoDatasetPeriodiciteWeb();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgInsertIntoDatasetPeriodiciteWeb");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

       

        [HttpPost("pvgInsertIntoDatasetListeClient")]
        public ActionResult<List<clsReqcompteutilisateur>> pvgInsertIntoDatasetListeClient([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgInsertIntoDatasetListeClient(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgInsertIntoDatasetListeClient");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }


        [HttpPost("pvgPeriodiciteWeb")]
        public ActionResult<clsPeriodeDTO> pvgPeriodiciteWeb([FromQuery] string EX_EXERCICE)
        {
            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgPeriodiciteWeb(EX_EXERCICE);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgPeriodiciteWeb");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgPeriodiciteDateDebutFin")]
        public ActionResult<clsPeriodeDateDebutDateFinDTO> pvgPeriodiciteDateDebutFin([FromQuery] string EX_EXERCICE, [FromQuery] string MO_CODEMOIS, [FromQuery] string PE_CODEPERIODICITE)
        {
            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgPeriodiciteDateDebutFin(EX_EXERCICE, MO_CODEMOIS, PE_CODEPERIODICITE);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgPeriodiciteDateDebutFin");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgFrequenceReclamation")]
        public ActionResult<clsFrequenceReclamationDTO> pvgFrequenceReclamation([FromQuery] string AG_CODEAGENCE, [FromQuery] string RQ_DATEDEBUT, [FromQuery] string RQ_DATEFIN, [FromQuery] string CU_CODECOMPTEUTULISATEUR, [FromQuery] string TYPEETAT)
        {
            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgFrequenceReclamation( AG_CODEAGENCE,RQ_DATEDEBUT,  RQ_DATEFIN,  CU_CODECOMPTEUTULISATEUR,  TYPEETAT);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgFrequenceReclamation");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgChargerDansDataSetDASHBOARD")]
        public ActionResult<List<clsReqrequete>> pvgChargerDansDataSetDASHBOARD([FromBody] ObjetsWrapper<clsObjetEnvoiListe> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgChargerDansDataSetDASHBOARD(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgChargerDansDataSetDASHBOARD");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgTableauDeBordstatistique")]
        public ActionResult<clsTableauDeBord> pvgTableauDeBordstatistique([FromQuery] string AG_CODEAGENCE, [FromQuery] string RQ_DATEDEBUT, [FromQuery] string RQ_DATEFIN, [FromQuery] string CU_CODECOMPTEUTULISATEUR, [FromQuery] string TYPEETAT)
        {
            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgTableauDeBordstatistique( AG_CODEAGENCE,  RQ_DATEDEBUT,  RQ_DATEFIN,  CU_CODECOMPTEUTULISATEUR,  TYPEETAT);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgTableauDeBordstatistique");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgMajReqrequeteAvisclient")]
        public ActionResult<List<clsReqrequete>> pvgMajReqrequeteAvisclient([FromBody] ObjetsWrapper<clsReqrequete> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgMajReqrequeteAvisclient(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgMajReqrequeteAvisclient");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgAjouterdroitOperateur")]
        public ActionResult<string> pvgAjouterdroitOperateur([FromBody] ObjetsWrapper<clsRequtilisateurdroitparametre> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgAjouterdroitOperateur(data.Objets);
                return Ok(result); // Le service retourne une string
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgAjouterdroitOperateur");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgDroitParOperateurs")]
        public ActionResult<List<clsRequtilisateurdroitparametre>> pvgDroitParOperateurs([FromBody] ObjetsWrapper<clsRequtilisateurdroitparametre> data)
        {
            if (data?.Objets == null || data.Objets.Count == 0)
                return BadRequest("Paramètre Objets manquant ou vide.");

            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgDroitParOperateurs(data.Objets);
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgDroitParOperateurs");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }

        [HttpPost("pvgInsertIntoDatasetListeDroitUtilisateur")]
        public ActionResult<List<clsRequtilisateurdroitparametre>> pvgInsertIntoDatasetListeDroitUtilisateur()
        {
            try
            {
                var service = new RequeteClientsClasse(_configuration);
                var result = service.pvgInsertIntoDatasetListeDroitUtilisateur();
                return Ok(new { Objets = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur dans pvgInsertIntoDatasetListeDroitUtilisateur");
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }


        //***********************UPLOAD FILE ***************************************//
        [HttpPost("pvgpvgMajReqrequeteEtapeUPloadFile")]
        public async Task<IActionResult> UploadEtape()
        {
            return await TraiterFichiersAsync("pvgMajReqrequeteEtapeUPloadFile");
        }

        [HttpPost("pvgpvgMajReqrequeteUPloadFile")]
        public async Task<IActionResult> UploadRequete()
        {
            return await TraiterFichiersAsync("pvgMajReqrequeteUPloadFile");
        }

        [HttpPost("pvgMajReqrequeteContentieuxUPloadFile")]
        public async Task<IActionResult> UploadContentieux()
        {
            return await TraiterFichiersAsync("pvgMajReqrequeteContentieuxUPloadFile");
        }

        private async Task<IActionResult> TraiterFichiersAsync(string action)
        {
            try
            {
                var fichiers = Request.Form.Files;
                var cheminDossier = Path.Combine(_env.WebRootPath ?? _env.ContentRootPath, "FICHIERS");

                if (!Directory.Exists(cheminDossier))
                    Directory.CreateDirectory(cheminDossier);

                var nomsFichiers = new List<string>();

                foreach (var fichier in fichiers)
                {
                    var nomFichier = Path.GetFileName(fichier.FileName).Replace(" ", "");
                    var cheminFichier = Path.Combine(cheminDossier, nomFichier);

                    using (var stream = new FileStream(cheminFichier, FileMode.Create))
                    {
                        await fichier.CopyToAsync(stream);
                    }

                    nomsFichiers.Add(nomFichier);
                }

                // Extraire les données du formulaire
                var form = Request.Form;

                switch (action)
                {
                    case "pvgMajReqrequeteEtapeUPloadFile":
                        clsDeclaration.DOCS_FICHIERS = nomsFichiers.ToArray();
                        clsDeclaration.AG_CODEAGENCE = form["AG_CODEAGENCE"];
                        clsDeclaration.RQ_CODEREQUETE = form["RQ_CODEREQUETE"];
                        clsDeclaration.AT_INDEXETAPE = form["AT_INDEXETAPE"];
                        clsDeclaration.RE_CODEETAPE = form["RE_CODEETAPE"];
                        clsDeclaration.AT_DATEFINTRAITEMENTETAPE = form["AT_DATEFINTRAITEMENTETAPE"];
                        clsDeclaration.AT_OBSERVATION = form["AT_OBSERVATION"];
                        //pvgpvgMajReqrequeteEtapeUPloadFile();
                        try
                        {
                            var service = new RequeteClientsClasse(_configuration);
                            var result = service.pvgpvgMajReqrequeteEtapeUPloadFile();
                            return Ok(result);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Erreur dans pvgpvgMajReqrequeteEtapeUPloadFile");
                            return StatusCode(500, new { Erreur = ex.Message });
                        }
                        //break;

                    case "pvgMajReqrequeteUPloadFile":
                        clsDeclaration.DOCS_FICHIERS = nomsFichiers.ToArray();
                        clsDeclaration.RQ_CODEREQUETE = form["RQ_CODEREQUETE"];
                        //pvgpvgMajReqrequeteUPloadFile();
                        try
                        {
                            var service = new RequeteClientsClasse(_configuration);
                            var result = service.pvgpvgMajReqrequeteUPloadFile();
                            return Ok(result);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Erreur dans pvgpvgMajReqrequeteUPloadFile");
                            return StatusCode(500, new { Erreur = ex.Message });
                        }
                        //break;

                    case "pvgMajReqrequeteContentieuxUPloadFile":
                        clsDeclaration.DOCS_FICHIERS = nomsFichiers.ToArray();
                        clsDeclaration.CT_CODEREQUETECONTENTIEUX = form["CT_CODEREQUETECONTENTIEUX"];
                        //pvgMajReqrequeteContentieuxUPloadFile();
                        try
                        {
                            var service = new RequeteClientsClasse(_configuration);
                            var result = service.pvgMajReqrequeteContentieuxUPloadFile();
                            return Ok(result);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Erreur dans pvgMajReqrequeteContentieuxUPloadFile");
                            return StatusCode(500, new { Erreur = ex.Message });
                        }
                       // break;
                }

                return Ok(new { Message = "Fichiers enregistrés avec succès", Fichiers = nomsFichiers });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Erreur = ex.Message });
            }
        }
        //*************************************************************************//







    }
    }
