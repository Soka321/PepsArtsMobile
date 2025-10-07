using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using PepsArts_Mobile.ViewModels;
using System.Net.Http.Json;


namespace PepsArts_Mobile.Views;

[QueryProperty(nameof(ExhibitionId), "id")]
public partial class RegisterExhibition : ContentPage
{

    HttpClient client = new HttpClient();
    public int ExhibitionId { get; set; }

    public RegisterExhibition()
	{
		InitializeComponent();
       // BindingContext = new RegisterExhibitionVM(exhibitionId);
    }

    //Console.WriteLine("Button clicked!");
   

    protected override void OnAppearing()
    {


        base.OnAppearing();
        BindingContext = new RegisterExhibitionVM(ExhibitionId);
    }
    private void OnExhibitionRegister(object sender, EventArgs e)
    {
        //use an if statement for if registered then the others use else if

        if (string.IsNullOrEmpty(NumAttendees.Text))
        {
            lblError.Text = "Please Provide number of Attendess";

        }
        
    }

    protected async void RegExhibition(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(NumAttendees.Text))
        {
            lblError.Text = "Please Provide number of Attendess";

        }
        //RegisterExhibition reg = new RegisterExhibition();
        string Message;
        int user_id = UserSession.id;
        if (user_id == 0)
        {
            lblError.Text = "Please login First to register for an Exhibition";
            return;
        }
        var payload = new { user_id, number_of_attendees = Convert.ToInt32(NumAttendees.Text), registration_date = DateTime.Now };
        try
        {
            var response = await client.PostAsJsonAsync($"http://192.168.18.17:2025/PepsArts/Exhibitions/Register/{ExhibitionId}", payload);

            if (response.IsSuccessStatusCode)
            {
                UserSession.registered = "Registered";
                await DisplayAlert("Exhibition Registration",UserSession.name+"" +"Successfully registered for Exhibition number : "+ ExhibitionId, "OK");
                lblError.Text = "Successfully Registered for Exhibition";
                await Navigation.PushAsync(new ViewExhibitions());

            } else
            {
                lblError.Text = "Server error, could not Register for Exhibition, please try again";
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    /* try
     {
         string jsonString = JsonSerializer.Serialize(usertolog);
         HttpContent content = new StringContent(jsonString, Encoding.UTF8,"application/json");

         var data = await _userService.Login<User>("http://192.168.18.17:2025/PepsArts/Login", content);

         if (data.role == "Visitor")
         {
             UserSession.id = data.id;
             UserSession.name = data.email;
             UserSession.role = data.role;

             await Navigation.PushAsync(new MainPage());
             await DisplayAlert("Success", "Welcome dear Visitor", " Ok");
         }

         else
         {
             await DisplayAlert("Test User Role:", Convert.ToString(data.role), "Ok");
             lblError.Text = "User not registered";
         }

     }
     catch (Exception ex)
     {

         lblError.Text = ex.Message;

     }   */

}

       
    