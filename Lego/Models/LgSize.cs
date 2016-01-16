using Newtonsoft.Json;
using System.ComponentModel;

namespace Lego.Models
{
    public class LgSize : INotifyPropertyChanged
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public LgSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
