using Kamban.Maui.Pages;
using Kamban.Maui.Services;

namespace Kamban.Maui
{
    public partial class MainPage : ContentPage
    {
        private readonly KambanService _kambanService;

        public MainPage(KambanService kambanService)
        {
            InitializeComponent();
            _kambanService = kambanService;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaDeTareasPage(_kambanService));
        }
    }

}
