using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kamban.Maui.ModelViews
{
    public class BaseModelView : INotifyPropertyChanged
    {
        private bool _estaCargando;
        public bool EstaCargando
        {
            get => _estaCargando;
            set { _estaCargando = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
