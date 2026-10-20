using AlisaPROJECT.Models;

using AlisaPROJECT.Services;

namespace AlisaPROJECT.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void goToSignUpClicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("//RegisterPage");
    }

	private async void loginClicked(object sender, EventArgs e)
	{
		string? email = emailEntry.Text;
		if (email == null) { errLoginEmail.Text = "Enter your email"; }
		else 
		{ 
			var foundUser = DataRepository.users.Find(u => u.Email.ToLower() == email.ToLower());
			if (foundUser == null) { errLoginEmail.Text = "User not Found, create an account?"; }
			else
			{
                string? pass = passwordEntry.Text;
                if (pass == null) { errLoginPassword.Text = "Enter your password"; }
				else
				{
					if(foundUser.Password != pass) { errLoginPassword.Text = "Incorrect password"; }
					else
					{
						DataRepository.currUser = foundUser;
						await Shell.Current.GoToAsync("//MainPage");
                    }
                }
            }
        }

    }

    private void OnShowPasswordClicked(object sender, EventArgs e)
    {

        bool isPass = passwordEntry.IsPassword;

        passwordEntry.IsPassword = !isPass;

        if (isPass)
        {
            showButton.Text = "show";
        }
        else
        {
            showButton.Text = "hide";
        }
    }
}