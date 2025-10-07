using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PepsArts_Mobile.Models;
using PepsArts_Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PepsArts_Mobile.ViewModels
{
    public partial class RegisterExhibitionVM : ObservableObject
    {
        HttpClient client = new HttpClient();

        [ObservableProperty]
        Exhibition exhibition = new();

        
        private  int User_Id;

        

        [ObservableProperty]
        private string message;

        
        public RegisterExhibitionVM(int id)
        {
           // VisitorId = UserSession.id;

            LoadSingleExhibition(id);
        }

        public async void LoadSingleExhibition(int id)
        {
            try
            {
                var response = await client.GetAsync($"http://192.168.18.17:2025/PepsArts/Exhibitions/{id}");
                var json = await response.Content.ReadAsStringAsync();
                

                if (response != null)
                {
                    Exhibition = JsonSerializer.Deserialize<Exhibition>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading exhibitions: {ex.Message}");
            }
        }
        
        [RelayCommand]
        public async Task RegisterExhibition(Exhibition_Registration reg)

        {
            User_Id = UserSession.id;
            if (User_Id != 0)
            {
                Message = "Please login First to register for an Exhibition";
                return;
            }
            var payload = new { User_Id, NumberOfAttendess = reg.number_of_attendees, Date_Regisitered = reg.registration_date };
            try
            {
                var response = await client.PostAsJsonAsync($"http://192.168.18.17:2025/PepsArts/Exhibitions/Register/{reg.exhibition_id}", payload);

                if (response.IsSuccessStatusCode)
                {
                    Message= "Sussessfully Registered for Exhibition";
                    await Shell.Current.GoToAsync("ViewExhibitions");

                }

            }
            catch (Exception ex)
            {
                Message= ex.Message;
            }
        }
    }
}
