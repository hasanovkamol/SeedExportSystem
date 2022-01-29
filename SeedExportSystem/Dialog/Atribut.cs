using SeedExportSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeedExportSystem.Dialog
{
    public partial class Atribut : Form
    {
        public Atribut()
        {
            InitializeComponent();
            this.comBox.Items.Add(Global.dbo.Predmets.ToList());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Atribut atribut = new Model.Atribut();
            atribut.Label = tbLabel.Text;
            //atribut.Predmet =comBox.SelectedIndex;
            if (atribut.NotNulModel())
            {
                atribut.ApplyChanges();
            }
            this.Hide();
        }
    }
}
