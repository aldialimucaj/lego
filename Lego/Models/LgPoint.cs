using Newtonsoft.Json;
using System.ComponentModel;

namespace Lego.Models
{
    public class LgPoint : INotifyPropertyChanged
    {
        public int X { get; set; }
        public int Y { get; set; }

        public LgPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
