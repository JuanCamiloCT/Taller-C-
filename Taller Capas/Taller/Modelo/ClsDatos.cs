using System;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class clsDatos
    {
        

        SqlConnection cnnConexion = null;
        SqlCommand cmdComando = null;
        SqlDataAdapter daAdaptador = null;
        DataTable Dtt = null;
        string strCadenaConexion = string.Empty;

      
        //Conexcion a la base de datos BD_Plato
        public clsDatos()
        {
            strCadenaConexion = @"Data Source=PAPOTE-PC;Initial Catalog=BD_Platos; Integrated Security = true";
        }

        public void EjecutarSP(SqlParameter[] parParametros, string parSPName)
        {
         

            try
            {
              
                cnnConexion = new SqlConnection(strCadenaConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cnnConexion.Open();
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = parSPName;
                cmdComando.Parameters.AddRange(parParametros);
                cmdComando.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();

            }

        }

        public DataTable RetornaTabla(SqlParameter[] parParametros, string parTSQL)
        {
            //Obejeto tabla
            Dtt = null;
            try
            {
                Dtt = new DataTable();
                cnnConexion = new SqlConnection(strCadenaConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = parTSQL;
                cmdComando.Parameters.AddRange(parParametros);
                daAdaptador = new SqlDataAdapter(cmdComando);
                daAdaptador.Fill(Dtt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                daAdaptador.Dispose();
            }
            return Dtt;
        }

    }
}