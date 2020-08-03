
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistanciaMapaTeste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getValorAsync();
        }

        private void getValorAsync()
        {
            var retorno = SolariUtils.DistanciaMapa.MapDistance.GetDistancia("Mandaguari", "Maringa", "AIzaSyDvdIkbnRiIQYSc7mt5AOjLydiUf1xuhrU");
            textBox1.Text = retorno + "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var retorno = "";
            SolariUtils.WitAI.SolariWitIA.getWitAi(textBox2.Text, out retorno);

            MessageBox.Show(retorno);
        }
    }
}
