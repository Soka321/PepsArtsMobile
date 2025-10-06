using Microsoft.Maui.ApplicationModel.Communication;
using PepsArts_Mobile.Models;
using PepsArts_Mobile.ViewModels;
using System.Text;
using System.Text.Json;

namespace PepsArts_Mobile.Views;

public partial class Login : ContentPage
{
    private readonly UserService _userService;
    public Login()
	{
		InitializeComponent();
        _userService = new UserService();
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