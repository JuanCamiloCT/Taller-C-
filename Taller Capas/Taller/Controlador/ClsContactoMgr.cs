using System;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Controlador
{
    public class ClsContactoMgr
    {

        clsDatos cnGeneral = null;
        ClsContacto objContacto = null;
        DataTable tblDatos = null;


        public ClsContactoMgr(ClsContacto parObjContacto)
        {
            objContacto = parObjContacto;
        }
        //Clase Listar
        public DataTable Listar()
        {

            tblDatos = new DataTable();
            //Se trae los parametros que hay en el procedimeinto almacenado el cual es el 1
            try
            {
                cnGeneral = new clsDatos();

                SqlParameter[] parParameter = new SqlParameter[1];

                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@opc";
                parParameter[0].SqlDbType = SqlDbType.Int;
                parParameter[0].SqlValue = objContacto.opc;

                
                tblDatos = cnGeneral.RetornaTabla(parParameter, "SPContacto");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return tblDatos;
        }

        //Registar plato
        //Se manda el parametro para la eleccion de metodo almacenado
        //Luego los parametros y el tipo
        public void Registar()
        {



            try
            {
                cnGeneral = new clsDatos();

                SqlParameter[] parParameter = new SqlParameter[4];

                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@opc";
                parParameter[0].SqlDbType = SqlDbType.Int;
                parParameter[0].SqlValue = objContacto.opc;

                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@ID_P";
                parParameter[1].SqlDbType = SqlDbType.Int;
                parParameter[1].SqlValue = objContacto.ID_P;

                parParameter[2] = new SqlParameter();
                parParameter[2].ParameterName = "@Plato";
                parParameter[2].SqlDbType = SqlDbType.VarChar;
                parParameter[2].Size = 20;
                parParameter[2].SqlValue = objContacto.Plato;

                parParameter[3] = new SqlParameter();
                parParameter[3].ParameterName = "@Valor";
                parParameter[3].SqlDbType = SqlDbType.VarChar;
                parParameter[3].Size = 20;
                parParameter[3].SqlValue = objContacto.Valor;

                cnGeneral.EjecutarSP(parParameter, "SPContacto");



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


        public void Actualizar()
        {



            try
            {
                cnGeneral = new clsDatos();

                SqlParameter[] parParameter = new SqlParameter[4];

                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@opc";
                parParameter[0].SqlDbType = SqlDbType.Int;
                parParameter[0].SqlValue = objContacto.opc;

                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@ID_P";
                parParameter[1].SqlDbType = SqlDbType.Int;
                parParameter[1].SqlValue = objContacto.ID_P;

                parParameter[2] = new SqlParameter();
                parParameter[2].ParameterName = "@Plato";
                parParameter[2].SqlDbType = SqlDbType.VarChar;
                parParameter[2].Size = 20;
                parParameter[2].SqlValue = objContacto.Plato;

                parParameter[3] = new SqlParameter();
                parParameter[3].ParameterName = "@Telefono";
                parParameter[3].SqlDbType = SqlDbType.VarChar;
                parParameter[3].Size = 20;
                parParameter[3].SqlValue = objContacto.Valor;

                cnGeneral.EjecutarSP(parParameter, "SPContacto");



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}