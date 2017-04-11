using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TP01
{
    public partial class Form1 : Form
    {
        Calculadora calculadora;



        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            calculadora = new Calculadora();

            Numero numero1 = new Numero(this.txtNumero1.Text);
            Numero numero2 = new Numero(this.txtNumero2.Text);         
                     
            lblResultado.Visible =  true;


            try
            {
                lblResultado.Text = calculadora.operar(numero1, numero2, cmbOperacion.SelectedItem.ToString()).ToString();
            }
            catch
            {
                lblResultado.Text = "0";
            
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {        
                  
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {
            lblResultado.Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Visible = false;
            cmbOperacion.SelectedItem = null;


        }
    }
}
