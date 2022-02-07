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
    public partial class User : Form
    {
        private List<KeyValue> keyValue = new List<KeyValue>();
        public User()
        {
            InitializeComponent();
            predmet.DataSource = Global.GetPredmets().Select(x => x.Label).ToList();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            StartWindow start = new StartWindow();
            start.Show(); this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if(key1.SelectedItem.ToString().Length>0 && value1.SelectedItem.ToString().Length > 0)
            {
                keyValue.Add(new KeyValue()
                {
                    Key = Global.GetAtributIdByLabel(key1.SelectedItem.ToString()),
                    Value = Global.GetQiymatIdBuLabel(value1.SelectedItem.ToString()),
                });
            }
            richTextBox2.Text +=(richTextBox2.Text.Length==0?" Agar ": "bo'lsa va ")
                + key1.SelectedItem.ToString()+" = "
                + value1.SelectedItem.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            keyValue = new List<KeyValue>();
            richTextBox2.Text = "";
        }

        private void predmet_SelectedIndexChanged(object sender, EventArgs e)
        {
            int prdemetSoxaId = Global.GetPredmets()
                .FirstOrDefault(x => x.Label ==((ComboBox)sender).SelectedItem.ToString())
                .Id;
            key1.DataSource = Global.GetAtributs()
                .Where(x=>x.PredmetId== prdemetSoxaId)
                .Select(x => x.Label)
                .ToList();

        }

        private void key1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int atributId = Global.GetAtributs()
                .FirstOrDefault(x => x.Label ==((ComboBox) sender).SelectedItem.ToString())
                .Id;
            value1.DataSource = Global.GetQiyamts()
                .Where(x => x.AtributId == atributId)
                .Select(x => x.Label)
                .ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (var item in Global.GetExports())
            {
                count = 0;
                foreach (var x in item.keyValues)
                {
                    if(keyValue.FirstOrDefault(s=>s.Key==x.Key && s.Value == x.Value) != null)
                    {
                        count++;
                    }
                }
                if (count == keyValue.Count)
                {
                    richTextBox1.Text +="\t" +Global.GetAtributLabelById(item.keyValues.FirstOrDefault(x => x.isResult).Key)
                        +":"+ Global.GetQiymatLabelById(item.keyValues.FirstOrDefault(x => x.isResult).Value);
                }
            }
        }
    }
}
