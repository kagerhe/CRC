using CRCWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace CRCWeb.Enlaces
{
    public class EInteresado
    {
        public static string urlApi = WebConfigurationManager.AppSettings["UrlApiSecurityCrc"];
        
       
        public async Task<List<Compania>> ECompanias()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(urlApi + "Interesado/ListaCompania");
            List<Compania> Lst = JsonConvert.DeserializeObject<List<Compania>>(result);
            return Lst;
        }
        public async Task<List<Pais>> EPais()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(urlApi + "Interesado/ListaPais");
            List<Pais> Lst = JsonConvert.DeserializeObject<List<Pais>>(result);
            return Lst;
        }
        public async Task<List<AreaTrabajo>> EAreaTrabajo()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(urlApi + "Interesado/ListaAreaTrabajo");
            List<AreaTrabajo> Lst = JsonConvert.DeserializeObject<List<AreaTrabajo>>(result);
            return Lst;
        }

        public async Task<List<Sedes>> ESedes()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(urlApi + "Interesado/ListaSedes");
            List<Sedes> Lst = JsonConvert.DeserializeObject<List<Sedes>>(result);
            return Lst;
        }

        public async Task<List<AreaInformacion>> EAreaInformacion()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(urlApi + "Interesado/ListaAreaInformacion");
            List<AreaInformacion> Lst = JsonConvert.DeserializeObject<List<AreaInformacion>>(result);
            return Lst;
        }

        public async Task<List<Nacionalidad>> ENacionalidad()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(urlApi + "Interesado/ListaNacionalidad");
            List<Nacionalidad> Lst = JsonConvert.DeserializeObject<List<Nacionalidad>>(result);
            return Lst;
        }
        public async Task<List<DatosInteresado>> EListInteresado()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(urlApi + "Interesado/ListarInteresados");
            List<DatosInteresado> Lst = JsonConvert.DeserializeObject<List<DatosInteresado>>(result);
            return Lst;
        }

        public async Task<DatosInteresado> EVerInteresado(int idIns)
        {
            DatosInteresado objSBC = new DatosInteresado();
            // objSBC.Id_sbc = sbc;

            var myContent = JsonConvert.SerializeObject(idIns);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(urlApi + "Interesado/ObtenerRegistroInteresado/", byteContent);
            var result = await response.Content.ReadAsStringAsync();

            DatosInteresado rs = JsonConvert.DeserializeObject<DatosInteresado>(result);

            return rs;
        }

        public async Task<DatosInteresado> ECambiarInteresado(int idIns)
        {
            DatosInteresado objSBC = new DatosInteresado();
            // objSBC.Id_sbc = sbc;

            var myContent = JsonConvert.SerializeObject(idIns);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(urlApi + "Interesado/CambiarInteresado/", byteContent);
            var result = await response.Content.ReadAsStringAsync();

            DatosInteresado rs = JsonConvert.DeserializeObject<DatosInteresado>(result);

            return rs;
        }

        public async Task<Response> EEditarInter(DatosInteresado m)
        {
            DatosInteresado objSBC = new DatosInteresado();


            var myContent = JsonConvert.SerializeObject(m);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient httpClient = new HttpClient();
            var responsea = await httpClient.PostAsync(urlApi + "Interesado/EditarInteresado/", byteContent);
            var jsonResult = await responsea.Content.ReadAsStringAsync();

            Response rs = JsonConvert.DeserializeObject<Response>(jsonResult);

            return rs;
        }



    }
}