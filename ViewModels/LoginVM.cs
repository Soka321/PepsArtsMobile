

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PepsArts_Mobile.ViewModels
{
    public partial class LoginVM : ObservableObject
    {

        HttpClient client = new();

        [ObservableProperty]
        private  string email;

        [ObservableProperty]
        private  string password;

        [ObservableProperty]
        private  string message ;

        [RelayCommand]
        private async Task OnLogin()
        {

            if (string.IsNullOrEmpty(Email))
            {
                Message = "Invalid email entry Or Password";
                return;

            }
            else if (string.IsNullOrEmpty(Password))
            {
                Message = "Invalid email entry Or Password";
                return;
            }

            var payload = new
            {
                email = Email,
                password = Password

            };


           // var json = JsonConvert.SerializeObject(payload);

           // var content = new StringContent(json, Encoding.UTF8, "application/json");


            try
            {



                var response = await client.PostAsJsonAsync("http://192.168.18.17:2025/PepsArts/Login", payload);
                //Console.WriteLine($"Sending login payload: {json}");

                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {

                    var result = System.Text.Json.JsonSerializer.Deserialize<LoginResponse>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    UserSession.id = result.id;
                    UserSession.name = result.name;
                    UserSession.role = result.role;

                    Message = "Login successful!";
                    await Shell.Current.GoToAsync("ViewExhibitions");
                    Message = " Login Successfully ";
                    //await DisplayAlert("Login Failed", "Failed to Login, Please try again..", "Cancel");
                    // message = "Successfully logged in";

                }
                else
                {
                    Message = "Login Unsuccessful";
                }

            }
            catch (HttpRequestException ex)
            {


                Message = "Wrong Credintials, Plesae try again" + ex;

            }
        }


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

