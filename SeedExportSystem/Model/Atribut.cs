using System.Data.Entity.Migrations;

namespace SeedExportSystem.Model
{
    public class Atribut: DataModel
    {
        private int m_Id;
        private string m_Label;
        private int m_PredmetId;
        private Predmet m_Predmet;

        public int Id { get=>GetValue(nameof(Id),m_Id); set=>SetValue(nameof(Id), ref m_Id, value); }
        public string Label { get => GetValue(nameof(Label), m_Label); set => SetValue(nameof(Label), ref m_Label, value); }
        public int PredmetId { get => GetValue(nameof(PredmetId), m_PredmetId); set => SetValue(nameof(PredmetId), ref m_PredmetId, value); }
        public Predmet Predmet { get => GetValue(nameof(Predmet), m_Predmet); set => SetValue(nameof(Predmet), ref m_Predmet, value); }
        public bool NotNulModel()
        {
            return m_Label.Length > 0 && m_PredmetId > 0 ? true : false;
        }
        public override void ApplyChanges()
        {
            Global.dbo.Atributs.AddOrUpdate(this);
            base.ApplyChanges();
        }
    }
}
