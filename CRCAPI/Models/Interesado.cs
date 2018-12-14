using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRCAPI.Models
{
    public class Interesado
    {
        public int Id_Inter { get; set; }
        public string Papellido { get; set; }
        public string Sapellido { get; set; }
        public string Nombres { get; set; }
        public string Dni { get; set; }
        public string fecha_Nac { get; set; }
        public int Nacionalidad { get; set; }
        public int Pais { get; set; }
        public string TelefonoC { get; set; }
        public string TelefonoCasa { get; set; }
        public int Experiencia { get; set; }
        public string Correo { get; set; }
        public int Trabajo_Interes { get; set; }
        public int IdCompCrucero { get; set; }
        public int Tatuaje { get; set; }
        public string LugarTatu { get; set; }
        public int IdEnteraste { get; set; }
        public int IdAreaInteres { get; set; }
        public string Foto { get; set; }
        public List<Compania> LstCompania { get; set; }
        public List<Pais> LstPais { get; set; }
        public List<Nacionalidad> LstNacionalidad { get; set; }
        public List<AreaTrabajo> LstNAreaTrabajo { get; set; }
        public List<AreaInformacion> LstAreaInformacion { get; set; }
        public string usuarioasociado { get; set; }
        public string disponible { get; set; }
        public int estado { get; set; }
        public int cod_creador { get; set; }
        public List<DatosInteresado> LstInteresados { get; set; }
        public int sede { get; set; }
    }
    public class DatosInteresado
    {
        public int Id_Inter { get; set; }
        public string Papellido { get; set; }
        public string Sapellido { get; set; }
        public string Nombres { get; set; }
        public string Tipo_doc { get; set; }
        public string Dni { get; set; }
        public string fecha_Nac { get; set; }
        public int Nacionalidad { get; set; }
        public string Pais { get; set; }
        public string Correo { get; set; }
        public string TelefonoC { get; set; }
        public string TelefonoCasa { get; set; }
        public int Nivelingles { get; set; }
        public int IdEnteraste { get; set; }
        public int Trabajo_Interes { get; set; }
        public int Experiencia { get; set; }
        public int IdCompCrucero { get; set; }
        public int IdAreaInteres { get; set; }
        public int Tatuaje { get; set; }
        public string LugarTatu { get; set; }
        //public int Estado { get; set; }
        public string Direccion { get; set; }
        public string Foto { get; set; }
        public int cod_creador { get; set; }
        public string usuarioasociado { get; set; }

        //public int Id_Inter { get; set; }
        //public string Papellido { get; set; }
        //public string Sapellido { get; set; }
        //public string Nombres { get; set; }
        //public string Tipo_doc { get; set; }
        //public string Dni { get; set; }
        //public string fecha_Nac { get; set; }
        //public int Nacionalidad { get; set; }
        //public string Pais { get; set; }
        //public string Correo { get; set; }
        //public string TelefonoC { get; set; }
        //public string TelefonoCasa { get; set; }
        //public int Nivelingles { get; set; }
        //public int IdEnteraste { get; set; }
        //public int Trabajo_Interes { get; set; }
        //public int Experiencia { get; set; }
        //public int IdCompCrucero { get; set; }
        //public int IdAreaInteres { get; set; }
        //public int Tatuaje { get; set; }
        //public string LugarTatu { get; set; }
        //public int Estado { get; set; }
        //public string Direccion { get; set; }
        //public string Foto { get; set; }
        //public int cod_creador { get; set; }
        //public string usuarioasociado { get; set; }
        public List<Compania> LstCompania { get; set; }
        public List<Pais> LstPais { get; set; }
        public List<Nacionalidad> LstNacionalidad { get; set; }
        public List<AreaTrabajo> LstNAreaTrabajo { get; set; }
        public List<AreaInformacion> LstAreaInformacion { get; set; }
        public string disponible { get; set; }
        public int estado { get; set; }
        public int sede { get; set; }
    }
    public class RegistroInteresado
    {
        public int Id_Inter { get; set; }
        public string Papellido { get; set; }
        public string Sapellido { get; set; }
        public string Nombres { get; set; }
        public string Tipo_doc { get; set; }
        public string Dni { get; set; }
        public string fecha_Nac { get; set; }
        public int Nacionalidad { get; set; }
        public string Pais { get; set; }
        public string Correo { get; set; }
        public string TelefonoC { get; set; }
        public string TelefonoCasa { get; set; }
        public int Nivelingles { get; set; }
        public int IdEnteraste { get; set; }
        public int Trabajo_Interes { get; set; }
        public int Experiencia { get; set; }
        public int IdCompCrucero { get; set; }
        public int IdAreaInteres { get; set; }
        public int Tatuaje { get; set; }
        public string LugarTatu { get; set; }
        public int Estado { get; set; }
        public string Direccion { get; set; }
        public string Foto { get; set; }
        public int cod_creador { get; set; }
        public string usuarioasociado { get; set; }
        public int sede { get; set; }
        //public List<Compania> LstCompania { get; set; }
        //public List<Pais> LstPais { get; set; }
        //public List<Nacionalidad> LstNacionalidad { get; set; }
        //public List<AreaTrabajo> LstNAreaTrabajo { get; set; }
        //public List<AreaInformacion> LstAreaInformacion { get; set; }
    }


    public class EditarInteresado
    {
        public int Id_Inter { get; set; }
        public string Papellido { get; set; }
        public string Sapellido { get; set; }
        public string Nombres { get; set; }
        public string Tipo_doc { get; set; }
        public string Dni { get; set; }
        public string fecha_Nac { get; set; }
        public int Nacionalidad { get; set; }
        public string Pais { get; set; }
        public string Correo { get; set; }
        public string TelefonoC { get; set; }
        public string TelefonoCasa { get; set; }
        public int Nivelingles { get; set; }
        public int IdEnteraste { get; set; }
        public int Trabajo_Interes { get; set; }
        public int Experiencia { get; set; }
        public int IdCompCrucero { get; set; }
        public int IdAreaInteres { get; set; }
        public int Tatuaje { get; set; }
        public string LugarTatu { get; set; }
        public int Estado { get; set; }
        public string Direccion { get; set; }
        public string Foto { get; set; }
        public int cod_creador { get; set; }
        public string usuarioasociado { get; set; }
        public int sede { get; set; }
        //public List<Compania> LstCompania { get; set; }
        //public List<Pais> LstPais { get; set; }
        //public List<Nacionalidad> LstNacionalidad { get; set; }
        //public List<AreaTrabajo> LstNAreaTrabajo { get; set; }
        //public List<AreaInformacion> LstAreaInformacion { get; set; }
    }

}
