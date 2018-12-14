using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRCAPI.Models
{
    public class ResponseModel<TModel>
    {
        public string Message { get; set; }
        public bool Estatus { get; set; }
        public TModel Data;

        public ResponseModel()
        {
            this.Estatus = true;
        }
        public void OK(TModel data)
        {
            this.Estatus = true;
            this.Message = string.Empty;
            this.Data = data;
        }

        public void OK(string mensaje)
        {
            this.Message = mensaje;
            this.Estatus = true;
        }
        public void Error(string mensaje)
        {
            this.Message = mensaje;
            if (!string.IsNullOrWhiteSpace(mensaje))
                this.Estatus = false;

        }

    }

    public class Response
    {
        public string Message { get; set; }
        public bool Estatus { get; set; }


        public Response()
        {
            this.Estatus = true;
        }

        public void OK(string mensaje)
        {
            this.Message = mensaje;
            this.Estatus = true;
        }
        public void Error(string mensaje)
        {
            this.Message = mensaje;
            if (!string.IsNullOrWhiteSpace(mensaje))
                this.Estatus = false;

        }

    }

}