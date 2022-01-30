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
    public partial class Qiymat : Form
    {
        public Qiymat()
        {
            InitializeComponent();
            this.comBox.DataSource = Global.GetAtributs().Select(x => x.Label).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Qiymat qiymat = new Model.Qiymat();
            qiymat.Label = tbLabel.Text;
            qiymat.AtributId = Global.GetAtributs().FirstOrDefault(x => x.Label == comBox.SelectedItem).Id;
            if(qiymat.NotNull())
            {
                qiymat.ApplyChanges();
            }
            this.Hide();
        }
    }
}
