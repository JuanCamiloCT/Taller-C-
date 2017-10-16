using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection;

namespace Tallersito
{
    public partial class Admin : Form
    {
        private SqlConnection ConexionConBD;
        private SqlCommand Orden;
        static SqlDataReader Lector;//No se porque no me quiere dar
        //PLATO
        //Variables de modulo de platos
        string ID_P;
        string Plato;
        string Valorp;
        //INGREDIENTES
        //Variables de modulo de ingredientes
        string ID_I;
        string Ingredientes;
        string Valori;
        string ID_Plato;



        string strConexion = "Data Source=MEDAFREAK0089;Initial Catalog=BD_Tiend; Integrated Security = true";
        public Admin()
        {
            InitializeComponent();
        }
        //MODULO REGISTRAR PLATO
        //Registrar plato
        public void RegistarPlato()

        {
            ConexionConBD = new SqlConnection(strConexion);

            ID_P = textBox5.Text;
            Plato = textBox1.Text;
            Valorp = textBox2.Text;
            

            string Consulta = "INSERT INTO Platos (ID_P , Plato, Valor) VALUES" + "(" + "'" + ID_P + "'" + "," + "'" + Plato + "'" + "," + "'" + Valorp + "'" + ")";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            Orden.ExecuteNonQuery();
            


        }
        //Registrar ingrediente
        public void RegistarIngrediente()

        {
            ConexionConBD = new SqlConnection(strConexion);

            ID_I = textBox6.Text;
            Ingredientes = textBox3.Text;
            Valori = textBox4.Text;
            ID_Plato = textBox7.Text;


            string Consulta = "INSERT INTO Ingredientes(ID_I,Ingredientes,Valor,ID_Plato) VALUES" + "(" + "'" + ID_I + "'" + "," + "'" + Ingredientes + "'" + "," + "'" + Valori + "'" + "," + "'" + ID_Plato + "'" + ")";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            Orden.ExecuteNonQuery();
       

        }
        //MODULO DE REPORTES
        //Consulta toda la tabla de facturas
        public void ConsultarFacturas()

        {
            ConexionConBD = new SqlConnection(strConexion);
            string Consulta = "select * From Facturas";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(Orden);
            DataTable scores = new DataTable();
            da.Fill(scores);
            dataGridView1.DataSource = scores;


        }
        //Consulta toda la tabla de pedidos
        public void ConsultarPedido()

        {
            ConexionConBD = new SqlConnection(strConexion);
            string Consulta = "select *  From Pedidos";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(Orden);
            DataTable scores = new DataTable();
            da.Fill(scores);
            dataGridView1.DataSource = scores;


        }
        //Solicita un top 3 de los platos mas frecuentes
        public void topplatos()

        {
            ConexionConBD = new SqlConnection(strConexion);
            string Consulta = "select  Top 3 p.Plato, count(pe.Plato) as Cantidad from Pedidos pe  join Platos p on pe.Plato = p.ID_P group by pe.Plato,p.Plato order by count(pe.Plato) desc";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(Orden);
            DataTable scores = new DataTable();
            da.Fill(scores);
            dataGridView1.DataSource = scores;


        }
        //Solicita un top 3 de los clientes mas frecuentes
        public void topclientes()

        {
            ConexionConBD = new SqlConnection(strConexion);
            string Consulta = "SELECT TOP 3 Nombre, count(Cedula) as Cedula FROM Facturas GROUP BY Nombre ORDER BY Cedula DESC";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(Orden);
            DataTable scores = new DataTable();
            da.Fill(scores);
            dataGridView1.DataSource = scores;


        }
        //Solicita un top 3 de bebidas segun el plato
        public void topbebidas()

        {
            ConexionConBD = new SqlConnection(strConexion);
            string Consulta = "select TOP 3 b.Tipo,pe.Plato, count(pe.Bebida) as Cantidad from Pedidos pe  join Bebidas b on pe.Bebida = b.ID_B group by pe.Bebida,b.Tipo,pe.Plato order by count(pe.Bebida) desc";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(Orden);
            DataTable scores = new DataTable();
            da.Fill(scores);
            dataGridView1.DataSource = scores;


        }
        //Limpia cajas
        public void Limpiar()
        {

            textBox5.Text = " ";
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox6.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox7.Text = " ";
        }
        //Cierra conexcion
        public void CerrarConexion()
        {

            if (Lector != null)
                Lector.Close();
            if (ConexionConBD != null)
                ConexionConBD.Close();
        }

        private void Rplato_Click(object sender, EventArgs e)
        {
            try
            {
                RegistarPlato();
               
            }
            catch (Exception p)
            {
                label8.Text = (p.Message);
            }
            finally
            {
                CerrarConexion();
            }
            
        }

        private void Ringre_Click(object sender, EventArgs e)
        {
            try
            {
                RegistarIngrediente();
              

            }
            catch (Exception p)
            {
                label8.Text = (p.Message);
            }
            finally
            {
                CerrarConexion();
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultarFacturas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultarPedido();
        }

        private void Topplatos_Click(object sender, EventArgs e)
        {
            topplatos();
        }

        private void Topclientes_Click(object sender, EventArgs e)
        {
            topclientes();
        }

        private void Topbebidas_Click(object sender, EventArgs e)
        {
            topbebidas();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
