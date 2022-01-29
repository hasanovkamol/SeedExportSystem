using System;

using System.Windows.Forms;

namespace SeedExportSystem.Dialog
{
    public partial class Predmet : Form
    {
        public Predmet()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Predmet predmet = new Model.Predmet();
            predmet.Label = tbLabel.Text;
            if (predmet.NotNull())
            {
                predmet.ApplyChanges();
            }
            this.Hide();
        }
    }
}
