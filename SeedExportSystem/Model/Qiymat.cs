using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedExportSystem.Model
{
    public class Qiymat: DataModel
    {
        private int m_Id;
        private string m_Label;
        private int m_AtributId;
        public Atribut m_Atribut;

        public int Id { get => GetValue(nameof(Id), m_Id); set => SetValue(nameof(Id), ref m_Id, value); }
        public string Label { get => GetValue(nameof(Label), m_Label); set => SetValue(nameof(Label), ref m_Label, value); }
        public int AtributId { get => GetValue(nameof(AtributId), m_AtributId); set => SetValue(nameof(AtributId), ref m_AtributId, value); }
        public Atribut Atribut { get => GetValue(nameof(Atribut), m_Atribut); set => SetValue(nameof(Atribut), ref m_Atribut, value); }
        public bool NotNull()
            => m_Label.Length>0 && m_AtributId>0 ? true : false;
        public override void ApplyChanges()
        {
            dbo.Qiymats.AddOrUpdate(this);
            base.ApplyChanges();
        }
    }
}
