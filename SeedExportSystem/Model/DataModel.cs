using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedExportSystem.Model
{
    public static class Global
    {
        public static DbContextEntity dbo = new DbContextEntity();
    }
    public class DataModel: INotifyPropertyChanged
    {
        public static DbContextEntity dbo = Global.dbo;
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
            }
            return propertyRef;
        }
        public virtual void ApplyChanges()
        {
            dbo.SaveChanges();
        }
    }
}
