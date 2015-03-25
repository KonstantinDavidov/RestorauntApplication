using System.ComponentModel;

namespace TestExRestaurant.Utils
{
    /// <summary>
    /// Base Class wich implements INotifyPropertyChanged
    /// </summary>
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
