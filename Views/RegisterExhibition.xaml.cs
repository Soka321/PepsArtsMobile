using Microsoft.Maui.ApplicationModel.Communication;
using PepsArts_Mobile.ViewModels;

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
        else if (string.IsNullOrEmpty(Date.Text))
        {
            lblError.Text = "Provide the date Please";
        }
    }
    }