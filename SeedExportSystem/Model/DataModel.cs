using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedExportSystem.Model
{
    public static class Global
    {
        public static DbContextEntity dbo = new DbContextEntity();
        public static List<Predmet> LsPredmet { get; set; }
        public static List<Atribut> LsAtribut { get; set; }
        public static List<Qiymat> LsQiymat { get; set; }
        public static List<Export> LsExport { get; set; }
        public static void Update()
        {
            LsAtribut = dbo.Atributs.ToList();
            LsQiymat = dbo.Qiymats.ToList();
            LsPredmet = dbo.Predmets.ToList();
        }
        public static List<Predmet> GetPredmets()
              =>LsPredmet=LsPredmet??dbo.Predmets.ToList();
        public static List<Atribut> GetAtributs()
            =>LsAtribut = LsAtribut??dbo.Atributs.ToList();
        public static string GetAtributLabelById(int id)
            => GetAtributs()?.FirstOrDefault(x => x.Id == id).Label ?? "undefained";
        public static int GetAtributIdByLabel(string label)
            => GetAtributs()?.FirstOrDefault(x => x.Label ==label ).Id ?? 0;
        public static string GetQiymatLabelById(int id)
            => GetQiyamts()?.FirstOrDefault(x => x.Id == id).Label ?? "undefained";
        public static int GetQiymatIdBuLabel(string label)
           => GetQiyamts()?.FirstOrDefault(x => x.Label == label).Id ?? 0;
        public static List<Qiymat> GetQiyamts()
            =>LsQiymat = LsQiymat?? dbo.Qiymats.ToList();
        public static List<Export> GetExports()
            =>  dbo.Exports.Include("keyValues").ToList();
    }
    public class DataModel: INotifyPropertyChanged
    {
        private bool m_HasChanges;
        [NotMapped]
        public bool HasChanges
        {
            get { return m_HasChanges; }
            set
            {
                if (m_HasChanges != value)
                {
                    m_HasChanges = value;
                    OnPropertyChanged(nameof(HasChanges));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        protected virtual TValue GetValue<TValue>(string propertyName, TValue property)
        {
            return property;
        }

        protected virtual TValue SetValue<TValue>(string propertyName, ref TValue propertyRef, TValue value)
        {
            if (!object.Equals(propertyRef, value))
            {
                propertyRef = value;
                OnPropertyChanged(propertyName);
                HasChanges = true;
            }
            return propertyRef;
        }
        public virtual void ApplyChanges()
        {
            Global.dbo.SaveChanges();
            HasChanges = false;
        }
    }
}
