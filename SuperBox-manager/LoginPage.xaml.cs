using System.Net.Mime;

namespace SuperBox_manager;



public partial class LoginPage : ContentPage
{


	private readonly FileService _fileService;
	public LoginPage()
	{
		InitializeComponent();
		_fileService = new FileService(); // Instanțierea serviciului
	}


    private async void ButtonClicked_OnClicked(object sender, EventArgs e)
	{
		string username = this.username.Text; 
		string password = this.password.Text; 
		string fileName = "credentialsTest.txt";

		

        User savedData = await _fileService.ReadTextFromFile(fileName, username, password);
		if (savedData != null)
		{




			//catre MainPage
			if (savedData.Admin == "true")
			{
                await Navigation.PushAsync(new Home(savedData));

            }
            else await Navigation.PushAsync(new MainPage(savedData));

		}
		else
		{

			await DisplayAlert("Eșec", "Utilizator sau parolă incorecte.", "OK");
		}
	}
	
	private async void EnterMethod_OnClicked(object? sender, EventArgs e)
	{
		
			 await Navigation.PushAsync(new SignInPage());

	}
}