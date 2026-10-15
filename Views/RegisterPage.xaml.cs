using AlisaPROJECT.Services;
using System.Text.RegularExpressions;

namespace AlisaPROJECT.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private async void goToLogInClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginPage");
    }

    private async void registerClicked(object sender, EventArgs e)
    {
        errRegisterEmail.Text = "";
        errRegisterPassword.Text = "";

        string? email = emailEntry.Text;
        string? password = passwordEntry.Text;
        string? name = nameEntry.Text;

        bool isValid = true;

        if(email == null) { errRegisterEmail.Text = "Email is required"; isValid = false; }
        if(password == null) { errRegisterPassword.Text = "Password is required"; isValid = false; }
        if (name == null) { name = $"user {DataRepository.users.Count() + 1}"; }

        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(email, pattern))
        {
            errRegisterEmail.Text = "Invalid email format";
            isValid = false;
        }

        if(password.Length < 8)
        {
            errRegisterPassword.Text = "Password must be at least 8 characters long";
            isValid = false;
        }

        if (isValid)
        {
            bool successAdding = DataRepository.RegisterUser(email, password, name);
            if (successAdding)
            {
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                errRegisterEmail.Text = "Email already exists";
            }
        }
    }

    private void OnShowPasswordClicked(object sender, EventArgs e)
    {
        
        bool isPass = passwordEntry.IsPassword;

        passwordEntry.IsPassword = !isPass;

        if(isPass)
        {
            showButton.Text = "show";
        }
        else
        {
            showButton.Text = "hide";
        }
    }
}