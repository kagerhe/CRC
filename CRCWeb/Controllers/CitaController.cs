using CRCWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRCWeb.Controllers
{
    public class CitaController : Controller
    {
        // GET: Cita
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> RegistroCita()
        {
            Enlaces.EInteresado x = new Enlaces.EInteresado();
            Interesado datos = new Interesado();

            try
            {

                datos.LstCompania = await x.ECompanias();
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
    }
}