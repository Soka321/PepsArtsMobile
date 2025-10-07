using Newtonsoft.Json;
using PepsArts_Mobile.Models;
using PepsArts_Mobile.ViewModels;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PepsArts_Mobile.Views;

[QueryProperty(nameof(ExhibitionId), "id")]
public partial class ExibitionDetails : ContentPage
{
    HttpClient client= new HttpClient();
    public int ExhibitionId { get; set; }

	public ExibitionDetails()
	{
		InitializeComponent();
        //client = new HttpClient();
       // OnAppearing();
        //BindingContext = new ExhibitionDetailVM(exhibition_id);
    }

    

    protected  override void OnAppearing()
    {
        

        base.OnAppearing();
        
        BindingContext = new ExhibitionDetailVM(ExhibitionId);

        

    }

    

    protected  void OnRegister(object sender, EventArgs e)
    {

        var button = sender as Button;
        var exhibition = button?.BindingContext as Exhibition;
        if (exhibition != null)
        {
            Shell.Current.GoToAsync($"RegisterExhibition?id={exhibition.Id}");
        }
        //Shell.Current.GoToAsync($"RegisterExhibition?exhibitionId=id");

        // Navigation.PushAsync(new RegisterExhibition());
    }

    protected async void ViewExhibition(object sender, EventArgs e)
    {
        
        try
        {
            // http://192.168.18.17:2025/PepsArts/Exhibitions/{1}
            int one = ExhibitionId;
            lblId.Text = one.ToString();
            var response = await client.GetAsync($"http://10.0.2.2:2025/PepsArts/Exhibitions/{one}");
            if (response != null )
            {
                var json = await response.Content.ReadAsStringAsync();
                var exhibition = JsonConvert.DeserializeObject<Exhibition>(json);
                lblTitle.Text = exhibition.Description;
            }
            else
            {
                lblTitle.Text = " Could not load exhibition";
            }
        }
        catch (Exception ex)
        {
            lblTitle.Text = ex.Message;
        }


        //
        
    //OnAppearing();
    /*try
     {
         // http://192.168.18.17:2025/PepsArts/Exhibitions/{1}
         int one = 1;

         var response = await client.GetAsync($"http://10.0.2.2:2025/PepsArts/Exhibitions/{one}");
         if (response != null)
         {
             lblTitle.Text = response.ToString();
         }
     }
     catch (Exception ex)
     {
         lblTitle.Text = ex.Message;
     }*/
}


    
}