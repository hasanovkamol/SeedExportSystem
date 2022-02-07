using SeedExportSystem.Dialog;
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
    public partial class SeedExport : Form
    {
        private Export export = new Export();
        public SeedExport()
        {
            InitializeComponent();
            this.UploadLs();
        }

        private void SeedExport_Load(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            StartWindow start = new StartWindow();
            start.Show();
            this.Hide();
        }

        
        private void onLoad(int predmetId)
        {
            lsExports.Text = "";
            foreach (var item in Global.GetExports().Where(x=>x.PredmetId==predmetId))
            {
                foreach (var x in item.keyValues)
                {
                    lsExports.Text += (x.isResult ? "u holda ":" Agar ")
                        +Global.GetAtributLabelById(x.Key)+" = "
                        +Global.GetQiymatLabelById(x.Value)
                        + (x.isResult ?" bo'ladi": " bo'lsa ");
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Dialog.Atribut atribut = new Dialog. Atribut();
            atribut.ShowDialog();
            if (atribut.DialogResult == DialogResult.OK) this.UploadLs();
        }
        private void btn1_Click_1(object sender, EventArgs e)
        {
            Dialog.Predmet predmet = new Dialog.Predmet();
            predmet.ShowDialog();
            if (DialogResult.OK == predmet.DialogResult) this.UploadLs();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Dialog.Qiymat qiymat = new Dialog.Qiymat();
            qiymat.ShowDialog();
            if(DialogResult.OK==qiymat.DialogResult) this.UploadLs();
        }
        private void UploadLs()
        {
            Global.Update();
            this.comBoxPredmet.DataSource =
            this.sectionList.DataSource =
            Global.GetPredmets().Select(x => x.Label).ToList();
        }
        private void sectionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int prdermetId = Global.GetPredmets()
                .FirstOrDefault(x => x.Label == ((ListBox)sender).SelectedItem.ToString()).Id;
            this.key1.DataSource =
                             this.keyList.DataSource =Global.GetAtributs()
                             .Where(x=>x.PredmetId==prdermetId)
                             .Select(x => x.Label)
                             .ToList();

            this.onLoad(prdermetId);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richresult.Text +=(natija.Checked?" U holda ": (richresult.Text.Length == 0 ? " Agar " : " va "))
                + key1.SelectedItem.ToString()
                + " = "
                + value1.SelectedItem.ToString()+(natija.Checked?" bo'ladi ":" bo'lsa ");
            export.keyValues.Add(new KeyValue()
            {
                isResult=natija.Checked,
                Key = Global.GetAtributs().FirstOrDefault(x=>x.Label==key1.SelectedItem.ToString()).Id,
                Value = Global.GetQiyamts().FirstOrDefault(x=>x.Label==value1.SelectedItem.ToString()).Id
            });            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            export.PredmetId = Global.GetPredmets()
                .FirstOrDefault(x => x.Label == comBoxPredmet.SelectedItem.ToString()).Id;
           if(export.keyValues.Count>2)
            {
                export.ApplyChanges();
                UploadLs();


            }
            else
            {
                MessageBox.Show("Error","Export ma'lumotlari to'liqligni tekshiring");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comBoxPredmet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void keyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int atributId = Global.GetAtributIdByLabel(((ListBox)sender).SelectedItem.ToString());
            this.value1.DataSource =
                   this.valueList.DataSource = Global.GetQiyamts()
                   .Where(x=>x.AtributId==atributId)
                   .Select(x => x.Label)
                   .ToList();
        }
    }
}
