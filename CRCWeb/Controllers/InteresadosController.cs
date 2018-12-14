
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Web;
//using System.Web.Configuration;
//using System.Web.Mvc;
//using System.Web.Http;
//using System.Web.Http.Description;
//using System.Threading.Tasks;
//using CRCWeb.Models;
//using Newtonsoft.Json;


using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using CRCWeb.Models;
using System.Collections.Generic;

namespace CRCWeb.Controllers
{


    public class InteresadosController : Controller
    {
        public static string urlApi = WebConfigurationManager.AppSettings["UrlApiSecurityCrc"];
        HttpClient httpClient = new HttpClient();
        // GET: Interesados
        public async Task<ActionResult> Index()
        {
            Enlaces.EInteresado x = new Enlaces.EInteresado();
            Interesado datos = new Interesado();

            datos.LstNAreaTrabajo = await x.EAreaTrabajo();
            datos.LstSedes = await x.ESedes();
            datos.LstAreaInformacion = await x.EAreaInformacion();
            datos.LstNacionalidad = await x.ENacionalidad();
            datos.LstPais = await x.EPais();
            datos.LstInteresados = await x.EListInteresado();
            List<DatosInteresado> lstAccesoFiltro = new List<DatosInteresado>();

            foreach (var item in datos.LstInteresados)
            {
                lstAccesoFiltro.Add(item);
            }

            //se precargara la lista de interesados    
            //AutenticacionModels datosuser = (AutenticacionModels)System.Web.HttpContext.Current.Session["DatosUsuarios"];

            //var jsonLogin = await PeticionHttpClientAsync("Interesado/ListarInteresados/", "hola");

            //List<Interesado> lstAcceso = JsonConvert.DeserializeObject<List<Interesado>>(jsonLogin);
            //System.Web.HttpContext.Current.Session["ListaInteresado"] = lstAcceso;

            //List<Interesado> lstAccesoFiltro = new List<Interesado>();

            //foreach (var item in lstAcceso)
            //{
            //    lstAccesoFiltro.Add(item);
            //}
            return View(datos);

        }



        #region Metodo para envio al servicio "POST"
        public async Task<string> PeticionHttpClientAsync(string direccionURL, string datosAcceder)
        {
            var myContent = JsonConvert.SerializeObject(datosAcceder);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient httpClient = new HttpClient();
            var responsea = await httpClient.PostAsync(urlApi + direccionURL, byteContent);
            var jsonResult = await responsea.Content.ReadAsStringAsync();

            return jsonResult;
        }
        #endregion

        public async Task<ActionResult> Registro()
        {
            Enlaces.EInteresado x = new Enlaces.EInteresado();
            Interesado datos = new Interesado();

            try
            {

                datos.LstCompania = await x.ECompanias();
                datos.LstSedes = await x.ESedes();

                datos.LstNAreaTrabajo = await x.EAreaTrabajo();
                datos.LstAreaInformacion = await x.EAreaInformacion();
                datos.LstNacionalidad = await x.ENacionalidad();
                datos.LstPais = await x.EPais();
                //  datos.LstNacionalidad = await x.ENacionalidad();

            }
            catch (Exception ex)
            {
                throw;
            }
            return View(datos);
        }

        [HttpPost]
        public async Task<JsonResult> InsertNewInteresado(RegistroInteresado m)
        {

            try
            {
                var myContent = JsonConvert.SerializeObject(m);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpClient httpClient = new HttpClient();
                var responsea = await httpClient.PostAsync(urlApi + "Interesado/RegistroInteresado/", byteContent);
                var jsonResult = await responsea.Content.ReadAsStringAsync();

                Response rs = JsonConvert.DeserializeObject<Response>(jsonResult);

                if (rs.Estatus != false)
                {
                    return Json(new
                    {
                        redirectUrl = Url.Action("Index", "Interesados"),
                        isRedirect = true,
                        rs.Message,
                        rs.Estatus
                    });
                }
                else
                {
                    return Json(new
                    {
                        isRedirect = false,
                        rs.Message
                    });
                }

               
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> Visualizar(int idIns)
        {
            //if (!(System.Web.HttpContext.Current.Session["DatosUsuarios"] != null))
            //{
            //    return Json(new
            //    {
            //        redirectUrl = Url.Action("Login", "Login"),
            //        isRedirect = true
            //    });

            //}

            Enlaces.EInteresado x = new Enlaces.EInteresado();
            DatosInteresado datos = await x.EVerInteresado(idIns);
            datos.LstNAreaTrabajo = await x.EAreaTrabajo();
            datos.LstNacionalidad = await x.ENacionalidad();
            datos.LstPais = await x.EPais();
            datos.Papellido = datos.Papellido;
            datos.Sapellido = datos.Sapellido;
            datos.Nombres = datos.Nombres;
            datos.TelefonoC = datos.TelefonoC;
            datos.TelefonoCasa = datos.TelefonoCasa;
            datos.Correo = datos.Correo;
            datos.Tipo_doc = datos.Tipo_doc;
            datos.Dni = datos.Dni;
            datos.fecha_Nac = datos.fecha_Nac;
            return View(datos);

        }

        [HttpPost]
        public async Task<ActionResult> Cancelar(DatosInteresado m)
        {
            try
            {
                Enlaces.EInteresado x = new Enlaces.EInteresado();
                Response rs = await x.EEditarInter(m);

                if (rs.Estatus != false)
                {
                    return Json(new
                    {
                        redirectUrl = Url.Action("Index", "Interesados"),
                        isRedirect = true,
                        rs.Message,
                        rs.Estatus
                    });
                }
                else
                {
                    return Json(new
                    {
                        isRedirect = false,
                        rs.Message
                    });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
        [HttpGet]
        public async Task<ActionResult> CambiarEstado(int idIns)
        {

            Enlaces.EInteresado x = new Enlaces.EInteresado();
            DatosInteresado datos = await x.ECambiarInteresado(idIns);
            datos.LstNAreaTrabajo = await x.EAreaTrabajo();
            datos.LstNacionalidad = await x.ENacionalidad();
            datos.LstPais = await x.EPais();
            datos.Papellido = datos.Papellido;
            datos.Sapellido = datos.Sapellido;
            datos.Nombres = datos.Nombres;
            datos.TelefonoC = datos.TelefonoC;
            datos.TelefonoCasa = datos.TelefonoCasa;
            datos.Correo = datos.Correo;
            datos.Tipo_doc = datos.Tipo_doc;
            datos.Dni = datos.Dni;
            datos.fecha_Nac = datos.fecha_Nac;
            return View(datos);
        }

        //[HttpPost]
        //public async Task<JsonResult> EditInteresado(DatosInteresado m)
        //{


        //    try
        //    {
        //        var myContent = JsonConvert.SerializeObject(m);
        //        var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
        //        var byteContent = new ByteArrayContent(buffer);
        //        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        HttpClient httpClient = new HttpClient();
        //        var responsea = await httpClient.PostAsync(urlApi + "Interesado/EditarInteresado/", byteContent);
        //        var jsonResult = await responsea.Content.ReadAsStringAsync();

        //        Response rs = JsonConvert.DeserializeObject<Response>(jsonResult);

        //        if (rs.Estatus != false)
        //        {
        //            return Json(new
        //            {
        //                redirectUrl = Url.Action("Index", "Interesados"),
        //                isRedirect = true,
        //                rs.Message,
        //                rs.Estatus
        //            });
        //        }
        //        else
        //        {
        //            return Json(new
        //            {
        //                isRedirect = false,
        //                rs.Message
        //            });
        //        }

                
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public async Task<JsonResult> EditarInteresados(DatosInteresado m)
        {
           
                try
                {
                    Enlaces.EInteresado x = new Enlaces.EInteresado();
                    Response rs = await x.EEditarInter(m);

                    if (rs.Estatus != false)
                    {
                        return Json(new
                        {
                            redirectUrl = Url.Action("Index", "Interesados"),
                            isRedirect = true,
                            rs.Message,
                            rs.Estatus
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            isRedirect = false,
                            rs.Message
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            #region Filtros

            public async Task<JsonResult> FiltrarInteresado(FiltrosModels filtros)
        {
            int temp = 0;

            //VALIDAR ESPACIO EN BLANCO DEMAS
            if (filtros.Tipodoc != null)
                filtros.Tipodoc = filtros.Tipodoc.Trim();

            if (!(int.TryParse(filtros.nro_doc, out temp)))
            {
                filtros.nro_doc = null;
            }
            if (!(int.TryParse(filtros.apellidoP, out temp)))
            {
                filtros.apellidoP = null;
            }
            if (!(int.TryParse(filtros.correo, out temp)))
            {
                filtros.correo = null;
            }
            //if (string.IsNullOrEmpty(filtros.sede))
            //{
            //    filtros.sede = null;
            //}
            var myContent = JsonConvert.SerializeObject(filtros);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            HttpClient httpClient = new HttpClient();
            var responsea = await httpClient.PostAsync(urlApi + "Interesado/ListarInteresadoFiltro/", byteContent);
            var jsonResult = await responsea.Content.ReadAsStringAsync();

            List<DatosInteresado> varFiltrosLista = JsonConvert.DeserializeObject<List<DatosInteresado>>(jsonResult);
            return Json(varFiltrosLista, JsonRequestBehavior.AllowGet);

           
        }

        #endregion

    }
}
