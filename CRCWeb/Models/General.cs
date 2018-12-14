using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace CRCWeb.Models
{
    public class General
    {

        public string codigo { set; get; }

        public string descripcion { set; get; }

    }

    public class ElementoStringCollection : Collection<Tuple<string, string>>
    {
        public void Add(string item1, string item2)
        {
            this.Add(new Tuple<string, string>(item1, item2));
        }
    }


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

    public class InfiniteList<T> : List<InfiniteList<T>>
    {
        public T Value { set; get; }
    }

}
