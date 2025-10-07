namespace PepsArts_Mobile.Views;

public partial class ViewArtPieces : ContentPage
{
	public ViewArtPieces()
	{
		InitializeComponent();
	}

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        /*var selectedExhibition = e.CurrentSelection?.FirstOrDefault() as Exhibition;
        if (selectedExhibition != null)
        {
            var vm = BindingContext as ExhibitionVM;
            await vm.TappedItem(selectedExhibition.Id);

            ExhibitionList.SelectedItem = null;
        }*/
    }
}