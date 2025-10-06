
using PepsArts_Mobile.Views;
using System.Text;

namespace PepsArts_Mobile
{
    public partial class MainPage : ContentPage
    {
        HttpClient client = new HttpClient();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLogin(Object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Login());
        }

        private async void OnExhibition(Object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ViewExhibitions());
        }

    }
}
