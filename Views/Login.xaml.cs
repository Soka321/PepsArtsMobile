using Microsoft.Maui.ApplicationModel.Communication;
using PepsArts_Mobile.Models;
using PepsArts_Mobile.ViewModels;
using System.Net.Http.Json;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;

namespace PepsArts_Mobile.Views;

public partial class Login : ContentPage
{
    private readonly UserService _userService;

    HttpClient client = new HttpClient();
    public Login()
	{
		InitializeComponent();
        _userService = new UserService();
    }


    protected async void OnLogin(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(email.Text))
        {
            lblError.Text = "Please Provide email addrress";

        }
        else if (string.IsNullOrEmpty(Password.Text))
        {
            lblError.Text = "Invalid email entry Or Password";
        }

        else
        {
            //RegisterExhibition reg = new RegisterExhibition();
            
            var payload = new { email = email.Text, password = Password.Text };
            try
            {
                var response = await client.PostAsJsonAsync($"http://192.168.18.17:2025/PepsArts/Login", payload);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    var result = System.Text.Json.JsonSerializer.Deserialize<LoginResponse>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    UserSession.id = result.id;
                    UserSession.name = result.name;
                    UserSession.role = result.role;


                    await DisplayAlert("Login", " Successfully logged in! : "+ UserSession.name, "OK");
                    lblError.Text = "Successful login";
                    await Navigation.PushAsync(new MainPage());

                }
                else
                {
                    lblError.Text = "Failed to login, please try again";
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }




    private void OnLog(object sender, EventArgs e)
    {
        //use an if statement for if registered then the others use else if

        if (string.IsNullOrEmpty(email.Text))
        {
            lblError.Text = "Invalid email entry Or Password";

        }
        else if (string.IsNullOrEmpty(Password.Text))
        {
            lblError.Text = "Invalid email entry Or Password";
        }

        else
        {

            //Takes user to login page1 ;

            


            var usertolog = new User
            {


                email = email.Text,
                password = Password.Text,
                first_name = "",
                last_name = "",
                gender = "",
                role = "Visitor",
            };

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
    }
    private void GoBack(object sender, EventArgs e)
    {
        //Takes the user back
        Navigation.PopAsync();
    }
}

public class LoginResponse
{
    // public bool Success { get; set; }
    //public string message { get; set; }
    public string role { get; set; }
    public string name { get; set; }
    public int id { get; set; }
}
