using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedExportSystem.Model
{
    public class Export: DataModel
    {
        public int Id { get; set; }
        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }
        public ICollection<KeyValue> keyValues { get; set; }
        public Export()
        {
            keyValues = new HashSet<KeyValue>();
        }
        public override void ApplyChanges()
        {
            Global.dbo.Exports.AddOrUpdate(this);
            base.ApplyChanges();
        }
    }
    public class KeyValue
    {
        public int Id { get; set; }
        public int Key { get; set; }
        public int Value { get; set; }
        public bool isResult { get; set; }
    }
}
