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
            this.comBox.DataSource = Global.GetPredmets().Select(x=>x.Label).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Atribut atribut = new Model.Atribut();
            atribut.Label = tbLabel.Text;
            atribut.PredmetId = Global.GetPredmets().FirstOrDefault(x=>x.Label==comBox.SelectedItem).Id;
            if (atribut.NotNulModel())
            {
                atribut.ApplyChanges();
            }
            this.Hide();
        }
    }
}
