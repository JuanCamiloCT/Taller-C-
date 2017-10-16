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
    public partial class Mesero : Form
    {
        private SqlConnection ConexionConBD;
        private SqlCommand Orden;
        static SqlDataReader Lector;//No se porque no me quiere dar 
        //BEBIDA
        //Variables de modulo de bebidas
        string ID_B;
        string Tipo;
        string Marca;
        string Precio;
        //PEDIDO
        //Variables de reserva mesa
        string Ubicacion;
        string mesas;
        string Cantidad_sillas;
        //Variables de Calculo de total
        string Plato;
        string Ingredientes;
        string Bebidas;
        //Variables Pedido
        string Cedula;
        string Valor;
        //FACTURA
        string Nombre;
        string ValorPedido;
        string IVA;
        string Propina;
        string Total;




        string strConexion = "Data Source=MEDAFREAK0089;Initial Catalog=BD_Tiend; Integrated Security = true";
        public Mesero()
        {
            InitializeComponent();
        }
        //MODULO BEBIDAS
        //Registar Bebida
        public void RegistrarBebida()

        {
            ConexionConBD = new SqlConnection(strConexion);

            ID_B = txtb.Text;
            Tipo = txttb.Text;
            Marca = txtm.Text;
            Precio = txtp.Text;

            string Consulta = "INSERT INTO Bebidas (ID_B , Tipo, Marca, Precio) VALUES" + "(" + "'" + ID_B + "'" + "," + "'" + Tipo + "'" + "," + "'" + Marca + "'" + "," + "'" + Precio + "'" + ")";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            Orden.ExecuteNonQuery();
            Lector.Close();


        }
        //MODULO PEDIDO
        //Registrar pedido
        public void RegistarPedido()

        {
            ConexionConBD = new SqlConnection(strConexion);

            Cedula = textBox8.Text;
            Ubicacion = comboBox2.Text;
            Cantidad_sillas = numericUpDown1.Text;
            Plato = textBox9.Text;
            Ingredientes = textBox10.Text;
            Bebidas = textBox11.Text;
            Valor = textBox12.Text;

          

            string Consulta = "INSERT INTO Pedidos (Cedula ,Tipo_mesa,Cant_comensales,Plato,Ingrediente,Bebida,Valor) VALUES" + "(" + "'" + Cedula + "'" + "," + "'" + Ubicacion + "'" + "," + "'" + Cantidad_sillas + "'" + "," + "'" + Plato + "'" + "," + "'" + Ingredientes + "'" + "," + "'" + Bebidas + "'" + "," + "'" + Valor + "'" + ")";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            Orden.ExecuteNonQuery();

            textBox3.Text = textBox8.Text;
            textBox1.Text = textBox12.Text;

            double  iva = double.Parse(textBox1.Text) * (0.19) ;
            textBox15.Text = iva.ToString();
            double propina =  double.Parse(textBox1.Text) * (0.15); 
            textBox16.Text = propina.ToString();

            double Total = double.Parse(textBox1.Text) + double.Parse(textBox15.Text) + double.Parse(textBox16.Text); ;
            textBox7.Text = Total.ToString();

           
        }
        //Reserva Mesa
        public void Reservarmesa()

        {
            Ubicacion = comboBox2.Text;
            Cantidad_sillas = numericUpDown1.Text;
            mesas = textBox14.Text;
            ConexionConBD = new SqlConnection(strConexion);
            string Consulta = "UPDATE Acomodacion SET Cantidad_mesas = Cantidad_mesas -'" + mesas + "' WHERE Ubicacion ='" + Ubicacion + "' ";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(Orden);
            DataTable scores = new DataTable();
            da.Fill(scores);
            dataGridView2.DataSource = scores;

            Consultardisponibilidad();
        }
        //Consulta la disponibilidad de las mesas
        public void Consultardisponibilidad()

        {
            ConexionConBD = new SqlConnection(strConexion);
            string Consulta = "select Ubicacion, Cantidad_sillas, Cantidad_mesas From Acomodacion";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(Orden);
            DataTable scores = new DataTable();
            da.Fill(scores);
            dataGridView2.DataSource = scores;


        }
        //Consulta Platos
        public void Platos()

        {
            ConexionConBD = new SqlConnection(strConexion);
            string Consulta = "Select ID_P, Plato,Valor From Platos";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(Orden);
            DataTable scores = new DataTable();
            da.Fill(scores);
            dataGridView1.DataSource = scores;
            
        }
        //Consulta Ingredientes

        public void Ingrediente()

        {
            ConexionConBD = new SqlConnection(strConexion);
            string Consulta = "Select ID_I, Ingredientes,Valor From Ingredientes";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(Orden);
            DataTable scores = new DataTable();
            da.Fill(scores);
            dataGridView3.DataSource = scores;

        }
        //Consulta Bebidas

        public void Bebidass()

        {
            ConexionConBD = new SqlConnection(strConexion);
            string Consulta = "Select * From Bebidas";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(Orden);
            DataTable scores = new DataTable();
            da.Fill(scores);
            dataGridView4.DataSource = scores;

        }
        //Calcula el valor total segun los platos e ingredientes
        public void CalcularValor()

        {
             Plato = textBox9.Text;
             Ingredientes = textBox10.Text;
             Bebidas = textBox11.Text;



               
                double total = double.Parse(textBox4.Text) + double.Parse(textBox5.Text) + double.Parse(textBox6.Text); ;
            textBox12.Text = total.ToString();
        }
  
        //Limpia columnas de pedido
        public void Limpiar()
        {

            textBox8.Text = " ";
            comboBox2.Text = " ";
            numericUpDown1.Text= " ";
            textBox9.Text = " ";
            textBox10.Text = " ";
            textBox11.Text = " ";
            textBox12.Text = " ";
        }
        //MODULO FACTURAS
        //Registar Factura
        public void RegistrarFactura()

        {
            ConexionConBD = new SqlConnection(strConexion);

            Cedula = textBox3.Text;
            Nombre = textBox2.Text;
            ValorPedido = textBox1.Text;
            IVA = textBox15.Text;
            Propina = textBox16.Text;
            Total = textBox7.Text;


            string Consulta = "INSERT INTO Facturas (Cedula, Nombre ,Valor_pedido,IVA,Valor_propina,Valor_total) VALUES" + "(" + "'" + Cedula + "'" + "," + "'" + Nombre + "'" + "," + "'" + ValorPedido + "'" + "," + "'" + IVA + "'" + "," + "'" + Propina + "'" + "," + "'" + Total + "'" + ")";
            Orden = new SqlCommand(Consulta, ConexionConBD);
            ConexionConBD.Open();
            Orden.CommandType = CommandType.Text;
            Orden.ExecuteNonQuery();



        }
     //Quitar la propina 
        public void Nopropina()
        {

            textBox16.Text = "0";
            Totales();
        }
        //Calcula el valor total sin la propina
        public void Totales()
        {

            double Total = double.Parse(textBox1.Text) + double.Parse(textBox15.Text) + double.Parse(textBox16.Text); ;
            textBox7.Text = Total.ToString();
        }
        //Limpia campos de factura
        public void Limpiafac()
        {

           textBox3.Text = " ";
           textBox2.Text = " ";
           textBox1.Text = " ";
           textBox15.Text = " ";
           textBox16.Text = " ";
           textBox7.Text = " ";
        }
        public void CerrarConexion()
        {

            if (Lector != null)
                Lector.Close();
            if (ConexionConBD != null)
                ConexionConBD.Close();
        }
        private void Rbebida_Click(object sender, EventArgs e)
        {
            try{ 
            RegistrarBebida();
            }
            catch
            {

            }
            finally
            {
                CerrarConexion();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Consultardisponibilidad();
            }
            catch (Exception p)
            {
                label18.Text = (p.Message);
            }
            finally
            {
                CerrarConexion();
            }
}

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Reservarmesa();
            }
            catch (Exception p)
            {
                label18.Text = (p.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
      
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        


            



        }

        private void button4_Click(object sender, EventArgs e)
        {
        
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            CalcularValor();
        }

        private void Rpedido_Click(object sender, EventArgs e)
        {
            RegistarPedido();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Nopropina();
        }

        private void Rfactura_Click(object sender, EventArgs e)
        {
            RegistrarFactura();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Limpiafac();
        }
        //Asignar valor y codigo de bebida
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
                textBox11.Text = row.Cells["ID_B"].Value.ToString();
                textBox6.Text = row.Cells["Precio"].Value.ToString();
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }
        //Asignar Valor y codigo de Plato
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox9.Text = row.Cells["ID_P"].Value.ToString();
                textBox4.Text = row.Cells["Valor"].Value.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }
        //Asignar valor y codigo de ingrediente
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                textBox10.Text = row.Cells["ID_I"].Value.ToString();
                textBox5.Text = row.Cells["Valor"].Value.ToString();        
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            
        }
        //Generador de cantidades de mesas
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //Condicionales Pasillo
            if (comboBox2.Text == ("Pasillo"))
            {
                if (numericUpDown1.Value <= 2)
                {
                    textBox14.Text = ("1");
                }
                else
                if (numericUpDown1.Value <= 4)
                {
                    textBox14.Text = ("2");
                }
                else
                if (numericUpDown1.Value <= 6)
                {
                    textBox14.Text = ("3");
                }
                else
                if (numericUpDown1.Value <= 8)
                {
                    textBox14.Text = ("4");
                }
                else
                if (numericUpDown1.Value <= 10 )
                {
                    textBox14.Text = ("5");
                }
            }
            //Condcionales Balcon
            else
            if (comboBox2.Text == ("Balcon"))
            {
                if (numericUpDown1.Value <= 6)
                {
                    textBox14.Text = ("1");
                }
                else
             if (numericUpDown1.Value <= 12)
                {
                    textBox14.Text = ("2");
                }
                else
             if (numericUpDown1.Value <= 18)
                {
                    textBox14.Text = ("3");
                }
                else
              if (numericUpDown1.Value <= 24)
                {
                    textBox14.Text = ("4");
                }
            }
            else
            //Central
            if (comboBox2.Text == ("Central"))
            {
                if (numericUpDown1.Value <= 4)
                {
                    textBox14.Text = ("1");
                }
                else
           if (numericUpDown1.Value <= 8)
                {
                    textBox14.Text = ("2");
                }
                else
                if (numericUpDown1.Value <= 12)
                {
                    textBox14.Text = ("3");
                }
                else
          if (numericUpDown1.Value <= 16)
                {
                    textBox14.Text = ("4");
                }
                else
                if (numericUpDown1.Value <= 20)
                {
                    textBox14.Text = ("5");
                }
                else
          if (numericUpDown1.Value <= 24)
                {
                    textBox14.Text = ("6");
                }
            }
        }
        //Despliegue de menu
        private void button11_Click(object sender, EventArgs e)
        {
            Bebidass();
            Ingrediente();
            Platos();
        }
    }
}
