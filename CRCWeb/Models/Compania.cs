using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRCWeb.Models
{
    public class Compania
    {
        public int Id_Compania { get; set; }
        public string Descripcion { get; set; }
        public bool Estado_Compania { get; set; }
        public string Prefijo { get; set; }
    }
}
