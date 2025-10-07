using PepsArts_Mobile.Views;

namespace PepsArts_Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ExibitionDetails", typeof(ExibitionDetails));
            Routing.RegisterRoute("RegisterExhibition", typeof(RegisterExhibition));

        }
    }
}
