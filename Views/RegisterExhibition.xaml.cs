using Microsoft.Maui.ApplicationModel.Communication;

namespace PepsArts_Mobile.Views;

public partial class RegisterExhibition : ContentPage
{
	public RegisterExhibition()
	{
		InitializeComponent();
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