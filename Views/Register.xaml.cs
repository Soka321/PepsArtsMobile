using PepsArts_Mobile.Models;
using System.Data;
using System.Net.Http.Json;
using System.Text.Json;

namespace PepsArts_Mobile.Views;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}

    protected async void OnRegister(object sender, EventArgs e)
    {
        HttpClient client = new HttpClient();
        if (string.IsNullOrEmpty(Email.Text))
        {
            lblError.Text = "Please Provide email addrress";

        }
        else if (string.IsNullOrEmpty(Password.Text))
        {
            lblError.Text = "Please Provide  Password";
        }
        else if (string.IsNullOrEmpty(Name.Text))
        {
            lblError.Text = "Please Provide Name";
        }
        else if (string.IsNullOrEmpty(Surname.Text))
        {
            lblError.Text = "Please Provide Surname";
        }
        else if (string.IsNullOrEmpty(Age.Text))
        {
            lblError.Text = "Please Provide Age";
        }
        else if (string.IsNullOrEmpty(Gender.Text))
        {
            lblError.Text = "Please Provide gender";
        }

        else
        {
            //RegisterExhibition reg = new RegisterExhibition();

            var payload = new { email = Email.Text, password = Password.Text , first_name = Name.Text, last_name = Surname.Text, gender = Gender.Text, age = Convert.ToInt32(Age.Text), phone_number = Convert.ToInt32(PhoneNumber.Text), role = "Visitor", datecreated = DateTime.Now };
            try
            {
                var response = await client.PostAsJsonAsync($"http://192.168.18.17:2025/PepsArts/Register", payload);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    var result = System.Text.Json.JsonSerializer.Deserialize<User>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });/*
                    UserSession.id = result.id;
                    UserSession.name = result.name;
                    UserSession.role = result.role;  */


                    await DisplayAlert("Register", " Successfully registered in! : ", "OK");
                    lblError.Text = "Successful Register";
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
}