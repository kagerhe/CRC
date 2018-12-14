using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRCAPI.Models;

namespace CRCAPI.Controllers
{
    public class InteresadoController : ApiController
    {

        [HttpGet]
        [Route("api/Interesado/ListaCompania")]
        public IHttpActionResult GetlsCompania()
        {
      
            List<Compania> lst = new ApiMetodos.Interesados().ListaCompania();

            return Ok(lst);
        }

        [HttpGet]
        [Route("api/Interesado/ListarInteresados")]
        public IHttpActionResult GetlsInteresados()
        {

            List<Interesado> lst = new ApiMetodos.Interesados().ListaInteresados();

            return Ok(lst);
        }

        [HttpPost]
        [Route("api/Interesado/ListarInteresadoFiltro")]
        public IHttpActionResult GetListarInteresadoFiltros(FiltrosModels filtros)
        {

            var varResult = new ApiMetodos.Interesados().ListarInteresadoFiltro(filtros);

            return Ok(varResult);
        }

        [HttpGet]
        [Route("api/Interesado/ListaPais")]
        public IHttpActionResult GetlsPaiss()
        {

            List<Pais> lst = new ApiMetodos.Interesados().ListaPais();

            return Ok(lst);
        }

        [HttpGet]
        [Route("api/Interesado/ListaSedes")]
        public IHttpActionResult GetlsSedes()
        {
          
            List<Sedes> lst = new ApiMetodos.Interesados().ListaSedes();

            return Ok(lst);
        }

        [HttpGet]
        [Route("api/Interesado/ListaAreaTrabajo")]
        public IHttpActionResult GetlsAreaTrabajo()
        {
          
            List<AreaTrabajo> lst = new ApiMetodos.Interesados().ListaAreaTrabajo();

            return Ok(lst);
        }

        [HttpGet]
        [Route("api/Interesado/ListaAreaInformacion")]
        public IHttpActionResult GetlsAreaInformacion()
        {
            
            List<AreaInformacion> lst = new ApiMetodos.Interesados().ListaAreaInformacion();

            return Ok(lst);
        }
        [HttpGet]
        [Route("api/Interesado/ListaNacionalidad")]
        public IHttpActionResult GetlsNacionalidad()
        {

            List<Nacionalidad> lst = new ApiMetodos.Interesados().ListaNacionalidad();

            return Ok(lst);

        }
             //[HttpPost]
             // POST api/Interesado/RegistroInteresado
             /// <summary>
             /// Resgistro interesado
             /// </summary>
             /// <typeparam name="inte">Datos del formulario de registro de interesado </typeparam>
             /// <returns>Codigo de registro interesado</returns>
        [ResponseType(typeof(Models.Response))]
        [HttpPost]
        [Route("api/Interesado/RegistroInteresado")]
        public IHttpActionResult GetRegistrointe(RegistroInteresado inte)
        {
            var reponse = new Models.Response();
            var varResult = new ApiMetodos.Interesados().RegistrarInteresado(inte);
            var msg = "¡Se ha registrado con éxito!";
            reponse.OK(msg);
            return Json(reponse);
        }
        
        //     [ResponseType(typeof(Models.ResponseModel<DatosInteresado>))]
        //[HttpPost]
        //[Route("api/Interesado/CambiarInteresado")]
        //public IHttpActionResult GetCambiarInteresa([FromBody] int Id)
        //{
        //    ///////////////////////////Cartilla  SBC
        //    DatosInteresado varResultInte = new ApiMetodos.Interesados().CambiarInteresado(Id);
        //    // int idUser = varResultInte.id;
        //    // varResultAudit.lstDetalleAudit = new ApiMetodos.Interesados().ObtenerListar_RegistroAuditoria(Id);

        //    return Ok(varResultInte);
        //}

        [ResponseType(typeof(Models.ResponseModel<DatosInteresado>))]
        [HttpPost]
        [Route("api/Interesado/ObtenerRegistroInteresado")]
        public IHttpActionResult GetObtenerResgistroInteresa([FromBody] int Id)
        {
            ///////////////////////////Cartilla  SBC
            DatosInteresado varResultInte = new ApiMetodos.Interesados().Obtener_RegistroInteresado(Id);
           // int idUser = varResultInte.id;
           // varResultAudit.lstDetalleAudit = new ApiMetodos.Interesados().ObtenerListar_RegistroAuditoria(Id);

            return Ok(varResultInte);
        }

        [ResponseType(typeof(Models.ResponseModel<DatosInteresado>))]
        [HttpPost]
        [Route("api/Interesado/CambiarInteresado")]
        public IHttpActionResult GetCambiarEastado([FromBody] int Id)
        {
            ///////////////////////////Cartilla  SBC
            DatosInteresado varResultInte = new ApiMetodos.Interesados().CambiarEstadoInteresados(Id);
            // int idUser = varResultInte.id;
            // varResultAudit.lstDetalleAudit = new ApiMetodos.Interesados().ObtenerListar_RegistroAuditoria(Id);

            return Ok(varResultInte);
        }

        //[ResponseType(typeof(Models.Response))]
        //[HttpPost]
        //[Route("api/Interesado/CambiarInteresado")]
        //public IHttpActionResult GetCambiarEastado(RegistroInteresado Id)
        //{
        //    ///////////////////////////Cartilla  SBC
        //    DatosInteresado varResultInte = new ApiMetodos.Interesados().CambiarEstadoInteresados(Id);
        //    // int idUser = varResultInte.id;
        //    // varResultAudit.lstDetalleAudit = new ApiMetodos.Interesados().ObtenerListar_RegistroAuditoria(Id);

        //    return Ok(varResultInte);
        //}

        //[HttpPost]
        // POST api/Auditoria/EditarAuditoria
        /// <summary>
        /// Editar resgistro de auditoria
        /// </summary>
        /// <typeparam name="auditoria">Datos del formulario auditoria </typeparam>
        /// <returns>Codigo de registro de la cartilla</returns>
        [ResponseType(typeof(Models.Response))]
        [HttpPost]
        [Route("api/Interesado/EditarInteresado")]
        public IHttpActionResult PostEditarAuditoria(DatosInteresado auditoria)
        {
            var reponse = new Models.Response();
            var varResult = new ApiMetodos.Interesados().EditarInteresado(auditoria);
            var msg = "¡Se ha actualizado con éxito!";
            reponse.OK(msg);
            return Json(reponse);
        }
    }
}
