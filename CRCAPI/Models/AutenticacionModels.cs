using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRCAPI.Models
{
    public class AutenticacionModels
    {
        public int IdUsers { get; set; }
        public string Usuario_Login { get; set; }
        public string Contraseña_Login { get; set; }

        public int IdPerfil_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Apellido_Usuario { get; set; }
        public int Razon_Social { get; set; }
        public string DescripcionEmpresa { get; set; }
        public string PrefijoEmpresa { get; set; }
        public string Email_Corporativo { get; set; }
        public int Telefono_Usuario { get; set; }
        public int Celular_Personal { get; set; }
        public string Direccion_Legal_Corporativo { get; set; }
        public int RUC { get; set; }
        public int IdSede_Proyecto { get; set; }
        public string Descripcion_Rol_Usuario { get; set; }
        public Boolean Estado_Rol_Usuario { get; set; }
        public string Descripcion_Rol { get; set; }
        public int Id_Rol_Usuario { get; set; }

        public int Id_Rol_General { get; set; }
        //ESTE CAMPO SE USARA PARA TRAER DATO DE REGISTRO DE INSPECCION
        public string FechaRegistroInspeccion { get; set; }

        public int Id_Empresa { get; set; }
        public string IdUsuarioNotificado { get; set; }
    }
}