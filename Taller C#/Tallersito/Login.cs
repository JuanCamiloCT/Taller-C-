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

namespace Tallersito
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //Administrador:
        //Rol : "Admin"
        //Contraseña: "123"

        //Mesero:
        //Rol : "Mesero"
        //Contraseña: "321"





        private void Ingresar_Click(object sender, EventArgs e)
        {
           
            
        }
        //Envia a la ventana de meseros
        public void Enviar1()

        {

            Mesero F1 = new Mesero();
            F1.Show();
            this.Hide();


        }
        //Envia a la ventana de administrador
        public void Enviar2()

        {

            Admin F2 = new Admin();
            F2.Show();
            this.Hide();


        }
        public void validar()

        
        {
            if (textBox1.Text ==("Admin" ) & textBox2.Text == ("123")) 
            {
                Enviar2();
            }
            else
            if (textBox1.Text == ("Mesero") & textBox2.Text == ("321"))
            {
                Enviar1();
            }
            else
        
            {
                label3.Text = ("Tiene algun campo invalido.");
            }

        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            validar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
