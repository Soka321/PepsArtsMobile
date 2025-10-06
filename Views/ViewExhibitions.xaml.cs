using PepsArts_Mobile.Models;
using PepsArts_Mobile.ViewModels;
using System.Collections.ObjectModel;
using System.Net.Http.Json;


namespace PepsArts_Mobile.Views;

public partial class ViewExhibitions : ContentPage
{
    HttpClient client = new();
    UserService _userService;

	public ViewExhibitions()
	{
		InitializeComponent();
        _userService = new UserService();
        //LoadExhibitions();
	}

    private async void OnView(object sender, EventArgs e)
    {
        try
        {
            var data = await client.GetFromJsonAsync<List<Exhibition>>($"http://192.168.18.17:2025/PepsArts/Exhibitions");

            if (data != null)
            {
                lblName.Text = data[0].Name;
                lblDescription.Text = data[0].Description;
                lblStatus.Text = data[0].Status;
                lblStartDate.Text = data[0].Start_Date.ToString();
                lblEndDate.Text = data[0].End_Date.ToString();
                // lblStatus.Text = data[0].Status;

            }
            else
            {
                lblExhibitions.Text = "No Exhibitions found !";
            }

        }
        catch (Exception ex)
        {
            lblError.Text= "Failed to get Exhibitions" + ex.Message;
        }

        

    }
    public async void LoadExhibitions()
    {
        try
        {
            var response = await client.GetFromJsonAsync<List<Exhibition>>($"http://192.168.18.17:2025/PepsArts/Exhibitions");

            if (response != null)


            {

                
                ObservableCollection<Exhibition> Exhibitions = new ObservableCollection<Exhibition>(response);
                foreach (var exhibition in Exhibitions)
                {
                    lblName.Text = exhibition.Name;
                    lblStartDate.Text = exhibition.Start_Date.ToString();
                    lblEndDate.Text = exhibition.End_Date.ToString();
                    lblStatus .Text = exhibition.Status;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading exhibitions: {ex.Message}");
        }
    }
    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedExhibition = e.CurrentSelection?.FirstOrDefault() as Exhibition;
        if (selectedExhibition != null)
        {
            var vm = BindingContext as ExhibitionVM;
            await vm.TappedItem(selectedExhibition.Id);

            ExhibitionList.SelectedItem = null;
        }
    }
}