using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using CRCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Common;
using System.Data;

namespace CRCAPI.ApiMetodos
{
    public class Interesados
    {
        public List<Interesado> ListaInteresados()
        {
            List<Interesado> lstinteresado = new List<Interesado>();

            SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["DesarrolloCRCSecurity"].ToString());

            using (DbCommand sprocCmd = sqlDatabase.GetStoredProcCommand("SP_LISTAR_INTERESADO"))
            {
                using (IDataReader reader = sqlDatabase.ExecuteReader(sprocCmd))
                {
                    while (reader.Read())
                    {
                        Interesado r = new Interesado();

                        var apep = Convert.IsDBNull(reader["dsc_paterno"]);
                        if (apep != true)
                        {
                            r.Papellido = (string)reader["dsc_paterno"];
                        }


                        //var nomb = Convert.IsDBNull(reader["nombres"]);
                        //if (nomb != true)
                        //{
                        //    r.Nombres = (string)reader["nombres"];
                        //}

                        var TefCasa = Convert.IsDBNull(reader["TelefonoCasa"]);
                        if (TefCasa != true)
                        {
                            r.TelefonoCasa = (string)reader["TelefonoCasa"];
                        }

                        var TefC = Convert.IsDBNull(reader["TelefonoC"]);
                        if (TefC != true)
                        {
                            r.TelefonoC = (string)reader["TelefonoC"];
                        }

                        var Corre = Convert.IsDBNull(reader["Correo"]);
                        if (Corre != true)
                        {
                            r.Correo = (string)reader["Correo"];
                        }
                        var usuasociado = Convert.IsDBNull(reader["usuarioasociado"]);
                        if (usuasociado != true)
                        {
                            r.usuarioasociado = (string)reader["usuarioasociado"];
                        }
                        //var usuasoc = Convert.IsDBNull(reader["cod_creador"]);
                        //if (usuasoc != true)
                        //{
                        //    r.usuarioasociado = (Int32)reader["cod_creador"];
                        //}

                        var estad = Convert.IsDBNull(reader["estado"]);
                        if (estad != true)
                        {
                            r.estado = (Int32)reader["estado"];
                        }
                        var codpostu = Convert.IsDBNull(reader["IdInte"]);
                        if (codpostu != true)
                        {
                            r.Id_Inter = (Int32)reader["IdInte"];
                        }


                        //ValorDefault = _reader.IsDBNull(3) ? String.Empty : _reader.GetString(3);
                        lstinteresado.Add(r);
                    }
                }
            }

            return lstinteresado;
        }
        public List<DatosInteresado> ListarInteresadoFiltro(FiltrosModels filtros)
        {
            List<DatosInteresado> lstAuditoriaFiltro = new List<DatosInteresado>();

            SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["DesarrolloCRCSecurity"].ToString());

            using (DbCommand sprocCmd = sqlDatabase.GetStoredProcCommand("SP_FILTROS_INTERESADO"))
            {
                //sqlDatabase.AddInParameter(sprocCmd, "@Tipodoc", DbType.String, filtros.Tipodoc);
                //sqlDatabase.AddInParameter(sprocCmd, "@nro_doc", DbType.String, filtros.nro_doc);
                //sqlDatabase.AddInParameter(sprocCmd, "@apellidoP", DbType.String, filtros.apellidoP);
                //sqlDatabase.AddInParameter(sprocCmd, "@correo", DbType.String, filtros.correo);
                //sqlDatabase.AddInParameter(sprocCmd, "@Fechainicio", DbType.String, filtros.Fechainicio);
                //sqlDatabase.AddInParameter(sprocCmd, "@Fechafin", DbType.String, filtros.Fechafin);
                sqlDatabase.AddInParameter(sprocCmd, "@sede", DbType.String, filtros.sede);
                //sqlDatabase.AddInParameter(sprocCmd, "@formacontacto", DbType.String, filtros.formacontacto);
                //sqlDatabase.AddInParameter(sprocCmd, "@AreaInteres", DbType.String, filtros.AreaInteres);
                sqlDatabase.AddInParameter(sprocCmd, "@usuario", DbType.String, filtros.usuario);
                //sqlDatabase.AddInParameter(sprocCmd, "@estado", DbType.String, filtros.estado);


                using (IDataReader reader = sqlDatabase.ExecuteReader(sprocCmd))
                {
                    while (reader.Read())
                    {
                        DatosInteresado varAuditoria = new DatosInteresado();
                        var apep = Convert.IsDBNull(reader["dsc_paterno"]);
                        if (apep != true)
                        {
                            varAuditoria.Papellido = (string)reader["dsc_paterno"];
                        }
                        //var nomb = Convert.IsDBNull(reader["dsc_nombres"]);
                        //if (nomb != true)
                        //{
                        //    varAuditoria.Nombres = (string)reader["dsc_nombres"];
                        //}

                        var TefCasa = Convert.IsDBNull(reader["TelefonoCasa"]);
                        if (TefCasa != true)
                        {
                            varAuditoria.TelefonoCasa = (string)reader["TelefonoCasa"];
                        }

                        var TefC = Convert.IsDBNull(reader["TelefonoC"]);
                        if (TefC != true)
                        {
                            varAuditoria.TelefonoC = (string)reader["TelefonoC"];
                        }

                        var Corre = Convert.IsDBNull(reader["Correo"]);
                        if (Corre != true)
                        {
                            varAuditoria.Correo = (string)reader["Correo"];
                        }

                        var usuasoc = Convert.IsDBNull(reader["cod_creador"]);
                        if (usuasoc != true)
                        {
                            varAuditoria.cod_creador = (Int32)reader["cod_creador"];
                        }

                        var estad = Convert.IsDBNull(reader["estado"]);
                        if (estad != true)
                        {
                            varAuditoria.estado = (int)reader["estado"];
                        }

                        var idinte = Convert.IsDBNull(reader["IdInte"]);
                        if (idinte != true)
                        {
                            varAuditoria.Id_Inter = (int)reader["IdInte"];
                        }

                        var usuasociado = Convert.IsDBNull(reader["usuarioasociado"]);
                        if (usuasociado != true)
                        {
                            varAuditoria.usuarioasociado = (string)reader["usuarioasociado"];
                        }


                        //var codpostu = Convert.IsDBNull(reader["cod_postulante"]);
                        //if (codpostu != true)
                        //{
                        //    varAuditoria.Id_Inter = (Int32)reader["cod_postulante"];
                        //}


                        lstAuditoriaFiltro.Add(varAuditoria);
                    }
                }
            }

            return lstAuditoriaFiltro;
        }
        //public List<DatosInteresado> ListarInteresadoFiltro(FiltrosModels filtros)
        //{
        //    List<DatosInteresado> lstAuditoriaFiltro = new List<DatosInteresado>();

        //    SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["DesarrolloCRCSecurity"].ToString());

        //    using (DbCommand sprocCmd = sqlDatabase.GetStoredProcCommand("SP_FILTROS_INTERESADO"))
        //    {


        //        sqlDatabase.AddInParameter(sprocCmd, "@Tipodoc", DbType.String, filtros.Tipodoc);
        //        sqlDatabase.AddInParameter(sprocCmd, "@nro_doc", DbType.String, filtros.nro_doc);
        //        sqlDatabase.AddInParameter(sprocCmd, "@apellidoP", DbType.String, filtros.apellidoP);
        //        sqlDatabase.AddInParameter(sprocCmd, "@correo", DbType.String, filtros.correo);
        //        sqlDatabase.AddInParameter(sprocCmd, "@Fechainicio", DbType.String, filtros.Fechainicio);
        //        sqlDatabase.AddInParameter(sprocCmd, "@Fechafin", DbType.String, filtros.Fechafin);
        //        sqlDatabase.AddInParameter(sprocCmd, "@sede", DbType.String, filtros.sede);
        //        sqlDatabase.AddInParameter(sprocCmd, "@formacontacto", DbType.String, filtros.formacontacto);
        //        sqlDatabase.AddInParameter(sprocCmd, "@AreaInteres", DbType.String, filtros.AreaInteres);
        //        sqlDatabase.AddInParameter(sprocCmd, "@usuario", DbType.String, filtros.usuario);
        //        sqlDatabase.AddInParameter(sprocCmd, "@estado", DbType.String, filtros.estado);

        //        using (IDataReader reader = sqlDatabase.ExecuteReader(sprocCmd))
        //        {
        //            while (reader.Read())
        //            {
        //                DatosInteresado r = new DatosInteresado();
        //                var apep = Convert.IsDBNull(reader["dsc_paterno"]);
        //                if (apep != true)
        //                {
        //                    r.Papellido = (string)reader["dsc_paterno"];
        //                }

        //                //var apem = Convert.IsDBNull(reader["dsc_materno"]);
        //                //if (apem != true)
        //                //{
        //                //    r.Sapellido = (string)reader["dsc_materno"];
        //                //}

        //                var nomb = Convert.IsDBNull(reader["dsc_nombres"]);
        //                if (nomb != true)
        //                {
        //                    r.Nombres = (string)reader["dsc_nombres"];
        //                }

        //                var TefCasa = Convert.IsDBNull(reader["num_telefono"]);
        //                if (TefCasa != true)
        //                {
        //                    r.TelefonoC = (string)reader["num_telefono"];
        //                }

        //                var TefC = Convert.IsDBNull(reader["num_celular2"]);
        //                if (TefC != true)
        //                {
        //                    r.TelefonoC = (string)reader["num_celular2"];
        //                }

        //                var Corre = Convert.IsDBNull(reader["dsc_email"]);
        //                if (Corre != true)
        //                {
        //                    r.Correo = (string)reader["dsc_email"];
        //                }

        //                var usuasoc = Convert.IsDBNull(reader["cod_creador"]);
        //                if (usuasoc != true)
        //                {
        //                    r.usuarioasociado = (string)reader["cod_creador"];
        //                }

        //                var estad = Convert.IsDBNull(reader["estado"]);
        //                if (estad != true)
        //                {
        //                    r.estado = (string)reader["estado"];
        //                }
        //                var codpostu = Convert.IsDBNull(reader["cod_postulante"]);
        //                if (codpostu != true)
        //                {
        //                    r.Id_Inter = (Int32)reader["cod_postulante"];
        //                }

        //                lstAuditoriaFiltro.Add(r);
        //            }
        //        }
        //    }

        //    return lstAuditoriaFiltro;
        //}


        public List<Compania> ListaCompania()
        {
            List<Compania> lstEmpresas = new List<Compania>();

            SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["DesarrolloCRCSecurity"].ToString());

            using (DbCommand sprocCmd = sqlDatabase.GetStoredProcCommand("SP_LISTAR_COMPANIA_CRUCERO"))
            {
                using (IDataReader reader = sqlDatabase.ExecuteReader(sprocCmd))
                {

                    while (reader.Read())
                    {
                        Compania r = new Compania();
                        r.Id_Compania = (Int32)reader["Id_Compania"];
                        r.Descripcion = (string)reader["Descripcion"];
                        lstEmpresas.Add(r);
                    }
                    //while (reader.Read())
                    //{
                    //    Compania r = new Compania();
                    //    r.Id_Compania = (string)reader["cod_cliente"];
                    //    r.Descripcion = (string)reader["dsc_cliente"];
                    //    lstEmpresas.Add(r);
                    //}
                }
            }

            return lstEmpresas;
        }

        public List<Pais> ListaPais()
        {
            List<Pais> lstPais = new List<Pais>();

            SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["DesarrolloCRCSecurity"].ToString());

            using (DbCommand sprocCmd = sqlDatabase.GetStoredProcCommand("SP_LISTAR_PAIS"))
            {
                using (IDataReader reader = sqlDatabase.ExecuteReader(sprocCmd))
                {
                    while (reader.Read())
                    {
                        Pais r = new Pais();
                        r.Id_Pais = (Int32)reader["Id_pais"];
                        r.DescripcionP = (string)reader["NombreP"];
                        lstPais.Add(r);
                    }
                }
            }

            return lstPais;
        }

        public List<Sedes> ListaSedes()
        {
            List<Sedes> lstPais = new List<Sedes>();

            SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["DesarrolloCRCSecurity"].ToString());

            using (DbCommand sprocCmd = sqlDatabase.GetStoredProcCommand("SP_LISTAR_SEDES"))
            {
                using (IDataReader reader = sqlDatabase.ExecuteReader(sprocCmd))
                {
                    while (reader.Read())
                    {
                        Sedes r = new Sedes();
                        r.Id_Sede = (Int32)reader["IdSede"];
                        r.Descripcion = (string)reader["Descripcion"];
                        lstPais.Add(r);
                    }
                }
            }

            return lstPais;
        }


        public List<AreaTrabajo> ListaAreaTrabajo()
        {
            List<AreaTrabajo> lstArea = new List<AreaTrabajo>();

            SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["DesarrolloCRCSecurity"].ToString());

            using (DbCommand sprocCmd = sqlDatabase.GetStoredProcCommand("SP_LISTAR_AREATRABAJO"))
            {

                using (IDataReader reader = sqlDatabase.ExecuteReader(sprocCmd))
                {
                    while (reader.Read())
                    {
                        AreaTrabajo r = new AreaTrabajo();
                        r.Id_Area = (Int32)reader["Id_Area"];
                        r.Descripcion = (string)reader["DescripcionArea"];
                        lstArea.Add(r);
                    }
                }
            }

            return lstArea;
        }

        public List<AreaInformacion> ListaAreaInformacion()
        {
            List<AreaInformacion> lstArea = new List<AreaInformacion>();

            SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["DesarrolloCRCSecurity"].ToString());

            using (DbCommand sprocCmd = sqlDatabase.GetStoredProcCommand("SP_LISTAR_AREAINFORMACION"))
            {
                using (IDataReader reader = sqlDatabase.ExecuteReader(sprocCmd))
                {
                    while (reader.Read())
                    {
                        AreaInformacion r = new AreaInformacion();
                        r.Id_AreaI = (Int32)reader["Id_Interes"];
                        r.Descripcion = (string)reader["Descripcion_I"];
                        lstArea.Add(r);
                    }
                }
            }

            return lstArea;
        }

        public List<Nacionalidad> ListaNacionalidad()
        {
            List<Nacionalidad> lstNac = new List<Nacionalidad>();

            SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["DesarrolloCRCSecurity"].ToString());

            using (DbCommand sprocCmd = sqlDatabase.GetStoredProcCommand("SP_LISTAR_NACIONALIDAD"))
            {
                using (IDataReader reader = sqlDatabase.ExecuteReader(sprocCmd))
                {
                    while (reader.Read())
                    {
                        Nacionalidad r = new Nacionalidad();
                        r.Id_Nac = (Int32)reader["Id_Nac"];
                        r.Descripcion = (string)reader["Descripcion"];
                        lstNac.Add(r);
                    }
                }
            }

            return lstNac;
        }

        public string RegistrarInteresado(RegistroInteresado inte)
        {
            var ObtenerCodigo = string.Empty;
            string tipodoc = "";

            if (inte.Tipo_doc == "1")
            {
                tipodoc = "DNI";
            }
            else
            {
                tipodoc = "CE";
            }

            SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["DesarrolloCRCSecurity"].ToString());
            // var sça = inte.LstCargo.FirstOrDefault().IdCargo;
            using (DbConnection conn = sqlDatabase.CreateConnection())
            {
                try
                {
                    DateTime fnac;
                    DateTime.TryParse(inte.fecha_Nac, out fnac);
                    DbCommand cmd = sqlDatabase.GetStoredProcCommand("SP_REGISTRAR_INTERESADO");
                    //sqlDatabase.AddInParameter(cmd, "@TipoDoc", DbType.String, tipodoc);
                    //sqlDatabase.AddInParameter(cmd, "@Dni", DbType.String, inte.Dni);
                    //sqlDatabase.AddInParameter(cmd, "@ApellidoP", DbType.String, inte.Papellido);
                    //sqlDatabase.AddInParameter(cmd, "@ApellidoM", DbType.String, inte.Sapellido);
                    //sqlDatabase.AddInParameter(cmd, "@Nombres", DbType.String, inte.Nombres);
                    //sqlDatabase.AddInParameter(cmd, "@Nacionalidad", DbType.Int32, inte.Nacionalidad);
                    //sqlDatabase.AddInParameter(cmd, "@NivelIngles", DbType.Int32, inte.Nivelingles);
                    //sqlDatabase.AddInParameter(cmd, "@TelefonoC", DbType.String, inte.TelefonoCasa);
                    //sqlDatabase.AddInParameter(cmd, "@TelefonoCasa", DbType.String, inte.TelefonoCasa);
                    //sqlDatabase.AddInParameter(cmd, "@ExperienciaC", DbType.String, inte.Experiencia);
                    //sqlDatabase.AddInParameter(cmd, "@TrabajoInteres", DbType.Int32, inte.Trabajo_Interes);
                    //sqlDatabase.AddInParameter(cmd, "@cod_cliente", DbType.String, inte.IdCompCrucero);
                    //sqlDatabase.AddInParameter(cmd, "@Tatuaje", DbType.Int32, inte.Tatuaje);
                    //sqlDatabase.AddInParameter(cmd, "@IdEnteraste", DbType.Int32, inte.IdEnteraste);
                    //sqlDatabase.AddInParameter(cmd, "@IdAreaInt", DbType.Int32, inte.IdAreaInteres);
                    //sqlDatabase.AddInParameter(cmd, "@Foto", DbType.String, inte.Foto);
                    //sqlDatabase.AddInParameter(cmd, "@Pais", DbType.String, inte.Pais);
                    //sqlDatabase.AddInParameter(cmd, "@Correo", DbType.String, inte.Correo);
                    //sqlDatabase.AddInParameter(cmd, "@LugarTatu", DbType.String, inte.LugarTatu);
                    //sqlDatabase.AddInParameter(cmd, "@Fecha_Reg", DbType.String, inte.fecha_Nac);
                    //sqlDatabase.AddInParameter(cmd, "@Direccion", DbType.String, inte.Direccion);
                    //sqlDatabase.AddInParameter(cmd, "@Fecha_Nac", DbType.String, inte.fecha_Nac);
                    //sqlDatabase.AddInParameter(cmd, "@Estado", DbType.Int32, inte.Estado);

                    sqlDatabase.AddInParameter(cmd, "@TipoDoc", DbType.String, tipodoc);
                    sqlDatabase.AddInParameter(cmd, "@Dni", DbType.String, inte.Dni);
                    sqlDatabase.AddInParameter(cmd, "@ApellidoP", DbType.String, inte.Papellido);
                    sqlDatabase.AddInParameter(cmd, "@ApellidoM", DbType.String, inte.Sapellido);
                    sqlDatabase.AddInParameter(cmd, "@Nombres", DbType.String, inte.Nombres);
                    sqlDatabase.AddInParameter(cmd, "@Nacionalidad", DbType.Int32, inte.Nacionalidad);
                    sqlDatabase.AddInParameter(cmd, "@NivelIngles", DbType.Int32, inte.Nivelingles);
                    sqlDatabase.AddInParameter(cmd, "@TelefonoC", DbType.String, inte.TelefonoC);
                    sqlDatabase.AddInParameter(cmd, "@TelefonoCasa", DbType.String, inte.TelefonoCasa);
                    sqlDatabase.AddInParameter(cmd, "@ExperienciaC", DbType.Int32, inte.Experiencia);
                    sqlDatabase.AddInParameter(cmd, "@TrabajoInteres", DbType.Int32, inte.Trabajo_Interes);
                    sqlDatabase.AddInParameter(cmd, "@IdCompCruzero", DbType.Int32, inte.IdCompCrucero);
                    sqlDatabase.AddInParameter(cmd, "@Tatuaje", DbType.Int32, inte.Tatuaje);
                    sqlDatabase.AddInParameter(cmd, "@IdEnteraste", DbType.Int32, inte.IdEnteraste);
                    sqlDatabase.AddInParameter(cmd, "@IdAreaInt", DbType.Int32, inte.IdAreaInteres);
                    sqlDatabase.AddInParameter(cmd, "@Foto", DbType.String, inte.Foto);
                    sqlDatabase.AddInParameter(cmd, "@Pais", DbType.Int32, inte.Pais);
                    sqlDatabase.AddInParameter(cmd, "@Correo", DbType.String, inte.Correo);
                    sqlDatabase.AddInParameter(cmd, "@LugarTatu", DbType.String, inte.LugarTatu);
                    sqlDatabase.AddInParameter(cmd, "@Fecha_Reg", DbType.String, inte.fecha_Nac);
                    sqlDatabase.AddInParameter(cmd, "@Direccion", DbType.String, inte.Direccion);
                    sqlDatabase.AddInParameter(cmd, "@Fecha_Nac", DbType.String, inte.fecha_Nac);
                    sqlDatabase.AddInParameter(cmd, "@codcreador", DbType.Int32, inte.cod_creador);
                    sqlDatabase.AddInParameter(cmd, "@estado", DbType.Int32, inte.Estado);
                    sqlDatabase.AddInParameter(cmd, "@usuarioasociado", DbType.String, inte.usuarioasociado);
                    sqlDatabase.AddInParameter(cmd, "@IdSede", DbType.Int32, inte.sede);

                    using (IDataReader reader = sqlDatabase.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {

                            ObtenerCodigo = (string)reader["IdInte"];
                        }
                    }
                    return ObtenerCodigo;

                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }

        }

        public DatosInteresado CambiarEstadoInteresados(int Id)
        {
            DatosInteresado varInte = new DatosInteresado();
            //List<Sede_Proyecto> sede = new List<Sede_Proyecto>();
            //List<CargoUsuario> cargo = new List<CargoUsuario>();
            //CargoUsuario objCargo = new CargoUsuario();
            //Sede_Proyecto objSede = new Sede_Proyecto();
            SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["DesarrolloCRCSecurity"].ToString());

            using (DbCommand sprocCmd = sqlDatabase.GetStoredProcCommand("[SP_VERINTERESADO]"))
            {
                sqlDatabase.AddInParameter(sprocCmd, "@IdInte", DbType.String, Id);

                using (IDataReader reader = sqlDatabase.ExecuteReader(sprocCmd))
                {
                    while (reader.Read())
                    {
                        try
                        {

                            varInte.Id_Inter = (Int32)reader["IdInte"];
                            // varAudit.Fecha_Audit = Convert.ToString(reader["Fecha_Audit"]);
                            varInte.Papellido = (string)reader["Papellido"];
                            varInte.Sapellido = (string)reader["Sapellido"];
                            varInte.Nombres = (string)reader["nombres"];
                            varInte.TelefonoC = (string)reader["TelefonoC"];
                            varInte.TelefonoCasa = (string)reader["TelefonoCasa"];
                            varInte.Correo = (string)reader["Correo"];
                            varInte.fecha_Nac = Convert.ToString(reader["Fecha_Nac"]);
                            varInte.Tipo_doc = (string)reader["TipoDoc"];
                            varInte.Dni = (string)reader["Dni"];
                            varInte.LugarTatu = (string)reader["LugarTatu"];
                            varInte.Trabajo_Interes = (Int32)reader["TrabajoInteres"];
                            varInte.IdCompCrucero = (Int32)reader["IdCompCruzero"];
                            varInte.IdEnteraste = (Int32)reader["IdEnteraste"];
                            varInte.IdAreaInteres = (Int32)reader["IdAreaInt"];
                            varInte.Pais = (string)reader["Pais"];
                            varInte.Nivelingles = (Int32)reader["Nivelingles"];
                            varInte.sede = (Int32)reader["IdSede"];
                        }
                        catch (Exception ex)
                        {

                            throw;
                        }
                    }
                }
            }

            return varInte;

        }

        public DatosInteresado Obtener_RegistroInteresado(int Id)
        {
            DatosInteresado varInte = new DatosInteresado();
            //List<Sede_Proyecto> sede = new List<Sede_Proyecto>();
            //List<CargoUsuario> cargo = new List<CargoUsuario>();
            //CargoUsuario objCargo = new CargoUsuario();
            //Sede_Proyecto objSede = new Sede_Proyecto();
            SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["DesarrolloCRCSecurity"].ToString());

            using (DbCommand sprocCmd = sqlDatabase.GetStoredProcCommand("SP_LIST_INTERESADO"))
            {
                sqlDatabase.AddInParameter(sprocCmd, "@IdInte", DbType.String, Id);

                using (IDataReader reader = sqlDatabase.ExecuteReader(sprocCmd))
                {
                    while (reader.Read())
                    {
                        try
                        {

                            varInte.Id_Inter = (Int32)reader["IdInte"];
                            // varAudit.Fecha_Audit = Convert.ToString(reader["Fecha_Audit"]);
                            varInte.Papellido = (string)reader["Papellido"];
                            varInte.Sapellido = (string)reader["Sapellido"];
                            varInte.Nombres = (string)reader["nombres"];
                            varInte.TelefonoC = (string)reader["TelefonoC"];
                            varInte.TelefonoCasa = (string)reader["TelefonoCasa"];
                            varInte.Correo = (string)reader["Correo"];
                            varInte.fecha_Nac = Convert.ToString(reader["Fecha_Nac"]);
                            varInte.Tipo_doc = (string)reader["TipoDoc"];
                            varInte.Dni = (string)reader["Dni"];
                          //  varInte.LugarTatu = (string)reader["LugarTatu"];
                            //varInte.Trabajo_Interes = (Int32)reader["TrabajoInteres"];
                            //varInte.IdCompCrucero = (Int32)reader["IdCompCruzero"];
                            //varInte.IdEnteraste = (Int32)reader["IdEnteraste"];
                            //varInte.IdAreaInteres = (Int32)reader["IdAreaInt"];
                            //varInte.Pais = (string)reader["Pais"];
                            //varInte.Nivelingles = (Int32)reader["Nivelingles"];
                            //varInte.sede = (Int32)reader["IdSede"];
                        }
                        catch (Exception ex)
                        {

                            throw;
                        }
                    }
                }
            }

            return varInte;

        }



        public string EditarInteresado(DatosInteresado auditoria)
        {
            var ObtenerCodigo = string.Empty;
            int Estado;
            //if (auditoria.Estado_Audit == 2)
            //{
            //    Estado = 2;
            //}
            //else
            //{
            //    Estado = 3;
            //}

            SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["DesarrolloCRCSecurity"].ToString());
            using (DbConnection conn = sqlDatabase.CreateConnection())
            {
                try
                {

                    //DateTime fregistro;
                    //DateTime.TryParse(auditoria.Fecha_Audit, out fregistro);
                    DbCommand cmd = sqlDatabase.GetStoredProcCommand("[SP_ACTUALIZAR_ESTATUSINTERESADO]");
                    sqlDatabase.AddInParameter(cmd, "@IdInte", DbType.Int32, auditoria.Id_Inter);
                    sqlDatabase.AddInParameter(cmd, "@estado", DbType.Int32, auditoria.estado);
                    var valor = (sqlDatabase.ExecuteNonQuery(cmd) == 1) ? 1 : 0;
                    return valor.ToString();

                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
        }
    }
}