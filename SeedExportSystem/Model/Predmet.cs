using System.Data.Entity.Migrations;

namespace SeedExportSystem.Model
{
    public class Predmet: DataModel
    {
        private int m_Id;
        private string m_Label;

        public int Id { get => GetValue(nameof(Id), m_Id); set => SetValue(nameof(Id), ref m_Id, value); }
        public string Label { get => GetValue(nameof(Label), m_Label); set => SetValue(nameof(Label), ref m_Label, value); }
        public bool NotNull()
            => m_Label.Length>0 ? true:false;
        public override void ApplyChanges()
        {
            dbo.Predmets.AddOrUpdate(this);
            base.ApplyChanges();
        }
    }
}
