using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace MVC_VISTA_
{
    public partial class Form1 : Form
    {
        ClsContacto objContacto = null;
        ClsContactoMgr objContactoMgr = null;
        DataTable Dtt = null;
        public Form1()
        {
            InitializeComponent();
        }
        //Boton llama listar y registrar
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar();
            Listar();
        }
        // se llama los objetos y se mandan los parametros 
        private void Registrar()
        {
                objContacto = new ClsContacto();
            //Si la variable es 2 llama el procedimiento de registrar
                objContacto.opc = 2;
            objContacto.ID_P = int.Parse(textBox1.Text);
            objContacto.Plato = textBox2.Text;
            objContacto.Valor = textBox3.Text;
                objContactoMgr = new ClsContactoMgr(objContacto);

            //Se llama la cla de registrar en el controlador
            objContactoMgr.Registar();
            //Mensaje
            MessageBox.Show("Plato registrado!", "Notificacion");
        }

        //Se llama los objetos y luego se enlistan en un dataGridView
        private void Listar()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 1;
            objContactoMgr = new ClsContactoMgr(objContacto);

            Dtt = new DataTable();
            Dtt = objContactoMgr.Listar();
            if (Dtt.Rows.Count > 0)
                dataGridView1.DataSource = Dtt;
        }
        //Boton de Limpiar

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text =  " ";
            textBox3.Text = "";
        }
    }
}
