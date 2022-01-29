using SeedExportSystem.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeedExportSystem
{
    public partial class SeedExport : Form
    {
        public SeedExport()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void SeedExport_Load(object sender, EventArgs e)
        {

        }
        /// Predmet soxa
        private void btn1_Click(object sender, EventArgs e)
        {
          
        }
        /// atribut 
        private void btn2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StartWindow start = new StartWindow();
            start.Show();
            this.Hide();
        }

        private void btn1_Click_1(object sender, EventArgs e)
        {
            Predmet predmet = new Predmet();
            predmet.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Atribut atribut = new Atribut();
            atribut.Show(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Qiymat qiymat = new Qiymat();
            qiymat.Show();
        }
    }
}
