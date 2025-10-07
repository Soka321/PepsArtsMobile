using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PepsArts_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace PepsArts_Mobile.ViewModels
{
    public partial  class ExhibitionDetailVM : ObservableObject
    {
        HttpClient client = new HttpClient();

        [ObservableProperty]
        private Exhibition exhibitions = new();

        public ExhibitionDetailVM(int id)
        {
            // VisitorId = UserSession.id;

            LoadSingleExhibition(id);
        }
        

        public async void LoadSingleExhibition(int id)
        {
            try
            {
                Exhibitions = await client.GetFromJsonAsync<Exhibition>($"http://192.168.18.17:2025/PepsArts/Exhibitions/{id}");

                Console.WriteLine($"Raw JSON: {Exhibitions}");
                Console.WriteLine($"Loaded exhibition: {Exhibitions?.Name}");

                // var json = await response.Content.ReadAsStringAsync();


                /* if (response != null)
                 {
                 // Exhibitions = JsonSerializer.Deserialize<Exhibition>(json);
                     Console.WriteLine($"Loaded exhibition: {Exhibitions?.Name}");

                 }*/
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading exhibitions: {ex.Message}");
            }
        }

        [RelayCommand]
        public async Task Register(Exhibition exhibition)
        {
            if (exhibition == null) return;
            await Shell.Current.GoToAsync($"RegisterExhibition?exhibitionId=id");

        }
    }
}
