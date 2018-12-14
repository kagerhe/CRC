using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRCAPI.Models
{
    public class Nacionalidad
    {
        public int Id_Nac { get; set; }
        public string Descripcion { get; set; }
       
    }

    public class Pais
    {
        public int Id_Pais { get; set; }
        public string DescripcionP { get; set; }

    }


}