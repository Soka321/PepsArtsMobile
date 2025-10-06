using PepsArts_Mobile.Models;
using PepsArts_Mobile.ViewModels;
using System.Net.Http.Json;

namespace PepsArts_Mobile.Views;

[QueryProperty(nameof(ExhibitionId), "id")]
public partial class ExibitionDetails : ContentPage
{
    HttpClient client;
    public int ExhibitionId { get; set; }

	public ExibitionDetails()
	{
		InitializeComponent();
        client = new HttpClient();
	}

    protected  async void ViewExhibition(object sender, EventArgs e)
    {
        var response = await client.GetAsync($"http://192.168.18.17:2025/PepsArts/Exhibitions/{1}");
        if (response != null)
        {
            lblTitle.Text = response.ToString();
        }
    }

    protected  void Register(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegisterExhibition());
    }
}