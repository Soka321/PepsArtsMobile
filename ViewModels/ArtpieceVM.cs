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
    public partial class ArtpieceVM:ObservableObject
    {
        HttpClient client = new HttpClient();

        [ObservableProperty]
        private ArtPiece artpieceSelected = new();

        [ObservableProperty]
        private ObservableCollection<Artpiece> artpieces = new();

        public ArtpieceVM()
        {

            LoadArtpieces();
        }

        public async void LoadArtpieces()
        {
            try
            {
                var response = await client.GetFromJsonAsync<List<Artpiece>>($"http://192.168.18.17:2025/PepsArts/ArtPieces");

                if (response != null)
                {
                    /*foreach (var item in response)
                    {
                        item.Image_Url = $"http://192.168.18.17:2025{item.Image_Url}";
                    }*/
                    Artpieces = new ObservableCollection<Artpiece>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading exhibitions: {ex.Message}");
            }
        }

    }
}
