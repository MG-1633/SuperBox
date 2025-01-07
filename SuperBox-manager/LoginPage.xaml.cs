using System.Net.Mime;

namespace SuperBox_manager;

public partial class LoginPage : ContentPage
{
	private readonly FileService _fileService;
	bool userIsSigningIn = false;
	public LoginPage()
	{
		InitializeComponent();
		_fileService = new FileService(); // Instanțierea serviciului
	}

	private async void ButtonClicked_OnClicked(object sender, EventArgs e)
	{
		string username = this.username.Text; // Obținem textul din câmpul "username"
		string password = this.password.Text; // Obținem textul din câmpul "password"
		var random = new Random();
		string randomNumber = random.Next(100,1000).ToString();
		string filename = "credentials.txt";
	
		string savedData = await _fileService.ReadTextFromFile(filename, username, password);
		if (savedData == "true")
		{

			if (!string.IsNullOrWhiteSpace(savedData))
			{
				//await DisplayAlert("Date Salvate", savedData, "OK");
			}
			else
				await DisplayAlert("Info", "Nu există date salvate. Inregistreaza-te prima data."
					, "ОК");


				//către MainPage
				await Navigation.PushAsync(new MainPage());

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