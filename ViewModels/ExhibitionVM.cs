
using CommunityToolkit.Mvvm.ComponentModel;
using PepsArts_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PepsArts_Mobile.ViewModels
{
    public partial class ExhibitionVM : ObservableObject
    {
        HttpClient client = new HttpClient();

        [ObservableProperty]
        private Exhibition exhibitionSelected = new();

        [ObservableProperty]
        private  ObservableCollection<Exhibition> exhibitions= new();

        public ExhibitionVM()
        { 
       
            LoadExhibitions();
         }
        
        public async void LoadExhibitions()
        {
            try
            {
                var response = await client.GetFromJsonAsync<List<Exhibition>>($"http://192.168.18.17:2025/PepsArts/Exhibitions");

                if (response !=null)
                {
                    Exhibitions = new ObservableCollection<Exhibition>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading exhibitions: {ex.Message}");
            }
        }

        public async Task TappedItem(int exhibitionId)
        {
            //if (exhibition == null) return;

            
           await  Shell.Current.GoToAsync($"ExhibitionDetails?id={exhibitionId}");
        }
    }
}
