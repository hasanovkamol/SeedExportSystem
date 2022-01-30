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

namespace SeedExportSystem
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();
            Global.dbo = new DbContextEntity();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeedExport export = new SeedExport();
            export.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show(); this.Hide();
        }
    }
}
