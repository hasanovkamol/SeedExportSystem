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

        
        private void UploadLs()
        {
           this.comBoxPredmet.DataSource=
              this.sectionList.DataSource=
                Global.GetPredmets().Select(x => x.Label).ToList();
            this.key1.DataSource=
                this.keyList.DataSource =
                Global.GetAtributs().Select(x => x.Label).ToList();
            this.value1.DataSource=
            this.valueList.DataSource = Global.GetQiyamts().Select(x => x.Label).ToList();
            
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

        private void sectionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var u = sender;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richresult.Text +=(natija.Checked?" U holda ": (richresult.Text.Length == 0 ? " Agar " : " va "))
                + key1.SelectedItem.ToString()
                + " = "
                + value1.SelectedItem.ToString()+(natija.Checked?" bo'ladi ":" bo'lsa ");
            export.keyValues.Add(new KeyValue()
            {
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
                foreach (var item in Global.GetExports().ToList().FirstOrDefault(x=>x.PredmetId==export.Id).keyValues)
                {
                    lsExports.Text += item.Key.ToString() +" = "+item.Value.ToString() +" bolsa va ";
                    richresult.Text = "";
                    export = new Export();
                }
                
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
            lsExports.Text = "";
            foreach (var item in Global.GetExports().ToList().FirstOrDefault().keyValues)
            {
                lsExports.Text +=
                    Global.GetAtributLabelById(item.Key) 
                    + " = " + 
                    Global.GetQiymatLabelById(item.Value) + " bolsa va ";
                richresult.Text = "";
                export = new Export();
            }
        }
    }
}
